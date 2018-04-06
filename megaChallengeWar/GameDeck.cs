using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Cards;

namespace megaChallengeWar
{
    public class GameDeck
    {
        public Deck gameDeck;
        private Random _random;
        private StringBuilder _sb;

        public GameDeck()
        {
            gameDeck = new Deck();
        }

        public string Deal(Player player1, Player player2)
        {
            _sb = new StringBuilder();
            while (gameDeck._deck.Count > 0)
            {
                // Deal the top card to each player
                dealCard(player1);
                dealCard(player2);
            }
            return _sb.ToString();
        }

        private void dealCard(Player player)
        {
            Card card = gameDeck._deck.ElementAt(0);
            player.Hand.Add(card);
            gameDeck._deck.Remove(card);
            displayDeal(card, player);
        }

        private void displayDeal(Card card, Player player)
        {
            _sb.Append("<br/>");
            _sb.Append(player.Name);
            _sb.Append(" is dealt the ");
            _sb.Append(card.Kind);
            _sb.Append(" of ");
            _sb.Append(card.Suit);
        }
    }
}