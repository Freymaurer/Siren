namespace Siren.Sea.Tests;
using Xunit;
using Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


public class RequirementTests
{
    public class CompletenessTests
    {
        [Fact]
        public void RequirementTest()
        {
            Type csharpType = typeof(Siren.Sea.Requirement);
            Type fsharpType = typeof(Siren.requirement);
            Utils.CompareClasses(csharpType, fsharpType);
        }
        [Fact]
        public void RqRiskTest()
        {
            Type csharpType = typeof(Siren.Sea.rqRisk);
            Type fsharpType = typeof(Siren.rqRisk);
            Utils.CompareClasses(csharpType, fsharpType);
        }
        [Fact]
        public void RqMethodTest()
        {
            Type csharpType = typeof(Siren.Sea.rqMethod);
            Type fsharpType = typeof(Siren.rqMethod);
            Utils.CompareClasses(csharpType, fsharpType);
        }
    }
}
