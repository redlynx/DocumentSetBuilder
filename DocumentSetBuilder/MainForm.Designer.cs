namespace DocumentSetBuilder
{
    partial class MainForm
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
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtSeed = new System.Windows.Forms.TextBox();
            this.cmdGo = new System.Windows.Forms.Button();
            this.txtPercentageSplit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.pBDirs = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(12, 21);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(347, 20);
            this.txtSource.TabIndex = 1;
            // 
            // txtSeed
            // 
            this.txtSeed.Location = new System.Drawing.Point(12, 147);
            this.txtSeed.Name = "txtSeed";
            this.txtSeed.Size = new System.Drawing.Size(29, 20);
            this.txtSeed.TabIndex = 4;
            this.txtSeed.Text = "42";
            // 
            // cmdGo
            // 
            this.cmdGo.Location = new System.Drawing.Point(12, 175);
            this.cmdGo.Name = "cmdGo";
            this.cmdGo.Size = new System.Drawing.Size(352, 39);
            this.cmdGo.TabIndex = 5;
            this.cmdGo.Text = "Go";
            this.cmdGo.UseVisualStyleBackColor = true;
            this.cmdGo.Click += new System.EventHandler(this.cmdGo_Click);
            // 
            // txtPercentageSplit
            // 
            this.txtPercentageSplit.Location = new System.Drawing.Point(12, 107);
            this.txtPercentageSplit.Name = "txtPercentageSplit";
            this.txtPercentageSplit.Size = new System.Drawing.Size(29, 20);
            this.txtPercentageSplit.TabIndex = 3;
            this.txtPercentageSplit.Text = "0,8";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Source: the root import folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Percentage split";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Seed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(312, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "The percentage of documents to be put into the TRAINING SET";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Useful to reproduce splits";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(227, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Destination: the root for test/training set folders";
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(12, 65);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(347, 20);
            this.txtDestination.TabIndex = 2;
            // 
            // pBDirs
            // 
            this.pBDirs.Location = new System.Drawing.Point(12, 236);
            this.pBDirs.Name = "pBDirs";
            this.pBDirs.Size = new System.Drawing.Size(352, 23);
            this.pBDirs.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Progress";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 270);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pBDirs);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPercentageSplit);
            this.Controls.Add(this.cmdGo);
            this.Controls.Add(this.txtSeed);
            this.Controls.Add(this.txtSource);
            this.Name = "MainForm";
            this.Text = "Document Set Builder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtSeed;
        private System.Windows.Forms.Button cmdGo;
        private System.Windows.Forms.TextBox txtPercentageSplit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.ProgressBar pBDirs;
        private System.Windows.Forms.Label label7;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

