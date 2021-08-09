using InstructionProcessor.Console.Models;
using InstructionProcessor.Console.Services.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                var sw = new Stopwatch();
                sw.Start();
                var action = actionFactory.GetStrategy(instruction.Action);

                instruction.EvalutatedResult = action.Evaluate(instruction.Values, instructionDictionary, actionFactory);

                sw.Stop();
                System.Console.WriteLine($"Evaluated instruction: {instruction.Action} {string.Join(", ", instruction.Values)} in {sw.ElapsedMilliseconds}");
            }

            return instruction.EvalutatedResult.Value;
        }
    }
}
