namespace WindowsFormsApp1
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.captureFrame = new System.Windows.Forms.PictureBox();
            this.streamBtn = new System.Windows.Forms.Button();
            this.snapshotBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.captureFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // captureFrame
            // 
            this.captureFrame.ErrorImage = global::WindowsFormsApp1.Properties.Resources.giphy;
            this.captureFrame.InitialImage = global::WindowsFormsApp1.Properties.Resources.giphy;
            this.captureFrame.Location = new System.Drawing.Point(0, -2);
            this.captureFrame.Name = "captureFrame";
            this.captureFrame.Size = new System.Drawing.Size(802, 296);
            this.captureFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.captureFrame.TabIndex = 0;
            this.captureFrame.TabStop = false;
            // 
            // streamBtn
            // 
            this.streamBtn.BackColor = System.Drawing.Color.SeaGreen;
            this.streamBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.streamBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.streamBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.streamBtn.Location = new System.Drawing.Point(12, 300);
            this.streamBtn.Name = "streamBtn";
            this.streamBtn.Size = new System.Drawing.Size(252, 118);
            this.streamBtn.TabIndex = 1;
            this.streamBtn.Text = "Start";
            this.streamBtn.UseVisualStyleBackColor = false;
            this.streamBtn.Click += new System.EventHandler(this.streamBtn_Click);
            // 
            // snapshotBtn
            // 
            this.snapshotBtn.BackColor = System.Drawing.Color.CadetBlue;
            this.snapshotBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.snapshotBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.snapshotBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.snapshotBtn.Location = new System.Drawing.Point(536, 300);
            this.snapshotBtn.Name = "snapshotBtn";
            this.snapshotBtn.Size = new System.Drawing.Size(252, 118);
            this.snapshotBtn.TabIndex = 2;
            this.snapshotBtn.Text = "Take Snapshot";
            this.snapshotBtn.UseVisualStyleBackColor = false;
            this.snapshotBtn.Click += new System.EventHandler(this.snapshotBtn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.snapshotBtn);
            this.Controls.Add(this.streamBtn);
            this.Controls.Add(this.captureFrame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "CaptureMe";
            ((System.ComponentModel.ISupportInitialize)(this.captureFrame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox captureFrame;
        private System.Windows.Forms.Button streamBtn;
        private System.Windows.Forms.Button snapshotBtn;
    }
}

