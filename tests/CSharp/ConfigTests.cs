namespace Siren.Sea.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Siren.Yaml;

public class ConfigTests
{
    [Fact]
    public void FlowchartConfigTest()
    {
        Type csharpType = typeof(Siren.Sea.flowchartConfig);
        Type fsharpType = typeof(Siren.flowchartConfig);
        Utils.CompareClasses(csharpType, fsharpType);
    }
    [Fact]
    public void SequenceConfigTest()
    {
        Type csharpType = typeof(Siren.Sea.sequenceConfig);
        Type fsharpType = typeof(Siren.sequenceConfig);
        Utils.CompareClasses(csharpType, fsharpType);
    }
    [Fact]
    public void GanttConfigTest()
    {
        Type csharpType = typeof(Siren.Sea.ganttConfig);
        Type fsharpType = typeof(Siren.ganttConfig);
        Utils.CompareClasses(csharpType, fsharpType);
    }
    [Fact]
    public void JourneyConfigTest()
    {
        Type csharpType = typeof(Siren.Sea.journeyConfig);
        Type fsharpType = typeof(Siren.journeyConfig);
        Utils.CompareClasses(csharpType, fsharpType);
    }
    [Fact]
    public void TimelineConfigTest()
    {
        Type csharpType = typeof(Siren.Sea.timelineConfig);
        Type fsharpType = typeof(Siren.timelineConfig);
        Utils.CompareClasses(csharpType, fsharpType);
    }
    [Fact]
    public void ClassConfigTest()
    {
        Type csharpType = typeof(Siren.Sea.classConfig);
        Type fsharpType = typeof(Siren.classConfig);
        Utils.CompareClasses(csharpType, fsharpType);
    }
    [Fact]
    public void StateConfigTest()
    {
        Type csharpType = typeof(Siren.Sea.stateConfig);
        Type fsharpType = typeof(Siren.stateConfig);
        Utils.CompareClasses(csharpType, fsharpType);
    }
    [Fact]
    public void ERConfigTest()
    {
        Type csharpType = typeof(Siren.Sea.erConfig);
        Type fsharpType = typeof(Siren.erConfig);
        Utils.CompareClasses(csharpType, fsharpType);
    }
    [Fact]
    public void QuadrantChartConfigTest()
    {
        Type csharpType = typeof(Siren.Sea.quadrantChartConfig);
        Type fsharpType = typeof(Siren.quadrantChartConfig);
        Utils.CompareClasses(csharpType, fsharpType);
    }
    [Fact]
    public void PieConfigTest()
    {
        Type csharpType = typeof(Siren.Sea.pieConfig);
        Type fsharpType = typeof(Siren.pieConfig);
        Utils.CompareClasses(csharpType, fsharpType);
    }
    [Fact]
    public void XYChartConfigTest()
    {
        Type csharpType = typeof(Siren.Sea.xyChartConfig);
        Type fsharpType = typeof(Siren.xyChartConfig);
        Utils.CompareClasses(csharpType, fsharpType);
    }
    [Fact]
    public void MindmapConfigTest()
    {
        Type csharpType = typeof(Siren.Sea.mindmapConfig);
        Type fsharpType = typeof(Siren.mindmapConfig);
        Utils.CompareClasses(csharpType, fsharpType);
    }
    [Fact]
    public void GitGraphConfig()
    {
        Type csharpType = typeof(Siren.Sea.gitGraphConfig);
        Type fsharpType = typeof(Siren.gitGraphConfig);
        Utils.CompareClasses(csharpType, fsharpType);
    }
    [Fact]
    public void RequirementDiagramConfig()
    {
        Type csharpType = typeof(Siren.Sea.requirementConfig);
        Type fsharpType = typeof(Siren.requirementConfig);
        Utils.CompareClasses(csharpType, fsharpType);
    }
}
