namespace Genny.Api.Controllers
{
    using Genny.Api.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// UInt64 Controller
    /// </summary>
    [Route("ulongs")]
    [ApiController]
    [Produces("application/json")]
    public sealed class ULongController : ControllerBase
    {
        private readonly IGeneratorService generatorService;

        /// <summary>
        /// Instantiates a Long Controller
        /// </summary>
        /// <param name="generatorService"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ULongController(IGeneratorService generatorService)
        {
            this.generatorService = generatorService ?? throw new ArgumentNullException(nameof(generatorService));
        }

        /// <summary>
        /// Generates a list of ulongs
        /// </summary>
        /// <param name="numberOfItems">Number of ulongs desired</param>
        /// <param name="floor">Minimum value of ulongs to be generated</param>
        /// <param name="ceiling">Maximum value of ulongs to be generated</param>
        /// <returns>List of ulongs</returns>
        [HttpGet]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ForbidResult), StatusCodes.Status429TooManyRequests)]
        public IActionResult Get(
            [FromQuery][Range(1, 1000)] int numberOfItems = 100,
            [FromQuery][Range(ulong.MinValue, ulong.MaxValue)] ulong floor = 0,
            [FromQuery][Range(ulong.MinValue, ulong.MaxValue)] ulong ceiling = ulong.MaxValue
            )
        {
            try
            {
                var result = generatorService.ULongs(numberOfItems, floor, ceiling);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
