using System;
using System.Collections.Generic;
using System.Linq;
using MarketingPageAcceptanceTests.TestData.Information;
using MarketingPageAcceptanceTests.TestData.Utils;

namespace MarketingPageAcceptanceTests.TestData.Capabilities
{
    public static class CapabilitiesGenerator
    {
        public static IEnumerable<SolutionCapabilities> GenerateListOfSolutionCapabilities(string connectionString,
            string solutionId, int length = 5)
        {
            var solCaps = new List<SolutionCapabilities>();

            var capabilities = Capability.GetAll(connectionString) // Get list of Capabilities
                .OrderBy(s => Guid.NewGuid()) // Reorder them randomly                
                .ToList();

            for (var i = 0; i < length; i++)
                solCaps.Add(new SolutionCapabilities
                { SolutionID = solutionId, CapabilityId = capabilities[i].CapabilityRef });

            return solCaps.OrderBy(s => s.CapabilityId);
        }

        public static IEnumerable<EpicDto> GenerateCapabilityEpics(string connectionString,
            IEnumerable<SolutionCapabilities> capabilities)
        {
            var solEpics = new List<EpicDto>();

            foreach (var capability in capabilities.Select(s => s.CapabilityId))
            {
                var epics = EpicDto.GetAllByIdPrefix(connectionString, $"{capability}E");

                foreach (var epic in epics)
                {
                    epic.EpicFinalAssessmentResult = SelectRandomAssessmentResult(AssessmentStatuses(connectionString));
                    solEpics.Add(epic);
                }
            }

            return solEpics;
        }

        public static IEnumerable<EpicDto> GenerateEpicsForCapabilityNotSelected(string connectionString,
            IEnumerable<SolutionCapabilities> capabilities)
        {
            var solEpics = new List<EpicDto>();

            var allCaps = Capability.GetAll(connectionString).Select(s => s.CapabilityRef);

            foreach (var capability in capabilities.Select(s => s.CapabilityId))
            {
                var epics = EpicDto.GetAllByIdPrefix(connectionString, $"{allCaps.First(s => s != capability)}E");

                foreach (var epic in epics)
                {
                    epic.EpicFinalAssessmentResult = SelectRandomAssessmentResult(AssessmentStatuses(connectionString));
                    solEpics.Add(epic);
                }
            }

            return solEpics;
        }

        private static string SelectRandomAssessmentResult(IEnumerable<string> assessmentLevels)
        {
            return RandomInformation.GetRandomItem(assessmentLevels);
        }

        private static IEnumerable<string> AssessmentStatuses(string connectionString)
        {
            var assessmentLevelsQuery = "SELECT Name FROM SolutionEpicStatus";

            return SqlExecutor.Execute<string>(connectionString, assessmentLevelsQuery, null);
        }
    }
}