namespace Siren.Sea.Tests;
using Xunit;
using Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

public class SirenElementTests
{
    [Fact]
    public void AccessibilityTests()
    {
        SirenElement element =
            siren.sankey
                ([
                    sankey.links("Input1",[
                        ("Output1", 12),
                        ("Output2", 23),
                        ("Output3", 34)
                    ])
                ]);
        string actual = element.write();
        string expected = @"sankey-beta
""Input1"",""Output1"",12.000000
""Input1"",""Output2"",23.000000
""Input1"",""Output3"",34.000000
";
        Assert.Equal(expected, actual);
    }
}
