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

namespace Eolia_IHM.Menu
{
    public partial class StatusMenu : UserControl
    {
        public StatusMenu()
        {
            InitializeComponent();
        }

        private void StatusMenu_Load(object sender, EventArgs e)
        {

        }

        private void buttonDemarrerESP32_Click(object sender, EventArgs e)
        {
            
            if (EoliaMes.LiaisonSerieCapteur())
            {
                EoliaMes.FermerLiaisonSerieCapteur();
                if (!EoliaMes.LiaisonSerieCapteur())
                {
                    buttonDemarrerESP32.Text = "Démarrer liaison série";
                }
            }
            else
            {
                EoliaMes.InitialiserLiaisonSerieCapteur(EoliaUtils.LireConfiguration("PORTSERIECAPTEUR"), labelStatutCapteurs);
                if (EoliaMes.LiaisonSerieCapteur())
                {
                    buttonDemarrerESP32.Text = "Arrêter liaison série";
                }
            }
        }

        private void buttonEtatBDD_Click(object sender, EventArgs e)
        {
            if (!EoliaSQL.BDDisConnected())
            {
                EoliaSQL.InitialiserConnexionSQL(EoliaUtils.LireConfiguration("MYSQLDBNAME"),
                EoliaUtils.LireConfiguration("MYSQLUSERNAME"),
                EoliaUtils.LireConfiguration("MYSQLPASSWORD"),
                EoliaUtils.LireConfiguration("MYSQLADRESS"),
                labelStatutBDD,
                buttonEtatBDD);
            }
            else
            {
                EoliaSQL.FermerConnexionSQL();
            }
        }
    }
}
