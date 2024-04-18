module Tests.Journey

open Fable.Pyxpecto
open Siren

let main = testList "Journey" [
    testCase "complex" <| fun _ ->
        let Me, Cat = "Me", "Cat"
        let actual = 
            siren.journey [
                journey.title "My working day"
                journey.section "Go to work"
                journey.task("Make tea", 5, [Me])
                journey.task("Go upstairs", 3, [Me])
                journey.task("Do work", 1, [Me; Cat])
                journey.section "Go home"
                journey.task("Go downstairs", 5, [Me])
                journey.task("Sit down", 5, [Me])
            ]
            |> siren.write
        let expected = """journey
    title My working day
    section Go to work
    Make tea: 5: Me
    Go upstairs: 3: Me
    Do work: 1: Me, Cat
    section Go home
    Go downstairs: 5: Me
    Sit down: 5: Me
"""
        Expect.trimEqual actual expected ""
    testCase "no actors" <| fun _ ->
        let actual = 
            siren.journey [
                journey.title "My working day"
                journey.task("My house exists alone", 5)
            ]
            |> siren.write
        let expected = """journey
    title My working day
    My house exists alone: 5
"""
        Expect.trimEqual actual expected ""
]

