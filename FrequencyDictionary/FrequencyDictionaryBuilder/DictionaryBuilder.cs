using FrequencyDictionaryBuilder.Interfaces;
using Ninject;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FrequencyDictionaryBuilder
{
    /// <summary>
    /// Frequency dictionary builder
    /// </summary>
    public class DictionaryBuilder : IDictionaryBuilder
    {
        /// <summary>
        /// number of words in single batch for processing
        /// </summary>
        private int batchSize = 10000;

        private Dictionary<string, long> data;

        private readonly IInputReader reader;

        private readonly IOutputWriter writer;

        [Inject]
        public DictionaryBuilder(IInputReader reader, IOutputWriter writer)
        {
            this.reader = reader ?? throw new ArgumentNullException("reader");
            this.writer = writer ?? throw new ArgumentNullException("writer");
        }

        /// <summary>
        /// Counts words occurences in source
        /// </summary>
        /// <param name="source">Source input</param>
        /// <param name="trimChars">Chars to be trimmed from words</param>
        /// <returns>Dictionary of words and occurences numbers</returns>
        public Dictionary<string, long> BuildDictionary(Stream source)
        {
            var words = this.reader.ReadSource(source);
            var dictionary = new ConcurrentDictionary<string, long>();

            Parallel.ForEach(words.ToBatches(this.batchSize), wordsBatch =>
            {
                foreach (var word in wordsBatch)
                {
                    if (!string.IsNullOrEmpty(word))
                    {
                        dictionary.AddOrUpdate(word.ToLower(), 1, (key, oldVal) => oldVal + 1);
                    }
                }
            });

            this.data = dictionary.OrderBy(r => r.Value).Reverse().ToDictionary(r=>r.Key, r=>r.Value);
            return this.data;
        }

        /// <summary>
        /// Stores counted data to output
        /// </summary>
        /// <param name="target">Target output</param>
        public void SaveDictionary(Stream target)
        {
            if (this.data != null && this.data.Any())
            {
                this.writer.Write(this.data, target);
            }
        }
    }
}
