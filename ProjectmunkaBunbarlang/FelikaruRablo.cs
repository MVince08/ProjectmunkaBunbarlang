using System;
using System.Threading;

namespace Szerencsejatek
{
    // Ez egy segédosztály, ami egy pörgetés eredményét tárolja
    public class PorgetesEredmeny
    {
        public string[] Szimbolumok { get; set; }
        public int Nyeremeny { get; set; }
        public bool Jackpot { get; set; }
    }

    public class FelikaruRablo
    {
        private int Egyenleg { get; set; }
        private readonly string[] _szimbolumok = { "X", "7", "O", "A", "B" };
        private Random _rnd;

        public FelikaruRablo(int kezdoEgyenleg)
        {
            Egyenleg = kezdoEgyenleg;
            _rnd = new Random();
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
            string s1 = _szimbolumok[_rnd.Next(_szimbolumok.Length)];
            string s2 = _szimbolumok[_rnd.Next(_szimbolumok.Length)];
            string s3 = _szimbolumok[_rnd.Next(_szimbolumok.Length)];

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