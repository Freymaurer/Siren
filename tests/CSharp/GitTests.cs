namespace Siren.Sea.Tests;
using Xunit;
using Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


public class GitTests
{
    public class CompletenessTests
    {
        [Fact]
        public void GitTest()
        {
            Type csharpType = typeof(Siren.Sea.git);
            Type fsharpType = typeof(Siren.git);
            Utils.CompareClasses(csharpType, fsharpType);
        }
    }
}
