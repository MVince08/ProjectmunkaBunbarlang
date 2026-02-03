using System;
using System.Threading;

namespace Szerencsejatek
{
    public class Game2
    {
        private string _kepFajlNev;
        private KepMegjelenito _kepMegjelenito;
        private FelikaruRablo _jatek;

        public Game2()
        {
            _kepFajlNev = "kep.png";
            _kepMegjelenito = new KepMegjelenito(_kepFajlNev);
            _jatek = new FelikaruRablo(1000); // 1000 Ft-tal indulunk
        }

        public void Start()
        {
            FejlecKiirasa();

            // FŐ CIKLUS
            while (_jatek.VanPenze())
            {
                Console.WriteLine($"\nEgyenleged: {_jatek.Egyenleg} Ft");
                Console.Write("Tét (vagy 'kilep'): ");
                string bemenet = Console.ReadLine();

                if (bemenet.ToLower() == "kilep") break;

                if (int.TryParse(bemenet, out int tet))
                {
                    if (_jatek.TetErvenyes(tet))
                    {
                        PorgetesEredmeny eredmeny = _jatek.Porgetes(tet);

                        AnimacioEsEredmeny(eredmeny);

                        if (eredmeny.Jackpot)
                        {
                            // Ha Jackpot van, szólunk a Képkezelő osztálynak
                            _kepMegjelenito.Megnyitas();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hiba: Nincs ennyi pénzed vagy rossz az összeg.");
                    }
                }
                else
                {
                    Console.WriteLine("Kérlek számot adj meg!");
                }
            }

            Console.WriteLine("\nA játéknak vége. Viszlát!");
            Console.ReadKey();
        }

        // UI Segédfüggvények
        private void FejlecKiirasa()
        {
            Console.Title = "OOP Kaszinó";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("===================");
            Console.WriteLine("   FÉLKARÚ RABLÓ");
            Console.WriteLine("===================");
            Console.ResetColor();
        }

        private void AnimacioEsEredmeny(PorgetesEredmeny eredmeny)
        {
            Console.WriteLine();
            Console.Write("Pörgetés: ");

            // Kis animáció a szimbólumok megjelenéséhez
            foreach (var szimbolum in eredmeny.Szimbolumok)
            {
                Thread.Sleep(300);
                Console.Write($"[ {szimbolum} ] ");
            }
            Console.WriteLine();

            if (eredmeny.Jackpot)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"JACKPOT! Nyertél: {eredmeny.Nyeremeny} Ft");
            }
            else if (eredmeny.Nyeremeny > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Nyertél: {eredmeny.Nyeremeny} Ft");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Nem nyertél.");
            }
            Console.ResetColor();
            Console.WriteLine("----------------------------------------");
        }
    }
}