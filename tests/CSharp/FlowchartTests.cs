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

    public static class Utils
    {
        public static int GetMemberCount(Type type)
        {
            var members = type.GetMembers();
            return members.Length;
        }

        public static List<string> GetMemberNameDifferences(Type type1, Type type2)
        {
            List<string> differences = new List<string>();

            var type1Members = type1.GetMembers().Select(m => m.Name);
            var type2Members = type2.GetMembers().Select(m => m.Name);
            differences.AddRange(type1Members.Except(type2Members));
            differences.AddRange(type2Members.Except(type1Members));

            return differences;
        }
    }

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
            int csharpMemberCount = Utils.GetMemberCount(csharpType);
            int fsharpMemberCount = Utils.GetMemberCount(fsharpType);
            List<string> differences = Utils.GetMemberNameDifferences(fsharpType, csharpType);
            Assert.Empty(differences);
            Assert.Equal(fsharpMemberCount, csharpMemberCount);
        }
    }
}