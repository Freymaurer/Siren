namespace Siren.Sea.Tests;
using Xunit;
using Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


public class PieChartTests
{
    public class CompletenessTests
    {
        [Fact]
        public void PieChartTest()
        {
            Type csharpType = typeof(Siren.Sea.pieChart);
            Type fsharpType = typeof(Siren.pieChart);
            Utils.CompareClasses(csharpType, fsharpType);
        }
    }
}
