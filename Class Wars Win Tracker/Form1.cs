using Gma.System.MouseKeyHook;

using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace Class_Wars_Win_Tracker
{
    public partial class Form1 : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        private readonly ClassWarsWinTracker Stats;

        private readonly IKeyboardEvents KeyboardHook;

        private static Process GameProcess => Process.GetProcessesByName("hl2").FirstOrDefault(p => p.MainWindowTitle.Equals("Team Fortress 2"), null);
        private bool GameIsOpen => GameProcess != null;
        private bool GameIsForeground => GameIsOpen && GetForegroundProcess().Id == GameProcess.Id;

        public Form1()
        {
            KeyboardHook = Hook.GlobalEvents();

            InitializeComponent();

            Stats = File.Exists("stats.json") ? JsonSerializer.Deserialize<ClassWarsWinTracker>(File.ReadAllText("stats.json")) : DefaultStats.Get;

            CbxCtrlPt.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            CbxStage.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            CbxBlu.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            CbxRed.SelectedIndexChanged += ComboBox_SelectedIndexChanged;

            CbxCtrlPt.SelectedIndex = 0;
            CbxStage.SelectedIndex = 0;

            KeyboardHook.KeyDown += (_, a) =>
            {
                if (a.Control && GameIsForeground)
                {
                    if (a.KeyCode == Keys.Up && CbxBlu.SelectedIndex > 0)
                    {
                        a.Handled = true;
                        --CbxBlu.SelectedIndex;
                    }
                    else if (a.KeyCode == Keys.Down && CbxBlu.SelectedIndex < 8)
                    {
                        a.Handled = true;
                        ++CbxBlu.SelectedIndex;
                    }
                    else if (a.KeyCode == Keys.Left && CbxStage.SelectedIndex > 0)
                    {
                        a.Handled = true;
                        --CbxStage.SelectedIndex;
                        CbxCtrlPt.SelectedIndex = 0;
                    }
                    else if (a.KeyCode == Keys.Right && CbxStage.SelectedIndex < 2)
                    {
                        a.Handled = true;
                        ++CbxStage.SelectedIndex;
                        CbxCtrlPt.SelectedIndex = 0;
                    }
                }

                if (a.Alt && GameIsForeground)
                {
                    if (a.KeyCode == Keys.Up && CbxRed.SelectedIndex > 0)
                    {
                        a.Handled = true;
                        --CbxRed.SelectedIndex;
                    }
                    else if (a.KeyCode == Keys.Down && CbxRed.SelectedIndex < 8)
                    {
                        a.Handled = true;
                        ++CbxRed.SelectedIndex;
                    }
                    else if (a.KeyCode == Keys.PageUp && BtnBluWins.Enabled)
                    {
                        a.Handled = true;
                        BtnBluWins_Click(KeyboardHook, new());
                    }
                    else if (a.KeyCode == Keys.PageDown && BtnRedWins.Enabled)
                    {
                        a.Handled = true;
                        BtnRedWins_Click(KeyboardHook, new());
                    }
                }
            };

            LblBlu.MouseClick += (_, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    List<Label> stats = new();

                    for (int blu = 0; blu < 9; blu++)
                    {
                        for (int red = 0; red < 9; red++)
                        {
                            for (int sge = 0; sge < 3; sge++)
                            {
                                for (int cpt = 0; cpt < 2; cpt++)
                                {
                                    base.Text = $"{blu + 1}{red + 1}{sge + 1}{cpt + 1}";

                                    Label redClass = new()
                                    {
                                        Name = $"LblBluClass{blu + 1}",
                                        Text = $"{blu}",
                                        AutoSize = true,
                                        ForeColor = Color.Blue
                                    };

                                    Label bluWins = new()
                                    {
                                        //Name = $"LblBluWins{blu}{red}{sge}{cpt}",
                                        Name = $"LblBluWins{blu + 1}{red + 1}{sge + 1}{cpt + 1}",
                                        Text = $"{Stats[blu].VsRed[red].Stage[sge].ControlPoint[cpt].BluWins}",
                                        AutoSize = true,
                                        ForeColor = Color.Blue,
                                    };

                                    if (sge is 0 && cpt is 0)
                                    {
                                        bluWins.Font = BoldFont(bluWins.Font);
                                    }

                                    Label redWins = new()
                                    {
                                        Name = $"LblRedWins{blu}{red}{sge}{cpt}",
                                        Text = $"{Stats[blu].VsRed[red].Stage[sge].ControlPoint[cpt].RedWins}",
                                        AutoSize = true,
                                        ForeColor = Color.Red,
                                    };

                                    bluWins.MouseClick += (s, e) =>
                                    {
                                        Label lbl = (Label)s;

                                        if (e.Button == MouseButtons.Right)
                                        {
                                            MessageBox.Show($"{lbl.Name}");
                                        }
                                    };

                                    redWins.MouseClick += (s, e) =>
                                    {
                                        Label lbl = (Label)s;

                                        if (e.Button == MouseButtons.Right)
                                        {
                                            MessageBox.Show($"{lbl.Name}");
                                        }
                                    };

                                    stats.Add(bluWins);
                                    stats.Add(redWins);
                                }
                            }
                        }
                    }

                    Form FrmStats = new();

                    int lastX = 0;

                    for (int i = 0; i < stats.Count; i++)
                    {
                        if (i % 108 == 0)
                        {
                            lastX = 0;
                        }
                        else
                        {
                            lastX += 12 + (i % 4 == 0 ? 4 : 0);
                        }

                        stats[i].Location = new(lastX, stats[0].Size.Height * (i / 108) + (i / 108 > 0 ? 2 : 0));
                        FrmStats.Controls.Add(stats[i]);

                        Text = i.ToString();
                    }

                    FrmStats.Show();
                    FrmStats.ClientSize = new(FrmStats.Controls["LblRedWins8821"].Location.X + FrmStats.Controls["LblRedWins8821"].Size.Width, FrmStats.Controls["LblRedWins8821"].Location.Y + FrmStats.Controls["LblRedWins8821"].Size.Height);
                    Text = "Class Wars Dustbowl Wins Tracker";
                }
            };

            LblRed.MouseClick += (_, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    List<string> stuff = new();

                    for (int blu = 0; blu < 9; blu++)
                    {
                        for (int red = 0; red < 9; red++)
                        {
                            for (int sge = 0; sge < 3; sge++)
                            {
                                base.Text = $"{blu + 1}{red + 1}{sge + 1}";

                                if (Stats[blu].VsRed[red].Stage[sge].ControlPoint[1].BluWins + Stats[blu].VsRed[red].Stage[sge].ControlPoint[1].RedWins > Stats[blu].VsRed[red].Stage[sge].ControlPoint[0].BluWins)
                                {
                                    stuff.Add($"{blu}, {red}, {sge} -> {Stats[blu].VsRed[red].Stage[sge].ControlPoint[1].BluWins} + {Stats[blu].VsRed[red].Stage[sge].ControlPoint[1].RedWins} > {Stats[blu].VsRed[red].Stage[sge].ControlPoint[0].BluWins}");
                                    Stats[blu].VsRed[red].Stage[sge].ControlPoint[0].BluWins = Stats[blu].VsRed[red].Stage[sge].ControlPoint[1].BluWins + Stats[blu].VsRed[red].Stage[sge].ControlPoint[1].RedWins;
                                }
                            }
                        }
                    }

                    if (stuff.Any())
                    {
                        MessageBox.Show(string.Join(Environment.NewLine, stuff));
                    }
                }
            };

            Task.Run(() =>
            {
                bool gameWasOpen = false;
                while (!Disposing)
                {
                    if (GameProcess != null && !gameWasOpen || GameProcess == null && gameWasOpen)
                    {
                        Invoke(() =>
                        {
                            if (gameWasOpen)
                            {
                                CbxStage.SelectedIndex = 0;
                                CbxCtrlPt.SelectedIndex = 0;
                                CbxBlu.SelectedIndex = -1;
                                CbxRed.SelectedIndex = -1;
                            }
                            else if (CbxBlu.SelectedIndex >= 0 && CbxRed.SelectedIndex >= 0 && CbxStage.SelectedIndex >= 0 && CbxCtrlPt.SelectedIndex >= 0)
                            {
                                BtnBluWins.Enabled = true;
                                BtnBluSubtract.Enabled = true;
                                BtnRedWins.Enabled = true;
                                BtnRedSubtract.Enabled = true;
                            }
                        });

                        gameWasOpen = !gameWasOpen;
                    }

                    Task.Delay(1000).Wait();
                }
            });
        }

        public StageControlPoint Tracker => Stats[CbxBlu.SelectedIndex].VsRed[CbxRed.SelectedIndex].Stage[CbxStage.SelectedIndex].ControlPoint[CbxCtrlPt.SelectedIndex];

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbxBlu.SelectedIndex < 0 || CbxRed.SelectedIndex < 0 || CbxStage.SelectedIndex < 0 || CbxCtrlPt.SelectedIndex < 0 || !GameIsOpen)
            {
                BtnBluWins.Enabled = false;
                BtnBluSubtract.Enabled = false;
                BtnRedWins.Enabled = false;
                BtnRedSubtract.Enabled = false;

                LblBluWins.Text = $"BLU Wins: 0";
                LblRedWins.Text = $"RED Wins: 0";
            }
            else
            {
                BtnBluWins.Enabled = true;
                BtnBluSubtract.Enabled = true;
                BtnRedWins.Enabled = true;
                BtnRedSubtract.Enabled = true;

                LblBluWins.Text = $"BLU Wins: {Tracker.BluWins}";
                LblRedWins.Text = $"RED Wins: {Tracker.RedWins}";
            }
        }

        private void BtnBluWins_Click(object sender, EventArgs e)
        {
            LblBluWins.Text = $"BLU Wins: {++Tracker.BluWins}";
            File.WriteAllText("stats.json", JsonSerializer.Serialize(Stats, options: new() { WriteIndented = true, IncludeFields = true }));

            LblLastWin1.Text = $"BLU {CbxBlu.Text} won against";
            LblLastWin2.Text = $"RED {CbxRed.Text} on {CbxStage.Text}, {CbxCtrlPt.Text}";

            if (CbxCtrlPt.SelectedIndex == 1)
            {
                CbxCtrlPt.SelectedIndex = 0;

                if (CbxStage.SelectedIndex == 2)
                {
                    CbxStage.SelectedIndex = 0;
                }
                else
                {
                    ++CbxStage.SelectedIndex;
                }

                CbxBlu.SelectedIndex = -1;
                CbxRed.SelectedIndex = -1;
            }
            else
            {
                CbxCtrlPt.SelectedIndex = 1;
            }

            SwitchToThisWindow(GameProcess.MainWindowHandle, true);
        }

        private void BtnRedWins_Click(object sender, EventArgs e)
        {
            LblRedWins.Text = $"RED Wins: {++Tracker.RedWins}";
            File.WriteAllText("stats.json", JsonSerializer.Serialize(Stats, options: new() { WriteIndented = true, IncludeFields = true }));

            LblLastWin1.Text = $"RED {CbxRed.Text} won against";
            LblLastWin2.Text = $"BLU {CbxBlu.Text} on {CbxStage.Text}, {CbxCtrlPt.Text}";

            CbxStage.SelectedIndex = 0;
            CbxCtrlPt.SelectedIndex = 0;
            CbxBlu.SelectedIndex = -1;
            CbxRed.SelectedIndex = -1;

            SwitchToThisWindow(GameProcess.MainWindowHandle, true);
        }

        private void BtnBluSubtract_Click(object sender, EventArgs e)
        {
            LblBluWins.Text = $"BLU Wins: {--Tracker.BluWins}";
            File.WriteAllText("stats.json", JsonSerializer.Serialize(Stats, options: new() { WriteIndented = true, IncludeFields = true }));
        }

        private void BtnRedSubtract_Click(object sender, EventArgs e)
        {
            LblRedWins.Text = $"RED Wins: {--Tracker.RedWins}";
            File.WriteAllText("stats.json", JsonSerializer.Serialize(Stats, options: new() { WriteIndented = true, IncludeFields = true }));
        }

        public static Font BoldFont(Font font)
        {
            if (font != null)
            {
                FontStyle fontStyle = font.Style;
                if ((fontStyle & FontStyle.Bold) == 0)
                {
                    fontStyle |= FontStyle.Bold;
                    font = new Font(font, fontStyle);
                }
            }
            return font;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        public static Process GetForegroundProcess()
        {
            IntPtr hWnd = GetForegroundWindow(); // Get foreground window handle
            GetWindowThreadProcessId(hWnd, out uint processID); // Get PID from window handle
            Process fgProc = Process.GetProcessById(Convert.ToInt32(processID)); // Get it as a C# obj.
            // NOTE: In some rare cases ProcessID will be NULL. Handle this how you want. 
            return fgProc;
        }
    }
}