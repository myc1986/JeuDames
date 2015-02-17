using System.Windows.Forms;
namespace APIJeuMorpionCsharp.Formes
{
    partial class FormPlateau : Form
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.flp_terrain = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flp_terrain
            // 
            this.flp_terrain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_terrain.Location = new System.Drawing.Point(0, 0);
            this.flp_terrain.Name = "flp_terrain";
            this.flp_terrain.Size = new System.Drawing.Size(584, 561);
            this.flp_terrain.TabIndex = 0;
            this.flp_terrain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.flp_terrain_MouseClick);
            // 
            // FormPlateau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.flp_terrain);
            this.Name = "FormPlateau";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormPlateau_Load);
            this.MouseCaptureChanged += new System.EventHandler(this.FormPlateau_MouseCaptureChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flp_terrain;
    }
}

