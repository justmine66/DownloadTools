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
            this.pbDownloadSpeed = new System.Windows.Forms.ProgressBar();
            this.btnBreakpointResume = new System.Windows.Forms.Button();
            this.lbSpreedMsg = new System.Windows.Forms.Label();
            this.btnSliceDownload = new System.Windows.Forms.Button();
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
            this.btnDirectDownload.Location = new System.Drawing.Point(71, 53);
            this.btnDirectDownload.Name = "btnDirectDownload";
            this.btnDirectDownload.Size = new System.Drawing.Size(106, 25);
            this.btnDirectDownload.TabIndex = 2;
            this.btnDirectDownload.Text = "直接下载";
            this.btnDirectDownload.UseVisualStyleBackColor = true;
            this.btnDirectDownload.Click += new System.EventHandler(this.btnDirectDownload_Click);
            // 
            // pbDownloadSpeed
            // 
            this.pbDownloadSpeed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDownloadSpeed.Location = new System.Drawing.Point(71, 102);
            this.pbDownloadSpeed.Name = "pbDownloadSpeed";
            this.pbDownloadSpeed.Size = new System.Drawing.Size(516, 25);
            this.pbDownloadSpeed.TabIndex = 3;
            // 
            // btnBreakpointResume
            // 
            this.btnBreakpointResume.Location = new System.Drawing.Point(196, 53);
            this.btnBreakpointResume.Name = "btnBreakpointResume";
            this.btnBreakpointResume.Size = new System.Drawing.Size(106, 25);
            this.btnBreakpointResume.TabIndex = 4;
            this.btnBreakpointResume.Text = "断点续传";
            this.btnBreakpointResume.UseVisualStyleBackColor = true;
            this.btnBreakpointResume.Click += new System.EventHandler(this.btnBreakpointResume_Click);
            // 
            // lbSpreedMsg
            // 
            this.lbSpreedMsg.AutoSize = true;
            this.lbSpreedMsg.Location = new System.Drawing.Point(71, 134);
            this.lbSpreedMsg.Name = "lbSpreedMsg";
            this.lbSpreedMsg.Size = new System.Drawing.Size(0, 13);
            this.lbSpreedMsg.TabIndex = 5;
            // 
            // btnSliceDownload
            // 
            this.btnSliceDownload.Location = new System.Drawing.Point(318, 53);
            this.btnSliceDownload.Name = "btnSliceDownload";
            this.btnSliceDownload.Size = new System.Drawing.Size(106, 25);
            this.btnSliceDownload.TabIndex = 6;
            this.btnSliceDownload.Text = "分片下载";
            this.btnSliceDownload.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 158);
            this.Controls.Add(this.btnSliceDownload);
            this.Controls.Add(this.lbSpreedMsg);
            this.Controls.Add(this.btnBreakpointResume);
            this.Controls.Add(this.pbDownloadSpeed);
            this.Controls.Add(this.btnDirectDownload);
            this.Controls.Add(this.tbDownloadUri);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "下载界面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDownloadUri;
        private System.Windows.Forms.Button btnDirectDownload;
        private System.Windows.Forms.ProgressBar pbDownloadSpeed;
        private System.Windows.Forms.Button btnBreakpointResume;
        private System.Windows.Forms.Label lbSpreedMsg;
        private System.Windows.Forms.Button btnSliceDownload;
    }
}

