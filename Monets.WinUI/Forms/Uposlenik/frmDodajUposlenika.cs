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
    public partial class frmDodajUposlenika : Form
    {
        private readonly APIService gradService = new APIService("Grad");
        private readonly APIService ulogaService = new APIService("Uloga");
        private readonly APIService uposlenikService = new APIService("Uposlenik");
        private UposlenikInsertRequest request = new UposlenikInsertRequest();
        public frmDodajUposlenika()
        {
            InitializeComponent();
        }

        private async void frmDodajUposlenika_Load(object sender, EventArgs e)
        {
            pbLoading.Visible = false;
            await ucitajGradove();
            await ucitajUloge();
        }

        private async Task ucitajGradove()
        {
            var listaGradova = await gradService.Get<List<Model.Grad>>(null);

            //listaGradova.Insert(0, new Model.Grad());
            cmbGrad.DataSource = listaGradova;
            cmbGrad.ValueMember = "GradId";
            cmbGrad.DisplayMember = "Naziv";
        }

        private async Task ucitajUloge()
        {
            var listaUloga = await ulogaService.Get<List<Model.Uloga>>(null);

            clbUloge.DataSource = listaUloga;
            clbUloge.ValueMember = "UlogaId";
            clbUloge.DisplayMember = "Naziv";
        }

        private async Task ucitajSliku(byte[] slika)
        {
            if (slika != null && slika.Length > 0)
            {
                Image x = (Bitmap)((new ImageConverter()).ConvertFrom(slika));
                pbSlika.Image = x;
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

        private void txtLozinka_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave.Enabled = false;
                pbLoading.Visible = true;

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

                var uloge = clbUloge.CheckedItems.Cast<Model.Uloga>();
                request.Uloge = uloge.Select(s => s.UlogaId).ToList();

                var response = await uposlenikService.Insert<Model.Uposlenik>(request);

                if (response != null)
                {
                    MessageBox.Show("Uspješno ste dodali uposlenika - " + response.Ime+" "+response.Prezime, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
}
