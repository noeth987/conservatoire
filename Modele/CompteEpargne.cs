using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banque.Modele
{
    [Serializable]
    class CompteEpargne : Compte
    {
        
        static double taux;

        public CompteEpargne(int n, Client c, double unTaux) : base(n, c)
        {
            CompteEpargne.taux = unTaux;

        }


        public override bool debiter(double mont)
        {
            if (solde - mont < 0)
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
            get => base.Description + " taux : " + CompteEpargne.taux ;
        }
    }
}
