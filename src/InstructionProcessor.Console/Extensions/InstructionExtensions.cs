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
            IDictionary<int, Instruction> instructionDictionary,
            IActionStrategyFactory actionFactory)
        {
            if (!instruction.EvalutatedResult.HasValue)
            {
                var action = actionFactory.GetStrategy(instruction.Action);

                instruction.EvalutatedResult = action.Evaluate(instruction.Values, instructionDictionary, actionFactory);
            }

            return instruction.EvalutatedResult.Value;
        }
    }
}
