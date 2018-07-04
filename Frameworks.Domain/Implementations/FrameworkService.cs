using Frameworks.Domain.Contracts;
using Frameworks.Entities;
using Frameworks.Repositories.Contracts;
using System.Collections.Generic;

namespace Frameworks.Domain.Implementations
{

    public class FrameworkService : IFrameworkService
    {
        private IFrameworkRepository _frameworkRepository { get; set; }

        private IProgrammingLanguageRepository _programmingLanguageRepository { get; set; }

        public FrameworkService(IFrameworkRepository frameworkRepository, IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _frameworkRepository = frameworkRepository;
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public IEnumerable<Framework> GetAll()
        {
            return _frameworkRepository.GetAll();
        }

        public IEnumerable<Framework> GetAllWithProgrammingLanguage()
        {
            var frameworks = GetAll();
            foreach(Framework framework in frameworks) {
                SetProgrammingLanguage(framework);
            }
            return frameworks;
        }

        public Framework GetById(int id)
        {
            return _frameworkRepository.GetById(id);
        }

        public Framework GetByIdWithProgrammingLanguage(int id)
        {
            var framework = GetById(id);
            if (framework != null)
            {
                SetProgrammingLanguage(framework);
            }
            return framework;
        }

        private void SetProgrammingLanguage(Framework framework)
        {
            framework.ProgrammingLanguage = _programmingLanguageRepository.GetById(framework.ProgrammingLanguageId);
        }

        public Framework Create(Framework framework)
        {
            return _frameworkRepository.Create(framework);
        }

        public Framework Update(int id, Framework framework)
        {
            return _frameworkRepository.Update(id, framework);
        }

        public Framework Delete(int id)
        {
            return _frameworkRepository.Delete(id);
        }
    }
}
