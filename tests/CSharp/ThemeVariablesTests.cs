namespace Siren.Sea.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ThemeVariablesTests
{
    [Fact]
    public void QuadrantThemeTest()
    {
        Type csharpType = typeof(Siren.Sea.quadrantTheme);
        Type fsharpType = typeof(Siren.quadrantTheme);
        Utils.CompareClasses(csharpType, fsharpType);
    }
    [Fact]
    public void GitThemeTest()
    {
        Type csharpType = typeof(Siren.Sea.gitTheme);
        Type fsharpType = typeof(Siren.gitTheme);
        Utils.CompareClasses(csharpType, fsharpType);
    }
    [Fact]
    public void TimelineThemeTest()
    {
        Type csharpType = typeof(Siren.Sea.timelineTheme);
        Type fsharpType = typeof(Siren.timelineTheme);
        Utils.CompareClasses(csharpType, fsharpType);
    }
    [Fact]
    public void XYChartThemeTest()
    {
        Type csharpType = typeof(Siren.Sea.xyChartTheme);
        Type fsharpType = typeof(Siren.xyChartTheme);
        Utils.CompareClasses(csharpType, fsharpType);
    }
}
