namespace Siren.Sea.Tests;
using Xunit;
using Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


public class BlockTests
{
    public class DocsTests
    {
        [Fact]
        public void Introduction()
        {
            string actual =
                siren.block([
                    Block.columns(1),
                    Block.blockCircle("db", "DB"),
                    Block.arrowDown("blockArrowId6"),
                    Block.cIdBlock("ID", [
                        Block.block("A"),
                        Block.block("B", "A wide one in the middle"),
                        Block.block("C")
                    ]),
                    Block.space,
                    Block.block("D"),
                    Block.link("ID", "D"),
                    Block.link("C", "D"),
                    Block.style("B", [
                        ("fill", "#939"),
                        ("stroke", "#333"),
                        ("stroke-width", "4px")
                    ])
                ]).write();
            string expected = @"block-beta
    columns 1
    db((""DB""))
    blockArrowId6<[""&nbsp;&nbsp;&nbsp;""]>(down)
    block:ID
        A[""A""]
        B[""A wide one in the middle""]
        C[""C""]
    end
    space
    D[""D""]
    ID-->D
    C-->D
    style B fill:#939,stroke:#333,stroke-width:4px;
";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Services()
        {
            (string Frontend, string Backend, string Database) = ("Frontend", "Backend", "Database");
            string actual =
                siren.block([
                    Block.columns(3),
                    Block.line([
                        Block.block(Frontend),
                        Block.arrowRight("blockArrowId6", 1),
                        Block.block(Backend)
                    ]),
                    Block.line([
                        Block.spacew(2),
                        Block.arrowDown("down", 1)
                    ]),
                    Block.line([
                        Block.block("Disk"),
                        Block.arrowLeft("left", 1),
                        Block.blockCylindrical(Database)
                    ]),
                    Block.classDef("front", [
                        ("fill", "#696"), 
                        ("stroke", "#333")
                    ]),
                    Block.classDef("back", [("fill", "#969"), ("stroke", "#333")]),
                    Block.@class([Frontend], "front"),
                    Block.@class([Backend, Database], "back")
                ]).write();
            string expected = @"block-beta
    columns 3
    Frontend[""Frontend""] blockArrowId6<[""&nbsp;""]>(right) Backend[""Backend""]
    space:2 down<[""&nbsp;""]>(down)
    Disk[""Disk""] left<[""&nbsp;""]>(left) Database[(""Database"")]
    classDef front fill:#696,stroke:#333;
    classDef back fill:#969,stroke:#333;
    class Frontend front
    class Backend,Database back
";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void DecisionMaking()
        {
            string actual =
                siren.block([
                    Block.columns(3),
                    Block.line([
                        Block.blockCircle("Start"),
                        Block.spacew(2)
                    ]),
                    Block.line([
                        Block.arrowDownLabeled("down", " "),
                        Block.spacew(2)
                    ]),
                    Block.line([
                        Block.blockHexagon("Decision", "Make Decision"),
                        Block.arrowRightLabeled("right", "Yes"),
                        Block.block("Process1", "Process A")
                    ]),
                    Block.line([
                        Block.arrowDownLabeled("downAgain", "No"),
                        Block.space,
                        Block.arrowDownLabeled("r3", "Done")
                    ]),
                    Block.line([
                        Block.block("Process2", "Process B"),
                        Block.arrowRightLabeled("r2", "Done"),
                        Block.blockCircle("End")
                    ]),
                    Block.style("Start", [("fill", "#969")]),
                    Block.style("End", [("fill", "#696")])
                ]).write();
            string expected = @"block-beta
    columns 3
    Start((""Start"")) space:2
    down<["" ""]>(down) space:2
    Decision{{""Make Decision""}} right<[""Yes""]>(right) Process1[""Process A""]
    downAgain<[""No""]>(down) space r3<[""Done""]>(down)
    Process2[""Process B""] r2<[""Done""]>(right) End((""End""))
    style Start fill:#969;
    style End fill:#696;
";
            Assert.Equal(expected, actual);
        }
    }
    public class CompletenessTests
    {
        [Fact]
        public void BlockTest()
        {
            Type csharpType = typeof(Siren.Sea.Block);
            Type fsharpType = typeof(Siren.block);
            Utils.CompareClasses(csharpType, fsharpType);
        }
    }
}
