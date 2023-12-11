using Gma.System.MouseKeyHook;

using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Class_Wars_Win_Tracker
{
    public partial class FrmMain : Form
    {
        [LibraryImport("user32.dll")]
        private static partial void SwitchToThisWindow(IntPtr hWnd, [MarshalAs(UnmanagedType.Bool)] bool fAltTab);

        private readonly ClassWarsWinTracker Stats = new();

        private readonly IKeyboardEvents KeyboardHook;

        private static Process GameProcess => Process.GetProcessesByName("hl2").FirstOrDefault(p => p.MainWindowTitle.Equals("Team Fortress 2"), null);
        private static bool GameIsOpen => GameProcess != null;
        private static bool GameIsForeground => GameIsOpen && GetForegroundProcess().Id == GameProcess.Id;

        private const byte DataFormatVersion = 0;
        private const string DataFile = "stats.dat";

        public void LoadData()
        {
            byte[] data = File.ReadAllBytes(DataFile);

            if (data[0] == 0)
            {
                int i = 1;
                for (int blu = 0; blu < 9; blu++)
                {
                    for (int red = 0; red < 9; red++)
                    {
                        for (int sge = 0; sge < 3; sge++)
                        {
                            for (int cpt = 0; cpt < 2; cpt++)
                            {
                                Stats.Blu[blu].Red[red].Stage[sge].ControlPoint[cpt].BluWins = data[i++];
                                Stats.Blu[blu].Red[red].Stage[sge].ControlPoint[cpt].RedWins = data[i++];
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("wut?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                Application.Exit();
            }
        }

        public void SaveData()
        {
            List<byte> data = [DataFormatVersion];

            for (int blu = 0; blu < 9; blu++)
            {
                for (int red = 0; red < 9; red++)
                {
                    for (int sge = 0; sge < 3; sge++)
                    {
                        for (int cpt = 0; cpt < 2; cpt++)
                        {
                            data.Add(Stats.Blu[blu].Red[red].Stage[sge].ControlPoint[cpt].BluWins);
                            data.Add(Stats.Blu[blu].Red[red].Stage[sge].ControlPoint[cpt].RedWins);
                        }
                    }
                }
            }

            File.WriteAllBytes(DataFile, [.. data]);
        }

        public FrmMain()
        {
            KeyboardHook = Hook.GlobalEvents();

            InitializeComponent();

            LoadData();

            CbxCtrlPt.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            CbxStage.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            CbxBlu.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            CbxRed.SelectedIndexChanged += ComboBox_SelectedIndexChanged;

            CbxCtrlPt.SelectedIndex = 0;
            CbxStage.SelectedIndex = 0;

            KeyboardHook.KeyDown += (_, e) =>
            {
                if (e.Control && GameIsForeground)
                {
                    if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9 && CbxBlu.Enabled)
                    {
                        e.Handled = true;
                        CbxBlu.SelectedIndex = Convert.ToInt32(e.KeyCode.ToString().Last().ToString()) - 1;
                    }
                    else if (e.KeyCode == Keys.Up && CbxBlu.SelectedIndex > 0 && CbxBlu.Enabled)
                    {
                        e.Handled = true;
                        --CbxBlu.SelectedIndex;
                    }
                    else if (e.KeyCode == Keys.Down && CbxBlu.SelectedIndex < 8 && CbxBlu.Enabled)
                    {
                        e.Handled = true;
                        ++CbxBlu.SelectedIndex;
                    }
                    else if (e.KeyCode == Keys.Left && CbxStage.SelectedIndex > 0 && CbxStage.Enabled)
                    {
                        e.Handled = true;
                        --CbxStage.SelectedIndex;
                        CbxCtrlPt.SelectedIndex = 0;
                    }
                    else if (e.KeyCode == Keys.Right && CbxStage.SelectedIndex < 2 && CbxStage.Enabled)
                    {
                        e.Handled = true;
                        ++CbxStage.SelectedIndex;
                        CbxCtrlPt.SelectedIndex = 0;
                    }
                }

                if (e.Alt && GameIsForeground)
                {
                    if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9 && CbxRed.Enabled)
                    {
                        e.Handled = true;
                        CbxRed.SelectedIndex = Convert.ToInt32(e.KeyCode.ToString().Last().ToString()) - 1;
                    }
                    else if (e.KeyCode == Keys.Up && CbxRed.SelectedIndex > 0 && CbxRed.Enabled)
                    {
                        e.Handled = true;
                        --CbxRed.SelectedIndex;
                    }
                    else if (e.KeyCode == Keys.Down && CbxRed.SelectedIndex < 8 && CbxRed.Enabled)
                    {
                        e.Handled = true;
                        ++CbxRed.SelectedIndex;
                    }
                    else if (e.KeyCode == Keys.PageUp && BtnBluWins.Enabled)
                    {
                        e.Handled = true;
                        BtnBluWins_Click(KeyboardHook, new());
                    }
                    else if (e.KeyCode == Keys.PageDown && BtnRedWins.Enabled)
                    {
                        e.Handled = true;
                        BtnRedWins_Click(KeyboardHook, new());
                    }
                }
            };

            LblBlu.MouseClick += (_, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    List<Label> stats = [];

                    int const_space = 10;
                    int space = const_space;

                    for (int blu = 0; blu < 9; blu++)
                    {
                        for (int red = 0; red < 9; red++)
                        {
                            for (int sge = 0; sge < 3; sge++)
                            {
                                for (int cpt = 0; cpt < 2; cpt++)
                                {
                                    base.Text = $"{blu + 1}{red + 1}{sge + 1}{cpt + 1}";

                                    StageControlPoint cp = Stats.Blu[blu].Red[red].Stage[sge].ControlPoint[cpt];
                                    byte bluWins = cp.BluWins;
                                    byte redWins = cp.RedWins;

                                    if (const_space * bluWins.ToString().Length > space)
                                    {
                                        space = const_space * bluWins.ToString().Length;
                                    }
                                    else if (const_space * redWins.ToString().Length > space)
                                    {
                                        space = const_space * redWins.ToString().Length;
                                    }

                                    Label lblRedClass = new()
                                    {
                                        Name = $"LblBluClass{blu + 1}",
                                        Text = $"{blu}",
                                        AutoSize = true,
                                        ForeColor = Color.Blue
                                    };

                                    Label lblBluWins = new()
                                    {
                                        //Name = $"LblBluWins{blu}{red}{sge}{cpt}",
                                        Name = $"LblBluWins{blu + 1}{red + 1}{sge + 1}{cpt + 1}",
                                        Text = $"{cp.BluWins}",
                                        AutoSize = true,
                                        ForeColor = Color.Blue,
                                    };

                                    if (sge is 0 && cpt is 0)
                                    {
                                        lblBluWins.Font = ToggleBold(lblBluWins.Font);
                                    }

                                    Label lblRedWins = new()
                                    {
                                        Name = $"LblRedWins{blu}{red}{sge}{cpt}",
                                        Text = $"{cp.RedWins}",
                                        AutoSize = true,
                                        ForeColor = Color.Red,
                                    };

                                    lblBluWins.MouseClick += (s, e) =>
                                    {
                                        Label lbl = (Label)s;

                                        if (e.Button == MouseButtons.Right)
                                        {
                                            MessageBox.Show($"{lbl.Name}");
                                        }
                                    };

                                    lblRedWins.MouseClick += (s, e) =>
                                    {
                                        Label lbl = (Label)s;

                                        if (e.Button == MouseButtons.Right)
                                        {
                                            MessageBox.Show($"{lbl.Name}");
                                        }
                                    };

                                    stats.Add(lblBluWins);
                                    stats.Add(lblRedWins);
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
                            lastX += space + (i % 4 == 0 ? 4 : 0);
                        }

                        stats[i].Location = new(lastX, stats[0].Size.Height * (i / 108) + (i / 108 > 0 ? 2 : 0));
                        FrmStats.Controls.Add(stats[i]);

                        base.Text = i.ToString();
                    }

                    FrmStats.Show();
                    FrmStats.ClientSize = new(FrmStats.Controls["LblRedWins8821"].Location.X + FrmStats.Controls["LblRedWins8821"].Size.Width, FrmStats.Controls["LblRedWins8821"].Location.Y + FrmStats.Controls["LblRedWins8821"].Size.Height);
                    base.Text = "Class Wars Dustbowl Wins Tracker";
                }
            };

            LblRed.MouseClick += (_, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    List<string> stuff = [];

                    for (int blu = 0; blu < 9; blu++)
                    {
                        for (int red = 0; red < 9; red++)
                        {
                            for (int sge = 0; sge < 3; sge++)
                            {
                                base.Text = $"{blu + 1}{red + 1}{sge + 1}";

                                if (Stats.Blu[blu].Red[red].Stage[sge].ControlPoint[0].BluWins + Stats.Blu[blu].Red[red].Stage[sge].ControlPoint[0].RedWins == 0)
                                {
                                    stuff.Add($"BLU {CbxBlu.Items[blu]} vs RED {CbxRed.Items[red]}, Stage {sge + 1}");
                                }
                            }
                        }
                    }

                    if (stuff.Count != 0)
                    {
                        MessageBox.Show(string.Join(Environment.NewLine, stuff));
                    }
                }
            };

            Task.Run(() =>
            {
                bool gameIsOpen = false;
                while (!Disposing)
                {
                    if (GameProcess != null && !gameIsOpen || GameProcess == null && gameIsOpen)
                    {
                        gameIsOpen = !gameIsOpen;

                        Invoke(() =>
                        {
                            if (!gameIsOpen)
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

                    }

                    if (gameIsOpen && !IsKeyLocked(Keys.NumLock) && GameIsForeground)
                    {
                        Utils.SetNumLockOn();
                    }

                    Task.Delay(1000).Wait();
                }
            });
        }

        public StageControlPoint Tracker => Stats.Blu[CbxBlu.SelectedIndex].Red[CbxRed.SelectedIndex].Stage[CbxStage.SelectedIndex].ControlPoint[CbxCtrlPt.SelectedIndex];

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbxBlu.SelectedIndex < 0 || CbxRed.SelectedIndex < 0 || CbxStage.SelectedIndex < 0 || CbxCtrlPt.SelectedIndex < 0)
            {
                BtnBluWins.Enabled = false;
                BtnBluSubtract.Enabled = false;
                BtnRedWins.Enabled = false;
                BtnRedSubtract.Enabled = false;

                LblBluWinsCpt1.Text = $"0";
                LblBluWinsCpt2.Text = $"0";

                LblRedWinsCpt1.Text = $"0";
                LblRedWinsCpt2.Text = $"0";

                if (LblRedWinsCpt1.Font.Bold)
                {
                    LblBluWinsCpt1.Font = ToggleBold(LblBluWinsCpt1.Font);
                    LblRedWinsCpt1.Font = ToggleBold(LblRedWinsCpt1.Font);
                }

                if (LblRedWinsCpt2.Font.Bold)
                {
                    LblBluWinsCpt2.Font = ToggleBold(LblBluWinsCpt2.Font);
                    LblRedWinsCpt2.Font = ToggleBold(LblRedWinsCpt2.Font);
                }
            }
            else
            {
                if (GameIsOpen)
                {
                    BtnBluWins.Enabled = true;
                    BtnBluSubtract.Enabled = true;
                    BtnRedWins.Enabled = true;
                    BtnRedSubtract.Enabled = true;
                }

                StageControlPoint cpt1 = Stats.Blu[CbxBlu.SelectedIndex].Red[CbxRed.SelectedIndex].Stage[CbxStage.SelectedIndex].ControlPoint[0];
                StageControlPoint cpt2 = Stats.Blu[CbxBlu.SelectedIndex].Red[CbxRed.SelectedIndex].Stage[CbxStage.SelectedIndex].ControlPoint[1];

                LblBluWinsCpt1.Text = $"{cpt1.BluWins}";
                LblBluWinsCpt2.Text = $"{cpt2.BluWins}";

                LblRedWinsCpt1.Text = $"{cpt1.RedWins}";
                LblRedWinsCpt2.Text = $"{cpt2.RedWins}";

                if (CbxCtrlPt.SelectedIndex == 0 && !LblBluWinsCpt1.Font.Bold)
                {
                    LblBluWinsCpt1.Font = ToggleBold(LblBluWinsCpt1.Font);
                    LblRedWinsCpt1.Font = ToggleBold(LblRedWinsCpt1.Font);

                    if (LblRedWinsCpt2.Font.Bold)
                    {
                        LblBluWinsCpt2.Font = ToggleBold(LblBluWinsCpt2.Font);
                        LblRedWinsCpt2.Font = ToggleBold(LblRedWinsCpt2.Font);
                    }
                }
                else if (CbxCtrlPt.SelectedIndex == 1 && !LblBluWinsCpt2.Font.Bold)
                {
                    LblBluWinsCpt2.Font = ToggleBold(LblBluWinsCpt2.Font);
                    LblRedWinsCpt2.Font = ToggleBold(LblRedWinsCpt2.Font);

                    if (LblRedWinsCpt1.Font.Bold)
                    {
                        LblBluWinsCpt1.Font = ToggleBold(LblBluWinsCpt1.Font);
                        LblRedWinsCpt1.Font = ToggleBold(LblRedWinsCpt1.Font);
                    }
                }
            }
        }

        private void BtnBluWins_Click(object sender, EventArgs e)
        {
            if (CbxCtrlPt.SelectedIndex == 0)
            {
                StageControlPoint cp2 = Stats.Blu[CbxBlu.SelectedIndex].Red[CbxRed.SelectedIndex].Stage[CbxStage.SelectedIndex].ControlPoint[1];
                if (cp2.BluWins + cp2.RedWins == Tracker.BluWins)
                {
                    ++Tracker.BluWins;
                }
            }
            else
            {
                ++Tracker.BluWins;
            }

            Controls[$"LblBluWinsCpt{CbxCtrlPt.SelectedIndex + 1}"].Text = $"{Tracker.BluWins}";
            SaveData();

            LblLastWin.Text = $"BLU {CbxBlu.Text} won against{Environment.NewLine}RED {CbxRed.Text} on {CbxStage.Text}, {CbxCtrlPt.Text}";

            Task.Run(() =>
            {
                Invoke(() =>
                {
                    if (CbxCtrlPt.SelectedIndex == 1)
                    {
                        CbxStage.Enabled = false;
                        CbxCtrlPt.Enabled = false;
                        CbxBlu.Enabled = false;
                        CbxRed.Enabled = false;

                        BtnBluWins.Enabled = false;
                        BtnRedWins.Enabled = false;
                        BtnBluSubtract.Enabled = false;
                        BtnRedSubtract.Enabled = false;

                        Controls[$"LblBluWinsCpt{CbxCtrlPt.SelectedIndex + 1}"].ForeColor = Color.LightGreen;
                        Controls[$"LblBluWinsCpt{CbxCtrlPt.SelectedIndex + 1}"].BackColor = Color.Green;

                        Refresh();

                        Task.Delay(4000).Wait();

                        Controls[$"LblBluWinsCpt{CbxCtrlPt.SelectedIndex + 1}"].ForeColor = Color.Black;
                        Controls[$"LblBluWinsCpt{CbxCtrlPt.SelectedIndex + 1}"].BackColor = DefaultBackColor;

                        CbxBlu.SelectedIndex = -1;
                        CbxRed.SelectedIndex = -1;

                        CbxCtrlPt.SelectedIndex = 0;

                        if (CbxStage.SelectedIndex == 2)
                        {
                            CbxStage.SelectedIndex = 0;
                        }
                        else
                        {
                            ++CbxStage.SelectedIndex;
                        }
                    }
                    else
                    {
                        CbxCtrlPt.SelectedIndex = 1;
                    }

                    CbxStage.Enabled = true;
                    CbxCtrlPt.Enabled = true;
                    CbxBlu.Enabled = true;
                    CbxRed.Enabled = true;

                    Refresh();
                });
            });
        }

        private void BtnRedWins_Click(object sender, EventArgs e)
        {
            Controls[$"LblRedWinsCpt{CbxCtrlPt.SelectedIndex + 1}"].Text = $"{++Tracker.RedWins}";
            SaveData();

            LblLastWin.Text = $"RED {CbxRed.Text} won against{Environment.NewLine}BLU {CbxBlu.Text} on {CbxStage.Text}, {CbxCtrlPt.Text}";

            CbxStage.Enabled = false;
            CbxCtrlPt.Enabled = false;
            CbxBlu.Enabled = false;
            CbxRed.Enabled = false;

            BtnBluWins.Enabled = false;
            BtnRedWins.Enabled = false;
            BtnBluSubtract.Enabled = false;
            BtnRedSubtract.Enabled = false;

            Task.Run(() =>
            {
                Invoke(() =>
                {
                    Controls[$"LblRedWinsCpt{CbxCtrlPt.SelectedIndex + 1}"].ForeColor = Color.LightGreen;
                    Controls[$"LblRedWinsCpt{CbxCtrlPt.SelectedIndex + 1}"].BackColor = Color.Green;

                    Task.Delay(4000).Wait();

                    Controls[$"LblRedWinsCpt{CbxCtrlPt.SelectedIndex + 1}"].ForeColor = Color.Black;
                    Controls[$"LblRedWinsCpt{CbxCtrlPt.SelectedIndex + 1}"].BackColor = DefaultBackColor;

                    CbxStage.SelectedIndex = 0;
                    CbxCtrlPt.SelectedIndex = 0;
                    CbxBlu.SelectedIndex = -1;
                    CbxRed.SelectedIndex = -1;

                    CbxStage.Enabled = true;
                    CbxCtrlPt.Enabled = true;
                    CbxBlu.Enabled = true;
                    CbxRed.Enabled = true;
                });
            });
        }

        private void BtnBluSubtract_Click(object sender, EventArgs e)
        {
            if (Tracker.BluWins > 0)
            {
                Controls[$"LblBluWinsCpt{CbxCtrlPt.SelectedIndex + 1}"].Text = $"{--Tracker.BluWins}";
                SaveData();
            }
        }

        private void BtnRedSubtract_Click(object sender, EventArgs e)
        {
            if (Tracker.RedWins > 0)
            {
                Controls[$"LblRedWinsCpt{CbxCtrlPt.SelectedIndex + 1}"].Text = $"{--Tracker.RedWins}";
                SaveData();
            }
        }

        public static Font ToggleBold(Font font)
        {
            if (font != null)
            {
                FontStyle fontStyle = font.Style;
                if ((fontStyle & FontStyle.Bold) == 0)
                {
                    fontStyle |= FontStyle.Bold;
                    font = new Font(font, fontStyle);
                }
                else
                {
                    fontStyle ^= FontStyle.Bold;
                    font = new Font(font, fontStyle);
                }
            }
            return font;
        }

        [LibraryImport("user32.dll")]
        private static partial IntPtr GetForegroundWindow();

        [LibraryImport("user32.dll", SetLastError = true)]
        private static partial uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        public static Process GetForegroundProcess()
        {
            IntPtr hWnd = GetForegroundWindow(); // Get foreground window handle
            _ = GetWindowThreadProcessId(hWnd, out uint processID); // Get PID from window handle
            Process fgProc = Process.GetProcessById(Convert.ToInt32(processID)); // Get it as a C# obj.
            // NOTE: In some rare cases ProcessID will be NULL. Handle this how you want. 
            return fgProc;
        }

        private void FrmMain_LocationChanged(object sender, EventArgs e)
        {

        }
    }
}