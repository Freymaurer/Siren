namespace Siren.Sea;

using Siren.Sea.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class xyChartConfig
{
    public static ConfigVariable custom(string key, string value)
         => Siren.xyChartConfig.custom(key, value);
    public static ConfigVariable width(int value)
         => Siren.xyChartConfig.width(value);
    public static ConfigVariable height(int value)
         => Siren.xyChartConfig.height(value);
    public static ConfigVariable titlePadding(int value)
         => Siren.xyChartConfig.titlePadding(value);
    public static ConfigVariable titleFontSize(int value)
         => Siren.xyChartConfig.titleFontSize(value);
    public static ConfigVariable showTitle(int value)
         => Siren.xyChartConfig.showTitle(value);
    public static ConfigVariable xAxis(Optional<bool> showLabel = default, Optional<int> labelFontSize = default, Optional<int> labelPadding = default, Optional<bool> showTitle = default, Optional<int> titleFontSize = default, Optional<int> titlePadding = default, Optional<bool> showTick = default, Optional<int> tickLength = default, Optional<int> tickWidth = default, Optional<bool> showAxisLine = default, Optional<int> axisLineWidth = default)
         => Siren.xyChartConfig.xAxis(showLabel.ToOption(), labelFontSize.ToOption(), labelPadding.ToOption(), showTitle.ToOption(), titleFontSize.ToOption(), titlePadding.ToOption(), showTick.ToOption(), tickLength.ToOption(), tickWidth.ToOption(), showAxisLine.ToOption(), axisLineWidth.ToOption());
    public static ConfigVariable yAxis(Optional<bool> showLabel = default, Optional<int> labelFontSize = default, Optional<int> labelPadding = default, Optional<bool> showTitle = default, Optional<int> titleFontSize = default, Optional<int> titlePadding = default, Optional<bool> showTick = default, Optional<int> tickLength = default, Optional<int> tickWidth = default, Optional<bool> showAxisLine = default, Optional<int> axisLineWidth = default)
         => Siren.xyChartConfig.yAxis(showLabel.ToOption(), labelFontSize.ToOption(), labelPadding.ToOption(), showTitle.ToOption(), titleFontSize.ToOption(), titlePadding.ToOption(), showTick.ToOption(), tickLength.ToOption(), tickWidth.ToOption(), showAxisLine.ToOption(), axisLineWidth.ToOption());
    public static ConfigVariable chartOrientation(int value)
         => Siren.xyChartConfig.chartOrientation(value);
    public static ConfigVariable chartOrientationVertical
         => Siren.xyChartConfig.chartOrientationVertical;
    public static ConfigVariable chartOrientationHorizontal
         => Siren.xyChartConfig.chartOrientationHorizontal;
}