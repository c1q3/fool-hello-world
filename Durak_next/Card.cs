using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durak_next
{

    public class Card
    {
        public string FaceName;
        public string Suit;
        public string CardMarker; //used to understand users imput

        public int faceValue; //(1 - 36)
        public int BelongsTo; //(0 - koloda, 1,2,3,4-igrok. 5 - dump, 7 - table)

        public bool IsVisible;  // for ai

        public bool Trump;

        public Card(int rank, string suit, int faceValue) // method of adding cards to deck
        {
            this.faceValue = faceValue;
            this.Suit = suit;

            switch (rank)
            {
                case 8:
                    this.FaceName = "A";
                    break;
                case 7:
                    this.FaceName = "K";
                    break;
                case 6:
                    this.FaceName = "Q";
                    break;
                case 5:
                    this.FaceName = "J";
                    break;
                case 4:
                    this.FaceName = "10";
                    break;
                case 3:
                    this.FaceName = "9";
                    break;
                case 2:
                    this.FaceName = "8";
                    break;
                case 1:
                    this.FaceName = "7";
                    break;
                case 0:
                    this.FaceName = "6";
                    break;
            }
            this.CardMarker = CardToString();
        }  

        public string CardToString()
        {
            return FaceName + Suit;
        } // return string of Face+Suit

        public void MakeTrump(string s)
        {
            if (Suit == s)
                { 
                    Trump = true;
                }
        } // makes this card as trump
    }

}
