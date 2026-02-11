using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    internal class Game3
    {
        private Deck deck;
        private int correctPredictions = 0;
        private int wrongPredictions = 0;

        public Game3()
        {
            deck = new Deck();
        }

        public void Start()
        {
            Console.WriteLine("╔═════════════════════════╗");
            Console.WriteLine("║ Üdvözöl a Ride The Bus! ║");
            Console.WriteLine("╚═════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("Az a játék lényege: megjósold a kártyákat!");
            Console.WriteLine();

            bool playAgain = true;

            while (playAgain)
            {
                PlayGame();

                Console.Write("\nSzeretnél még játszani? (i/n): ");
                string answer = Console.ReadLine()?.ToLower();
                playAgain = answer == "i";
                Console.WriteLine();
            }

            Console.WriteLine("Köszönjük a játékot!");
        }

        private void PlayGame()
        {
            correctPredictions = 0;
            wrongPredictions = 0;
            deck = new Deck();
            deck.Shuffle();

            Console.WriteLine("╔════════════════════╗");
            Console.WriteLine("║      ÚJ JÁTÉK      ║");
            Console.WriteLine("╚════════════════════╝");
            Console.WriteLine();

            // Stage 1: Suit (4 kártya)
            Stage1_Suit();

            // Stage 2: Between (4 kártya)
            Stage2_Between();

            // Stage 3: Higher/Lower (4 kártya)
            Stage3_HigherLower();

            // Results
            DisplayResults();
        }

        private void Stage1_Suit()
        {
            Console.WriteLine("═════════════════════════════════════");
            Console.WriteLine("Etap 1: MILYEN SZIMBÓLUMÁT (LAPOK)?");
            Console.WriteLine("═════════════════════════════════════");
            Console.WriteLine("Meg kell jósold a kártya szimbólumát! (♠/♥/♦/♣)\n");

            for (int i = 0; i < 4; i++)
            {
                Console.Write("Melyik szimbólum? (♠/♥/♦/♣ vagy S/H/D/C): ");
                string prediction = Console.ReadLine()?.ToUpper();

                // Konvertáld a rövidítéseket szimbólumokká
                string predictedSuit = prediction switch
                {
                    "S" => "♠",
                    "H" => "♥",
                    "D" => "♦",
                    "C" => "♣",
                    _ => prediction
                };

                Card currentCard = deck.DrawCard();
                Console.WriteLine($"A kártya: {currentCard}");

                if (predictedSuit == currentCard.Suit)
                {
                    Console.WriteLine("Helyes!\n");
                    correctPredictions++;
                }
                else
                {
                    Console.WriteLine("Rossz!\n");
                    wrongPredictions++;
                }
            }
        }

        private void Stage2_Between()
        {
            Console.WriteLine("═════════════════════════════════════");
            Console.WriteLine("Etap 2: KÖZÖTT VAGY KÍVÜL?");
            Console.WriteLine("═════════════════════════════════════");
            Console.WriteLine("Meg kell jósold, hogy a következő kártya a két kártya között van-e!\n");

            Card card1 = deck.DrawCard();
            Card card2 = deck.DrawCard();

            // Biztosítsd, hogy card1 < card2
            if (card1.Value > card2.Value)
            {
                Card temp = card1;
                card1 = card2;
                card2 = temp;
            }

            Console.WriteLine($"Kártyák: {card1} és {card2}");
            Console.WriteLine($"Értékek: {card1.Value} és {card2.Value}");

            for (int i = 0; i < 4; i++)
            {
                Console.Write("Között (B) vagy Kívül (K)? ");
                string prediction = Console.ReadLine()?.ToUpper();

                Card currentCard = deck.DrawCard();
                Console.WriteLine($"A kártya: {currentCard} (Érték: {currentCard.Value})");

                bool isBetween = currentCard.Value > card1.Value && currentCard.Value < card2.Value;
                bool correct = (prediction == "B" && isBetween) || (prediction == "K" && !isBetween);

                if (correct)
                {
                    Console.WriteLine("Helyes!\n");
                    correctPredictions++;
                }
                else
                {
                    Console.WriteLine("Rossz!\n");
                    wrongPredictions++;
                }

                card1 = currentCard;
                card2 = deck.DrawCard();
                if (card1.Value > card2.Value)
                {
                    Card temp = card1;
                    card1 = card2;
                    card2 = temp;
                }
                Console.WriteLine($"Új kártyák: {card1} és {card2}");
            }
        }

        private void Stage3_HigherLower()
        {
            Console.WriteLine("═══════════════════════════════════");
            Console.WriteLine("Etap 3: MAGASABB vagy ALACSONYABB?");
            Console.WriteLine("═══════════════════════════════════");
            Console.WriteLine("Meg kell jósold, hogy a következő kártya magasabb vagy alacsonyabb-e az előzőnél.\n");

            Card previousCard = deck.DrawCard();
            Console.WriteLine($"Első kártya: {previousCard}");

            for (int i = 0; i < 4; i++)
            {
                Console.Write("Magasabb (M) vagy Alacsonyabb (A)? ");
                string prediction = Console.ReadLine()?.ToUpper();

                Card currentCard = deck.DrawCard();
                Console.WriteLine($"A kártya: {currentCard}");

                bool correct = false;
                if (prediction == "M" && currentCard.Value > previousCard.Value)
                    correct = true;
                else if (prediction == "A" && currentCard.Value < previousCard.Value)
                    correct = true;

                if (correct)
                {
                    Console.WriteLine("Helyes!\n");
                    correctPredictions++;
                }
                else
                {
                    Console.WriteLine("Rossz!\n");
                    wrongPredictions++;
                }

                previousCard = currentCard;
            }
        }

        private void DisplayResults()
        {
            Console.WriteLine("\n╔════════════════════════════════╗");
            Console.WriteLine("║         VÉGEREDMÉNY             ║");
            Console.WriteLine("╚════════════════════════════════╝");
            Console.WriteLine($"\nHelyes: {correctPredictions}");
            Console.WriteLine($"Rossz: {wrongPredictions}");
            int totalPoints = correctPredictions - wrongPredictions;
            Console.WriteLine($"Összesített pontszám: {totalPoints}");
        }
    }
