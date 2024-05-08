namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class quadrantChartConfig
{
    public static (string, string) custom(string key, string value)
         => Siren.quadrantChartConfig.custom(key, value).ToValueTuple();
    public static (string, string) chartWidth(int value)
         => Siren.quadrantChartConfig.chartWidth(value).ToValueTuple();
    public static (string, string) chartHeight(int value)
         => Siren.quadrantChartConfig.chartHeight(value).ToValueTuple();
    public static (string, string) titleFontSize(int value)
         => Siren.quadrantChartConfig.titleFontSize(value).ToValueTuple();
    public static (string, string) titlePadding(int value)
         => Siren.quadrantChartConfig.titlePadding(value).ToValueTuple();
    public static (string, string) quadrantPadding(int value)
         => Siren.quadrantChartConfig.quadrantPadding(value).ToValueTuple();
    public static (string, string) xAxisLabelPadding(int value)
         => Siren.quadrantChartConfig.xAxisLabelPadding(value).ToValueTuple();
    public static (string, string) yAxisLabelPadding(int value)
         => Siren.quadrantChartConfig.yAxisLabelPadding(value).ToValueTuple();
    public static (string, string) xAxisLabelFontSize(int value)
         => Siren.quadrantChartConfig.xAxisLabelFontSize(value).ToValueTuple();
    public static (string, string) yAxisLabelFontSize(int value)
         => Siren.quadrantChartConfig.yAxisLabelFontSize(value).ToValueTuple();
    public static (string, string) quadrantLabelFontSize(int value)
         => Siren.quadrantChartConfig.quadrantLabelFontSize(value).ToValueTuple();
    public static (string, string) quadrantTextTopPadding(int value)
         => Siren.quadrantChartConfig.quadrantTextTopPadding(value).ToValueTuple();
    public static (string, string) pointTextPadding(int value)
         => Siren.quadrantChartConfig.pointTextPadding(value).ToValueTuple();
    public static (string, string) pointLabelFontSize(int value)
         => Siren.quadrantChartConfig.pointLabelFontSize(value).ToValueTuple();
    public static (string, string) pointRadius(int value)
         => Siren.quadrantChartConfig.pointRadius(value).ToValueTuple();
    public static (string, string) yAxisPosition(string value)
         => Siren.quadrantChartConfig.yAxisPosition(value).ToValueTuple();
    public static (string, string) yAxisPositionLeft
         => Siren.quadrantChartConfig.yAxisPositionLeft.ToValueTuple();
    public static (string, string) yAxisPositionRight
         => Siren.quadrantChartConfig.yAxisPositionRight.ToValueTuple();
    public static (string, string) quadrantInternalBorderStrokeWidth(int value)
         => Siren.quadrantChartConfig.quadrantInternalBorderStrokeWidth(value).ToValueTuple();
    public static (string, string) quadrantExternalBorderStrokeWidth(int value)
         => Siren.quadrantChartConfig.quadrantExternalBorderStrokeWidth(value).ToValueTuple();
}