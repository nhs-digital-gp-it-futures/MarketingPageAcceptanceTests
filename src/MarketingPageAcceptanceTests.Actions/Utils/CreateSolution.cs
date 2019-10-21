﻿using System;

namespace MarketingPageAcceptanceTests.Actions.Utils
{
    public static class CreateSolution
    {
        const string prefix = "AutoSol";

        public static Solution CreateNewSolution()
        {
            var Id = $"{prefix}{RandomSolId(14 - prefix.Length)}";
            Solution solution = new Solution
            {
                Id = Id,
                Name = $"Automated Solution {Id}",
                Version = "1.0.0"
            };

            return solution;
        }

        private static string RandomSolId(int length)
        {
            string characters = "1234567890";
            Random rand = new Random();

            string result = "";
            for (int i = 0; i < length; i++)
            {
                result += characters[rand.Next(characters.Length)];
            }
            return result;
        }
    }

    public sealed class Solution
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string OrganisationId { get; set; } = "1000000";
        public int PublishedStatusId { get; set; } = 1;
        public int AuthorityStatusId { get; set; } = 1;
        public int SupplierStatusId { get; set; } = 1;
    }
}