using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public class Deck
    {
        public List<Card> GameDeck;

        public Deck()
        {
            GameDeck = new List<Card>();
        }

        public void buildDeck()
        {
            string[] suits = new string[] { "Spades", "Clubs", "Diamonds", "Hearts" };
            string[] kinds = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            foreach (var suit in suits)
            {
                foreach (var kind in kinds)
                {
                    GameDeck.Add(new Card() { Suit = suit, Kind = kind });
                }
            }
        }       
    }
}
