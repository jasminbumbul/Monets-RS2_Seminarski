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

namespace Monets.WinUI.Forms.Transakcija
{
    public partial class frmTransakcije : Form
    {
        private readonly APIService transakcijaService = new APIService("Transakcija");
        private List<Model.Transakcija> listaTransakcija = new List<Model.Transakcija>();
        private IPagedList<Model.Transakcija> pagedListaTransakcija;
        private int pageNumber = 1;
        private int pageSize = 10;

        public frmTransakcije()
        {
            InitializeComponent();
        }

        private void frmTransakcije_Load(object sender, EventArgs e)
        {
            ucitajPodatke();
        }

        private async void ucitajPodatke(TransakcijaSearchRequest search = null)
        {
            if (search == null)
            {
                search = new TransakcijaSearchRequest();
                search.Status = true;
            }

            listaTransakcija = await transakcijaService.Get<List<Model.Transakcija>>(search);
            listaTransakcija = listaTransakcija.OrderBy(x => x.Sifra).ToList();
            pagedListaTransakcija = listaTransakcija.ToPagedList(pageNumber, pageSize);
            dgvTransakcije.AutoGenerateColumns = false;
            dgvTransakcije.DataSource = pagedListaTransakcija.ToList();

            btnPrethodna.Enabled = pagedListaTransakcija.HasPreviousPage;
            btnSljedeca.Enabled = pagedListaTransakcija.HasNextPage;
            lblStranica.Text = string.Format("Page {0}/{1}", pageNumber, pagedListaTransakcija.PageCount);
        }

        private void txtIme_TextChanged(object sender, EventArgs e)
        {
            ucitajPodatke(new TransakcijaSearchRequest() { Sifra=txtSifra.Text });
        }

        private void btnSljedeca_Click_1(object sender, EventArgs e)
        {
            if (pagedListaTransakcija.HasNextPage)
            {
                pagedListaTransakcija = listaTransakcija.ToPagedList(++pageNumber, pageSize);

                dgvTransakcije.AutoGenerateColumns = false;
                dgvTransakcije.DataSource = pagedListaTransakcija.ToList();

                btnPrethodna.Enabled = pagedListaTransakcija.HasPreviousPage;
                btnSljedeca.Enabled = pagedListaTransakcija.HasNextPage;
                lblStranica.Text = string.Format("Page {0}/{1}", pageNumber, pagedListaTransakcija.PageCount);
            }
        }

        private void btnPrethodna_Click_1(object sender, EventArgs e)
        {
             if (pagedListaTransakcija.HasPreviousPage)
            {
                pagedListaTransakcija = listaTransakcija.ToPagedList(--pageNumber, pageSize);

                dgvTransakcije.AutoGenerateColumns = false;
                dgvTransakcije.DataSource = pagedListaTransakcija.ToList();

                btnPrethodna.Enabled = pagedListaTransakcija.HasPreviousPage;
                btnSljedeca.Enabled = pagedListaTransakcija.HasNextPage;
                lblStranica.Text = string.Format("Page {0}/{1}", pageNumber, pagedListaTransakcija.PageCount);
            }
        }

        private void dgvUposlenici_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewButtonColumn c = (DataGridViewButtonColumn)dgvTransakcije.Columns["Deaktivacija"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Black;
            c.DefaultCellStyle.BackColor = Color.FromArgb(243, 76, 54);

            DataGridViewButtonColumn d = (DataGridViewButtonColumn)dgvTransakcije.Columns["Detalji"];
            d.FlatStyle = FlatStyle.Popup;
            d.DefaultCellStyle.ForeColor = Color.White;
            d.DefaultCellStyle.BackColor = Color.FromArgb(42, 2, 82);
        }

        private void cbAktivneTransakcije_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
