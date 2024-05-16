using Utility;

namespace UtilityTests
{
    [TestClass]
    public class DeckUnitTests
    {
        private TestContext? testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext? TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CreateNormalDeck()
        {
            // Create a deck without jokers.
            CardDeck deck = new CardDeck(CardDeck.GenerateCommonDeck(false));
            Assert.AreEqual(deck.CardCount, (uint)52);
        }

        [TestMethod]
        public void Perform54CardDealInto4Hands()
        {
            // Create a deck with jokers.
            CardDeck deck = new CardDeck(CardDeck.GenerateCommonDeck(true));

            // Deal out 52 cards into 4 hands (13 each).
            uint handCount = 4;
            List<List<Card>> hands;
            deck.Deal(handCount, 13, out hands);

            Assert.AreEqual((uint)hands.Count, handCount);

            for (int i = 0; i < handCount; i++)
            {
                Assert.AreEqual((uint)hands[i].Count, (uint)13);
            }

            // There should be two cards left in the deck.
            Assert.AreEqual((uint)2, deck.CardCount);
        }

        [TestMethod]
        public void Perform52CardDealInto4Hands()
        {
            // Create a deck with jokers.
            CardDeck deck = new CardDeck(CardDeck.GenerateCommonDeck(false));

            // Deal out 52 cards into 4 hands (13 each).
            uint handCount = 4;
            List<List<Card>> hands;
            deck.Deal(handCount, 13, out hands);

            Assert.AreEqual((uint)hands.Count, handCount);

            for (int i = 0; i < handCount; i++)
            {
                Assert.AreEqual((uint)hands[i].Count, (uint)13);
            }

            // There should be no cards left in the deck.
            Assert.AreEqual((uint)0, deck.CardCount);
        }

        [TestMethod]
        public void Perform54CardDealInto3Hands()
        {
            // Create a deck with jokers.
            CardDeck deck = new CardDeck(CardDeck.GenerateCommonDeck(false));

            // Deal out 52 cards into 3 hands (17 each).
            uint handCount = 3;
            List<List<Card>> hands;
            deck.Deal(handCount, 17, out hands);

            Assert.AreEqual((uint)hands.Count, handCount);

            for (int i = 0; i < handCount; i++)
            {
                Assert.AreEqual((uint)hands[i].Count, (uint)17);
            }

            // There should be no cards left in the deck.
            Assert.AreEqual((uint)1, deck.CardCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void PerformInvalidDeal()
        {
            // Create a deck with jokers.
            CardDeck deck = new CardDeck(CardDeck.GenerateCommonDeck(true));

            // Deal out 54 cards into 5 hands (not enough cards).
            uint handCount = 5;
            List<List<Card>> hands;
            deck.Deal(handCount, 13, out hands);
        }

        [TestMethod]
        public void PerformShuffle()
        {
            // Create a deck with jokers.
            CardDeck deck = new CardDeck(CardDeck.GenerateCommonDeck(true));
            uint startCount = deck.CardCount;

            deck.Shuffle();

            Assert.AreEqual(deck.CardCount, startCount);

            // Ensure that all the cards are unique.
            CardDeck verifyDeck = new CardDeck();
            while (deck.CardCount > 0)
            {
                Card temp = deck.RemoveFromTop();
                Assert.IsFalse(verifyDeck.Contains(temp));

                verifyDeck.AddToBottom(temp);
            }
        }

        [TestMethod]
        public void PerformCut()
        {
            // Create a deck with jokers.
            CardDeck deck = new CardDeck(CardDeck.GenerateCommonDeck(true));
            uint startCount = deck.CardCount;
            Card topCard = deck.PeekTop();

            deck.Cut();

            Assert.AreEqual(deck.CardCount, startCount);
            Assert.AreNotEqual(topCard, deck.PeekTop());

            // Ensure that all the cards are unique.
            CardDeck verifyDeck = new CardDeck();
            while (deck.CardCount > 0)
            {
                Card temp = deck.RemoveFromTop();
                Assert.IsFalse(verifyDeck.Contains(temp));

                verifyDeck.AddToBottom(temp);
            }
        }
    }
}
