using Monets.Model.Requests;
using Monets.WinUI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Monets.WinUI.Forms.Static
{
    public partial class frmLogin : Form, IMessageFilter
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

        APIService _apiService = new APIService("Korisnik");
        public frmLogin()
        {
            InitializeComponent();
            pbLoading.Visible = false;

            Application.AddMessageFilter(this);

            //Stavke koje se dodaju, biti će korištene za premještanje prozora
            controlsToMove.Add(this);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            loginPanel.BringToFront();
        }

        private async void btnPrijava_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren() && ProvjeriValidaciju() == true)
            {
                btnPrijava.Enabled = false;
                pbLoading.Visible = true;
                try
                {
                    APIService.Username = txtKorisnickoIme.Text;
                    APIService.Password = txtLozinka.Text;

                    AuthenticationRequest request = new AuthenticationRequest
                    {
                        KorisnickoIme = txtKorisnickoIme.Text,
                        Lozinka = txtLozinka.Text
                    };

                    var x = await _apiService.Authenticate(request);

                    var frm = new frmMain(x);
                    frm.Show();

                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Autentifikacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            btnPrijava.Enabled = true;
            pbLoading.Visible = false;
        }

        private bool ProvjeriValidaciju()
        {
            if (errorProvider.GetError(txtKorisnickoIme).Length > 0)
                return false;

            if (errorProvider.GetError(txtLozinka).Length > 0)
                return false;

            return true;
        }

        private void txtKorisnickoIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKorisnickoIme.Text))
            {
                errorProvider.SetError(txtKorisnickoIme, Properties.Resources.ObaveznoPolje);
            }
            else
            {
                errorProvider.SetError(txtKorisnickoIme, null);
            }
        }

        private void txtLozinka_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLozinka.Text))
            {
                errorProvider.SetError(txtLozinka, Properties.Resources.ObaveznoPolje);
            }
            else
            {
                errorProvider.SetError(txtLozinka, null);
            }
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

        private void loginPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMinimize_MouseDown(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnRestore_MouseDown(object sender, MouseEventArgs e)
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

        private void btnClose_MouseDown(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
    }
}
