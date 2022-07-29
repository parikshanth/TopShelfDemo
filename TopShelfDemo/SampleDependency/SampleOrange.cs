using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfDemo.SampleDependency
{
    internal class SampleOrange : ISample
    {
        public string GetDependentColour()
        {
            return "orange";
        }
    }
}
