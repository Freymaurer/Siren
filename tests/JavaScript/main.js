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
          siren.diagram.flowchart.bt([
              siren.subgraph.subgraph("space",[
                  siren.direction.bt,
                  siren.link.dottedArrow(
                    siren.node.simple("earth"), 
                    siren.node.simple("moon"), 
                    siren.formatting.unicode("🚀"),
                    6
                  ),
                  siren.node.round("moon", "moon"),
                  siren.subgraph.subgraph("atmosphere",[
                    siren.node.circle("earth", "earth")
                  ])
              ])
          ]);
        const actual = siren.siren.write(e);
        const expected = `flowchart BT
    subgraph space[space]
        direction BT
        earth[earth]-......->|"🚀"|moon[moon]
        moon(moon)
        subgraph atmosphere[atmosphere]
            earth((earth))
        end
    end
`
        assert.equal(actual,expected,"This should be equal")
    });
}); 