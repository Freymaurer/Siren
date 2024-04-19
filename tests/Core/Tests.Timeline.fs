module Tests.Timeline

open Fable.Pyxpecto
open Siren

let main = testList "Timeline" [
    testCase "social-media" <| fun _ ->
        let actual =
            siren.timeline [
                timeline.title "History of Social Media Platform"
                timeline.single("2002", "LinkedIn")
                timeline.period("2003")
                timeline.multiple("2004", ["Facebook"; "Google"])
                timeline.single("2005", "Youtube")
                timeline.single("2006", "Twitter")
            ]
            |> siren.write
        let expected = """timeline
    title History of Social Media Platform
    2002 : LinkedIn
    2003
    2004
        : Facebook
        : Google
    2005 : Youtube
    2006 : Twitter
"""
        Expect.trimEqual actual expected ""
    testCase "docs" <| fun _ ->
        let actual =
            siren.timeline [
                timeline.title "MermaidChart 2023 Timeline"
                timeline.section("2023 Q1 <br> Release Personal Tier", [
                    timeline.multiple("Bullet 1", [
                        "sub-point 1a"
                        "sub-point 1b"
                        "sub-point 1c"
                    ])
                    timeline.multiple("Bullet 2", [
                        "sub-point 2a"
                        "sub-point 2b"
                    ])
                ])
                timeline.section("2023 Q2 <br> Release XYZ Tier", [
                    timeline.multiple("Bullet 3", [
                        "sub-point 3a"
                        "sub-point 3b"
                        "sub-point 3c"
                    ])
                    timeline.multiple("Bullet 4", [
                        "sub-point 4a"
                        "sub-point 4b"
                    ])
                ])
            ]
            |> siren.write
        let expected = """timeline
    title MermaidChart 2023 Timeline
    section 2023 Q1 <br> Release Personal Tier
        Bullet 1
            : sub-point 1a
            : sub-point 1b
            : sub-point 1c
        Bullet 2
            : sub-point 2a
            : sub-point 2b
    section 2023 Q2 <br> Release XYZ Tier
        Bullet 3
            : sub-point 3a
            : sub-point 3b
            : sub-point 3c
        Bullet 4
            : sub-point 4a
            : sub-point 4b
"""
        Expect.trimEqual actual expected ""
]

