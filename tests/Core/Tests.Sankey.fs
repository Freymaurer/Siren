module Tests.Sankey

open Fable.Pyxpecto
open Siren

let main = testList "Sankey" [
    let PumpedHeat = "Pumped heat"
    testCase "empty" <| fun _ ->
        let actual =
            siren.sankey [
            ]
            |> siren.write
        let expected = """sankey-beta
"""
        Expect.trimEqual actual expected ""
    testCase "bioconversion" <| fun _ ->
        let actual =
            siren.sankey [
                sankey.links("Bio-conversion", [
                    "Losses", 26.862
                    "Solid", 280.322
                    "Gas", 81.144
                ])
            ]
            |> siren.write
        let expected = """sankey-beta
"Bio-conversion","Losses",26.862000
"Bio-conversion","Solid",280.322000
"Bio-conversion","Gas",81.144000
"""
        Expect.trimEqual actual expected ""
    testCase "electricity" <| fun _ ->
        let actual =
            siren.sankey [
                sankey.link(PumpedHeat, "Heating and cooling, \"homes\"", 193.026)
                sankey.link(PumpedHeat, "Heating and cooling, \"commercial\"", 70.672)
            ]
            |> siren.write
        let expected = "sankey-beta
\"Pumped heat\",\"Heating and cooling, \"\"homes\"\"\",193.026000
\"Pumped heat\",\"Heating and cooling, \"\"commercial\"\"\",70.672000
"
        Expect.trimEqual actual expected ""
    testCase "electricity-links" <| fun _ ->
        let actual =
            siren.sankey [
                sankey.links(PumpedHeat, [
                    "Heating and cooling, \"homes\"", 193.026
                    "Heating and cooling, \"commercial\"", 70.672
                ])
            ]
            |> siren.write
        let expected = "sankey-beta
\"Pumped heat\",\"Heating and cooling, \"\"homes\"\"\",193.026000
\"Pumped heat\",\"Heating and cooling, \"\"commercial\"\"\",70.672000
"
        Expect.trimEqual actual expected ""
]

