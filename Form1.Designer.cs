namespace Connect4GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.blackRadBtn = new System.Windows.Forms.RadioButton();
            this.redRadBtn = new System.Windows.Forms.RadioButton();
            this.grpPlayer = new System.Windows.Forms.GroupBox();
            this.lblRowPrompt = new System.Windows.Forms.Label();
            this.lblColPrompt = new System.Windows.Forms.Label();
            this.numRow = new System.Windows.Forms.NumericUpDown();
            this.numCol = new System.Windows.Forms.NumericUpDown();
            this.submitBtn = new System.Windows.Forms.Button();
            this.displayLbl = new System.Windows.Forms.Label();
            this.strtNew = new System.Windows.Forms.Button();
            this.svrstrGame = new System.Windows.Forms.Button();
            this.fileLocTxtB = new System.Windows.Forms.TextBox();
            this.fileLocLbl = new System.Windows.Forms.Label();
            this.flNotFndLbl = new System.Windows.Forms.Label();
            this.errorLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCol)).BeginInit();
            this.SuspendLayout();
            // 
            // blackRadBtn
            // 
            this.blackRadBtn.AutoSize = true;
            this.blackRadBtn.Enabled = false;
            this.blackRadBtn.Location = new System.Drawing.Point(45, 29);
            this.blackRadBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.blackRadBtn.Name = "blackRadBtn";
            this.blackRadBtn.Size = new System.Drawing.Size(73, 24);
            this.blackRadBtn.TabIndex = 0;
            this.blackRadBtn.Text = "Black";
            this.blackRadBtn.UseVisualStyleBackColor = true;
            this.blackRadBtn.CheckedChanged += new System.EventHandler(this.blackRadBtn_CheckedChanged);
            // 
            // redRadBtn
            // 
            this.redRadBtn.AutoSize = true;
            this.redRadBtn.Enabled = false;
            this.redRadBtn.Location = new System.Drawing.Point(212, 29);
            this.redRadBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.redRadBtn.Name = "redRadBtn";
            this.redRadBtn.Size = new System.Drawing.Size(64, 24);
            this.redRadBtn.TabIndex = 1;
            this.redRadBtn.Text = "Red";
            this.redRadBtn.UseVisualStyleBackColor = true;
            this.redRadBtn.CheckedChanged += new System.EventHandler(this.redRadBtn_CheckedChanged);
            // 
            // grpPlayer
            // 
            this.grpPlayer.Controls.Add(this.redRadBtn);
            this.grpPlayer.Controls.Add(this.blackRadBtn);
            this.grpPlayer.Location = new System.Drawing.Point(45, 18);
            this.grpPlayer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpPlayer.Name = "grpPlayer";
            this.grpPlayer.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpPlayer.Size = new System.Drawing.Size(330, 83);
            this.grpPlayer.TabIndex = 2;
            this.grpPlayer.TabStop = false;
            this.grpPlayer.Text = "Active Player:";
            // 
            // lblRowPrompt
            // 
            this.lblRowPrompt.AutoSize = true;
            this.lblRowPrompt.Location = new System.Drawing.Point(42, 106);
            this.lblRowPrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRowPrompt.Name = "lblRowPrompt";
            this.lblRowPrompt.Size = new System.Drawing.Size(41, 20);
            this.lblRowPrompt.TabIndex = 3;
            this.lblRowPrompt.Text = "Row";
            // 
            // lblColPrompt
            // 
            this.lblColPrompt.AutoSize = true;
            this.lblColPrompt.Location = new System.Drawing.Point(258, 106);
            this.lblColPrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColPrompt.Name = "lblColPrompt";
            this.lblColPrompt.Size = new System.Drawing.Size(63, 20);
            this.lblColPrompt.TabIndex = 4;
            this.lblColPrompt.Text = "Column";
            // 
            // numRow
            // 
            this.numRow.Location = new System.Drawing.Point(46, 131);
            this.numRow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numRow.Name = "numRow";
            this.numRow.Size = new System.Drawing.Size(122, 26);
            this.numRow.TabIndex = 5;
            this.numRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numRow.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numCol
            // 
            this.numCol.Location = new System.Drawing.Point(199, 131);
            this.numCol.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numCol.Name = "numCol";
            this.numCol.Size = new System.Drawing.Size(122, 26);
            this.numCol.TabIndex = 6;
            this.numCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numCol.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // submitBtn
            // 
            this.submitBtn.Enabled = false;
            this.submitBtn.Location = new System.Drawing.Point(121, 167);
            this.submitBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(112, 65);
            this.submitBtn.TabIndex = 7;
            this.submitBtn.Text = "Submit Choice";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // displayLbl
            // 
            this.displayLbl.Location = new System.Drawing.Point(14, 366);
            this.displayLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.displayLbl.Name = "displayLbl";
            this.displayLbl.Size = new System.Drawing.Size(494, 248);
            this.displayLbl.TabIndex = 8;
            this.displayLbl.Text = "[Board State Here]";
            this.displayLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // strtNew
            // 
            this.strtNew.Location = new System.Drawing.Point(382, 18);
            this.strtNew.Name = "strtNew";
            this.strtNew.Size = new System.Drawing.Size(126, 36);
            this.strtNew.TabIndex = 9;
            this.strtNew.Text = "Start New";
            this.strtNew.UseVisualStyleBackColor = true;
            this.strtNew.Click += new System.EventHandler(this.strtNewBtn_Click);
            // 
            // svrstrGame
            // 
            this.svrstrGame.Location = new System.Drawing.Point(382, 65);
            this.svrstrGame.Name = "svrstrGame";
            this.svrstrGame.Size = new System.Drawing.Size(125, 36);
            this.svrstrGame.TabIndex = 10;
            this.svrstrGame.Text = "Save/Restore";
            this.svrstrGame.UseVisualStyleBackColor = true;
            this.svrstrGame.Click += new System.EventHandler(this.svrstrGameBtn_Click);
            // 
            // fileLocTxtB
            // 
            this.fileLocTxtB.Location = new System.Drawing.Point(279, 240);
            this.fileLocTxtB.Name = "fileLocTxtB";
            this.fileLocTxtB.Size = new System.Drawing.Size(228, 26);
            this.fileLocTxtB.TabIndex = 11;
            this.fileLocTxtB.Text = "board.txt";
            // 
            // fileLocLbl
            // 
            this.fileLocLbl.Location = new System.Drawing.Point(275, 211);
            this.fileLocLbl.Name = "fileLocLbl";
            this.fileLocLbl.Size = new System.Drawing.Size(232, 26);
            this.fileLocLbl.TabIndex = 12;
            this.fileLocLbl.Text = "File Location";
            // 
            // flNotFndLbl
            // 
            this.flNotFndLbl.Location = new System.Drawing.Point(383, 269);
            this.flNotFndLbl.Name = "flNotFndLbl";
            this.flNotFndLbl.Size = new System.Drawing.Size(125, 84);
            this.flNotFndLbl.TabIndex = 13;
            this.flNotFndLbl.Visible = false;
            // 
            // errorLbl
            // 
            this.errorLbl.Enabled = false;
            this.errorLbl.Location = new System.Drawing.Point(18, 269);
            this.errorLbl.Name = "errorLbl";
            this.errorLbl.Size = new System.Drawing.Size(215, 84);
            this.errorLbl.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(18, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 23);
            this.label1.TabIndex = 15;
            this.label1.Text = "Message Field";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 623);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.errorLbl);
            this.Controls.Add(this.flNotFndLbl);
            this.Controls.Add(this.fileLocLbl);
            this.Controls.Add(this.fileLocTxtB);
            this.Controls.Add(this.svrstrGame);
            this.Controls.Add(this.strtNew);
            this.Controls.Add(this.displayLbl);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.numCol);
            this.Controls.Add(this.numRow);
            this.Controls.Add(this.lblColPrompt);
            this.Controls.Add(this.lblRowPrompt);
            this.Controls.Add(this.grpPlayer);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Connect 4: Freestyle";
            this.grpPlayer.ResumeLayout(false);
            this.grpPlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton blackRadBtn;
        private System.Windows.Forms.RadioButton redRadBtn;
        private System.Windows.Forms.GroupBox grpPlayer;
        private System.Windows.Forms.Label lblRowPrompt;
        private System.Windows.Forms.Label lblColPrompt;
        private System.Windows.Forms.NumericUpDown numRow;
        private System.Windows.Forms.NumericUpDown numCol;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Label displayLbl;
        private System.Windows.Forms.Button strtNew;
        private System.Windows.Forms.Button svrstrGame;
        private System.Windows.Forms.TextBox fileLocTxtB;
        private System.Windows.Forms.Label fileLocLbl;
        private System.Windows.Forms.Label flNotFndLbl;
        private System.Windows.Forms.Label errorLbl;
        private System.Windows.Forms.Label label1;
    }
}

