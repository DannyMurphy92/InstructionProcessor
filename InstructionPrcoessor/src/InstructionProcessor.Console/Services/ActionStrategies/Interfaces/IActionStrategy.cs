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

        int Evaluate(IEnumerable<int> inputs);
    }
}
