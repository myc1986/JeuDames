using System.Windows.Forms;
namespace APIJeuMorpionCsharp.Formes
{
    partial class FrmConfiguration : Form
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
            this.txt_nom = new System.Windows.Forms.TextBox();
            this.grp_nouveauJoueur = new System.Windows.Forms.GroupBox();
            this.btn_ajouter = new System.Windows.Forms.Button();
            this.lbl_nom = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_tailleTerrain = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grp_joueurs = new System.Windows.Forms.GroupBox();
            this.lst_joueurs = new System.Windows.Forms.ListBox();
            this.btn_lancer = new System.Windows.Forms.Button();
            this.btn_quitter = new System.Windows.Forms.Button();
            this.grp_nouveauJoueur.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grp_joueurs.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_nom
            // 
            this.txt_nom.Location = new System.Drawing.Point(55, 19);
            this.txt_nom.Name = "txt_nom";
            this.txt_nom.Size = new System.Drawing.Size(147, 20);
            this.txt_nom.TabIndex = 0;
            // 
            // grp_nouveauJoueur
            // 
            this.grp_nouveauJoueur.Controls.Add(this.btn_ajouter);
            this.grp_nouveauJoueur.Controls.Add(this.lbl_nom);
            this.grp_nouveauJoueur.Controls.Add(this.txt_nom);
            this.grp_nouveauJoueur.Location = new System.Drawing.Point(12, 12);
            this.grp_nouveauJoueur.Name = "grp_nouveauJoueur";
            this.grp_nouveauJoueur.Size = new System.Drawing.Size(208, 73);
            this.grp_nouveauJoueur.TabIndex = 1;
            this.grp_nouveauJoueur.TabStop = false;
            this.grp_nouveauJoueur.Text = "Nouveau Joueur";
            // 
            // btn_ajouter
            // 
            this.btn_ajouter.Location = new System.Drawing.Point(127, 44);
            this.btn_ajouter.Name = "btn_ajouter";
            this.btn_ajouter.Size = new System.Drawing.Size(75, 23);
            this.btn_ajouter.TabIndex = 2;
            this.btn_ajouter.Text = "Ajouter";
            this.btn_ajouter.UseVisualStyleBackColor = true;
            this.btn_ajouter.Click += new System.EventHandler(this.btn_ajouter_Click);
            // 
            // lbl_nom
            // 
            this.lbl_nom.AutoSize = true;
            this.lbl_nom.Location = new System.Drawing.Point(6, 22);
            this.lbl_nom.Name = "lbl_nom";
            this.lbl_nom.Size = new System.Drawing.Size(35, 13);
            this.lbl_nom.TabIndex = 1;
            this.lbl_nom.Text = "Nom :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txt_tailleTerrain);
            this.groupBox2.Location = new System.Drawing.Point(226, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(246, 73);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configuration";
            // 
            // txt_tailleTerrain
            // 
            this.txt_tailleTerrain.Location = new System.Drawing.Point(140, 22);
            this.txt_tailleTerrain.Name = "txt_tailleTerrain";
            this.txt_tailleTerrain.Size = new System.Drawing.Size(100, 20);
            this.txt_tailleTerrain.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Taille Terrain de jeu :";
            // 
            // grp_joueurs
            // 
            this.grp_joueurs.Controls.Add(this.lst_joueurs);
            this.grp_joueurs.Location = new System.Drawing.Point(12, 91);
            this.grp_joueurs.Name = "grp_joueurs";
            this.grp_joueurs.Size = new System.Drawing.Size(460, 149);
            this.grp_joueurs.TabIndex = 3;
            this.grp_joueurs.TabStop = false;
            this.grp_joueurs.Text = "Joueurs";
            // 
            // lst_joueurs
            // 
            this.lst_joueurs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_joueurs.FormattingEnabled = true;
            this.lst_joueurs.Location = new System.Drawing.Point(3, 16);
            this.lst_joueurs.Name = "lst_joueurs";
            this.lst_joueurs.Size = new System.Drawing.Size(454, 130);
            this.lst_joueurs.TabIndex = 0;
            // 
            // btn_lancer
            // 
            this.btn_lancer.Location = new System.Drawing.Point(372, 246);
            this.btn_lancer.Name = "btn_lancer";
            this.btn_lancer.Size = new System.Drawing.Size(100, 23);
            this.btn_lancer.TabIndex = 3;
            this.btn_lancer.Text = "Lancer partie";
            this.btn_lancer.UseVisualStyleBackColor = true;
            this.btn_lancer.Click += new System.EventHandler(this.btn_lancer_Click);
            // 
            // btn_quitter
            // 
            this.btn_quitter.Location = new System.Drawing.Point(291, 246);
            this.btn_quitter.Name = "btn_quitter";
            this.btn_quitter.Size = new System.Drawing.Size(75, 23);
            this.btn_quitter.TabIndex = 4;
            this.btn_quitter.Text = "Quitter";
            this.btn_quitter.UseVisualStyleBackColor = true;
            this.btn_quitter.Click += new System.EventHandler(this.btn_quitter_Click);
            // 
            // FrmConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 275);
            this.Controls.Add(this.btn_quitter);
            this.Controls.Add(this.btn_lancer);
            this.Controls.Add(this.grp_joueurs);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grp_nouveauJoueur);
            this.Name = "FrmConfiguration";
            this.Text = "FrmConfiguration";
            this.grp_nouveauJoueur.ResumeLayout(false);
            this.grp_nouveauJoueur.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grp_joueurs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_nom;
        private System.Windows.Forms.GroupBox grp_nouveauJoueur;
        private System.Windows.Forms.Button btn_ajouter;
        private System.Windows.Forms.Label lbl_nom;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_tailleTerrain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grp_joueurs;
        private System.Windows.Forms.ListBox lst_joueurs;
        private System.Windows.Forms.Button btn_lancer;
        private System.Windows.Forms.Button btn_quitter;
    }
}