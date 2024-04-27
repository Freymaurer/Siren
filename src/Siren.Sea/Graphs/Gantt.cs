namespace Siren.Sea;

using static Siren.Formatting.Gantt;
using static Siren.Types;
public class ganttTime
{
    public static String length(string timespan)
         => Siren.ganttTime.length(timespan);
    public static String dateTime(string datetime)
         => Siren.ganttTime.dateTime(datetime);
    public static String after(string id)
         => Siren.ganttTime.after(id);
    public static String until(string id)
         => Siren.ganttTime.until(id);
}

public class ganttTags
{
    public static GanttTags active
         => Siren.ganttTags.active;
    public static GanttTags done
         => Siren.ganttTags.done;
    public static GanttTags crit
         => Siren.ganttTags.crit;
    public static GanttTags milestone
         => Siren.ganttTags.milestone;
}

public class ganttUnit
{
    public static GanttUnit millisecond
         => Siren.ganttUnit.millisecond;
    public static GanttUnit second
         => Siren.ganttUnit.second;
    public static GanttUnit minute
         => Siren.ganttUnit.minute;
    public static GanttUnit hour
         => Siren.ganttUnit.hour;
    public static GanttUnit day
         => Siren.ganttUnit.day;
    public static GanttUnit week
         => Siren.ganttUnit.week;
    public static GanttUnit month
         => Siren.ganttUnit.month;
}

public class gantt
{
    public static GanttElement raw(string line)
         => Siren.gantt.raw(line);
    public static GanttElement title(string name)
         => Siren.gantt.title(name);
    public static GanttElement section(string name)
         => Siren.gantt.section(name);
    public static GanttElement task(string title, string id, string startDate, string endDate, Optional<IEnumerable<GanttTags>> tags = default)
         => Siren.gantt.task(title, id, startDate, endDate, tags.ToOption());
    public static GanttElement taskStartEnd(string title, string startDate, string endDate, Optional<IEnumerable<GanttTags>> tags = default)
         => Siren.gantt.taskStartEnd(title, startDate, endDate, tags.ToOption());
    public static GanttElement taskEnd(string title, string endDate, Optional<IEnumerable<GanttTags>> tags = default)
         => Siren.gantt.taskEnd(title, endDate, tags.ToOption());
    public static GanttElement milestone(string title, string id, string startDate, string endDate, Optional<IEnumerable<GanttTags>> tags = default)
         => Siren.gantt.milestone(title, id, startDate, endDate, tags.ToOption());
    public static GanttElement milestoneStartEnd(string title, string startDate, string endDate, Optional<IEnumerable<GanttTags>> tags = default)
         => Siren.gantt.milestoneStartEnd(title, startDate, endDate, tags.ToOption());
    public static GanttElement milestoneEnd(string title, string endDate, Optional<IEnumerable<GanttTags>> tags = default)
         => Siren.gantt.milestoneEnd(title, endDate, tags.ToOption());
    public static GanttElement dateFormat(string formatString)
         => Siren.gantt.dateFormat(formatString);
    public static GanttElement axisFormat(string formatString)
         => Siren.gantt.axisFormat(formatString);
    public static GanttElement tickInterval(int interval, GanttUnit unit)
         => Siren.gantt.tickInterval(interval, unit);
    public static GanttElement weekday(string day)
         => Siren.gantt.weekday(day);
    public static GanttElement excludes(string day)
         => Siren.gantt.excludes(day);
    public static GanttElement comment(string txt)
         => Siren.gantt.comment(txt);
}
