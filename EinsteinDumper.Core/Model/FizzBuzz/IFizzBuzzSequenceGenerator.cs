using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EinsteinDumper.Core.Model.FizzBuzz
{
    public interface IFizzBuzzSequenceGenerator
    {
        IEnumerable<string> Generate(int start, int max);
    }
}
