using Frameworks.Domain.Contracts;
using Frameworks.Entities;
using Frameworks.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Frameworks.Domain.Implementations
{
    public class ProgrammingLanguageService : IProgrammingLanguageService
    {
        private IProgrammingLanguageRepository _programmingLanguageRepository { get; set; }

        private IFrameworkRepository _frameworkRepository { get; set; }

        public ProgrammingLanguageService(IProgrammingLanguageRepository programmingLanguageRepository, IFrameworkRepository frameworkRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _frameworkRepository = frameworkRepository;
        }

        public IEnumerable<ProgrammingLanguage> GetAll()
        {
            return _programmingLanguageRepository.GetAll();
        }

        public IEnumerable<ProgrammingLanguage> GetAllWithFrameworks()
        {
            var programmingLanguages = GetAll();
            foreach (ProgrammingLanguage language in programmingLanguages)
            {
                SetFrameworks(language);
            }
            return programmingLanguages;
        }

        public ProgrammingLanguage GetById(int id)
        {
            return _programmingLanguageRepository.GetById(id);
        }

        public ProgrammingLanguage GetByIdWithFrameworks(int id)
        {
            var language = GetById(id);
            if (language != null)
            {
                SetFrameworks(language);
            }
            return language;
        }

        private void SetFrameworks(ProgrammingLanguage language)
        {
            language.Frameworks = _frameworkRepository.GetAll().Where(f => f.ProgrammingLanguageId == language.Id);
        }

        public ProgrammingLanguage Create(ProgrammingLanguage programmingLanguage)
        {
            return _programmingLanguageRepository.Create(programmingLanguage);
        }

        public ProgrammingLanguage Update(int id, ProgrammingLanguage programmingLanguage)
        {
            return _programmingLanguageRepository.Update(id, programmingLanguage);
        }

        public ProgrammingLanguage Delete(int id)
        {
            return _programmingLanguageRepository.Delete(id);
        }
    }
}
