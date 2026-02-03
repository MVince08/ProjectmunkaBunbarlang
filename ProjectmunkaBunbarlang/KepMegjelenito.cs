using System;
using System.Diagnostics;
using System.IO;

namespace Szerencsejatek
{
    public class KepMegjelenito
    {
        private string _fajlNev;

        public KepMegjelenito(string fajlNev)
        {
            _fajlNev = fajlNev;
        }

        public void Megnyitas()
        {
            try
            {
                // Ellenőrizzük, hogy létezik-e a fájl
                if (File.Exists(_fajlNev))
                {
                    Console.WriteLine("\n>>> 🌟 A TITKOS KÉP BETÖLTÉSE... 🌟 <<<");

                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = _fajlNev,
                        UseShellExecute = true // Windows alatt szükséges a megnyitáshoz
                    };
                    Process.Start(psi);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nHIBA: Nem találom a képet! ({_fajlNev})");
                    Console.WriteLine("Másold a képet a bin/Debug/netX.X mappába!");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba a kép megnyitásakor: " + ex.Message);
            }
        }
    }
}