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
    public partial class AccueilIHM : Form
    {
        public AccueilIHM()
        {
            InitializeComponent();
            
        }

        private void BoutonLancer_Click(object sender, EventArgs e)
        {

            this.Hide();
            //IHM IHMForm = new IHM();
            //IHMForm.Show();
            MenuEolia menu = new MenuEolia();
            menu.Show();
           
        }

        private void buttonFermerProgramme_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AccueilIHM_Load(object sender, EventArgs e)
        {
            EoliaLogs.InitializeLogs();
            EoliaLogs.Write("Démarrage de l'IHM");
        }
    }
}
