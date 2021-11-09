
namespace Monets.WinUI.Forms.Rezervacija
{
    partial class frmPotvrdaRezervacije
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPotvrdaRezervacije));
            this.btnPotvrdi = new System.Windows.Forms.Button();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.txtPotvrdi = new System.Windows.Forms.TextBox();
            this.lblNaslov = new System.Windows.Forms.Label();
            this.btnOdbij = new System.Windows.Forms.Button();
            this.txtOdbij = new System.Windows.Forms.TextBox();
            this.lblUputa = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSifra = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPotvrdi
            // 
            this.btnPotvrdi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPotvrdi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(9)))));
            this.btnPotvrdi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPotvrdi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.btnPotvrdi.FlatAppearance.BorderSize = 0;
            this.btnPotvrdi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPotvrdi.Font = new System.Drawing.Font("Corbel", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPotvrdi.ForeColor = System.Drawing.Color.Black;
            this.btnPotvrdi.Location = new System.Drawing.Point(665, 351);
            this.btnPotvrdi.Margin = new System.Windows.Forms.Padding(0);
            this.btnPotvrdi.Name = "btnPotvrdi";
            this.btnPotvrdi.Size = new System.Drawing.Size(338, 112);
            this.btnPotvrdi.TabIndex = 30;
            this.btnPotvrdi.Text = "Potvrdi";
            this.btnPotvrdi.UseVisualStyleBackColor = false;
            this.btnPotvrdi.Click += new System.EventHandler(this.btnPotvrdi_Click);
            // 
            // pbLoading
            // 
            this.pbLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLoading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbLoading.Image = ((System.Drawing.Image)(resources.GetObject("pbLoading.Image")));
            this.pbLoading.Location = new System.Drawing.Point(409, 483);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(330, 189);
            this.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLoading.TabIndex = 31;
            this.pbLoading.TabStop = false;
            // 
            // txtPotvrdi
            // 
            this.txtPotvrdi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            this.txtPotvrdi.Font = new System.Drawing.Font("Corbel Light", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.txtPotvrdi.Location = new System.Drawing.Point(648, 124);
            this.txtPotvrdi.Multiline = true;
            this.txtPotvrdi.Name = "txtPotvrdi";
            this.txtPotvrdi.ReadOnly = true;
            this.txtPotvrdi.Size = new System.Drawing.Size(377, 213);
            this.txtPotvrdi.TabIndex = 33;
            // 
            // lblNaslov
            // 
            this.lblNaslov.Font = new System.Drawing.Font("Corbel", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lblNaslov.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblNaslov.Location = new System.Drawing.Point(85, 9);
            this.lblNaslov.Name = "lblNaslov";
            this.lblNaslov.Size = new System.Drawing.Size(578, 36);
            this.lblNaslov.TabIndex = 32;
            this.lblNaslov.Text = "Potvrda rezervacije (Odaberite jednu opciju):";
            // 
            // btnOdbij
            // 
            this.btnOdbij.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOdbij.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(76)))), ((int)(((byte)(54)))));
            this.btnOdbij.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOdbij.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.btnOdbij.FlatAppearance.BorderSize = 0;
            this.btnOdbij.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOdbij.Font = new System.Drawing.Font("Corbel", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnOdbij.ForeColor = System.Drawing.Color.Black;
            this.btnOdbij.Location = new System.Drawing.Point(199, 351);
            this.btnOdbij.Margin = new System.Windows.Forms.Padding(0);
            this.btnOdbij.Name = "btnOdbij";
            this.btnOdbij.Size = new System.Drawing.Size(338, 112);
            this.btnOdbij.TabIndex = 34;
            this.btnOdbij.Text = "Odbij";
            this.btnOdbij.UseVisualStyleBackColor = false;
            this.btnOdbij.Click += new System.EventHandler(this.btnOdbij_Click);
            // 
            // txtOdbij
            // 
            this.txtOdbij.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            this.txtOdbij.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOdbij.Location = new System.Drawing.Point(178, 124);
            this.txtOdbij.Multiline = true;
            this.txtOdbij.Name = "txtOdbij";
            this.txtOdbij.Size = new System.Drawing.Size(377, 213);
            this.txtOdbij.TabIndex = 35;
            // 
            // lblUputa
            // 
            this.lblUputa.AutoSize = true;
            this.lblUputa.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUputa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblUputa.Location = new System.Drawing.Point(178, 86);
            this.lblUputa.Margin = new System.Windows.Forms.Padding(0);
            this.lblUputa.Name = "lblUputa";
            this.lblUputa.Size = new System.Drawing.Size(222, 26);
            this.lblUputa.TabIndex = 36;
            this.lblUputa.Text = "Upišite razlog odbijanja :";
            this.lblUputa.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.label1.Location = new System.Drawing.Point(770, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 26);
            this.label1.TabIndex = 37;
            this.label1.Text = "Šifra rezervacije:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSifra
            // 
            this.lblSifra.AutoSize = true;
            this.lblSifra.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSifra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblSifra.Location = new System.Drawing.Point(925, 19);
            this.lblSifra.Margin = new System.Windows.Forms.Padding(0);
            this.lblSifra.Name = "lblSifra";
            this.lblSifra.Size = new System.Drawing.Size(155, 26);
            this.lblSifra.TabIndex = 38;
            this.lblSifra.Text = "Šifra rezervacije:";
            this.lblSifra.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmPotvrdaRezervacije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 698);
            this.Controls.Add(this.lblSifra);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblUputa);
            this.Controls.Add(this.btnOdbij);
            this.Controls.Add(this.txtOdbij);
            this.Controls.Add(this.btnPotvrdi);
            this.Controls.Add(this.pbLoading);
            this.Controls.Add(this.txtPotvrdi);
            this.Controls.Add(this.lblNaslov);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1214, 698);
            this.MinimumSize = new System.Drawing.Size(1214, 698);
            this.Name = "frmPotvrdaRezervacije";
            this.Text = "frmPotvrdaRezervacije";
            this.Load += new System.EventHandler(this.frmPotvrdaRezervacije_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPotvrdi;
        private System.Windows.Forms.PictureBox pbLoading;
        private System.Windows.Forms.TextBox txtPotvrdi;
        private System.Windows.Forms.Label lblNaslov;
        private System.Windows.Forms.Button btnOdbij;
        private System.Windows.Forms.TextBox txtOdbij;
        private System.Windows.Forms.Label lblUputa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSifra;
    }
}