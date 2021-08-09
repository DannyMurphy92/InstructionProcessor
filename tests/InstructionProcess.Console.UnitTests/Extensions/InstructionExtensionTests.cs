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
        private IDictionary<int, Instruction> instructionDictionary;

        [SetUp]
        public void SetUp()
        {
            actionFactory = Substitute.For<IActionStrategyFactory>();
            instructionDictionary = new Dictionary<int, Instruction>();
        }

        [Test]
        public void Evaluate_GetStrategyFromFactory()
        {
            var sut = new Instruction
            {
                Action = "test-action",
                Values = new int[] { },
            };

            sut.Evaluate(instructionDictionary, actionFactory);

            actionFactory.Received(1).GetStrategy("test-action");
        }

        [Test]
        public void Evaluate_ReturnsResultFromActionStrategy_AndCachesResult()
        {
            var strategy = Substitute.For<IActionStrategy>();
            strategy.Evaluate(default, default, default).ReturnsForAnyArgs(10);
            var sut = new Instruction
            {
                Action = "test-action",
                Values = new[] {10, 12}
            };

            actionFactory.GetStrategy(default).ReturnsForAnyArgs(strategy);
            var result = sut.Evaluate(instructionDictionary, actionFactory);

            strategy.Received(1).Evaluate(sut.Values, instructionDictionary, actionFactory);
            Assert.AreEqual(10, result);
            Assert.AreEqual(10, sut.EvalutatedResult);
        }

        [Test]
        public void Evaluate_HasCachedResult_ReturnCachedResultDoesNotPerformOtherActions()
        {
            var sut = new Instruction
            {
                Action = "test-action",
                EvalutatedResult = 5,
            };

            var result = sut.Evaluate(instructionDictionary, actionFactory);

            actionFactory.DidNotReceiveWithAnyArgs().GetStrategy(default);

            Assert.AreEqual(5, result);
        }
    }
}
