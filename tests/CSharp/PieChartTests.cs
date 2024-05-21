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

    public class DocsTests
    {
        [Fact]
        public void Product()
        {
            string actual = siren.pieChart([
                pieChart.data("Calcium", 42.96),
                pieChart.data("Potassium", 50.05),
                pieChart.data("Magnesium", 10.01),
                pieChart.data("Iron", 5)
            ], true, "Key elements in Product X")
                .addGraphConfigVariable(pieConfig.textPosition(0.5))
                .addThemeVariable(pieTheme.pieOuterStrokeWidth("5px"))
                .write();
            string expected = @"---
config:
    pie:
        textPosition: 0.5
    themeVariables:
        pieOuterStrokeWidth: 5px
---
pie showData title Key elements in Product X
    ""Calcium"" : 42.96
    ""Potassium"" : 50.05
    ""Magnesium"" : 10.01
    ""Iron"" : 5
";
            Assert.Equal(expected, actual);
        }
    }
    public class CompletenessTests
    {
        [Fact]
        public void PieChartTest()
        {
            Type csharpType = typeof(Siren.Sea.pieChart);
            Type fsharpType = typeof(Siren.pieChart);
            Utils.CompareClasses(csharpType, fsharpType);
        }
        [Fact]
        public void PieThemeTest()
        {
            Type csharpType = typeof(Siren.Sea.pieTheme);
            Type fsharpType = typeof(Siren.pieTheme);
            Utils.CompareClasses(csharpType, fsharpType);
        }
    }
}
