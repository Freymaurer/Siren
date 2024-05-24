import {siren, xyChart } from "./siren/index.js"
import * as assert from "assert"

describe('xychart', function(){
    it('Sales Revenue', function(){
        const actual = 
            siren.xyChart([
                xyChart.title("Sales Revenue"),
                xyChart.xAxis(["jan", "feb", "mar", "apr", "may", "jun", "jul", "aug", "sep", "oct", "nov", "dec"]),
                xyChart.yAxisNamedRange("Revenue (in $)", 4000, 11000),
                xyChart.bar([5000, 6000, 7500, 8200, 9500, 10500, 11000, 10200, 9200, 8500, 7000, 6000]),
                xyChart.line([5000, 6000, 7500, 8200, 9500, 10500, 11000, 10200, 9200, 8500, 7000, 6000])
            ]).write();
        const expected = `xychart-beta
    title "Sales Revenue"
    x-axis [jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec]
    y-axis "Revenue (in $)" 4000.000000 --> 11000.000000
    bar [5000, 6000, 7500, 8200, 9500, 10500, 11000, 10200, 9200, 8500, 7000, 6000]
    line [5000, 6000, 7500, 8200, 9500, 10500, 11000, 10200, 9200, 8500, 7000, 6000]
`
        assert.equal(actual,expected,"This should be equal")
    });
});