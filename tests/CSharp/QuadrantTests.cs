namespace Siren.Sea.Tests;
using Xunit;
using Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using static Fable.Core.JS;
using System.Reflection.Emit;


public class QuadrantTests
{
    public class DocsTests
    {
        [Fact]
        public void Engagement()
        {
            string actual =
                siren.quadrant([
                    quadrant.title("Reach and engagement of campaigns"),
                    quadrant.xAxis("Low Reach", "High Reach"),
                    quadrant.yAxis("Low Engagement", "High Engagement"),
                    quadrant.comment("Labels start here"),
                    quadrant.quadrant1("We should expand"),
                    quadrant.quadrant2("Need to promote"),
                    quadrant.quadrant3("Re-evaluate"),
                    quadrant.quadrant4("May be improved"),

                    quadrant.point("Campaign A", 0.3, 0.6),
                    quadrant.point("Campaign B", 0.45, 0.23),
                    quadrant.point("Campaign C", 0.57, 0.69),
                    quadrant.point("Campaign D", 0.78, 0.34),
                    quadrant.point("Campaign E", 0.40, 0.34),
                    quadrant.point("Campaign F", 0.35, 0.78),
                ]).write();
            string expected = @"quadrantChart
    title Reach and engagement of campaigns
    x-axis Low Reach --> High Reach
    y-axis Low Engagement --> High Engagement
    %% Labels start here
    quadrant-1 We should expand
    quadrant-2 Need to promote
    quadrant-3 Re-evaluate
    quadrant-4 May be improved
    Campaign A: [0.30, 0.60]
    Campaign B: [0.45, 0.23]
    Campaign C: [0.57, 0.69]
    Campaign D: [0.78, 0.34]
    Campaign E: [0.40, 0.34]
    Campaign F: [0.35, 0.78]
";
            Assert.Equal(expected, actual);
        }
    }
    public class CompletenessTests
    {
        [Fact]
        public void QuadrantTest()
        {
            Type csharpType = typeof(Siren.Sea.quadrant);
            Type fsharpType = typeof(Siren.quadrant);
            Utils.CompareClasses(csharpType, fsharpType);
        }
    }
}
