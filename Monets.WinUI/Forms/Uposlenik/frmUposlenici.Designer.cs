
namespace Monets.WinUI.Forms.Uposlenik
{
    partial class frmUposlenici
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
            this.lblIme = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.dgvUposlenici = new System.Windows.Forms.DataGridView();
            this.UposlenikId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KorisničkoIme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumZaposlenja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aktivan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Detalji = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Deaktivacija = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cbAktivniUposlenici = new System.Windows.Forms.CheckBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.lblPrezime = new System.Windows.Forms.Label();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.btnPrethodna = new FontAwesome.Sharp.IconButton();
            this.btnSljedeca = new FontAwesome.Sharp.IconButton();
            this.lblStranica = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUposlenici)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Font = new System.Drawing.Font("Corbel", 15.75F);
            this.lblIme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblIme.Location = new System.Drawing.Point(42, 12);
            this.lblIme.Margin = new System.Windows.Forms.Padding(0);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(186, 26);
            this.lblIme.TabIndex = 20;
            this.lblIme.Text = "Pretražite po imenu:\r\n";
            this.lblIme.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtIme
            // 
            this.txtIme.BackColor = System.Drawing.Color.White;
            this.txtIme.Font = new System.Drawing.Font("Corbel", 12F);
            this.txtIme.Location = new System.Drawing.Point(21, 44);
            this.txtIme.Multiline = true;
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(176, 27);
            this.txtIme.TabIndex = 19;
            this.txtIme.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dgvUposlenici
            // 
            this.dgvUposlenici.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUposlenici.BackgroundColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Ebrima", 12.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUposlenici.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUposlenici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUposlenici.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UposlenikId,
            this.Ime,
            this.Prezime,
            this.KorisničkoIme,
            this.DatumZaposlenja,
            this.Aktivan,
            this.Detalji,
            this.Deaktivacija});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Ebrima", 12.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUposlenici.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUposlenici.Location = new System.Drawing.Point(21, 116);
            this.dgvUposlenici.Name = "dgvUposlenici";
            this.dgvUposlenici.ReadOnly = true;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Ebrima", 12.75F);
            this.dgvUposlenici.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUposlenici.RowTemplate.Height = 25;
            this.dgvUposlenici.Size = new System.Drawing.Size(996, 266);
            this.dgvUposlenici.TabIndex = 21;
            this.dgvUposlenici.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUposlenici_CellClick);
            this.dgvUposlenici.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUposlenici_CellContentClick);
            this.dgvUposlenici.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvUposlenici_DataBindingComplete);
            // 
            // UposlenikId
            // 
            this.UposlenikId.DataPropertyName = "UposlenikId";
            this.UposlenikId.HeaderText = "ID";
            this.UposlenikId.Name = "UposlenikId";
            this.UposlenikId.ReadOnly = true;
            this.UposlenikId.Visible = false;
            // 
            // Ime
            // 
            this.Ime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ime.DataPropertyName = "Ime";
            this.Ime.HeaderText = "Ime";
            this.Ime.Name = "Ime";
            this.Ime.ReadOnly = true;
            // 
            // Prezime
            // 
            this.Prezime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Prezime.DataPropertyName = "Prezime";
            this.Prezime.HeaderText = "Prezime";
            this.Prezime.Name = "Prezime";
            this.Prezime.ReadOnly = true;
            // 
            // KorisničkoIme
            // 
            this.KorisničkoIme.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.KorisničkoIme.DataPropertyName = "KorisnickoIme";
            this.KorisničkoIme.HeaderText = "Korisničko ime";
            this.KorisničkoIme.Name = "KorisničkoIme";
            this.KorisničkoIme.ReadOnly = true;
            // 
            // DatumZaposlenja
            // 
            this.DatumZaposlenja.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DatumZaposlenja.DataPropertyName = "DatumZaposlenja";
            this.DatumZaposlenja.HeaderText = "Datum zaposlenja";
            this.DatumZaposlenja.Name = "DatumZaposlenja";
            this.DatumZaposlenja.ReadOnly = true;
            // 
            // Aktivan
            // 
            this.Aktivan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Aktivan.DataPropertyName = "Status";
            this.Aktivan.HeaderText = "Aktivan";
            this.Aktivan.Name = "Aktivan";
            this.Aktivan.ReadOnly = true;
            // 
            // Detalji
            // 
            this.Detalji.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Detalji.HeaderText = "Detalji";
            this.Detalji.Name = "Detalji";
            this.Detalji.ReadOnly = true;
            this.Detalji.Text = "Prikaz detalja";
            this.Detalji.ToolTipText = "Prikaz detalja";
            this.Detalji.UseColumnTextForButtonValue = true;
            // 
            // Deaktivacija
            // 
            this.Deaktivacija.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Deaktivacija.HeaderText = "Deaktivacija";
            this.Deaktivacija.Name = "Deaktivacija";
            this.Deaktivacija.ReadOnly = true;
            this.Deaktivacija.Text = "Deaktivacija";
            this.Deaktivacija.ToolTipText = "Deaktivacija";
            this.Deaktivacija.UseColumnTextForButtonValue = true;
            // 
            // cbAktivniUposlenici
            // 
            this.cbAktivniUposlenici.AutoSize = true;
            this.cbAktivniUposlenici.Checked = true;
            this.cbAktivniUposlenici.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAktivniUposlenici.Font = new System.Drawing.Font("Corbel", 12F);
            this.cbAktivniUposlenici.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.cbAktivniUposlenici.Location = new System.Drawing.Point(21, 77);
            this.cbAktivniUposlenici.Name = "cbAktivniUposlenici";
            this.cbAktivniUposlenici.Size = new System.Drawing.Size(239, 23);
            this.cbAktivniUposlenici.TabIndex = 22;
            this.cbAktivniUposlenici.Text = "Prikaži samo aktivne uposlenike";
            this.cbAktivniUposlenici.UseVisualStyleBackColor = true;
            this.cbAktivniUposlenici.CheckedChanged += new System.EventHandler(this.cbAktivniUposlenici_CheckedChanged);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconPictureBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 19;
            this.iconPictureBox1.Location = new System.Drawing.Point(21, 15);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(19, 20);
            this.iconPictureBox1.TabIndex = 23;
            this.iconPictureBox1.TabStop = false;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconPictureBox2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 19;
            this.iconPictureBox2.Location = new System.Drawing.Point(223, 15);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(19, 20);
            this.iconPictureBox2.TabIndex = 26;
            this.iconPictureBox2.TabStop = false;
            // 
            // lblPrezime
            // 
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.Font = new System.Drawing.Font("Corbel", 15.75F);
            this.lblPrezime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblPrezime.Location = new System.Drawing.Point(244, 12);
            this.lblPrezime.Margin = new System.Windows.Forms.Padding(0);
            this.lblPrezime.Name = "lblPrezime";
            this.lblPrezime.Size = new System.Drawing.Size(223, 26);
            this.lblPrezime.TabIndex = 25;
            this.lblPrezime.Text = "Pretražite po prezimenu:\r\n";
            this.lblPrezime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtPrezime
            // 
            this.txtPrezime.BackColor = System.Drawing.Color.White;
            this.txtPrezime.Font = new System.Drawing.Font("Corbel", 12F);
            this.txtPrezime.Location = new System.Drawing.Point(223, 44);
            this.txtPrezime.Multiline = true;
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(213, 27);
            this.txtPrezime.TabIndex = 24;
            this.txtPrezime.TextChanged += new System.EventHandler(this.txtPrezime_TextChanged);
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
            this.btnPrethodna.Location = new System.Drawing.Point(856, 397);
            this.btnPrethodna.Name = "btnPrethodna";
            this.btnPrethodna.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.btnPrethodna.Size = new System.Drawing.Size(27, 20);
            this.btnPrethodna.TabIndex = 27;
            this.btnPrethodna.UseVisualStyleBackColor = false;
            this.btnPrethodna.Click += new System.EventHandler(this.btnPrethodna_Click);
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
            this.btnSljedeca.Location = new System.Drawing.Point(981, 396);
            this.btnSljedeca.Name = "btnSljedeca";
            this.btnSljedeca.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.btnSljedeca.Size = new System.Drawing.Size(27, 20);
            this.btnSljedeca.TabIndex = 28;
            this.btnSljedeca.UseVisualStyleBackColor = false;
            this.btnSljedeca.Click += new System.EventHandler(this.btnSljedeca_Click);
            // 
            // lblStranica
            // 
            this.lblStranica.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStranica.AutoSize = true;
            this.lblStranica.Font = new System.Drawing.Font("Corbel", 15.75F);
            this.lblStranica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblStranica.Location = new System.Drawing.Point(896, 394);
            this.lblStranica.Margin = new System.Windows.Forms.Padding(0);
            this.lblStranica.Name = "lblStranica";
            this.lblStranica.Size = new System.Drawing.Size(86, 26);
            this.lblStranica.TabIndex = 29;
            this.lblStranica.Text = "Page 2/5";
            this.lblStranica.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmUposlenici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 605);
            this.Controls.Add(this.lblStranica);
            this.Controls.Add(this.btnSljedeca);
            this.Controls.Add(this.btnPrethodna);
            this.Controls.Add(this.iconPictureBox2);
            this.Controls.Add(this.lblPrezime);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.cbAktivniUposlenici);
            this.Controls.Add(this.dgvUposlenici);
            this.Controls.Add(this.lblIme);
            this.Controls.Add(this.txtIme);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1041, 605);
            this.MinimumSize = new System.Drawing.Size(1041, 605);
            this.Name = "frmUposlenici";
            this.Text = "frmKorisnici";
            this.Load += new System.EventHandler(this.frmUposlenici_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUposlenici)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.DataGridView dgvUposlenici;
        private System.Windows.Forms.CheckBox cbAktivniUposlenici;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.Label lblPrezime;
        private System.Windows.Forms.TextBox txtPrezime;
        private FontAwesome.Sharp.IconButton btnPrethodna;
        private FontAwesome.Sharp.IconButton btnSljedeca;
        private System.Windows.Forms.Label lblStranica;
        private System.Windows.Forms.DataGridViewTextBoxColumn UposlenikId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisničkoIme;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumZaposlenja;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Aktivan;
        private System.Windows.Forms.DataGridViewButtonColumn Detalji;
        private System.Windows.Forms.DataGridViewButtonColumn Deaktivacija;
    }
}