
namespace Monets.WinUI.Forms.Rezervacija
{
    partial class frmRezervacija
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRezervacija));
            this.lblStol = new System.Windows.Forms.Label();
            this.lblCijena = new System.Windows.Forms.Label();
            this.lblDatum = new System.Windows.Forms.Label();
            this.lblVrijeme = new System.Windows.Forms.Label();
            this.lblSifra = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblKorisnik = new System.Windows.Forms.Label();
            this.lblPlaceno = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStol
            // 
            this.lblStol.AutoSize = true;
            this.lblStol.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Bold);
            this.lblStol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(136)))), ((int)(((byte)(174)))));
            this.lblStol.Location = new System.Drawing.Point(107, 45);
            this.lblStol.Name = "lblStol";
            this.lblStol.Size = new System.Drawing.Size(51, 21);
            this.lblStol.TabIndex = 13;
            this.lblStol.Text = "stol 1";
            // 
            // lblCijena
            // 
            this.lblCijena.AutoSize = true;
            this.lblCijena.BackColor = System.Drawing.Color.Transparent;
            this.lblCijena.Font = new System.Drawing.Font("Ebrima", 24F);
            this.lblCijena.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblCijena.Location = new System.Drawing.Point(722, 51);
            this.lblCijena.Name = "lblCijena";
            this.lblCijena.Size = new System.Drawing.Size(111, 45);
            this.lblCijena.TabIndex = 8;
            this.lblCijena.Text = "45 KM";
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Font = new System.Drawing.Font("Ebrima", 15F, System.Drawing.FontStyle.Bold);
            this.lblDatum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(136)))), ((int)(((byte)(174)))));
            this.lblDatum.Location = new System.Drawing.Point(391, 42);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(118, 28);
            this.lblDatum.TabIndex = 14;
            this.lblDatum.Text = "20.20.2901";
            // 
            // lblVrijeme
            // 
            this.lblVrijeme.AutoSize = true;
            this.lblVrijeme.Font = new System.Drawing.Font("Ebrima", 15F, System.Drawing.FontStyle.Bold);
            this.lblVrijeme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(136)))), ((int)(((byte)(174)))));
            this.lblVrijeme.Location = new System.Drawing.Point(413, 72);
            this.lblVrijeme.Name = "lblVrijeme";
            this.lblVrijeme.Size = new System.Drawing.Size(65, 28);
            this.lblVrijeme.TabIndex = 15;
            this.lblVrijeme.Text = "20:35";
            // 
            // lblSifra
            // 
            this.lblSifra.AutoSize = true;
            this.lblSifra.Font = new System.Drawing.Font("Corbel", 24F, System.Drawing.FontStyle.Bold);
            this.lblSifra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblSifra.Location = new System.Drawing.Point(389, 2);
            this.lblSifra.Name = "lblSifra";
            this.lblSifra.Size = new System.Drawing.Size(132, 39);
            this.lblSifra.TabIndex = 17;
            this.lblSifra.Text = "KASJDA";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(33, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // lblKorisnik
            // 
            this.lblKorisnik.AutoSize = true;
            this.lblKorisnik.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Bold);
            this.lblKorisnik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(136)))), ((int)(((byte)(174)))));
            this.lblKorisnik.Location = new System.Drawing.Point(107, 72);
            this.lblKorisnik.Name = "lblKorisnik";
            this.lblKorisnik.Size = new System.Drawing.Size(109, 21);
            this.lblKorisnik.TabIndex = 20;
            this.lblKorisnik.Text = "Device Redtz";
            // 
            // lblPlaceno
            // 
            this.lblPlaceno.AutoSize = true;
            this.lblPlaceno.BackColor = System.Drawing.Color.Transparent;
            this.lblPlaceno.Font = new System.Drawing.Font("Ebrima", 24F, System.Drawing.FontStyle.Underline);
            this.lblPlaceno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblPlaceno.Location = new System.Drawing.Point(678, 2);
            this.lblPlaceno.Name = "lblPlaceno";
            this.lblPlaceno.Size = new System.Drawing.Size(198, 45);
            this.lblPlaceno.TabIndex = 21;
            this.lblPlaceno.Text = "Nije plaćeno";
            this.lblPlaceno.Click += new System.EventHandler(this.lblPlaceno_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.label1.Location = new System.Drawing.Point(26, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 39);
            this.label1.TabIndex = 22;
            this.label1.Text = "Šifra rezervacije:";
            // 
            // frmRezervacija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(898, 107);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPlaceno);
            this.Controls.Add(this.lblKorisnik);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblSifra);
            this.Controls.Add(this.lblVrijeme);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.lblStol);
            this.Controls.Add(this.lblCijena);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(900, 109);
            this.Name = "frmRezervacija";
            this.Load += new System.EventHandler(this.frmRezervacija_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStol;
        private System.Windows.Forms.Label lblCijena;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.Label lblVrijeme;
        private System.Windows.Forms.Label lblSifra;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblKorisnik;
        private System.Windows.Forms.Label lblPlaceno;
        private System.Windows.Forms.Label label1;
    }
}