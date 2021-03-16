using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EinsteinDumper.Core.Model.Util
{
    public interface IDivisibleValidator
    {
        bool IsDivisible(int a, int b);
    }
}
