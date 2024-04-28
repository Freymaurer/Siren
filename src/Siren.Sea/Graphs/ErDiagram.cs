namespace Siren.Sea;

using static Siren.Types;
using static Formatting.ERDiagram;
using Util;

public static class erKey
{
    public static ERKeyType pk
         => Siren.erKey.pk;
    public static ERKeyType fk
         => Siren.erKey.fk;
    public static ERKeyType uk
         => Siren.erKey.uk;
}

public static class erCardinality
{
    public static ERCardinalityType oneOrMany
         => Siren.erCardinality.oneOrMany;
    public static ERCardinalityType oneOrZero
         => Siren.erCardinality.oneOrZero;
    public static ERCardinalityType onlyOne
         => Siren.erCardinality.onlyOne;
    public static ERCardinalityType zeroOrMany
         => Siren.erCardinality.zeroOrMany;
}
public static class erDiagram
{
    public static ERDiagramElement raw(string line)
         => Siren.erDiagram.raw(line);
    public static ERDiagramElement entity(string id, Optional<string> alias = default, Optional<IEnumerable<ERAttribute>> attr = default)
         => Siren.erDiagram.entity(id, alias.ToOption(), attr.ToOption());
    public static ERDiagramElement relationship(string id1, ERCardinalityType erCardinality1, string id2, ERCardinalityType erCardinality2, string message, Optional<bool> isOptional = default)
         => Siren.erDiagram.relationship(id1, erCardinality1, id2, erCardinality2, message, isOptional.ToOption());
    public static ERAttribute attribute(string attrType, string name, Optional<IEnumerable<ERKeyType>> keys = default, Optional<string> comment = default)
         => Siren.erDiagram.attribute(attrType, name, keys.ToOption(), comment.ToOption());
}
