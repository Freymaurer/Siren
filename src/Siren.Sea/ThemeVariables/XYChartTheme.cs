namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class xyChartTheme
{
    public static (string, string) backgroundColor(string color)
         => Siren.xyChartTheme.backgroundColor(color).ToValueTuple();
    public static (string, string) titleColor(string color)
         => Siren.xyChartTheme.titleColor(color).ToValueTuple();
    public static (string, string) xAxisLabelColor(string color)
         => Siren.xyChartTheme.xAxisLabelColor(color).ToValueTuple();
    public static (string, string) xAxisTitleColor(string color)
         => Siren.xyChartTheme.xAxisTitleColor(color).ToValueTuple();
    public static (string, string) xAxisTickColor(string color)
         => Siren.xyChartTheme.xAxisTickColor(color).ToValueTuple();
    public static (string, string) xAxisLineColor(string color)
         => Siren.xyChartTheme.xAxisLineColor(color).ToValueTuple();
    public static (string, string) yAxisLabelColor(string color)
         => Siren.xyChartTheme.yAxisLabelColor(color).ToValueTuple();
    public static (string, string) yAxisTitleColor(string color)
         => Siren.xyChartTheme.yAxisTitleColor(color).ToValueTuple();
    public static (string, string) yAxisTickColor(string color)
         => Siren.xyChartTheme.yAxisTickColor(color).ToValueTuple();
    public static (string, string) yAxisLineColor(string color)
         => Siren.xyChartTheme.yAxisLineColor(color).ToValueTuple();
    public static (string, string) plotColorPalette(string[] colors)
         => Siren.xyChartTheme.plotColorPalette(colors).ToValueTuple();
}