using FrequencyDictionaryBuilder.Interfaces;
using Ninject;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FrequencyDictionaryBuilder
{
    /// <summary>
    /// Frequency dictionary builder
    /// </summary>
    public class DictionaryBuilder : IDictionaryBuilder
    {
        private int batchSize = 10000;

        private Dictionary<string, long> data;

        /// <summary>
        /// Gets or sets input data reader
        /// </summary>
        [Inject]
        public IInputReader Reader { get; set; }

        /// <summary>
        /// Gets or sets output writer
        /// </summary>
        [Inject]
        public IOutputWriter Writer { get; set; }

        /// <summary>
        /// Counts words occurences in source
        /// </summary>
        /// <param name="source">Source input</param>
        /// <param name="trimChars">Chars to be trimmed from words</param>
        /// <returns>Dictionary of words and occurences numbers</returns>
        public Dictionary<string, long> BuildDictionary(object source)
        {
            var words = this.Reader.ReadSource(source);
            var dictionary = new ConcurrentDictionary<string, long>();

            Parallel.ForEach(words.ToBatches(this.batchSize), wordsBatch =>
            {
                foreach (var word in wordsBatch)
                {
                    if (!string.IsNullOrEmpty(word))
                    {
                        dictionary.AddOrUpdate(word.ToLower(), 1, (key, oldVal) => Interlocked.Increment(ref oldVal));
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
        public void SaveDictionary(object target)
        {
            if (this.data != null && this.data.Any())
            {
                this.Writer.Write(this.data, target);
            }
        }
    }
}
