namespace Siren.Sea;

using static Siren.Types;

public class quadrant
{
    public static QuadrantElement raw(string txt)
         => Siren.quadrant.raw(txt);
    public static QuadrantElement title(string title)
         => Siren.quadrant.title(title);
    public static QuadrantElement xAxis(string left, Optional<string> right = default)
         => Siren.quadrant.xAxis(left, right.ToOption());
    public static QuadrantElement yAxis(string bottom, Optional<string> top = default)
         => Siren.quadrant.yAxis(bottom, top.ToOption());
    public static QuadrantElement quadrant1(string title)
         => Siren.quadrant.quadrant1(title);
    public static QuadrantElement quadrant2(string title)
         => Siren.quadrant.quadrant2(title);
    public static QuadrantElement quadrant3(string title)
         => Siren.quadrant.quadrant3(title);
    public static QuadrantElement quadrant4(string title)
         => Siren.quadrant.quadrant4(title);
    public static QuadrantElement point(string name, double xAxis, double yAxis)
         => Siren.quadrant.point(name, xAxis, yAxis);
    public static QuadrantElement comment(string txt)
         => Siren.quadrant.comment(txt);
}
