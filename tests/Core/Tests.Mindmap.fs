module Tests.Mindmap

open Fable.Pyxpecto
open Siren

let tests_docs = testList "docs" [
    testCase "example" <| fun _ ->
        let actual =
            siren.mindmap [
                mindmap.circleId("root","mindmap", [

                    mindmap.node("Origins", [
                        mindmap.node "Long history"
                        mindmap.icon "fa fa-book"
                        mindmap.node ("Popularisation", [
                            mindmap.node "British popular psychology author Tony Buzan"
                        ])
                    ])

                    mindmap.node("Research",[
                        mindmap.node "On effectiveness<br/>and features"
                        mindmap.node ("On Automatic creation", [
                            mindmap.node ("Uses", [
                                mindmap.node "Creative techniques"
                                mindmap.node "Strategic planning"
                                mindmap.node "Argument mapping"
                            ])
                        ])
                    ])

                    mindmap.node ("Tools",[
                        mindmap.node "Pen and paper"
                        mindmap.node "Mermaid"
                    ])
                ])
            ]
            |> siren.write
        let expected = """mindmap
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
        Expect.trimEqual actual expected ""
    testCase "markdown" <| fun _ ->
        let actual =
            siren.mindmap [
                mindmap.squareId(
                    "id1",
                    formatting.markdown """**Root** with
a second line
Unicode works too: 🤓""", [
                    mindmap.squareId("id2", formatting.markdown """The dog in **the** hog... a *very long text* that wraps to a new line""")
                ])
            ]
            |> siren.write
        let expected = """mindmap
    id1["`**Root** with
a second line
Unicode works too: 🤓`"]
        id2["`The dog in **the** hog... a *very long text* that wraps to a new line`"]
"""
        Expect.trimEqual actual expected ""
]

let main = testList "Mindmap" [
    tests_docs
]

