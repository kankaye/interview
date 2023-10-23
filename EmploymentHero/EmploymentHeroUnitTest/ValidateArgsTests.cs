using EmployementHeroTest;

namespace EmploymentHeroUnitTest
{
    [TestFixture]
    public class ValidateArgsTests
    {
        // Valid Test Cases
        [Test]
        public void TestValidName()
        {
            Assert.AreEqual(0, Test1.ValidateArgs(new List<string> { "--name", "test" }));
        }

        [Test]
        public void TestValidNameCaseInsensitive()
        {
            Assert.AreEqual(0, Test1.ValidateArgs(new List<string> { "--NAME", "test" }));
        }

        [Test]
        public void TestValidRange()
        {
            Assert.AreEqual(0, Test1.ValidateArgs(new List<string> { "--range", "15" }));
        }

        [Test]
        public void TestValidRangeCaseInsensitive()
        {
            Assert.AreEqual(0, Test1.ValidateArgs(new List<string> { "--RANGE", "15" }));
        }

        [Test]
        public void TestValidHelp()
        {
            Assert.AreEqual(1, Test1.ValidateArgs(new List<string> { "--help" }));
        }

        [Test]
        public void TestValidHelpWithName()
        {
            Assert.AreEqual(1, Test1.ValidateArgs(new List<string> { "--help", "--name", "test" }));
        }

        [Test]
        public void TestValidHelpWithRange()
        {
            Assert.AreEqual(1, Test1.ValidateArgs(new List<string> { "--help", "--range", "15" }));
        }

        [Test]
        public void TestValidNameAndRange()
        {
            Assert.AreEqual(0, Test1.ValidateArgs(new List<string> { "--name", "test", "--range", "15" }));
        }

        [Test]
        public void TestValidRangeAndName()
        {
            Assert.AreEqual(0, Test1.ValidateArgs(new List<string> { "--range", "15", "--name", "test" }));
        }

        [Test]
        public void TestValidHelpWithNameAndRange()
        {
            Assert.AreEqual(1, Test1.ValidateArgs(new List<string> { "--help", "--name", "test", "--range", "15" }));
        }

        // Invalid Test Cases
        [Test]
        public void TestEmptyArray()
        {
            Assert.AreEqual(-1, Test1.ValidateArgs(new List<string>()));
        }

        [Test]
        public void TestMissingValueForName()
        {
            Assert.AreEqual(-1, Test1.ValidateArgs(new List<string> { "--name" }));
        }

        [Test]
        public void TestShortValueForName()
        {
            Assert.AreEqual(-1, Test1.ValidateArgs(new List<string> { "--name", "te" }));
        }

        [Test]
        public void TestLongValueForName()
        {
            Assert.AreEqual(-1, Test1.ValidateArgs(new List<string> { "--name", "thisisaverylongname" }));
        }

        [Test]
        public void TestLowValueForRange()
        {
            Assert.AreEqual(-1, Test1.ValidateArgs(new List<string> { "--range", "5" }));
        }

        [Test]
        public void TestHighValueForRange()
        {
            Assert.AreEqual(-1, Test1.ValidateArgs(new List<string> { "--range", "105" }));
        }

        [Test]
        public void TestHelpWithMissingName()
        {
            Assert.AreEqual(-1, Test1.ValidateArgs(new List<string> { "--help", "--name" }));
        }

        [Test]
        public void TestHelpWithMissingRange()
        {
            Assert.AreEqual(-1, Test1.ValidateArgs(new List<string> { "--help", "--range" }));
        }

        [Test]
        public void TestHelpWithShortName()
        {
            Assert.AreEqual(-1, Test1.ValidateArgs(new List<string> { "--help", "--name", "te" }));
        }

        [Test]
        public void TestHelpWithHighRange()
        {
            Assert.AreEqual(-1, Test1.ValidateArgs(new List<string> { "--help", "--range", "105" }));
        }

        [Test]
        public void TestDuplicateName()
        {
            Assert.AreEqual(-1, Test1.ValidateArgs(new List<string> { "--name", "test", "--name", "test2" }));
        }

        [Test]
        public void TestDuplicateRange()
        {
            Assert.AreEqual(-1, Test1.ValidateArgs(new List<string> { "--range", "15", "--range", "20" }));
        }

        [Test]
        public void TestDuplicateHelp()
        {
            Assert.AreEqual(-1, Test1.ValidateArgs(new List<string> { "--help", "--help" }));
        }

        // Additional Invalid Test Cases for Unrecognized Arguments
        [Test]
        public void TestUnrecognizedArgument()
        {
            Assert.AreEqual(-1, Test1.ValidateArgs(new List<string> { "--unknown" }));
        }

        [Test]
        public void TestValidNameWithUnrecognizedArgument()
        {
            Assert.AreEqual(-1, Test1.ValidateArgs(new List<string> { "--name", "test", "--unknown" }));
        }

        [Test]
        public void TestHelpWithUnrecognizedArgument()
        {
            Assert.AreEqual(-1, Test1.ValidateArgs(new List<string> { "--help", "--unknown" }));
        }

        [Test]
        public void TestValidRangeWithUnrecognizedArgument()
        {
            Assert.AreEqual(-1, Test1.ValidateArgs(new List<string> { "--unknown", "--range", "15" }));
        }

        [Test]
        public void TestMultipleUnrecognizedArguments()
        {
            Assert.AreEqual(-1, Test1.ValidateArgs(new List<string> { "--unknown", "--unknown2" }));
        }

        [Test]
        public void TestValidNameAndRangeWithUnrecognizedArgument()
        {
            Assert.AreEqual(-1, Test1.ValidateArgs(new List<string> { "--name", "test", "--unknown", "--range", "15" }));
        }
    }

}
