using InstructionProcessor.Console.Models;
using InstructionProcessor.Console.Services.ActionStrategies.Interfaces;
using InstructionProcessor.Console.Services.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InstructionProcessor.Console.Services.ActionStrategies
{
    public class ValueStrategy : IActionStrategy
    {
        public string Name => "VALUE";

        public int Evaluate(IEnumerable<int> inputs, IDictionary<int, Instruction> instructionDictionary, IActionStrategyFactory actionFactory)
        {
            if (inputs.Count() != 1)
            {
                throw new ArgumentException("Value instruction must only be given a single value");
            }

            return inputs.First();
        }
    }
}
