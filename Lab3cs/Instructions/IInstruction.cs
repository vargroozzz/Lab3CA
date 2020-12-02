using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public interface IInstruction
    {
        string Instruction { get; set; }
        bool Execute();
    }
}
