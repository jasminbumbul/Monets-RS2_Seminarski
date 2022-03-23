using Monets.Model.Requests;
using Monets.WinUI.Forms.Static;
using Monets.WinUI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monets.WinUI.Forms.Jelo
{
    public partial class frmUpsertJelo : Form
    {
        private Model.Jelo jelo=new Model.Jelo();
        JeloUpsertRequest request = new JeloUpsertRequest();
        private APIService kategorijaService = new APIService("Kategorija");
        private APIService jeloService = new APIService("Jelo");
        private bool isEdit = false;

        public frmUpsertJelo(Model.Jelo jelo=null)
        {
            InitializeComponent();
            pbLoading.Visible = false;
            if (jelo != null)
            {
                isEdit = true;
                this.jelo = jelo;
                ucitajPodatke();
            }
            ucitajKategorije();
        }

        private async void ucitajPodatke()
        {
            lblUpsertJela.Text = "Update jela";
            btnSave.Text = "Update jelo";
            txtNazivJela.Text = jelo.NazivJela;
            txtVrijemeIzrade.Text = jelo.VrijemeIzradeUminutama.ToString();
            txtCijena.Text = jelo.Cijena.ToString();

            if (!string.IsNullOrEmpty(jelo.OpisJela))
            {
                txtOpisJela.Text = jelo.OpisJela.ToString();
            }
            else
            {
                txtOpisJela.Text = "";
            }
            await ucitajSliku(jelo.Slika);
        }

        private async Task ucitajSliku(byte[] slika)
        {
            if (slika != null && slika.Length > 0)
            {
                Image x = (Bitmap)((new ImageConverter()).ConvertFrom(slika));
                pbSlika.Image = x;
            }

        }

        private async void ucitajKategorije()
        {
            List<Model.Kategorija> listaKategorija = await kategorijaService.Get<List<Model.Kategorija>>(null);
            cmbKategorija.DataSource = listaKategorija;
            cmbKategorija.DisplayMember = "Naziv";
            cmbKategorija.ValueMember = "KategorijaId";
            if(isEdit)
               cmbKategorija.SelectedValue = jelo.KategorijaId;
        }

        private void lblKorisnickoIme_Click(object sender, EventArgs e)
        {

        }

        private void loginPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if(isEdit)
            {
                try
                {
                    btnSave.Enabled = false;
                    pbLoading.Visible = true;
                    request.Cijena = Convert.ToDouble(txtCijena.Text);
                    request.KategorijaId = Convert.ToInt32(cmbKategorija.SelectedValue);
                    request.NazivJela = txtNazivJela.Text;
                    request.VrijemeIzradeUminutama = Int16.Parse(txtVrijemeIzrade.Text);
                    request.OpisJela = txtOpisJela.Text;

                    var response = await jeloService.Update<Model.Jelo>(jelo.JeloId, request);

                    if (response != null)
                    {
                        MessageBox.Show("Uspješno ste update jelo - " + response.NazivJela, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        request.SlikaPutanja = response.SlikaPutanja;
                    }

                    frmMain.INSTANCE.btnPregledJela_Click();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Greška prilikom spremanja.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                btnSave.Enabled = true;
                pbLoading.Visible = false;
            }
            else
            {
                try
                {
                    btnSave.Enabled = false;
                    pbLoading.Visible = true;
                    request.Cijena = Convert.ToDouble(txtCijena.Text);
                    request.KategorijaId = Convert.ToInt32(cmbKategorija.SelectedValue);
                    request.NazivJela = txtNazivJela.Text;
                    request.VrijemeIzradeUminutama = Int16.Parse(txtVrijemeIzrade.Text);
                    request.OpisJela = txtOpisJela.Text;
                    var response = await jeloService.Insert<Model.Jelo>(request);

                    if (response != null)
                    {
                        MessageBox.Show("Uspješno ste dodali jelo - " + response.NazivJela, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        request.SlikaPutanja = response.SlikaPutanja;
                    }
                    frmMain.INSTANCE.btnPregledJela_Click();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
