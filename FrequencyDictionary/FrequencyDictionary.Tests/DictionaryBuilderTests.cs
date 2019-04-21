using FrequencyDictionaryBuilder.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace FrequencyDictionaryBuilder.Tests
{
    [TestClass]
    public class DictionaryBuilderTests
    {
        [TestMethod]
        public void BuildDictionaryTest()
        {
            var reference = new Dictionary<string, long>()
            {
                { "w3", 3 },
                { "w2", 2  },
                { "w1", 1 },
            };

            var mockReader = new Mock<IInputReader>();
            var mockWriter = new Mock<IOutputWriter>();

            mockReader.Setup(r => r.ReadSource(null)).Returns(() => new List<string>() { "W1", "w2", "W2", "W3", "w3", "W3" });
            var builder = new DictionaryBuilder(mockReader.Object, mockWriter.Object);
            var data = builder.BuildDictionary(null);

            Assert.IsTrue(reference.Count == data.Count);
            var refKeys = reference.Keys.ToArray();
            var refValues = reference.Values.ToArray();
            var dataKeys = data.Keys.ToArray();
            var dataValues = data.Values.ToArray();

            for (int i = 0; i < reference.Count; i++)
            {
                Assert.IsTrue(string.Equals(dataKeys[i], refKeys[i]));
                Assert.IsTrue(dataValues[i] == refValues[i]);
            }
        }

        [TestMethod]
        public void RandomBuildDictionaryTest()
        {
            long refLength = 10000;
            var generator = new RandomGenerator();
            var mockReader = new Mock<IInputReader>();
            var mockWriter = new Mock<IOutputWriter>();
            mockReader.Setup(r => r.ReadSource(null)).Returns(() => generator.GetSequence(refLength));
            var builder = new DictionaryBuilder(mockReader.Object, mockWriter.Object);
            var data = builder.BuildDictionary(null);
            var dataSummary = data.Values.Sum();
            Assert.AreEqual(refLength, dataSummary);
        }

        [TestMethod]
        public void BatcherTest()
        {
            var input = new List<int>()
            {
                1,2,3,4,5,6,7,8,9,0
            };

            var reference = new List<List<int>>()
            {
                new List<int>() { 1, 2, 3 },
                new List<int>() { 4, 5, 6 },
                new List<int>() { 7, 8, 9 },
                new List<int>() { 0 }
            };


            var batches = input.ToBatches(3).ToList();

            Assert.AreEqual(reference.Count, batches.Count);
            for(int i=0; i < reference.Count; i++)
            {
                Assert.AreEqual(reference[i].Count, batches[i].Count);

                for(int j=0; j<reference[i].Count; j++)
                {
                    Assert.AreEqual(reference[i][j], batches[i][j]);
                }
            }
        }
    }
}
