using System.Collections.Generic;
using Frameworks.Entities;

namespace Frameworks.Domain.Contracts
{
    public interface IFrameworkService
    {
        IEnumerable<Framework> GetAll();

        IEnumerable<Framework> GetAllWithProgrammingLanguage();

        Framework GetById(int id);

        Framework GetByIdWithProgrammingLanguage(int id);

        Framework Create(Framework framework);

        Framework Update(int id, Framework framework);

        Framework Delete(int id);
    }
}
