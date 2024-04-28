namespace Siren.Sea;
using static Siren.Types;

public static class sankey
{
    public static SankeyElement raw(string line)
         => Siren.sankey.raw(line);
    public static SankeyElement comment(string txt)
         => Siren.sankey.comment(txt);
    public static SankeyElement link(string source, string target, double value)
         => Siren.sankey.link(source, target, value);
    public static SankeyElement links(string source, IEnumerable<(string, double)> targets)
         => Siren.sankey.links(source, targets.Select(t => t.ToTuple()));
}
