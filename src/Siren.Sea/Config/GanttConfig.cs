namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ganttConfig
{
    public static (string, string) custom(string key, string value)
         => Siren.ganttConfig.custom(key, value).ToValueTuple() ;
    public static (string, string) titleTopMargin(int px)
         => Siren.ganttConfig.titleTopMargin(px).ToValueTuple();
    public static (string, string) barHeight(int px)
         => Siren.ganttConfig.barHeight(px).ToValueTuple();
    public static (string, string) barGap(int px)
         => Siren.ganttConfig.barGap(px).ToValueTuple();
    public static (string, string) topPadding(int px)
         => Siren.ganttConfig.topPadding(px).ToValueTuple();
    public static (string, string) leftPadding(int px)
         => Siren.ganttConfig.leftPadding(px).ToValueTuple();
    public static (string, string) rightPadding(int px)
         => Siren.ganttConfig.rightPadding(px).ToValueTuple();
    public static (string, string) gridLineStartPadding(int px)
         => Siren.ganttConfig.gridLineStartPadding(px).ToValueTuple();
    public static (string, string) fontSize(int px)
         => Siren.ganttConfig.fontSize(px).ToValueTuple();
    public static (string, string) sectionFontSize(int px)
         => Siren.ganttConfig.sectionFontSize(px).ToValueTuple();
    public static (string, string) numberSectionStyles(int n)
         => Siren.ganttConfig.numberSectionStyles(n).ToValueTuple();
    public static (string, string) axisFormat(string format)
         => Siren.ganttConfig.axisFormat(format).ToValueTuple();
    public static (string, string) tickInterval(string format)
         => Siren.ganttConfig.tickInterval(format).ToValueTuple();
    public static (string, string) tickIntervalMillisecond(int ms)
         => Siren.ganttConfig.tickIntervalMillisecond(ms).ToValueTuple();
    public static (string, string) tickIntervalSecond(int s)
         => Siren.ganttConfig.tickIntervalSecond(s).ToValueTuple();
    public static (string, string) tickIntervalMinute(int min)
         => Siren.ganttConfig.tickIntervalMinute(min).ToValueTuple();
    public static (string, string) tickIntervalHour(int hour)
         => Siren.ganttConfig.tickIntervalHour(hour).ToValueTuple();
    public static (string, string) tickIntervalDay(int day)
         => Siren.ganttConfig.tickIntervalDay(day).ToValueTuple();
    public static (string, string) tickIntervalWeek(int week)
         => Siren.ganttConfig.tickIntervalWeek(week).ToValueTuple();
    public static (string, string) tickIntervalMonth(int month)
         => Siren.ganttConfig.tickIntervalMonth(month).ToValueTuple();
    public static (string, string) topAxis(bool b)
         => Siren.ganttConfig.topAxis(b).ToValueTuple();
    public static (string, string) displayMode(string mode)
         => Siren.ganttConfig.displayMode(mode).ToValueTuple();
    public static (string, string) displayModeDefault
         => Siren.ganttConfig.displayModeDefault.ToValueTuple();
    public static (string, string) displayModeCompact
         => Siren.ganttConfig.displayModeCompact.ToValueTuple();
    public static (string, string) weekday(string day)
         => Siren.ganttConfig.weekday(day).ToValueTuple();
    public static (string, string) weekdayMonday
         => Siren.ganttConfig.weekdayMonday.ToValueTuple();
    public static (string, string) weekdayTuesday
         => Siren.ganttConfig.weekdayTuesday.ToValueTuple();
    public static (string, string) weekdayWednesday
         => Siren.ganttConfig.weekdayWednesday.ToValueTuple();
    public static (string, string) weekdayThursday
         => Siren.ganttConfig.weekdayThursday.ToValueTuple();
    public static (string, string) weekdayFriday
         => Siren.ganttConfig.weekdayFriday.ToValueTuple();
    public static (string, string) weekdaySaturday
         => Siren.ganttConfig.weekdaySaturday.ToValueTuple();
    public static (string, string) weekdaySunday
         => Siren.ganttConfig.weekdaySunday.ToValueTuple();
}