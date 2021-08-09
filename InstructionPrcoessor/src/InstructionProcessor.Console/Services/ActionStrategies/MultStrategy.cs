using InstructionProcessor.Console.Extensions;
using InstructionProcessor.Console.Models;
using InstructionProcessor.Console.Services.ActionStrategies.Interfaces;
using InstructionProcessor.Console.Services.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstructionProcessor.Console.Services.ActionStrategies
{
    public class MultStrategy : IActionStrategy
    {
        public string Name => "MULT";

        public int Evaluate(IEnumerable<int> inputs, IDictionary<int, Instruction> instructionDictionary, IActionStrategyFactory actionFactory)
        {
            var result = 1;
            inputs.ToList().ForEach(input =>
            {
                var instruction = instructionDictionary[input];
                var x = instruction.Evaluate(instructionDictionary, actionFactory);
                result = result * x;
            });

            return result;
        }
    }
}
