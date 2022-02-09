using MartianRobots.Api.Translators;
using MartianRobots.Api.Validators;
using MartianRobots.Common.Exceptions;
using MartianRobots.Repositories.Interfaces;
using MartianRobots.Services;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var robots = await robotRepository.GetAll();
            return Ok(robots);
        }       


    }
}
