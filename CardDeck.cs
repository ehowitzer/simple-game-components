namespace Utility
{
    public enum CardSuit { Club, Diamond, Heart, Spade, Joker };
	public enum CardOrdinal { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King };

	public class Card
	{
		private CardSuit _suit;
		public CardSuit Suit
		{
			get { return _suit; }
		}

		private CardOrdinal _ordinal;
		public CardOrdinal Ordinal
		{
			get { return _ordinal; }
		}

		private Card()
		{
		}

		public Card(CardSuit suit, CardOrdinal ordinal)
		{
			_suit = suit;
			_ordinal = ordinal;
		}
	}

	public class CardDeck
	{
		private List<Card> _cards = new List<Card>();

		public uint CardCount
		{
			get { return (uint)_cards.Count; }
		}

		public CardDeck()
		{
		}

		public CardDeck(List<Card> cards)
		{
			_cards = cards;
		}

		public bool Contains(Card card)
		{
			return _cards.Contains(card);
		}

		public void AddToTop(Card card)
		{
			_cards.Insert(0, card);
		}

		public void AddToBottom(Card card)
		{
			_cards.Insert(_cards.Count, card);
		}

		public Card RemoveFromTop()
		{
			Card temp = _cards[0];
			_cards.Remove(temp);

			return temp;
		}

		public Card RemoveFromBottom()
		{
			Card temp = _cards[_cards.Count];
			_cards.Remove(temp);

			return temp;
		}

		public static List<Card> GenerateCommonDeck(bool withJokers)
		{
			List<Card> cards = new List<Card>();

			for (int i = 0; i <= (int)CardSuit.Spade; i++)
			{
				for (int j = 0; j <= (int)CardOrdinal.King; j++)
				{
					cards.Add(new Card((CardSuit)i, (CardOrdinal)j));
				}
			}

			if (withJokers)
			{
				cards.Add(new Card(CardSuit.Joker, CardOrdinal.Ace));
				cards.Add(new Card(CardSuit.Joker, CardOrdinal.Two));
			}

			return cards;
		}

		public void Deal(uint numberOfHands, uint numberOfCardsEach, out List<List<Card>> hands)
		{
			if (numberOfHands * numberOfCardsEach > _cards.Count)
			{
				throw new ArithmeticException("Numnber of hands times number of cards per hand cannot be more than the number of cards in the deck.");
			}

			hands = new List<List<Card>>((int)numberOfHands);
			for (int i = 0; i < numberOfHands; i++)
			{
				hands.Add(new List<Card>());
			}

			for (int j = 0; j < numberOfCardsEach; j++)
			{
				for (int i = 0; i < numberOfHands; i++)
				{
					hands[i].Add(this.RemoveFromTop());
				}
			}
		}

		public void Shuffle()
		{
			Random rand = new Random();
			List<Card> shuffled = new List<Card>();

			List<Card> tempDeck = new List<Card>();
			tempDeck.AddRange(_cards);

			while (tempDeck.Count > 0)
			{
				int i = rand.Next(tempDeck.Count);
				Card temp = tempDeck[i];
				shuffled.Add(temp);
				tempDeck.RemoveAt(i);
			}

			_cards = shuffled;
		}

		public Card PeekTop()
		{
			return _cards[0];
		}

		public Card PeekBottom()
		{
			return _cards[_cards.Count];
		}

		public void Cut()
		{
			Random rand = new Random();
			int cutLocation = rand.Next(0, (int)this.CardCount - 1);

			List<Card> tempDeck = new List<Card>();

			for (int i = cutLocation + 1; i < _cards.Count; i++)
			{
				tempDeck.Add(_cards[i]);			 
			}

			for (int i = 0; i <= cutLocation; i++)
			{
				tempDeck.Add(_cards[i]);
			}

			_cards = tempDeck;
		}
	}
}
