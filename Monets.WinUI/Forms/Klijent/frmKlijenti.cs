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

namespace Monets.WinUI.Forms.Klijent
{
    public partial class frmKlijenti : Form
    {
        private readonly APIService klijentService = new APIService("Klijent");
        private List<Model.Klijent> listaKlijenata = new List<Model.Klijent>();
        private IPagedList<Model.Klijent> pagedListaKlijenata;
        private int pageNumber = 1;
        private int pageSize = 10;

        public frmKlijenti()
        {
            InitializeComponent();
        }

        private void frmKlijenti_Load(object sender, EventArgs e)
        {
            ucitajPodatke();
        }

        private async void ucitajPodatke(KlijentSearchRequest search = null)
        {
            if (search == null && cbAktivniKlijenti.Checked == true)
            {
                search = new KlijentSearchRequest();
                search.Status = true;
            }

            listaKlijenata = await klijentService.Get<List<Model.Klijent>>(search);
            listaKlijenata = listaKlijenata.OrderBy(x => x.Ime).ThenBy(x => x.Prezime).ThenBy(x => x.Status).ToList();
            pagedListaKlijenata = listaKlijenata.ToPagedList(pageNumber, pageSize);
            dgvKlijenti.AutoGenerateColumns = false;
            dgvKlijenti.DataSource = pagedListaKlijenata.ToList();

            btnPrethodna.Enabled = pagedListaKlijenata.HasPreviousPage;
            btnSljedeca.Enabled = pagedListaKlijenata.HasNextPage;
            lblStranica.Text = string.Format("Page {0}/{1}", pageNumber, pagedListaKlijenata.PageCount);
        }

        private void txtIme_TextChanged(object sender, EventArgs e)
        {
            ucitajPodatke(new KlijentSearchRequest() { Ime = txtIme.Text, Prezime = txtPrezime.Text, Status = cbAktivniKlijenti.Checked });
        }

        private void txtPrezime_TextChanged(object sender, EventArgs e)
        {
            ucitajPodatke(new KlijentSearchRequest() { Ime = txtIme.Text, Prezime = txtPrezime.Text, Status = cbAktivniKlijenti.Checked });
        }

        private void cbAktivniKlijenti_CheckedChanged(object sender, EventArgs e)
        {
            ucitajPodatke(new KlijentSearchRequest() { Ime = txtIme.Text, Prezime = txtPrezime.Text, Status = cbAktivniKlijenti.Checked });
        }

        private void btnSljedeca_Click(object sender, EventArgs e)
        {
            if (pagedListaKlijenata.HasNextPage)
            {
                pagedListaKlijenata = listaKlijenata.ToPagedList(++pageNumber, pageSize);

                dgvKlijenti.AutoGenerateColumns = false;
                dgvKlijenti.DataSource = pagedListaKlijenata.ToList();

                btnPrethodna.Enabled = pagedListaKlijenata.HasPreviousPage;
                btnSljedeca.Enabled = pagedListaKlijenata.HasNextPage;
                lblStranica.Text = string.Format("Page {0}/{1}", pageNumber, pagedListaKlijenata.PageCount);
            }
        }

        private void btnPrethodna_Click(object sender, EventArgs e)
        {
            if (pagedListaKlijenata.HasPreviousPage)
            {
                pagedListaKlijenata = listaKlijenata.ToPagedList(--pageNumber, pageSize);

                dgvKlijenti.AutoGenerateColumns = false;
                dgvKlijenti.DataSource = pagedListaKlijenata.ToList();

                btnPrethodna.Enabled = pagedListaKlijenata.HasPreviousPage;
                btnSljedeca.Enabled = pagedListaKlijenata.HasNextPage;
                lblStranica.Text = string.Format("Page {0}/{1}", pageNumber, pagedListaKlijenata.PageCount);
            }
        }

        private void dgvKlijenti_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewButtonColumn c = (DataGridViewButtonColumn)dgvKlijenti.Columns["Deaktivacija"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Black;
            c.DefaultCellStyle.BackColor = Color.FromArgb(243, 76, 54);

            DataGridViewButtonColumn d = (DataGridViewButtonColumn)dgvKlijenti.Columns["Detalji"];
            d.FlatStyle = FlatStyle.Popup;
            d.DefaultCellStyle.ForeColor = Color.White;
            d.DefaultCellStyle.BackColor = Color.FromArgb(42, 2, 82);

            DataGridViewButtonColumn f = (DataGridViewButtonColumn)dgvKlijenti.Columns["Transakcije"];
            f.FlatStyle = FlatStyle.Popup;
            f.DefaultCellStyle.ForeColor = Color.Black;
            f.DefaultCellStyle.BackColor = Color.FromArgb(251, 175, 2);
        }

        private async void dgvKlijenti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = (int)dgvKlijenti.Rows[e.RowIndex].Cells[0].Value;
            if (dgvKlijenti.Columns[e.ColumnIndex].Name == "Deaktivacija" && e.RowIndex != -1)
            {
                var ime = dgvKlijenti.Rows[e.RowIndex].Cells[1].Value;
                var prezime = dgvKlijenti.Rows[e.RowIndex].Cells[2].Value;

                if (MessageBox.Show("Jeste li sigurni da želite deaktivirati klijenta " + ime + " " + prezime + "? Odabrani klijent se neće moći prijaviti. Želite li nastaviti?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        var response = await klijentService.Delete<bool>(id);
                        if (response)
                        {
                            MessageBox.Show("Uspješno ste deaktivirali korisnika " + ime + " " + prezime + ".", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Greška prilikom deaktiviranja korisnika " + ime + " " + prezime + ".", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    frmMain.INSTANCE.btnPregledKlijenata_Click();
                }
            }
            else if (dgvKlijenti.Columns[e.ColumnIndex].Name == "Detalji" && e.RowIndex != -1)
            {
                var klijent = await klijentService.GetById<Model.Klijent>(id);
                frmMain.INSTANCE.loadUpdateKlijenta(klijent);
            }
            else if (dgvKlijenti.Columns[e.ColumnIndex].Name == "Transakcije" && e.RowIndex != -1)
            {
                //load transakcije
            }
        }


    }
}
