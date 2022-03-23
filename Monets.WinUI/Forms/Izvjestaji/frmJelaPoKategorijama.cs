using Microsoft.Reporting.WinForms;
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
    public partial class frmJelaPoKategorijama : Form
    {
        private APIService jeloRezervacijaService = new APIService("JeloRezervacija");

        public frmJelaPoKategorijama()
        {
            InitializeComponent();
        }

        private async void frmJelaPoKategorijama_LoadAsync(object sender, EventArgs e)
        {
            var rezervacije = await jeloRezervacijaService.Get<List<Model.JeloRezervacija>>(null);
            ReportDataSource rds = new ReportDataSource("DataSet1", rezervacije);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Monets.WinUI.Reports.BrojJelaPoRezervacijiReport.rdlc";
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("DatumIzvjestaja", DateTime.Now.ToString("dd.MM.yyyy")));

            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}
