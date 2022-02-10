using MartianRobots.Contract.V1.Translators;
using MartianRobots.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MartianRobots.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GridController : ControllerBase
    {

        private readonly IGridRepository gridRepository;


        public GridController(IGridRepository gridRepository)
        {
            this.gridRepository = gridRepository;
        }

        /// <summary>
        /// Recovers all grids.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var grids = await gridRepository.GetAll();
            var gridsDTO = GridTranslator.Translate(grids);
            return Ok(gridsDTO);
        }       


    }
}
