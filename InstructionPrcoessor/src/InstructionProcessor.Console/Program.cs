using InstructionProcessor.Console.Extensions;
using InstructionProcessor.Console.Models;
using InstructionProcessor.Console.Services.ActionStrategies;
using InstructionProcessor.Console.Services.ActionStrategies.Interfaces;
using InstructionProcessor.Console.Services.Factories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InstructionProcessor.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();

            sw.Start();
            var actionFactory = new ActionStrategyFactory(new List<IActionStrategy>
            {
                new ValueStrategy(),
                new AddStrategy(),
                new MultStrategy(),
            });

            var instructionDictionary = new Dictionary<int, Instruction>();

            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            using (var reader = new StreamReader($"{assemblyPath}\\Data\\input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    instructionDictionary.AddInstruction(line);
                }
            }

            var result = instructionDictionary.First().Value.Evaluate(instructionDictionary, actionFactory);
            sw.Stop();
            System.Console.WriteLine($"Result of instructions: {result}. Calculated in {sw.ElapsedMilliseconds}ms");
            System.Console.WriteLine("Press any key to exit");
            System.Console.ReadKey();
        }
    }
}
