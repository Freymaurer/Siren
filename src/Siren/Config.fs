namespace Siren

open Fable.Core

// official docs: https://mermaid.js.org/config/schema-docs/config.html


[<AttachMembers>]
type flowchartConfig =
    static member custom (key, value) = key, value
    /// Default: "dagre-wrapper"
    static member defaultRenderer (renderer: string) = "defaultRenderer", renderer
    static member defaultRendererElk = "defaultRenderer", "elk"
    static member defaultRendererDagreD3 = "defaultRenderer", "dagre-d3"
    static member defaultRendererDagreWrapper = "defaultRenderer", "dagre-wrapper"
    /// Default: 25
    static member titleTopMargin(px:int) = "titleTopMargin", string px
    /// Default: {"top": 0, "bottom": 0 }
    static member subGraphTitleMargin(top: int, bottom: int) = "subGraphTitleMargin", sprintf "{\"top\": %i, \"bottom\": %i}" top bottom
    static member arrowMarkerAbsolute(b: bool) = "arrowMarkerAbsolute", string b
    /// Default: 20
    static member diagramPadding(px: int) = "diagramPadding", string px
    /// Default: true
    static member htmlLabels(b: bool) = "htmlLabels", string b
    /// Default: 50
    static member nodeSpacing(px: int) = "nodeSpacing", string px
    /// Default: 50
    static member rankSpacing(px: int) = "rankSpacing", string px
    /// Default: "basis"
    static member curve(name: string) = "curve", name
    static member curveBasis = "curve", "basis"
    static member curveLinear = "curve", "linear"
    static member curveCardianal = "curve", "cardinal"
    /// Default: 15
    static member padding(px: int) = "padding", string px
    /// Default: 200
    static member wrappingWidth(px: int) = "wrappingWidth", string px

[<AttachMembers>]
type sequenceConfig =
    static member custom (key, value) = key, value
    static member arrowMarkerAbsolute (b: bool) = "arrowMarkerAbsolute", string b
