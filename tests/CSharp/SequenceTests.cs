using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siren.Sea.Tests
{
    public class Sequence
    {
        [Fact]
        public void Alt()
        {
            SirenElement graph =
                siren.sequence([
                    sequence.alt("if",[],[
                        ("else", [])
                    ])
                ]);
            string actual = siren.write(graph);
            string expected = @"sequenceDiagram
    alt if
    else else
    end
";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Docs()
        {
            SirenElement graph =
                siren.sequence([
                    sequence.participant("Alice"),
                    sequence.participant("John"),
                    sequence.links("Alice", [("Dashboard", "https://dashboard.contoso.com/alice"), ("Wiki", "https://wiki.contoso.com/alice")]),
                    sequence.links("John", [("Dashboard", "https://dashboard.contoso.com/john"), ("Wiki", "https://wiki.contoso.com/john")]),
                    sequence.messageArrow("Alice", "John", "Hello John, how are you?"),
                ]);
            string actual = siren.write(graph);
            string expected = @"sequenceDiagram
    participant Alice
    participant John
    links Alice: {""Dashboard"": ""https://dashboard.contoso.com/alice"", ""Wiki"": ""https://wiki.contoso.com/alice""}
    links John: {""Dashboard"": ""https://dashboard.contoso.com/john"", ""Wiki"": ""https://wiki.contoso.com/john""}
    Alice->>John: Hello John, how are you?
";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CompletenessTest()
        {
            Type csharpType = typeof(Siren.Sea.sequence);
            Type fsharpType = typeof(Siren.sequence);
            Utils.CompareClasses(csharpType, fsharpType);
        }
    }

}