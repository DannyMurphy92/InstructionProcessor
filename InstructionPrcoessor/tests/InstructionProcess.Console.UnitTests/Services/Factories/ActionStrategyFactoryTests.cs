using InstructionProcessor.Console.Services.ActionStrategies.Interfaces;
using InstructionProcessor.Console.Services.Factories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstructionProcess.Console.UnitTests.Services.Factories
{
    [TestFixture]
    public class ActionStrategyFactoryTests
    {
        [Test]
        public void Get_WhenNoStrategies_ThrowException()
        {
            var sut = new ActionStrategyFactory(new List<IActionStrategy>());

            var ex = Assert.Throws<ArgumentException>(() => sut.GetStrategy("not-a-strategy"));
            Assert.AreEqual("No strategy for \"not-a-strategy\" found", ex.Message);
        }

        [Test]
        public void Get_MatchesCorrectStrategyByName()
        {
            var dummyStrat = new MyDummyStrategy();
            var sut = new ActionStrategyFactory(new List<IActionStrategy> { dummyStrat });

            var returnedStrat = sut.GetStrategy("test-strategy");

            Assert.AreEqual(dummyStrat, returnedStrat);
        }
    }

    internal class MyDummyStrategy : IActionStrategy
    {
        public string Name => "Test-Strategy";

        public int Evaluate(IEnumerable<int> inputs)
        {
            throw new NotImplementedException();
        }
    }
}
