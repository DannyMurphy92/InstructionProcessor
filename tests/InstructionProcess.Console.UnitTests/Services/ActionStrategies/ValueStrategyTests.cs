using InstructionProcessor.Console.Services.ActionStrategies;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstructionProcess.Console.UnitTests.Services.ActionStrategies
{
    [TestFixture]
    public class ValueStrategyTests
    {
        [Test]
        public void Name_IsSetCorrectly()
        {
            var sut = new ValueStrategy();
            Assert.AreEqual("VALUE", sut.Name);
        }

        [Test]
        public void Evaluate_GivenSingleInputValue_ReturnsValue()
        {
            var sut = new ValueStrategy();

            Assert.AreEqual(10, sut.Evaluate(new[] { 10 }, null, null));
        }

        [Test]
        public void Evaluate_GivenMultipleInputs_ThrowsException()
        {
            var sut = new ValueStrategy();

            var ex = Assert.Throws<ArgumentException>(() => sut.Evaluate(new[] { 10, 11 }, null, null));
            Assert.AreEqual("Value instruction must only be given a single value", ex.Message);
        }
    }
}
