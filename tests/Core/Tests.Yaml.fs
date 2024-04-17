module Tests.Yaml

open Fable.Pyxpecto
open Siren

let main = testList "Yaml" [
    testCase "line" <| fun _ ->
        let ast = 
            Yaml.root [
                Yaml.line "flowchart TB"
                Yaml.level [
                    Yaml.line "c1-->a2"
                    Yaml.line "subgraph one"
                    Yaml.level [
                        Yaml.line "a1-->a2"
                    ]
                    Yaml.line "end"
                    Yaml.line "subgraph two"
                    Yaml.level [
                        Yaml.line "b1-->b2"
                    ]
                    Yaml.line "end"
                    Yaml.line "subgraph three"
                    Yaml.level [
                        Yaml.line "c1-->c2"
                    ]
                    Yaml.line "end"
                ]
            ]
        let actual = Yaml.write ast
        let expected = """flowchart TB
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
        Expect.equal actual expected ""
] 

