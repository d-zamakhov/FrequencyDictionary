using FrequencyDictionary.Modules;
using FrequencyDictionaryBuilder.Interfaces;
using Ninject;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace FrequencyDictionary
{
    class Program
    {
        private static StandardKernel kernel;

        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Please, provide data source and target strings as parameters.");
                return;
            }

            var source = args[0];
            var target = args[1];

            kernel = new StandardKernel(new TextFileCharsBuilderModule());

            try
            {
                Console.WriteLine($"Frequency Dictionary Builder start: source = {source} target = {target}");
                var dictionaryBuilder = kernel.Get<IDictionaryBuilder>();
                using (var sourceStream = new FileStream(source, FileMode.Open))
                {
                    var sw = Stopwatch.StartNew();
                    var data = dictionaryBuilder.BuildDictionary(sourceStream);
                    sw.Stop();
                }
                Console.WriteLine($"Dictionary built in {0} ms. Now saving.");
                using (var targetStream = new FileStream(target, FileMode.Create))
                {
                    dictionaryBuilder.SaveDictionary(targetStream);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Console.WriteLine("Finished");
            }
        }
    }
}
