using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cards;

namespace megaChallengeWar
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand;

        public Player()
        {
            Hand = new List<Card>();
        }
    }
}