﻿module Tests.RequirementDiagram

open Fable.Pyxpecto
open Siren

let main = testList "RequirementDiagram" [
    testCase "docs" <| fun _ ->
        let actual =
            siren.requirementDiagram [
                reqDia.requirement("test_req", "1", "the test text.", rqRisk.high, rqMethod.test)

                reqDia.functionalRequirement("test_req2", "1.1", "the second test text.", rqRisk.low, rqMethod.inspection)

                reqDia.performanceRequirement ("test_req3", "1.2", "the third test text.", rqRisk.medium, rqMethod.demonstration)

                reqDia.interfaceRequirement ("test_req4", "1.2.1", "the fourth test text.", rqRisk.medium, rqMethod.analysis)

                reqDia.physicalRequirement ("test_req5", "1.2.2", "the fifth test text.", rqRisk.medium, rqMethod.analysis)

                reqDia.designConstraint ("test_req6", "1.2.3", "the sixth test text.", rqRisk.medium, rqMethod.analysis)

                reqDia.element("test_entity", "simulation")
                reqDia.element("test_entity2", "word doc", "reqs/test_entity")
                reqDia.element("test_entity3", "test suite", "github.com/all_the_tests")

                reqDia.satisfies ("test_entity", "test_req2")
                reqDia.traces ("test_req", "test_req2")
                reqDia.contains ("test_req", "test_req3")
                reqDia.contains ("test_req3", "test_req4")
                reqDia.derives ("test_req4", "test_req5")
                reqDia.refines ("test_req5", "test_req6")
                reqDia.verifies ("test_entity3", "test_req5")
                reqDia.copies ("test_entity2", "test_req")
            ]
            |> siren.write
        let expected = """requirementDiagram
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
        Expect.trimEqual actual expected ""
]

