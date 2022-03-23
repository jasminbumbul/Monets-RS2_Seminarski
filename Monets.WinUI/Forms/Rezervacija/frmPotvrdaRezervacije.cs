using Monets.Model.Requests;
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
    public partial class frmPotvrdaRezervacije : Form
    {
        private Model.Rezervacija rezervacija;
        private readonly APIService rezervacijaService = new APIService("Rezervacija");
        private RezervacijaUpsertRequest request = new RezervacijaUpsertRequest();


        public frmPotvrdaRezervacije(Model.Rezervacija rezervacija)
        {
            InitializeComponent();
            pbLoading.Visible = false;
            if(rezervacija!=null)
            {
                this.rezervacija = rezervacija;
                if((bool)!rezervacija.Potvrdjena)
                {
                    txtOdbij.Text = rezervacija.Poruka;
                }
            }
        }

        private void frmPotvrdaRezervacije_Load(object sender, EventArgs e)
        {
            ucitajPodatke();
        }

        private void ucitajPodatke()
        {
            lblSifra.Text = rezervacija.Sifra;
            txtPotvrdi.Text = "Rezervacija " + rezervacija.Sifra + " je potvrđena";
        }

        private async void btnPotvrdi_Click(object sender, EventArgs e)
        {
            try
            {
                btnPotvrdi.Enabled = false;
                btnOdbij.Enabled = false;
                pbLoading.Visible = true;
                request.Poruka = txtPotvrdi.Text;
                request.Potvrdjena = true;
                request.PocetakRezervacije = rezervacija.PocetakRezervacije;
                request.KrajRezervacije = rezervacija.KrajRezervacije;
                request.Placena = rezervacija.Placena;
                request.StolId = rezervacija.StolId;

                var response = await rezervacijaService.Update<Model.Rezervacija>(rezervacija.RezervacijaId,request);

                if (response != null)
                {
                    MessageBox.Show("Uspješno ste potvrdili rezervaciju - " + response.Sifra, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                frmMain.INSTANCE.btnRezervacije_Click();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška prilikom spremanja.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnPotvrdi.Enabled = true;
            btnOdbij.Enabled = true;
            pbLoading.Visible = false;
        }

        private async void btnOdbij_Click(object sender, EventArgs e)
        {
            try
            {
                btnPotvrdi.Enabled = false;
                btnOdbij.Enabled = false;
                pbLoading.Visible = true;
                request.Poruka = txtOdbij.Text;
                request.Potvrdjena = false;

                var response = await rezervacijaService.Update<Model.Rezervacija>(rezervacija.RezervacijaId, request);

                if (response != null)
                {
                    MessageBox.Show("Uspješno ste odbili rezervaciju - " + response.Sifra, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                frmMain.INSTANCE.btnRezervacije_Click();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška prilikom spremanja.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnPotvrdi.Enabled = true;
            btnOdbij.Enabled = true;
            pbLoading.Visible = false;
        }
    }
}
