module Main

open Fable.Pyxpecto
open Siren

let all = testList "Main" [
    Tests.Comment.main
    Tests.Line.main
    Tests.Node.main
    Tests.Connection.main
    Tests.Subgraph.main
    Tests.Flowchart.main
    Tests.SequenceDiagram.main
]

[<EntryPoint>]
let main argv = Pyxpecto.runTests (ConfigArg.fromStrings argv) all