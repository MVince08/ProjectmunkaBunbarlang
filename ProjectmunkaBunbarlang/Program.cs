// Program.cs MAIN
using System;

class Program
{
	static void Main(string[] args)
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;

		Console.WriteLine("Válasszon játékot lehetőségek: \n\tBlackjack(21): 'B'\n\tComingSoon");

		if (Console.ReadKey(true).KeyChar is 'B' or 'b')
		{
			Console.WriteLine("BlackJack-et választotta, átirányítás...");
			Game game = new Game();
			game.Start();
		}
	}
}