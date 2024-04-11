using SakilaConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakilaConsoleApp.Abstractions
{
    internal interface ILanguageRepository
    {
        void Add(Language language);
        List<Language> GetAllLanguages();
        Language GetLanguage(int id);
    }
}
