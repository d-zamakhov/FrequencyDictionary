using FrequencyDictionaryBuilder.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FrequencyDictionaryBuilder.Readers
{
    /// <summary>
    /// Reader from file
    /// </summary>
    public class FileStringsReader : IInputReader
    {
        /// <summary>
        /// Reads string by string
        /// </summary>
        /// <param name="reader">Source text reader</param>
        /// <returns>Enumeration of words in file</returns>
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
