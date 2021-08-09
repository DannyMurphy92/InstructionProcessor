using InstructionProcessor.Console.Models;
using InstructionProcessor.Console.Services.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstructionProcessor.Console.Extensions
{
    public static class InstructionExtensions
    {
        public static int Evaluate(
            this Instruction instruction,
            IActionStrategyFactory actionFactory)
        {
            var action = actionFactory.GetStrategy(instruction.Action);

            return action.Evaluate(instruction.Values);
        }
    }
}
