using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durak_next
{
    class CardRules
    {
        PlayerDeck PlayerDeck = new PlayerDeck();
        CardsDeck CardsDeck = new CardsDeck();
        Random rand = new Random();

        public CardRules()
        {
            PlayerDeck.GetPlayers();  //WAITS FOR USERS IMPUT
            PlayerDeck.PlayersStatus();  //INFO

            for (int i = 0; i < 5500; i++)
            {
                CardsDeck.GameReset();  //RESET BOOLS
                CardsDeck.ShuffleCards();  //SHUFFLE
                //CardsDeck.ShowAllDeck(); //test
            
                //Console.Clear();


                CardsDeck.GameStart(PlayerDeck.PlayersCount);  // Start

                GetPlayerWhoStartFirst();  // get attacker
                ShowAllPlayersAndCards();  // MainRender
                Console.WriteLine("First attack:");
                FirstAttack();


            }
        }

        public void GetPlayerWhoStartFirst()
        {
            int z = CardsDeck.GetAttacker();
            switch (z)
            {
                case 1:
                    PlayerDeck.SetPlayerStates(1);
                    break;
                case 2:
                    PlayerDeck.SetPlayerStates(2);
                    break;
                case 3:
                    PlayerDeck.SetPlayerStates(3);
                    break;
                case 4:
                    PlayerDeck.SetPlayerStates(4);
                    break;
                case 0:
                    Console.WriteLine("No TRUMPS");
                    //Console.WriteLine("Player Randomly assigned " + rand.Next(1, z + 1));
                    PlayerDeck.SetPlayerStates(rand.Next(1, z + 1));
                    //Console.ReadLine();
                    break;
                default:
                    break;
            }

        } // who starts

        public void ShowAllPlayersAndCards()
        {
            Console.WriteLine("Cards in deck: ");
            CardsDeck.ShowCardsOfPlayer(0);
            Console.WriteLine("TRUMP: ");
            Console.WriteLine(CardsDeck.cards[0].CardToString());

            for (int i = 0; i < PlayerDeck.PlayersCount; i++)
            {
                Console.WriteLine("Player {0} cards: ", PlayerDeck.players[i].PlayerName);
                CardsDeck.ShowCardsOfPlayer(i+1);
            }
            //Console.ReadLine();
        } // all info for test.

        public void AfterRoundRoutine()
        {
            if (CardsDeck.CountCardsOnHand(0) + CardsDeck.CountCardsOnHand(6) >= 0) // check deck//проверяем наличие карт в колоде
            {
                //проверяем кто ходил первым 1
                foreach (var player in PlayerDeck.players)
                {
                    if (player != null)
                    {
                        if (player.IsAttacking)
                        {
                            for (int i = 0; i < 6; i++)
                            {

                                CardsDeck.GiveNextCardFromDeckToPlayer(player.ThisPlayersNumber);                 //даем по одной карте первому, пока не будет 6ти карт.
                                                                                                                  //добавить карту игроку player.
                            }
                        }
                    }
                }

                foreach (var player in PlayerDeck.players)                 //проверяем кто подкидывал 2
                {
                    if (player != null)
                    {
                        if (player.CanAdd)
                        {
                            for (int i = 0; i < 6; i++)
                            {

                                CardsDeck.GiveNextCardFromDeckToPlayer(player.ThisPlayersNumber); //даем по одной карте второму, пока не будет 6ти карт.
                                //добавить карту игроку player.
                            }
                        }
                    }
                }

                foreach (var player in PlayerDeck.players)                                 //проверяем кто бился 3                
                    if (player != null)
                    {
                        if (player.IsDefencing)
                        {
                            for (int i = 0; i < 6; i++)
                            {

                                CardsDeck.GiveNextCardFromDeckToPlayer(player.ThisPlayersNumber); //даем по одной карте третьему, пока не будет 6ти карт.
                                //добавить карту игроку player.
                            }
                        }
                    }
                }

            foreach (var player in PlayerDeck.players) //проверяем, всем ли хватило карт, есть ли кто-нибудь с 0 карт, удаляем из игры тех кому не хватило карт
            {
                if (player != null)
                {
                    if (CardsDeck.CountCardsOnHand(player.ThisPlayersNumber) == 0 && player.IsFinished == false)
                    {
                        player.IsFinished = true;
                        PlayerDeck.PlayersStillPlaying--;
                        //player.State_SetAsFinished();
                    }
                }
            }

            //меняем роли

            if (PlayerDeck.PlayersStillPlaying < 2)
            {
                // game ends. Dyrak has been found.
            }
            else if (PlayerDeck.PlayersStillPlaying == 2)
            {
                foreach (var player in PlayerDeck.players) //проверяем, всем ли хватило карт, есть ли кто-нибудь с 0 карт, удаляем из игры тех кому не хватило карт
                {
                    if (player != null)
                    {
                        if (player.IsFinished == false && player.IsDefencing)
                        {

                        }
                    }
                }
            }
            else if (PlayerDeck.PlayersStillPlaying == 3)
            {

            }

            else if (PlayerDeck.PlayersStillPlaying == 4)
            {

            }

            //меняем роли
            //запускаем след раунд.
            //если карт нету или игроков меньше 2х начинаем новую.
        }

        public void FirstAttack() // put cards in attack
        {
            string s = Console.ReadLine(); // wait imput

            Console.WriteLine("Write next to end round.");

            if (s == "next")
            {
                foreach (var card in CardsDeck.cards)
                {
                    if (card.BelongsTo == 7)
                    {
                        CasualDefence();
                    }
                }
                Console.WriteLine("you have to attack!!!"); 
            }

            foreach (var player in PlayerDeck.players)
            {
                if (player != null)
                {
                    if (player.IsAttacking)
                    {
                        foreach (var card in CardsDeck.cards)
                        {
                            if (card.BelongsTo == player.ThisPlayersNumber)
                            {
                                if (s.Contains(card.CardMarker))
                                {
                                    Console.WriteLine("Attack with {0} !", card.CardMarker);
                                    card.BelongsTo = 7;
                                    Console.ReadLine();
                                    FirstAttack();
                                }
                            }
                        }
                    }
                }
            } 
        }

        public void CasualDefence() // put cards as defence
        {
            Console.WriteLine("Defence starts now.");
        }

        public void NextAttack() // not sure.
        {

        }

        public void AddingCardsToAttack() // adding cards (5 max at first time)
        {

        }

        public void PlayerFoldsHands()  // round won by attacker. get cards
        {

        }

        public void PlayerDefended()  // round won by defender. get cards
        {

        }

        public void PriorityPause() // for 3+ players
        {


        }



    }
    }

