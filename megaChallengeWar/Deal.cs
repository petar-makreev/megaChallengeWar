using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Cards;

namespace megaChallengeWar
{
    public class Deal
    {
        public string DealResult;
        private Deck _deck;

        private Random _random;
        private StringBuilder _sb;

        public Deal()
        {
            DealResult = "";
            _deck = new Deck();
            _deck.buildDeck();

            _random = new Random();
            _sb = new StringBuilder();
        }

        public string PerformDeal(Player player1, Player player2)
        {
            while (_deck.GameDeck.Count > 0)
            {
                dealCard(player1);
                dealCard(player2);
            }
            DealResult = _sb.ToString();
            return DealResult;
        }
       
        private void dealCard(Player player)
        {
            Card card = _deck.GameDeck.ElementAt(_random.Next(_deck.GameDeck.Count));
            player.Hand.Add(card);
            _deck.GameDeck.Remove(card);

            displayDeal(player, card);
        }

        private void displayDeal(Player player, Card card)
        {
            _sb.Append("<br />");
            _sb.Append(player.Name);
            _sb.Append(" is dealt the ");
            _sb.Append(card.Kind);
            _sb.Append(" of ");
            _sb.Append(card.Suit);
        }
    }
}