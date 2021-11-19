using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenethicAlgorithm.Models
{
    struct Gen
    {
        public Gen(int val)
        {
            value = val == 1 ? true : false;
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
        public Gen[] genArray { get; private set; }
        public int chromePower { get; private set; }
        public Chromosome(int size)
        {
            genArray = new Gen[size];
            GenerateChromosome();
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
            chromePower = power;
        }
        private void GenerateChromosome()
        {
            for(int i = 0; i < genArray.Length; i++)
            {
                int value = new Random().Next(0, 1);
                genArray[i] = new Gen(value);
            }
        }
    }
}
