using System.Collections.ObjectModel;
using System.Linq;

namespace Lab3
{
    public class XorInstruction : IInstruction
    {
        private Register First { get; set; }
        private Register Second { get; set; }
        public string Instruction { get; set; }

        public XorInstruction(Register first, Register second, string instruction)
        {
            First = first;
            Second = second;
            Instruction = instruction;
        }

        public bool Execute()
        {
            for (int i = 0; i < First.Count; i++) First[i] = First[i] ^ Second[i];
            return !First[0];
        }
    }
}