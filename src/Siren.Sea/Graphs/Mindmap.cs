namespace Siren.Sea;
using Util;
public static class mindmap
{
    public static MindmapElement raw(string line)
         => Siren.mindmap.raw(line);
    public static MindmapElement node(string name, Optional<MindmapElement[]> children = default)
         => Siren.mindmap.node(name, children.ToOption());
    public static MindmapElement square(string name, Optional<MindmapElement[]> children = default)
         => Siren.mindmap.square(name, children.ToOption());
    public static MindmapElement squareId(string id, string name, Optional<MindmapElement[]> children = default)
         => Siren.mindmap.squareId(id, name, children.ToOption());
    public static MindmapElement roundedSquare(string name, Optional<MindmapElement[]> children = default)
         => Siren.mindmap.roundedSquare(name, children.ToOption());
    public static MindmapElement roundedSquareId(string id, string name, Optional<MindmapElement[]> children = default)
         => Siren.mindmap.roundedSquareId(id, name, children.ToOption());
    public static MindmapElement circle(string name, Optional<MindmapElement[]> children = default)
         => Siren.mindmap.circle(name, children.ToOption());
    public static MindmapElement circleId(string id, string name, Optional<MindmapElement[]> children = default)
         => Siren.mindmap.circleId(id, name, children.ToOption());
    public static MindmapElement bang(string name, Optional<MindmapElement[]> children = default)
         => Siren.mindmap.bang(name, children.ToOption());
    public static MindmapElement bangId(string id, string name, Optional<MindmapElement[]> children = default)
         => Siren.mindmap.bangId(id, name, children.ToOption());
    public static MindmapElement cloud(string name, Optional<MindmapElement[]> children = default)
         => Siren.mindmap.cloud(name, children.ToOption());
    public static MindmapElement cloudId(string id, string name, Optional<MindmapElement[]> children = default)
         => Siren.mindmap.cloudId(id, name, children.ToOption());
    public static MindmapElement hexagon(string name, Optional<MindmapElement[]> children = default)
         => Siren.mindmap.hexagon(name, children.ToOption());
    public static MindmapElement hexagonId(string id, string name, Optional<MindmapElement[]> children = default)
         => Siren.mindmap.hexagonId(id, name, children.ToOption());
    public static MindmapElement icon(string iconClass)
         => Siren.mindmap.icon(iconClass);
    public static MindmapElement className(string className)
         => Siren.mindmap.className(className);
    public static MindmapElement classNames(IEnumerable<string> classNames)
         => Siren.mindmap.classNames(classNames);
    public static String comment(string txt)
         => Siren.mindmap.comment(txt);
}
