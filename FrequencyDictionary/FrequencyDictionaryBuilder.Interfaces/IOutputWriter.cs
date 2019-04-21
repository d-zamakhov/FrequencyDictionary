using System.Collections.Generic;
using System.IO;

namespace FrequencyDictionaryBuilder.Interfaces
{
    /// <summary>
    /// Output writer
    /// </summary>
    public interface IOutputWriter
    {
        /// <summary>
        /// Writes dictionary to target
        /// </summary>
        /// <param name="data">Dictionary</param>
        /// <param name="target">Target</param>
        void Write(Dictionary<string, long> data, Stream target);
    }
}
