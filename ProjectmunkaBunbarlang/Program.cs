// Program.cs MAIN
using System;
using Szerencsejatek;

class Program
{
	static void Main(string[] args)
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;

		Console.WriteLine("Válasszon játékot lehetőségek: \n\tBlackjack(21): 'B'\n\tRide the Bus: 'R'\n\tFélkarú Rabló: 'F' ");

		if (Console.ReadKey(true).KeyChar is 'B' or 'b')
		{
			Console.WriteLine("BlackJack-et választotta, átirányítás...");
			Game game = new Game();
			game.Start();
		}
		else if (Console.ReadKey(true).KeyChar is 'R' or 'r')
		{
            Console.WriteLine("Ride the Bus-t választotta, átirányítás...");
        }
		else if (Console.ReadKey(true).KeyChar is 'F' or 'f')
        {
            Console.WriteLine("Félkarú rablót választotta, átirányítás... ");
            Game2 jatek = new Game2();
            jatek.Start();
        }
    }
}