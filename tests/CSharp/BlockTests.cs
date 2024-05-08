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
    public class CompletenessTests
    {
        [Fact]
        public void BlockTest()
        {
            Type csharpType = typeof(Siren.Sea.blockGraph);
            Type fsharpType = typeof(Siren.block);
            Utils.CompareClasses(csharpType, fsharpType);
        }
    }
}
