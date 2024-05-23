from siren.index import siren, mindmap, formatting

class TestMindmap:

  def test_example(self):
      actual = (
        siren.mindmap([
            mindmap.circle_id("root", "mindmap", [
        
                mindmap.node("Origins", [
                    mindmap.node ("Long history"),
                    mindmap.icon ("fa fa-book"),
                    mindmap.node ("Popularisation", [
                        mindmap.node("British popular psychology author Tony Buzan")
                    ])
                ]),
        
                mindmap.node("Research", [
                    mindmap.node ("On effectiveness<br/>and features"),
                    mindmap.node ("On Automatic creation", [
                        mindmap.node ("Uses", [
                            mindmap.node ("Creative techniques"),
                            mindmap.node ("Strategic planning"),
                            mindmap.node ("Argument mapping")
                        ])
                    ])
                ]),
        
                mindmap.node ("Tools", [
                    mindmap.node ("Pen and paper"),
                    mindmap.node ("Mermaid")
                ])
            ])
          ]).write()
      ) 
      expected = """mindmap
    root((mindmap))
        Origins
            Long history
            ::icon(fa fa-book)
            Popularisation
                British popular psychology author Tony Buzan
        Research
            On effectiveness<br/>and features
            On Automatic creation
                Uses
                    Creative techniques
                    Strategic planning
                    Argument mapping
        Tools
            Pen and paper
            Mermaid
"""
      assert actual == expected
  def test_example(self):
      actual = (
        siren.mindmap([
              mindmap.square_id(
                  "id1",
                  formatting.markdown("""**Root** with
a second line
Unicode works too: 🤓"""), [
                  mindmap.square_id("id2", formatting.markdown("The dog in **the** hog... a *very long text* that wraps to a new line"))
              ])
          ]).write()
      ) 
      expected = """mindmap
    id1["`**Root** with
a second line
Unicode works too: 🤓`"]
        id2["`The dog in **the** hog... a *very long text* that wraps to a new line`"]
"""
      assert actual == expected