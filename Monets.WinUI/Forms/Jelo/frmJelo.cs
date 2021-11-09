using Monets.WinUI.Forms.Static;
using Monets.WinUI.Helper;
using Monets.WinUI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monets.WinUI.Forms
{
    public partial class frmJelo : Form
    {
        private Model.Jelo jelo;
        List<Model.Rejting> listaRejtinga = new List<Model.Rejting>();
        private APIService rejtingService = new APIService("Rejting");

        public frmJelo(Model.Jelo jelo)
        {
            InitializeComponent();
            this.jelo = jelo;
            loadInfo();
        }

        private async void loadInfo()
        {
            lblNazivJela.Text = jelo.NazivJela;
            lblCijena.Text = jelo.Cijena.ToString() + "KM";
            await ucitajRejting();
            await ucitajSliku(jelo.Slika);
        }

        private async Task ucitajRejting()
        {
            var listaRejtinga = await rejtingService.Get<List<Model.Rejting>>(null);
            var listaMojihRejtinga = new List<Model.Rejting>();
            foreach (var rejting in listaRejtinga)
            {
                if (rejting.JeloId == jelo.JeloId)
                {
                    listaMojihRejtinga.Add(rejting);
                }
            }
            ProgressBarColor.SetState(pbRejting, 3);
            double prosjecniRejting = 0;

            if (listaMojihRejtinga.Count > 0)
            {
                foreach (var rejting in listaMojihRejtinga)
                {
                    prosjecniRejting += (double)rejting.Ocjena;
                }
                prosjecniRejting /= listaMojihRejtinga.Count;
                pbRejting.Value = (int)((100 * listaMojihRejtinga.Count) / prosjecniRejting);
            }

            lblRejting.Text = "Rejting " + prosjecniRejting + "/5" + "(" + listaMojihRejtinga.Count + " rejtinga)";
        }

        private async Task ucitajSliku(byte[] slika)
        {
            if (slika != null && slika.Length > 0)
            {
                Image x = (Bitmap)((new ImageConverter()).ConvertFrom(slika));
                pbSlika.Image = x;
            }

        }

  

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void lblRejting_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmMain.INSTANCE.loadUpdateJela(jelo.JeloId);
        }
    }
}
