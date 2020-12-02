namespace Lab3
{
    class MovInstrustion : IInstruction
    {
        public Register First { get; set; }
        public Register Second { get; set; }
        public string Instruction { get; set; }

        public bool Execute()
        {
            for (int i = 0; i < First.Count; ++i)
                First[i] = Second[i];
            return !First[0];
        }

        public MovInstrustion(Register first, Register second, string instruction)
        {
            First = first;
            Second = second;
            Instruction = instruction;
        }
    }
}
