using Frameworks.Domain.Contracts;
using Frameworks.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Frameworks.Api.Controllers
{
    /// <summary>
    /// Programming languages controller
    /// </summary>
    [Route("api/[controller]")]
    public class ProgrammingLanguageController : Controller
    {
        private readonly IProgrammingLanguageService _programmingLanguageService;

        /// <summary>
        /// Programming languages controller constructor
        /// </summary>
        public ProgrammingLanguageController(IProgrammingLanguageService programmingLanguageService)
            :base()
        {
            _programmingLanguageService = programmingLanguageService;
        }

        /// <summary>
        /// Gets all the programming languages
        /// </summary>
        /// <returns>
        /// All the programming languages
        /// </returns>
        [HttpGet]
        public IEnumerable<ProgrammingLanguage> Get()
        {
            return _programmingLanguageService.GetAll();
        }

        /// <summary>
        /// Gets all the programming languages including their frameworks
        /// </summary>
        /// <returns>
        /// All the programming languages including their frameworks
        /// </returns>
        [HttpGet("frameworks")]
        public IEnumerable<ProgrammingLanguage> GetWithFrameworks()
        {
            return _programmingLanguageService.GetAllWithFrameworks();
        }

        /// <summary>
        /// Gets the programming language identified by id
        /// </summary>
        /// <param name="id">The programming language id</param>
        /// <returns>
        /// The programming language identified by id
        /// </returns>
        [HttpGet("{id}")]
        public ProgrammingLanguage Get(int id)
        {
            return _programmingLanguageService.GetById(id);
        }

        /// <summary>
        /// Gets the programming language identified by id including its frameworks
        /// </summary>
        /// <param name="id">The programming language id</param>
        /// <returns>
        /// The programming language identified by id including its frameworks
        /// </returns>
        [HttpGet("{id}/frameworks")]
        public ProgrammingLanguage GetWithFrameworks(int id)
        {
            return _programmingLanguageService.GetByIdWithFrameworks(id);
        }

        /// <summary>
        /// Creates a new programming language
        /// </summary>
        /// <param name="programmingLanguage">The new programming language data</param>
        /// <returns>The new programming language</returns>
        [HttpPost]
        public ProgrammingLanguage Post([FromBody]ProgrammingLanguage programmingLanguage)
        {
            return _programmingLanguageService.Create(programmingLanguage);
        }

        /// <summary>
        /// Updates the programming language identified by id with the programming language data received as paramter
        /// </summary>
        /// <param name="id">The programming language id</param>
        /// <param name="programmingLanguage">The new programming language data</param>
        /// <returns>The updated programming language</returns>
        [HttpPut("{id}")]
        public ProgrammingLanguage Put(int id, [FromBody]ProgrammingLanguage programmingLanguage)
        {
            return _programmingLanguageService.Update(id, programmingLanguage);
        }

        /// <summary>
        /// Deletes the programming language identified by id
        /// </summary>
        /// <param name="id">The programming language id</param>
        /// <returns>The deleted programming language</returns>
        [HttpDelete("{id}")]
        public ProgrammingLanguage Delete(int id)
        {
            return _programmingLanguageService.Delete(id);
        }
    }
}
