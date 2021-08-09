using InstructionProcessor.Console.Extensions;
using InstructionProcessor.Console.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstructionProcess.Console.UnitTests.Extensions
{
    [TestFixture]
    public class InstructionDictionaryExtensionsTests
    {
        [Test]
        public void AddInstruction_GivenInstructionInDefaultFormat_AddsCorrectly()
        {
            var sut = new Dictionary<int, Instruction>();
            sut.AddInstruction("123: Add 100 200");

            var instruction = sut[123];
            Assert.AreEqual("ADD", instruction.Action);
            Assert.AreEqual(new[] { 100, 200 }, instruction.Values);
        }

        [Test]
        public void AddInstruction_GivenInstructionInDifferentFormatWithMatchingRegexAndIndexes_AddsCorrectly()
        {
            var sut = new Dictionary<int, Instruction>();
            sut.AddInstruction("Add 123: 100 200", @"^(\w+)\s+(\d+):\s+((\d+\s*)+)$", 2, 1, 3);

            var instruction = sut[123];
            Assert.AreEqual("ADD", instruction.Action);
            Assert.AreEqual(new[] { 100, 200 }, instruction.Values);
        }

        [Test]
        public void AddInstruction_InputThatDoesntMatchPattern_ThrowsException()
        {
            var sut = new Dictionary<int, Instruction>();
            var ex = Assert.Throws<ArgumentException>(() => sut.AddInstruction("not a valid input", "^\\d*$"));
            Assert.AreEqual("\"not a valid input\" does not match the supplied pattern \"^\\d*$\"", ex.Message);
        }
    }
}
