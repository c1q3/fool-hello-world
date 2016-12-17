using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durak_next
{
    class PlayerDeck
    {
        public Player[] players = new Player[4];
        private int playersIndex = 0;
        public int PlayersCount = 0;
        public int PlayersStillPlaying;
        public PlayerDeck()
        {

        }

        public void AddPlayer(string NickName) //Routine to add new user
        {
            players[playersIndex] = new Player(NickName);
            playersIndex++;
        }

        public void PlayersStatus() // console writer
        {
            foreach (var player in players)
            {
                if (player != null)
                Console.WriteLine(player.StatusToString());
            }
            //Console.WriteLine("PlayersCount " + PlayersCount.ToString());
        }

        public void GetPlayers()
        {
            Console.WriteLine("How many players will play (2-4)?");
            string s = Console.ReadLine();
            switch (s)
            {
                case "2":
                    PlayersCount = 2;
                    for (int i = 0; i < 2; i++)
                    {
                        AddPlayer(Console.ReadLine());
                    }

                    break;
                case "3":
                    PlayersCount = 3;
                    for (int i = 0; i < 3; i++)
                    {
                        AddPlayer(Console.ReadLine());
                    }
                    break;
                case "4":
                    PlayersCount = 4;
                    for (int i = 0; i < 4; i++)
                    {
                        AddPlayer(Console.ReadLine());
                    }
                    break;

                default:
                    //PlayersCount = 4;
                    PlayersCount = 2;
                    AddPlayer("Alkaida");
                    AddPlayer("ISIS");
                    //AddPlayer("GorgBush");
                    //AddPlayer("Clinton");
                    break;
            }

            PlayersStillPlaying = PlayersCount;
            Console.ReadLine();
        } //typed by user 

        public int GetPlayersCount()
        {
            PlayersCount = 0;
            foreach (var player in players)
            {
                if (player != null)
                    PlayersCount++;
            }
            return PlayersCount;
        } //return players quantity

        public void SetPlayerStates(int x) 
        {
            if (PlayersCount == 4)
            {
                switch (x)
                {
                    case 1:
                        players[0].State_SetAsAttacker();
                        players[1].State_SetAsDefender();
                        players[2].State_SetAsCanAdd();
                        players[3].State_SetAsMutedFromBattle();
                        break;
                    case 2:
                        players[0].State_SetAsMutedFromBattle();
                        players[1].State_SetAsAttacker();
                        players[2].State_SetAsDefender();
                        players[3].State_SetAsCanAdd();
                        break;
                    case 3:
                        players[0].State_SetAsCanAdd();
                        players[1].State_SetAsMutedFromBattle();
                        players[2].State_SetAsAttacker();
                        players[3].State_SetAsDefender();
                        break;
                    case 4:
                        players[0].State_SetAsDefender();
                        players[1].State_SetAsCanAdd();
                        players[2].State_SetAsMutedFromBattle();
                        players[3].State_SetAsAttacker();
                        break;

                    default:
                        break;
                }
            }
            else if (PlayersCount == 3)
            {

                switch (x)
                {
                    case 1:
                        players[0].State_SetAsAttacker();
                        players[1].State_SetAsDefender();
                        players[2].State_SetAsCanAdd();
                        break;
                    case 2:
                        players[1].State_SetAsAttacker();
                        players[2].State_SetAsDefender();
                        players[0].State_SetAsCanAdd();
                        break;
                    case 3:
                        players[2].State_SetAsAttacker();
                        players[0].State_SetAsDefender();
                        players[1].State_SetAsCanAdd();
                        break;

                    default:
                        break;
                }
            }
            else if (PlayersCount == 2)
            {


                switch (x)
                {
                    case 1:
                        players[0].State_SetAsAttacker();
                        players[1].State_SetAsDefender();
                        break;
                    case 2:
                        players[1].State_SetAsAttacker();
                        players[0].State_SetAsDefender();
                        break;

                    default:
                        break;
                }
            }
        } //sets states of players depends on who will start.
    }

}
