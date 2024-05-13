import {siren, flowchart, direction, formatting } from "./siren/index.js"
import * as assert from "assert"

describe('flowchart', function(){
  it('With Title', function(){
      const actual = 
        siren.flowchart(direction.lr, [
          flowchart.node("id1", "This is the text in the box")
        ]).withTitle("Node with text").write();
      const expected = `---
title: Node with text
---
flowchart LR
    id1[This is the text in the box]
`
      assert.equal(actual,expected,"This should be equal")
  });
  it('Different Length', function(){
    const actual = 
      siren.flowchart(direction.td, [
        flowchart.node("A", "Start"), 
        flowchart.nodeRhombus("B", "Is it?"), 
        flowchart.node("C", "OK"), 
        flowchart.node("D", "Rethink"), 
        flowchart.node("E", "End"), 
        flowchart.linkArrow("A", "B"), 
        flowchart.linkArrow("B", "C", "Yes"), 
        flowchart.linkArrow("C", "D"), 
        flowchart.linkArrow("D", "B"), 
        flowchart.linkArrow("B", "E", "No", 3)
      ]).write();
    const expected = `flowchart TD
    A[Start]
    B{Is it?}
    C[OK]
    D[Rethink]
    E[End]
    A-->B
    B-->|Yes|C
    C-->D
    D-->B
    B---->|No|E
`
    assert.equal(actual,expected,"This should be equal")
  });
  it('Subgraphs', function(){
    const actual = 
      siren.flowchart(direction.tb, [
        flowchart.linkArrow("c1", "a2"), 
        flowchart.subgraph("one", [flowchart.linkArrow("a1", "a2")]), 
        flowchart.subgraph("two", [flowchart.linkArrow("b1", "b2")]), 
        flowchart.subgraph("three", [flowchart.linkArrow("c1", "c2")])
      ]).write();
    const expected = `flowchart TB
    c1-->a2
    subgraph one
        a1-->a2
    end
    subgraph two
        b1-->b2
    end
    subgraph three
        c1-->c2
    end
`
    assert.equal(actual,expected,"This should be equal")
  });
  it('Subgraph Direction', function(){
    const actual = 
      siren.flowchart(direction.lr, [
        flowchart.subgraph("subgraph1", [
            flowchart.directionTB, 
            flowchart.node("top1"), 
            flowchart.node("bottom1"), 
            flowchart.linkArrow("top1", "bottom1")
        ]), 
        flowchart.subgraph("subgraph2", [
            flowchart.directionTB, 
            flowchart.node("top2"), 
            flowchart.node("bottom2"), 
            flowchart.linkArrow("top2", "bottom2")
        ]), 
        flowchart.linkArrow("outside", "subgraph1"), 
        flowchart.linkArrow("outside", "top2", null, 2)
      ]).write();
    const expected = `flowchart LR
    subgraph subgraph1
        direction TB
        top1[top1]
        bottom1[bottom1]
        top1-->bottom1
    end
    subgraph subgraph2
        direction TB
        top2[top2]
        bottom2[bottom2]
        top2-->bottom2
    end
    outside-->subgraph1
    outside--->top2
`
    assert.equal(actual,expected,"This should be equal")
  });
  it('Markdown string', function(){
    const actual = 
      siren.flowchart(direction.lr, [
        flowchart.subgraph("One", [
            flowchart.nodeRound("a", formatting.markdown(`The **cat**
in the hat`)), 
            flowchart.nodeRhombus("b", formatting.markdown("The **dog** in the hog")), 
            flowchart.linkArrow("a", "b", formatting.markdown("Bold **edge label**"))
        ])
      ]).write();
    const expected = `flowchart LR
    subgraph One
        a("\`The **cat**
in the hat\`")
        b{"\`The **dog** in the hog\`"}
        a-->|"\`Bold **edge label**\`"|b
    end
`
    assert.equal(actual,expected,"This should be equal")
  });
  it('Moon rocket', function(){
    const actual = 
      siren.flowchart(direction.bt, [
        flowchart.subgraph("space", [
            flowchart.directionBT, 
            flowchart.linkDottedArrow("earth", "moon", formatting.unicode("🚀"), 6), 
            flowchart.nodeRound("moon"), 
            flowchart.subgraph("atmosphere", [
                flowchart.nodeCircle("earth")
            ])
        ])
      ]).write();
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