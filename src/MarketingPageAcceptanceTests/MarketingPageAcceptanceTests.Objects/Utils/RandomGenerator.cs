using System;

namespace MarketingPageAcceptanceTests.Objects.Utils
{
    public class RandomGenerator
    {
        private Random random = new Random();
        private const string AllCharacters = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!£$%^&*(){}:@~<>?|[];#,./";

        /// <summary>
        /// </summary>
        /// <param name="stringLength">Length of the random string</param>
        /// <returns>string made up of random characters of specified length.</returns>
        public string GetRandomString(int stringLength)
        {
            string randomString = "";
            for (int i = 0; i < stringLength; i++)
            {
                randomString += AllCharacters[random.Next(AllCharacters.Length)];
            }

            return randomString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="length"></param>
        /// <returns>random index for array of specified length</returns>
        public int GetRandomPositionInArrayOfLength(int length)
        {
            return random.Next(length);
        }

    }
}
