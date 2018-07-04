using Frameworks.Entities;
using System.Collections.Generic;

namespace Frameworks.Repositories.Contracts
{
    public interface IProgrammingLanguageRepository
    {
        IEnumerable<ProgrammingLanguage> GetAll();

        ProgrammingLanguage GetById(int id);

        ProgrammingLanguage Create(ProgrammingLanguage programmingLanguage);

        ProgrammingLanguage Update(int id, ProgrammingLanguage programmingLanguage);

        ProgrammingLanguage Delete(int id);
    }
}
