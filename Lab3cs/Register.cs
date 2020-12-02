using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Lab3
{
    public class Register
    {

        #region Public properties
        public string Name { get; set; }
        public int Count => bits.Length;
        public bool this[int index]
        {
            get => bits[index];
            set
            {
                bits[index] = value;
            }
        }

        #endregion

        #region Data container

        private bool[] bits { get; set; } = new bool[14];

        #endregion

        #region Static properties
        private static List<Register> Registers { get; set; } = new List<Register>();

        #endregion

        #region Object overrides

        public override string ToString()
        {
            var arr = bits.Select(bit => bit ? '1' : '0');
            var res = "";
            foreach (var bit in arr)
            {
                res += bit.ToString();
            }
            return res;
        }

        #endregion

        public static Register GetRegister(string name)
        {
            try
            {
                return Registers.Single(r => r.Name == name);
            }
            catch { return null; }
        }

        #region Constructor

        /// <summary>
        /// Initializes register with specified content and name.
        /// </summary>
        /// <param name="n">Content.</param>
        /// <param name="name">Name.</param>
        public Register(int n, string name)
        {
            Name = name;
            bits = To14BitsArray(n);
            if (Registers.FindIndex(c => c.Name == name) == -1)
                Registers.Add(this);
        }

        #endregion

        #region helper methods

        /// <summary>
        /// Converts a number to 14-bit.
        /// </summary>
        /// <param name="n">The number to convert.</param>
        /// <returns></returns>
        private static bool[] To14BitsArray(int n)
        {
            var str = (new String('0', 32) + Convert.ToString(n, 2));
            return str.Substring(str.Length - 14).Select(bit => bit == '1' ? true : false).ToArray();
        }

        #endregion
    }
}
