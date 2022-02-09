using MartianRobots.Api.Translators;
using MartianRobots.Api.Validators;
using MartianRobots.Common.Exceptions;
using MartianRobots.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MartianRobots.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MissionController : ControllerBase
    {

        private readonly IMissionService missionService;


        public MissionController(IMissionService missionService)
        {
            this.missionService = missionService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var missions = await missionService.GetPastMissions();
            return Ok(missions);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody][MissionString] string input)
        {
            var mission = MissionTranslator.TranslateInput(input);
            var completedMission = await missionService.RunMission(mission);
            var output = MissionTranslator.TranslateOutput(completedMission);

            return Ok(output);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Guid id)
        {
            try
            {
                var completedMission = await missionService.ReRunMission(id);
                var output = MissionTranslator.TranslateOutput(completedMission);

                return Ok(output);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }


    }
}
