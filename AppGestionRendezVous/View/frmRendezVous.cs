using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AppGestionRendezVous.Model;

namespace AppGestionRendezVous.View
{
    public partial class frmRendezVous : Form
    {
        private string nomPrenom;
        private string telephone;
       

        public string NomPrenom { get; }
        public string Telephone1 { get; }
        public frmRendezVous()
        {
            InitializeComponent();
        }
        BdRvMedicalContext db = new BdRvMedicalContext();



        public frmRendezVous(string nomPrenom, string telephone)
        {
            InitializeComponent();
            this.nomPrenom = nomPrenom;
            this.telephone = telephone;

            // Assurez-vous que les contrôles existent et qu'ils sont accessibles
            txtNomPrenom.Text = nomPrenom;
            txtTel.Text = telephone;
        }

        private void frmRendezVous_Load(object sender, EventArgs e)
        {
            ResetForm();
            ChargerRendezVous(); // Charge les rendez-vous existants
        }
        

        private void ResetForm()
        {
           
            cbbMedecin.SelectedValue = string.Empty;
            cbbMedecin.DataSource = LoadcbbPatient();
            cbbMedecin.ValueMember = "Value";
            cbbMedecin.DisplayMember = "Text";

            cbbModePayment.SelectedValue = string.Empty;
            cbbModePayment.DataSource = LoadcbbModePay();
            cbbModePayment.ValueMember = "Value";
            cbbModePayment.DisplayMember = "Text";

            cbbSoins.SelectedValue = string.Empty;
            cbbSoins.DataSource = LoadcbbSoins();
            cbbSoins.ValueMember = "Value";
            cbbSoins.DisplayMember = "Text";
          
        }

        private List<SelectListViewModel> LoadcbbPatient()
        {
            var m = db.Medecins.ToList();
            List<SelectListViewModel> list = new List<SelectListViewModel>();
            SelectListViewModel b = new SelectListViewModel { Text = "Selectionnez...", Value = "" };
            list.Add(b);
            foreach (var c in m)
            {
                SelectListViewModel a = new SelectListViewModel { Text = c.NomPrenom, Value = c.IdU.ToString() };
                list.Add(a);
            }
            return list;
        }

        private List<SelectListViewModel> LoadcbbSoins()
        {
            var soinsList = db.soins.ToList();
            List<SelectListViewModel> list = new List<SelectListViewModel>();

            SelectListViewModel defaultItem = new SelectListViewModel
            {
                Text = "Sélectionnez...",
                Value = ""
            };
            list.Add(defaultItem);

            foreach (var soin in soinsList)
            {
                SelectListViewModel soinItem = new SelectListViewModel
                {
                    Text = soin.Description,
                    Value = soin.IdSoin.ToString() // Assurez-vous que c'est bien l'ID du soin
                };
                list.Add(soinItem);
            }

            return list;
        }

        private List<SelectListViewModel> LoadcbbModePay()
        {
            var soinsList = db.MoyenPayment.ToList();
            List<SelectListViewModel> list = new List<SelectListViewModel>();

            SelectListViewModel defaultItem = new SelectListViewModel
            {
                Text = "Sélectionnez...",
                Value = ""
            };
            list.Add(defaultItem);

            foreach (var soin in soinsList)
            {
                SelectListViewModel soinItem = new SelectListViewModel
                {
                    Text = soin.Libelle,
                    Value = soin.IdModePayment.ToString() // Assurez-vous que c'est bien l'ID du soin
                };
                list.Add(soinItem);
            }

            return list;
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Affichage du coût du soin sélectionné
        private void cbbSoins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSoins.SelectedIndex > 0)  // Si un soin est sélectionné
            {
                var selectedValue = cbbSoins.SelectedValue?.ToString();

                if (int.TryParse(selectedValue, out int soinId))
                {
                    var soin = db.soins.FirstOrDefault(s => s.IdSoin == soinId);

                    if (soin != null)
                    {
                        txtCout.Text = $"{soin.cout:N0} FCFA";  // Afficher le coût en format monétaire
                    }
                    else
                    {
                        txtCout.Clear();
                    }
                }
                else
                {
                    txtCout.Clear();
                }
            }
            else
            {
                txtCout.Clear();
            }
        }

       

        private void cbbMedecin_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedMedecinId = cbbMedecin.SelectedValue?.ToString();

