namespace Genny.Controllers
{
    using Genny.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Int32 Controller
    /// </summary>
    [Route("longs")]
    [ApiController]
    [Produces("application/json")]
    public class LongController : ControllerBase
    {
        private readonly IGeneratorService generatorService;

        /// <summary>
        /// Instantiates a Long Controller
        /// </summary>
        /// <param name="generatorService"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public LongController(IGeneratorService generatorService)
        {
            this.generatorService = generatorService ?? throw new ArgumentNullException(nameof(generatorService));
        }

        /// <summary>
        /// Generates a list of ints
        /// </summary>
        /// <param name="numberOfItems">Number of ints desired</param>
        /// <param name="floor">Minimum value of ints to be generated</param>
        /// <param name="ceiling">Maximum value of ints to be generated</param>
        /// <returns>List of ints</returns>
        [HttpGet]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        public IActionResult Get(
            [FromQuery][Range(1, 1000)] int numberOfItems = 100,
            [FromQuery][Range(long.MinValue, long.MaxValue)] long floor = long.MinValue,
            [FromQuery][Range(long.MinValue, long.MaxValue)] long ceiling = long.MaxValue
            )
        {
            try
            {
                var result = generatorService.Longs(numberOfItems, floor, ceiling);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
