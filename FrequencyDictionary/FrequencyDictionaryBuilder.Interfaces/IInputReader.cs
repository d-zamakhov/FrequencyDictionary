using System.Collections.Generic;

namespace FrequencyDictionaryBuilder.Interfaces
{
    /// <summary>
    /// Input reader
    /// </summary>
    public interface IInputReader
    {
        /// <summary>
        /// Reads data from the source
        /// </summary>
        /// <param name="source">Data source</param>
        /// <returns>Enumeration of found words</returns>
        IEnumerable<string> ReadSource(object source);
    }
}
