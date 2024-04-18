module Main

open Fable.Pyxpecto
open Siren

let all = testList "Main" [
    Tests.Yaml.main
    Tests.Flowchart.main
    Tests.SequenceDiagram.main
    Tests.ClassDiagram.main
    Tests.StateDiagram.main
    Tests.EntityRelationshipDiagram.main
    Tests.Journey.main
    Tests.Gantt.main
    Tests.PieChart.main
    Tests.Quadrant.main
]

[<EntryPoint>]
let main argv = Pyxpecto.runTests (ConfigArg.fromStrings argv) all