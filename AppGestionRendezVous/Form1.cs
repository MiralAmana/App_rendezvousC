using AppGestionRendezVous.Helper;
using AppGroupe2.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGestionRendezVous
{
    public partial class frmConexion : Form
    {
        public frmConexion()
        {
            InitializeComponent();
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            frmMDI f= new frmMDI();
            f.Show();
            this.Hide();
        }

      

        private void btnQuitter_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmConexion_Load(object sender, EventArgs e)
        {
            Utils.WriteLogSystem("test", "Ceci est est test");
            GMailer.SenMail("maremekane2216@gmail.com", "test", "un test");


        }
    }
    }

