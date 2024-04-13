module Tests.Subgraph

open Fable.Pyxpecto
open Siren


let private tests_formatter = testList "formatter" [
    
    testCase "empty" <| fun _ -> 
        let actual = subgraph.subgraph "sub1" [] |> Formatter.writeElementFast
        let expected = """subgraph sub1[sub1]
end
"""
        Expect.stringEqualF actual expected ""

    testCase "nodes" <| fun _ -> 
        let actual = 
            subgraph.subgraph "sub1" [
                let space = node.simple "Space"
                let earth = node.round "Earth" "Earth"
                link.dotted(earth, space, "Satellite", 10)
                space --> earth
                earth --> node.simple "Moon"
            ] 
            |> Formatter.writeElementFast
        let expected = """subgraph sub1[sub1]
    Earth(Earth)-..........-|Satellite|Space[Space]
    Space[Space]-->Earth(Earth)
    Earth(Earth)-->Moon[Moon]
end
"""
        Expect.stringEqualF actual expected ""     

    testCase "nested" <| fun _ -> 
        let actual = 
            subgraph.subgraph "space" [
                node.round "moon" "moon"
                subgraph.subgraph "atmosphere" [
                    node.circle "earth" "earth"
                ]
                link.dottedArrow(node.simple "earth", node.simple "moon", formatting.unicode "rocket 🚀", 6)
            ] 
            |> Formatter.writeElementFast
        let expected = """subgraph space[space]
    moon(moon)
    subgraph atmosphere[atmosphere]
        earth((earth))
    end
    earth[earth]-......->|"rocket 🚀"|moon[moon]
end
"""
        Expect.stringEqualF actual expected ""
]

let main = testList "Subgraph" [
    tests_formatter
]

