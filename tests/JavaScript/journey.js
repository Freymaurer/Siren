import {siren, journey } from "./siren/index.js"
import * as assert from "assert"

describe('journey', function(){
    it('Workday', function(){
        const [Me, Cat] = ["Me", "Cat"];
        const actual = 
          siren.journey([
              journey.title("My working day"),
              journey.section("Go to work"),
              journey.task("Make tea", 5, [Me]),
              journey.task("Go upstairs", 3, [Me]),
              journey.task("Do work", 1, [Me, Cat]),
              journey.section("Go home"),
              journey.task("Go downstairs", 5, [Me]),
              journey.task("Sit down", 5, [Me])
          ]).write();
        const expected = `journey
    title My working day
    section Go to work
    Make tea: 5: Me
    Go upstairs: 3: Me
    Do work: 1: Me, Cat
    section Go home
    Go downstairs: 5: Me
    Sit down: 5: Me
`
        assert.equal(actual,expected,"This should be equal")
    });
});