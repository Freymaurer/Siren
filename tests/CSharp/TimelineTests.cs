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
