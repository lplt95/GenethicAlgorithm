using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenethicAlgorithm.Models
{
    struct Gen
    {
        public Gen(bool val)
        {
            value = val;
        }
        public bool value { get; set; }
        public char ToChar()
        {
            return value ? '1' : '0';
        }
        public int GetValue()
        {
            return value ? 1 : 0;
        }
    }
    internal class Chromosome
    {
        private Gen[] genArray;
        public int ChromePower { get; private set; }
        public Chromosome(int size)
        {
            genArray = new Gen[size];
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach  (Gen gen in genArray)
            {
                sb.Append(gen.ToChar());
            }
            return sb.ToString();
        }
        public void CalculatePower()
        {
            int power = 0;
            foreach (Gen gen in genArray)
            {
                power =+ gen.GetValue();
            }
            ChromePower = power;
        }
    }
}
