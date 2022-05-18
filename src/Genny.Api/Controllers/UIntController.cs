namespace Genny.Api.Controllers
{
    using Genny.Api.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// UInt32 Controller
    /// </summary>
    [Route("uuints")]
    [ApiController]
    [Produces("application/json")]
    public sealed class UIntController : ControllerBase
    {
        private readonly IGeneratorService generatorService;

        /// <summary>
        /// Instantiates a UInt Controller
        /// </summary>
        /// <param name="generatorService"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UIntController(IGeneratorService generatorService)
        {
            this.generatorService = generatorService ?? throw new ArgumentNullException(nameof(generatorService));
        }

        /// <summary>
        /// Generates a list of uints
        /// </summary>
        /// <param name="numberOfItems">Number of uints desired</param>
        /// <param name="floor">Minimum value of uints to be generated</param>
        /// <param name="ceiling">Maximum value of uints to be generated</param>
        /// <returns>List of uints</returns>
        [HttpGet]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ForbidResult), StatusCodes.Status429TooManyRequests)]
        public IActionResult Get(
            [FromQuery][Range(1, 1000)] int numberOfItems = 100,
            [FromQuery][Range(uint.MinValue, uint.MaxValue)] uint floor = uint.MinValue,
            [FromQuery][Range(uint.MinValue, uint.MaxValue)] uint ceiling = uint.MaxValue
            )
        {
            try
            {
                var result = generatorService.UInts(numberOfItems, floor, ceiling);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
