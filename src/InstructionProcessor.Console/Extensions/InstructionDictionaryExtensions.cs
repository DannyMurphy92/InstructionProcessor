using InstructionProcessor.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace InstructionProcessor.Console.Extensions
{
    public static class InstructionDictionaryExtensions
    {
        private const string DefaultPattern = @"^(\d+):\s+(\w+)\s+((\d+\s*)+)$";
        private const int DefaultLabelGroupIx = 1;
        private const int DefaultActionGroupIx = 2;
        private const int DefaultValueGroupIx = 3;

        public static void AddInstruction(
            this IDictionary<int, Instruction> dict,
            string input,
            string instructionPattern = DefaultPattern,
            int labelGrounpIx = DefaultLabelGroupIx,
            int actionGrounpIx = DefaultActionGroupIx,
            int valueGrounpIx = DefaultValueGroupIx
            )
        {
            var regex = new Regex(instructionPattern, RegexOptions.IgnoreCase);

            var match = regex.Match(input);

            if (!match.Success)
            {
                throw new ArgumentException($"\"{input}\" does not match the supplied pattern \"{instructionPattern}\"");
            }

            var label = int.Parse(match.Groups[labelGrounpIx].Value);
            var action = match.Groups[actionGrounpIx].Value.ToUpper();
            var values = match.Groups[valueGrounpIx].Value.Split(' ').Select(val => int.Parse(val));

            var instruction = new Instruction
            {
                Action = action,
                Values = values
            };

            dict.Add(label, instruction);
        }
    }
}
