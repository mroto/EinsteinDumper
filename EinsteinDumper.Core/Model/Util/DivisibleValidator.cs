using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EinsteinDumper.Core.Model.Util
{
    public class DivisibleValidator : IDivisibleValidator
    {
        public bool IsDivisible(int a, int b)
        {
            return a % b == 0;
        }
    }
}
