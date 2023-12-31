﻿namespace Class_Wars_Win_Tracker
{
    partial class FrmMain
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
            LblBluWins_Static = new Label();
            LblRedWins_Static = new Label();
            BtnBluWins = new Button();
            BtnRedWins = new Button();
            BtnBluSubtract = new Button();
            BtnRedSubtract = new Button();
            LblLastWin = new Label();
            LblDivider1 = new Label();
            LblDivider2 = new Label();
            LblBluWinsCpt1 = new Label();
            LblBluWinsCpt2 = new Label();
            LblRedWinsCpt2 = new Label();
            LblRedWinsCpt1 = new Label();
            LblDivider3 = new Label();
            LblDivider4 = new Label();
            LblDivider5 = new Label();
            SuspendLayout();
            // 
            // LblBlu
            // 
            LblBlu.Font = new Font("Segoe UI", 24F);
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
            LblRed.Font = new Font("Segoe UI", 24F);
            LblRed.ForeColor = Color.Red;
            LblRed.Location = new Point(140, 43);
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
            CbxRed.Location = new Point(140, 86);
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
            CbxCtrlPt.Location = new Point(140, 12);
            CbxCtrlPt.Name = "CbxCtrlPt";
            CbxCtrlPt.Size = new Size(82, 23);
            CbxCtrlPt.TabIndex = 5;
            // 
            // LblBluWins_Static
            // 
            LblBluWins_Static.AutoSize = true;
            LblBluWins_Static.Location = new Point(12, 119);
            LblBluWins_Static.Name = "LblBluWins_Static";
            LblBluWins_Static.Size = new Size(60, 15);
            LblBluWins_Static.TabIndex = 6;
            LblBluWins_Static.Text = "BLU Wins:";
            // 
            // LblRedWins_Static
            // 
            LblRedWins_Static.AutoSize = true;
            LblRedWins_Static.Location = new Point(12, 148);
            LblRedWins_Static.Name = "LblRedWins_Static";
            LblRedWins_Static.Size = new Size(60, 15);
            LblRedWins_Static.TabIndex = 7;
            LblRedWins_Static.Text = "RED Wins:";
            // 
            // BtnBluWins
            // 
            BtnBluWins.Location = new Point(147, 115);
            BtnBluWins.Name = "BtnBluWins";
            BtnBluWins.Size = new Size(75, 23);
            BtnBluWins.TabIndex = 8;
            BtnBluWins.Text = "BLU Wins";
            BtnBluWins.UseVisualStyleBackColor = true;
            BtnBluWins.Click += BtnBluWins_Click;
            // 
            // BtnRedWins
            // 
            BtnRedWins.Location = new Point(147, 144);
            BtnRedWins.Name = "BtnRedWins";
            BtnRedWins.Size = new Size(75, 23);
            BtnRedWins.TabIndex = 9;
            BtnRedWins.Text = "RED Wins";
            BtnRedWins.UseVisualStyleBackColor = true;
            BtnRedWins.Click += BtnRedWins_Click;
            // 
            // BtnBluSubtract
            // 
            BtnBluSubtract.Location = new Point(122, 115);
            BtnBluSubtract.Name = "BtnBluSubtract";
            BtnBluSubtract.Size = new Size(19, 23);
            BtnBluSubtract.TabIndex = 10;
            BtnBluSubtract.Text = "-";
            BtnBluSubtract.UseVisualStyleBackColor = true;
            BtnBluSubtract.Click += BtnBluSubtract_Click;
            // 
            // BtnRedSubtract
            // 
            BtnRedSubtract.Location = new Point(122, 144);
            BtnRedSubtract.Name = "BtnRedSubtract";
            BtnRedSubtract.Size = new Size(19, 23);
            BtnRedSubtract.TabIndex = 11;
            BtnRedSubtract.Text = "-";
            BtnRedSubtract.UseVisualStyleBackColor = true;
            BtnRedSubtract.Click += BtnRedSubtract_Click;
            // 
            // LblLastWin
            // 
            LblLastWin.Location = new Point(12, 187);
            LblLastWin.MaximumSize = new Size(213, 40);
            LblLastWin.Name = "LblLastWin";
            LblLastWin.Size = new Size(210, 40);
            LblLastWin.TabIndex = 12;
            LblLastWin.Text = "Line 1";
            // 
            // LblDivider1
            // 
            LblDivider1.BorderStyle = BorderStyle.Fixed3D;
            LblDivider1.Location = new Point(2, 175);
            LblDivider1.Name = "LblDivider1";
            LblDivider1.Size = new Size(231, 2);
            LblDivider1.TabIndex = 14;
            // 
            // LblDivider2
            // 
            LblDivider2.BorderStyle = BorderStyle.Fixed3D;
            LblDivider2.Location = new Point(2, 43);
            LblDivider2.Name = "LblDivider2";
            LblDivider2.Size = new Size(231, 2);
            LblDivider2.TabIndex = 16;
            // 
            // LblBluWinsCpt1
            // 
            LblBluWinsCpt1.AutoSize = true;
            LblBluWinsCpt1.Location = new Point(73, 119);
            LblBluWinsCpt1.Name = "LblBluWinsCpt1";
            LblBluWinsCpt1.Size = new Size(21, 15);
            LblBluWinsCpt1.TabIndex = 17;
            LblBluWinsCpt1.Text = "XY";
            // 
            // LblBluWinsCpt2
            // 
            LblBluWinsCpt2.AutoSize = true;
            LblBluWinsCpt2.Location = new Point(96, 119);
            LblBluWinsCpt2.Name = "LblBluWinsCpt2";
            LblBluWinsCpt2.Size = new Size(21, 15);
            LblBluWinsCpt2.TabIndex = 18;
            LblBluWinsCpt2.Text = "YZ";
            // 
            // LblRedWinsCpt2
            // 
            LblRedWinsCpt2.AutoSize = true;
            LblRedWinsCpt2.Location = new Point(96, 148);
            LblRedWinsCpt2.Name = "LblRedWinsCpt2";
            LblRedWinsCpt2.Size = new Size(21, 15);
            LblRedWinsCpt2.TabIndex = 20;
            LblRedWinsCpt2.Text = "YZ";
            // 
            // LblRedWinsCpt1
            // 
            LblRedWinsCpt1.AutoSize = true;
            LblRedWinsCpt1.Location = new Point(73, 148);
            LblRedWinsCpt1.Name = "LblRedWinsCpt1";
            LblRedWinsCpt1.Size = new Size(21, 15);
            LblRedWinsCpt1.TabIndex = 19;
            LblRedWinsCpt1.Text = "XY";
            // 
            // LblDivider3
            // 
            LblDivider3.BorderStyle = BorderStyle.Fixed3D;
            LblDivider3.Location = new Point(72, 115);
            LblDivider3.Name = "LblDivider3";
            LblDivider3.Size = new Size(2, 50);
            LblDivider3.TabIndex = 21;
            // 
            // LblDivider4
            // 
            LblDivider4.BorderStyle = BorderStyle.Fixed3D;
            LblDivider4.Location = new Point(94, 118);
            LblDivider4.Name = "LblDivider4";
            LblDivider4.Size = new Size(2, 50);
            LblDivider4.TabIndex = 22;
            // 
            // LblDivider5
            // 
            LblDivider5.BorderStyle = BorderStyle.Fixed3D;
            LblDivider5.Location = new Point(12, 141);
            LblDivider5.Name = "LblDivider5";
            LblDivider5.Size = new Size(105, 2);
            LblDivider5.TabIndex = 23;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(234, 226);
            Controls.Add(LblDivider5);
            Controls.Add(LblDivider4);
            Controls.Add(LblDivider3);
            Controls.Add(LblRedWinsCpt2);
            Controls.Add(LblRedWinsCpt1);
            Controls.Add(LblBluWinsCpt2);
            Controls.Add(LblBluWinsCpt1);
            Controls.Add(LblDivider2);
            Controls.Add(LblDivider1);
            Controls.Add(LblLastWin);
            Controls.Add(BtnRedSubtract);
            Controls.Add(BtnBluSubtract);
            Controls.Add(BtnRedWins);
            Controls.Add(BtnBluWins);
            Controls.Add(LblRedWins_Static);
            Controls.Add(LblBluWins_Static);
            Controls.Add(CbxCtrlPt);
            Controls.Add(CbxStage);
            Controls.Add(CbxRed);
            Controls.Add(CbxBlu);
            Controls.Add(LblRed);
            Controls.Add(LblBlu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmMain";
            ShowIcon = false;
            Text = "Class Wars Dustbowl Wins Tracker";
            LocationChanged += FrmMain_LocationChanged;
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
        private Label LblBluWins_Static;
        private Label LblRedWins_Static;
        private Button BtnBluWins;
        private Button BtnRedWins;
        private Button BtnBluSubtract;
        private Button BtnRedSubtract;
        private Label LblLastWin;
        private Label LblDivider1;
        private Label LblDivider2;
        private Label LblBluWinsCpt1;
        private Label LblBluWinsCpt2;
        private Label LblRedWinsCpt2;
        private Label LblRedWinsCpt1;
        private Label LblDivider3;
        private Label LblDivider4;
        private Label LblDivider5;
    }
}