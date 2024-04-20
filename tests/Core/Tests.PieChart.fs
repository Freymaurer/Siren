module Tests.PieChart

open Fable.Pyxpecto
open Siren

let main = testList "PieChart" [
    testCase "docs" <| fun _ ->
        let actual =
            siren.pieChart ([
                pieChart.data("Calcium", 42.96)
                pieChart.data("Potassium", 50.05)
                pieChart.data("Magnesium", 10.01)
                pieChart.data("Iron", 5)
            ], true, "Key elements in Product X")
            |> siren.write
        let expected = """pie showData title Key elements in Product X
    "Calcium" : 42.96
    "Potassium" : 50.05
    "Magnesium" : 10.01
    "Iron" : 5
"""
        Expect.trimEqual actual expected ""
]

