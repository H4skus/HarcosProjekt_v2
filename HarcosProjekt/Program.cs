using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarcosProjekt
{
    class Program
    {

        static Harcos jatekos;

        static void Main(string[] args)
        {
            Kezdes();
        }


        public static void Kezdes()
        {
            Console.Write("Kerem adja meg a nevet a Harcosnak: ");
            string nev = Console.ReadLine();
            int valasz;
            Console.WriteLine(" Udvozoljuk: "+ nev + "Valasz karakter osztalyt: \n\t (1)Haros: alapEletero = 15, alapSebzes = 3 \n\t (2)Ijasz: alapEletero = 12, alapSebzes = 4 \n\t (3)Magus: alapEletero = 8, alapSebzes = 5");
            bool isNumber = Int32.TryParse(Console.ReadLine(),out valasz);
            while(!isNumber || valasz < 1 || valasz > 3)
            {
                Console.Clear();
                Console.WriteLine(" Udvozoljuk: " + nev + "Valasz karakter osztalyt: \n\t (1)Haros: alapEletero = 15, alapSebzes = 3 \n\t (2)Ijasz: alapEletero = 12, alapSebzes = 4 \n\t (3)Magus: alapEletero = 8, alapSebzes = 5");
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

    }
}
