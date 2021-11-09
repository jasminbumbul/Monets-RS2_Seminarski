
namespace Monets.WinUI.Forms.Meni
{
    partial class frmMeni
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMeni));
            this.gbMeni = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNazivMenija = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEdit = new FontAwesome.Sharp.IconButton();
            this.gbMeni.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbMeni
            // 
            this.gbMeni.AutoSize = true;
            this.gbMeni.Controls.Add(this.btnEdit);
            this.gbMeni.Controls.Add(this.panel1);
            this.gbMeni.Controls.Add(this.pictureBox1);
            this.gbMeni.Location = new System.Drawing.Point(12, 12);
            this.gbMeni.Name = "gbMeni";
            this.gbMeni.Size = new System.Drawing.Size(474, 236);
            this.gbMeni.TabIndex = 0;
            this.gbMeni.TabStop = false;
            this.gbMeni.Text = "Meni br x";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(21)))), ((int)(((byte)(65)))));
            this.panel1.Controls.Add(this.lblNazivMenija);
            this.panel1.Location = new System.Drawing.Point(86, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 52);
            this.panel1.TabIndex = 3;
            // 
            // lblNazivMenija
            // 
            this.lblNazivMenija.BackColor = System.Drawing.Color.Transparent;
            this.lblNazivMenija.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNazivMenija.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNazivMenija.Font = new System.Drawing.Font("Corbel", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNazivMenija.ForeColor = System.Drawing.Color.White;
            this.lblNazivMenija.Location = new System.Drawing.Point(0, 0);
            this.lblNazivMenija.Name = "lblNazivMenija";
            this.lblNazivMenija.Size = new System.Drawing.Size(304, 33);
            this.lblNazivMenija.TabIndex = 2;
            this.lblNazivMenija.Text = "Naziv menija";
            this.lblNazivMenija.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, -11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(415, 223);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
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
            this.btnEdit.Location = new System.Drawing.Point(444, 13);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(24, 27);
            this.btnEdit.TabIndex = 17;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmMeni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(484, 682);
            this.ControlBox = false;
            this.Controls.Add(this.gbMeni);
            this.MinimumSize = new System.Drawing.Size(500, 698);
            this.Name = "frmMeni";
            this.Load += new System.EventHandler(this.frmMeni_Load);
            this.gbMeni.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMeni;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNazivMenija;
        private FontAwesome.Sharp.IconButton btnEdit;
    }
}