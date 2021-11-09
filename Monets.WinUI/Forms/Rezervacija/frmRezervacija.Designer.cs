
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
            this.btnPotvrda = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblKorisnik = new System.Windows.Forms.Label();
            this.lblPlaceno = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRazlog = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStol
            // 
            this.lblStol.AutoSize = true;
            this.lblStol.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(136)))), ((int)(((byte)(174)))));
            this.lblStol.Location = new System.Drawing.Point(125, 52);
            this.lblStol.Name = "lblStol";
            this.lblStol.Size = new System.Drawing.Size(51, 21);
            this.lblStol.TabIndex = 13;
            this.lblStol.Text = "stol 1";
            // 
            // lblCijena
            // 
            this.lblCijena.AutoSize = true;
            this.lblCijena.BackColor = System.Drawing.Color.Transparent;
            this.lblCijena.Font = new System.Drawing.Font("Ebrima", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCijena.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblCijena.Location = new System.Drawing.Point(453, 12);
            this.lblCijena.Name = "lblCijena";
            this.lblCijena.Size = new System.Drawing.Size(111, 45);
            this.lblCijena.TabIndex = 8;
            this.lblCijena.Text = "45 KM";
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Font = new System.Drawing.Font("Ebrima", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDatum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(136)))), ((int)(((byte)(174)))));
            this.lblDatum.Location = new System.Drawing.Point(296, 52);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(118, 28);
            this.lblDatum.TabIndex = 14;
            this.lblDatum.Text = "20.20.2901";
            // 
            // lblVrijeme
            // 
            this.lblVrijeme.AutoSize = true;
            this.lblVrijeme.Font = new System.Drawing.Font("Ebrima", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblVrijeme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(136)))), ((int)(((byte)(174)))));
            this.lblVrijeme.Location = new System.Drawing.Point(296, 76);
            this.lblVrijeme.Name = "lblVrijeme";
            this.lblVrijeme.Size = new System.Drawing.Size(65, 28);
            this.lblVrijeme.TabIndex = 15;
            this.lblVrijeme.Text = "20:35";
            // 
            // lblSifra
            // 
            this.lblSifra.AutoSize = true;
            this.lblSifra.Font = new System.Drawing.Font("Corbel", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSifra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblSifra.Location = new System.Drawing.Point(296, 12);
            this.lblSifra.Name = "lblSifra";
            this.lblSifra.Size = new System.Drawing.Size(132, 39);
            this.lblSifra.TabIndex = 17;
            this.lblSifra.Text = "KASJDA";
            // 
            // btnPotvrda
            // 
            this.btnPotvrda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(9)))));
            this.btnPotvrda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPotvrda.Font = new System.Drawing.Font("Ebrima", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPotvrda.Location = new System.Drawing.Point(658, 24);
            this.btnPotvrda.Name = "btnPotvrda";
            this.btnPotvrda.Size = new System.Drawing.Size(368, 78);
            this.btnPotvrda.TabIndex = 18;
            this.btnPotvrda.Text = "Potvrđena";
            this.btnPotvrda.UseVisualStyleBackColor = false;
            this.btnPotvrda.Click += new System.EventHandler(this.btnPotvrda_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(39, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // lblKorisnik
            // 
            this.lblKorisnik.AutoSize = true;
            this.lblKorisnik.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKorisnik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(136)))), ((int)(((byte)(174)))));
            this.lblKorisnik.Location = new System.Drawing.Point(125, 83);
            this.lblKorisnik.Name = "lblKorisnik";
            this.lblKorisnik.Size = new System.Drawing.Size(109, 21);
            this.lblKorisnik.TabIndex = 20;
            this.lblKorisnik.Text = "Device Redtz";
            // 
            // lblPlaceno
            // 
            this.lblPlaceno.AutoSize = true;
            this.lblPlaceno.BackColor = System.Drawing.Color.Transparent;
            this.lblPlaceno.Font = new System.Drawing.Font("Ebrima", 24F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.lblPlaceno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblPlaceno.Location = new System.Drawing.Point(453, 57);
            this.lblPlaceno.Name = "lblPlaceno";
            this.lblPlaceno.Size = new System.Drawing.Size(198, 45);
            this.lblPlaceno.TabIndex = 21;
            this.lblPlaceno.Text = "Nije plaćeno";
            this.lblPlaceno.Click += new System.EventHandler(this.lblPlaceno_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.label1.Location = new System.Drawing.Point(39, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 39);
            this.label1.TabIndex = 22;
            this.label1.Text = "Šifra rezervacije:";
            // 
            // lblRazlog
            // 
            this.lblRazlog.AutoSize = true;
            this.lblRazlog.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRazlog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblRazlog.Location = new System.Drawing.Point(658, 105);
            this.lblRazlog.Name = "lblRazlog";
            this.lblRazlog.Size = new System.Drawing.Size(87, 17);
            this.lblRazlog.TabIndex = 23;
            this.lblRazlog.Text = "Device Redtz";
            // 
            // frmRezervacija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1048, 123);
            this.ControlBox = false;
            this.Controls.Add(this.lblRazlog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPlaceno);
            this.Controls.Add(this.lblKorisnik);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnPotvrda);
            this.Controls.Add(this.lblSifra);
            this.Controls.Add(this.lblVrijeme);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.lblStol);
            this.Controls.Add(this.lblCijena);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(1050, 125);
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
        private System.Windows.Forms.Button btnPotvrda;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblKorisnik;
        private System.Windows.Forms.Label lblPlaceno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRazlog;
    }
}