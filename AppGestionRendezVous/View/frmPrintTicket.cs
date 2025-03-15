using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Mysqlx.Notice.Warning.Types;
using AppGestionRendezVous.Model;
using AppGestionRendezVous.Report;

namespace AppGestionRendezVous.View
{
    public partial class frmPrintTicket : Form
    {
        public frmPrintTicket()
        {
            InitializeComponent();
        }
        BdRvMedicalContext db = new BdRvMedicalContext();

        private void frmPrintTicket_Load(object sender, EventArgs e)
        {
            rptTicketRv objRpt = new rptTicketRv();

            // Charger les données dans le rapport
            DataTable dt = GetTableTicket(1); // Remplacez par l'ID du rendez-vous à imprimer
            objRpt.SetDataSource(dt);

            // Afficher dans le Crystal Report Viewer
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        public DataTable GetTableTicket(int? idRv = 0)
        {
            DataTable table = new DataTable();
            table.Columns.Add("NomPrenom", typeof(string));
            table.Columns.Add("DateRv", typeof(DateTime));
            table.Columns.Add("Medecin", typeof(string));
            table.Columns.Add("Creneau", typeof(string));
            table.Columns.Add("DataQr", typeof(byte[])); // Correction ici
            table.Columns.Add("ReferencePayment", typeof(string));
            table.Columns.Add("soin", typeof(string));
            table.Columns.Add("cout", typeof(string));
            table.Columns.Add("NumRecu", typeof(string));

            var leRv = db.RendezVous.FirstOrDefault(a => a.IdRendezVous == idRv);

            if (leRv != null)
            {
                table.Rows.Add(
                    leRv.Patient.NomPrenom,
                    leRv.DateRv,
                    leRv.Medecin.NomPrenom,
                    leRv.Creneau,
                    new byte[0], // Remplacez par une fonction qui génère un QRCode en bytes
                    leRv.ReferencePayment,
                    leRv.Soin.Description,
                    leRv.Soin.cout,
                    leRv.NumRecu
                );
            }

            return table;
        }

    }
}
