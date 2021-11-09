
namespace Monets.WinUI.Forms.Meni
{
    partial class frmUpsertMeni
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpsertMeni));
            this.txtCijena = new System.Windows.Forms.TextBox();
            this.lblCijena = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.lblNazivMenija = new System.Windows.Forms.Label();
            this.txtNazivMenija = new System.Windows.Forms.TextBox();
            this.lblUpsertMenija = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbJela = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCijena
            // 
            this.txtCijena.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCijena.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            this.txtCijena.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCijena.Location = new System.Drawing.Point(680, 113);
            this.txtCijena.Multiline = true;
            this.txtCijena.Name = "txtCijena";
            this.txtCijena.Size = new System.Drawing.Size(405, 30);
            this.txtCijena.TabIndex = 38;
            // 
            // lblCijena
            // 
            this.lblCijena.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCijena.AutoSize = true;
            this.lblCijena.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCijena.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblCijena.Location = new System.Drawing.Point(680, 84);
            this.lblCijena.Margin = new System.Windows.Forms.Padding(0);
            this.lblCijena.Name = "lblCijena";
            this.lblCijena.Size = new System.Drawing.Size(188, 26);
            this.lblCijena.TabIndex = 37;
            this.lblCijena.Text = "Cijena menija (u KM)";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(816, 489);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(195, 52);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "Dodaj meni";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pbLoading
            // 
            this.pbLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLoading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbLoading.Image = ((System.Drawing.Image)(resources.GetObject("pbLoading.Image")));
            this.pbLoading.Location = new System.Drawing.Point(548, 238);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(463, 227);
            this.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLoading.TabIndex = 31;
            this.pbLoading.TabStop = false;
            // 
            // lblNazivMenija
            // 
            this.lblNazivMenija.AutoSize = true;
            this.lblNazivMenija.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNazivMenija.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblNazivMenija.Location = new System.Drawing.Point(87, 84);
            this.lblNazivMenija.Margin = new System.Windows.Forms.Padding(0);
            this.lblNazivMenija.Name = "lblNazivMenija";
            this.lblNazivMenija.Size = new System.Drawing.Size(123, 26);
            this.lblNazivMenija.TabIndex = 34;
            this.lblNazivMenija.Text = "Naziv menija";
            this.lblNazivMenija.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtNazivMenija
            // 
            this.txtNazivMenija.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            this.txtNazivMenija.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNazivMenija.Location = new System.Drawing.Point(87, 113);
            this.txtNazivMenija.Multiline = true;
            this.txtNazivMenija.Name = "txtNazivMenija";
            this.txtNazivMenija.Size = new System.Drawing.Size(405, 30);
            this.txtNazivMenija.TabIndex = 33;
            // 
            // lblUpsertMenija
            // 
            this.lblUpsertMenija.Font = new System.Drawing.Font("Corbel", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lblUpsertMenija.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lblUpsertMenija.Location = new System.Drawing.Point(74, 9);
            this.lblUpsertMenija.Name = "lblUpsertMenija";
            this.lblUpsertMenija.Size = new System.Drawing.Size(228, 36);
            this.lblUpsertMenija.TabIndex = 32;
            this.lblUpsertMenija.Text = "Dodaj novi meni";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbJela);
            this.groupBox1.Controls.Add(this.pbLoading);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Location = new System.Drawing.Point(74, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1037, 571);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unesite informacije o meniju";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.label1.Location = new System.Drawing.Point(13, 103);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 26);
            this.label1.TabIndex = 42;
            this.label1.Text = "Jela";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbJela
            // 
            this.lbJela.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            this.lbJela.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbJela.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(2)))), ((int)(((byte)(82)))));
            this.lbJela.FormattingEnabled = true;
            this.lbJela.ItemHeight = 19;
            this.lbJela.Location = new System.Drawing.Point(13, 132);
            this.lbJela.Name = "lbJela";
            this.lbJela.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbJela.Size = new System.Drawing.Size(405, 403);
            this.lbJela.TabIndex = 0;
            // 
            // frmUpsertMeni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 682);
            this.ControlBox = false;
            this.Controls.Add(this.txtCijena);
            this.Controls.Add(this.lblCijena);
            this.Controls.Add(this.lblNazivMenija);
            this.Controls.Add(this.txtNazivMenija);
            this.Controls.Add(this.lblUpsertMenija);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(1214, 698);
            this.MinimumSize = new System.Drawing.Size(1214, 698);
            this.Name = "frmUpsertMeni";
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtCijena;
        private System.Windows.Forms.Label lblCijena;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox pbLoading;
        private System.Windows.Forms.Label lblNazivMenija;
        private System.Windows.Forms.TextBox txtNazivMenija;
        private System.Windows.Forms.Label lblUpsertMenija;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbJela;
    }
}