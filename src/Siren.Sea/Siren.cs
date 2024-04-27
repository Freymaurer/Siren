namespace Siren.Sea;

using static Siren.Types;

public class siren
{
    public static SirenElement flowchart(Direction direction, IEnumerable<FlowchartElement> children)
         => Siren.siren.flowchart(direction, children);
    public static SirenElement sequence(IEnumerable<SequenceElement> children)
         => Siren.siren.sequence(children);
    public static SirenElement classDiagram(IEnumerable<ClassDiagramElement> children)
         => Siren.siren.classDiagram(children);
    public static SirenElement state(IEnumerable<StateDiagramElement> children)
         => Siren.siren.state(children);
    public static SirenElement stateV2(IEnumerable<StateDiagramElement> children)
         => Siren.siren.stateV2(children);
    public static SirenElement erDiagram(IEnumerable<ERDiagramElement> children)
         => Siren.siren.erDiagram(children);
    public static SirenElement journey(IEnumerable<JourneyElement> children)
         => Siren.siren.journey(children);
    public static SirenElement gantt(IEnumerable<GanttElement> children)
         => Siren.siren.gantt(children);
    public static SirenElement pieChart(IEnumerable<PieChartElement> children, Optional<bool> showData = default, Optional<string> title = default)
         => Siren.siren.pieChart(children, showData.ToOption(), title.ToOption());
    public static SirenElement quadrant(IEnumerable<QuadrantElement> children)
         => Siren.siren.quadrant(children);
    public static SirenElement requirement(IEnumerable<RequirementDiagramElement> children)
         => Siren.siren.requirement(children);
    public static SirenElement git(IEnumerable<GitGraphElement> children)
         => Siren.siren.git(children);
    public static SirenElement mindmap(IEnumerable<MindmapElement> children)
         => Siren.siren.mindmap(children);
    public static SirenElement timeline(IEnumerable<TimelineElement> children)
         => Siren.siren.timeline(children);
    public static SirenElement sankey(IEnumerable<SankeyElement> children)
         => Siren.siren.sankey(children);
    public static SirenElement xyChart(IEnumerable<XYChartElement> children, Optional<bool> isHorizontal = default)
         => Siren.siren.xyChart(children, isHorizontal.ToOption());
    public static String write(SirenElement diagram)
         => Siren.siren.write(diagram);
}

public class Testing
{
    public void Test()
    {
        SirenElement graph = siren.classDiagram
        ([
            classDiagram.@class("Test1"),
            classDiagram.@class("Test2"),
            classDiagram.relationshipCustom
            (
                "Test1", "Test2",
                classRltsType.association,
                direction: classDirection.twoWay,
                isDotted: true,
                cardinality1: classCardinality.one,
                cardinality2: classCardinality.zeroToN
            )
        ]);
        return;
    }
}