module Tests.PieChart

open Fable.Pyxpecto
open Siren

let tests_docs = testList "docs" [
    testCase "Product" <| fun _ ->
        let actual =
            siren.pieChart ([
                pieChart.data("Calcium", 42.96)
                pieChart.data("Potassium", 50.05)
                pieChart.data("Magnesium", 10.01)
                pieChart.data("Iron", 5)
            ], true, "Key elements in Product X")
            |> siren.addGraphConfigVariable(pieConfig.textPosition 0.5)
            |> siren.addThemeVariable(pieTheme.pieOuterStrokeWidth "5px")
            |> siren.write
        let expected = """---
config:
    pie:
        textPosition: 0.5
    themeVariables:
        pieOuterStrokeWidth: 5px
---
pie showData title Key elements in Product X
    "Calcium" : 42.96
    "Potassium" : 50.05
    "Magnesium" : 10.01
    "Iron" : 5
"""
        Expect.trimEqual actual expected ""
]

let main = testList "PieChart" [
    tests_docs
]