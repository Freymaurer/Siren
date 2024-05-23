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
    public class DocsTests
    {
        [Fact]
        public void LargeExample()
        {
            string actual =
                siren.requirement([
                    Requirement.requirement("test_req", "1", "the test text.", rqRisk.high, rqMethod.test),

                    Requirement.functionalRequirement("test_req2", "1.1", "the second test text.", rqRisk.low, rqMethod.inspection),

                    Requirement.performanceRequirement("test_req3", "1.2", "the third test text.", rqRisk.medium, rqMethod.demonstration),

                    Requirement.interfaceRequirement("test_req4", "1.2.1", "the fourth test text.", rqRisk.medium, rqMethod.analysis),

                    Requirement.physicalRequirement("test_req5", "1.2.2", "the fifth test text.", rqRisk.medium, rqMethod.analysis),

                    Requirement.designConstraint("test_req6", "1.2.3", "the sixth test text.", rqRisk.medium, rqMethod.analysis),

                    Requirement.element("test_entity", "simulation"),
                    Requirement.element("test_entity2", "word doc", "reqs/test_entity"),
                    Requirement.element("test_entity3", "test suite", "github.com/all_the_tests"),

                    Requirement.satisfies("test_entity", "test_req2"),
                    Requirement.traces("test_req", "test_req2"),
                    Requirement.contains("test_req", "test_req3"),
                    Requirement.contains("test_req3", "test_req4"),
                    Requirement.derives("test_req4", "test_req5"),
                    Requirement.refines("test_req5", "test_req6"),
                    Requirement.verifies("test_entity3", "test_req5"),
                    Requirement.copies("test_entity2", "test_req"),
                ]).write();
            string expected = @"requirementDiagram
    requirement test_req {
        id: ""1""
        text: ""the test text.""
        risk: high
        verifymethod: test
    }
    functionalRequirement test_req2 {
        id: ""1.1""
        text: ""the second test text.""
        risk: low
        verifymethod: inspection
    }
    performanceRequirement test_req3 {
        id: ""1.2""
        text: ""the third test text.""
        risk: medium
        verifymethod: demonstration
    }
    interfaceRequirement test_req4 {
        id: ""1.2.1""
        text: ""the fourth test text.""
        risk: medium
        verifymethod: analysis
    }
    physicalRequirement test_req5 {
        id: ""1.2.2""
        text: ""the fifth test text.""
        risk: medium
        verifymethod: analysis
    }
    designConstraint test_req6 {
        id: ""1.2.3""
        text: ""the sixth test text.""
        risk: medium
        verifymethod: analysis
    }
    element test_entity {
        type: ""simulation""
    }
    element test_entity2 {
        type: ""word doc""
        docRef: ""reqs/test_entity""
    }
    element test_entity3 {
        type: ""test suite""
        docRef: ""github.com/all_the_tests""
    }
    test_entity - satisfies -> test_req2
    test_req - traces -> test_req2
    test_req - contains -> test_req3
    test_req3 - contains -> test_req4
    test_req4 - derives -> test_req5
    test_req5 - refines -> test_req6
    test_entity3 - verifies -> test_req5
    test_entity2 - copies -> test_req
";
            Assert.Equal(expected, actual);
        }
    }
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
