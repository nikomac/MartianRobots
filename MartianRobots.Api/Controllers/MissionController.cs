using MartianRobots.Common.Exceptions;
using MartianRobots.Contract.V1.Translators;
using MartianRobots.Contract.V1.Validators;
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

        /// <summary>
        /// Recovers all missions.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var missions = await missionService.GetPastMissions();
            var missionsDTO = MissionTranslator.Translate(missions);
            return Ok(missionsDTO);
        }

        /// <summary>
        /// Runs and saves a mission.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     "5 3\n1 1 E\nRFRFRFRF\n3 2 N\nFRRFLLFFRRFLL\n0 3 W\nLLFFFRFLFL"
        ///
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody][MissionString] string input)
        {
            var mission = MissionTranslator.TranslateInput(input);
            var completedMission = await missionService.RunMission(mission);
            var output = MissionTranslator.TranslateOutput(completedMission);

            return Ok(output);
        }

        /// <summary>
        /// Reruns and saves an existing mission.
        /// </summary>
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
