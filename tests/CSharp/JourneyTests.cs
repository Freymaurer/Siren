namespace Siren.Sea.Tests;
using Xunit;
using Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


public class JourneyTests
{
    public class CompletenessTests
    {
        [Fact]
        public void JourneyTest()
        {
            Type csharpType = typeof(Siren.Sea.journey);
            Type fsharpType = typeof(Siren.journey);
            Utils.CompareClasses(csharpType, fsharpType);
        }
    }
}
