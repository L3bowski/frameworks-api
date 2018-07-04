using Frameworks.Entities;
using Frameworks.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Frameworks.Repositories.Implementations
{
    public class FrameworkRepository : IFrameworkRepository
    {
        private IEnumerable<Framework> _frameworks { get; set; }

        private int _nextId { get; set; }

        public FrameworkRepository()
        {
            _nextId = 1;
            _frameworks = new List<Framework> {
                new Framework { Id = _nextId++, Name = "VueJS", ProgrammingLanguageId = 1 },
                new Framework { Id = _nextId++, Name = "React", ProgrammingLanguageId = 1 },
                new Framework { Id = _nextId++, Name = "Angular", ProgrammingLanguageId = 1 }
            };
        }

        public IEnumerable<Framework> GetAll()
        {
            return _frameworks;
        }

        public Framework GetById(int id)
        {
            return _frameworks.FirstOrDefault(f => f.Id == id);
        }

        public Framework Create(Framework framework)
        {
            var newFramework = new Framework
            {
                Id = _nextId++,
                Name = framework.Name
            };
            _frameworks = _frameworks.Concat(new List<Framework> { newFramework });
            return newFramework;
        }

        public Framework Update(int id, Framework framework)
        {
            var updatedFramework = GetById(id);
            if (updatedFramework != null)
            {
                updatedFramework.Name = framework.Name;
            }
            return updatedFramework;
        }

        public Framework Delete(int id)
        {
            var deletedFramework = GetById(id);
            _frameworks = _frameworks.Where(f => f.Id != id);
            return deletedFramework;
        }
    }
}
