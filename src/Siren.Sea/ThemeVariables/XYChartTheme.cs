namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class xyChartTheme
{
    public static ThemeVariable backgroundColor(string color)
         => Siren.xyChartTheme.backgroundColor(color);
    public static ThemeVariable titleColor(string color)
         => Siren.xyChartTheme.titleColor(color);
    public static ThemeVariable xAxisLabelColor(string color)
         => Siren.xyChartTheme.xAxisLabelColor(color);
    public static ThemeVariable xAxisTitleColor(string color)
         => Siren.xyChartTheme.xAxisTitleColor(color);
    public static ThemeVariable xAxisTickColor(string color)
         => Siren.xyChartTheme.xAxisTickColor(color);
    public static ThemeVariable xAxisLineColor(string color)
         => Siren.xyChartTheme.xAxisLineColor(color);
    public static ThemeVariable yAxisLabelColor(string color)
         => Siren.xyChartTheme.yAxisLabelColor(color);
    public static ThemeVariable yAxisTitleColor(string color)
         => Siren.xyChartTheme.yAxisTitleColor(color);
    public static ThemeVariable yAxisTickColor(string color)
         => Siren.xyChartTheme.yAxisTickColor(color);
    public static ThemeVariable yAxisLineColor(string color)
         => Siren.xyChartTheme.yAxisLineColor(color);
    public static ThemeVariable plotColorPalette(string[] colors)
         => Siren.xyChartTheme.plotColorPalette(colors);
}