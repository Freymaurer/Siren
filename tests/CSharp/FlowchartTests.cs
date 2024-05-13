using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.FSharp.Reflection;
using System.Reflection;
using Siren.Sea;

namespace Siren.Sea.Tests
{

    public class FlowchartTests
    {
        [Fact]
        public void WithTitle()
        {
            SirenElement graph = siren.flowchart(direction.lr, [
                flowchart.node("id1", "This is the text in the box")
            ]);
            string actual = 
                graph
                    .withTitle("Node with text")
                    .write();
            string expected = @"---
title: Node with text
---
flowchart LR
    id1[This is the text in the box]
";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void LengthChart()
        {
            (string a, string b, string c, string d, string e) = ("A", "B", "C", "D", "E");
            SirenElement graph = siren.flowchart(direction.td, [
                flowchart.node(a, "Start"),
                flowchart.nodeRhombus(b, "Is it?"),
                flowchart.node(c, "OK"),
                flowchart.node(d, "Rethink"),
                flowchart.node(e, "End"),
                flowchart.linkArrow(a, b),
                flowchart.linkArrow(b, c, "Yes"),
                flowchart.linkArrow(c, d),
                flowchart.linkArrow(d, b),
                flowchart.linkArrow(b, e, "No", 3),
            ]);
            string actual =
                graph.write();
            string expected = @"flowchart TD
    A[Start]
    B{Is it?}
    C[OK]
    D[Rethink]
    E[End]
    A-->B
    B-->|Yes|C
    C-->D
    D-->B
    B---->|No|E
";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void SubgraphsTest()
        {
            (string c1, string c2, string b1, string b2, string a1, string a2) = ("c1", "c2", "b1", "b2", "a1", "a2");
            SirenElement graph = siren.flowchart(direction.tb, [
                flowchart.linkArrow(c1, a2),
                flowchart.subgraph("one", [
                    flowchart.linkArrow(a1,a2)
                ]),
                flowchart.subgraph("two", [
                    flowchart.linkArrow(b1,b2)
                ]),
                flowchart.subgraph("three", [
                    flowchart.linkArrow(c1,c2)
                ])

            ]);
            string actual =
                graph.write();
            Console.WriteLine(actual);
            string expected = @"flowchart TB
    c1-->a2
    subgraph one
        a1-->a2
    end
    subgraph two
        b1-->b2
    end
    subgraph three
        c1-->c2
    end
";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void SubgraphDirectionTest()
        {
            (string outside, string top1, string bot1, string top2, string bot2) = ("outside", "top1", "bottom1", "top2", "bottom2");
            SirenElement graph = siren.flowchart(direction.lr, [
                flowchart.subgraph("subgraph1", [
                    flowchart.directionTB,
                    flowchart.node(top1),
                    flowchart.node(bot1),
                    flowchart.linkArrow(top1, bot1)
                ]),
                flowchart.subgraph("subgraph2", [
                    flowchart.directionTB,
                    flowchart.node(top2),
                    flowchart.node(bot2),
                    flowchart.linkArrow(top2, bot2)
                ]),
                flowchart.linkArrow(outside, "subgraph1"),
                flowchart.linkArrow(outside, top2, addedLength: 2),
            ]);
            string actual =
                graph.write();
            Console.WriteLine(actual);
            string expected = @"flowchart LR
    subgraph subgraph1
        direction TB
        top1[top1]
        bottom1[bottom1]
        top1-->bottom1
    end
    subgraph subgraph2
        direction TB
        top2[top2]
        bottom2[bottom2]
        top2-->bottom2
    end
    outside-->subgraph1
    outside--->top2
";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void MarkdownStringsTest()
        {
            SirenElement graph = siren.flowchart(direction.lr, [
                flowchart.subgraph("One", [
                    flowchart.nodeRound("a", formatting.markdown(@"The **cat**
in the hat")
                    ),
                    flowchart.nodeRhombus("b", formatting.markdown(@"The **dog** in the hog")),
                    flowchart.linkArrow("a","b", formatting.markdown("Bold **edge label**"))
                ]),
            ]);
            string actual = siren.write(graph);
            string expected = @"flowchart LR
    subgraph One
        a(""`The **cat**
in the hat`"")
        b{""`The **dog** in the hog`""}
        a-->|""`Bold **edge label**`""|b
    end
";
            Assert.Equal(expected, actual);
        }
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