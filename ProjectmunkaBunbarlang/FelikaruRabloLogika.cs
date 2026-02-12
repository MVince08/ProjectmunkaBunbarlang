using System;
using System.Threading;

namespace Szerencsejatek
{
    // Pörgetés eredményét tároló osztály
    public class PorgetesEredmeny
    {
        public string[] Szimbolumok { get; set; }
        public int Nyeremeny { get; set; }
        public bool Jackpot { get; set; }
    }

    // Félkarú Rabló logika osztály
    public class FelikaruRabloLogika
    {
        public int Egyenleg { get; private set; }
        private readonly string[] szimbolumok = { "X", "7", "O", "A", "B" };
        private Random rnd;

        public FelikaruRabloLogika()
        {
            Egyenleg = 1000; // 1000 Ft-tal indul a game
            rnd = new Random();
        }

        public bool VanPenze()
        {
            return Egyenleg > 0;
        }

        public bool TetErvenyes(int tet)
        {
            return tet > 0 && tet <= Egyenleg;
        }

        public PorgetesEredmeny Porgetes(int tet)
        {
            Egyenleg -= tet;

            // 3 véletlen szimbólum
            string s1 = szimbolumok[rnd.Next(szimbolumok.Length)];
            string s2 = szimbolumok[rnd.Next(szimbolumok.Length)];
            string s3 = szimbolumok[rnd.Next(szimbolumok.Length)];
            
            int nyeremeny = 0;
            bool isJackpot = false;

            // Nyeremény logika
            if (s1 == s2 && s2 == s3)
            {
                nyeremeny = tet * 5; // Jackpot: 5x
                isJackpot = true;
            }
            else if (s1 == s2 || s2 == s3 || s1 == s3)
            {
                nyeremeny = tet * 2; // Kis nyeremény: 2x
            }

            Egyenleg += nyeremeny;

            return new PorgetesEredmeny
            {
                Szimbolumok = new string[] { s1, s2, s3 },
                Nyeremeny = nyeremeny,
                Jackpot = isJackpot
            };
        }
    }
}