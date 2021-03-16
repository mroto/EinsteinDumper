using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EinsteinDumper.Core.Model.FizzBuzz
{
    public interface IFizzBuzzConverter
    {
        public string Convert(int number);
    }
}
