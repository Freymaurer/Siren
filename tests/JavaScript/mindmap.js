import {siren, mindmap, formatting } from "./siren/index.js"
import * as assert from "assert"

describe('mindmap', function(){
    it('Example', function(){
        const actual = 
            siren.mindmap([
                mindmap.circleId("root", "mindmap", [
            
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
            ]).write();
        const expected = `mindmap
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
`
        assert.equal(actual,expected,"This should be equal")
    });
    it('Markdown', function(){
      const actual = 
          siren.mindmap([
              mindmap.squareId(
                  "id1",
                  formatting.markdown(`**Root** with
a second line
Unicode works too: 🤓`), [
                  mindmap.squareId("id2", formatting.markdown("The dog in **the** hog... a *very long text* that wraps to a new line"))
              ])
          ]).write();
      const expected = `mindmap
    id1[\"\`**Root** with
a second line
Unicode works too: 🤓\`\"]
        id2[\"\`The dog in **the** hog... a *very long text* that wraps to a new line\`\"]
`
      assert.equal(actual,expected,"This should be equal")
  });
});