﻿namespace QuanLySoThu
{
    partial class pageTrangChu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picBG = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBG)).BeginInit();
            this.SuspendLayout();
            // 
            // picBG
            // 
            this.picBG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBG.Image = global::QuanLySoThu.Properties.Resources.bgtrangchu;
            this.picBG.Location = new System.Drawing.Point(0, 0);
            this.picBG.Name = "picBG";
            this.picBG.Size = new System.Drawing.Size(1203, 693);
            this.picBG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBG.TabIndex = 5;
            this.picBG.TabStop = false;
            // 
            // pageTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picBG);
            this.Name = "pageTrangChu";
            this.Size = new System.Drawing.Size(1203, 693);
            ((System.ComponentModel.ISupportInitialize)(this.picBG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBG;
    }
}
