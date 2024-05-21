namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ganttConfig
{
    public static ConfigVariable custom(string key, string value)
         => Siren.ganttConfig.custom(key, value) ;
    public static ConfigVariable titleTopMargin(int px)
         => Siren.ganttConfig.titleTopMargin(px);
    public static ConfigVariable barHeight(int px)
         => Siren.ganttConfig.barHeight(px);
    public static ConfigVariable barGap(int px)
         => Siren.ganttConfig.barGap(px);
    public static ConfigVariable topPadding(int px)
         => Siren.ganttConfig.topPadding(px);
    public static ConfigVariable leftPadding(int px)
         => Siren.ganttConfig.leftPadding(px);
    public static ConfigVariable rightPadding(int px)
         => Siren.ganttConfig.rightPadding(px);
    public static ConfigVariable gridLineStartPadding(int px)
         => Siren.ganttConfig.gridLineStartPadding(px);
    public static ConfigVariable fontSize(int px)
         => Siren.ganttConfig.fontSize(px);
    public static ConfigVariable sectionFontSize(int px)
         => Siren.ganttConfig.sectionFontSize(px);
    public static ConfigVariable numberSectionStyles(int n)
         => Siren.ganttConfig.numberSectionStyles(n);
    public static ConfigVariable axisFormat(string format)
         => Siren.ganttConfig.axisFormat(format);
    public static ConfigVariable tickInterval(string format)
         => Siren.ganttConfig.tickInterval(format);
    public static ConfigVariable tickIntervalMillisecond(int ms)
         => Siren.ganttConfig.tickIntervalMillisecond(ms);
    public static ConfigVariable tickIntervalSecond(int s)
         => Siren.ganttConfig.tickIntervalSecond(s);
    public static ConfigVariable tickIntervalMinute(int min)
         => Siren.ganttConfig.tickIntervalMinute(min);
    public static ConfigVariable tickIntervalHour(int hour)
         => Siren.ganttConfig.tickIntervalHour(hour);
    public static ConfigVariable tickIntervalDay(int day)
         => Siren.ganttConfig.tickIntervalDay(day);
    public static ConfigVariable tickIntervalWeek(int week)
         => Siren.ganttConfig.tickIntervalWeek(week);
    public static ConfigVariable tickIntervalMonth(int month)
         => Siren.ganttConfig.tickIntervalMonth(month);
    public static ConfigVariable topAxis(bool b)
         => Siren.ganttConfig.topAxis(b);
    public static ConfigVariable displayMode(string mode)
         => Siren.ganttConfig.displayMode(mode);
    public static ConfigVariable displayModeDefault
         => Siren.ganttConfig.displayModeDefault;
    public static ConfigVariable displayModeCompact
         => Siren.ganttConfig.displayModeCompact;
    public static ConfigVariable weekday(string day)
         => Siren.ganttConfig.weekday(day);
    public static ConfigVariable weekdayMonday
         => Siren.ganttConfig.weekdayMonday;
    public static ConfigVariable weekdayTuesday
         => Siren.ganttConfig.weekdayTuesday;
    public static ConfigVariable weekdayWednesday
         => Siren.ganttConfig.weekdayWednesday;
    public static ConfigVariable weekdayThursday
         => Siren.ganttConfig.weekdayThursday;
    public static ConfigVariable weekdayFriday
         => Siren.ganttConfig.weekdayFriday;
    public static ConfigVariable weekdaySaturday
         => Siren.ganttConfig.weekdaySaturday;
    public static ConfigVariable weekdaySunday
         => Siren.ganttConfig.weekdaySunday;
}