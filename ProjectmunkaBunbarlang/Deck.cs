// Deck.cs BLACKJACK
public class Deck
{
    private List<Card> cards;
    private Random random;

    public Deck()
    {
        cards = new List<Card>();
        random = new Random();
        InitializeDeck();
    }
    private void InitializeDeck()
    {
        string[] suits = { "♠", "♥", "♦", "♣" };
        string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        int[] values = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };

        foreach (string suit in suits)
        {
            for (int i = 0; i < ranks.Length; i++)
            {
                cards.Add(new Card(suit, ranks[i], values[i]));
            }
        }
    }

    public void Shuffle()
    {
        cards = cards.OrderBy(c => random.Next()).ToList();
    }

    public Card DrawCard()
    {
        if (cards.Count == 0)
        {
            InitializeDeck();
            Shuffle();
        }

        Card card = cards[0];
        cards.RemoveAt(0);
        return card;
    }

    /* Dobálja az errort folyamat nem teljesen értem mi folyik itt, szval nme használom az enum-ot, meg sztem ez logikusabb és egyszerűbb logika
     

 public enum Suit
{
    Spades,
    Hearts,
    Diamonds,
    Clubs
}

public enum Rank
{
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10,
    Jack = 10,
    Queen = 10,
    King = 10,
    Ace = 11
}

public class Deck
{
    private static readonly Dictionary<Suit, string> SuitSymbols = new()
    {
        { Suit.Spades, "♠" },
        { Suit.Hearts, "♥" },
        { Suit.Diamonds, "♦" },
        { Suit.Clubs, "♣" }
    };

    private static readonly Dictionary<Rank, string> RankSymbols = new()
    {
        { Rank.Two, "2" },
        { Rank.Three, "3" },
        { Rank.Four, "4" },
        { Rank.Five, "5" },
        { Rank.Six, "6" },
        { Rank.Seven, "7" },
        { Rank.Eight, "8" },
        { Rank.Nine, "9" },
        { Rank.Ten, "10" },
        { Rank.Jack, "J" },
        { Rank.Queen, "Q" },
        { Rank.King, "K" },
        { Rank.Ace, "A" }
    };

    private List<Card> cards;
    private Random random;

    public Deck()
    {
        cards = new List<Card>();
        random = new Random();
        InitializeDeck();
    }

    private void InitializeDeck()
    {
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                cards.Add(new Card(
                    SuitSymbols[suit],
                    RankSymbols[rank],
                    (int)rank
                ));
            }
        }
    }
     */

}

