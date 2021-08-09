using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstructionProcessor.Console.Models
{
    public class Instruction
    {
        public int? EvalutatedResult { get; set; } = null;
        public string Action { get; set; }
        public IEnumerable<int> Values { get; set; }
    }
}
