﻿using FrequencyDictionaryBuilder.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FrequencyDictionaryBuilder.Readers
{
    public class FileCharsReader : IInputReader
    {
        /// <summary>
        /// Reads contents by symbols
        /// </summary>
        /// <param name="filePath">Source text file</param>
        /// <returns>Enumeration of words in file</returns>
        public IEnumerable<string> ReadSource(Stream input)
        {
            int maxWordLength = 10;
            List<char> chars = new List<char>(maxWordLength);
            using (var reader = new StreamReader(input, Encoding.GetEncoding("Windows-1251")))
            {
                while (!reader.EndOfStream)
                {
                    var c = (char)reader.Read();
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
            }
            if (chars.Any())
            {
                yield return new string(chars.ToArray());
            }
        }
    }
}