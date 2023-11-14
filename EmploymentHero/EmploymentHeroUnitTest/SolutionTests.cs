using EmployementHeroTest;
using System.Diagnostics;

namespace EmploymentHeroUnitTest
{
    [TestFixture]
    public class SolutionTests
    {
        Solution sol = new Solution();

        [Test]
        public void PerformanceTest()
        {
            // Generate a large number of connections
            int n = 10000;
            string[] Connections = new string[n];
            for (int i = 0; i < n - 1; i++)
            {
                Connections[i] = $"{i}:{i + 1}";
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Execute the function
            int result = sol.solution(Connections, "0", $"{n - 1}");

            stopwatch.Stop();
            long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

            // Check the result and print the time taken
            Assert.That(result, Is.EqualTo(n - 1));
            Console.WriteLine($"Time taken: {elapsedMilliseconds} ms");

            // Optionally, you can assert that the time should be below a certain threshold
            Assert.LessOrEqual(elapsedMilliseconds, 200);  // for example, less than 100 ms
        }

        [TestCase(new string[] { "Martin:Job", "Kim:Job", "martin:David", "Kim:Larsey", "Larsey:Job" }, "Martin", "Job", 1)]
        [TestCase(new string[] { "Martin:Job", "Kim:Job", "Kim:David", "Kim:Larsey", "Larsey:Job", "Larsey:David" }, "martin", "David", 2)]
        [TestCase(new string[] { "martin:Kim", "Kim:David", "David:Larsey", "Larsey:Job" }, "Martin", "job", 4)]
        [TestCase(new string[] { "Martin:Kim", "Kim:David", "David:Larsey", "Larsey:Job", "Job:Zoe", "Zoe:Alan" }, "martin", "ALAN", 6)]
        [TestCase(new string[] { "Martin:Kim", "Kim:David", "David:Larsey", "Larsey:Job", "Job:Zoe", "Zoe:Alan", "Alan:Steve" }, "MARTIN", "steve", 7)]
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