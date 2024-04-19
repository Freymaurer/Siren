module Tests.Git

open Fable.Pyxpecto
open Siren

let main = testList "Git" [
    testCase "commits" <| fun _ ->
        let actual =
            siren.git [
                git.commit "Normal"
                git.commit ()
                git.commit ("Reverse", gitType.reverse)
                git.commit ()
                git.commit ("Highlight", gitType.highlight)
                git.commit ()
            ]
            |> siren.write
        let expected = """gitGraph
    commit id: "Normal"
    commit
    commit id: "Reverse" type: REVERSE
    commit
    commit id: "Highlight" type: HIGHLIGHT
    commit
"""
        Expect.trimEqual actual expected ""
    testCase "tags" <| fun _ ->
        let actual =
            siren.git [
                git.commit ()
                git.commit ("Normal",tag="v1.0.0")
                git.commit ()
                git.commit ("Reverse", gitType.reverse, "RC_1")
                git.commit ()
                git.commit ("Highlight", gitType.highlight, "8.8.4")
                git.commit ()
            ]
            |> siren.write
        let expected = """gitGraph
    commit
    commit id: "Normal" tag: "v1.0.0"
    commit
    commit id: "Reverse" type: REVERSE tag: "RC_1"
    commit
    commit id: "Highlight" type: HIGHLIGHT tag: "8.8.4"
    commit
"""
        Expect.trimEqual actual expected ""
    testCase "merge" <| fun _ ->
        let nice_feature, main, very_nice_feature = "nice_feature", "main", "very_nice_feature"
        let actual =
            siren.git [
                git.commit "1"
                git.commit "2"
                git.branch nice_feature
                git.commit "3"
                git.checkout main
                git.commit "4"
                git.checkout nice_feature
                git.branch very_nice_feature
                git.commit "5"
                git.checkout main
                git.commit "6"
                git.checkout nice_feature
                git.commit "7"
                git.checkout main
                git.merge(nice_feature,"customID",gitType.reverse,"customTag")
                git.checkout very_nice_feature
                git.commit "8"
                git.checkout main
                git.commit "9"

            ]
            |> siren.write
        let expected = """gitGraph
    commit id: "1"
    commit id: "2"
    branch nice_feature
    commit id: "3"
    checkout main
    commit id: "4"
    checkout nice_feature
    branch very_nice_feature
    commit id: "5"
    checkout main
    commit id: "6"
    checkout nice_feature
    commit id: "7"
    checkout main
    merge nice_feature id: "customID" type: REVERSE tag: "customTag"
    checkout very_nice_feature
    commit id: "8"
    checkout main
    commit id: "9"
"""
        Expect.trimEqual actual expected ""
    testCase "cherry-pick" <| fun _ ->
        let main, develop, release, B, MERGE = "main", "develop", "release", "B", "MERGE"
        let actual =
            siren.git [
                git.commit "ZERO"
                git.branch develop
                git.branch release
                git.commit "A"
                git.checkout main
                git.commit "ONE"
                git.checkout develop
                git.commit B
                git.checkout main
                git.merge (develop, MERGE)
                git.commit "TWO"
                git.checkout release
                git.cherryPick(MERGE,B)
                git.commit "THREE"
                git.checkout develop
                git.commit "C"
            ]
            |> siren.write
        let expected = """gitGraph
    commit id: "ZERO"
    branch develop
    branch release
    commit id: "A"
    checkout main
    commit id: "ONE"
    checkout develop
    commit id: "B"
    checkout main
    merge develop id: "MERGE"
    commit id: "TWO"
    checkout release
    cherry-pick id: "MERGE" parent: "B"
    commit id: "THREE"
    checkout develop
    commit id: "C"
"""
        Expect.trimEqual actual expected ""
]

