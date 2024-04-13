module Tests.Flowchart

open Fable.Pyxpecto
open Siren

let private tests_formatter = testList "formatter" [
    testCase "empty" <| fun _ ->
        let actual =
            diagram.flowchart.bt [
        
            ]
            |> Formatter.writeElementFast

        let expected = """flowchart BT
"""
        Expect.stringEqualF actual expected ""

    testCase "small" <| fun _ ->
        let actual =
            diagram.flowchart.bt [
                subgraph.subgraph "space" [
                    direction.bt
                    link.dottedArrow(node.simple "earth", node.simple "moon", formatting.unicode "🚀", 6)
                    node.round "moon" "moon"
                    subgraph.subgraph "atmosphere" [
                        node.circle "earth" "earth"
                    ]
                ]
            ]
            |> siren.write

        let expected = """flowchart BT
    subgraph space[space]
        direction BT
        earth[earth]-......->|"🚀"|moon[moon]
        moon(moon)
        subgraph atmosphere[atmosphere]
            earth((earth))
        end
    end
"""
        Expect.stringEqualF actual expected ""
]

let main = testList "Flowchart" [
    tests_formatter
]

