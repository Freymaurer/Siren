namespace Siren.Sea.Tests;
using Xunit;
using Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using static Siren.Yaml.AST;


public class MindmapTests
{
    public class DocsTests
    {
        [Fact]
        public void Example()
        {
            string actual =
                siren.mindmap([
                    mindmap.circleId("root", "mindmap", new MindmapElement[] {

                        mindmap.node("Origins", new MindmapElement[] {
                            mindmap.node ("Long history"),
                            mindmap.icon ("fa fa-book"),
                            mindmap.node ("Popularisation", new MindmapElement[] {
                                mindmap.node("British popular psychology author Tony Buzan")
                            })
                        }),

                        mindmap.node("Research", new MindmapElement[] {
                            mindmap.node ("On effectiveness<br/>and features"),
                            mindmap.node ("On Automatic creation", new MindmapElement[] {
                                mindmap.node ("Uses", new MindmapElement[] {
                                    mindmap.node ("Creative techniques"),
                                    mindmap.node ("Strategic planning"),
                                    mindmap.node ("Argument mapping")
                                })
                            })
                        }),

                        mindmap.node ("Tools", new MindmapElement[] {
                            mindmap.node ("Pen and paper"),
                            mindmap.node ("Mermaid")
                        })
                    })
                ]).write();
            string expected = @"mindmap
    root((mindmap))
        Origins
            Long history
            ::icon(fa fa-book)
            Popularisation
                British popular psychology author Tony Buzan
        Research
            On effectiveness<br/>and features
            On Automatic creation
                Uses
                    Creative techniques
                    Strategic planning
                    Argument mapping
        Tools
            Pen and paper
            Mermaid
";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Markdown()
        {
            string actual =
                siren.mindmap([
                    mindmap.squareId(
                        "id1",
                        formatting.markdown(@"**Root** with
a second line
Unicode works too: 🤓"), new MindmapElement[] {
                        mindmap.squareId("id2", formatting.markdown(@"The dog in **the** hog... a *very long text* that wraps to a new line"))
                    })
                ]).write();
            string expected = @"mindmap
    id1[""`**Root** with
a second line
Unicode works too: 🤓`""]
        id2[""`The dog in **the** hog... a *very long text* that wraps to a new line`""]
";
            Assert.Equal(expected, actual);
        }
    }
    public class CompletenessTests
    {
        [Fact]
        public void MindmapTest()
        {
            Type csharpType = typeof(Siren.Sea.mindmap);
            Type fsharpType = typeof(Siren.mindmap);
            Utils.CompareClasses(csharpType, fsharpType);
        }
    }
}
