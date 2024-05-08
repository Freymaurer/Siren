namespace Siren.Sea.Tests;
using Xunit;
using Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


public class QuadrantTests
{
    public class CompletenessTests
    {
        [Fact]
        public void QuadrantTest()
        {
            Type csharpType = typeof(Siren.Sea.quadrant);
            Type fsharpType = typeof(Siren.quadrant);
            Utils.CompareClasses(csharpType, fsharpType);
        }
    }
}
