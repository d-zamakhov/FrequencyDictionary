using System.Collections.Generic;

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
        Dictionary<string, long> BuildDictionary(object source);

        /// <summary>
        /// Writes dictionary to target
        /// </summary>
        /// <param name="target"></param>
        void SaveDictionary(object target);
    }
}