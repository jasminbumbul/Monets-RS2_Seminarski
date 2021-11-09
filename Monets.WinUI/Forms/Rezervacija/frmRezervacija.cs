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
        public frmRezervacija(Model.Rezervacija rezervacija)
        {
            InitializeComponent();
            this.rezervacija = rezervacija;
            ucitajPodatke();
        }

        private async void ucitajPodatke()
        {
            //todo: cijena, korisnik
            btnPotvrda.BackColor = (bool)rezervacija.Potvrdjena ? Color.FromArgb(255, 221, 9) : Color.FromArgb(243, 76, 54);
            btnPotvrda.Text = (bool)rezervacija.Potvrdjena ? "Potvrđena" : "Nije potvrđena";
            lblDatum.Text = rezervacija.DatumRezervacije.ToShortDateString();
            lblPlaceno.Text = (bool)rezervacija.Placena ? "Plaćeno" : "Nije plaćeno";
            lblSifra.Text = rezervacija.Sifra;
            Model.Stol stol = await stolService.GetById<Model.Stol>(rezervacija.StolId);
            lblStol.Text = stol.NazivStola + ", " + stol.BrojMjesta + " mjesta.";
            lblVrijeme.Text = rezervacija.DatumRezervacije.ToLongTimeString();
            lblRazlog.Text = (bool)rezervacija.Potvrdjena ? "" : "Odbijena zbog:"+rezervacija.Poruka;
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
