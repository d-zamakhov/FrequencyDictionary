using System.Collections.Generic;
using FrequencyDictionaryBuilder.Interfaces;

namespace FrequencyDictionaryBuilder
{
    /// <summary>
    /// Dictionary builder interface
    /// </summary>
    public interface IDictionaryBuilder
    {
        /// <summary>
        /// Gets or sets input data reader
        /// </summary>
        IInputReader Reader { get; set; }

        /// <summary>
        /// Gets or sets output data writer
        /// </summary>
        IOutputWriter Writer { get; set; }

        /// <summary>
        /// Buildes dictionary from source
        /// </summary>
        /// <param name="source">Data source</param>
        /// <param name="trimChars">Chars to trim from the words</param>
        /// <returns></returns>
        Dictionary<string, long> BuildDictionary(object source);

        /// <summary>
        /// Writes dictionary to target
        /// </summary>
        /// <param name="target"></param>
        void SaveDictionary(object target);
    }
}