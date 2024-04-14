module Tests.Line

open Fable.Pyxpecto
open Siren

let main = testList "Line" [
    testCase "subgraph" <| fun _ ->
        let graph = 
            subgraph.subgraph "Sub1" [
                node.simple "earth"
                line.raw "earth & saturn & mars -->|orbit| sun"
            ]
        let actual = Formatter.writeElementFast graph
        let expected = """subgraph Sub1
    earth[earth]
    earth & saturn & mars -->|orbit| sun
end
"""
        Expect.stringEqualF actual expected ""
]
