using Frameworks.Domain.Contracts;
using Frameworks.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Frameworks.Api.Controllers
{
    /// <summary>
    /// Frameworks controller
    /// </summary>
    [Route("api/frameworks")]
    public class FrameworksController : Controller
    {
        private readonly IFrameworkService _frameworkService;

        /// <summary>
        /// Frameworks controller constructor
        /// </summary>
        public FrameworksController(IFrameworkService frameworkService)
            :base()
        {
            _frameworkService = frameworkService;
        }

        /// <summary>
        /// Gets all the frameworks sorted by popularity
        /// </summary>
        /// <returns>
        /// All the frameworks sorted by popularity
        /// </returns>
        [HttpGet]
        public IEnumerable<Framework> Get()
        {
            return _frameworkService.GetAll();
        }

        /// <summary>
        /// Gets all the frameworks sorted by popularity including their programming language
        /// </summary>
        /// <returns>
        /// All the frameworks sorted by popularity including their programming language
        /// </returns>
        [HttpGet("programming-languages")]
        public IEnumerable<Framework> GetWithProgrammingLanguage()
        {
            return _frameworkService.GetAllWithProgrammingLanguage();
        }

        /// <summary>
        /// Gets the framework identified by id
        /// </summary>
        /// <param name="id">The framework id</param>
        /// <returns>
        /// The framework identified by id
        /// </returns>
        [HttpGet("{id}")]
        public Framework Get(int id)
        {
            return _frameworkService.GetById(id);
        }

        /// <summary>
        /// Gets the framework identified by id including its programming language
        /// </summary>
        /// <param name="id">The framework id</param>
        /// <returns>
        /// The framework identified by id including its programming language
        /// </returns>
        [HttpGet("{id}/programming-languages")]
        public Framework GetWithProgrammingLanguage(int id)
        {
            return _frameworkService.GetByIdWithProgrammingLanguage(id);
        }

        /// <summary>
        /// Creates a new framework
        /// </summary>
        /// <param name="framework">The new framework data</param>
        /// <returns>The new framework</returns>
        [HttpPost]
        public Framework Post([FromBody]Framework framework)
        {
            return _frameworkService.Create(framework);
        }

        /// <summary>
        /// Updates the framework identified by id with the framework data received as paramter
        /// </summary>
        /// <param name="id">The framework id</param>
        /// <param name="framework">The new framework data</param>
        /// <returns>The updated framework</returns>
        [HttpPut("{id}")]
        public Framework Put(int id, [FromBody]Framework framework)
        {
            return _frameworkService.Update(id, framework);
        }

        /// <summary>
        /// Deletes the framework identified by id
        /// </summary>
        /// <param name="id">The framework id</param>
        /// <returns>The deleted framework</returns>
        [HttpDelete("{id}")]
        public Framework Delete(int id)
        {
            return _frameworkService.Delete(id);
        }
    }
}
