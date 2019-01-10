using F1WM.ApiModel;
using F1WM.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1WM.Controllers
{
    [Route("api/[controller]")]
    public class SeasonsController : ControllerBase
    {
        private readonly ISeasonsService service;
        private readonly ILoggingService logger;

        [HttpGet("rules")]
        [Produces("application/json", Type = typeof(SeasonRules))]
        public async Task<IActionResult> GetSeasonRules([FromQuery(Name = "year")] int? year)
        {
            try
            {
                var seasonRules = await service.GetSeasonRules(year);
                if (seasonRules != null)
                {
                    return Ok(seasonRules);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
                throw ex;
            }
        }

        public SeasonsController(ISeasonsService service, ILoggingService logger)
        {
            this.service = service;
            this.logger = logger;
        }
    }
}
