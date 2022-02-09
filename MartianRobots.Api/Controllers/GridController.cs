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
    public class GridController : ControllerBase
    {

        private readonly IGridRepository gridRepository;


        public GridController(IGridRepository gridRepository)
        {
            this.gridRepository = gridRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var grids = await gridRepository.GetAll();
            return Ok(grids);
        }       


    }
}
