using System.Collections.Generic;
using System.IO;

namespace FrequencyDictionaryBuilder.Interfaces
{
    /// <summary>
    /// Dictionary builder interface
    /// </summary>
    public interface IDictionaryBuilder
    {
        /// <summary>
        /// Builds dictionary from source
        /// </summary>
        /// <param name="source">Data source</param>
        /// <returns>Word count dictionary</returns>
        Dictionary<string, long> BuildDictionary(Stream source);

        /// <summary>
        /// Writes dictionary to target
        /// </summary>
        /// <param name="target">Target</param>
        void SaveDictionary(Stream target);
    }
}