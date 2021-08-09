using InstructionProcessor.Console.Models;
using InstructionProcessor.Console.Services.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstructionProcessor.Console.Services.ActionStrategies.Interfaces
{
    public interface IActionStrategy
    {
        string Name { get; }

        int Evaluate(IEnumerable<int> inputs, IDictionary<int, Instruction> instructionDictionary, IActionStrategyFactory actionFactory);
    }
}
