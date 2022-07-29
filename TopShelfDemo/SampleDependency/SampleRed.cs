using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfDemo.SampleDependency
{
    internal class SampleRed : ISample
    {
        public string GetDependentColour()
        {
            return "red";
        }
    }
}
