namespace Siren.Sea.Tests;
using Xunit;
using Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


public class GanttTests
{
    public class CompletenessTests
    {
        [Fact]
        public void GanttTest()
        {
            Type csharpType = typeof(Siren.Sea.gantt);
            Type fsharpType = typeof(Siren.gantt);
            Utils.CompareClasses(csharpType, fsharpType);
        }
    }
}
