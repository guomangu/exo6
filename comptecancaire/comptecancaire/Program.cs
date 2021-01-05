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

            //----------------------------------
            Console.WriteLine("\n \n");

            Banque banque = new Banque();
            banque.ajouterCompte(86,  4500.50,"Tournesol", -3000);
            banque.toString();

            banque.ajouterCompte(1086,  104500.50,"millenesol", -20);
            banque.toString();


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
            return "N°:"+this.numeroCompte + " "+"Solde:" + this.soldeCompte + " "+"Nom:" + this.nomTitulaire + " ,decouvert autorise " + this.decouvert+" euros";
        }


    }

    public class Banque{
        private Compte[] mesComptes;
        private int nbCompte;

        public Banque()
        {
            this.mesComptes = new Compte[10];
            this.nbCompte = 0;
        }

        private void ajouterCompte(Compte _compte){
            this.mesComptes[nbCompte] = _compte;
            this.nbCompte++;
        }

        public void ajouterCompte(int _numeroCompte,double _soldeCompte,string _nomTitulaire,double _decouvert){
            Compte lol = new Compte(_numeroCompte,_soldeCompte,_nomTitulaire,_decouvert);
            this.ajouterCompte(lol);
        }

        public void toString(){
            string phraseComptes="Il y a "+this.nbCompte+" comptes dans ma banque."+ "\n" ;
            for (int i = 0; i < this.nbCompte; i++)
			{
                phraseComptes+= this.mesComptes[i].Infocompte()+ "\n";
			}
            Console.WriteLine(phraseComptes);
        }
    }
}
