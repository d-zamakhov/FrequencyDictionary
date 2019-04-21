using FrequencyDictionaryBuilder;
using FrequencyDictionaryBuilder.Interfaces;
using FrequencyDictionaryBuilder.Readers;
using FrequencyDictionaryBuilder.Writers;
using Ninject.Modules;

namespace FrequencyDictionary.Modules
{
    /// <summary>
    /// Dictionary builder with text file input/output
    /// </summary>
    public class TextFileStringsBuilderModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IInputReader>().To<FileStringsReader>();
            this.Bind<IOutputWriter>().To<FileWriter>();
            this.Bind<IDictionaryBuilder>().To<DictionaryBuilder>();
        }
    }
}
