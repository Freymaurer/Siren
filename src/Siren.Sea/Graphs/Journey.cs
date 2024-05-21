namespace Siren.Sea;

using Util;
public static class journey
{
    public static JourneyElement raw(string line)
         => Siren.journey.raw(line);
    public static JourneyElement title(string name)
         => Siren.journey.title(name);
    public static JourneyElement section(string name)
         => Siren.journey.section(name);
    public static JourneyElement task(string name, int score, string[] actors)
         => Siren.journey.task(name, score, actors);
    public static JourneyElement taskEmpty(string name, int score)
         => Siren.journey.taskEmpty(name, score);
}
