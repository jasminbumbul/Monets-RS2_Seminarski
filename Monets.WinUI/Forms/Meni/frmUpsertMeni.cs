using Monets.Model.Requests;
using Monets.WinUI.Forms.Static;
using Monets.WinUI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monets.WinUI.Forms.Meni
{
    public partial class frmUpsertMeni : Form
    {
        private bool isEdit = false;
        private MeniUpsertRequest request = new MeniUpsertRequest();
        private APIService meniService = new APIService("Meni");
        private APIService jelaService = new APIService("Jelo");
        private Model.Meni meni = new Model.Meni();


        public frmUpsertMeni(Model.Meni meni=null)
        {
            InitializeComponent();
            pbLoading.Visible = false;
            if (meni != null)
            {
                isEdit = true;
                this.meni = meni;
                lblUpsertMenija.Text = "Update menija";
                btnSave.Text = "Update meni";
                ucitajPodatke();
            }
            ucitajJela();
        }

        private void ucitajPodatke()
        {
            txtNazivMenija.Text = meni.Naziv;
            txtCijena.Text = meni.Cijena.ToString();
        }

        private async void ucitajJela()
        {
            var listaJela = await jelaService.Get<List<Model.Jelo>>(null);
            var listaOdabranihJela = new List<Model.Jelo>();
            if (isEdit)
            {
                foreach (var jeloMeni in meni.JeloMeni)
                {
                    listaOdabranihJela.Add(jeloMeni.Jelo);
                }
            }

            listaJela = await jelaService.Get<List<Model.Jelo>>(null);
            listaJela = listaJela.OrderBy(x => x.NazivJela).ToList();
            lbJela.DataSource = listaJela;
            lbJela.DisplayMember = "NazivJela";
            lbJela.ValueMember = "JeloId";

            if (isEdit)
            {
                for (int i = 0; i < listaOdabranihJela.Count; i++)
                {
                    for (int j = 0; j < listaJela.Count ; j++)
                    {
                        if (listaOdabranihJela[i].JeloId==listaJela[j].JeloId)
                        {
                            int index = lbJela.FindString(listaOdabranihJela[i].NazivJela);
                            lbJela.SetSelected(index, true);
                        }
                    }
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            pbLoading.Visible = true;
            try
            {
                if (isEdit)
                {
                    List<int> odabranaJela = new List<int>();
                    foreach (Model.Jelo item in lbJela.SelectedItems)
                    {
                        odabranaJela.Add(Convert.ToInt32(item.JeloId));
                    }

                    request.Cijena = Convert.ToDouble(txtCijena.Text);
                    request.Naziv = txtNazivMenija.Text;
                    request.Jela = odabranaJela;

                    var response = await meniService.Update<Model.Meni>(meni.MeniId, request);

                    if (response != null)
                    {
                        MessageBox.Show("Uspješno ste update meni - " + response.Naziv, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {

                    List<int> odabranaJela = new List<int>();
                    foreach (Model.Jelo item in lbJela.SelectedItems)
                    {
                        odabranaJela.Add(Convert.ToInt32(item.JeloId));
                    }
                    btnSave.Enabled = false;
                    pbLoading.Visible = true;
                    request.Cijena = Convert.ToDouble(txtCijena.Text);
                    request.Naziv = txtNazivMenija.Text;
                    request.Jela = odabranaJela;

                    var response = await meniService.Insert<Model.Meni>(request);

                    if (response != null)
                    {
                        MessageBox.Show("Uspješno ste dodali meni - " + response.Naziv, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška prilikom spremanja.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            frmMain.INSTANCE.btnPregledMenija_Click();
            btnSave.Enabled = true;
            pbLoading.Visible = false;
        }
    }
}
