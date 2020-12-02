﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab3
{
    public class ProcessorViewModel
    {
        #region Properties

        #region Registers

        public Register R1 { get; set; } = new Register(0, nameof(R1));

        public Register R2 { get; set; } = new Register(0, nameof(R2));

        public Register R3 { get; set; } = new Register(0, nameof(R3));

        public Register R4 { get; set; } = new Register(0, nameof(R4));

        public bool PS { get; set; } = false;

        public int PC { get; set; } = 0;

        public int TC { get; set; } = 0;

        public string IR { get; set; } = "";

        #endregion

        public Queue<IInstruction> instructions { get; set; } = new Queue<IInstruction>();

        public string Path { get; set; } = @"./exampleCommands.txt";

        #endregion

        #region Commands
        public void executeTact()
        {
            if (TC == 2)
                TC = 0;
            TC++;
            if (TC == 1)
            {
                PC++;
                IR = instructions.Peek().Instruction;
            }
            else if (TC == 2)
            {
                PS = instructions.Dequeue().Execute();
            }
        }
        public bool canExecute()
        {
            return instructions.Count != 0;
        }

        #endregion

        #region Constructor

        public ProcessorViewModel()
        {
            ParseFile(Path);
        }
        #endregion

        public static string ReplaceWhitespaces(string str)
        {
            var options = RegexOptions.None;
            var regex = new Regex("[ ]{2,}", options);
            return regex.Replace(str, " ");
        }
        private void ParseFile(string path)
        {
            string text = File.ReadAllText(path).Replace("\r", "");
            List<string> commands = text.Split('\n')
                                        .Where(line => line.Any(c => !char.IsWhiteSpace(c)))
                                        .Select(str => ReplaceWhitespaces(str))
                                        .ToList();
            for (int i = 0; i < commands.Count; ++i)
            {
                var command = commands[i].Split(' ');
                IInstruction current = null;
                switch (command[0])
                {
                    case "mov":
                        {
                            var first = Register.GetRegister(command[1]) ?? new Register(Convert.ToInt32(command[1]), "");
                            var second = Register.GetRegister(command[2]) ?? new Register(Convert.ToInt32(command[2]), "");
                            current = new MovInstrustion(first, second, commands[i]);
                        }
                        break;
                    case "xor":
                        {
                            var first = Register.GetRegister(command[1]) ?? new Register(Convert.ToInt32(command[1]), "");
                            var second = Register.GetRegister(command[2]) ?? new Register(Convert.ToInt32(command[2]), "");
                            current = new XorInstruction(first, second, commands[i]);
                        }
                        break;
                }
                if (current != null)
                    instructions.Enqueue(current);
            }

            return;
        }



    }
}
