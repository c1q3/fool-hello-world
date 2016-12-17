using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durak_next
{
    class Player
    {
        public static int PlayersOnTheTable;

        public int ThisPlayersNumber;

        public string PlayerName;
        public int Wins;
        public int Loses;

        //GameVars

        public int MaxCardsToBuy = 6;
        public int CardsCount = 0;
        public bool IsAttacking = false; //атакует
        public bool CanAdd = false; // добавляет
        public bool IsDefencing = false; //защищается
        public bool HasTeammate = false; //имеет союзника
        public bool IsFinished = false;

        public Player()
        {
            PlayerName = "Anon";
            Wins = 0;
            Loses = 0;
            PlayersOnTheTable++;
            ThisPlayersNumber = PlayersOnTheTable;
        }

        public Player(string s)
        {
            PlayerName = s;
            Wins = 0;
            Loses = 0;
            PlayersOnTheTable++;
            ThisPlayersNumber = PlayersOnTheTable;
        }

        public string StatusToString()
        {
            return PlayerName + " wins: " + Wins.ToString() + " loses: " + Loses.ToString() + " your number is: " + ThisPlayersNumber;
        }

        public void ResetRoutine()
        {
            IsAttacking = false;
            IsDefencing = false;
            CanAdd = false;
            IsFinished = false;
        }

        public void PlayerWon()
        {
            Wins++;
        }

        public void PlayerLose()
        {
            Loses++;
        }

        public void State_SetAsAttacker()
        {
            IsAttacking = true;
            CanAdd = true;
            IsDefencing = false;
            Console.WriteLine(PlayerName + " attacking! " + ThisPlayersNumber);
        }

        public void State_SetAsDefender()
        {
            IsAttacking = false;
            CanAdd = false;
            IsDefencing = true;
            Console.WriteLine(PlayerName + " defending! " + ThisPlayersNumber);
        }

        public void State_SetAsCanAdd()
        {
            IsAttacking = false;
            CanAdd = true;
            IsDefencing = false;
            Console.WriteLine(PlayerName + " can add! " + ThisPlayersNumber);
        }

        public void State_SetAsMutedFromBattle() //teammate
        {
            IsAttacking = false;
            CanAdd = false;
            IsDefencing = false;
            Console.WriteLine(PlayerName + " watching how his ally defending! " + ThisPlayersNumber);
        }

        public void State_SetAsFinished()
        {
            IsAttacking = false;
            IsDefencing = false;
            CanAdd = false;
            IsFinished = true;
        }
    }
}
