namespace Siren.Sea;

using Util;

public static class Block
{
    public static BlockElement columns(int count)
         => Siren.block.columns(count);
    public static BlockElement simple(string id)
         => Siren.block.simple(id);
    public static BlockElement simples(string[] ids)
         => Siren.block.simples(ids);
    public static BlockElement cBlock(BlockElement[] children)
         => Siren.block.cBlock(children);
    public static BlockElement cIdBlock(string id, BlockElement[] children)
         => Siren.block.cIdBlock(id, children);
    public static BlockElement cIdWidthBlock(string id, int width, BlockElement[] children)
         => Siren.block.cIdWidthBlock(id, width, children);
    public static BlockElement line(BlockElement[] children)
         => Siren.block.line(children);
    public static BlockElement block(string id, Optional<string> label = default, Optional<int> width = default)
         => Siren.block.block(id, label.ToOption(), width.ToOption());
    public static BlockElement blockRounded(string id, Optional<string> label = default, Optional<int> width = default)
         => Siren.block.blockRounded(id, label.ToOption(), width.ToOption());
    public static BlockElement blockStatidum(string id, Optional<string> label = default, Optional<int> width = default)
         => Siren.block.blockStatidum(id, label.ToOption(), width.ToOption());
    public static BlockElement blockSubroutine(string id, Optional<string> label = default, Optional<int> width = default)
         => Siren.block.blockSubroutine(id, label.ToOption(), width.ToOption());
    public static BlockElement blockCylindrical(string id, Optional<string> label = default, Optional<int> width = default)
         => Siren.block.blockCylindrical(id, label.ToOption(), width.ToOption());
    public static BlockElement blockCircle(string id, Optional<string> label = default, Optional<int> width = default)
         => Siren.block.blockCircle(id, label.ToOption(), width.ToOption());
    public static BlockElement blockAsymmetric(string id, Optional<string> label = default, Optional<int> width = default)
         => Siren.block.blockAsymmetric(id, label.ToOption(), width.ToOption());
    public static BlockElement blockRhombus(string id, Optional<string> label = default, Optional<int> width = default)
         => Siren.block.blockRhombus(id, label.ToOption(), width.ToOption());
    public static BlockElement blockHexagon(string id, Optional<string> label = default, Optional<int> width = default)
         => Siren.block.blockHexagon(id, label.ToOption(), width.ToOption());
    public static BlockElement blockParallelogram(string id, Optional<string> label = default, Optional<int> width = default)
         => Siren.block.blockParallelogram(id, label.ToOption(), width.ToOption());
    public static BlockElement blockParallelogramAlt(string id, Optional<string> label = default, Optional<int> width = default)
         => Siren.block.blockParallelogramAlt(id, label.ToOption(), width.ToOption());
    public static BlockElement blockTrapezoid(string id, Optional<string> label = default, Optional<int> width = default)
         => Siren.block.blockTrapezoid(id, label.ToOption(), width.ToOption());
    public static BlockElement blockTrapezoidAlt(string id, Optional<string> label = default, Optional<int> width = default)
         => Siren.block.blockTrapezoidAlt(id, label.ToOption(), width.ToOption());
    public static BlockElement blockDoubleCircle(string id, Optional<string> label = default, Optional<int> width = default)
         => Siren.block.blockDoubleCircle(id, label.ToOption(), width.ToOption());
    public static BlockElement arrowRightLabeled(string id, Optional<string> label = default)
         => Siren.block.arrowRightLabeled(id, label.ToOption());
    public static BlockElement arrowRight(string id, Optional<int> width = default)
         => Siren.block.arrowRight(id, width.ToOption());
    public static BlockElement arrowLeftLabeled(string id, Optional<string> label = default)
         => Siren.block.arrowLeftLabeled(id, label.ToOption());
    public static BlockElement arrowLeft(string id, Optional<int> width = default)
         => Siren.block.arrowLeft(id, width.ToOption());
    public static BlockElement arrowUpLabeled(string id, Optional<string> label = default)
         => Siren.block.arrowUpLabeled(id, label.ToOption());
    public static BlockElement arrowUp(string id, Optional<int> width = default)
         => Siren.block.arrowUp(id, width.ToOption());
    public static BlockElement arrowDownLabeled(string id, Optional<string> label = default)
         => Siren.block.arrowDownLabeled(id, label.ToOption());
    public static BlockElement arrowDown(string id, Optional<int> width = default)
         => Siren.block.arrowDown(id, width.ToOption());
    public static BlockElement arrowXLabeled(string id, Optional<string> label = default)
         => Siren.block.arrowXLabeled(id, label.ToOption());
    public static BlockElement arrowX(string id, Optional<int> width = default)
         => Siren.block.arrowX(id, width.ToOption());
    public static BlockElement arrowYLabeled(string id, Optional<string> label = default)
         => Siren.block.arrowYLabeled(id, label.ToOption());
    public static BlockElement arrowY(string id, Optional<int> width = default)
         => Siren.block.arrowY(id, width.ToOption());
    public static BlockElement arrowCustomLabeled(string id, string direction, Optional<string> label = default)
         => Siren.block.arrowCustomLabeled(id, direction, label.ToOption());
    public static BlockElement arrowCustom(string id, string direction, Optional<int> width = default)
         => Siren.block.arrowCustom(id, direction, width.ToOption());
    public static BlockElement space
         => Siren.block.space;
    public static BlockElement spacew(Optional<int> width = default)
         => Siren.block.spacew(width.ToOption());
    public static BlockElement link(string id1, string id2, Optional<string> label = default)
         => Siren.block.link(id1, id2, label.ToOption());
    public static BlockElement style(string id, (string,string)[] styles)
         => Siren.block.style(id, styles.Select(t => t.ToTuple()));
    public static BlockElement classDef(string className, (string, string)[] styles)
         => Siren.block.classDef(className, styles.Select(t => t.ToTuple()));
    public static BlockElement @class(string[] nodeIds, string className)
         => Siren.block.@class(nodeIds, className);
    public static BlockElement comment(string txt)
         => Siren.block.comment(txt);
}
