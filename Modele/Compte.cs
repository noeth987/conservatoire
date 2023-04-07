using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Banque.Modele
{
   
   /// <summary>
   /// Classe qui gère les comptes
   /// </summary>
 
    
    [Serializable]
    public abstract class Compte
    {

        protected int num;
        protected Client proprio;
        public double solde = 0;


        public int Num { get => num; }

   
   /// <summary>
   /// méthode qui affecte un certain montant de découvert
   /// </summary>
   /// <param name="value">double représentant le découvert</param>
        
        

        public Compte(int n, Client c)
		{
			this.num = n;
			this.solde =0;
			this.proprio = c;
           // this.proprio.ajouterCompte(this);
        }



		public virtual string Description
		{
            get => "Compte n° " + num + " " + " Client :  " + proprio + " " + " solde : " + solde + " €" ; 
		}

        public Client Propriétaire
        {
            get { return proprio; }
        }

        protected double Solde { get => solde; }

        public void crediter(double mont)
		{
			solde = solde+mont;
		}

		public abstract bool debiter(double mont);
		
		
    }
}
