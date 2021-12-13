
namespace Monets.WinUI.Forms.Klijent
{
    partial class frmKlijenti
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
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.lblPrezime = new System.Windows.Forms.Label();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.cbAktivniKlijenti = new System.Windows.Forms.CheckBox();
            this.lblIme = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.lblStranica = new System.Windows.Forms.Label();
            this.btnSljedeca = new FontAwesome.Sharp.IconButton();
            this.btnPrethodna = new FontAwesome.Sharp.IconButton();
            this.dgvKlijenti = new System.Windows.Forms.DataGridView();
            this.KlijentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KorisničkoIme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumKreiranja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aktivan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Transakcije = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Detalji = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Deaktivacija = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlijenti)).BeginInit();
            this.SuspendLayout();
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconPictureBox2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 22;
            this.iconPictureBox2.Location = new System.Drawing.Point(262, 22);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(22, 23);
            this.iconPictureBox2.TabIndex = 37;
            this.iconPictureBox2.TabStop = false;
            // 
            // lblPrezime
            // 
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPrezime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblPrezime.Location = new System.Drawing.Point(287, 19);
            this.lblPrezime.Margin = new System.Windows.Forms.Padding(0);
            this.lblPrezime.Name = "lblPrezime";
            this.lblPrezime.Size = new System.Drawing.Size(223, 26);
            this.lblPrezime.TabIndex = 36;
            this.lblPrezime.Text = "Pretražite po prezimenu:\r\n";
            this.lblPrezime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtPrezime
            // 
            this.txtPrezime.BackColor = System.Drawing.Color.White;
            this.txtPrezime.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPrezime.Location = new System.Drawing.Point(262, 48);
            this.txtPrezime.Multiline = true;
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.PlaceholderText = "Doe";
            this.txtPrezime.Size = new System.Drawing.Size(248, 30);
            this.txtPrezime.TabIndex = 35;
            this.txtPrezime.TextChanged += new System.EventHandler(this.txtPrezime_TextChanged);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconPictureBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 22;
            this.iconPictureBox1.Location = new System.Drawing.Point(26, 22);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(22, 23);
            this.iconPictureBox1.TabIndex = 34;
            this.iconPictureBox1.TabStop = false;
            // 
            // cbAktivniKlijenti
            // 
            this.cbAktivniKlijenti.AutoSize = true;
            this.cbAktivniKlijenti.Checked = true;
            this.cbAktivniKlijenti.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAktivniKlijenti.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbAktivniKlijenti.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.cbAktivniKlijenti.Location = new System.Drawing.Point(26, 94);
            this.cbAktivniKlijenti.Name = "cbAktivniKlijenti";
            this.cbAktivniKlijenti.Size = new System.Drawing.Size(217, 23);
            this.cbAktivniKlijenti.TabIndex = 33;
            this.cbAktivniKlijenti.Text = "Prikaži samo aktivne klijente";
            this.cbAktivniKlijenti.UseVisualStyleBackColor = true;
            this.cbAktivniKlijenti.CheckedChanged += new System.EventHandler(this.cbAktivniKlijenti_CheckedChanged);
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblIme.Location = new System.Drawing.Point(51, 19);
            this.lblIme.Margin = new System.Windows.Forms.Padding(0);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(186, 26);
            this.lblIme.TabIndex = 31;
            this.lblIme.Text = "Pretražite po imenu:\r\n";
            this.lblIme.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtIme
            // 
            this.txtIme.BackColor = System.Drawing.Color.White;
            this.txtIme.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtIme.Location = new System.Drawing.Point(26, 48);
            this.txtIme.Multiline = true;
            this.txtIme.Name = "txtIme";
            this.txtIme.PlaceholderText = "John";
            this.txtIme.Size = new System.Drawing.Size(205, 30);
            this.txtIme.TabIndex = 30;
            this.txtIme.TextChanged += new System.EventHandler(this.txtIme_TextChanged);
            // 
            // lblStranica
            // 
            this.lblStranica.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStranica.AutoSize = true;
            this.lblStranica.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStranica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblStranica.Location = new System.Drawing.Point(1039, 456);
            this.lblStranica.Margin = new System.Windows.Forms.Padding(0);
            this.lblStranica.Name = "lblStranica";
            this.lblStranica.Size = new System.Drawing.Size(86, 26);
            this.lblStranica.TabIndex = 40;
            this.lblStranica.Text = "Page 2/5";
            this.lblStranica.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSljedeca
            // 
            this.btnSljedeca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSljedeca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.btnSljedeca.FlatAppearance.BorderSize = 0;
            this.btnSljedeca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSljedeca.IconChar = FontAwesome.Sharp.IconChar.ArrowRight;
            this.btnSljedeca.IconColor = System.Drawing.Color.White;
            this.btnSljedeca.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSljedeca.IconSize = 20;
            this.btnSljedeca.Location = new System.Drawing.Point(1139, 458);
            this.btnSljedeca.Name = "btnSljedeca";
            this.btnSljedeca.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.btnSljedeca.Size = new System.Drawing.Size(31, 23);
            this.btnSljedeca.TabIndex = 39;
            this.btnSljedeca.UseVisualStyleBackColor = false;
            // 
            // btnPrethodna
            // 
            this.btnPrethodna.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrethodna.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.btnPrethodna.FlatAppearance.BorderSize = 0;
            this.btnPrethodna.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrethodna.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            this.btnPrethodna.IconColor = System.Drawing.Color.White;
            this.btnPrethodna.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPrethodna.IconSize = 20;
            this.btnPrethodna.Location = new System.Drawing.Point(993, 459);
            this.btnPrethodna.Name = "btnPrethodna";
            this.btnPrethodna.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.btnPrethodna.Size = new System.Drawing.Size(31, 23);
            this.btnPrethodna.TabIndex = 38;
            this.btnPrethodna.UseVisualStyleBackColor = false;
            // 
            // dgvKlijenti
            // 
            this.dgvKlijenti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKlijenti.BackgroundColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Ebrima", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKlijenti.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKlijenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKlijenti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KlijentId,
            this.Ime,
            this.Prezime,
            this.KorisničkoIme,
            this.DatumKreiranja,
            this.Aktivan,
            this.Transakcije,
            this.Detalji,
            this.Deaktivacija});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Ebrima", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKlijenti.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKlijenti.Location = new System.Drawing.Point(26, 134);
            this.dgvKlijenti.Name = "dgvKlijenti";
            this.dgvKlijenti.ReadOnly = true;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Ebrima", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dgvKlijenti.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvKlijenti.RowTemplate.Height = 25;
            this.dgvKlijenti.Size = new System.Drawing.Size(1162, 307);
            this.dgvKlijenti.TabIndex = 41;
            this.dgvKlijenti.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKlijenti_CellContentClick);
            this.dgvKlijenti.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvKlijenti_DataBindingComplete);
            // 
            // KlijentId
            // 
            this.KlijentId.DataPropertyName = "KlijentId";
            this.KlijentId.HeaderText = "ID";
            this.KlijentId.Name = "KlijentId";
            this.KlijentId.ReadOnly = true;
            this.KlijentId.Visible = false;
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
            // DatumKreiranja
            // 
            this.DatumKreiranja.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DatumKreiranja.DataPropertyName = "DatumKreiranja";
            this.DatumKreiranja.HeaderText = "Datum kreiranja";
            this.DatumKreiranja.Name = "DatumKreiranja";
            this.DatumKreiranja.ReadOnly = true;
            // 
            // Aktivan
            // 
            this.Aktivan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Aktivan.DataPropertyName = "Status";
            this.Aktivan.HeaderText = "Aktivan";
            this.Aktivan.Name = "Aktivan";
            this.Aktivan.ReadOnly = true;
            // 
            // Transakcije
            // 
            this.Transakcije.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Transakcije.HeaderText = "Transakcije";
            this.Transakcije.Name = "Transakcije";
            this.Transakcije.ReadOnly = true;
            this.Transakcije.Text = "Transakcije";
            this.Transakcije.ToolTipText = "Transakcije";
            this.Transakcije.UseColumnTextForButtonValue = true;
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
            // frmKlijenti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 500);
            this.Controls.Add(this.dgvKlijenti);
            this.Controls.Add(this.lblStranica);
            this.Controls.Add(this.btnSljedeca);
            this.Controls.Add(this.btnPrethodna);
            this.Controls.Add(this.iconPictureBox2);
            this.Controls.Add(this.lblPrezime);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.cbAktivniKlijenti);
            this.Controls.Add(this.lblIme);
            this.Controls.Add(this.txtIme);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1214, 500);
            this.Name = "frmKlijenti";
            this.Text = "frmKlijenti";
            this.Load += new System.EventHandler(this.frmKlijenti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlijenti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.Label lblPrezime;
        private System.Windows.Forms.TextBox txtPrezime;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.CheckBox cbAktivniKlijenti;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Label lblStranica;
        private FontAwesome.Sharp.IconButton btnSljedeca;
        private FontAwesome.Sharp.IconButton btnPrethodna;
        private System.Windows.Forms.DataGridView dgvKlijenti;
        private System.Windows.Forms.DataGridViewTextBoxColumn KlijentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisničkoIme;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumKreiranja;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Aktivan;
        private System.Windows.Forms.DataGridViewButtonColumn Transakcije;
        private System.Windows.Forms.DataGridViewButtonColumn Detalji;
        private System.Windows.Forms.DataGridViewButtonColumn Deaktivacija;
    }
}