using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppGestionRendezVous.Migrations;
using AppGestionRendezVous.Model;


namespace AppGestionRendezVous.View
{
    public partial class frmPatient : Form
    {
        private bool enModification = false;
        public frmPatient()
        {
            InitializeComponent();
        }
        BdRvMedicalContext db= new BdRvMedicalContext();

        private void ResetForm()
        {
            txtAdresse.Text= string.Empty;
            txtNomPrenom.Text = string.Empty; 
            txtEmail.Text= string.Empty;
            txtTelephone.Text= string.Empty;
            cbbGroupeSanguin.SelectedValue = string.Empty;
            cbbGroupeSanguin.DataSource = LoadCbbGroupeSanguin();
            cbbGroupeSanguin.DisplayMember = "Text"; // Propriété à afficher
            cbbGroupeSanguin.ValueMember = "Value"; // Valeur associée à chaque élément

            txtPoids.Text= string.Empty;
            txtTaille.Text= string.Empty;
            dgPatient.DataSource= db.Patients.ToList();
            txtNomPrenom.Focus();
        }


        private void btnAjouter_Click(object sender, EventArgs e)
        {
            // Vérifier si un groupe sanguin est sélectionné
            Patient p = new Patient
            {
                NomPrenom = txtNomPrenom.Text,
                Adresse = txtAdresse.Text,
                Email = txtEmail.Text,
                Tel = txtTelephone.Text,
            };

            // Récupérer la valeur du groupe sanguin sélectionné
            if (int.TryParse(cbbGroupeSanguin.SelectedValue?.ToString(), out int groupeSanguinId))
            {
                p.IdGroupeSanguin = groupeSanguinId;
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un groupe sanguin valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Conversion de la taille
            if (float.TryParse(txtTaille.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float taille))
            {
                p.Taille = taille;
            }
            else
            {
                MessageBox.Show("Veuillez entrer une valeur valide pour la taille.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Conversion du poids
            if (float.TryParse(txtPoids.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float poids))
            {
                p.Poids = poids;
            }
            else
            {
                MessageBox.Show("Veuillez entrer une valeur valide pour le poids.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ajouter le patient à la base de données
            db.Patients.Add(p);
            // Exemple d'appel dans la méthode Main ou ailleurs dans votre code
            

            db.SaveChanges();

            // Réinitialiser le formulaire
            ResetForm();
        }



        private void frmPatient_Load(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnChoisir_Click(object sender, EventArgs e)
        {
            if (dgPatient.CurrentRow != null)
            {
                var row = dgPatient.CurrentRow;

                txtNomPrenom.Text = row.Cells["NomPrenom"]?.Value?.ToString();
                txtAdresse.Text = row.Cells["Adresse"]?.Value?.ToString();
                txtEmail.Text = row.Cells["Email"]?.Value?.ToString();
                txtTelephone.Text = row.Cells["Tel"]?.Value?.ToString();

                if (int.TryParse(row.Cells["IdGroupeSanguin"]?.Value?.ToString(), out int groupeSanguinId))
                {
                    cbbGroupeSanguin.SelectedValue = groupeSanguinId.ToString();
                }
                else
                {
                    cbbGroupeSanguin.SelectedValue = "";
                }


                txtPoids.Text = row.Cells["Poids"]?.Value?.ToString();
                txtTaille.Text = row.Cells["Taille"]?.Value?.ToString();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un patient dans la liste.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private List<SelectListViewModel> LoadCbbGroupeSanguin()
        {
            var groupesSanguins = db.GroupeSanguins.ToList();
            List<SelectListViewModel> list = new List<SelectListViewModel>
    {
        new SelectListViewModel { Text = "Sélectionnez...", Value = "" }
    };

            list.AddRange(groupesSanguins.Select(g => new SelectListViewModel
            {
                Text = g.CodeGroupeSanguin, // Le nom du groupe sanguin à afficher
                Value = g.IdGroupeSanguin.ToString() // L'ID du groupe sanguin à utiliser comme valeur
            }));

            return list;
        }




        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgPatient.CurrentRow != null)
            {
              
                var cellValue = dgPatient.CurrentRow.Cells["IdU"]?.Value;

                if (cellValue != null && int.TryParse(cellValue.ToString(), out int id))
                {
                    btnAjouter.Enabled = false;
                    var p = db.Patients.Find(id);
                    if (p != null)
                    {
                        // Mise à jour des propriétés du patient
                        p.NomPrenom = txtNomPrenom.Text;
                        p.Adresse = txtAdresse.Text;
                        p.Email = txtEmail.Text;
                        p.Tel = txtTelephone.Text;

                        if (int.TryParse(cbbGroupeSanguin.SelectedValue?.ToString(), out int groupeSanguinId))
                        {
                            p.IdGroupeSanguin = groupeSanguinId;
                        }
                        else
                        {
                            MessageBox.Show("Veuillez sélectionner un groupe sanguin valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (float.TryParse(txtTaille.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float taille))
                        {
                            p.Taille = taille;
                        }
                        else
                        {
                            MessageBox.Show("Veuillez entrer une valeur valide pour la taille.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (float.TryParse(txtPoids.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float poids))
                        {
                            p.Poids = poids;
                        }
                        else
                        {
                            MessageBox.Show("Veuillez entrer une valeur valide pour le poids.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        db.SaveChanges();
                        ResetForm();
                    }
                    else
                    {
                        MessageBox.Show("Patient introuvable.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Identifiant de patient invalide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un patient à modifier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSuprimer_Click(object sender, EventArgs e)
        {
            // Vérifier si une ligne est sélectionnée
            if (dgPatient.CurrentRow != null)
            {
                // Vérifier que la cellule à l'index 3 existe bien dans la ligne sélectionnée
                var cellValue = dgPatient.CurrentRow.Cells["IdU"]?.Value;

                // Vérifier si la cellule contient une valeur
                if (cellValue != null)
                {
                    // Tenter de convertir la valeur en entier
                    if (int.TryParse(cellValue.ToString(), out int id))
                    {
                        try
                        {
                            // Rechercher le patient par ID
                            var p = db.Patients.Find(id);
                            if (p != null)
                            {
                                // Supprimer le patient de la base de données
                                db.Patients.Remove(p);
                                db.SaveChanges();
                                MessageBox.Show("Patient supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ResetForm(); // Réinitialiser le formulaire
                            }
                            else
                            {
                                MessageBox.Show("Patient introuvable.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        catch (Exception ex)
                        {
                            // Gérer d'éventuelles erreurs lors de la suppression
                            MessageBox.Show($"Une erreur est survenue lors de la suppression : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Identifiant invalide. Assurez-vous que la cellule contient un entier valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Aucune valeur trouvée dans la cellule d'identifiant.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void btnRv_Click(object sender, EventArgs e)
        {
            if (dgPatient.CurrentRow == null)
            {
                MessageBox.Show("Aucune ligne sélectionnée dans la liste des patients.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgPatient.CurrentRow;

            // Vérifie si les colonnes existent avant d'y accéder
            if (!dgPatient.Columns.Contains("NomPrenom") || !dgPatient.Columns.Contains("Tel"))
            {
                MessageBox.Show("Les colonnes 'NomPrenom' ou 'Tel' sont introuvables dans la table des patients.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Récupération sécurisée des valeurs
            string nomPrenom = row.Cells["NomPrenom"].Value?.ToString()?.Trim();
            string telephone = row.Cells["Tel"].Value?.ToString()?.Trim();

            if (string.IsNullOrEmpty(nomPrenom) || string.IsNullOrEmpty(telephone))
            {
                MessageBox.Show("Le nom ou le numéro de téléphone est vide. Veuillez vérifier les données.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmRendezVous f = new frmRendezVous(nomPrenom, telephone);
            f.Show();
        }


        // Déclarer une liste de patients pour stocker les données chargées
        private List<Patient> listePatients = new List<Patient>();

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            // Si la listePatients est vide, on la charge avec tous les patients
            if (listePatients == null || !listePatients.Any())
            {
                // Charger tous les patients uniquement si la liste est vide ou nulle
                listePatients = db.Patients.ToList();
            }

            // Filtrer la liste en fonction des critères de recherche
            var filteredList = listePatients.AsQueryable(); // Utiliser AsQueryable() pour appliquer des filtres dynamiques

            // Recherche par email exact si un email est saisi
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                filteredList = filteredList.Where(a => a.Email.ToUpper() == txtEmail.Text.ToUpper()); // Recherche exacte sur l'email
            }

            // Recherche par téléphone exact si un numéro de téléphone est saisi
            if (!string.IsNullOrEmpty(txtTelephone.Text))
            {
                filteredList = filteredList.Where(a => a.Tel.ToUpper() == txtTelephone.Text.ToUpper()); // Recherche exacte sur le téléphone
            }

            // Mettre à jour le DataGridView avec la liste filtrée
            dgPatient.DataSource = filteredList.ToList();
        }




        private void dgPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
  }


