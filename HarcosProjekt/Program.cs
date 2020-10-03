using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HarcosProjekt
{
    class Program
    {

        static Harcos jatekos;
        static Harcos ellenseg;
        static List<Harcos> ellensegek = new List<Harcos>();

        static void Main(string[] args)
        {
            ellensegFelvesz();
            Kezdes();
            Menu();
            ellenfelValasztas();
        }


        public static void Kezdes()
        {
            Console.Write("Kerem adja meg a nevet a Harcosnak: ");
            string nev = Console.ReadLine();
            int valasz;
            Console.WriteLine("Udvozoljuk: "+ nev + "Valasz karakter osztalyt: \n\t (1)Haros: alapEletero = 15, alapSebzes = 3 \n\t (2)Ijasz: alapEletero = 12, alapSebzes = 4 \n\t (3)Magus: alapEletero = 8, alapSebzes = 5");
            bool isNumber = Int32.TryParse(Console.ReadLine(),out valasz);
            while(!isNumber || valasz < 1 || valasz > 3)
            {
                Console.Clear();
                Console.WriteLine("Udvozoljuk: " + nev + "Valasz karakter osztalyt: \n\t (1)Haros: alapEletero = 15, alapSebzes = 3 \n\t (2)Ijasz: alapEletero = 12, alapSebzes = 4 \n\t (3)Magus: alapEletero = 8, alapSebzes = 5");
                if (!isNumber)
                {
                    Console.WriteLine("Ez nem szam!");
                }
                else if (valasz < 1 || valasz > 3)
                {
                    Console.WriteLine("Ilyen szamhoz nem tartozik karakter osztaly! ");
                }
                isNumber = Int32.TryParse(Console.ReadLine(), out valasz);
            }
            jatekos = new Harcos(nev, valasz);
        }

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine(jatekos);
            Console.WriteLine("Nyomj egy 'a'-t az ellensegek keresesehez, nyomj egy ''- a gyogitashoz, nyomj egy '' a kilepeshez");
            string valasz = Console.ReadLine();
                if (valasz == "a")
                {
                    if (eleteroCheck())
                    {
                    Menu();
                    }
                    else
                    {
                    ellenfelValasztas();
                    }
                }
                else if (valasz == "h")
                {
                    Gyogyul();
                }
        }
        public static void Gyogyul()
        {
            if (jatekos.Eletero == 0)
            {
                jatekos.Eletero = jatekos.MaxEletero;
                Console.Clear();
                Console.WriteLine("Teljesen meggyogyultal ");
                Console.ReadKey();
                Menu();
            }
            else if(jatekos.Eletero == jatekos.MaxEletero)
            {
                Console.Clear();
                Console.WriteLine("Max hp-n vagy, nem tudsz gyogyulni! ");
                Console.ReadKey();
                Menu();
            }
            else
            {
                jatekos.Eletero += (3 + jatekos.Szint);
                Console.Clear();
                Console.WriteLine("Sikeresen gyogyitottal magadon " + (3+jatekos.Szint)+ "-t");
                Console.ReadKey();
                Menu();
            }
        }
        public static void ellensegListazas()
        {
            int i = 1;
            foreach (Harcos item in ellensegek)
            {
                if (item.Eletero > 0)
                {
                    Console.WriteLine(i + ". " + item);
                    i++;
                }
            }
        }

        public static void ellensegFelvesz()
        {
            StreamReader sr = new StreamReader("harcosok.csv", Encoding.UTF8);
            int i = 0;
            string sor = "";
            while (!sr.EndOfStream)
            {
                sor = sr.ReadLine();
                string[] elemek = sor.Split(';');
                ellenseg = new Harcos(elemek[0], Convert.ToInt32(elemek[1]));
                ellenseg.Nev = elemek[0];
                ellenseg.StatuszSablon = Convert.ToInt32(elemek[1]);
                ellensegek.Add(ellenseg);
            }
            sr.Close();
        }

        public static void ellenfelValasztas()
        {
            Console.WriteLine(jatekos);
            Console.WriteLine("valasszon ellenfelet");
            ellensegListazas();
            int valasz;
            bool isNumber = Int32.TryParse(Console.ReadLine(), out valasz);
            while (!isNumber || valasz < 0 || valasz > ellensegek.Count+1)
            {
                Console.Clear();
                Console.WriteLine(jatekos);
                Console.Write("valasszon ellenfelet");
                if (!isNumber)
                {
                    Console.Clear();
                    Console.WriteLine("Ez nem szam!");
                    ellensegListazas();
                }
                else if (valasz < 0 || valasz > ellensegek.Count + 1)
                {
                    Console.Clear();
                    Console.WriteLine(jatekos);
                    Console.WriteLine("Ilyen szamhoz nem tartozik ellenfel");
                }
                isNumber = Int32.TryParse(Console.ReadLine(), out valasz);
            }
            valasz -= 1;
            scan(valasz);

        }
        public static void scan(int valasz)
        {
            if (jatekos.Osztaly == ellensegek[valasz].Osztaly)
            {
                Console.WriteLine("Ez nem jo");
                Console.ReadKey();
                ellenfelValasztas();
            }
        }

        public static void harcol()
        {

        }
        public static bool eleteroCheck()
        {
            if (jatekos.Eletero <= 0)
            {
                Console.WriteLine("Az eleterod tul alacsony! ");
                Console.ReadKey();
                return true;
            }
            return false;
        }

    }
}
