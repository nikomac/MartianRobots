using MartianRobots.Contract.V1.Translators;
using MartianRobots.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MartianRobots.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RobotController : ControllerBase
    {

        private readonly IRobotRepository robotRepository;


        public RobotController(IRobotRepository robotRepository)
        {
            this.robotRepository = robotRepository;
        }

        /// <summary>
        /// Recovers all robots.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var robots = await robotRepository.GetAll();
            var robotsDTO = RobotTranslator.Translate(robots);
            return Ok(robotsDTO);
        }

        /// <summary>
        /// Recovers lost robots.
        /// </summary>
        [HttpGet("lost")]
        public async Task<IActionResult> GetLost()
        {
            var robots = await robotRepository.GetLost();
            var robotsDTO = RobotTranslator.Translate(robots);
            return Ok(robotsDTO);
        }


    }
}
