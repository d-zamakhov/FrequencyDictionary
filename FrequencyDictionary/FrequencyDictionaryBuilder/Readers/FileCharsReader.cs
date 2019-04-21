using FrequencyDictionaryBuilder.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FrequencyDictionaryBuilder.Readers
{
    public class FileCharsReader : IInputReader
    {
        /// <summary>
        /// Reads file contents by symbols
        /// </summary>
        /// <param name="filePath">Source text file</param>
        /// <returns>Enumeration of words in file</returns>
        public IEnumerable<string> ReadSource(object filePathObj)
        {
            var filePath = filePathObj.ToString();
            using (var fileReader = new StreamReader(filePath, Encoding.GetEncoding("Windows-1251")))
            {
                int maxWordLength = 0;
                List<char> chars = new List<char>();
                
                while (!fileReader.EndOfStream)
                {
                    var c = (char)fileReader.Read();
                    if (c == ' ' || c == '\r' || c == '\n')
                    {
                        if (chars.Any())
                        {
                            maxWordLength = maxWordLength < chars.Count ? chars.Count : maxWordLength; 
                            yield return new string(chars.ToArray());
                        }

                        chars = new List<char>(maxWordLength);
                    }
                    else
                    {
                        chars.Add(c);
                    }
                }

                if (chars.Any())
                {
                    yield return new string(chars.ToArray());
                }
            }
        }
    }
}