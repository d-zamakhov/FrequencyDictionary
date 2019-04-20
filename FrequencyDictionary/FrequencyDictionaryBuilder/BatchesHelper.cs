using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrequencyDictionaryBuilder
{
    public static class BatchesHelper
    {
        /// <summary>
        /// Splits enumeration into batches
        /// </summary>
        /// <param name="source">Source enumerable</param>
        /// <param name="batchSize">Number of element in batch</param>
        /// <returns>Enumeration of batches</returns>
        public static IEnumerable<List<T>> ToBatches<T>(this IEnumerable<T> source, int batchSize)
        {
            List<T> batch = new List<T>(batchSize);
            int index = 0;
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                batch.Add(enumerator.Current);
                index++;
                if (index == batchSize)
                {
                    index = 0;
                    yield return batch;
                }
                if (index == 0)
                {
                    batch = new List<T>(batchSize);
                }
            }
            if (batch != null && batch.Any())
            {
                yield return batch;
            }
        }
    }
}
