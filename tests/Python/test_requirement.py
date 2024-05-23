from siren.index import siren, requirement, rq_method, rq_risk

class TestQuadrantChart:

  def test_engagement(self):
      actual = (
          siren.requirement([
              requirement.requirement("test_req", "1", "the test text.", rq_risk.high(), rq_method.test()),
          
              requirement.functional_requirement("test_req2", "1.1", "the second test text.", rq_risk.low(), rq_method.inspection()),
          
              requirement.performance_requirement("test_req3", "1.2", "the third test text.", rq_risk.medium(), rq_method.demonstration()),
          
              requirement.interface_requirement("test_req4", "1.2.1", "the fourth test text.", rq_risk.medium(), rq_method.analysis()),
          
              requirement.physical_requirement("test_req5", "1.2.2", "the fifth test text.", rq_risk.medium(), rq_method.analysis()),
          
              requirement.design_constraint("test_req6", "1.2.3", "the sixth test text.", rq_risk.medium(), rq_method.analysis()),
          
              requirement.element("test_entity", "simulation"),
              requirement.element("test_entity2", "word doc", "reqs/test_entity"),
              requirement.element("test_entity3", "test suite", "github.com/all_the_tests"),
          
              requirement.satisfies("test_entity", "test_req2"),
              requirement.traces("test_req", "test_req2"),
              requirement.contains("test_req", "test_req3"),
              requirement.contains("test_req3", "test_req4"),
              requirement.derives("test_req4", "test_req5"),
              requirement.refines("test_req5", "test_req6"),
              requirement.verifies("test_entity3", "test_req5"),
              requirement.copies("test_entity2", "test_req"),
          ]).write()
      ) 
      expected = """requirementDiagram
    requirement test_req {
        id: "1"
        text: "the test text."
        risk: high
        verifymethod: test
    }
    functionalRequirement test_req2 {
        id: "1.1"
        text: "the second test text."
        risk: low
        verifymethod: inspection
    }
    performanceRequirement test_req3 {
        id: "1.2"
        text: "the third test text."
        risk: medium
        verifymethod: demonstration
    }
    interfaceRequirement test_req4 {
        id: "1.2.1"
        text: "the fourth test text."
        risk: medium
        verifymethod: analysis
    }
    physicalRequirement test_req5 {
        id: "1.2.2"
        text: "the fifth test text."
        risk: medium
        verifymethod: analysis
    }
    designConstraint test_req6 {
        id: "1.2.3"
        text: "the sixth test text."
        risk: medium
        verifymethod: analysis
    }
    element test_entity {
        type: "simulation"
    }
    element test_entity2 {
        type: "word doc"
        docRef: "reqs/test_entity"
    }
    element test_entity3 {
        type: "test suite"
        docRef: "github.com/all_the_tests"
    }
    test_entity - satisfies -> test_req2
    test_req - traces -> test_req2
    test_req - contains -> test_req3
    test_req3 - contains -> test_req4
    test_req4 - derives -> test_req5
    test_req5 - refines -> test_req6
    test_entity3 - verifies -> test_req5
    test_entity2 - copies -> test_req
"""
      assert actual == expected