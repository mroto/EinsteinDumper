using EinsteinDumper.Core.Model.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EinsteinDumper.Core.Model.FizzBuzz
{
    public interface IFizzBuzzValidator
    {
        NumberType GetNumberType(int number);
    }
}
