import {siren, sankey } from "./siren/index.js"
import * as assert from "assert"

describe('sankey', function(){
    it('bioconversion', function(){
        const actual = 
            siren.sankey([
                sankey.links("Bio-conversion", [
                    ["Losses", 26.862],
                    ["Solid", 280.322],
                    ["Gas", 81.144]
                ])
            ]).write();
        const expected = `sankey-beta
"Bio-conversion","Losses",26.862000
"Bio-conversion","Solid",280.322000
"Bio-conversion","Gas",81.144000
`
        assert.equal(actual,expected,"This should be equal")
    });
});