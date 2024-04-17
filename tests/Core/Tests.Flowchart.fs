module Tests.Flowchart

open Fable.Pyxpecto
open Siren

let private tests_formatter = testList "formatter" [
    testCase "empty" <| fun _ ->
        let actual =
            diagram.flowchart (flowchartDirection.bt, [
        
            ])
            |> siren.write

        let expected = """flowchart BT
"""
        Expect.stringEqualF actual expected ""

    testCase "small" <| fun _ ->
        let actual =
            diagram.flowchart(flowchartDirection.bt, [
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
        Expect.stringEqualF actual expected ""
]

let main = testList "Flowchart" [
    tests_formatter
]

