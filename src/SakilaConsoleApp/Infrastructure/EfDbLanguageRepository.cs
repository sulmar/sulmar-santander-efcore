using SakilaConsoleApp.Abstractions;
using SakilaConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakilaConsoleApp.Infrastructure
{
    internal class EfDbLanguageRepository : ILanguageRepository
    {
        private SakilaContext db;

        public EfDbLanguageRepository(SakilaContext db)
        {
            this.db = db;
        }

        public void Add(Language language)
        {
            db.Languages.Add(language);

            db.SaveChanges();
        }

        public List<Language> GetAllLanguages()
        {
            return db.Languages.ToList();
        }

        public Language GetLanguage(int id)
        {
            return db.Languages.Find(id);
        }
    }
}
