using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketingPageAcceptanceTests.TestData.Information
{
    public static class RandomInformation
    {
        public static string RandomInformationText(int numWords = 10)
        {
            var faker = new Faker();

            return string.Join(" ", faker.Lorem.Words(numWords));
        }

        public static string RandomCharacters(int count)
        {
            var faker = new Faker();
            return string.Join("", faker.Random.String(length: count));
        }
    }
}
