namespace Pocetni
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imgBB8 = new System.Windows.Forms.PictureBox();
            this.imgZmijica = new System.Windows.Forms.PictureBox();
            this.btnFabrika = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgBB8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgZmijica)).BeginInit();
            this.SuspendLayout();
            // 
            // imgBB8
            // 
            this.imgBB8.Image = ((System.Drawing.Image)(resources.GetObject("imgBB8.Image")));
            this.imgBB8.Location = new System.Drawing.Point(500, 800);
            this.imgBB8.Name = "imgBB8";
            this.imgBB8.Size = new System.Drawing.Size(150, 149);
            this.imgBB8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBB8.TabIndex = 2;
            this.imgBB8.TabStop = false;
            this.imgBB8.Click += new System.EventHandler(this.imgBB8_Click);
            // 
            // imgZmijica
            // 
            this.imgZmijica.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imgZmijica.BackgroundImage")));
            this.imgZmijica.Location = new System.Drawing.Point(1000, 300);
            this.imgZmijica.Name = "imgZmijica";
            this.imgZmijica.Size = new System.Drawing.Size(150, 100);
            this.imgZmijica.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgZmijica.TabIndex = 3;
            this.imgZmijica.TabStop = false;
            this.imgZmijica.Click += new System.EventHandler(this.imgZmijica_Click);
            // 
            // btnFabrika
            // 
            this.btnFabrika.BackColor = System.Drawing.Color.DimGray;
            this.btnFabrika.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFabrika.ForeColor = System.Drawing.Color.Firebrick;
            this.btnFabrika.Location = new System.Drawing.Point(23, 288);
            this.btnFabrika.Name = "btnFabrika";
            this.btnFabrika.Size = new System.Drawing.Size(105, 32);
            this.btnFabrika.TabIndex = 4;
            this.btnFabrika.Text = "FABRIKA";
            this.btnFabrika.UseVisualStyleBackColor = false;
            this.btnFabrika.Click += new System.EventHandler(this.btnFabrika_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1215, 906);
            this.Controls.Add(this.btnFabrika);
            this.Controls.Add(this.imgZmijica);
            this.Controls.Add(this.imgBB8);
            this.Name = "Form1";
            this.Text = "Igrice Bo i Vivi";
            ((System.ComponentModel.ISupportInitialize)(this.imgBB8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgZmijica)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox imgBB8;
        private System.Windows.Forms.PictureBox imgZmijica;
        private System.Windows.Forms.Button btnFabrika;
    }
}

