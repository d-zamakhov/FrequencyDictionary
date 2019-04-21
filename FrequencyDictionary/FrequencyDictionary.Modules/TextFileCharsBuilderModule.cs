using FrequencyDictionaryBuilder;
using FrequencyDictionaryBuilder.Interfaces;
using FrequencyDictionaryBuilder.Readers;
using FrequencyDictionaryBuilder.Writers;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrequencyDictionary.Modules
{
    public class TextFileCharsBuilderModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IInputReader>().To<FileCharsReader>();
            this.Bind<IOutputWriter>().To<FileWriter>();
            this.Bind<IDictionaryBuilder>().To<DictionaryBuilder>();
        }
    }
}
