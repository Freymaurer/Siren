using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.FSharp.Reflection;
using System.Reflection;
using Siren.Sea;
using static Siren.Types;

namespace Siren.Sea.Tests
{

    public class FlowchartTests
    {
        [Fact]
        public void MoonRocket()
        {
            SirenElement graph = siren.flowchart(direction.bt, [
                flowchart.subgraph("space", [
                    flowchart.directionBT,
                    flowchart.linkDottedArrow("earth", "moon", formatting.unicode("🚀"), 6),
                    flowchart.nodeRound("moon"),
                    flowchart.subgraph("atmosphere",[
                        flowchart.nodeCircle("earth")
                    ])
                ])
            ]);
            string actual = siren.write(graph);
            string expected = @"flowchart BT
    subgraph space
        direction BT
        earth-......->|""🚀""|moon
        moon(moon)
        subgraph atmosphere
            earth((earth))
        end
    end
";
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void CompletenessTest()
        {
            Type csharpType = typeof(Siren.Sea.flowchart);
            Type fsharpType = typeof(Siren.flowchart);
            Utils.CompareClasses(csharpType, fsharpType);
        }
    }
}