using FrequencyDictionaryBuilder.Interfaces;
using FrequencyDictionaryBuilder.Modules.Readers;
using FrequencyDictionaryBuilder.Modules.Writers;
using Ninject.Modules;

namespace FrequencyDictionaryBuilder.Modules
{
    /// <summary>
    /// Dictionary builder with text file input/output
    /// </summary>
    public class TextFileBuilderModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IInputReader>().To<FileReader>();
            this.Bind<IOutputWriter>().To<FileWriter>();
            this.Bind<IDictionaryBuilder>().To<DictionaryBuilder>();
        }
    }
}
