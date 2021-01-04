using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fraction
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction f1 = new Fraction(12, 7);
            f1.Afficher();

            Fraction f2 = new Fraction(46);
            f2.Afficher();

            Fraction f3 = new Fraction();
            f3.Afficher();

            Fraction f4 = new Fraction(12,7);
            f4.Oppose();

            Fraction f5 = new Fraction(12, 7);
            f5.Inverse();

            bool result=f1.SuperieurA(f2);
            Console.WriteLine(result);

            Fraction f0 = new Fraction(24, 14);
            f0.Afficher();
            bool result2 = f1.EgalA(f0);
            Console.WriteLine(result2);

            Fraction f6 = new Fraction(60, 36);
            int result3=f6.GetPgcd();
            f6.Reduire(result3);
            
            Fraction f7 = f6.Addition(f5);
            f7.ToString();
            
            int result4=f7.GetPgcd();
            f7.Reduire(result4);
            f7.ToString();

            Fraction f8 = f6.Soustraction(f5);
            f8.ToString();

            Fraction f9 = f6.Multiplication(f5);
            f9.ToString();

            Fraction f10 = f6.Division(f5);
            f10.ToString();

            Console.ReadKey();
        }
    }

    public class Fraction
    {
        private int num;
        private int deno;

        public int UNnum { get => num; set => num = value; }
        public int UNdeno { get => deno; set => deno = value; }

        public Fraction()
        {
            this.num = 0;
            this.deno = 1;
        }
        public Fraction(int UNnum)
        {
            this.num = UNnum;
            this.deno = 1;
        }
        public Fraction(int UNnum, int UNdeno)
        {
            this.num = UNnum;
            this.deno = UNdeno;
        }

        public void Afficher()
        {
            double lol = this.num / this.deno;
            Console.WriteLine(this.num + " sur " + this.deno + " est egal a "+lol);
        }

        public void Oppose()
        {
            string lol = "-" + this.num;
            int lo=int.Parse(lol);
            double l = lo / this.deno;
            Console.WriteLine(lol + " sur " + this.deno + " est egal a " + l);
        }

        public void Inverse()
        {
            double lol =  this.deno / this.num ;
            Console.WriteLine(this.deno + " sur " + this.num + " est egal a " + lol);
        }

        public bool SuperieurA(Fraction fract)
        {
            double un = this.num / this.deno;
            double deux=fract.num / fract.deno;

            if (un<deux)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool EgalA(Fraction fract)
        {
            double un = this.num / this.deno;
            double deux = fract.num / fract.deno;

            if (un == deux)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*public int GetPgcd()
        {
            int a = 0;
            int b = 0;
            if (this.UNnum>this.UNdeno)
            {
                a = this.UNnum;
                b = this.UNdeno;
            }
            else
            {
                b = this.UNnum;
                a = this.UNdeno;
            }
            
            int c;
            bool lol =true;
            int result = 0;
            while (lol == true)
            {
                c = a - b;
                a = b;
                result = b;
                b = c;
               

                if (b==0)
                {
                    
                    lol = false;
                }
            }
            Console.WriteLine("lol");
            return result;
        }*/

        public int GetPgcd() { 
            int a = this.UNnum;
            int b = this.UNdeno;
            int pgcd=-1;
            if ( a!=0 && b!=0) { 
                if ( a<0 ) a =-a; 
                if ( b<0 ) b =-b; 
                while ( a!=b ) {
                    if ( a<b ) {
                        b = b-a; 
                    } else {
                        a =a-b; 
                    }
                    pgcd = a; 
                }
            } 
            return pgcd; 
        }

        public void Reduire(int result3)
        {
            this.UNnum = this.UNnum / result3;
            this.UNdeno = this.UNdeno / result3;

        }

        public Fraction Addition(Fraction _fract){
            int nume = this.UNnum * _fract.UNdeno + _fract.UNnum * this.UNdeno;
            int denom = this.deno * _fract.deno;

            return new Fraction(nume,denom);
        }

        public Fraction Soustraction(Fraction _fract){
            int nume = this.UNnum * _fract.UNdeno - _fract.UNnum * this.UNdeno;
            int denom = this.deno * _fract.deno;

            return new Fraction(nume,denom);
        }

        public Fraction Multiplication(Fraction _fract){
            int nume = this.UNnum * _fract.UNnum;
            int denom = this.deno * _fract.deno;

            return new Fraction(nume,denom);
        }

        public Fraction Division(Fraction _fract){
            int nume = this.num * _fract.deno;
            int denom = this.deno * _fract.num;

            return new Fraction(nume,denom);
        }


        public void ToString(){
            Console.WriteLine(this.UNnum+" / "+ this.UNdeno);
        }
    }
}