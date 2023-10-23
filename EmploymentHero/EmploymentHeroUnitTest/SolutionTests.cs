using EmployementHeroTest;
namespace EmploymentHeroUnitTest
{
    [TestFixture]
    public class SolutionTests
    {
        Solution sol = new Solution();

        [TestCase(new string[] { "Martin:Job", "Kim:Job", "martin:David", "Kim:Larsey", "Larsey:Job" }, "Martin", "Job", 1)]
        [TestCase(new string[] { "Martin:Job", "Kim:Job", "Kim:David", "Kim:Larsey", "Larsey:Job", "Larsey:David" }, "martin", "David", 2)]
        [TestCase(new string[] { "martin:Kim", "Kim:David", "David:Larsey", "Larsey:Job" }, "Martin", "job", 3)]
        [TestCase(new string[] { "Martin:Kim", "Kim:David", "David:Larsey", "Larsey:Job", "Job:Zoe", "Zoe:Alan" }, "martin", "ALAN", 5)]
        [TestCase(new string[] { "Martin:Kim", "Kim:David", "David:Larsey", "Larsey:Job", "Job:Zoe", "Zoe:Alan", "Alan:Steve" }, "MARTIN", "steve", 6)]
        [TestCase(new string[] { "Martin:Job", "Kim:Job", "martin:David", "Kim:Larsey", "Larsey:Job" }, "Martin", "Zoe", -1)]
        [TestCase(new string[] { }, "Martin", "Job", -1)]
        [TestCase(new string[] { "Martin:Kim", "Kim:David", "David:Larsey" }, "Martin", "Job", -1)]
        [TestCase(new string[] { "Martin:Kim", "Kim:David", "David:Larsey" }, "martin", "martin", -1)]
        [TestCase(new string[] { "Martin:Kim", "Kim:Martin" }, "martin", "David", -1)]
        [TestCase(new string[] { "Martin:Kim" }, "martin", "kim", 1)]
        [TestCase(new string[] { "Martin:Kim" }, "KIM", "MARTIN", 1)]
        [TestCase(new string[] { "Martin:Kim", "Kim:Martin" }, "martin", "martin", -1)]
        public void TestSolution(string[] Connections, string Name1, string Name2, int expected)
        {
            Assert.That(sol.solution(Connections, Name1, Name2), Is.EqualTo(expected));
        }
    }

}