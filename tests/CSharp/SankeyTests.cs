namespace Siren.Sea.Tests;
using Xunit;
using Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


public class SankeyTests
{
    public class DocsTests
    {
        [Fact]
        public void BioConversion()
        {
            string actual =
                siren.sankey([
                    sankey.links("Bio-conversion", [
                        ("Losses", 26.862),
                        ("Solid", 280.322),
                        ("Gas", 81.144)
                    ])
                ]).write();
            string expected = @"sankey-beta
""Bio-conversion"",""Losses"",26.862000
""Bio-conversion"",""Solid"",280.322000
""Bio-conversion"",""Gas"",81.144000
";
            Assert.Equal(expected, actual);
        }
    }
    public class CompletenessTests
    {
        [Fact]
        public void SankeyTest()
        {
            Type csharpType = typeof(Siren.Sea.sankey);
            Type fsharpType = typeof(Siren.sankey);
            Utils.CompareClasses(csharpType, fsharpType);
        }
    }
}
