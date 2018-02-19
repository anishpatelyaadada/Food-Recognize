namespace Food_Recognition_EmguCV_08302016
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
            this.RealImage = new System.Windows.Forms.PictureBox();
            this.subtractImage = new System.Windows.Forms.PictureBox();
            this.OpenImageByClickingButton = new System.Windows.Forms.Button();
            this.TestImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.RealImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subtractImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestImage)).BeginInit();
            this.SuspendLayout();
            // 
            // RealImage
            // 
            this.RealImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.RealImage.Location = new System.Drawing.Point(12, 12);
            this.RealImage.Name = "RealImage";
            this.RealImage.Size = new System.Drawing.Size(510, 600);
            this.RealImage.TabIndex = 0;
            this.RealImage.TabStop = false;
            // 
            // subtractImage
            // 
            this.subtractImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.subtractImage.Location = new System.Drawing.Point(528, 12);
            this.subtractImage.Name = "subtractImage";
            this.subtractImage.Size = new System.Drawing.Size(510, 600);
            this.subtractImage.TabIndex = 1;
            this.subtractImage.TabStop = false;
            // 
            // OpenImageByClickingButton
            // 
            this.OpenImageByClickingButton.Location = new System.Drawing.Point(12, 619);
            this.OpenImageByClickingButton.Name = "OpenImageByClickingButton";
            this.OpenImageByClickingButton.Size = new System.Drawing.Size(127, 31);
            this.OpenImageByClickingButton.TabIndex = 2;
            this.OpenImageByClickingButton.Text = "Open Image";
            this.OpenImageByClickingButton.UseVisualStyleBackColor = true;
            this.OpenImageByClickingButton.Click += new System.EventHandler(this.OpenImageByClickingButton_Click);
            // 
            // TestImage
            // 
            this.TestImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TestImage.Location = new System.Drawing.Point(1044, 12);
            this.TestImage.Name = "TestImage";
            this.TestImage.Size = new System.Drawing.Size(510, 600);
            this.TestImage.TabIndex = 3;
            this.TestImage.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1580, 744);
            this.Controls.Add(this.TestImage);
            this.Controls.Add(this.OpenImageByClickingButton);
            this.Controls.Add(this.subtractImage);
            this.Controls.Add(this.RealImage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RealImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subtractImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox RealImage;
        private System.Windows.Forms.PictureBox subtractImage;
        private System.Windows.Forms.Button OpenImageByClickingButton;
        private System.Windows.Forms.PictureBox TestImage;
    }
}

