using Bogus;
using System;

namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    public static class CreateSolution
    {
        const string prefix = "AutoSol";

        public static Solution CreateNewSolution()
        {
            var faker = new Faker();

            var Id = RandomSolId(faker);
            Solution solution = new Solution
            {
                Id = Id,
                Name = faker.Name.JobTitle(),
                Version = faker.System.Semver()
            };

            if (System.Diagnostics.Debugger.IsAttached)
            {
                Console.WriteLine(solution.ToString());
            }

            return solution;
        }

        private static string RandomSolId(Faker faker)
        {
            var suffix = faker.Random.Digits(14 - prefix.Length);

            return $"{prefix}{string.Join("", suffix)}";
        }

        public static SolutionDetail CreateCompleteSolutionDetail(Solution solution, SolutionDetail solutionDetail)
        {
            return CreateSolutionDetails.CreateNewSolutionDetail(solution.Id, solutionDetail.SolutionDetailId, 5);
        }
    }
}
