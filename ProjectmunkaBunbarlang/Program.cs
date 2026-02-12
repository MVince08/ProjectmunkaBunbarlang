// Program.cs MAIN
using System;
using Szerencsejatek;

class Program
{
	static void Main(string[] args)
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;

		Console.Write("Válasszon játékot lehetőségek: \n\tBlackjack(21): 'B'\n\tRide the Bus: 'R'\n\tFélkarú Rabló: 'F': ");
		string valasztas = Console.ReadLine();

        if (valasztas is "B" or "b")
		{
			Console.WriteLine("BlackJack-et választotta, átirányítás...");
			Game game = new Game();
			game.Start();
		}
		else if (valasztas is "R" or "r")
		{
            Console.WriteLine("Ride the Bus-t választotta, átirányítás...");
            Game3 busGame = new Game3();
            busGame.Start();
        }
		else if (valasztas is "F" or "f")
        {
            Console.WriteLine("Félkarú rablót választotta, átirányítás... \n");
            FelkaruRabloGame jatek = new FelkaruRabloGame();
            jatek.Start();
        }
    }
}