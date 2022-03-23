namespace Monets.WinUI.Forms.Transakcija
{
    partial class frmTransakcije
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblStranica = new System.Windows.Forms.Label();
            this.btnSljedeca = new FontAwesome.Sharp.IconButton();
            this.btnPrethodna = new FontAwesome.Sharp.IconButton();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.dgvTransakcije = new System.Windows.Forms.DataGridView();
            this.TransakcijaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sifra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RezervacijaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KorisnikId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iznos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblIme = new System.Windows.Forms.Label();
            this.txtSifra = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransakcije)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStranica
            // 
            this.lblStranica.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStranica.AutoSize = true;
            this.lblStranica.Font = new System.Drawing.Font("Corbel", 15.75F);
            this.lblStranica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblStranica.Location = new System.Drawing.Point(881, 422);
            this.lblStranica.Margin = new System.Windows.Forms.Padding(0);
            this.lblStranica.Name = "lblStranica";
            this.lblStranica.Size = new System.Drawing.Size(86, 26);
            this.lblStranica.TabIndex = 40;
            this.lblStranica.Text = "Page 2/5";
            this.lblStranica.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSljedeca
            // 
            this.btnSljedeca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSljedeca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.btnSljedeca.FlatAppearance.BorderSize = 0;
            this.btnSljedeca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSljedeca.IconChar = FontAwesome.Sharp.IconChar.ArrowRight;
            this.btnSljedeca.IconColor = System.Drawing.Color.White;
            this.btnSljedeca.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSljedeca.IconSize = 20;
            this.btnSljedeca.Location = new System.Drawing.Point(970, 426);
            this.btnSljedeca.MaximumSize = new System.Drawing.Size(21, 22);
            this.btnSljedeca.MinimumSize = new System.Drawing.Size(21, 22);
            this.btnSljedeca.Name = "btnSljedeca";
            this.btnSljedeca.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.btnSljedeca.Size = new System.Drawing.Size(21, 22);
            this.btnSljedeca.TabIndex = 39;
            this.btnSljedeca.UseVisualStyleBackColor = false;
            this.btnSljedeca.Click += new System.EventHandler(this.btnSljedeca_Click_1);
            // 
            // btnPrethodna
            // 
            this.btnPrethodna.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrethodna.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.btnPrethodna.FlatAppearance.BorderSize = 0;
            this.btnPrethodna.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrethodna.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            this.btnPrethodna.IconColor = System.Drawing.Color.White;
            this.btnPrethodna.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPrethodna.IconSize = 20;
            this.btnPrethodna.Location = new System.Drawing.Point(857, 426);
            this.btnPrethodna.MaximumSize = new System.Drawing.Size(21, 22);
            this.btnPrethodna.MinimumSize = new System.Drawing.Size(21, 22);
            this.btnPrethodna.Name = "btnPrethodna";
            this.btnPrethodna.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.btnPrethodna.Size = new System.Drawing.Size(21, 22);
            this.btnPrethodna.TabIndex = 38;
            this.btnPrethodna.UseVisualStyleBackColor = false;
            this.btnPrethodna.Click += new System.EventHandler(this.btnPrethodna_Click_1);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconPictureBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 19;
            this.iconPictureBox1.Location = new System.Drawing.Point(23, 21);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(19, 20);
            this.iconPictureBox1.TabIndex = 34;
            this.iconPictureBox1.TabStop = false;
            // 
            // dgvTransakcije
            // 
            this.dgvTransakcije.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransakcije.BackgroundColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Ebrima", 12.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransakcije.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTransakcije.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransakcije.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TransakcijaId,
            this.Sifra,
            this.RezervacijaId,
            this.KorisnikId,
            this.Iznos,
            this.Datum});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Ebrima", 12.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTransakcije.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTransakcije.Location = new System.Drawing.Point(23, 123);
            this.dgvTransakcije.Name = "dgvTransakcije";
            this.dgvTransakcije.ReadOnly = true;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Ebrima", 12.75F);
            this.dgvTransakcije.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTransakcije.RowTemplate.Height = 25;
            this.dgvTransakcije.Size = new System.Drawing.Size(985, 266);
            this.dgvTransakcije.TabIndex = 32;
            // 
            // TransakcijaId
            // 
            this.TransakcijaId.DataPropertyName = "TransakcijaId";
            this.TransakcijaId.HeaderText = "TransakcijaId";
            this.TransakcijaId.Name = "TransakcijaId";
            this.TransakcijaId.ReadOnly = true;
            this.TransakcijaId.Visible = false;
            // 
            // Sifra
            // 
            this.Sifra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Sifra.DataPropertyName = "Sifra";
            this.Sifra.HeaderText = "Šifra";
            this.Sifra.Name = "Sifra";
            this.Sifra.ReadOnly = true;
            // 
            // RezervacijaId
            // 
            this.RezervacijaId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RezervacijaId.DataPropertyName = "RezervacijaId";
            this.RezervacijaId.HeaderText = "RezervacijaId";
            this.RezervacijaId.Name = "RezervacijaId";
            this.RezervacijaId.ReadOnly = true;
            // 
            // KorisnikId
            // 
            this.KorisnikId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.KorisnikId.DataPropertyName = "KorisnikId";
            this.KorisnikId.HeaderText = "KorisnikId";
            this.KorisnikId.Name = "KorisnikId";
            this.KorisnikId.ReadOnly = true;
            // 
            // Iznos
            // 
            this.Iznos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Iznos.DataPropertyName = "Iznos";
            this.Iznos.HeaderText = "Iznos";
            this.Iznos.Name = "Iznos";
            this.Iznos.ReadOnly = true;
            // 
            // Datum
            // 
            this.Datum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Datum.DataPropertyName = "Datum";
            this.Datum.HeaderText = "Datum";
            this.Datum.Name = "Datum";
            this.Datum.ReadOnly = true;
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Font = new System.Drawing.Font("Corbel", 15.75F);
            this.lblIme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblIme.Location = new System.Drawing.Point(45, 18);
            this.lblIme.Margin = new System.Windows.Forms.Padding(0);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(164, 26);
            this.lblIme.TabIndex = 31;
            this.lblIme.Text = "Pretražite po šifri:";
            this.lblIme.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtSifra
            // 
            this.txtSifra.BackColor = System.Drawing.Color.White;
            this.txtSifra.Font = new System.Drawing.Font("Corbel", 12F);
            this.txtSifra.Location = new System.Drawing.Point(23, 47);
            this.txtSifra.Multiline = true;
            this.txtSifra.Name = "txtSifra";
            this.txtSifra.Size = new System.Drawing.Size(176, 27);
            this.txtSifra.TabIndex = 30;
            this.txtSifra.TextChanged += new System.EventHandler(this.txtIme_TextChanged);
            // 
            // frmTransakcije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 605);
            this.Controls.Add(this.lblStranica);
            this.Controls.Add(this.btnSljedeca);
            this.Controls.Add(this.btnPrethodna);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.dgvTransakcije);
            this.Controls.Add(this.lblIme);
            this.Controls.Add(this.txtSifra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1041, 605);
            this.MinimumSize = new System.Drawing.Size(1041, 605);
            this.Name = "frmTransakcije";
            this.Text = "frmTransakcije";
            this.Load += new System.EventHandler(this.frmTransakcije_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransakcije)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStranica;
        private FontAwesome.Sharp.IconButton btnSljedeca;
        private FontAwesome.Sharp.IconButton btnPrethodna;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.DataGridView dgvTransakcije;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.TextBox txtSifra;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransakcijaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sifra;
        private System.Windows.Forms.DataGridViewTextBoxColumn RezervacijaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnikId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iznos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
    }
}