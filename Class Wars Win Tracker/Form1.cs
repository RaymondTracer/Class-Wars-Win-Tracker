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
    }
}