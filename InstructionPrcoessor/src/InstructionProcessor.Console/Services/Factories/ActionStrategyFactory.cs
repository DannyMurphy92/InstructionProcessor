using InstructionProcessor.Console.Services.Factories.Interfaces;
using InstructionProcessor.Console.Services.ActionStrategies.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstructionProcessor.Console.Services.Factories
{
    public class ActionStrategyFactory : IActionStrategyFactory
    {
        private readonly IEnumerable<IActionStrategy> _strategies;

        public ActionStrategyFactory(IEnumerable<IActionStrategy> strategies)
        {
            _strategies = strategies;
        }

        public IActionStrategy GetStrategy(string name)
        {
            var strategy = _strategies.FirstOrDefault(strat => strat.Name.ToUpper() == name.ToUpper());

            if (strategy == null)
            {
                throw new ArgumentException($"No strategy for \"{name}\" found");
            }

            return strategy;
        }
    }
}
