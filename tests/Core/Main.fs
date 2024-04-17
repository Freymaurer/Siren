﻿module Main

open Fable.Pyxpecto
open Siren

let all = testList "Main" [
    Tests.Yaml.main
    Tests.Flowchart.main
    Tests.SequenceDiagram.main
]

[<EntryPoint>]
let main argv = Pyxpecto.runTests (ConfigArg.fromStrings argv) all