            if (int.TryParse(selectedMedecinId, out int medecinId))
            {
                var medecin = db.Medecins
                    .Include("Agenda")
                    .FirstOrDefault(m => m.IdU == medecinId);

                if (medecin != null && medecin.Agenda != null)
                {
                    var agendaMedecin = medecin.Agenda.FirstOrDefault();

                    if (agendaMedecin != null)
                    {
                        GenererCreneaux(agendaMedecin);
                        ChargerCreneaux(agendaMedecin); // Charger les créneaux dans le ListView
                    }
                }
            }
        }

        // Méthode pour générer les créneaux horaires pour un agenda
        private void GenererCreneaux(Agenda agenda)
        {
            // Convertir les chaînes en TimeSpan
            TimeSpan heureDebut = TimeSpan.Parse(agenda.HeureDebut); // Convertir la chaîne en TimeSpan
            TimeSpan heureFin = TimeSpan.Parse(agenda.HeureFin); // Convertir la chaîne en TimeSpan

            agenda.Creneaux.Clear(); // Vider la liste des créneaux existants

            while (heureDebut < heureFin)
            {
                // Créer un créneau avec HeureDebut et HeureFin en tant que chaînes de caractères
                var creneau = new Creneau
                {
                    IdAgenda = agenda.IdAgenda,
                    Date = agenda.DatePlanifier, // Assurez-vous que la date est bien assignée
                    HeureDebut = heureDebut.ToString(@"hh\:mm"), // Convertir TimeSpan en chaîne au format "hh:mm"
                    HeureFin = heureDebut.Add(TimeSpan.FromMinutes(agenda.Creneau)).ToString(@"hh\:mm"), // Calculer HeureFin et la convertir en chaîne
                    Disponible = true // On suppose que tous les créneaux sont disponibles au début
                };

                agenda.Creneaux.Add(creneau);

                // Passer au créneau suivant
                heureDebut = heureDebut.Add(TimeSpan.FromMinutes(agenda.Creneau)); // Passer au créneau suivant
            }
        }





        // Méthode pour charger les créneaux dans le ListView
        private void ChargerCreneaux(Agenda agenda)
        {
            Creneaux.Items.Clear();  // Vider le ListBox

            foreach (var creneau in agenda.Creneaux)
            {
                // Formater les heures de début et de fin
                string horaire = $"{creneau.HeureDebut} - {creneau.HeureFin}";

                // Ajouter l'élément au ListBox
                Creneaux.Items.Add(horaire);
            }
        }


        private void btnValider_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérification des champs obligatoires
                if (cbbMedecin.SelectedValue == null)
                {
                    MessageBox.Show("Veuillez sélectionner un médecin.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbbSoins.SelectedValue == null)
                {
                    MessageBox.Show("Veuillez sélectionner un soin.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbbModePayment.SelectedValue == null)
                {
                    MessageBox.Show("Veuillez sélectionner un mode de paiement.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Creneaux.SelectedItem == null)
                {
                    MessageBox.Show("Veuillez choisir un créneau.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNomPrenom.Text))
                {
                    MessageBox.Show("Veuillez entrer le nom et prénom du patient.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTel.Text))
                {
                    MessageBox.Show("Veuillez entrer le numéro de téléphone du patient.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Vérification de l'existence du patient
                Patient patient = db.Patients.FirstOrDefault(p => p.Tel == txtTel.Text.Trim());

                if (patient == null)
                {
                    MessageBox.Show("Le patient n'existe pas dans la base de données. Veuillez l'ajouter avant de prendre un rendez-vous.",
                                    "Patient introuvable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Création d'un nouvel objet RendezVous
                // Now proceed with creating the RendezVous object
                RendezVous r = new RendezVous
                {
                    IdPatient = patient.IdU,
                    IdMedcin = Convert.ToInt32(cbbMedecin.SelectedValue),
                    IdSoin = Convert.ToInt32(cbbSoins.SelectedValue),
                    IdMoyenPay = Convert.ToInt32(cbbModePayment.SelectedValue),
                    NumRecu = txtNumRecu.Text.Trim(),
                    ReferencePayment = txtReferencePayment.Text.Trim(),
                    Creneau = Creneaux.SelectedItem.ToString(),
                    DateRv = DateTime.Now
                };

                // Add and save
                db.RendezVous.Add(r);
                db.SaveChanges();

                // Rafraîchir la liste des rendez-vous
                ChargerRendezVous();

                MessageBox.Show("Rendez-vous ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Réinitialisation du formulaire
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur inattendue est survenue : {ex.Message}\n\nDétails : {ex.InnerException?.Message}",
                                "Erreur système", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ChargerRendezVous()
        {
            dgRendezVous.DataSource = null; // Réinitialise la source des données
            var listeRendezVous = db.RendezVous.Select(r => new
            {
                r.IdRendezVous,
                Patient = r.Patient.NomPrenom,
                Medecin = r.Medecin.NomPrenom,
                Soin = r.Soin.Description,
                Paiement = r.MoyenPayment.Libelle,
                r.NumRecu,
                r.ReferencePayment,
                r.Creneau,
                r.DateRv
            }).ToList();

            dgRendezVous.DataSource = listeRendezVous; // Lier la liste au DataGridView
        }


        private void lslHoraire_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgRendezVous_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            frmPrintTicket frm = new frmPrintTicket();
            frm.ShowDialog();
        }

    }
}