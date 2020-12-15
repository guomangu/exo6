using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comptecancaire
{
    class Program
    {
        static void Main(string[] args)
        {
            Compte compteun;
            compteun = new Compte(1,1000,"gom",-200);
            Console.WriteLine(compteun.UNnomTitulaire+" = "+compteun.UNsoldeCompte);
            
            compteun.Crediter(200);
            Console.WriteLine(compteun.UNnomTitulaire+" = "+compteun.UNsoldeCompte);

            compteun.Debiter(200);
            Console.WriteLine(compteun.UNnomTitulaire+" = "+compteun.UNsoldeCompte);

            Compte comptedeux;
            comptedeux = new Compte(1,1000,"man",-200);
            Console.WriteLine(comptedeux.UNnomTitulaire+" = "+comptedeux.UNsoldeCompte);

            compteun.Transferer(500,comptedeux);
            Console.WriteLine(compteun.UNnomTitulaire+" = "+compteun.UNsoldeCompte);
            Console.WriteLine(comptedeux.UNnomTitulaire+" = "+comptedeux.UNsoldeCompte);

            compteun.Comparer(comptedeux);

            Console.WriteLine(compteun.Infocompte());
            Console.WriteLine(comptedeux.Infocompte());

            Console . ReadKey ();
        }
    }

    public class Compte
    {

        //attributs....
        private int numeroCompte;
        private double soldeCompte;
        private string nomTitulaire;
        private double decouvert;
        
        //propriétés....
        public int UNnumeroCompte { get => numeroCompte; }
        public double UNsoldeCompte { get => soldeCompte; set => soldeCompte=value; }
        public string UNnomTitulaire { get => nomTitulaire; }
        public double UNdecouvert { get => decouvert; }

        //constructeur....
        public Compte(int UNnumeroCompte, double UNsoldeCompte, string UNnomTitulaire, double UNdecouvert)
        {
            this.numeroCompte = UNnumeroCompte;
            this.soldeCompte = UNsoldeCompte;
            this.nomTitulaire = UNnomTitulaire;
            this.decouvert = UNdecouvert;
        }
        
        //méthodes....
        public void Crediter(double _montant)
        {
            this.soldeCompte = this.soldeCompte + _montant;
            
        }

        public void Debiter(double _montant)
        {
            if (this.soldeCompte-_montant<this.decouvert) {
                Console.WriteLine("Pas autorisé"); 
                return;
            } else { 
                Console.WriteLine("OK"); 
            }
            this.soldeCompte = this.soldeCompte - _montant;
            
        }

        public void Transferer(double _montant,Compte com)
        {
            com.Crediter(_montant);
            Debiter(_montant);
        }
        public void Comparer(Compte com)
        {
            double dif=0;
            if (this.soldeCompte>com.soldeCompte)
	        {
                dif=this.soldeCompte-com.soldeCompte;
	        }else
	        {
                dif=com.soldeCompte-this.soldeCompte;
	        }
            Console.WriteLine("Il y a une difference de "+dif); 
        }


        public string Infocompte()
        {
            return "N°:"+this.numeroCompte + " "+"Solde:" + this.soldeCompte + " "+"Nom:" + this.nomTitulaire + " " + this.decouvert+" euros";
        }


    }
}
