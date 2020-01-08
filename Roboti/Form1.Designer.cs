namespace Roboti
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
            this.btnNivo1 = new System.Windows.Forms.Button();
            this.btnNivo2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNivo1
            // 
            this.btnNivo1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnNivo1.Location = new System.Drawing.Point(164, 50);
            this.btnNivo1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNivo1.Name = "btnNivo1";
            this.btnNivo1.Size = new System.Drawing.Size(115, 45);
            this.btnNivo1.TabIndex = 0;
            this.btnNivo1.Text = "NIVO 1 BIBI8";
            this.btnNivo1.UseVisualStyleBackColor = false;
            this.btnNivo1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnNivo2
            // 
            this.btnNivo2.BackColor = System.Drawing.Color.Red;
            this.btnNivo2.Location = new System.Drawing.Point(164, 100);
            this.btnNivo2.Name = "btnNivo2";
            this.btnNivo2.Size = new System.Drawing.Size(115, 52);
            this.btnNivo2.TabIndex = 1;
            this.btnNivo2.Text = "BB8 I R2D2 se ponovo sreću";
            this.btnNivo2.UseVisualStyleBackColor = false;
            this.btnNivo2.Click += new System.EventHandler(this.btnNivo2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(323, 228);
            this.Controls.Add(this.btnNivo2);
            this.Controls.Add(this.btnNivo1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Roboti";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNivo1;
        private System.Windows.Forms.Button btnNivo2;
    }
}

