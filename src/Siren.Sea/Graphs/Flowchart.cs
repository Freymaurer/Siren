namespace Siren.Sea;

using static Siren.Types;

public class flowchart
{
    public static FlowchartElement raw(string txt) => Siren.flowchart.raw(txt);

    public static FlowchartElement id(string txt) => Siren.flowchart.raw(txt);

    public static FlowchartElement node(string id, Optional<string> name = default) =>
        Siren.flowchart.node(id, name.ToOption());
    public static FlowchartElement nodeRound(string id, Optional<string> name = default) =>
        Siren.flowchart.nodeRound(id, name.ToOption());
    public static FlowchartElement nodeStadium(string id, Optional<string> name = default) =>
        Siren.flowchart.nodeStadium(id, name.ToOption());
    public static FlowchartElement nodeSubroutine(string id, Optional<string> name = default) =>
        Siren.flowchart.nodeSubroutine(id, name.ToOption());
    public static FlowchartElement nodeCylindrical(string id, Optional<string> name = default) =>
        Siren.flowchart.nodeCylindrical(id, name.ToOption());
    public static FlowchartElement nodeCircle(string id, Optional<string> name = default) =>
        Siren.flowchart.nodeCircle(id, name.ToOption());
    public static FlowchartElement nodeAsymmetric(string id, Optional<string> name = default) =>
        Siren.flowchart.nodeAsymmetric(id, name.ToOption());
    public static FlowchartElement nodeRhombus(string id, Optional<string> name = default) =>
        Siren.flowchart.nodeRhombus(id, name.ToOption());
    public static FlowchartElement nodeHexagon(string id, Optional<string> name = default) =>
        Siren.flowchart.nodeHexagon(id, name.ToOption());
    public static FlowchartElement nodeParallelogram(string id, Optional<string> name = default) =>
        Siren.flowchart.nodeParallelogram(id, name.ToOption());
    public static FlowchartElement nodeParallelogramAlt(string id, Optional<string> name = default) =>
        Siren.flowchart.nodeParallelogramAlt(id, name.ToOption());
    public static FlowchartElement nodeTrapezoid(string id, Optional<string> name = default) =>
        Siren.flowchart.nodeTrapezoid(id, name.ToOption());
    public static FlowchartElement nodeTrapezoidAlt(string id, Optional<string> name = default) =>
        Siren.flowchart.nodeTrapezoidAlt(id, name.ToOption());
    public static FlowchartElement nodeDoubleCircle(string id, Optional<string> name = default) =>
        Siren.flowchart.nodeDoubleCircle(id, name.ToOption());

    public static FlowchartElement linkArrow(string id1, string id2, Optional<string> message, Optional<int> addedLength) =>
        Siren.flowchart.linkArrow(id1, id2, message.ToOption(), addedLength.ToOption());
    public static FlowchartElement linkArrowDouble(string id1, string id2, Optional<string> message, Optional<int> addedLength) =>
        Siren.flowchart.linkArrowDouble(id1, id2, message.ToOption(), addedLength.ToOption());
    public static FlowchartElement linkOpen(string id1, string id2, Optional<string> message, Optional<int> addedLength) =>
        Siren.flowchart.linkOpen(id1, id2, message.ToOption(), addedLength.ToOption());
    public static FlowchartElement linkDotted(string id1, string id2, Optional<string> message, Optional<int> addedLength) =>
        Siren.flowchart.linkDotted(id1, id2, message.ToOption(), addedLength.ToOption());
    public static FlowchartElement linkDottedArrow(string id1, string id2, Optional<string> message, Optional<int> addedLength) =>
        Siren.flowchart.linkDottedArrow(id1, id2, message.ToOption(), addedLength.ToOption());
    public static FlowchartElement linkThick(string id1, string id2, Optional<string> message, Optional<int> addedLength) =>
        Siren.flowchart.linkThick(id1, id2, message.ToOption(), addedLength.ToOption());
    public static FlowchartElement linkThickArrow(string id1, string id2, Optional<string> message, Optional<int> addedLength) =>
        Siren.flowchart.linkThickArrow(id1, id2, message.ToOption(), addedLength.ToOption());
    public static FlowchartElement linkInvisible(string id1, string id2, Optional<string> message, Optional<int> addedLength) =>
        Siren.flowchart.linkInvisible(id1, id2, message.ToOption(), addedLength.ToOption());
    public static FlowchartElement linkCircleEdge(string id1, string id2, Optional<string> message, Optional<int> addedLength) =>
        Siren.flowchart.linkCircleEdge(id1, id2, message.ToOption(), addedLength.ToOption());
    public static FlowchartElement linkCircleDouble(string id1, string id2, Optional<string> message, Optional<int> addedLength) =>
        Siren.flowchart.linkCircleDouble(id1, id2, message.ToOption(), addedLength.ToOption());
    public static FlowchartElement linkCrossEdge(string id1, string id2, Optional<string> message, Optional<int> addedLength) =>
        Siren.flowchart.linkCrossEdge(id1, id2, message.ToOption(), addedLength.ToOption());
    public static FlowchartElement linkCrossDouble(string id1, string id2, Optional<string> message, Optional<int> addedLength) =>
        Siren.flowchart.linkCrossDouble(id1, id2, message.ToOption(), addedLength.ToOption());

    public static FlowchartElement direction(Direction direction) => Siren.flowchart.direction(direction);
    public static FlowchartElement directionTB => Siren.flowchart.directionTB;
    public static FlowchartElement directionTD => Siren.flowchart.directionTD;
    public static FlowchartElement directionBT => Siren.flowchart.directionBT;
    public static FlowchartElement directionRL => Siren.flowchart.directionRL;
    public static FlowchartElement directionLR => Siren.flowchart.directionLR;

    public static FlowchartElement subgraphNamed(string id, string name, FlowchartElement[] children) =>
        Siren.flowchart.subgraphNamed(id, name, children);
    public static FlowchartElement subgraph(string id, FlowchartElement[] children) =>
        Siren.flowchart.subgraph(id, children);
    public static FlowchartElement clickHref(string id, string url, Optional<string> tooltip = default) =>
        Siren.flowchart.clickHref(id, url, tooltip.ToOption());
    public static FlowchartElement comment(string txt) =>
        Siren.flowchart.comment(txt);
};