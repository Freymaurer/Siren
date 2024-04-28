module Tests.Flowchart

open Fable.Pyxpecto
open Siren

let private writeYml (ele: FlowchartElement) = ele :> IYamlConvertible |> _.ToYamlAst() |> Yaml.root |> Yaml.write

let private tests_nodes = testList "nodes" [
    let id = "A"
    let name = "Hello World"

    testCase "simple" <| fun _ ->
        let actual = flowchart.id id |> writeYml
        let expected = "A"
        Expect.trimEqual actual expected ""
    testCase "node" <| fun _ ->
        let actual = flowchart.node (id, name) |> writeYml
        let expected = "A[Hello World]"
        Expect.trimEqual actual expected ""
    testCase "stadium" <| fun _ ->
        let actual = flowchart.nodeStadium (id, name) |> writeYml
        let expected = "A([Hello World])"
        Expect.trimEqual actual expected ""
    testCase "subroutine" <| fun _ ->
        let actual = flowchart.nodeSubroutine (id, name) |> writeYml
        let expected = "A[[Hello World]]"
        Expect.trimEqual actual expected ""
    testCase "cylindrical" <| fun _ ->
        let actual = flowchart.nodeCylindrical (id, name) |> writeYml
        let expected = "A[(Hello World)]"
        Expect.trimEqual actual expected ""
    testCase "circle" <| fun _ ->
        let actual = flowchart.nodeCircle (id, name) |> writeYml
        let expected = "A((Hello World))"
        Expect.trimEqual actual expected ""
    testCase "asymmetric" <| fun _ ->
        let actual = flowchart.nodeAsymmetric (id, name) |> writeYml
        let expected = "A>Hello World]"
        Expect.trimEqual actual expected ""
    testCase "rhombus" <| fun _ ->
        let actual = flowchart.nodeRhombus (id, name) |> writeYml
        let expected = "A{Hello World}"
        Expect.trimEqual actual expected ""
    testCase "hexagon " <| fun _ ->
        let actual = flowchart.nodeHexagon (id, name) |> writeYml
        let expected = "A{{Hello World}}"
        Expect.trimEqual actual expected ""
    testCase "parallelogram " <| fun _ ->
        let actual = flowchart.nodeParallelogram (id, name) |> writeYml
        let expected = "A[/Hello World/]"
        Expect.trimEqual actual expected ""
    testCase "parallelogram alt" <| fun _ ->
        let actual = flowchart.nodeParallelogramAlt (id, name) |> writeYml
        let expected = "A[\Hello World\]"
        Expect.trimEqual actual expected ""
    testCase "trapezoid" <| fun _ ->
        let actual = flowchart.nodeTrapezoid (id, name) |> writeYml
        let expected = "A[/Hello World\]"
        Expect.trimEqual actual expected ""
    testCase "trapezoid alt" <| fun _ ->
        let actual = flowchart.nodeTrapezoidAlt (id, name) |> writeYml
        let expected = "A[\Hello World/]"
        Expect.trimEqual actual expected ""
    testCase "double circle" <| fun _ ->
        let actual = flowchart.nodeDoubleCircle (id, name) |> writeYml
        let expected = "A(((Hello World)))"
        Expect.trimEqual actual expected ""
]

let private tests_comment = testList "Comment" [
    testList "String formatting" [
        testCase "simple" <| fun _ ->
            let actual = flowchart.comment "Lorem ipsum dolor sit amet, consetetur sadipscing elitr." |> writeYml
            let expected = "%% Lorem ipsum dolor sit amet, consetetur sadipscing elitr."
            Expect.trimEqual actual expected ""
    ]
]

let private tests_raw = testList "raw" [
    testCase "subgraph" <| fun _ ->
        let graph = 
            flowchart.subgraph ("Sub1", [
                flowchart.node "earth"
                flowchart.raw "earth & saturn & mars -->|orbit| sun"
            ])
        let actual = writeYml graph
        let expected = """subgraph Sub1
    earth[earth]
    earth & saturn & mars -->|orbit| sun
end"""
        Expect.trimEqual actual expected ""
]

