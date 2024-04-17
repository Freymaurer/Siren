module Main

open Fable.Pyxpecto
open Siren

let all = testList "Main" [
    Tests.Yaml.main
    //Tests.Comment.main
    //Tests.Line.main
    //Tests.Node.main
    //Tests.Connection.main
    //Tests.Subgraph.main
    Tests.Flowchart.main
    //Tests.SequenceDiagram.main
    testCase "ensure" <| fun _ ->
        Expect.equal 1 1 "Hello"
]

[<EntryPoint>]
let main argv = Pyxpecto.runTests (ConfigArg.fromStrings argv) all