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
    public class DocsTests
    {
        [Fact]
        public void Workday()
        {
            (string Me, string Cat) = ("Me", "Cat");
            string actual = siren.journey([
                journey.title("My working day"),
                journey.section("Go to work"),
                journey.task("Make tea", 5, [Me]),
                journey.task("Go upstairs", 3, [Me]),
                journey.task("Do work", 1, [Me, Cat]),
                journey.section("Go home"),
                journey.task("Go downstairs", 5, [Me]),
                journey.task("Sit down", 5, [Me])
            ]).write();
            string expected = @"journey
    title My working day
    section Go to work
    Make tea: 5: Me
    Go upstairs: 3: Me
    Do work: 1: Me, Cat
    section Go home
    Go downstairs: 5: Me
    Sit down: 5: Me
";
            Assert.Equal(expected, actual);
        }
    }
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
