using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public class Deck
    {
        public List<Card> _deck;
        private List<Card> _cards;
        private Random _random;
        private StringBuilder _sb;

        public Deck()
        {
            _deck = new List<Card>();
            _cards = new List<Card>();
            _random = new Random();

            cardList();
            randomizeDeck();
        }

        public void cardList()
        {
            string[] suits = new string[] { "Clubs", "Diamonds", "Hearts", "Spades" };
            string[] kinds = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            foreach (var suit in suits)
            {
                foreach (var kind in kinds)
                {
                    _cards.Add(new Card() { Suit = suit, Kind = kind });
                }
            }
        }

        private void randomizeDeck()
        {
            while (_cards.Count > 0)
            {
                Card card = _cards.ElementAt(_random.Next(_cards.Count));
                _deck.Add(card);
                _cards.Remove(card);
            }
        }

        public void Shuffle()
        {
            List<Card> _cardStack1 = new List<Card>();
            List<Card> _cardStack2 = new List<Card>();
            _random = new Random();

            shuffleDeck(_cardStack1, _cardStack2);
        }

        private void shuffleDeck(List<Card> cardStack1, List<Card> cardStack2)
        {
            splitDeck(cardStack1, cardStack2);
            while (cardStack1.Count > 0 || cardStack2.Count > 0)
            {
                if (cardStack1.Count > 0 && cardStack2.Count > 0)
                {
                    int _stackSelection = _random.Next(1);

                    if (_stackSelection == 0)
                    {
                        drawStack(cardStack1);
                    }
                    else
                    {
                        drawStack(cardStack2);
                    }
                }
                else if (cardStack1.Count > 0 && cardStack2.Count == 0)
                {
                    drawRemaining(cardStack1);
                }
                else
                {
                    drawRemaining(cardStack2);
                }
            };
        }

        private void splitDeck(List<Card> cardStack1, List<Card> cardStack2)
        {
            int halfDeck = _deck.Count / 2;
            for (int i = 0; i < halfDeck; i++)
            {
                Card card = _deck.ElementAt(0);
                cardStack1.Add(card);
                _deck.Remove(card);
            }
            for (int i = 0; i < halfDeck; i++)
            {
                Card card = _deck.ElementAt(0);
                cardStack2.Add(card);
                _deck.Remove(card);
            }
        }

        private void drawStack(List<Card> cardStack)
        {
            Card card = cardStack.ElementAt(0);
            _deck.Add(card);
            cardStack.Remove(card);
        }

        private void drawRemaining(List<Card> cardStack)
        {
            for (int i = 0; i < cardStack.Count; i++)
            {
                Card card = cardStack.ElementAt(0);
                _deck.Add(card);
                cardStack.Remove(card);
            }
        }
    }
}
