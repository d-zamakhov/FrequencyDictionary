using FrequencyDictionaryBuilder;
using FrequencyDictionaryBuilder.Modules;
using Ninject;
using System;

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

            kernel = new StandardKernel(new TextFileBuilderModule());

            try
            {
                Console.WriteLine($"Frequency Dictionary Builder start: source = {source} target = {target}");
                RunBuilder(source, target);
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

        private static void RunBuilder(string source, string target)
        {
            var dictionaryBuilder = kernel.Get<IDictionaryBuilder>();
            var data = dictionaryBuilder.BuildDictionary(source);
            dictionaryBuilder.SaveDictionary(target);
        }
    }
}
