using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AppGestionRendezVous.Helper;
using AppGestionRendezVous.Model;

namespace AppGestionRendezVous.View
{
    public partial class frmAgenda : Form
    {
        public int idMedecin;
        Utils utils=new Utils();

        public frmAgenda()
        {
            InitializeComponent();
        }

        BdRvMedicalContext db = new BdRvMedicalContext();

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            var m = db.Medecins.Find(idMedecin);
            lblMedecin.Text = string.Format("N Ordre: {0}  {1}", m.NumeroOrdre, m.NomPrenom);
            lblIdMedecin.Text = m.IdU.ToString();
            lblIdMedecin.Visible = false;
            ResetForm();
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                Agenda a = new Agenda();

                // Utiliser TryParse pour vérifier si la conversion est possible pour le créneau
                if (int.TryParse(txtCreneau.Text, out int creneau))
                {
                    a.Creneau = creneau;
                }
                else
                {
                    MessageBox.Show("Le créneau doit être un entier valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Vérification des heures (si elles sont dans un format valide)
                if (TimeSpan.TryParse(txtHeureDebut.Text, out TimeSpan heureDebut) && TimeSpan.TryParse(txtHeureFin.Text, out TimeSpan heureFin))
                {
                    a.HeureDebut = heureDebut.ToString();
                    a.HeureFin = heureFin.ToString();
                }
                else
                {
                    MessageBox.Show("Le format des heures est invalide. Utilisez le format HH:mm.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Affectation de la date (assurez-vous que txtDateAgenda est un DateTimePicker)
                a.DatePlanifier = txtDateAgenda.Value;

                // Remplir les autres champs
                a.statut = "Brouillon";
                a.Lieu = txtLieu.Text;
                a.Titre = txtTitre.Text;
                a.IdMedcin = idMedecin;

                // Ajouter à la base de données
                db.Agendas.Add(a);
                db.SaveChanges();

                // Mettre à jour le DataGridView pour afficher les nouveaux éléments
                UpdateAgendaGrid();

            }
            catch (Exception ex)
            {
                utils.WriteDataError("frmAgenda - btnAjouter_Click",ex.ToString());
            }
          finally
            {

                // Réinitialiser le formulaire pour ajouter un autre rendez-vous si nécessaire
                ResetForm();

            }
           

        }

        private void ResetForm()
        {
            // Réinitialisation des champs du formulaire
            txtCreneau.Text = string.Empty;
            txtTitre.Text = string.Empty;
            txtHeureDebut.Text = string.Empty;
            txtLieu.Text = string.Empty;
            txtHeureFin.Text = string.Empty;
            txtDateAgenda.Value = DateTime.Now;
            txtTitre.Focus();
        }

        private void UpdateAgendaGrid()
        {
            try
            {
                // Récupérer les agendas pour ce médecin, trier par date
                var agendas = db.Agendas
                                .Where(a => a.DatePlanifier > DateTime.Now && a.IdMedcin == idMedecin)
                                .OrderBy(a => a.DatePlanifier)
                                .ToList();

                // Vérifier si des agendas ont été récupérés
                if (agendas.Any())
                {
                    // Assigner les agendas comme source de données pour le DataGridView
                    dgAgenda.DataSource = agendas;

                    // Optionnel : Rafraîchir les colonnes pour qu'elles soient bien mises à jour
                    dgAgenda.Refresh();
                }
                else
                {
                    // Si aucun agenda n'est trouvé, afficher un message
                    MessageBox.Show("Aucun agenda à afficher pour ce médecin.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Si une erreur survient, afficher un message d'erreur
                MessageBox.Show($"Erreur lors de la récupération des agendas : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnChoisir_Click(object sender, EventArgs e)
        {
            txtTitre.Text = dgAgenda.CurrentRow.Cells["Titre"].Value.ToString();
            txtCreneau.Text = dgAgenda.CurrentRow.Cells["Creneau"].Value.ToString();
            txtHeureDebut.Text = dgAgenda.CurrentRow.Cells["HeureDebut"].Value.ToString();
            txtLieu.Text = dgAgenda.CurrentRow.Cells["Lieu"].Value.ToString();
            txtHeureFin.Text = dgAgenda.CurrentRow.Cells["HeureFin"].Value.ToString();
            txtDateAgenda.Value = Convert.ToDateTime(dgAgenda.CurrentRow.Cells["DatePlanifier"].Value);
        }

        private void btnReporter_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgAgenda.CurrentRow.Cells["Id"].Value);
            var agenda = db.Agendas.Find(id);
            if (agenda != null)
            {
                agenda.Creneau = int.Parse(txtCreneau.Text);
                agenda.HeureDebut = txtHeureDebut.Text;
                agenda.HeureFin = txtHeureFin.Text;
                agenda.Lieu = txtLieu.Text;
                agenda.Titre = txtTitre.Text;
                agenda.DatePlanifier = txtDateAgenda.Value;
                agenda.statut = "Brouillon";
                db.SaveChanges();
                UpdateAgendaGrid(); // Rafraîchir le DataGridView
                ResetForm(); // Réinitialiser le formulaire
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgAgenda.CurrentRow.Cells["Id"].Value);
            var agenda = db.Agendas.Find(id);
            if (agenda != null)
            {
                db.Agendas.Remove(agenda);
                db.SaveChanges();
                UpdateAgendaGrid(); // Rafraîchir le DataGridView
                ResetForm(); // Réinitialiser le formulaire
            }
        }

        private void dgAgenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ceci peut être utilisé pour gérer un clic sur le DataGridView si nécessaire
        }
    }
}
