using Frameworks.Domain.Contracts;
using Frameworks.Domain.Implementations;
using Frameworks.Entities;
using Frameworks.Repositories.Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Frameworks.Domain.Tests
{
    public class ProgrammingLanguageServiceTest
    {
        [Fact]
        public void ProgrammingLanguageService_GetByIdWithFrameworks()
        {
            dynamic testData = GetTestData(1, 2, 1);
            ProgrammingLanguage programmingLanguageWithFrameworks = testData.ProgrammingLanguageService.GetByIdWithFrameworks(testData.ProgrammingLanguage.Id);

            Assert.NotNull(programmingLanguageWithFrameworks);
            Assert.Equal(testData.ProgrammingLanguage.Id, programmingLanguageWithFrameworks.Id);
            Assert.NotNull(programmingLanguageWithFrameworks.Frameworks);
            Assert.NotEqual(programmingLanguageWithFrameworks.Frameworks.Count(), 0);
            Assert.Equal(programmingLanguageWithFrameworks.Frameworks.First().Id, testData.Framework.Id);
        }

        [Fact]
        public void ProgrammingLanguageService_GetByIdWithFrameworks_NonRelatedFrameworks()
        {
            dynamic testData = GetTestData(1, 2, 2);
            ProgrammingLanguage programmingLanguageWithFrameworks = testData.ProgrammingLanguageService.GetByIdWithFrameworks(testData.ProgrammingLanguage.Id);

            Assert.NotNull(programmingLanguageWithFrameworks);
            Assert.Equal(testData.ProgrammingLanguage.Id, programmingLanguageWithFrameworks.Id);
            Assert.NotNull(programmingLanguageWithFrameworks.Frameworks);
            Assert.Equal(programmingLanguageWithFrameworks.Frameworks.Count(), 0);
        }

        [Fact]
        public void ProgrammingLanguageService_GetByIdWithFramework_NonExsitingProgrammingLanguage()
        {
            dynamic testData = GetTestData(1, 2, 1);
            ProgrammingLanguage programmingLanguageWithFrameworks = testData.ProgrammingLanguageService.GetByIdWithFrameworks(2);

            Assert.Null(programmingLanguageWithFrameworks);
        }

        private T GetMock<T>(Action<Mock<T>> action)
            where T : class
        {
            var frameworkMock = new Mock<T>();
            action(frameworkMock);
            return frameworkMock.Object;
        }

        private dynamic GetTestData(int languageId, int frameworkId, int referencedLanguageId)
        {
            var programmingLanguage = new ProgrammingLanguage
            {
                Id = languageId,
                Name = "PL"
            };
            var framework = new Framework
            {
                Id = frameworkId,
                Name = "F",
                ProgrammingLanguageId = referencedLanguageId
            };

            var programmingLanguageRepository = GetMock<IProgrammingLanguageRepository>(mock =>
            {
                mock.Setup(plr => plr.GetById(languageId)).Returns(programmingLanguage);
            });
            var frameworkRepository = GetMock<IFrameworkRepository>(mock =>
            {
                mock.Setup(fr => fr.GetAll()).Returns(new List<Framework> { framework });
            });

            IProgrammingLanguageService programmingLanguageService = new ProgrammingLanguageService(programmingLanguageRepository, frameworkRepository);

            return new 
            {
                ProgrammingLanguage = programmingLanguage,
                Framework = framework,
                ProgrammingLanguageService = programmingLanguageService
            };
        }
    }
}
