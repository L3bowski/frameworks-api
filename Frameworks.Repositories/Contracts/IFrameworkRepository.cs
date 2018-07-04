using Frameworks.Entities;
using System.Collections.Generic;

namespace Frameworks.Repositories.Contracts
{
    public interface IFrameworkRepository
    {
        IEnumerable<Framework> GetAll();

        Framework GetById(int id);

        Framework Create(Framework framework);

        Framework Update(int id, Framework framework);

        Framework Delete(int id);
    }
}
