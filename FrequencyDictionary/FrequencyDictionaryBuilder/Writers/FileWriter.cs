using FrequencyDictionaryBuilder.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FrequencyDictionaryBuilder.Writers
{
    /// <summary>
    /// Output writer
    /// </summary>
    public class FileWriter : IOutputWriter
    {
        /// <summary>
        /// Writes dictionary
        /// </summary>
        /// <param name="data">Dictionary</param>
        /// <param name="filePath">Target stream</param>
        public void Write(Dictionary<string, long> data, Stream output)
        {
            using (var writer = new StreamWriter(output, Encoding.GetEncoding("Windows-1251")))
            {
                foreach (var kvp in data)
                {
                    writer.WriteLine($"{kvp.Key},{kvp.Value}");
                }
            }
        }
    }
}
