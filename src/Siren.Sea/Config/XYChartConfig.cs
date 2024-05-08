namespace Siren.Sea;

using Siren.Sea.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class xyChartConfig
{
    public static (string, string) custom(string key, string value)
         => Siren.xyChartConfig.custom(key, value).ToValueTuple();
    public static (string, string) width(int value)
         => Siren.xyChartConfig.width(value).ToValueTuple();
    public static (string, string) height(int value)
         => Siren.xyChartConfig.height(value).ToValueTuple();
    public static (string, string) titlePadding(int value)
         => Siren.xyChartConfig.titlePadding(value).ToValueTuple();
    public static (string, string) titleFontSize(int value)
         => Siren.xyChartConfig.titleFontSize(value).ToValueTuple();
    public static (string, string) showTitle(int value)
         => Siren.xyChartConfig.showTitle(value).ToValueTuple();
    public static (string, string) xAxis(Optional<bool> showLabel = default, Optional<int> labelFontSize = default, Optional<int> labelPadding = default, Optional<bool> showTitle = default, Optional<int> titleFontSize = default, Optional<int> titlePadding = default, Optional<bool> showTick = default, Optional<int> tickLength = default, Optional<int> tickWidth = default, Optional<bool> showAxisLine = default, Optional<int> axisLineWidth = default)
         => Siren.xyChartConfig.xAxis(showLabel.ToOption(), labelFontSize.ToOption(), labelPadding.ToOption(), showTitle.ToOption(), titleFontSize.ToOption(), titlePadding.ToOption(), showTick.ToOption(), tickLength.ToOption(), tickWidth.ToOption(), showAxisLine.ToOption(), axisLineWidth.ToOption()).ToValueTuple();
    public static (string, string) yAxis(Optional<bool> showLabel = default, Optional<int> labelFontSize = default, Optional<int> labelPadding = default, Optional<bool> showTitle = default, Optional<int> titleFontSize = default, Optional<int> titlePadding = default, Optional<bool> showTick = default, Optional<int> tickLength = default, Optional<int> tickWidth = default, Optional<bool> showAxisLine = default, Optional<int> axisLineWidth = default)
         => Siren.xyChartConfig.yAxis(showLabel.ToOption(), labelFontSize.ToOption(), labelPadding.ToOption(), showTitle.ToOption(), titleFontSize.ToOption(), titlePadding.ToOption(), showTick.ToOption(), tickLength.ToOption(), tickWidth.ToOption(), showAxisLine.ToOption(), axisLineWidth.ToOption()).ToValueTuple();
    public static (string, string) chartOrientation(int value)
         => Siren.xyChartConfig.chartOrientation(value).ToValueTuple();
    public static (string, string) chartOrientationVertical
         => Siren.xyChartConfig.chartOrientationVertical.ToValueTuple();
    public static (string, string) chartOrientationHorizontal
         => Siren.xyChartConfig.chartOrientationHorizontal.ToValueTuple();
}