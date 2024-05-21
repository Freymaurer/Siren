namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class quadrantChartConfig
{
    public static ConfigVariable custom(string key, string value)
         => Siren.quadrantChartConfig.custom(key, value);
    public static ConfigVariable chartWidth(int value)
         => Siren.quadrantChartConfig.chartWidth(value);
    public static ConfigVariable chartHeight(int value)
         => Siren.quadrantChartConfig.chartHeight(value);
    public static ConfigVariable titleFontSize(int value)
         => Siren.quadrantChartConfig.titleFontSize(value);
    public static ConfigVariable titlePadding(int value)
         => Siren.quadrantChartConfig.titlePadding(value);
    public static ConfigVariable quadrantPadding(int value)
         => Siren.quadrantChartConfig.quadrantPadding(value);
    public static ConfigVariable xAxisLabelPadding(int value)
         => Siren.quadrantChartConfig.xAxisLabelPadding(value);
    public static ConfigVariable yAxisLabelPadding(int value)
         => Siren.quadrantChartConfig.yAxisLabelPadding(value);
    public static ConfigVariable xAxisLabelFontSize(int value)
         => Siren.quadrantChartConfig.xAxisLabelFontSize(value);
    public static ConfigVariable yAxisLabelFontSize(int value)
         => Siren.quadrantChartConfig.yAxisLabelFontSize(value);
    public static ConfigVariable quadrantLabelFontSize(int value)
         => Siren.quadrantChartConfig.quadrantLabelFontSize(value);
    public static ConfigVariable quadrantTextTopPadding(int value)
         => Siren.quadrantChartConfig.quadrantTextTopPadding(value);
    public static ConfigVariable pointTextPadding(int value)
         => Siren.quadrantChartConfig.pointTextPadding(value);
    public static ConfigVariable pointLabelFontSize(int value)
         => Siren.quadrantChartConfig.pointLabelFontSize(value);
    public static ConfigVariable pointRadius(int value)
         => Siren.quadrantChartConfig.pointRadius(value);
    public static ConfigVariable yAxisPosition(string value)
         => Siren.quadrantChartConfig.yAxisPosition(value);
    public static ConfigVariable yAxisPositionLeft
         => Siren.quadrantChartConfig.yAxisPositionLeft;
    public static ConfigVariable yAxisPositionRight
         => Siren.quadrantChartConfig.yAxisPositionRight;
    public static ConfigVariable quadrantInternalBorderStrokeWidth(int value)
         => Siren.quadrantChartConfig.quadrantInternalBorderStrokeWidth(value);
    public static ConfigVariable quadrantExternalBorderStrokeWidth(int value)
         => Siren.quadrantChartConfig.quadrantExternalBorderStrokeWidth(value);
}