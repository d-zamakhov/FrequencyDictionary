using FrequencyDictionaryBuilder.Readers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FrequencyDictionary.Tests
{
    [TestClass]
    public class ReadersTests
    {
        [TestMethod]
        public void StringsReaderTest()
        {
            var reference = new List<string>() { "w1", "w2", "w3", "w4", "w5" };
            var inputString = string.Join(" \r\n", reference);
            byte[] byteArray = Encoding.GetEncoding("Windows-1251").GetBytes(inputString);
            MemoryStream stream = new MemoryStream(byteArray);

            var reader = new FileStringsReader();
            var result = new List<string>(reader.ReadSource(stream));
            Assert.AreEqual(reference.Count, result.Count);

            for (int i = 0; i < reference.Count; i++)
            {
                Assert.IsTrue(string.Equals(reference[i], result[i]));
            }
        }

        [TestMethod]
        public void CharsReaderTest()
        {
            var reference = new List<string>() { "w1", "w2", "w3", "w4", "w5" };
            var inputString = string.Join(" \r\n", reference);
            byte[] byteArray = Encoding.GetEncoding("Windows-1251").GetBytes(inputString);
            MemoryStream stream = new MemoryStream(byteArray);

            var reader = new FileCharsReader();
            var result = new List<string>(reader.ReadSource(stream));
            Assert.AreEqual(reference.Count, result.Count);

            for (int i = 0; i < reference.Count; i++)
            {
                Assert.IsTrue(string.Equals(reference[i], result[i]));
            }
        }
    }
}
