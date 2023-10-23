using EmployementHeroTest;
namespace EmploymentHeroUnitTest
{

    [TestFixture]
    public class ContainsCharactersInOrderTests
    {
        [Test]
        public void TestValidCases()
        {
            Assert.IsTrue(Test2.ContainsCharactersInOrder("ABOUYTN", "AN"));
            Assert.IsTrue(Test2.ContainsCharactersInOrder("ABOUYTN", "AB"));
            Assert.IsTrue(Test2.ContainsCharactersInOrder("ABOUYTN", "TN"));
            Assert.IsTrue(Test2.ContainsCharactersInOrder("ABOUYTN", "BO"));
            Assert.IsTrue(Test2.ContainsCharactersInOrder("ABOUYTN", ""));
            Assert.IsTrue(Test2.ContainsCharactersInOrder("ABOUYTN", "ATN"));
        }

        [Test]
        public void TestInvalidCases()
        {
            Assert.IsFalse(Test2.ContainsCharactersInOrder("ABOUYTN", "NA"));
            Assert.IsFalse(Test2.ContainsCharactersInOrder("ABOUYTN", "BA"));
            Assert.IsFalse(Test2.ContainsCharactersInOrder("ABOUYTN", "F"));
            Assert.IsFalse(Test2.ContainsCharactersInOrder("ABOUYTN", "Z"));
            Assert.IsFalse(Test2.ContainsCharactersInOrder("", "A"));
        }
    }

}
