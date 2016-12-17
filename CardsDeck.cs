using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durak_next
{
    public class CardsDeck
    {
        public Card[] cards = new Card[36];


        Random rand = new Random();
        //PlayerDeck Temp;
        int GamePlayers;

        public CardsDeck()
        {
            //cards = new Card[36];
            var index = 0;

            foreach (var suit in new[] { "s", "h", "c", "d", })
            {
                for (var rank = 0; rank <= 8; rank++)
                {
                    cards[index++] = new Card(rank, suit, index);
                }
            }
        }

        public void ShowAllDeck() //test
        {
            foreach (var card in cards)
            {
                Console.Write(card.CardToString());
            }
        }

        public void ShuffleCards()
        {
            for (int i = cards.Length - 1; i > 0; i--)
            {
                int n = rand.Next(i + 1);

                Swap(ref cards[i], ref cards[n]);
            }
        }

        public static void Swap<Card>(ref Card lhs, ref Card rhs)
        {
            Card temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        public void GameReset()
        {
            foreach (var card in cards)
            {
                card.BelongsTo = 0;
                card.IsVisible = false;
                card.IsTrump = false;
            }
        }

        //public void GameStart(int Players)  // раздача карт тут.
        //{
        //    GamePlayers = Players;
        //    int z = 0;
        //    for (int i = 0; i <= Players; i++)
        //    {
        //        for (int u = 0; u < 6; u++)
        //        {
        //            cards[z].BelongsTo = i;
        //            z++;
        //        }
        //    }

        //    cards[z].BelongsTo = 6; //(trump)
        //    cards[z].IsVisible = true;

        //    foreach (var card in cards)
        //    {
        //        card.MakeTrump(cards[z].Suit);
        //    }
        //}

        public void GameStart(int Players)  // раздача карт тут.
        {
            GamePlayers = Players;
            //int z = 35;
            for (int i = 1; i <= Players; i++)
            {
                for (int u = 0; u < 6; u++)
                {
                    GiveNextCardFromDeckToPlayer(i);
                    //cards[z].BelongsTo = i;
                    //z--;
                }
            }

            //cards[0].BelongsTo = 0; //(trump)
            cards[0].IsVisible = true;

            foreach (var card in cards)
            {
                card.MakeTrump(cards[0].Suit);
            }
        }

        public void ShowCardsOfPlayer(int x) // write cards of player (0 - koloda, 1,2,3,4-igrok. 5 - dump, 7 - table)
        {
            foreach (var card in cards)
            {
                if (card.BelongsTo == x)
                {
                    if (card.IsTrump)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else { Console.ForegroundColor = ConsoleColor.White; }

                    Console.Write(card.CardToString());
                    Console.ForegroundColor = ConsoleColor.White;
                }
                
            }
            Console.WriteLine();
        }

        public int CountCardsOnHand(int x)  // counts cards in player's hands (0 - koloda, 1,2,3,4-igrok. 5 - dump, 7 - table)
        {
            int z = 0;
            foreach (var card in cards)
            {
                if (card.BelongsTo == x)
                {
                    z++;
                }

            }
            return z;
        }

        public Card GetNextCardFromDeck()
        {
            return cards[3];
        }

        public int GetAttacker()
        {
            int TestMaxValue = 37; // test var
            foreach (var card in cards)
            {
                //Console.WriteLine(card.BelongsTo + " " + card.faceValue);
                if (card.BelongsTo > 0 && card.BelongsTo < 5)
                {
                    //Console.WriteLine(TestMaxValue + " " +card.faceValue);
                    if (card.IsTrump)
                    {
                        //Console.WriteLine("trump belongs to {0} ",card.BelongsTo);
                        if (card.faceValue < TestMaxValue)
                        {
                            TestMaxValue = card.faceValue;
                        }
                    }
                }
            }

            if (TestMaxValue != 37)
            {
                foreach (var card in cards)
                {
                    if (card.faceValue == TestMaxValue)
                    {
                        Console.WriteLine("Player first " + card.BelongsTo.ToString());
                        return card.BelongsTo;
                    }
                    //else
                    //Console.WriteLine("No trumps");
                }
            }

            Console.WriteLine("THERE IS NO TRUMPS ");
            return 0;
        }

        public void GiveNextCardFromDeckToPlayer(int x)
        {
            if (CountCardsOnHand(0) > 0)
            {
                if (CountCardsOnHand(x) < 6)
                {
                    for (int i = 35; i >= 0; i--)
                    {
                        if (cards[i].BelongsTo == 0)
                        {
                            cards[i].BelongsTo = x;
                            return;
                            //break;
                        }
                        //Console.WriteLine("Cards isnt belong to deck");
                    }
                }
                //Console.WriteLine("Hand is full");
            }
            //Console.WriteLine("No cards in deck");
        }

    }
}
