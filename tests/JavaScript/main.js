import {siren, flowchart, direction, formatting } from "./siren/index.js"
import * as assert from "assert"

describe('ensure testing', function () {
    it('should return -1 when the value is not present', function () {
      assert.equal([1, 2, 3].indexOf(4), -1);
    });
});


describe('syntax', function(){
    it('MoonRocketExample', function(){
        const e = 
          siren.flowchart(direction.bt, [
              flowchart.subgraph("space",[
                  flowchart.directionBT,
                  flowchart.linkDottedArrow(
                    "earth", 
                    "moon", 
                    formatting.unicode("🚀"),
                    6
                  ),
                  flowchart.nodeRound("moon"),
                  flowchart.subgraph("atmosphere",[
                    flowchart.nodeCircle("earth")
                  ])
              ])
          ]);
        const actual = siren.write(e);
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