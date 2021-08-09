using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstructionProcessor.Console.Models
{
    public class Instruction
    {
        public string Action { get; set; }
        public IEnumerable<int> Values { get; set; }

    }
}
