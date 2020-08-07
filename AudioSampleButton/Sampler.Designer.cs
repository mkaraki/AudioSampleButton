namespace AudioSampleButton
{
    partial class Sampler
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
            this.pbar_load = new System.Windows.Forms.ProgressBar();
            this.lbl_loading = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pbar_load
            // 
            this.pbar_load.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbar_load.Location = new System.Drawing.Point(0, 0);
            this.pbar_load.Name = "pbar_load";
            this.pbar_load.Size = new System.Drawing.Size(800, 23);
            this.pbar_load.TabIndex = 0;
            // 
            // lbl_loading
            // 
            this.lbl_loading.AutoSize = true;
            this.lbl_loading.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_loading.Location = new System.Drawing.Point(0, 23);
            this.lbl_loading.Name = "lbl_loading";
            this.lbl_loading.Size = new System.Drawing.Size(75, 13);
            this.lbl_loading.TabIndex = 1;
            this.lbl_loading.Text = "Reading Bank";
            // 
            // Sampler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_loading);
            this.Controls.Add(this.pbar_load);
            this.Name = "Sampler";
            this.Text = "Sampler";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Sampler_FormClosed);
            this.Load += new System.EventHandler(this.Sampler_Load);
            this.Shown += new System.EventHandler(this.Sampler_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbar_load;
        private System.Windows.Forms.Label lbl_loading;
    }
}