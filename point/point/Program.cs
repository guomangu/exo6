using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace point
{
    class Program
    {
        static void Main(string[] args)
        {
            Point point1 = new Point(2, 3,"prems");
            point1.Afficher();

            point1.Deplacement(4, 5);
            point1.Afficher();

            point1.Newparax();
            point1.Newparay();
            point1.Newparaall();

            Point point2 = new Point();
            point2.Afficher();

            Console.ReadKey();

        }
    }

    public class Point {
        private int x;
        private int y;
        private string name;

        public int UNposiX { get => x; set => x = value; }
        public int UNposiY { get => y; set => y = value; }
        public string UNname { get => name; set => name = value; }

        public Point(int UNposiX,int UNposiY,string UNname)
        {
            this.x = UNposiX;
            this.y = UNposiY;
            this.name = UNname;
        }
        public Point()
        {
            this.x = 0;
            this.y = 0;
            this.name = "randi";
        }

        //

        public void Afficher()
        {
            Console.WriteLine(this.name+" est a la position "+this.x+" x et "+this.y+" y.");
        }

        public void Deplacement(int newx,int newy)
        {
            this.x = newx;
            this.y = newy;
        }

        public void Newparax()
        {
            int lol = 0 - this.x;
            Point Pcopie = new Point(lol, this.y, this.name + "copiex");
            Pcopie.Afficher();
        }
        public void Newparay()
        {
            int lol = 0 - this.y;
            Point Pcopie2 = new Point(this.x, lol, this.name + "copiey");
            Pcopie2.Afficher();
        }
        public void Newparaall()
        {
            int lol = 0 - this.y;
            int lol2 = 0 - this.x;
            Point Pcopie3 = new Point(lol2, lol, this.name + "copieall");
            Pcopie3.Afficher();
        }


    }
}
