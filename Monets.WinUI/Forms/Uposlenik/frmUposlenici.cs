using Monets.Model.Requests;
using Monets.WinUI.Forms.Static;
using Monets.WinUI.Services;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monets.WinUI.Forms.Uposlenik
{
    public partial class frmUposlenici : Form
    {
        private readonly APIService uposlenikService = new APIService("Uposlenik");
        private List<Model.Uposlenik> listaUposlenika = new List<Model.Uposlenik>();
        private IPagedList<Model.Uposlenik> pagedListaUposlenika;
        private int pageNumber = 1;
        private int pageSize = 10;

        public frmUposlenici()
        {
            InitializeComponent();
        }

        private void frmUposlenici_Load(object sender, EventArgs e)
        {
            ucitajPodatke();
        }

        private async void ucitajPodatke(UposlenikSearchRequest search = null)
        {
            if (search == null && cbAktivniUposlenici.Checked == true)
            {
                search = new UposlenikSearchRequest();
                search.Status = true;
            }

            listaUposlenika = await uposlenikService.Get<List<Model.Uposlenik>>(search);
            listaUposlenika = listaUposlenika.OrderBy(x => x.Ime).ThenBy(x=> x.Prezime).ThenBy(x=> x.Status).ToList();
            pagedListaUposlenika = listaUposlenika.ToPagedList(pageNumber, pageSize);
            dgvUposlenici.AutoGenerateColumns = false;
            dgvUposlenici.DataSource = pagedListaUposlenika.ToList();

            btnPrethodna.Enabled = pagedListaUposlenika.HasPreviousPage;
            btnSljedeca.Enabled = pagedListaUposlenika.HasNextPage;
            lblStranica.Text = string.Format("Page {0}/{1}", pageNumber, pagedListaUposlenika.PageCount);
        }

        private void cbAktivniUposlenici_CheckedChanged(object sender, EventArgs e)
        {
            ucitajPodatke(new UposlenikSearchRequest() { Ime = txtIme.Text, Prezime = txtPrezime.Text, Status = cbAktivniUposlenici.Checked });
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ucitajPodatke(new UposlenikSearchRequest() { Ime = txtIme.Text, Prezime=txtPrezime.Text,Status=cbAktivniUposlenici.Checked });
        }

        private void txtPrezime_TextChanged(object sender, EventArgs e)
        {
            ucitajPodatke(new UposlenikSearchRequest() { Ime = txtIme.Text, Prezime = txtPrezime.Text, Status = cbAktivniUposlenici.Checked });
        }

        private void dgvUposlenici_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void dgvUposlenici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = (int)dgvUposlenici.Rows[e.RowIndex].Cells[0].Value;
            if (dgvUposlenici.Columns[e.ColumnIndex].Name == "Deaktivacija" && e.RowIndex != -1)
            {
                var ime = dgvUposlenici.Rows[e.RowIndex].Cells[1].Value;
                var prezime = dgvUposlenici.Rows[e.RowIndex].Cells[2].Value;

                if (MessageBox.Show("Jeste li sigurni da želite deaktivirati uposlenika " + ime + " " + prezime + "? Odabrani uposlenik se neće moći prijaviti. Želite li nastaviti?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        var response = await uposlenikService.Delete<bool>(id);
                        if (response)
                        {
                            MessageBox.Show("Uspješno ste deaktivirali korisnika " + ime + " " + prezime +".", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Greška prilikom deaktiviranja korisnika " + ime + " " + prezime + ".", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    frmMain.INSTANCE.btnPregledKorisnika_Click();
                }
            }
            else if (dgvUposlenici.Columns[e.ColumnIndex].Name == "Detalji" && e.RowIndex != -1)
            {
                var uposlenik = await uposlenikService.GetById<Model.Uposlenik>(id);
                frmMain.INSTANCE.loadUpdateUposlenika(uposlenik);
            }
        }

        private void btnSljedeca_Click(object sender, EventArgs e)
        {
            if (pagedListaUposlenika.HasNextPage)
            {
                pagedListaUposlenika = listaUposlenika.ToPagedList(++pageNumber, pageSize);

                dgvUposlenici.AutoGenerateColumns = false;
                dgvUposlenici.DataSource = pagedListaUposlenika.ToList();

                btnPrethodna.Enabled = pagedListaUposlenika.HasPreviousPage;
                btnSljedeca.Enabled = pagedListaUposlenika.HasNextPage;
                lblStranica.Text = string.Format("Page {0}/{1}", pageNumber, pagedListaUposlenika.PageCount);
            }
        }

        private void btnPrethodna_Click(object sender, EventArgs e)
        {
            if (pagedListaUposlenika.HasPreviousPage)
            {
                pagedListaUposlenika = listaUposlenika.ToPagedList(--pageNumber, pageSize);

                dgvUposlenici.AutoGenerateColumns = false;
                dgvUposlenici.DataSource = pagedListaUposlenika.ToList();

                btnPrethodna.Enabled = pagedListaUposlenika.HasPreviousPage;
                btnSljedeca.Enabled = pagedListaUposlenika.HasNextPage;
                lblStranica.Text = string.Format("Page {0}/{1}", pageNumber, pagedListaUposlenika.PageCount);
            }
        }

        private void dgvUposlenici_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewButtonColumn c = (DataGridViewButtonColumn)dgvUposlenici.Columns["Deaktivacija"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Black;
            c.DefaultCellStyle.BackColor = Color.FromArgb(243, 76, 54);

            DataGridViewButtonColumn d = (DataGridViewButtonColumn)dgvUposlenici.Columns["Detalji"];
            d.FlatStyle = FlatStyle.Popup;
            d.DefaultCellStyle.ForeColor = Color.White;
            d.DefaultCellStyle.BackColor = Color.FromArgb(42, 2, 82);
        }
    }
}
