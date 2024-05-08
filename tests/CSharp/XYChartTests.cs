namespace Siren.Sea.Tests;
using Xunit;
using Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


public class XYChartTests
{
    public class CompletenessTests
    {
        [Fact]
        public void XYChartTest()
        {
            Type csharpType = typeof(Siren.Sea.xyChart);
            Type fsharpType = typeof(Siren.xyChart);
            Utils.CompareClasses(csharpType, fsharpType);
        }
    }
}
