using Frameworks.Entities;
using Frameworks.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Frameworks.Repositories.Implementations
{
    public class ProgrammingLanguageRepository : IProgrammingLanguageRepository
    {
        private IEnumerable<ProgrammingLanguage> _programmingLanguages { get; set; }

        private int _nextId { get; set; }

        public ProgrammingLanguageRepository()
        {
            _nextId = 1;
            _programmingLanguages = new List<ProgrammingLanguage> {
                new ProgrammingLanguage { Id = _nextId++, Name = "JavaScript" }
            };
        }

        public IEnumerable<ProgrammingLanguage> GetAll()
        {
            return _programmingLanguages;
        }

        public ProgrammingLanguage GetById(int id)
        {
            return _programmingLanguages.FirstOrDefault(pl => pl.Id == id);
        }

        public ProgrammingLanguage Create(ProgrammingLanguage programmingLanguage)
        {
            var newProgrammingLanguage = new ProgrammingLanguage
            {
                Id = _nextId++,
                Name = programmingLanguage.Name
            };
            _programmingLanguages = _programmingLanguages.Concat(new List<ProgrammingLanguage> { newProgrammingLanguage });
            return newProgrammingLanguage;
        }

        public ProgrammingLanguage Update(int id, ProgrammingLanguage programmingLanguage)
        {
            var updatedLanguage = GetById(id);
            if (updatedLanguage != null)
            {
                updatedLanguage.Name = programmingLanguage.Name;
            }
            return updatedLanguage;
        }

        public ProgrammingLanguage Delete(int id)
        {
            var deletedLanguage = GetById(id);
            _programmingLanguages = _programmingLanguages.Where(f => f.Id != id);
            return deletedLanguage;
        }
    }
}
