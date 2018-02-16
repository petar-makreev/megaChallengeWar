using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cards;

namespace megaChallengeWar
{
    public class Game
    {
        private Player _player1;
        private Player _player2;

        public Game(string player1Name, string player2Name)
        {
            _player1 = new Player() { Name = player1Name };
            _player2 = new Player() { Name = player2Name };
        }

        public string Play()
        {
            Deal deal = new Deal();

            string result = "<h3>Dealing Cards ...</h3>";
            result += deal.PerformDeal(_player1, _player2);

            result += "<h3>Begin battle ...</h3>";
            int round = 0;
            while (_player1.Hand.Count != 0 && _player2.Hand.Count != 0)
            {
                Battle battle = new Battle();
                result += battle.PerformBattle(_player1, _player2);

                round++;
                if (round > 20)
                    break;
            }
            result += determineWinner();
            return result;
        }

        private string determineWinner()
        {
            string result = "<strong>";
            if (_player1.Hand.Count > _player2.Hand.Count)
                result += "<p /><br /> " + _player1.Name + " wins";
            if (_player2.Hand.Count > _player1.Hand.Count)
                result += "<p /><br /><span style='color:red;'>" + _player2.Name + " wins</span>";

            result += "<br />" + _player1.Name + ": " + _player1.Hand.Count + "<br /><span style='color:red;'>" + _player2.Name + ": " + _player2.Hand.Count + "</span></strong>";
            return result;
        }
    }
}