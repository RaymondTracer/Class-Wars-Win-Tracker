using System.Text.Json;

namespace Class_Wars_Win_Tracker
{
    public partial class Form1 : Form
    {
        private readonly ClassWarsWinTracker Stats;

        public Form1()
        {
            InitializeComponent();

            if (File.Exists("stats.json"))
            {
                Stats = JsonSerializer.Deserialize<ClassWarsWinTracker>(File.ReadAllText("stats.json"));
            }
            else
            {
                Stats = DefaultStats.Get;
            }

            CbxCtrlPt.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            CbxStage.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            CbxBlu.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            CbxRed.SelectedIndexChanged += ComboBox_SelectedIndexChanged;

            CbxCtrlPt.SelectedIndex = 0;
            CbxStage.SelectedIndex = 0;

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
                                        Text = $"{Stats[blu].VsRed[red].Stage[sge].ControlPoint[cpt].BluWins}",
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

                    for (int i = 0; i < stats.Count; i++)
                    {
                        stats[i].Location = new(stats[0].Size.Width * (i % 108) + (i % 4 == 0 ? 4 : 0), stats[0].Size.Height * (i / 108) + (i / 108 > 0 ? 2 : 0));
                        FrmStats.Controls.Add(stats[i]);
                    }

                    FrmStats.Show();
                    FrmStats.ClientSize = new(FrmStats.Controls["LblRedWins8821"].Location.X + FrmStats.Controls["LblRedWins8821"].Size.Width, FrmStats.Controls["LblRedWins8821"].Location.Y + FrmStats.Controls["LblRedWins8821"].Size.Height);
                }
            };
        }

        public StageControlPoint Tracker => Stats[CbxBlu.SelectedIndex].VsRed[CbxRed.SelectedIndex].Stage[CbxStage.SelectedIndex].ControlPoint[CbxCtrlPt.SelectedIndex];

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbxBlu.SelectedIndex < 0 || CbxRed.SelectedIndex < 0 || CbxStage.SelectedIndex < 0 || CbxCtrlPt.SelectedIndex < 0)
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
        }

        private void BtnRedWins_Click(object sender, EventArgs e)
        {
            LblRedWins.Text = $"RED Wins: {++Tracker.RedWins}";
            File.WriteAllText("stats.json", JsonSerializer.Serialize(Stats, options: new() { WriteIndented = true, IncludeFields = true }));

            CbxStage.SelectedIndex = 0;
            CbxCtrlPt.SelectedIndex = 0;
            CbxBlu.SelectedIndex = -1;
            CbxRed.SelectedIndex = -1;
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

        public Font BoldFont(Font font)
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
    }
}