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
