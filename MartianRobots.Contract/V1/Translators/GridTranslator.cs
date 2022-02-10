using MartianRobots.Common.Entities;
using MartianRobots.Contract.V1.DTO;
using System.Collections.Generic;
using System.Linq;

namespace MartianRobots.Contract.V1.Translators
{
    public static class GridTranslator
    {


        public static GridDTO Translate(Grid grid)
        {
            return new GridDTO
            {
                MaxX = grid.MaxX,
                MaxY = grid.MaxY,
            };
        }
        public static IEnumerable<GridDTO> Translate(IEnumerable<Grid> grids)
        {
            return grids.Select(grid => Translate(grid));
        }

    }
}
