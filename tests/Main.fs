module Tests

open Fable.Pyxpecto
open Siren

let all = testList "Main" [
    testCase "init" <| fun _ ->
        Siren.Init.hello "World"
        Expect.pass()
]

[<EntryPoint>]
let main argv = Pyxpecto.runTests [||] all