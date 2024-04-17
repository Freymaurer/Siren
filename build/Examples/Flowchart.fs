module Build.Examples.Flowchart

open Siren
open Util
    
//let writeMoonRocketExample() =
//    let key = "Example1"
//    let codeDisplay = """diagram.flowchart.bt [
//    subgraph.subgraph "space" [
//        direction.bt
//        link.dottedArrow(node.simple "earth", node.simple "moon", formatting.unicode "🚀", 6)
//        node.round "moon" "moon"
//        subgraph.subgraph "atmosphere" [
//            node.circle "earth" "earth"
//        ]
//    ]
//]
//|> siren.write
//"""
//    let mermaidMd = 
//        diagram.flowchart.bt [
//            subgraph.subgraph "space" [
//                direction.bt
//                link.dottedArrow(node.simple "earth", node.simple "moon", formatting.unicode "🚀", 6)
//                node.round "moon" "moon"
//                subgraph.subgraph "atmosphere" [
//                    node.circle "earth" "earth"
//                ]
//            ]
//        ]
//        |> siren.write
//    let replacement = $"""
//```fsharp
//{codeDisplay}
//```

//```mermaid
//{mermaidMd}
//```
//"""
//    writeExample(key, replacement)