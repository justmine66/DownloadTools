namespace DownloadTools
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbDownloadUri = new System.Windows.Forms.TextBox();
            this.btnDirectDownload = new System.Windows.Forms.Button();
            this.pbDownloadSpeed1 = new System.Windows.Forms.ProgressBar();
            this.btnBreakpointResume = new System.Windows.Forms.Button();
            this.lbSpreedMsg1 = new System.Windows.Forms.Label();
            this.btnSliceDownload = new System.Windows.Forms.Button();
            this.pbDownloadSpeed2 = new System.Windows.Forms.ProgressBar();
            this.pbDownloadSpeed3 = new System.Windows.Forms.ProgressBar();
            this.pbDownloadSpeed5 = new System.Windows.Forms.ProgressBar();
            this.pbDownloadSpeed4 = new System.Windows.Forms.ProgressBar();
            this.pbDownloadSpeed7 = new System.Windows.Forms.ProgressBar();
            this.pbDownloadSpeed6 = new System.Windows.Forms.ProgressBar();
            this.pbDownloadSpeed9 = new System.Windows.Forms.ProgressBar();
            this.pbDownloadSpeed8 = new System.Windows.Forms.ProgressBar();
            this.pbDownloadSpeed10 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbSpreedMsg2 = new System.Windows.Forms.Label();
            this.lbSpreedMsg3 = new System.Windows.Forms.Label();
            this.lbSpreedMsg4 = new System.Windows.Forms.Label();
            this.lbSpreedMsg5 = new System.Windows.Forms.Label();
            this.lbSpreedMsg6 = new System.Windows.Forms.Label();
            this.lbSpreedMsg7 = new System.Windows.Forms.Label();
            this.lbSpreedMsg8 = new System.Windows.Forms.Label();
            this.lbSpreedMsg9 = new System.Windows.Forms.Label();
            this.lbSpreedMsg10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "下载链接：";
            // 
            // tbDownloadUri
            // 
            this.tbDownloadUri.Location = new System.Drawing.Point(71, 15);
            this.tbDownloadUri.Name = "tbDownloadUri";
            this.tbDownloadUri.Size = new System.Drawing.Size(516, 20);
            this.tbDownloadUri.TabIndex = 1;
            this.tbDownloadUri.Text = "http://localhost/en_windows_10_enterprise_version_1607_updated_jul_2016_x64_dvd_9" +
    "054264.zip";
            // 
            // btnDirectDownload
            // 
            this.btnDirectDownload.Location = new System.Drawing.Point(71, 47);
            this.btnDirectDownload.Name = "btnDirectDownload";
            this.btnDirectDownload.Size = new System.Drawing.Size(106, 25);
            this.btnDirectDownload.TabIndex = 2;
            this.btnDirectDownload.Text = "直接下载";
            this.btnDirectDownload.UseVisualStyleBackColor = true;
            this.btnDirectDownload.Click += new System.EventHandler(this.btnDirectDownload_Click);
            // 
            // pbDownloadSpeed1
            // 
            this.pbDownloadSpeed1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDownloadSpeed1.Location = new System.Drawing.Point(71, 85);
            this.pbDownloadSpeed1.Name = "pbDownloadSpeed1";
            this.pbDownloadSpeed1.Size = new System.Drawing.Size(516, 25);
            this.pbDownloadSpeed1.TabIndex = 3;
            // 
            // btnBreakpointResume
            // 
            this.btnBreakpointResume.Location = new System.Drawing.Point(196, 47);
            this.btnBreakpointResume.Name = "btnBreakpointResume";
            this.btnBreakpointResume.Size = new System.Drawing.Size(106, 25);
            this.btnBreakpointResume.TabIndex = 4;
            this.btnBreakpointResume.Text = "断点续传";
            this.btnBreakpointResume.UseVisualStyleBackColor = true;
            this.btnBreakpointResume.Click += new System.EventHandler(this.btnBreakpointResume_Click);
            // 
            // lbSpreedMsg1
            // 
            this.lbSpreedMsg1.AutoSize = true;
            this.lbSpreedMsg1.Location = new System.Drawing.Point(74, 113);
            this.lbSpreedMsg1.Name = "lbSpreedMsg1";
            this.lbSpreedMsg1.Size = new System.Drawing.Size(0, 13);
            this.lbSpreedMsg1.TabIndex = 5;
            // 
            // btnSliceDownload
            // 
            this.btnSliceDownload.Location = new System.Drawing.Point(318, 47);
            this.btnSliceDownload.Name = "btnSliceDownload";
            this.btnSliceDownload.Size = new System.Drawing.Size(106, 25);
            this.btnSliceDownload.TabIndex = 6;
            this.btnSliceDownload.Text = "分片下载";
            this.btnSliceDownload.UseVisualStyleBackColor = true;
            this.btnSliceDownload.Click += new System.EventHandler(this.btnSliceDownload_Click);
            // 
            // pbDownloadSpeed2
            // 
            this.pbDownloadSpeed2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDownloadSpeed2.Location = new System.Drawing.Point(71, 129);
            this.pbDownloadSpeed2.Name = "pbDownloadSpeed2";
            this.pbDownloadSpeed2.Size = new System.Drawing.Size(516, 25);
            this.pbDownloadSpeed2.TabIndex = 7;
            // 
            // pbDownloadSpeed3
            // 
            this.pbDownloadSpeed3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDownloadSpeed3.Location = new System.Drawing.Point(71, 173);
            this.pbDownloadSpeed3.Name = "pbDownloadSpeed3";
            this.pbDownloadSpeed3.Size = new System.Drawing.Size(516, 25);
            this.pbDownloadSpeed3.TabIndex = 8;
            // 
            // pbDownloadSpeed5
            // 
            this.pbDownloadSpeed5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDownloadSpeed5.Location = new System.Drawing.Point(71, 259);
            this.pbDownloadSpeed5.Name = "pbDownloadSpeed5";
            this.pbDownloadSpeed5.Size = new System.Drawing.Size(516, 25);
            this.pbDownloadSpeed5.TabIndex = 10;
            // 
            // pbDownloadSpeed4
            // 
            this.pbDownloadSpeed4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDownloadSpeed4.Location = new System.Drawing.Point(71, 217);
            this.pbDownloadSpeed4.Name = "pbDownloadSpeed4";
            this.pbDownloadSpeed4.Size = new System.Drawing.Size(516, 25);
            this.pbDownloadSpeed4.TabIndex = 9;
            // 
            // pbDownloadSpeed7
            // 
            this.pbDownloadSpeed7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDownloadSpeed7.Location = new System.Drawing.Point(71, 347);
            this.pbDownloadSpeed7.Name = "pbDownloadSpeed7";
            this.pbDownloadSpeed7.Size = new System.Drawing.Size(516, 25);
            this.pbDownloadSpeed7.TabIndex = 12;
            // 
            // pbDownloadSpeed6
            // 
            this.pbDownloadSpeed6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDownloadSpeed6.Location = new System.Drawing.Point(71, 303);
            this.pbDownloadSpeed6.Name = "pbDownloadSpeed6";
            this.pbDownloadSpeed6.Size = new System.Drawing.Size(516, 25);
            this.pbDownloadSpeed6.TabIndex = 11;
            // 
            // pbDownloadSpeed9
            // 
            this.pbDownloadSpeed9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDownloadSpeed9.Location = new System.Drawing.Point(71, 435);
            this.pbDownloadSpeed9.Name = "pbDownloadSpeed9";
            this.pbDownloadSpeed9.Size = new System.Drawing.Size(516, 25);
            this.pbDownloadSpeed9.TabIndex = 14;
            // 
            // pbDownloadSpeed8
            // 
            this.pbDownloadSpeed8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDownloadSpeed8.Location = new System.Drawing.Point(71, 391);
            this.pbDownloadSpeed8.Name = "pbDownloadSpeed8";
            this.pbDownloadSpeed8.Size = new System.Drawing.Size(516, 25);
            this.pbDownloadSpeed8.TabIndex = 13;
            // 
            // pbDownloadSpeed10
            // 
            this.pbDownloadSpeed10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDownloadSpeed10.Location = new System.Drawing.Point(71, 479);
            this.pbDownloadSpeed10.Name = "pbDownloadSpeed10";
            this.pbDownloadSpeed10.Size = new System.Drawing.Size(516, 25);
            this.pbDownloadSpeed10.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "线程1：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "线程2：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "线程3：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "线程4：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "线程5：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 309);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "线程6：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 354);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "线程7：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 397);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "线程8：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 441);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "线程9：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 485);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "线程10：";
            // 
            // lbSpreedMsg2
            // 
            this.lbSpreedMsg2.AutoSize = true;
            this.lbSpreedMsg2.Location = new System.Drawing.Point(74, 157);
            this.lbSpreedMsg2.Name = "lbSpreedMsg2";
            this.lbSpreedMsg2.Size = new System.Drawing.Size(0, 13);
            this.lbSpreedMsg2.TabIndex = 26;
            // 
            // lbSpreedMsg3
            // 
            this.lbSpreedMsg3.AutoSize = true;
            this.lbSpreedMsg3.Location = new System.Drawing.Point(74, 201);
            this.lbSpreedMsg3.Name = "lbSpreedMsg3";
            this.lbSpreedMsg3.Size = new System.Drawing.Size(0, 13);
            this.lbSpreedMsg3.TabIndex = 27;
            // 
            // lbSpreedMsg4
            // 
            this.lbSpreedMsg4.AutoSize = true;
            this.lbSpreedMsg4.Location = new System.Drawing.Point(74, 244);
            this.lbSpreedMsg4.Name = "lbSpreedMsg4";
            this.lbSpreedMsg4.Size = new System.Drawing.Size(0, 13);
            this.lbSpreedMsg4.TabIndex = 28;
            // 
            // lbSpreedMsg5
            // 
            this.lbSpreedMsg5.AutoSize = true;
            this.lbSpreedMsg5.Location = new System.Drawing.Point(74, 287);
            this.lbSpreedMsg5.Name = "lbSpreedMsg5";
            this.lbSpreedMsg5.Size = new System.Drawing.Size(0, 13);
            this.lbSpreedMsg5.TabIndex = 29;
            // 
            // lbSpreedMsg6
            // 
            this.lbSpreedMsg6.AutoSize = true;
            this.lbSpreedMsg6.Location = new System.Drawing.Point(74, 331);
            this.lbSpreedMsg6.Name = "lbSpreedMsg6";
            this.lbSpreedMsg6.Size = new System.Drawing.Size(10, 13);
            this.lbSpreedMsg6.TabIndex = 31;
            this.lbSpreedMsg6.Text = " ";
            // 
            // lbSpreedMsg7
            // 
            this.lbSpreedMsg7.AutoSize = true;
            this.lbSpreedMsg7.Location = new System.Drawing.Point(74, 375);
            this.lbSpreedMsg7.Name = "lbSpreedMsg7";
            this.lbSpreedMsg7.Size = new System.Drawing.Size(10, 13);
            this.lbSpreedMsg7.TabIndex = 32;
            this.lbSpreedMsg7.Text = " ";
            // 
            // lbSpreedMsg8
            // 
            this.lbSpreedMsg8.AutoSize = true;
            this.lbSpreedMsg8.Location = new System.Drawing.Point(74, 419);
            this.lbSpreedMsg8.Name = "lbSpreedMsg8";
            this.lbSpreedMsg8.Size = new System.Drawing.Size(10, 13);
            this.lbSpreedMsg8.TabIndex = 33;
            this.lbSpreedMsg8.Text = " ";
            // 
            // lbSpreedMsg9
            // 
            this.lbSpreedMsg9.AutoSize = true;
            this.lbSpreedMsg9.Location = new System.Drawing.Point(74, 463);
            this.lbSpreedMsg9.Name = "lbSpreedMsg9";
            this.lbSpreedMsg9.Size = new System.Drawing.Size(10, 13);
            this.lbSpreedMsg9.TabIndex = 34;
            this.lbSpreedMsg9.Text = " ";
            // 
            // lbSpreedMsg10
            // 
            this.lbSpreedMsg10.AutoSize = true;
            this.lbSpreedMsg10.Location = new System.Drawing.Point(74, 507);
            this.lbSpreedMsg10.Name = "lbSpreedMsg10";
            this.lbSpreedMsg10.Size = new System.Drawing.Size(10, 13);
            this.lbSpreedMsg10.TabIndex = 35;
            this.lbSpreedMsg10.Text = " ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 524);
            this.Controls.Add(this.lbSpreedMsg10);
            this.Controls.Add(this.lbSpreedMsg9);
            this.Controls.Add(this.lbSpreedMsg8);
            this.Controls.Add(this.lbSpreedMsg7);
            this.Controls.Add(this.lbSpreedMsg6);
            this.Controls.Add(this.lbSpreedMsg5);
            this.Controls.Add(this.lbSpreedMsg4);
            this.Controls.Add(this.lbSpreedMsg3);
            this.Controls.Add(this.lbSpreedMsg2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbDownloadSpeed10);
            this.Controls.Add(this.pbDownloadSpeed9);
            this.Controls.Add(this.pbDownloadSpeed8);
            this.Controls.Add(this.pbDownloadSpeed7);
            this.Controls.Add(this.pbDownloadSpeed6);
            this.Controls.Add(this.pbDownloadSpeed5);
            this.Controls.Add(this.pbDownloadSpeed4);
            this.Controls.Add(this.pbDownloadSpeed3);
            this.Controls.Add(this.pbDownloadSpeed2);
            this.Controls.Add(this.btnSliceDownload);
            this.Controls.Add(this.lbSpreedMsg1);
            this.Controls.Add(this.btnBreakpointResume);
            this.Controls.Add(this.pbDownloadSpeed1);
            this.Controls.Add(this.btnDirectDownload);
            this.Controls.Add(this.tbDownloadUri);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "下载界面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDownloadUri;
        private System.Windows.Forms.Button btnDirectDownload;
        private System.Windows.Forms.ProgressBar pbDownloadSpeed1;
        private System.Windows.Forms.Button btnBreakpointResume;
        private System.Windows.Forms.Label lbSpreedMsg1;
        private System.Windows.Forms.Button btnSliceDownload;
        private System.Windows.Forms.ProgressBar pbDownloadSpeed2;
        private System.Windows.Forms.ProgressBar pbDownloadSpeed3;
        private System.Windows.Forms.ProgressBar pbDownloadSpeed5;
        private System.Windows.Forms.ProgressBar pbDownloadSpeed4;
        private System.Windows.Forms.ProgressBar pbDownloadSpeed7;
        private System.Windows.Forms.ProgressBar pbDownloadSpeed6;
        private System.Windows.Forms.ProgressBar pbDownloadSpeed9;
        private System.Windows.Forms.ProgressBar pbDownloadSpeed8;
        private System.Windows.Forms.ProgressBar pbDownloadSpeed10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbSpreedMsg2;
        private System.Windows.Forms.Label lbSpreedMsg3;
        private System.Windows.Forms.Label lbSpreedMsg4;
        private System.Windows.Forms.Label lbSpreedMsg5;
        private System.Windows.Forms.Label lbSpreedMsg6;
        private System.Windows.Forms.Label lbSpreedMsg7;
        private System.Windows.Forms.Label lbSpreedMsg8;
        private System.Windows.Forms.Label lbSpreedMsg9;
        private System.Windows.Forms.Label lbSpreedMsg10;
    }
}

