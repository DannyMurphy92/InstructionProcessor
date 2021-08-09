using InstructionProcessor.Console.Services.ActionStrategies.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstructionProcessor.Console.Services.Factories.Interfaces
{
    public interface IActionStrategyFactory
    {
        IActionStrategy GetStrategy(string name);
    }
}
