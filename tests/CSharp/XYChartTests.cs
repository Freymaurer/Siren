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
    public class DocsTests
    {
        [Fact]
        public void SalesRevenue()
        {
            string actual =
                siren.xyChart([
                    xyChart.title("Sales Revenue"),
                    xyChart.xAxis(["jan", "feb", "mar", "apr", "may", "jun", "jul", "aug", "sep", "oct", "nov", "dec"]),
                    xyChart.yAxisNamedRange("Revenue (in $)", 4000, 11000),
                    xyChart.bar([5000, 6000, 7500, 8200, 9500, 10500, 11000, 10200, 9200, 8500, 7000, 6000]),
                    xyChart.line([5000, 6000, 7500, 8200, 9500, 10500, 11000, 10200, 9200, 8500, 7000, 6000])
                ]).write();
            string expected = @"xychart-beta
    title ""Sales Revenue""
    x-axis [jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec]
    y-axis ""Revenue (in $)"" 4000.000000 --> 11000.000000
    bar [5000, 6000, 7500, 8200, 9500, 10500, 11000, 10200, 9200, 8500, 7000, 6000]
    line [5000, 6000, 7500, 8200, 9500, 10500, 11000, 10200, 9200, 8500, 7000, 6000]
";
            Assert.Equal(expected, actual);
        }
    }
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
