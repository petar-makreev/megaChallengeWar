using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Cards;

namespace megaChallengeWar
{
    public class Battle
    {
        private List<Card> _bounty;
        private StringBuilder _sb;

        public Battle()
        {
            _bounty = new List<Card>();
            _sb = new StringBuilder();
        }

        public string PerformBattle(Player player1, Player player2)
        {
            Card player1Card = getCard(player1);
            Card player2Card = getCard(player2);

            performEvaluation(player1, player2, player1Card, player2Card);
            return _sb.ToString();
        }

        private Card getCard(Player player)
        {
            Card card = player.Hand.ElementAt(0);
            player.Hand.Remove(card);
            _bounty.Add(card);
            return card;
        }

        private void performEvaluation(Player player1, Player player2, Card card1, Card card2)
        {
            displayBattleCards(card1, card2);
            if (card1.CardValue() == card2.CardValue())
                war(player1, player2);
            if (card1.CardValue() > card2.CardValue())
                declareWinner(player1);
            if (card2.CardValue() > card1.CardValue())
                declareWinner(player2);
        }       

        private void declareWinner(Player player)
        {
            if (_bounty.Count == 0) return;
            displayBountyCards();
            player.Hand.AddRange(_bounty);
            _bounty.Clear();
            
            _sb.Append("<br /><strong> ");
            _sb.Append(player.Name);
            _sb.Append(" wins!</strong><br />");
        }

        private void war(Player player1, Player player2)
        {
            _sb.Append("<br />************WAR************");
            getCard(player1);
            getCard(player1);
            Card warCardPlayer1 = getCard(player1);

            getCard(player2);
            getCard(player2);
            Card warCardPlayer2 = getCard(player2);

            performEvaluation(player1, player2, warCardPlayer1, warCardPlayer2);
        }

        private void displayBattleCards(Card card1, Card card2)
        {
            _sb.Append("<br />Battle Cards: ");
            _sb.Append(card1.Kind);
            _sb.Append(" of ");
            _sb.Append(card1.Suit);
            _sb.Append(" versus ");
            _sb.Append(card2.Kind);
            _sb.Append(" of ");
            _sb.Append(card2.Suit);
        }

        private void displayBountyCards()
        {
            _sb.Append("<br />Bounty ...");

            foreach (var card in _bounty)
            {
                _sb.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;");
                _sb.Append(card.Kind);
                _sb.Append(" of ");
                _sb.Append(card.Suit);
            }
        }
    }
}