namespace MarketingPageAcceptanceTests.TestData.Capabilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MarketingPageAcceptanceTests.TestData.Information;
    using MarketingPageAcceptanceTests.TestData.Utils;

    public static class CapabilitiesGenerator
    {
        public static async Task<IEnumerable<SolutionCapabilities>> GenerateListOfSolutionCapabilitiesAsync(
            string connectionString,
            string solutionId,
            int length = 5)
        {
            var solCaps = new List<SolutionCapabilities>();

            var capabilities = (await Capability.GetAllAsync(connectionString)) // Get list of Capabilities
                .OrderBy(s => Guid.NewGuid()) // Reorder them randomly
                .ToList();

            for (var i = 0; i < length; i++)
            {
                solCaps.Add(new SolutionCapabilities
                { SolutionID = solutionId, CapabilityId = capabilities[i].CapabilityRef });
            }

            return solCaps.OrderBy(s => s.CapabilityId);
        }

        public static async Task<IEnumerable<EpicDto>> GenerateCapabilityEpicsAsync(
            string connectionString,
            IEnumerable<SolutionCapabilities> capabilities)
        {
            var solEpics = new List<EpicDto>();

            foreach (var capability in capabilities.Select(s => s.CapabilityId))
            {
                var epics = await EpicDto.GetAllByIdPrefixAsync(connectionString, $"{capability}E");

                foreach (var epic in epics)
                {
                    epic.EpicFinalAssessmentResult = SelectRandomAssessmentResult(await AssessmentStatusesAsync(connectionString));
                    solEpics.Add(epic);
                }
            }

            return solEpics;
        }

        public static async Task<IEnumerable<EpicDto>> GenerateEpicsForCapabilityNotSelectedAsync(
            string connectionString,
            IEnumerable<SolutionCapabilities> capabilities)
        {
            var solEpics = new List<EpicDto>();

            var allCaps = (await Capability.GetAllAsync(connectionString)).Select(s => s.CapabilityRef);

            foreach (var capability in capabilities.Select(s => s.CapabilityId))
            {
                var epics = await EpicDto.GetAllByIdPrefixAsync(connectionString, $"{allCaps.First(s => s != capability)}E");

                foreach (var epic in epics)
                {
                    epic.EpicFinalAssessmentResult = SelectRandomAssessmentResult(await AssessmentStatusesAsync(connectionString));
                    solEpics.Add(epic);
                }
            }

            return solEpics;
        }

        private static string SelectRandomAssessmentResult(IEnumerable<string> assessmentLevels)
        {
            return RandomInformation.GetRandomItem(assessmentLevels);
        }

        private static async Task<IEnumerable<string>> AssessmentStatusesAsync(string connectionString)
        {
            var assessmentLevelsQuery = "SELECT Name FROM SolutionEpicStatus";

            return await SqlExecutor.ExecuteAsync<string>(connectionString, assessmentLevelsQuery, null);
        }
    }
}
