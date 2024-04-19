import * as siren from "./siren/Siren.js"
import * as assert from "assert"

describe('ensure testing', function () {
    it('should return -1 when the value is not present', function () {
      assert.equal([1, 2, 3].indexOf(4), -1);
    });
});


describe('syntax', function(){
    it('MoonRocketExample', function(){
        const e = 
          siren.diagram.flowchart(siren.flowchartDirection.bt, [
              siren.flowchart.subgraph("space",[
                  siren.flowchart.directionBT,
                  siren.flowchart.linkDottedArrow(
                    "earth", 
                    "moon", 
                    siren.formatting.unicode("🚀"),
                    6
                  ),
                  siren.flowchart.nodeRound("moon"),
                  siren.flowchart.subgraph("atmosphere",[
                    siren.flowchart.nodeCircle("earth")
                  ])
              ])
          ]);
        const actual = siren.siren.write(e);
        const expected = `flowchart BT
    subgraph space
        direction BT
        earth-......->|"🚀"|moon
        moon(moon)
        subgraph atmosphere
            earth((earth))
        end
    end
`
        assert.equal(actual,expected,"This should be equal")
    });
}); 