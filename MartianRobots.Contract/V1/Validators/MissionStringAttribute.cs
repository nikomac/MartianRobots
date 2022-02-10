using MartianRobots.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MartianRobots.Contract.V1.Validators
{

    public class MissionStringAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var missionLines = value.ToString().Split('\n');
            var validationErrors = new List<string>();

            var gridLine = missionLines.ElementAtOrDefault(0);
            var gridErrors = ValidateGrid(gridLine);
            validationErrors.AddRange(gridErrors);

            var robotsLines = missionLines.Skip(1);
            var robotsErrores = ValidateRobots(robotsLines);
            validationErrors.AddRange(robotsErrores);

            if (validationErrors.Any())
                return new ValidationResult(string.Join(",", validationErrors));

            return ValidationResult.Success;
        }

        public List<string> ValidateGrid(string input)
        {
            var gridLine = input.Trim();
            var errors = new List<string>();
            if (gridLine == null || !gridLine.Any())
            {
                errors.Add("GRID INPUT NOT FOUND");
            }
            else
            {
                var gridParams = gridLine.Split(' ');
                var gridX = gridParams.ElementAtOrDefault(0);
                var gridY = gridParams.ElementAtOrDefault(1);
                if (!IsValidPosition(gridX, gridY)) errors.Add("GRID COORDINATES INVALID");
            }
            return errors;
        }

        public List<string> ValidateRobots(IEnumerable<string> input)
        {
            var errors = new List<string>();
            if (!input.Any())
            {
                errors.Add("ROBOT/S INPUT NOT FOUND");
            }
            else if (input.Count() < 2)
            {
                errors.Add($"ROBOT 0 MUST HAVE 2 INPUT LINES");
            }
            else
            {
                for (int i = 0; i < input.Count() / 2; i++)
                {
                    var robotLines = input.Skip(i * 2).Take(2);
                    if (robotLines.Count() != 2)
                    {
                        errors.Add($"ROBOT {i} MUST HAVE 2 INPUT LINES");
                    }
                    else
                    {
                        var robotCoordinates = robotLines.ElementAt(0).Trim().Split(' ');
                        var robotX = robotCoordinates.ElementAtOrDefault(0);
                        var robotY = robotCoordinates.ElementAtOrDefault(1);
                        var robotO = robotCoordinates.ElementAtOrDefault(2);
                        if (!IsValidCoordinate(robotX, robotY, robotO)) errors.Add($"ROBOT {i} COORDINATES INVALID");
                        var robotInstructions = robotLines.ElementAt(1).Trim();
                        if (!IsValidInstructions(robotInstructions)) errors.Add($"ROBOT {i} INSTRUCTIONS INVALID");
                    }
                }
            }
            return errors;
        }

        const int maxX = 50;
        const int maxY = 50;
        const int minX = 0;
        const int minY = 0;
        const int maxInstructions = 100;

        public bool IsValidPosition(string x, string y)
        {
            return (
                (int.TryParse(x?.Trim(), out int xInt) && xInt >= minX && xInt <= maxX)
                && (int.TryParse(y?.Trim(), out int yInt) && yInt >= minY && yInt <= maxY)
                );
        }

        public bool IsValidCoordinate(string x, string y, string o)
        {
            return (
                IsValidPosition(x, y)
                && Enum.TryParse<Orientation>(o.Trim(), true, out _)
                );
        }

        public bool IsValidInstructions(string i)
        {
            var instructions = i.Trim();

            return instructions.Length < maxInstructions && instructions.All(i => Enum.TryParse<Instruction>(i.ToString(), true, out _));
        }

    }
}
