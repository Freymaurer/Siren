# Siren

# Examples 

## Flowchart

<!--Example1-->
```fsharp
diagram.flowchart.bt [
    subgraph.subgraph "space" [
        direction.bt
        link.dottedArrow(node.simple "earth", node.simple "moon", formatting.unicode "🚀", 6)
        node.round "moon" "moon"
        subgraph.subgraph "atmosphere" [
            node.circle "earth" "earth"
        ]
    ]
]
|> siren.write

```

```mermaid
flowchart BT
    subgraph space[space]
        direction BT
        earth[earth]-......->|"🚀"|moon[moon]
        moon(moon)
        subgraph atmosphere[atmosphere]
            earth((earth))
        end
    end
```
<!--Example1-End-->