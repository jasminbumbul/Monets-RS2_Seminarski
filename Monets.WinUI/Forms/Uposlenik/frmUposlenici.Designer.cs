
namespace Monets.WinUI.Forms.Korisnik
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
            this.lblIme = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.dgvUposlenici = new System.Windows.Forms.DataGridView();
            this.cbAktivniUposlenici = new System.Windows.Forms.CheckBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.lblPrezime = new System.Windows.Forms.Label();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.UposlenikId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KorisničkoIme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumZaposlenja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aktivan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Detalji = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Brisanje = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUposlenici)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblIme.Location = new System.Drawing.Point(49, 14);
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
            this.txtIme.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtIme.Location = new System.Drawing.Point(24, 43);
            this.txtIme.Multiline = true;
            this.txtIme.Name = "txtIme";
            this.txtIme.PlaceholderText = "John";
            this.txtIme.Size = new System.Drawing.Size(205, 30);
            this.txtIme.TabIndex = 19;
            this.txtIme.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dgvUposlenici
            // 
            this.dgvUposlenici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUposlenici.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UposlenikId,
            this.Ime,
            this.Prezime,
            this.KorisničkoIme,
            this.DatumZaposlenja,
            this.Aktivan,
            this.Detalji,
            this.Brisanje});
            this.dgvUposlenici.Location = new System.Drawing.Point(24, 134);
            this.dgvUposlenici.Name = "dgvUposlenici";
            this.dgvUposlenici.ReadOnly = true;
            this.dgvUposlenici.RowTemplate.Height = 25;
            this.dgvUposlenici.Size = new System.Drawing.Size(1162, 486);
            this.dgvUposlenici.TabIndex = 21;
            this.dgvUposlenici.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUposlenici_CellClick);
            this.dgvUposlenici.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUposlenici_CellContentClick);
            // 
            // cbAktivniUposlenici
            // 
            this.cbAktivniUposlenici.AutoSize = true;
            this.cbAktivniUposlenici.Checked = true;
            this.cbAktivniUposlenici.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAktivniUposlenici.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbAktivniUposlenici.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.cbAktivniUposlenici.Location = new System.Drawing.Point(24, 89);
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
            this.iconPictureBox1.IconSize = 22;
            this.iconPictureBox1.Location = new System.Drawing.Point(24, 17);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(22, 23);
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
            this.iconPictureBox2.IconSize = 22;
            this.iconPictureBox2.Location = new System.Drawing.Point(260, 17);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(22, 23);
            this.iconPictureBox2.TabIndex = 26;
            this.iconPictureBox2.TabStop = false;
            // 
            // lblPrezime
            // 
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPrezime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblPrezime.Location = new System.Drawing.Point(285, 14);
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
            this.txtPrezime.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPrezime.Location = new System.Drawing.Point(260, 43);
            this.txtPrezime.Multiline = true;
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.PlaceholderText = "Doe";
            this.txtPrezime.Size = new System.Drawing.Size(248, 30);
            this.txtPrezime.TabIndex = 24;
            this.txtPrezime.TextChanged += new System.EventHandler(this.txtPrezime_TextChanged);
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
            // Brisanje
            // 
            this.Brisanje.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Brisanje.HeaderText = "Brisanje";
            this.Brisanje.Name = "Brisanje";
            this.Brisanje.ReadOnly = true;
            this.Brisanje.Text = "Obriši";
            this.Brisanje.ToolTipText = "Obriši";
            this.Brisanje.UseColumnTextForButtonValue = true;
            // 
            // frmUposlenici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 698);
            this.Controls.Add(this.iconPictureBox2);
            this.Controls.Add(this.lblPrezime);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.cbAktivniUposlenici);
            this.Controls.Add(this.dgvUposlenici);
            this.Controls.Add(this.lblIme);
            this.Controls.Add(this.txtIme);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1214, 698);
            this.MinimumSize = new System.Drawing.Size(1214, 698);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn UposlenikId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisničkoIme;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumZaposlenja;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Aktivan;
        private System.Windows.Forms.DataGridViewButtonColumn Detalji;
        private System.Windows.Forms.DataGridViewButtonColumn Brisanje;
    }
}