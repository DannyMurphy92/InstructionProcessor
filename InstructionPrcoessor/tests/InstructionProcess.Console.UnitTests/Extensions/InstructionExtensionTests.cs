using InstructionProcessor.Console.Extensions;
using InstructionProcessor.Console.Models;
using InstructionProcessor.Console.Services.ActionStrategies.Interfaces;
using InstructionProcessor.Console.Services.Factories.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstructionProcess.Console.UnitTests.Extensions
{
    [TestFixture]
    public class InstructionExtensionTests
    {
        private IActionStrategyFactory actionFactory;

        [SetUp]
        public void SetUp()
        {
            actionFactory = Substitute.For<IActionStrategyFactory>();
        }

        [Test]
        public void Evaluate_GetStrategyFromFactory()
        {
            var sut = new Instruction
            {
                Action = "test-action"
            };

            sut.Evaluate(actionFactory);

            actionFactory.Received(1).GetStrategy("test-action");
        }

        [Test]
        public void Evaluate_ReturnsResultFromActionStrategy()
        {
            var strategy = Substitute.For<IActionStrategy>();
            strategy.Evaluate(default).ReturnsForAnyArgs(10);
            var sut = new Instruction
            {
                Action = "test-action",
                Values = new[] {10, 12}
            };

            actionFactory.GetStrategy(default).ReturnsForAnyArgs(strategy);
            var result = sut.Evaluate(actionFactory);

            strategy.Received(1).Evaluate(sut.Values);
            Assert.AreEqual(10, result);
        }
    }
}
