using InstructionProcessor.Console.Models;
using InstructionProcessor.Console.Services.ActionStrategies;
using InstructionProcessor.Console.Services.ActionStrategies.Interfaces;
using InstructionProcessor.Console.Services.Factories;
using InstructionProcessor.Console.Services.Factories.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstructionProcess.Console.UnitTests.Services.ActionStrategies
{
    [TestFixture]
    public class MultStrategyTests
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
        public void Name_IsSetCorrectly()
        {
            var sut = new MultStrategy();
            Assert.AreEqual("MULT", sut.Name);
        }

        [Test]
        public void Evaluate_CorrectlySumsUpEvaluateInstructionsAtLabelIds()
        {
            var strat1 = Substitute.For<IActionStrategy>();
            strat1.Name.Returns("strat1");
            strat1.Evaluate(default, default, default).ReturnsForAnyArgs(10);
            var strat2 = Substitute.For<IActionStrategy>();
            strat2.Name.Returns("strat2");
            strat2.Evaluate(default, default, default).ReturnsForAnyArgs(-2);
            var strat3 = Substitute.For<IActionStrategy>();
            strat3.Name.Returns("strat3");
            strat3.Evaluate(default, default, default).ReturnsForAnyArgs(3);

            actionFactory = new ActionStrategyFactory(new List<IActionStrategy> { strat1, strat2, strat3 });
            instructionDictionary = new Dictionary<int, Instruction>
            {
                {1, new Instruction{ Action = "strat1", Values = new []{ 1 } } },
                {2, new Instruction{ Action = "strat2", Values = new []{ 2 } } },
                {3, new Instruction{ Action = "strat3", Values = new []{ 3 } } },
            };

            var sut = new MultStrategy();
            var result = sut.Evaluate(new int[] { 1, 2, 3, 1 }, instructionDictionary, actionFactory);

            Assert.AreEqual(-600, result);
        }
    }
}
