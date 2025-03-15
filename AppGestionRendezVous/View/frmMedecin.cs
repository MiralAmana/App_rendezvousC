using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppGestionRendezVous.Model;

namespace AppGestionRendezVous.View
{
    public partial class frmMedecin : Form

    {
        BdRvMedicalContext db=new BdRvMedicalContext();
        public frmMedecin()
        {
            InitializeComponent();
        }

        private void btnChoisir_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgMedecin.CurrentRow.Cells[0].Value.ToString());
            var M=db.Medecins.Find(id);
            if (M != null)
            {
                txtAdresse.Text = M.Adresse;
                txtNomPrenom.Text = M.NomPrenom;
                txtEmail.Text = M.Email;
                txtTelephone.Text = M.Tel;
                txtNumOrdMedecin.Text = M.NumeroOrdre;
               cbbSpecialite.SelectedValue = M.IdSpecialite;
                txtIdentifiant.Text = M.Identifiant;
            }
                }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Medecin M=new Medecin();
            M.Identifiant=txtIdentifiant.Text;
            M.Tel= txtTelephone.Text;
            M.Adresse= txtAdresse.Text;
            M.NumeroOrdre = txtNumOrdMedecin.Text;
            M.IdSpecialite = int.Parse(cbbSpecialite.SelectedValue.ToString());
            M.Email= txtEmail.Text;
            M.NomPrenom = txtNomPrenom.Text; 
            M.statuts=false;
            db.Medecins.Add(M);
            db.SaveChanges();
            ResetForm();


        }
        private void ResetForm()
        {
            txtAdresse.Text = string.Empty;
            txtNomPrenom.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            txtNumOrdMedecin.Text = string.Empty;
            cbbSpecialite.SelectedValue = string.Empty;
            cbbSpecialite.DataSource = LoadCbbSpecialite();
            cbbSpecialite.ValueMember = "Value";
            cbbSpecialite.DisplayMember = "Text";
            txtIdentifiant.Text = string.Empty;
            dgMedecin.DataSource = db.Medecins.Select(a => new { a.IdU, a.NumeroOrdre, a.Identifiant, a.Specialite.NomSpecialite, a.NomPrenom, a.Tel, a.Email }).ToList();
            txtNomPrenom.Focus();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {

            int? id = int.Parse(dgMedecin.CurrentRow.Cells[0].Value.ToString());
            var M = db.Medecins.Find(id);

            M.Identifiant = txtIdentifiant.Text;
            M.Tel = txtTelephone.Text;
            M.Adresse = txtAdresse.Text;
            M.NumeroOrdre = txtNumOrdMedecin.Text;
            M.IdSpecialite =int.Parse(cbbSpecialite.SelectedValue.ToString());
            M.Email = txtEmail.Text;
            M.NomPrenom = txtNomPrenom.Text;
            db.SaveChanges();
            ResetForm();

        }

        private void btnSuprimer_Click(object sender, EventArgs e)
        {

            int? id = int.Parse(dgMedecin.CurrentRow.Cells[0].Value.ToString());
            var M = db.Medecins.Find(id);
            db.Medecins.Remove(M);
         
            db.SaveChanges();
            ResetForm();

        }

        private void frmMedecin_Load(object sender, EventArgs e)
        {
            ResetForm();
        }

        private List<SelectListViewModel>LoadCbbSpecialite()
        {
            var m=db.Specialites.ToList();
            List<SelectListViewModel> list = new List<SelectListViewModel>();
            SelectListViewModel b = new SelectListViewModel();
            b.Text = "Selectionnez...";
            b.Value = "";
            list.Add(b);
            foreach (var c in m)
            {
                SelectListViewModel a = new SelectListViewModel();
                a.Text = c.NomSpecialite;
                a.Value=c.IdSpecialite.ToString();
                list.Add(a);
            }
            return list;


        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            frmAgenda a= new frmAgenda();
            a.idMedecin = int.Parse(dgMedecin.CurrentRow.Cells[0].Value.ToString());
            a.Show();
        }

        private void dgMedecin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
