using Monets.WinUI.Forms.Static;
using Monets.WinUI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Monets.WinUI.Forms.Rezervacija
{
    public partial class frmRezervacija : Form
    {
        private Model.Rezervacija rezervacija;
        private readonly APIService stolService = new APIService("Stol");
        private readonly APIService klijentService = new APIService("Klijent");
        public frmRezervacija(Model.Rezervacija rezervacija)
        {
            InitializeComponent();
            this.rezervacija = rezervacija;
            ucitajPodatke();
        }

        private async void ucitajPodatke()
        {
            var klijent = await klijentService.GetById<Model.Klijent>(rezervacija.KlijentId);
            lblDatum.Text = rezervacija.PocetakRezervacije.ToShortDateString();
            lblPlaceno.Text = (bool)rezervacija.Placena ? "Plaćeno" : "Nije plaćeno";
            lblSifra.Text = rezervacija.Sifra;
            Model.Stol stol = await stolService.GetById<Model.Stol>(rezervacija.StolId);
            lblStol.Text = stol.NazivStola + ", " + stol.BrojMjesta + " mjesta.";
            lblVrijeme.Text = rezervacija.PocetakRezervacije.ToLongTimeString();
            lblKorisnik.Text = klijent.ImePrezimeKlijenta;
            double cijena = 0;
            foreach (var item in rezervacija.JeloRezervacija)
            {
                cijena += item.Jelo.Cijena.Value * item.Kolicina;
            }
            lblCijena.Text=cijena.ToString()+"KM"; 
        }

        private void frmRezervacija_Load(object sender, EventArgs e)
        {

        }

        private void lblPlaceno_Click(object sender, EventArgs e)
        {

        }

        private void btnPotvrda_Click(object sender, EventArgs e)
        {
            try
            {
                var forma = new frmPotvrdaRezervacije(rezervacija);
                frmMain.INSTANCE.openChildForm(forma);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška prilikom učitavanja.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
