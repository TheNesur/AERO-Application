using Eolia_IHM.Menu;
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
    public partial class MenuEolia : Form
    {
        public MenuEolia()
        {
            InitializeComponent();
        }

        StatusMenu statusMenu = new StatusMenu();
        MesureMenu mesureMenu = new MesureMenu();
        CameraMenu cameraMenu = new CameraMenu();
        ConfigurationMenu configurationMenu = new ConfigurationMenu();

        private const int numberMenu = 4;

        private enum MenuTypes
        {
            STATUS = 0,
            MESURE = 1,
            CAMERA = 2,
            CONFIGURATION = 3
        }

        private void chooseMenu(MenuTypes menuTypes)
        {
            switch (menuTypes)
            {
                case MenuTypes.STATUS:
                    statusMenu.Show();
                    mesureMenu.Hide();
                    cameraMenu.Hide();
                    configurationMenu.Hide();
                    break;

                case MenuTypes.MESURE:
                    statusMenu.Hide();
                    mesureMenu.Show();
                    cameraMenu.Hide();
                    configurationMenu.Hide();
                    break;

                case MenuTypes.CAMERA:
                    statusMenu.Hide();
                    mesureMenu.Hide();
                    cameraMenu.Show();
                    configurationMenu.Hide();
                    break;

                case MenuTypes.CONFIGURATION:
                    statusMenu.Hide();
                    mesureMenu.Hide();
                    cameraMenu.Hide();
                    configurationMenu.Show();
                    break;
                default:
                    break;
            }

        }



        private void buttonStatus_Click(object sender, EventArgs e)
        {
            chooseMenu(MenuTypes.STATUS);
        }

        private void buttonMesure_Click(object sender, EventArgs e)
        {
            chooseMenu(MenuTypes.MESURE);
        }

        private void buttonCamera_Click(object sender, EventArgs e)
        {
            chooseMenu(MenuTypes.CAMERA);
        }

        private void buttonConfiguration_Click(object sender, EventArgs e)
        {
            chooseMenu(MenuTypes.CONFIGURATION);
        }

        private void buttonQuitter_Click(object sender, EventArgs e)
        {
            if (EoliaMes.LiaisonSerieCapteur())
            {
                if (EoliaMes.EtatTransMes())
                    EoliaMes.ArreterTransMes();
                EoliaMes.FermerLiaisonSerieCapteur();
            }
            Application.Restart();
            Environment.Exit(0);
        }

        private void MenuEolia_Load(object sender, EventArgs e)
        {
            statusMenu.Parent = panelMenu;
            mesureMenu.Parent = panelMenu;
            cameraMenu.Parent = panelMenu;
            configurationMenu.Parent = panelMenu;
            chooseMenu(MenuTypes.STATUS);
        }

    }
}
