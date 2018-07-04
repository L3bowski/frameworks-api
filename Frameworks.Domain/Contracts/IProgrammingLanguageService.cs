using Frameworks.Entities;
using System.Collections.Generic;

namespace Frameworks.Domain.Contracts
{
    public interface IProgrammingLanguageService
    {
        IEnumerable<ProgrammingLanguage> GetAll();

        IEnumerable<ProgrammingLanguage> GetAllWithFrameworks();

        ProgrammingLanguage GetById(int id);

        ProgrammingLanguage GetByIdWithFrameworks(int id);

        ProgrammingLanguage Create(ProgrammingLanguage programmingLanguage);

        ProgrammingLanguage Update(int id, ProgrammingLanguage programmingLanguage);

        ProgrammingLanguage Delete(int id);
    }
}
