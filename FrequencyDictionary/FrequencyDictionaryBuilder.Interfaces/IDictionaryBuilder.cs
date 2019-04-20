using System.Collections.Generic;

namespace FrequencyDictionaryBuilder.Interfaces
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