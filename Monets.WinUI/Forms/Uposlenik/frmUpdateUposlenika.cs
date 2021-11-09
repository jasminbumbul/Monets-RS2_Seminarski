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
                if(rbDa.Checked==true)
                {
                    request.Status = true;
                }
                else
                {
                    request.Status = false;
                }

                var uloge = clbUloge.CheckedItems.Cast<Model.Uloga>();
                request.Uloge = uloge.Select(s => s.UlogaId).ToList();

                var response = await uposlenikService.Update<Model.Uposlenik>(uposlenik.UposlenikId,request);

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
    }
}
