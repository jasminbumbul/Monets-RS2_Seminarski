using Monets.Model.Requests;
using Monets.WinUI.Forms.Static;
using Monets.WinUI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monets.WinUI.Forms.Uposlenik
{
    public partial class frmUpdateUposlenika : Form
    {
        private Model.Uposlenik uposlenik;
        private readonly APIService gradService = new APIService("Grad");
        private readonly APIService ulogaService = new APIService("Uloga");
        private readonly APIService uposlenikService = new APIService("Uposlenik");
        private UposlenikUpdateRequest request = new UposlenikUpdateRequest();
        public frmUpdateUposlenika(Model.Uposlenik uposlenik)
        {
            InitializeComponent();
            if(uposlenik!=null)
            {
                this.uposlenik = uposlenik;
                ucitajPodatke();
            }
        }

        private async void ucitajPodatke()
        {
            pbLoading.Visible = false;
            await ucitajGradove();
            await ucitajUloge();
            await UcitajSliku(uposlenik.Slika);

            txtIme.Text = uposlenik.Ime;
            txtPrezime.Text = uposlenik.Prezime;
            txtKorisnickoIme.Text = uposlenik.KorisnickoIme;
            txtEmail.Text = uposlenik.Email;
            dtpDatumRodjenja.Value = uposlenik.DatumRodjenja;
            dtpDatumZaspolenja.Value = uposlenik.DatumZaposlenja;
            txtAdresa.Text = uposlenik.Adresa;
            txtTelefon.Text = uposlenik.Telefon;

            if(uposlenik.Status==true)
            {
                rbDa.Checked = true;
                rbNe.Checked = false;
            }
            else
            {
                rbDa.Checked = false;
                rbNe.Checked = true;
            }
        }

        private async Task UcitajSliku(byte[] slika)
        {
            if (slika != null && slika.Length > 0)
            {
                Image x = (Bitmap)((new ImageConverter()).ConvertFrom(slika));
                pbSlika.Image = x;
            }
        }

        private async Task ucitajGradove()
        {
            var listaGradova = await gradService.Get<List<Model.Grad>>(null);

            //listaGradova.Insert(0, new Model.Grad());
            cmbGrad.DataSource = listaGradova;
            cmbGrad.ValueMember = "GradId";
            cmbGrad.DisplayMember = "Naziv";
            cmbGrad.SelectedValue = uposlenik.GradId;
        }

        private async Task ucitajUloge()
        {
            var listaUloga = await ulogaService.Get<List<Model.Uloga>>(null);

            clbUloge.DataSource = listaUloga;
            clbUloge.ValueMember = "UlogaId";
            clbUloge.DisplayMember = "Naziv";

            var clbListUloge = clbUloge.Items.Cast<Model.Uloga>();

            for (int i = 0; i < uposlenik.UposlenikUloga.Count; i++)
            {
                for (int j = 0; j < clbListUloge.Count(); j++)
                {
                    if (uposlenik.UposlenikUloga.ElementAt(i).Uloga.UlogaId == clbListUloge.ElementAt(j).UlogaId)
                    {
                        clbUloge.SetItemChecked(j, true);
                    }
                }

            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren() && ProvjeraValidnostiPolja() == true)
            {
                btnSave.Enabled = false;
                pbLoading.Visible = true;
                try
                {

                    request.Ime = txtIme.Text;
                    request.Prezime = txtPrezime.Text;
                    request.KorisnickoIme = txtKorisnickoIme.Text;
                    request.Email = txtEmail.Text;
                    request.DatumZaposlenja = dtpDatumZaspolenja.Value;
                    request.DatumRodjenja = dtpDatumRodjenja.Value;
                    request.Adresa = txtAdresa.Text;
                    request.GradId = (int)cmbGrad.SelectedValue;
                    request.Lozinka = txtLozinka.Text;
                    request.LozinkaPotrvda = txtPotvrdaLozinke.Text;
                    request.Telefon = txtTelefon.Text;
                    if (rbDa.Checked == true)
                    {
                        request.Status = true;
                    }
                    else
                    {
                        request.Status = false;
                    }

                    var uloge = clbUloge.CheckedItems.Cast<Model.Uloga>();
                    request.Uloge = uloge.Select(s => s.UlogaId).ToList();

                    var response = await uposlenikService.Update<Model.Uposlenik>(uposlenik.UposlenikId, request);

                    if (response != null)
                    {
                        MessageBox.Show("Uspješno ste updateali uposlenika - " + response.Ime + " " + response.Prezime, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        request.SlikaPutanja = response.SlikaPutanja;
                    }
                    frmMain.INSTANCE.btnPregledKorisnika_Click();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Greška prilikom spremanja.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                btnSave.Enabled = true;
                pbLoading.Visible = false;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var filename = openFileDialog.FileName;
                request.SlikaPutanja = filename;
                var file = File.ReadAllBytes(filename);
                request.Slika = file;
                Image img = Image.FromFile(filename);
                pbSlika.Image = img;
            }
        }

        #region region vezan za validaciju polja
        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            Regex ime = new Regex(@"^\p{Lu}{1}[\p{Ll}\s\d]{2,29}$");

            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                errorProvider.SetError(txtIme, Properties.Resources.ObaveznoPolje);
            }
            else if (!ime.IsMatch(txtIme.Text))
            {
                errorProvider.SetError(txtIme, Properties.Resources.ImePrezimeNeispravanFormat);
            }
            else
            {
                errorProvider.SetError(txtIme, null);
            }
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            Regex prezime = new Regex(@"^\p{Lu}{1}[\p{Ll}\s\d]{2,29}$");

            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                errorProvider.SetError(txtPrezime, Properties.Resources.ObaveznoPolje);
            }
            else if (!prezime.IsMatch(txtIme.Text))
            {
                errorProvider.SetError(txtPrezime, Properties.Resources.ImePrezimeNeispravanFormat);
            }
            else
            {
                errorProvider.SetError(txtPrezime, null);
            }
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

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            Regex email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, Properties.Resources.ObaveznoPolje);
            }
            else if (!email.IsMatch(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, Properties.Resources.NeispravanFormat);
            }
            else
            {
                errorProvider.SetError(txtEmail, null);
            }
        }

        private void txtAdresa_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdresa.Text))
            {
                errorProvider.SetError(txtAdresa, Properties.Resources.ObaveznoPolje);
            }
            else
            {
                errorProvider.SetError(txtAdresa, null);
            }
        }

        private void cmbGrad_Validating(object sender, CancelEventArgs e)
        {
            if (cmbGrad.SelectedValue == null)
            {
                errorProvider.SetError(cmbGrad, Properties.Resources.ObaveznoPolje);
            }
            else if (int.Parse(cmbGrad.SelectedIndex.ToString()) == 0)
            {
                errorProvider.SetError(cmbGrad, Properties.Resources.ObaveznoPolje);
            }
            else
            {
                errorProvider.SetError(cmbGrad, null);
            }
        }

        private void txtLozinka_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLozinka.Text))
            {
                errorProvider.SetError(txtLozinka, Properties.Resources.ObaveznoPolje);
            }
            else if (!string.IsNullOrWhiteSpace(txtLozinka.Text) && txtLozinka.Text.Length < 4)
            {
                errorProvider.SetError(txtLozinka, Properties.Resources.MinimalnaDuzina);
            }
            else
            {
                errorProvider.SetError(txtLozinka, null);
            }
        }

        private void txtPotvrdaLozinke_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPotvrdaLozinke.Text))
            {
                errorProvider.SetError(txtPotvrdaLozinke, Properties.Resources.ObaveznoPolje);
            }
            else if (!string.IsNullOrWhiteSpace(txtPotvrdaLozinke.Text) && txtPotvrdaLozinke.Text.Length < 4)
            {
                errorProvider.SetError(txtPotvrdaLozinke, Properties.Resources.MinimalnaDuzina);
            }
            else if (txtPotvrdaLozinke.Text.Length >= 4 && txtLozinka.Text.Length >= 4 && txtPotvrdaLozinke.Text != txtLozinka.Text)
            {
                errorProvider.SetError(txtPotvrdaLozinke, Properties.Resources.RazliciteLozinke);
            }
            else
            {
                errorProvider.SetError(txtPotvrdaLozinke, null);
            }
        }

        private void txtTelefon_Validating(object sender, CancelEventArgs e)
        {
            Regex telefon = new Regex(@"^([0-9]){3}(-|/|\s)?([0-9]){3}(-|/|\s)?([0-9]){3,4}$");

            if (string.IsNullOrWhiteSpace(txtTelefon.Text))
            {
                errorProvider.SetError(txtTelefon, Properties.Resources.ObaveznoPolje);
            }
            else if (!telefon.IsMatch(txtTelefon.Text))
            {
                errorProvider.SetError(txtTelefon, Properties.Resources.NeispravanTelefon);
            }
            else
            {
                errorProvider.SetError(txtTelefon, null);
            }
        }

        private void clbUloge_Validating(object sender, CancelEventArgs e)
        {
            if (clbUloge.CheckedItems.Count == 0)
            {
                errorProvider.SetError(clbUloge, Properties.Resources.NeispravanOdabirUloge);
            }
            else
            {
                errorProvider.SetError(clbUloge, null);
            }
        }

        private bool ProvjeraValidnostiPolja()
        {
            if (errorProvider.GetError(txtIme).Length > 0)
                return false;

            if (errorProvider.GetError(txtPrezime).Length > 0)
                return false;

            if (errorProvider.GetError(txtKorisnickoIme).Length > 0)
                return false;

            if (errorProvider.GetError(txtEmail).Length > 0)
                return false;

            if (errorProvider.GetError(txtAdresa).Length > 0)
                return false;

            if (errorProvider.GetError(cmbGrad).Length > 0)
                return false;

            if (errorProvider.GetError(txtLozinka).Length > 0)
                return false;

            if (errorProvider.GetError(txtPotvrdaLozinke).Length > 0)
                return false;

            if (errorProvider.GetError(txtTelefon).Length > 0)
                return false;

            if (errorProvider.GetError(clbUloge).Length > 0)
                return false;

            return true;
        }
        #endregion
    }
}
