using FrequencyDictionaryBuilder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FrequencyDictionaryBuilder.Tests
{ 
    /// <summary>
    /// Test generator
    /// </summary>
    public class RandomGenerator
    {
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private Random random = new Random();

        public IEnumerable<string> GetSequence(long count)
        {
            for (long i = 0; i < count; i++)
            {
                yield return RandomString(random.Next(3, 10));
            }
        }

        private string RandomString(int length)
        {
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
