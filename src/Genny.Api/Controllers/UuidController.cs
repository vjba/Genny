using Genny.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.ComponentModel.DataAnnotations;

namespace Genny.Controllers
{
    /// <summary>
    /// UUID Controller
    /// </summary>
    [Route("uuids")]
    [ApiController]
    [Produces("application/json")]
    public class UuidController : ControllerBase
    {
        private readonly IGeneratorService generatorService;

        /// <summary>
        /// Instantiates a UUID Controller
        /// </summary>
        /// <param name="generatorService"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UuidController(IGeneratorService generatorService)
        {
            this.generatorService = generatorService ?? throw new ArgumentNullException(nameof(generatorService));
        }

        /// <summary>
        /// Generates a list of UUIDs
        /// </summary>
        /// <param name="numberOfItems">Number of UUIDs desired</param>
        /// <returns>List of UUIDs</returns>
        [HttpGet]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        public IActionResult Get([FromQuery][Range(1, 1000)] int numberOfItems = 100)
        {
            try
            {
                var result = generatorService.Uuids(numberOfItems);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
