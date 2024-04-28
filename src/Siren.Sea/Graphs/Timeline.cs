namespace Siren.Sea;
using static Siren.Types;
using Util;

public static class timeline
{
    public static TimelineElement raw(string line)
         => Siren.timeline.raw(line);
    public static TimelineElement title(string name)
         => Siren.timeline.title(name);
    public static TimelineElement period(string name)
         => Siren.timeline.period(name);
    public static TimelineElement single(string timePeriod, Optional<string> @event = default)
         => Siren.timeline.single(timePeriod, @event.ToOption());
    public static TimelineElement multiple(string timePeriod, IEnumerable<string> events)
         => Siren.timeline.multiple(timePeriod, events);
    public static TimelineElement section(string name, IEnumerable<TimelineElement> children)
         => Siren.timeline.section(name, children);
    public static TimelineElement comment(string txt)
         => Siren.timeline.comment(txt);
}
