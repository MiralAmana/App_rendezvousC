namespace AppGestionRendezVous.View
{
    partial class frmRendezVous
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMedecin = new System.Windows.Forms.Label();
            this.cbbSoins = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbModePayment = new System.Windows.Forms.ComboBox();
            this.cbbMedecin = new System.Windows.Forms.ComboBox();
            this.txtCout = new System.Windows.Forms.TextBox();
            this.txtReferencePayment = new System.Windows.Forms.TextBox();
            this.Creneaux = new System.Windows.Forms.ListBox();
            this.dgRendezVous = new System.Windows.Forms.DataGridView();
            this.txtNumRecu = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnValider = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.lblIdMedecins = new System.Windows.Forms.Label();
            this.btnFermer = new System.Windows.Forms.Button();
            this.btnImprimer = new System.Windows.Forms.Button();
            this.Telephone = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomPrenom = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgRendezVous)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMedecin
            // 
            this.lblMedecin.AutoSize = true;
            this.lblMedecin.Location = new System.Drawing.Point(41, 353);
            this.lblMedecin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMedecin.Name = "lblMedecin";
            this.lblMedecin.Size = new System.Drawing.Size(0, 16);
            this.lblMedecin.TabIndex = 0;
            // 
            // cbbSoins
            // 
            this.cbbSoins.FormattingEnabled = true;
            this.cbbSoins.Location = new System.Drawing.Point(41, 254);
            this.cbbSoins.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbSoins.Name = "cbbSoins";
            this.cbbSoins.Size = new System.Drawing.Size(313, 24);
            this.cbbSoins.TabIndex = 1;
            this.cbbSoins.SelectedIndexChanged += new System.EventHandler(this.cbbSoins_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 228);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Soin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 289);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Cout";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 481);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Reference Payment";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 420);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Mode Payment";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 358);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Medecin";
            // 
            // cbbModePayment
            // 
            this.cbbModePayment.FormattingEnabled = true;
            this.cbbModePayment.Location = new System.Drawing.Point(41, 446);
            this.cbbModePayment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbModePayment.Name = "cbbModePayment";
            this.cbbModePayment.Size = new System.Drawing.Size(313, 24);
            this.cbbModePayment.TabIndex = 7;
            // 
            // cbbMedecin
            // 
            this.cbbMedecin.FormattingEnabled = true;
            this.cbbMedecin.Location = new System.Drawing.Point(41, 384);
            this.cbbMedecin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbMedecin.Name = "cbbMedecin";
            this.cbbMedecin.Size = new System.Drawing.Size(313, 24);
            this.cbbMedecin.TabIndex = 8;
            this.cbbMedecin.SelectedIndexChanged += new System.EventHandler(this.cbbMedecin_SelectedIndexChanged);
            // 
            // txtCout
            // 
            this.txtCout.Enabled = false;
            this.txtCout.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCout.Location = new System.Drawing.Point(41, 315);
            this.txtCout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCout.Name = "txtCout";
            this.txtCout.ReadOnly = true;
            this.txtCout.Size = new System.Drawing.Size(317, 27);
            this.txtCout.TabIndex = 9;
            // 
            // txtReferencePayment
            // 
            this.txtReferencePayment.Location = new System.Drawing.Point(41, 507);
            this.txtReferencePayment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtReferencePayment.Name = "txtReferencePayment";
            this.txtReferencePayment.Size = new System.Drawing.Size(313, 22);
            this.txtReferencePayment.TabIndex = 10;
            // 
            // Creneaux
            // 
            this.Creneaux.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Creneaux.FormattingEnabled = true;
            this.Creneaux.ItemHeight = 17;
            this.Creneaux.Location = new System.Drawing.Point(427, 75);
            this.Creneaux.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Creneaux.Name = "Creneaux";
            this.Creneaux.Size = new System.Drawing.Size(197, 616);
            this.Creneaux.TabIndex = 11;
            this.Creneaux.SelectedIndexChanged += new System.EventHandler(this.lslHoraire_SelectedIndexChanged);
            // 
            // dgRendezVous
            // 
            this.dgRendezVous.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgRendezVous.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRendezVous.Location = new System.Drawing.Point(632, 68);
            this.dgRendezVous.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgRendezVous.Name = "dgRendezVous";
            this.dgRendezVous.RowHeadersWidth = 51;
            this.dgRendezVous.Size = new System.Drawing.Size(1005, 629);
            this.dgRendezVous.TabIndex = 15;
            this.dgRendezVous.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRendezVous_CellContentClick);
            // 
            // txtNumRecu
            // 
            this.txtNumRecu.Location = new System.Drawing.Point(41, 567);
            this.txtNumRecu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNumRecu.Name = "txtNumRecu";
            this.txtNumRecu.Size = new System.Drawing.Size(313, 22);
            this.txtNumRecu.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 542);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Numero Recu";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(41, 602);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "Date Demande";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(41, 628);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(313, 22);
            this.dateTimePicker1.TabIndex = 19;
            // 
            // btnValider
            // 
            this.btnValider.BackColor = System.Drawing.Color.Lime;
            this.btnValider.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValider.Location = new System.Drawing.Point(16, 753);
            this.btnValider.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(141, 34);
            this.btnValider.TabIndex = 20;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = false;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.Red;
            this.btnAnnuler.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.Location = new System.Drawing.Point(427, 753);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(141, 34);
            this.btnAnnuler.TabIndex = 21;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.Color.Blue;
            this.btnModifier.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifier.Location = new System.Drawing.Point(215, 753);
            this.btnModifier.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(141, 34);
            this.btnModifier.TabIndex = 22;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = false;
            // 
            // lblIdMedecins
            // 
            this.lblIdMedecins.AutoSize = true;
            this.lblIdMedecins.Location = new System.Drawing.Point(129, 706);
            this.lblIdMedecins.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdMedecins.Name = "lblIdMedecins";
            this.lblIdMedecins.Size = new System.Drawing.Size(0, 16);
            this.lblIdMedecins.TabIndex = 23;
            // 
            // btnFermer
            // 
            this.btnFermer.BackColor = System.Drawing.Color.Blue;
            this.btnFermer.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFermer.Location = new System.Drawing.Point(641, 26);
            this.btnFermer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(141, 34);
            this.btnFermer.TabIndex = 24;
            this.btnFermer.Text = "Fermer";
            this.btnFermer.UseVisualStyleBackColor = false;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            // 
            // btnImprimer
            // 
            this.btnImprimer.Location = new System.Drawing.Point(427, 13);
            this.btnImprimer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnImprimer.Name = "btnImprimer";
            this.btnImprimer.Size = new System.Drawing.Size(100, 28);
            this.btnImprimer.TabIndex = 25;
            this.btnImprimer.Text = "Imprimer";
            this.btnImprimer.UseVisualStyleBackColor = true;
            this.btnImprimer.Click += new System.EventHandler(this.btnImprimer_Click);
            // 
            // Telephone
            // 
            this.Telephone.AutoSize = true;
            this.Telephone.Location = new System.Drawing.Point(41, 166);
            this.Telephone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Telephone.Name = "Telephone";
            this.Telephone.Size = new System.Drawing.Size(73, 16);
            this.Telephone.TabIndex = 26;
            this.Telephone.Text = "Telephone";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "Nom Prenom Patient";
            // 
            // txtNomPrenom
            // 
            this.txtNomPrenom.Location = new System.Drawing.Point(45, 126);
            this.txtNomPrenom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNomPrenom.Name = "txtNomPrenom";
            this.txtNomPrenom.Size = new System.Drawing.Size(309, 22);
            this.txtNomPrenom.TabIndex = 31;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(41, 199);
            this.txtTel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(309, 22);
            this.txtTel.TabIndex = 32;
            // 
            // frmRendezVous
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1717, 876);
            this.ControlBox = false;
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtNomPrenom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Telephone);
            this.Controls.Add(this.btnImprimer);
            this.Controls.Add(this.btnFermer);
            this.Controls.Add(this.lblIdMedecins);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNumRecu);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgRendezVous);
            this.Controls.Add(this.Creneaux);
            this.Controls.Add(this.txtReferencePayment);
            this.Controls.Add(this.txtCout);
            this.Controls.Add(this.cbbMedecin);
            this.Controls.Add(this.cbbModePayment);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbSoins);
            this.Controls.Add(this.lblMedecin);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmRendezVous";
            this.Text = "Rendez Vous";
            this.Load += new System.EventHandler(this.frmRendezVous_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgRendezVous)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMedecin;
        private System.Windows.Forms.ComboBox cbbSoins;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbModePayment;
        private System.Windows.Forms.ComboBox cbbMedecin;
        private System.Windows.Forms.TextBox txtCout;
        private System.Windows.Forms.TextBox txtReferencePayment;
        private System.Windows.Forms.ListBox Creneaux;
        private System.Windows.Forms.DataGridView dgRendezVous;
        private System.Windows.Forms.TextBox txtNumRecu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Label lblIdMedecins;
        private System.Windows.Forms.Button btnFermer;
        private System.Windows.Forms.Button btnImprimer;
        private System.Windows.Forms.Label Telephone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomPrenom;
        private System.Windows.Forms.TextBox txtTel;
    }
}