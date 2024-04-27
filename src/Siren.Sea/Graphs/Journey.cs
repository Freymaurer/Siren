namespace Siren.Sea;

using static Siren.Types;

public class journey
{
    public static JourneyElement raw(string line)
         => Siren.journey.raw(line);
    public static JourneyElement title(string name)
         => Siren.journey.title(name);
    public static JourneyElement section(string name)
         => Siren.journey.section(name);
    public static JourneyElement task(string name, int score, Optional<IEnumerable<string>> actors = default)
         => Siren.journey.task(name, score, actors.ToOption());
}
