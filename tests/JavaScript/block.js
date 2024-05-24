import {siren, block } from "./siren/index.js"
import * as assert from "assert"

describe('block', function(){
    it('Introduction', function(){
        const actual = 
            siren.block([
              block.columns(1),
              block.blockCircle("db", "DB"),
              block.arrowDown("blockArrowId6"),
              block.cIdBlock("ID", [
                  block.block("A"),
                  block.block("B", "A wide one in the middle"),
                  block.block("C")
              ]),
              block.space,
              block.block("D"),
              block.link("ID", "D"),
              block.link("C", "D"),
              block.style("B", [
                  ["fill", "#939"],
                  ["stroke", "#333"],
                  ["stroke-width", "4px"]
              ])
          ]).write();
        const expected = `block-beta
    columns 1
    db(("DB"))
    blockArrowId6<["&nbsp;&nbsp;&nbsp;"]>(down)
    block:ID
        A["A"]
        B["A wide one in the middle"]
        C["C"]
    end
    space
    D["D"]
    ID-->D
    C-->D
    style B fill:#939,stroke:#333,stroke-width:4px;
`
        assert.equal(actual,expected,"This should be equal")
    });
    it('Services', function(){
        const [Frontend, Backend, Database] = ["Frontend", "Backend", "Database"];
        const actual = 
            siren.block([
                block.columns(3),
                block.line([
                  block.block(Frontend),
                  block.arrowRight("blockArrowId6", 1),
                  block.block(Backend)
                ]),
                block.line([
                  block.spacew(2),
                  block.arrowDown("down", 1)
                ]),
                block.line([
                  block.block("Disk"),
                  block.arrowLeft("left", 1),
                  block.blockCylindrical(Database)
                ]),
                block.classDef("front", [
                  ["fill", "#696"], 
                  ["stroke", "#333"]
                ]),
                block.classDef("back", [
                  ["fill", "#969"], 
                  ["stroke", "#333"]
                ]),
                block.class([Frontend], "front"),
                block.class([Backend, Database], "back")
            ]).write();
        const expected = `block-beta
    columns 3
    Frontend["Frontend"] blockArrowId6<["&nbsp;"]>(right) Backend["Backend"]
    space:2 down<["&nbsp;"]>(down)
    Disk["Disk"] left<["&nbsp;"]>(left) Database[("Database")]
    classDef front fill:#696,stroke:#333;
    classDef back fill:#969,stroke:#333;
    class Frontend front
    class Backend,Database back
`
        assert.equal(actual,expected,"This should be equal")
    });
    it('Services', function(){
      const actual = 
          siren.block([
            block.columns(3),
            block.line([
              block.blockCircle("Start"),
              block.spacew(2)
            ]),
            block.line([
              block.arrowDownLabeled("down", " "),
              block.spacew(2)
            ]),
            block.line([
              block.blockHexagon("Decision", "Make Decision"),
              block.arrowRightLabeled("right", "Yes"),
              block.block("Process1", "Process A")
            ]),
            block.line([
              block.arrowDownLabeled("downAgain", "No"),
              block.space,
              block.arrowDownLabeled("r3", "Done")
            ]),
            block.line([
              block.block("Process2", "Process B"),
              block.arrowRightLabeled("r2", "Done"),
              block.blockCircle("End")
            ]),
            block.style("Start", [["fill", "#969"]]),
            block.style("End", [["fill", "#696"]])
          ]).write();
      const expected = `block-beta
    columns 3
    Start(("Start")) space:2
    down<[" "]>(down) space:2
    Decision{{"Make Decision"}} right<["Yes"]>(right) Process1["Process A"]
    downAgain<["No"]>(down) space r3<["Done"]>(down)
    Process2["Process B"] r2<["Done"]>(right) End(("End"))
    style Start fill:#969;
    style End fill:#696;
`
      assert.equal(actual,expected,"This should be equal")
  });
});