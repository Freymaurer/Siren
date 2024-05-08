namespace Siren.Sea.Tests;
using Xunit;
using Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


public class MindmapTests
{
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
