using Monets.WinUI.Forms.Static;
using Monets.WinUI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Monets.WinUI.Forms.Meni
{
    public partial class frmMeni : Form
    {
        private APIService jeloService = new APIService("Jelo");
        private APIService meniService = new APIService("Meni");
        private Model.Meni meni;
        private int brojac = 0;
        List<GroupBox> listaGroupBoxova = new List<GroupBox>();
        List<Form> listaFormaJela = new List<Form>();

        public frmMeni(Model.Meni meni, int brojac)
        {
            InitializeComponent();
            this.meni = meni;
            this.brojac = brojac;
        }

        private void frmMeni_Load(object sender, EventArgs e)
        {
            ucitajPodatke();
        }

        private void ucitajPodatke()
        {
            int brojProslihJela = 0;
            gbMeni.Text = "Meni br. " + brojac;
            lblNazivMenija.Text = meni.Naziv;

            var listaJela = new List<Model.Jelo>();
            var listaKategorija = new List<Model.Kategorija>();
            bool postojiKategorija = false;
            foreach (var jeloMeni in meni.JeloMeni)
            {
                foreach (var kategorija in listaKategorija)
                {
                    if (kategorija.KategorijaId == jeloMeni.Jelo.Kategorija.KategorijaId)
                    {
                        postojiKategorija = true;
                    }
                }
                if (!postojiKategorija)
                {
                    listaKategorija.Add(jeloMeni.Jelo.Kategorija);
                }
                listaJela.Add(jeloMeni.Jelo);
                postojiKategorija = false;
            }

            try
            {
                foreach (var kategorija in listaKategorija)
                {
                    var jelaUKategoriji = getJelaUKategoriji(kategorija.KategorijaId, listaJela);

                    var noviGroupBoxKategorije = new GroupBox();
                    if (listaGroupBoxova.Count == 0)
                        noviGroupBoxKategorije.Location = new Point(23, 178);
                    else
                    {
                        noviGroupBoxKategorije.Location = new Point(listaGroupBoxova[listaGroupBoxova.Count - 1].Location.X, listaGroupBoxova[listaGroupBoxova.Count - 1].Location.Y + 200*brojProslihJela);
                        brojProslihJela = 0;
                    }
                    noviGroupBoxKategorije.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    noviGroupBoxKategorije.Text = kategorija.Naziv;
                    noviGroupBoxKategorije.Size = new Size(412, 135 * jelaUKategoriji.Count + jelaUKategoriji.Count * 60);
                    listaGroupBoxova.Add(noviGroupBoxKategorije);
                    gbMeni.Controls.Add(noviGroupBoxKategorije);
                    gbMeni.Size = new Size(gbMeni.Size.Width, gbMeni.Size.Height + 200);
                    noviGroupBoxKategorije.BringToFront();
                    noviGroupBoxKategorije.Show();

                    foreach (var jelo in jelaUKategoriji)
                    {
                        brojProslihJela++;
                        var novaFormaJela = new frmJelo(jelo);
                        if (listaFormaJela.Count == 0)
                            novaFormaJela.Location = new Point(38, 38);
                        else
                        {
                            novaFormaJela.Location = new Point(listaFormaJela[listaFormaJela.Count - 1].Location.X, listaFormaJela[listaFormaJela.Count - 1].Location.Y + 150);
                        }
                        novaFormaJela.Size = new Size(336, 135);
                        novaFormaJela.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        listaFormaJela.Add(novaFormaJela);
                        novaFormaJela.TopLevel = false;
                        noviGroupBoxKategorije.Controls.Add(novaFormaJela);
                        novaFormaJela.BringToFront();
                        novaFormaJela.Show();
                    }
                    listaFormaJela.Clear();


                    //var forma = new frmMeni(meni, brojacMenija++); ;
                    //openChildForm(forma, noviPanel);
                }
                listaGroupBoxova.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška prilikom učitavanja.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private List<Model.Jelo> getJelaUKategoriji(int kategorijaId, List<Model.Jelo> listaJela)
        {
            var novaLista = new List<Model.Jelo>();
            foreach (var jelo in listaJela)
            {
                if (jelo.KategorijaId == kategorijaId)
                {
                    novaLista.Add(jelo);
                }
            }
            return novaLista;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmMain.INSTANCE.loadUpdateMenija(meni.MeniId);
        }
    }
}
