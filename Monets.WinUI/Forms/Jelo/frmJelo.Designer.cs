
using Monets.WinUI.Helper;

namespace Monets.WinUI.Forms
{
    partial class frmJelo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEdit = new FontAwesome.Sharp.IconButton();
            this.pbRejting = new System.Windows.Forms.ProgressBar();
            this.lblRejting = new System.Windows.Forms.Label();
            this.lblNazivJela = new System.Windows.Forms.Label();
            this.pbSlika = new System.Windows.Forms.PictureBox();
            this.lblCijena = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.pbRejting);
            this.panel1.Controls.Add(this.lblRejting);
            this.panel1.Controls.Add(this.lblNazivJela);
            this.panel1.Controls.Add(this.pbSlika);
            this.panel1.Controls.Add(this.lblCijena);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(33)))), ((int)(((byte)(107)))));
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 127);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.btnEdit.IconChar = FontAwesome.Sharp.IconChar.Pen;
            this.btnEdit.IconColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEdit.IconSize = 20;
            this.btnEdit.Location = new System.Drawing.Point(299, 98);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(24, 24);
            this.btnEdit.TabIndex = 16;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // pbRejting
            // 
            this.pbRejting.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbRejting.Location = new System.Drawing.Point(93, 76);
            this.pbRejting.MarqueeAnimationSpeed = 50;
            this.pbRejting.Name = "pbRejting";
            this.pbRejting.Size = new System.Drawing.Size(144, 10);
            this.pbRejting.TabIndex = 15;
            this.pbRejting.Value = 1;
            // 
            // lblRejting
            // 
            this.lblRejting.AutoSize = true;
            this.lblRejting.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRejting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(136)))), ((int)(((byte)(174)))));
            this.lblRejting.Location = new System.Drawing.Point(93, 58);
            this.lblRejting.Name = "lblRejting";
            this.lblRejting.Size = new System.Drawing.Size(144, 15);
            this.lblRejting.TabIndex = 13;
            this.lblRejting.Text = "Rejting 5/5 (184 rejtinga)";
            this.lblRejting.Click += new System.EventHandler(this.lblRejting_Click);
            // 
            // lblNazivJela
            // 
            this.lblNazivJela.AutoSize = true;
            this.lblNazivJela.Font = new System.Drawing.Font("Corbel", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNazivJela.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblNazivJela.Location = new System.Drawing.Point(93, 3);
            this.lblNazivJela.Name = "lblNazivJela";
            this.lblNazivJela.Size = new System.Drawing.Size(71, 22);
            this.lblNazivJela.TabIndex = 12;
            this.lblNazivJela.Text = "Monet\'s";
            // 
            // pbSlika
            // 
            this.pbSlika.BackColor = System.Drawing.Color.Transparent;
            this.pbSlika.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSlika.Location = new System.Drawing.Point(3, 3);
            this.pbSlika.Name = "pbSlika";
            this.pbSlika.Size = new System.Drawing.Size(84, 83);
            this.pbSlika.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSlika.TabIndex = 11;
            this.pbSlika.TabStop = false;
            // 
            // lblCijena
            // 
            this.lblCijena.AutoSize = true;
            this.lblCijena.BackColor = System.Drawing.Color.Transparent;
            this.lblCijena.Font = new System.Drawing.Font("Corbel", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCijena.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblCijena.Location = new System.Drawing.Point(8, 89);
            this.lblCijena.Name = "lblCijena";
            this.lblCijena.Size = new System.Drawing.Size(67, 26);
            this.lblCijena.TabIndex = 8;
            this.lblCijena.Text = "45 KM";
            // 
            // frmJelo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 119);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(336, 135);
            this.MinimumSize = new System.Drawing.Size(336, 135);
            this.Name = "frmJelo";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCijena;
        private System.Windows.Forms.PictureBox pbSlika;
        private System.Windows.Forms.Label lblRejting;
        private System.Windows.Forms.Label lblNazivJela;
        private System.Windows.Forms.ProgressBar pbRejting;
        private FontAwesome.Sharp.IconButton btnEdit;
    }
}