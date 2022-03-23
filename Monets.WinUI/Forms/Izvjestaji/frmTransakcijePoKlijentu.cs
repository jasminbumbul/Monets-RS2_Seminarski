using Microsoft.Reporting.WinForms;
using Monets.Model.Requests;
using Monets.WinUI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monets.WinUI.Forms.Izvjestaji
{
    public partial class frmTransakcijePoKlijentu : Form
    {
        private APIService transakcijaService = new APIService("Transakcija");
        private APIService klijentService = new APIService("Klijent");


        public frmTransakcijePoKlijentu()
        {
            InitializeComponent();
        }

        private async Task LoadKlijenta()
        {
            var klijent = await klijentService.Get<List<Model.Klijent>>(null);

            klijent.Insert(0, new Model.Klijent() { Ime = "Odaberite klijenta" });
            cmbKlijent.DataSource = klijent;
            cmbKlijent.DisplayMember = "ImePrezimeKlijenta";
            cmbKlijent.ValueMember = "KlijentId";

        }

        private async void frmTransakcijePoKlijentu_Load(object sender, EventArgs e)
        {
            await LoadKlijenta();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren() && ProvjeraValidnostiPolja() == true)
            {
                var klijentValue = cmbKlijent.SelectedValue;

                var klijentIme = cmbKlijent.Text;

                TransakcijaSearchRequest request = new TransakcijaSearchRequest();

                if (int.TryParse(klijentValue.ToString(), out int id2))
                {
                    request.KlijentId = id2;
                }

                this.reportViewer1.Reset();
                this.reportViewer1.LocalReport.DataSources.Clear();
                var transakcije = await transakcijaService.Get<List<Model.Transakcija>>(request);
                ReportDataSource rds = new ReportDataSource("DataSet1", transakcije);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Monets.WinUI.Reports.TransakcijePoKlijentuReport.rdlc";
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("DatumIzvjestaja", DateTime.Now.ToString("dd.MM.yyyy")));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("ID", request.KlijentId.ToString()));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Klijent", klijentIme));


                this.reportViewer1.RefreshReport();
            }
        }

        private bool ProvjeraValidnostiPolja()
        {
            if (errorProvider.GetError(cmbKlijent).Length > 0)
                return false;
            else
                return true;
        }
     
        private void cmbKlijent_Validating(object sender, CancelEventArgs e)
        {
            if (cmbKlijent.SelectedValue == null)
            {
                labelClan.ForeColor = Color.Red;
                errorProvider.SetError(cmbKlijent, Properties.Resources.ObaveznoPolje);
            }
            else if (int.Parse(cmbKlijent.SelectedIndex.ToString()) == 0)
            {
                labelClan.ForeColor = Color.Red;
                errorProvider.SetError(cmbKlijent, Properties.Resources.ObaveznoPolje);
            }
            else
            {
                labelClan.ForeColor = Color.Black;
                errorProvider.SetError(cmbKlijent, null);
            }
        }
    }
}
