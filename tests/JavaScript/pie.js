import {siren, pieChart, pieConfig, pieTheme } from "./siren/index.js"
import * as assert from "assert"

describe('pie', function(){
    it('Product', function(){
        const actual = 
          siren.pieChart([
              pieChart.data("Calcium", 42.96),
              pieChart.data("Potassium", 50.05),
              pieChart.data("Magnesium", 10.01),
              pieChart.data("Iron", 5)
          ], true, "Key elements in Product X")
            .addGraphConfigVariable(pieConfig.textPosition(0.5))
            .addThemeVariable(pieTheme.pieOuterStrokeWidth("5px"))
            .write();
        const expected = `---
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
`
        assert.equal(actual,expected,"This should be equal")
    });
});