module Build.Examples.Flowchart

open Siren
open Util
    
let writeMoonRocketExample() =
    let key = "Example1"
    let codeDisplay = """diagram.flowchart(flowchartDirection.bt, [
    flowchart.subgraph ("space", [
        flowchart.directionBT
        flowchart.linkDottedArrow("earth", "moon", formatting.unicode "🚀", 6)
        flowchart.nodeRound "moon"
        flowchart.subgraph ("atmosphere", [
            flowchart.nodeCircle "earth"
        ])
    ])
])
|> siren.write
"""
    let mermaidMd = 
        siren.flowchart(direction.bt, [
            flowchart.subgraph ("space", [
                flowchart.directionBT
                flowchart.linkDottedArrow("earth", "moon", formatting.unicode "🚀", 6)
                flowchart.nodeRound "moon"
                flowchart.subgraph ("atmosphere", [
                    flowchart.nodeCircle "earth"
                ])
            ])
        ])
        |> siren.write
    let replacement = $"""
```fsharp
{codeDisplay}
```

```mermaid
{mermaidMd}
```
"""
    writeExample(key, replacement)