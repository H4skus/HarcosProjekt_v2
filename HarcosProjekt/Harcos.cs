using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarcosProjekt
{
    class Harcos
    {
        private string nev, osztaly;
        private int szint, tapasztalat, eletero, alapEletero, alapSebzes;


        public override string ToString()
        {
            return string.Format($"{nev} –LVL:{szint} –EXP: {tapasztalat}/{SzintLepeshez} –HP: {eletero}/{MaxEletero} –DMG: {Sebzes} ");
        }

        public Harcos(string nev, int statuszSablom)
        {
            switch (statuszSablom)
            {
                case 2:
                    alapSebzes = 4;
                    alapEletero = 12;
                    osztaly = "Ijasz";
                    break;
                case 3:
                    alapEletero = 8;
                    alapSebzes = 5;
                    osztaly = "Magus";
                    break;
                default:
                    alapEletero = 15;
                    alapSebzes = 3;
                    osztaly = "Harcos";
                    break;
            }
            this.nev = nev;
            szint = 1;
            tapasztalat = 0;
            eletero = MaxEletero;
        }

        public string Nev { get => nev; set => nev = value; }

        public string Osztaly { get => osztaly; }
        public int Szint
        {
            get => szint; set
            {
                if (szint+1 < value)
                {
                    szint = szint + 1;
                }
                else
                {
                    szint = value;
                } } }
        public int Tapasztalat
        {
            get => tapasztalat; set
            {
                if (tapasztalat >= SzintLepeshez)
                {
                    Szint++;
                    tapasztalat = value;
                }
                else
                {
                    tapasztalat = value;
                }
            } }
        public int AlapSebzes { get => alapSebzes; }
        public int AlapEletero { get => alapEletero; }
        public int Eletero
        {
            get => eletero; set
            {
                if (eletero <= MaxEletero)
                {
                    eletero = value;
                }
                else if (eletero < 0)
                {
                    eletero = 0;
                }
                else
                {
                    eletero = MaxEletero;
                } } }
        public int Sebzes { get => alapSebzes + szint; }
        public int SzintLepeshez { get => 10 + szint * 5; }
        public int MaxEletero { get => AlapEletero + szint * 3; }

    }
}
