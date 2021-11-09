﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Monets.WinUI.Forms.Jelo;
using Monets.WinUI.Forms.Korisnik;
using Monets.WinUI.Forms.Meni;
using Monets.WinUI.Forms.Rezervacija;
using Monets.WinUI.Forms.Uposlenik;
using Monets.WinUI.Services;

namespace Monets.WinUI.Forms.Static
{
    public partial class frmMain : Form, IMessageFilter
    {
        #region moveable window 
        //pošto sam koristio posebni dizajn koji podrazumijeva brisanje defaultnog title bara, potreban je kod za premještanje prozora
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int WM_LBUTTONDOWN = 0x0201;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private HashSet<Control> controlsToMove = new HashSet<Control>();

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN &&
                 controlsToMove.Contains(Control.FromHandle(m.HWnd)))
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                return true;
            }
            return false;
        }

        #endregion

        List<Panel> listaPanela = new List<Panel>();
        private APIService jeloService = new APIService("Jelo");
        private APIService meniService = new APIService("Meni");
        private APIService rezervacijaService = new APIService("Rezervacija");
        public static frmMain INSTANCE;

        public frmMain()
        {
            InitializeComponent();
            CustomizeDesign();
            Application.AddMessageFilter(this);

            //Stavke koje se dodaju, biti će korištene za premještanje prozora
            controlsToMove.Add(this);
            controlsToMove.Add(lblTitle);
            controlsToMove.Add(panelLogo);

            pbLoading.Visible = false;

            INSTANCE = this;
        }
        #region region vezan za kod oko menija, submenija i kontrola za manipulaciju velicinom prozora
        private void CustomizeDesign()
        {
            panelJelaSubmenu.Visible = false;
            panelMeniSubmenu.Visible = false;
            panelUposleniciSubmenu.Visible = false;
            panelIzvjestajiSubmenu.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelJelaSubmenu.Visible == true)
                panelJelaSubmenu.Visible = false;
            if (panelMeniSubmenu.Visible == true)
                panelMeniSubmenu.Visible = false;
            if (panelUposleniciSubmenu.Visible == true)
                panelUposleniciSubmenu.Visible = false;
            if (panelIzvjestajiSubmenu.Visible == true)
                panelIzvjestajiSubmenu.Visible = false;
        }

        private void showSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubMenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }

        private void btnJela_Click(object sender, EventArgs e)
        {
            showSubmenu(panelJelaSubmenu);
        }

        private void btnMeni_Click(object sender, EventArgs e)
        {
            showSubmenu(panelMeniSubmenu);
        }

        private void btnUposlenici_Click(object sender, EventArgs e)
        {
            showSubmenu(panelUposleniciSubmenu);
        }

        private void btnIzvještaj_Click(object sender, EventArgs e)
        {
            showSubmenu(panelIzvjestajiSubmenu);
        }



        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        private List<Form> listOfActiveForms = new List<Form>();
        public void openChildForm(Form childForm, Panel panel = null)
        {
            listOfActiveForms.Add(childForm);
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            if (panel != null)
            {
                panel.Controls.Add(childForm);
                panel.Tag = childForm;
            }
            else
            {
                mainPanel.Controls.Add(childForm);
                mainPanel.Tag = childForm;
            }
            childForm.BringToFront();
            childForm.Show();
        }

        private void clearMainPanel()
        {
            if(listOfActiveForms.Count>0)
            {
                foreach (var item in listOfActiveForms)
                {
                    item.Close();
                }
            }
        }

        public async void btnPregledJela_Click(object sender = null, EventArgs e = null)
        {
            lblNazivStranice.Text = "Jela";
            btnJela.Enabled = false;
            pbLoading.Visible = true;
            try
            {
                clearMainPanel();
                var listaJela = await jeloService.Get<List<Model.Jelo>>(null);
                foreach (var jelo in listaJela)
                {
                    var noviPanel = new Panel();
                    if (listaPanela.Count == 0)
                        noviPanel.Location = new Point(34, 0);
                    else
                    {
                        if (listaPanela.Count % 3 == 0)
                        {
                            noviPanel.Location = new Point(listaPanela[listaPanela.Count - 1].Location.X - 808, listaPanela[listaPanela.Count - 1].Location.Y + 220);
                            noviPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                        }
                        else
                        {
                            noviPanel.Location = new Point(listaPanela[listaPanela.Count - 1].Location.X + 404, listaPanela[listaPanela.Count - 1].Location.Y);
                            if (listaPanela.Count % 3 == 1)
                                noviPanel.Anchor = AnchorStyles.Top;
                            else
                                noviPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                        }
                    }
                    listaPanela.Add(noviPanel);
                    noviPanel.Size = new Size(336, 135);
                    mainPanel.Controls.Add(noviPanel);
                    noviPanel.BringToFront();
                    noviPanel.Show();
                    var forma = new frmJelo(jelo);
                    openChildForm(forma, noviPanel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška prilikom učitavanja.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnJela.Enabled = true;
            pbLoading.Visible = false;
            listaPanela.Clear();
        }

        private void btnDodajJelo_Click(object sender, EventArgs e)
        {
            try
            {
                clearMainPanel();
                lblNazivStranice.Text = "Jela";
                openChildForm(new frmUpsertJelo(), mainPanel);

                btnDodajJelo.Enabled = false;
                pbLoading.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška prilikom učitavanja.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnDodajJelo.Enabled = true;
            pbLoading.Visible = false;
        }

        public async void btnPregledMenija_Click(object sender = null, EventArgs e = null)
        {
            lblNazivStranice.Text = "Meni";
            btnMeni.Enabled = false;
            pbLoading.Visible = true;
            int brojacMenija = 1;
            try
            {
                clearMainPanel();
                var listaMenija = await meniService.Get<List<Model.Meni>>(null);
                foreach (var meni in listaMenija)
                {
                    var noviPanel = new Panel();
                    if (listaPanela.Count == 0)
                        noviPanel.Location = new Point(45, 4);
                    else
                    {
                        noviPanel.Location = new Point(listaPanela[listaPanela.Count - 1].Location.X + 555, listaPanela[listaPanela.Count - 1].Location.Y);
                    }
                    noviPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    listaPanela.Add(noviPanel);
                    noviPanel.Size = new Size(500, 698);
                    mainPanel.Controls.Add(noviPanel);
                    noviPanel.BringToFront();
                    noviPanel.Show();
                    var forma = new frmMeni(meni, brojacMenija++);
                    openChildForm(forma, noviPanel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška prilikom učitavanja.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnMeni.Enabled = true;
            pbLoading.Visible = false;
            listaPanela.Clear();
        }

        private void btnDodajMeni_Click(object sender, EventArgs e)
        {
            try
            {
                clearMainPanel();
                lblNazivStranice.Text = "Meni";
                openChildForm(new frmUpsertMeni(), mainPanel);

                btnDodajMeni.Enabled = false;
                pbLoading.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška prilikom učitavanja.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnDodajMeni.Enabled = true;
            pbLoading.Visible = false;
        }

        public async void btnRezervacije_Click(object sender = null, EventArgs e = null)
        {
            lblNazivStranice.Text = "Rezervacije";
            btnRezervacije.Enabled = false;
            pbLoading.Visible = true;
            try
            {
                clearMainPanel();
                var listaRezervacija = await rezervacijaService.Get<List<Model.Rezervacija>>(null);
                foreach (var rezervacija in listaRezervacija)
                {
                    var noviPanel = new Panel();
                    if (listaPanela.Count == 0)
                        noviPanel.Location = new Point(79, 0);
                    else
                    {
                        noviPanel.Location = new Point(listaPanela[listaPanela.Count - 1].Location.X, listaPanela[listaPanela.Count - 1].Location.Y + 190);
                    }
                    noviPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    listaPanela.Add(noviPanel);
                    noviPanel.Size = new Size(1050, 125);
                    mainPanel.Controls.Add(noviPanel);
                    noviPanel.BringToFront();
                    noviPanel.Show();
                    var forma = new frmRezervacija(rezervacija);
                    openChildForm(forma, noviPanel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška prilikom učitavanja.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnRezervacije.Enabled = true;
            pbLoading.Visible = false;
            listaPanela.Clear();
        }

        public void btnPregledKorisnika_Click(object sender=null, EventArgs e=null)
        {
            try
            {
                clearMainPanel();
                lblNazivStranice.Text = "Korisnici";
                openChildForm(new frmUposlenici(), mainPanel);

                btnPregledUposlenika.Enabled = false;
                pbLoading.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška prilikom učitavanja.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnPregledUposlenika.Enabled = true;
            pbLoading.Visible = false;
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        public async void loadUpdateJela(int id)
        {
            try
            {
                clearMainPanel();
                var jelo = await jeloService.GetById<Model.Jelo>(id);
                lblNazivStranice.Text = "Jela";
                openChildForm(new frmUpsertJelo(jelo), mainPanel);

                btnDodajJelo.Enabled = false;
                pbLoading.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška prilikom učitavanja.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnDodajJelo.Enabled = true;
            pbLoading.Visible = false;
        }

        public async void loadUpdateMenija(int id)
        {
            try
            {
                clearMainPanel();
                var meni = await meniService.GetById<Model.Meni>(id);
                lblNazivStranice.Text = "Meni";
                openChildForm(new frmUpsertMeni(meni), mainPanel);

                btnDodajMeni.Enabled = false;
                pbLoading.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška prilikom učitavanja.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnDodajMeni.Enabled = true;
            pbLoading.Visible = false;
        }

        public void loadUpdateUposlenika(Model.Uposlenik uposlenik)
        {
            try
            {
                clearMainPanel();
                lblNazivStranice.Text = "Uposlenik";
                openChildForm(new frmUpdateUposlenika(uposlenik), mainPanel);

                pbLoading.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška prilikom učitavanja.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            pbLoading.Visible = false;
        }

        private void btnDodajUposlenika_Click(object sender, EventArgs e)
        {
            try
            {
                clearMainPanel();
                lblNazivStranice.Text = "Uposlenik";
                openChildForm(new frmDodajUposlenika(), mainPanel);

                btnDodajUposlenika.Enabled = false;
                pbLoading.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška prilikom učitavanja.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnDodajUposlenika.Enabled = true;
            pbLoading.Visible = false;
        }
    }
}
