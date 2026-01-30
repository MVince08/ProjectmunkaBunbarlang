// Player.cs BLACKJACK
using System;
using System.Collections.Generic;
using System.Linq;

public class Player
{
	private string Name { get; set; }
	private List<Card> Hand { get; set; }

	public Player(string name)
	{
		Name = name;
		Hand = new List<Card>();
	}

	public void AddCard(Card card)
	{
		Hand.Add(card);
	}

	public int GetHandValue()
	{
		int value = Hand.Sum(c => c.Value);
		int aces = Hand.Count(c => c.Rank == "A");

		// Az ász értékét 1-re módosítjuk, ha túlléptük a 21-et
		while (value > 21 && aces > 0)
		{
			value -= 10;
			aces--;
		}

		return value;
	}

	public void ShowHand(bool hideFirst = false)
	{
		Console.Write($"{Name} kártyái: ");
		for (int i = 0; i < Hand.Count; i++)
		{
			if (i == 0 && hideFirst)
			{
				Console.Write("[Rejtett] ");
			}
			else
			{
				Console.Write($"{Hand[i]} ");
			}
		}

		if (!hideFirst)
		{
			Console.WriteLine($"(Érték: {GetHandValue()})");
		}
		else
		{
			Console.WriteLine();
		}
	}

	public void ClearHand()
	{
		Hand.Clear();
	}
}