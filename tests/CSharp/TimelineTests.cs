namespace Siren.Sea.Tests;
using Xunit;
using Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


public class TimelineTests
{
    public class DocsTests
    {
        [Fact]
        public void Example()
        {
            string actual =
                siren.timeline
                ([
                    timeline.title("MermaidChart 2023 Timeline"),
                    timeline.section("2023 Q1 <br> Release Personal Tier",[
                        timeline.multiple("Bullet 1", [
                            "sub-point 1a",
                            "sub-point 1b",
                            "sub-point 1c"
                        ]),
                        timeline.multiple("Bullet 2", [
                            "sub-point 2a",
                            "sub-point 2b",
                        ])
                    ]),
                    timeline.section("2023 Q2 <br> Release XYZ Tier",[
                        timeline.multiple("Bullet 3", [
                            "sub-point 3a",
                            "sub-point 3b",
                            "sub-point 3c"
                        ]),
                        timeline.multiple("Bullet 4", [
                            "sub-point 4a",
                            "sub-point 4b",
                        ])
                    ]),
                ]).write();
            string expected = @"timeline
    title MermaidChart 2023 Timeline
    section 2023 Q1 <br> Release Personal Tier
        Bullet 1
            : sub-point 1a
            : sub-point 1b
            : sub-point 1c
        Bullet 2
            : sub-point 2a
            : sub-point 2b
    section 2023 Q2 <br> Release XYZ Tier
        Bullet 3
            : sub-point 3a
            : sub-point 3b
            : sub-point 3c
        Bullet 4
            : sub-point 4a
            : sub-point 4b
";
            Assert.Equal(expected, actual);
        }
    }
    public class CompletenessTests
    {
        [Fact]
        public void TimelineTest()
        {
            Type csharpType = typeof(Siren.Sea.timeline);
            Type fsharpType = typeof(Siren.timeline);
            Utils.CompareClasses(csharpType, fsharpType);
        }
    }
}
