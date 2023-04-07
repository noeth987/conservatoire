using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO ;
using System.Runtime.Serialization.Formatters.Binary ;

using Banque.Modele;



namespace Banque.Vue
{
    
    [Serializable]
    public partial class Gestion : Form
    {

  public   List<Compte> lstcpt = new List<Compte>();

   
       
        public Gestion()
        {
            InitializeComponent();
        }

        private void crediterToolStripMenuItem_Click(object sender, EventArgs e)
        {

            lab.Visible = true;
            lab.Text = "Montant à créditer";

            bouton.Visible = true;
            bouton.Text = "Valider le crédit";

            tb.Visible = true;

        }

      

        private void debiterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lab.Visible = true;
            lab.Text = "Montant à débiter";

            bouton.Visible = true;
            bouton.Text = "Valider le débit";
            

            tb.Visible = true;
        }

        private void bouton_Click(object sender, EventArgs e)
        {
   
                int i;

                i = lBox.SelectedIndex;

             //   Compte c = lstcpt[i];


                Compte c = (Compte)lBox.SelectedItem;
            


                if (bouton.Text == "Valider le crédit")
                {

                    c.crediter(Convert.ToDouble(tb.Text));

                }


                // On ne débite que si le retour de la méthode est à true sinon on affiche un message

                if (bouton.Text == "Valider le débit")
                {


                    if (!c.debiter(Convert.ToDouble(tb.Text))) { MessageBox.Show("Debit interdit"); }

                    tb.Clear();
                }




                if (bouton.Text == "Valider le découvert")
                {

                try
                {
                    if (c.GetType().Name == "CompteCourant")
                    {
                        if (!((CompteCourant)c).setDecouv(Convert.ToDouble(tb.Text))) { MessageBox.Show("attention changement de découvert interdit !"); }

                        //   c.Decouv = Convert.ToDouble(tb.Text);
                    }

                   
                }

                catch (Exception Ex)
                {
                    //     MessageBox.Show("" + Ex.Message);

                }

                }



                rafraichirListBox();

            


        }

        private void découvertToolStripMenuItem_Click(object sender, EventArgs e)
        {


            lab.Visible = true;
            lab.Text = "Montant du nouveau découvert";

            bouton.Visible = true;
            bouton.Text = "Valider le découvert";


            tb.Visible = true;

        }


        private void rafraichirListBox()
        {

            lBox.DataSource = null;
            lBox.DataSource = lstcpt;
            lBox.DisplayMember = "Description";

        }

        private void Gestion_Load(object sender, EventArgs e)
        {
            /*Client cl1 = new Client(1, "Dupont", "toto", "Créteil");
            Client cl2 = new Client(2, "Abdala", "momo", "Cachan");


            Compte c1 = new CompteCourant(12, cl1);
            Compte c2 = new CompteCourant(12, cl1);

            Compte c3 = new CompteEpargne(11, cl2,1.2);

            Compte c4 = new CompteCourant(9, cl1);

            lstcpt.Add(c1);

            lstcpt.Add(c3);
            lstcpt.Add(c4);
            */

            Serialise.chargement();
            
            lstcpt = Serialise.Lstcpt;


            rafraichirListBox();
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Compte c = (Compte)lBox.SelectedItem;

            Client cl = c.Propriétaire;

            FormClient fc = new FormClient(cl);

            fc.ShowDialog();

            rafraichirListBox();


        }

        private void lBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        //    Compte c = (Compte)lBox.SelectedItem;
         //   MessageBox.Show(c.GetType().Name);
        }

        private void Gestion_FormClosing(object sender, FormClosingEventArgs e)
        {
            Serialise.sauvegarde(lstcpt);
        }
    }
}
