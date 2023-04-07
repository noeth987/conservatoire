using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banque.Modele
{

    [Serializable]
   public class CompteCourant : Compte
    {
        
        private double decouv = 0;

        public CompteCourant(int n, Client c) : base (n,c)
        {


        }


        public bool setDecouv(double value)
        {
            bool res = false;


            if (this.solde > -value)
            {
                decouv = value;
                res = true;

            }

            else
            {
                // Propager une exception

            }
            return (res);

        }


        // On peut aussi utiliser celui là....
        // Set utilisé avec l'outil d'encapsultation
        /// <summary>
        /// méthode qui affecte un certain montant de découvert
        /// </summary>
        /// <param name="value">double représentant le découvert</param>
        public double Decouv
        {
            get => decouv;

            set
            {
                if (this.solde >= (-value)) { decouv = value; }

                else
                {
                    // Propager une exception

                }


            }
        }
            public override bool debiter(double mont)
        {
            if (solde - mont < -decouv)
            {
                return false;
            }
            else
            {
                solde = solde - mont;
                return true;
            }
        }

        public override string Description
        {
            get => base.Description + " - decouvert : " + this.decouv;
        }

    }

    }

