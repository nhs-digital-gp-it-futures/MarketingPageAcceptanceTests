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
    }
}
