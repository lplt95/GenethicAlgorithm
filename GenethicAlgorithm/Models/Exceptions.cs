using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenethicAlgorithm.Models
{
    public class UnsupportedFormatException : Exception
    {
        public override string Message => "Unsupported field format. Contact with support.";
    }
}
