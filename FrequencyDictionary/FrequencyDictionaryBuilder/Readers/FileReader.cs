using FrequencyDictionaryBuilder.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FrequencyDictionaryBuilder.Modules.Readers
{
    /// <summary>
    /// Reader from file
    /// </summary>
    public class FileReader : IInputReader
    {
        /// <summary>
        /// Reads file contents
        /// </summary>
        /// <param name="filePath">Source text file</param>
        /// <returns>Enumeration of words in file</returns>
        public IEnumerable<string> ReadSource(object filePathObj)
        {
            var filePath = filePathObj.ToString();
            using (var fileReader = new StreamReader(filePath, Encoding.GetEncoding("Windows-1251")))
            {
                string line;
                while ((line = fileReader.ReadLine()) != null)
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
