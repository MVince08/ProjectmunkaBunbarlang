// Game.cs BLACKJACK
public class Game
{
	private Deck deck;
	private Player player;
	private Player dealer;
	private int wincount = 0;
	private int losecount = 0;
	private int drawcount = 0;

	public int Wincount { get => wincount; set => wincount = value; }
	public int Losecount { get => losecount; set => losecount = value; }
	public int Drawcount { get => drawcount; set => drawcount = value; }

	public Game()
	{
		deck = new Deck();
		player = new Player("Játékos");
		dealer = new Player("Osztó");
	}

	public void Start()
	{
		Console.WriteLine("╔════════════════════════════════╗");
		Console.WriteLine("║   Üdvözöl a 21-es játékban!    ║");
		Console.WriteLine("╚════════════════════════════════╝");
		Console.WriteLine();

		bool playAgain = true;

		while (playAgain)
		{
			PlayRound();

			Console.Write("\nSzeretnél még játszani? (i/n): ");
			string answer = Console.ReadLine()?.ToLower();
			playAgain = answer == "i" || answer == "igen";
			Console.WriteLine();
		}
		Console.WriteLine($"Összesjátszmából:({wincount + losecount + drawcount})\n\tNyertél: {wincount}\n\tVeszítettél: {losecount}\n\tDöntetlen játszma lett: {drawcount}");
		Console.WriteLine("Köszönjük a játékot!");
	}

	private void PlayRound()
	{
		player.ClearHand();
		dealer.ClearHand();
		deck.Shuffle();

		// Kezdő kártyák osztása
		player.AddCard(deck.DrawCard());
		dealer.AddCard(deck.DrawCard());
		player.AddCard(deck.DrawCard());
		dealer.AddCard(deck.DrawCard());

		// Játékos köre
		Console.WriteLine("\n--- Új játék ---");
		dealer.ShowHand(hideFirst: true);
		player.ShowHand();

		bool playerBusted = false;

		while (player.GetHandValue() < 21)
		{
			Console.Write("\nLapot kérsz? (i/n): ");
			string choice = Console.ReadLine()?.ToLower();

			if (choice == "i" || choice == "igen")
			{
				player.AddCard(deck.DrawCard());
				player.ShowHand();

				if (player.GetHandValue() > 21)
				{
					playerBusted = true;
					Console.WriteLine($"\n{player.GetHandValue()} - Túllépted a 21-et! Vesztettél.");
					break;
				}
			}
			else
			{
				break;
			}
		}

		// Osztó köre (ha a játékos nem lépte túl)
		if (!playerBusted)
		{
			Console.WriteLine("\n--- Osztó köre ---");
			dealer.ShowHand();

			while (dealer.GetHandValue() < 17)
			{
				Console.WriteLine("Az osztó lapot húz...");
				dealer.AddCard(deck.DrawCard());
				dealer.ShowHand();
				System.Threading.Thread.Sleep(1000);
			}

			// Eredmény megállapítása
			DetermineWinner();
		}
	}

	public void DetermineWinner()
	{
		int playerValue = player.GetHandValue();
		int dealerValue = dealer.GetHandValue();

		Console.WriteLine("\n╔════════════════════════════════╗");
		Console.WriteLine("║          EREDMÉNY              ║");
		Console.WriteLine("╚════════════════════════════════╝");

		if (dealerValue > 21)
		{
			Console.WriteLine($"Az osztó túllépte a 21-et! Nyertél! ({playerValue} vs {dealerValue})");
			this.wincount++;
		}
		else if (playerValue > dealerValue)
		{
			Console.WriteLine($"Nyertél! ({playerValue} vs {dealerValue})");
			this.wincount++;
		}
		else if (playerValue < dealerValue)
		{
			Console.WriteLine($"Vesztettél! ({playerValue} vs {dealerValue})");
			this.losecount++;
		}
		else
		{
			Console.WriteLine($"Döntetlen! ({playerValue} vs {dealerValue})");
			this.drawcount++;
		}
	}
}