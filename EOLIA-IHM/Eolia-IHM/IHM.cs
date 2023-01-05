using Eolia_IHM.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eolia_IHM
{
    public partial class IHM : Form
    {
        EoliaUtils EoliaFnct = new EoliaUtils();
        public IHM()
        {
            InitializeComponent();
        }

        private void BoutonQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void IHM_Load(object sender, EventArgs e)
        {

        }

        private void BoutonOngletEtat_Click(object sender, EventArgs e)
        {
            EoliaFnct.AfficherOnglet(GroupBoxEtat);
        }

        private void BoutonOngletMesure_Click(object sender, EventArgs e)
        {
            EoliaFnct.AfficherOnglet(GroupBoxMesure);
        }

        private void BoutonOngletConfig_Click(object sender, EventArgs e)
        {
            EoliaFnct.AfficherOnglet(GroupBoxConfig);
        }

        private void BoutonSauvegarde_Click(object sender, EventArgs e)
        {
            EoliaFnct.SauvegarderConfiguration();
            string x = EoliaFnct.LireConfiguration("key");
        }
    }
}