let private tests_link = testList "link" [
    let n1 = "A[A]"
    let n2 = "B[B]"
    testCase "simple" <| fun _ ->
        let actual = flowchart.linkOpen (n1,n2) |> writeYml
        let expected = "A[A]---B[B]"
        Expect.trimEqual actual expected ""
    testCase "arrow" <| fun _ ->
        let actual = flowchart.linkArrow (n1,n2) |> writeYml
        let expected = "A[A]-->B[B]"
        Expect.trimEqual actual expected ""
    testCase "arrowDouble" <| fun _ ->
        let actual = flowchart.linkArrowDouble (n1,n2) |> writeYml
        let expected = "A[A]<-->B[B]"
        Expect.trimEqual actual expected ""
    testCase "dotted" <| fun _ ->
        let actual = flowchart.linkDotted (n1,n2) |> writeYml
        let expected = "A[A]-.-B[B]"
        Expect.trimEqual actual expected ""
    testCase "dottedArrow" <| fun _ ->
        let actual = flowchart.linkDottedArrow (n1,n2) |> writeYml
        let expected = "A[A]-.->B[B]"
        Expect.trimEqual actual expected ""
    testCase "thick" <| fun _ ->
        let actual = flowchart.linkThick(n1,n2) |> writeYml
        let expected = "A[A]===B[B]"
        Expect.trimEqual actual expected ""
    testCase "thickArrow" <| fun _ ->
        let actual = flowchart.linkThickArrow(n1,n2) |> writeYml
        let expected = "A[A]==>B[B]"
        Expect.trimEqual actual expected ""
    testCase "invisible" <| fun _ ->
        let actual = flowchart.linkInvisible(n1,n2) |> writeYml
        let expected = "A[A]~~~B[B]"
        Expect.trimEqual actual expected ""
    testCase "circle edge" <| fun _ ->
        let actual = flowchart.linkCircleEdge(n1,n2) |> writeYml
        let expected = "A[A]--oB[B]"
        Expect.trimEqual actual expected ""
    testCase "circle double" <| fun _ ->
        let actual = flowchart.linkCircleDouble(n1,n2) |> writeYml
        let expected = "A[A]o--oB[B]"
        Expect.trimEqual actual expected ""
    testCase "cross edge" <| fun _ ->
        let actual = flowchart.linkCrossEdge(n1,n2) |> writeYml
        let expected = "A[A]--xB[B]"
        Expect.trimEqual actual expected ""
    testCase "cross double" <| fun _ ->
        let actual = flowchart.linkCrossDouble(n1,n2) |> writeYml
        let expected = "A[A]x--xB[B]"
        Expect.trimEqual actual expected ""
]

let private tests_subgraph = testList "subgraph" [
    
    testCase "empty" <| fun _ -> 
        let actual = flowchart.subgraph ("sub1", []) |> writeYml
        let expected = """subgraph sub1
end
"""
        Expect.trimEqual actual expected ""

    testCase "nodes" <| fun _ -> 
        let actual = 
            flowchart.subgraph ("sub1", [
                flowchart.node "Space"
                flowchart.nodeRound "Earth"
                flowchart.linkDotted("Earth", "Space", "Satellite", 10)
            ])
            |> writeYml
        let expected = """subgraph sub1
    Space[Space]
    Earth(Earth)
    Earth-..........-|Satellite|Space
end
"""
        Expect.trimEqual actual expected ""     

    testCase "nested" <| fun _ -> 
        let actual = 
            flowchart.subgraph ("space", [
                flowchart.nodeRound "moon"
                flowchart.subgraph ("atmosphere", [
                    flowchart.nodeCircle "earth"
                ])
                flowchart.linkDottedArrow("earth", "moon", formatting.unicode "rocket 🚀", 6)
            ])
            |> writeYml
        let expected = """subgraph space
    moon(moon)
    subgraph atmosphere
        earth((earth))
    end
    earth-......->|"rocket 🚀"|moon
end
"""
        Expect.trimEqual actual expected ""
]


let private tests_formatter = testList "formatter" [
    testCase "empty" <| fun _ ->
        let actual =
            siren.flowchart (direction.bt, [
        
            ])
            |> siren.write

        let expected = """flowchart BT
"""
        Expect.trimEqual actual expected ""

    testCase "small" <| fun _ ->
        let actual =
            siren.flowchart(direction.bt, [
                flowchart.subgraph ("space", [
                    flowchart.directionBT
                    flowchart.linkDottedArrow("earth", "moon", formatting.unicode "🚀", 6)
                    flowchart.nodeRound "moon"
                    flowchart.subgraph ("atmosphere", [
                        flowchart.nodeCircle "earth"
                    ])
                ])
            ])
            |> siren.write

        let expected = """flowchart BT
    subgraph space
        direction BT
        earth-......->|"🚀"|moon
        moon(moon)
        subgraph atmosphere
            earth((earth))
        end
    end
"""
        Expect.trimEqual actual expected ""
]

let main = testList "Flowchart" [
    tests_nodes
    tests_raw
    tests_comment
    tests_link
    tests_subgraph
    tests_formatter
]

