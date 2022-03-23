
namespace Monets.WinUI.Forms.Jelo
{
    partial class frmUpsertJelo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpsertJelo));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblSlika = new System.Windows.Forms.Label();
            this.pbSlika = new System.Windows.Forms.PictureBox();
            this.cmbKategorija = new System.Windows.Forms.ComboBox();
            this.lblKategorija = new System.Windows.Forms.Label();
            this.txtCijena = new System.Windows.Forms.TextBox();
            this.lblCijena = new System.Windows.Forms.Label();
            this.txtVrijemeIzrade = new System.Windows.Forms.TextBox();
            this.lblVrijemeIzrade = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.lblNazivJela = new System.Windows.Forms.Label();
            this.txtNazivJela = new System.Windows.Forms.TextBox();
            this.lblUpsertJela = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtOpisJela = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.Gray;
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.btnBrowse.FlatAppearance.BorderSize = 0;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Corbel", 10.75F, System.Drawing.FontStyle.Bold);
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location = new System.Drawing.Point(78, 17);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(0);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(77, 29);
            this.btnBrowse.TabIndex = 27;
            this.btnBrowse.Text = "Browse ";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblSlika
            // 
            this.lblSlika.AutoSize = true;
            this.lblSlika.Font = new System.Drawing.Font("Corbel", 15.75F);
            this.lblSlika.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblSlika.Location = new System.Drawing.Point(15, 17);
            this.lblSlika.Margin = new System.Windows.Forms.Padding(0);
            this.lblSlika.Name = "lblSlika";
            this.lblSlika.Size = new System.Drawing.Size(54, 26);
            this.lblSlika.TabIndex = 26;
            this.lblSlika.Text = "Slika";
            this.lblSlika.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbSlika
            // 
            this.pbSlika.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            this.pbSlika.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSlika.Location = new System.Drawing.Point(11, 48);
            this.pbSlika.Name = "pbSlika";
            this.pbSlika.Size = new System.Drawing.Size(319, 214);
            this.pbSlika.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSlika.TabIndex = 25;
            this.pbSlika.TabStop = false;
            // 
            // cmbKategorija
            // 
            this.cmbKategorija.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbKategorija.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            this.cmbKategorija.Font = new System.Drawing.Font("Corbel", 14F);
            this.cmbKategorija.FormattingEnabled = true;
            this.cmbKategorija.Location = new System.Drawing.Point(521, 122);
            this.cmbKategorija.Name = "cmbKategorija";
            this.cmbKategorija.Size = new System.Drawing.Size(348, 31);
            this.cmbKategorija.TabIndex = 24;
            // 
            // lblKategorija
            // 
            this.lblKategorija.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKategorija.AutoSize = true;
            this.lblKategorija.Font = new System.Drawing.Font("Corbel", 15.75F);
            this.lblKategorija.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblKategorija.Location = new System.Drawing.Point(521, 86);
            this.lblKategorija.Margin = new System.Windows.Forms.Padding(0);
            this.lblKategorija.Name = "lblKategorija";
            this.lblKategorija.Size = new System.Drawing.Size(101, 26);
            this.lblKategorija.TabIndex = 23;
            this.lblKategorija.Text = "Kategorija";
            // 
            // txtCijena
            // 
            this.txtCijena.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCijena.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            this.txtCijena.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCijena.Location = new System.Drawing.Point(525, 48);
            this.txtCijena.Multiline = true;
            this.txtCijena.Name = "txtCijena";
            this.txtCijena.Size = new System.Drawing.Size(348, 27);
            this.txtCijena.TabIndex = 22;
            // 
            // lblCijena
            // 
            this.lblCijena.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCijena.AutoSize = true;
            this.lblCijena.Font = new System.Drawing.Font("Corbel", 15.75F);
            this.lblCijena.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblCijena.Location = new System.Drawing.Point(585, 65);
            this.lblCijena.Margin = new System.Windows.Forms.Padding(0);
            this.lblCijena.Name = "lblCijena";
            this.lblCijena.Size = new System.Drawing.Size(160, 26);
            this.lblCijena.TabIndex = 21;
            this.lblCijena.Text = "Cijena jela (u KM)";
            // 
            // txtVrijemeIzrade
            // 
            this.txtVrijemeIzrade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            this.txtVrijemeIzrade.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtVrijemeIzrade.Location = new System.Drawing.Point(12, 122);
            this.txtVrijemeIzrade.Multiline = true;
            this.txtVrijemeIzrade.Name = "txtVrijemeIzrade";
            this.txtVrijemeIzrade.Size = new System.Drawing.Size(348, 27);
            this.txtVrijemeIzrade.TabIndex = 20;
            // 
            // lblVrijemeIzrade
            // 
            this.lblVrijemeIzrade.AutoSize = true;
            this.lblVrijemeIzrade.Font = new System.Drawing.Font("Corbel", 15.75F);
            this.lblVrijemeIzrade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblVrijemeIzrade.Location = new System.Drawing.Point(12, 86);
            this.lblVrijemeIzrade.Margin = new System.Windows.Forms.Padding(0);
            this.lblVrijemeIzrade.Name = "lblVrijemeIzrade";
            this.lblVrijemeIzrade.Size = new System.Drawing.Size(204, 26);
            this.lblVrijemeIzrade.TabIndex = 19;
            this.lblVrijemeIzrade.Text = "Vrijeme izrade (u min.)";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(766, 537);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(167, 45);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Dodaj jelo";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pbLoading
            // 
            this.pbLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLoading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbLoading.Image = ((System.Drawing.Image)(resources.GetObject("pbLoading.Image")));
            this.pbLoading.Location = new System.Drawing.Point(556, 333);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(399, 201);
            this.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLoading.TabIndex = 15;
            this.pbLoading.TabStop = false;
            // 
            // lblNazivJela
            // 
            this.lblNazivJela.AutoSize = true;
            this.lblNazivJela.Font = new System.Drawing.Font("Corbel", 15.75F);
            this.lblNazivJela.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblNazivJela.Location = new System.Drawing.Point(76, 65);
            this.lblNazivJela.Margin = new System.Windows.Forms.Padding(0);
            this.lblNazivJela.Name = "lblNazivJela";
            this.lblNazivJela.Size = new System.Drawing.Size(95, 26);
            this.lblNazivJela.TabIndex = 18;
            this.lblNazivJela.Text = "Naziv jela";
            this.lblNazivJela.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtNazivJela
            // 
            this.txtNazivJela.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            this.txtNazivJela.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNazivJela.Location = new System.Drawing.Point(16, 48);
            this.txtNazivJela.Multiline = true;
            this.txtNazivJela.Name = "txtNazivJela";
            this.txtNazivJela.Size = new System.Drawing.Size(348, 27);
            this.txtNazivJela.TabIndex = 17;
            // 
            // lblUpsertJela
            // 
            this.lblUpsertJela.Font = new System.Drawing.Font("Corbel", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lblUpsertJela.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblUpsertJela.Location = new System.Drawing.Point(65, 0);
            this.lblUpsertJela.Name = "lblUpsertJela";
            this.lblUpsertJela.Size = new System.Drawing.Size(255, 43);
            this.lblUpsertJela.TabIndex = 16;
            this.lblUpsertJela.Text = "Dodaj novo jelo";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cmbKategorija);
            this.groupBox1.Controls.Add(this.txtOpisJela);
            this.groupBox1.Controls.Add(this.lblKategorija);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCijena);
            this.groupBox1.Controls.Add(this.txtVrijemeIzrade);
            this.groupBox1.Controls.Add(this.lblVrijemeIzrade);
            this.groupBox1.Controls.Add(this.txtNazivJela);
            this.groupBox1.Location = new System.Drawing.Point(65, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(889, 236);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unesite informacije o jelu";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBrowse);
            this.groupBox2.Controls.Add(this.lblSlika);
            this.groupBox2.Controls.Add(this.pbSlika);
            this.groupBox2.Location = new System.Drawing.Point(66, 298);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(358, 284);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Odaberite sliku";
            // 
            // txtOpisJela
            // 
            this.txtOpisJela.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            this.txtOpisJela.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtOpisJela.Location = new System.Drawing.Point(12, 203);
            this.txtOpisJela.Multiline = true;
            this.txtOpisJela.Name = "txtOpisJela";
            this.txtOpisJela.Size = new System.Drawing.Size(348, 27);
            this.txtOpisJela.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 15.75F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.label1.Location = new System.Drawing.Point(12, 167);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 26);
            this.label1.TabIndex = 30;
            this.label1.Text = "Opis jela";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // frmUpsertJelo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 591);
            this.ControlBox = false;
            this.Controls.Add(this.lblCijena);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pbLoading);
            this.Controls.Add(this.lblNazivJela);
            this.Controls.Add(this.lblUpsertJela);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.MaximumSize = new System.Drawing.Size(1043, 607);
            this.MinimumSize = new System.Drawing.Size(1043, 607);
            this.Name = "frmUpsertJelo";
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblSlika;
        private System.Windows.Forms.PictureBox pbSlika;
        private System.Windows.Forms.ComboBox cmbKategorija;
        private System.Windows.Forms.Label lblKategorija;
        private System.Windows.Forms.TextBox txtCijena;
        private System.Windows.Forms.Label lblCijena;
        private System.Windows.Forms.TextBox txtVrijemeIzrade;
        private System.Windows.Forms.Label lblVrijemeIzrade;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox pbLoading;
        private System.Windows.Forms.Label lblNazivJela;
        private System.Windows.Forms.TextBox txtNazivJela;
        private System.Windows.Forms.Label lblUpsertJela;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtOpisJela;
        private System.Windows.Forms.Label label1;
    }
}