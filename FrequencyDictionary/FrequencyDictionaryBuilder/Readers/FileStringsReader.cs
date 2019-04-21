using FrequencyDictionaryBuilder.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FrequencyDictionaryBuilder.Readers
{
    /// <summary>
    /// Input data reader
    /// </summary>
    public class FileStringsReader : IInputReader
    {
        /// <summary>
        /// Reads source string by string
        /// </summary>
        /// <param name="input">Source stream</param>
        /// <returns>Enumeration of words</returns>
        public IEnumerable<string> ReadSource(Stream input)
        {
            string line;
            using (var reader = new StreamReader(input, Encoding.GetEncoding("Windows-1251")))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    var words = line.Split(' ');
                    foreach (var word in words)
                    {
                        if (!string.IsNullOrEmpty(word))
                        {
                            yield return word;
                        }
                    }
                }
            }
        }
    }
}
