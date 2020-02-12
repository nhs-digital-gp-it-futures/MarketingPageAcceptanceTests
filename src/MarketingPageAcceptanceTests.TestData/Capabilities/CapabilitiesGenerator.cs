using MarketingPageAcceptanceTests.TestData.Information;
using MarketingPageAcceptanceTests.TestData.Solutions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarketingPageAcceptanceTests.TestData.Capabilities
{
    public static class CapabilitiesGenerator
    {
        public static IEnumerable<SolutionCapabilities> GenerateListOfSolutionCapabilities(string connectionString, string solutionId, int length = 5)
        {
            List<SolutionCapabilities> solCaps = new List<SolutionCapabilities>();

            var capabilityIds = new Capability().GetAll(connectionString) // Get list of Capabilities
                .OrderBy(s => Guid.NewGuid())                             // Reorder them randomly
                .Select(s => s.CapabilityRef)
                .ToList();                                                // Return ordered list of Ref's only

            for (int i = 0; i < length; i++)
            {
                solCaps.Add(new SolutionCapabilities { SolutionID = solutionId, CapabilityId = capabilityIds[i] });
            }

            return solCaps;
        }

        public static IEnumerable<SolutionCapabilityEpics> GenerateCapabilityEpics(string connectionString, IEnumerable<SolutionCapabilities> capabilities, Solution solution)
        {
            List<SolutionCapabilityEpics> solEpics = new List<SolutionCapabilityEpics>();

            var capabilityIds = new Capability().GetAll(connectionString) // Get list of Capabilities
                .OrderBy(s => Guid.NewGuid())
                .Where(s => capabilities.Select(d => d.CapabilityId).Contains(s.CapabilityRef))
                .ToList();

            foreach(var capability in capabilityIds)
            {
                var epics = new Epic().GetAllByCapabilityId(connectionString, capability.Id);

                foreach(var epic in epics)
                {
                    solEpics.Add(
                        new SolutionCapabilityEpics 
                        { 
                            SupplierID = solution.SupplierId, 
                            CapabilityID = capability.CapabilityRef, 
                            EpicID = epic.Id, 
                            Level = LevelConversion[epic.Level], 
                            SolutionID = solution.Id,
                            EpicFinalAssessmentResult = SelectRandomAssessmentResult()
                        });
                }
            }

            return solEpics;
        }

        private static string SelectRandomAssessmentResult()
        {
            var assessmentLevels = new string[] { "Passed", "Failed", "Not Evidenced" };

            return RandomInformation.GetRandomItem(assessmentLevels);
        }

        private static Dictionary<string, string> LevelConversion = new Dictionary<string, string>
        {
            { "MUST", "Must" },
            {"MAY", "May" }
        };
    }
}
