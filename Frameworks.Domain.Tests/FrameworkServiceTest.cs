using Frameworks.Domain.Contracts;
using Frameworks.Domain.Implementations;
using Frameworks.Entities;
using Frameworks.Repositories.Contracts;
using Moq;
using System;
using Xunit;

namespace Frameworks.Domain.Tests
{
    public class FrameworkServiceTest
    {
        [Fact]
        public void FrameworkService_GetByIdWithProgrammingLanguage()
        {
            dynamic testData = GetTestData(1, 2, 1);
            Framework frameworkWithProgrammingLanguage = testData.FrameworkService.GetByIdWithProgrammingLanguage(testData.Framework.Id);

            Assert.NotNull(frameworkWithProgrammingLanguage);
            Assert.Equal(testData.Framework.Id, frameworkWithProgrammingLanguage.Id);
            Assert.NotNull(frameworkWithProgrammingLanguage.ProgrammingLanguage);
            Assert.Equal(testData.ProgrammingLanguage.Id, frameworkWithProgrammingLanguage.ProgrammingLanguage.Id);
        }

        [Fact]
        public void FrameworkService_GetByIdWithProgrammingLanguage_NonExsitingProgrammingLanguage()
        {
            dynamic testData = GetTestData(1, 2, 2);
            Framework frameworkWithProgrammingLanguage = testData.FrameworkService.GetByIdWithProgrammingLanguage(testData.Framework.Id);

            Assert.NotNull(frameworkWithProgrammingLanguage);
            Assert.Equal(testData.Framework.Id, frameworkWithProgrammingLanguage.Id);
            Assert.Null(frameworkWithProgrammingLanguage.ProgrammingLanguage);
        }

        [Fact]
        public void FrameworkService_GetByIdWithProgrammingLanguage_NonExsitingFramework()
        {
            dynamic testData = GetTestData(1, 2, 1);
            Framework frameworkWithProgrammingLanguage = testData.FrameworkService.GetByIdWithProgrammingLanguage(3);

            Assert.Null(frameworkWithProgrammingLanguage);
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
                mock.Setup(fr => fr.GetById(frameworkId)).Returns(framework);
            });

            IFrameworkService frameworkService = new FrameworkService(frameworkRepository, programmingLanguageRepository);

            return new 
            {
                ProgrammingLanguage = programmingLanguage,
                Framework = framework,
                FrameworkService = frameworkService
            };
        }
    }
}
