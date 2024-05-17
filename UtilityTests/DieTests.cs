using Utility;

namespace UtilityTests
{
    [TestClass]
    public class DieTests
    {
        [TestMethod]
        public void DieHasSixSides()
        {
            Die SixSidedDie = new Die(6);
            Assert.AreEqual(SixSidedDie.SideCount, (uint)6);
        }

        [TestMethod]
        public void DieHasMoreThanOneSide()
        {
            try
            {
                Die SixSidedDie = new Die(1);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.GetType().ToString(), "System.ArgumentOutOfRangeException");
            }
        }

        [TestMethod]
        public void DieRollIsWithinRange()
        {
            Die OneHundredSidedDie = new Die(100);
            for (int i = 0; i < 100; i++)
            {
                uint roll = OneHundredSidedDie.Roll();
                Assert.IsTrue(roll > 0);
                Assert.IsTrue(roll <= 100);
            }
        }
    }
}