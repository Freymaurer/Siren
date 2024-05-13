from siren.index import siren, flowchart, direction, formatting

class TestFlowchart:

  def test_with_title(self):
      actual = siren.flowchart(direction.lr(), [
            flowchart.node("id1", "This is the text in the box")
        ]).with_title("Node with text").write()
      expected = """---
title: Node with text
---
flowchart LR
    id1[This is the text in the box]
"""
      assert actual == expected
  def test_different_length(self):
      actual = siren.flowchart(direction.td(), [
        flowchart.node("A", "Start"), 
        flowchart.node_rhombus("B", "Is it?"), 
        flowchart.node("C", "OK"), 
        flowchart.node("D", "Rethink"), 
        flowchart.node("E", "End"), 
        flowchart.link_arrow("A", "B"), 
        flowchart.link_arrow("B", "C", "Yes"), 
        flowchart.link_arrow("C", "D"), 
        flowchart.link_arrow("D", "B"), 
        flowchart.link_arrow("B", "E", "No", 3)
      ]).write()
      expected = """flowchart TD
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
"""
      assert actual == expected
  def test_subgraphs(self):
      actual = siren.flowchart(direction.tb(), [
          flowchart.link_arrow("c1", "a2"), 
          flowchart.subgraph("one", [flowchart.link_arrow("a1", "a2")]), 
          flowchart.subgraph("two", [flowchart.link_arrow("b1", "b2")]), 
          flowchart.subgraph("three", [flowchart.link_arrow("c1", "c2")])
        ]).write()
      expected = """flowchart TB
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
"""
      assert actual == expected
  def test_subgraph_direction(self):
      actual = siren.flowchart(direction.lr(), [
          flowchart.subgraph("subgraph1", [
              flowchart.direction_tb(), 
              flowchart.node("top1"), 
              flowchart.node("bottom1"), 
              flowchart.link_arrow("top1", "bottom1")
          ]), 
          flowchart.subgraph("subgraph2", [
              flowchart.direction_tb(), 
              flowchart.node("top2"), 
              flowchart.node("bottom2"), 
              flowchart.link_arrow("top2", "bottom2")
          ]), 
          flowchart.link_arrow("outside", "subgraph1"), 
          flowchart.link_arrow("outside", "top2", None, 2)
        ]).write()
      expected = """flowchart LR
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
"""
      assert actual == expected
  def test_markdown_string(self):
      actual = siren.flowchart(direction.lr(), [
          flowchart.subgraph("One", [
              flowchart.node_round("a", formatting.markdown("""The **cat**
in the hat""")), 
              flowchart.node_rhombus("b", formatting.markdown("The **dog** in the hog")), 
              flowchart.link_arrow("a", "b", formatting.markdown("Bold **edge label**"))
          ])
        ]).write()
      expected = """flowchart LR
    subgraph One
        a("`The **cat**
in the hat`")
        b{"`The **dog** in the hog`"}
        a-->|"`Bold **edge label**`"|b
    end
"""
      assert actual == expected
  def test_moon_rocket(self):
      actual = siren.flowchart(direction.bt(), [
          flowchart.subgraph("space", [
              flowchart.direction_bt(), 
              flowchart.link_dotted_arrow("earth", "moon", formatting.unicode("🚀"), 6), 
              flowchart.node_round("moon"), 
              flowchart.subgraph("atmosphere", [
                  flowchart.node_circle("earth")
              ])
          ])
        ]).write()
      expected = """flowchart BT
    subgraph space
        direction BT
        earth-......->|"🚀"|moon
        moon(moon)
        subgraph atmosphere
            earth((earth))
        end
    end
"""
      assert actual == expected


  
  
