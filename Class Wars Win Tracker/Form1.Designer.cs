namespace Class_Wars_Win_Tracker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LblBlu = new Label();
            LblRed = new Label();
            CbxBlu = new ComboBox();
            CbxRed = new ComboBox();
            CbxStage = new ComboBox();
            CbxCtrlPt = new ComboBox();
            LblBluWins = new Label();
            LblRedWins = new Label();
            BtnBluWins = new Button();
            BtnRedWins = new Button();
            BtnBluSubtract = new Button();
            BtnRedSubtract = new Button();
            LblLastWin1 = new Label();
            LblDivider1 = new Label();
            LblLastWin2 = new Label();
            LblDivider2 = new Label();
            SuspendLayout();
            // 
            // LblBlu
            // 
            LblBlu.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            LblBlu.ForeColor = Color.Blue;
            LblBlu.Location = new Point(12, 43);
            LblBlu.Name = "LblBlu";
            LblBlu.Size = new Size(82, 40);
            LblBlu.TabIndex = 0;
            LblBlu.Text = "BLU";
            LblBlu.TextAlign = ContentAlignment.TopCenter;
            // 
            // LblRed
            // 
            LblRed.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            LblRed.ForeColor = Color.Red;
            LblRed.Location = new Point(120, 45);
            LblRed.Name = "LblRed";
            LblRed.Size = new Size(82, 38);
            LblRed.TabIndex = 1;
            LblRed.Text = "RED";
            LblRed.TextAlign = ContentAlignment.TopCenter;
            // 
            // CbxBlu
            // 
            CbxBlu.DropDownStyle = ComboBoxStyle.DropDownList;
            CbxBlu.FormattingEnabled = true;
            CbxBlu.Items.AddRange(new object[] { "Scout", "Soldier", "Pyro", "Demoman", "Heavy", "Engineer", "Medic", "Sniper", "Spy" });
            CbxBlu.Location = new Point(12, 86);
            CbxBlu.Name = "CbxBlu";
            CbxBlu.Size = new Size(82, 23);
            CbxBlu.TabIndex = 2;
            // 
            // CbxRed
            // 
            CbxRed.DropDownStyle = ComboBoxStyle.DropDownList;
            CbxRed.FormattingEnabled = true;
            CbxRed.Items.AddRange(new object[] { "Scout", "Soldier", "Pyro", "Demoman", "Heavy", "Engineer", "Medic", "Sniper", "Spy" });
            CbxRed.Location = new Point(120, 86);
            CbxRed.Name = "CbxRed";
            CbxRed.Size = new Size(82, 23);
            CbxRed.TabIndex = 3;
            // 
            // CbxStage
            // 
            CbxStage.DropDownStyle = ComboBoxStyle.DropDownList;
            CbxStage.FormattingEnabled = true;
            CbxStage.Items.AddRange(new object[] { "Stage 1", "Stage 2", "Stage 3" });
            CbxStage.Location = new Point(12, 12);
            CbxStage.Name = "CbxStage";
            CbxStage.Size = new Size(82, 23);
            CbxStage.TabIndex = 4;
            // 
            // CbxCtrlPt
            // 
            CbxCtrlPt.DropDownStyle = ComboBoxStyle.DropDownList;
            CbxCtrlPt.FormattingEnabled = true;
            CbxCtrlPt.Items.AddRange(new object[] { "Ctrl. Pt. 1", "Ctrl. Pt. 2" });
            CbxCtrlPt.Location = new Point(120, 12);
            CbxCtrlPt.Name = "CbxCtrlPt";
            CbxCtrlPt.Size = new Size(82, 23);
            CbxCtrlPt.TabIndex = 5;
            // 
            // LblBluWins
            // 
            LblBluWins.AutoSize = true;
            LblBluWins.Location = new Point(12, 119);
            LblBluWins.Name = "LblBluWins";
            LblBluWins.Size = new Size(84, 15);
            LblBluWins.TabIndex = 6;
            LblBluWins.Text = "BLU Wins: XYZ";
            // 
            // LblRedWins
            // 
            LblRedWins.AutoSize = true;
            LblRedWins.Location = new Point(12, 148);
            LblRedWins.Name = "LblRedWins";
            LblRedWins.Size = new Size(84, 15);
            LblRedWins.TabIndex = 7;
            LblRedWins.Text = "RED Wins: XYZ";
            // 
            // BtnBluWins
            // 
            BtnBluWins.Location = new Point(127, 115);
            BtnBluWins.Name = "BtnBluWins";
            BtnBluWins.Size = new Size(75, 23);
            BtnBluWins.TabIndex = 8;
            BtnBluWins.Text = "BLU Wins";
            BtnBluWins.UseVisualStyleBackColor = true;
            BtnBluWins.Click += BtnBluWins_Click;
            // 
            // BtnRedWins
            // 
            BtnRedWins.Location = new Point(127, 144);
            BtnRedWins.Name = "BtnRedWins";
            BtnRedWins.Size = new Size(75, 23);
            BtnRedWins.TabIndex = 9;
            BtnRedWins.Text = "RED Wins";
            BtnRedWins.UseVisualStyleBackColor = true;
            BtnRedWins.Click += BtnRedWins_Click;
            // 
            // BtnBluSubtract
            // 
            BtnBluSubtract.Location = new Point(102, 115);
            BtnBluSubtract.Name = "BtnBluSubtract";
            BtnBluSubtract.Size = new Size(19, 23);
            BtnBluSubtract.TabIndex = 10;
            BtnBluSubtract.Text = "-";
            BtnBluSubtract.UseVisualStyleBackColor = true;
            BtnBluSubtract.Click += BtnBluSubtract_Click;
            // 
            // BtnRedSubtract
            // 
            BtnRedSubtract.Location = new Point(102, 144);
            BtnRedSubtract.Name = "BtnRedSubtract";
            BtnRedSubtract.Size = new Size(19, 23);
            BtnRedSubtract.TabIndex = 11;
            BtnRedSubtract.Text = "-";
            BtnRedSubtract.UseVisualStyleBackColor = true;
            BtnRedSubtract.Click += BtnRedSubtract_Click;
            // 
            // LblLastWin1
            // 
            LblLastWin1.AutoSize = true;
            LblLastWin1.Location = new Point(12, 187);
            LblLastWin1.Name = "LblLastWin1";
            LblLastWin1.Size = new Size(38, 15);
            LblLastWin1.TabIndex = 12;
            LblLastWin1.Text = "Line 1";
            // 
            // LblDivider1
            // 
            LblDivider1.BorderStyle = BorderStyle.Fixed3D;
            LblDivider1.Location = new Point(2, 175);
            LblDivider1.Name = "LblDivider1";
            LblDivider1.Size = new Size(213, 2);
            LblDivider1.TabIndex = 14;
            // 
            // LblLastWin2
            // 
            LblLastWin2.AutoSize = true;
            LblLastWin2.Location = new Point(12, 202);
            LblLastWin2.Name = "LblLastWin2";
            LblLastWin2.Size = new Size(38, 15);
            LblLastWin2.TabIndex = 15;
            LblLastWin2.Text = "Line 2";
            // 
            // LblDivider2
            // 
            LblDivider2.BorderStyle = BorderStyle.Fixed3D;
            LblDivider2.Location = new Point(2, 43);
            LblDivider2.Name = "LblDivider2";
            LblDivider2.Size = new Size(213, 2);
            LblDivider2.TabIndex = 16;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(216, 225);
            Controls.Add(LblDivider2);
            Controls.Add(LblLastWin2);
            Controls.Add(LblDivider1);
            Controls.Add(LblLastWin1);
            Controls.Add(BtnRedSubtract);
            Controls.Add(BtnBluSubtract);
            Controls.Add(BtnRedWins);
            Controls.Add(BtnBluWins);
            Controls.Add(LblRedWins);
            Controls.Add(LblBluWins);
            Controls.Add(CbxCtrlPt);
            Controls.Add(CbxStage);
            Controls.Add(CbxRed);
            Controls.Add(CbxBlu);
            Controls.Add(LblRed);
            Controls.Add(LblBlu);
            Name = "Form1";
            Text = "Class Wars Dustbowl Wins Tracker";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblBlu;
        private Label LblRed;
        private ComboBox CbxBlu;
        private ComboBox CbxRed;
        private ComboBox CbxStage;
        private ComboBox CbxCtrlPt;
        private Label LblBluWins;
        private Label LblRedWins;
        private Button BtnBluWins;
        private Button BtnRedWins;
        private Button BtnBluSubtract;
        private Button BtnRedSubtract;
        private Label LblLastWin1;
        private Label LblDivider1;
        private Label LblLastWin2;
        private Label LblDivider2;
    }
}