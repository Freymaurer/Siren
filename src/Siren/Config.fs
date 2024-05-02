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
    static member hideUnusedParticipants (b: bool) = "hideUnusedParticipants", string b
    /// Default: 10
    static member activationWidth (px: int) = "activationWidth", string px
    /// Default: 50
    static member diagramMarginX (px: int) = "diagramMarginX", string px
    /// Default: 10
    static member diagramMarginY (px: int) = "diagramMarginX", string px
    /// Default: 50
    static member actorMargin (px: int) = "actorMargin", string px
    /// Default: 150
    static member width (px: int) = "width", string px
    /// Default: 50
    static member height (px: int) = "height", string px
    /// Default: 10
    static member boxMargin (px: int) = "boxMargin", string px
    /// Default: 5
    static member boxTextMargin (px: int) = "boxTextMargin", string px
    /// Default: 10
    static member noteMargin (px: int) = "noteMargin", string px
    /// Default: 35
    // static member messageMargin (px: int) = "messageMargin", string px //Did not work
    /// Default: center
    static member messageAlign (name: string)   = "messageAlign", name
    static member messageAlignLeft              = "messageAlign", "left"
    static member messageAligncCenter           = "messageAlign", "center"
    static member messageAlignRight             = "messageAlign", "right"
    /// Default: true
    static member mirrorActors (b:bool) = "mirrorActors", string b
    // static member forceMenus (b:bool) = "forceMenus", string b //Did not work
    /// Default: 1 
    static member bottomMarginAdj (px: int) = "bottomMarginAdj", string px
    //static member rightAngles (b: bool) = "rightAngles", string b //Did not work
    static member showSequenceNumbers (b: bool) = "showSequenceNumbers", string b
    /// Default: "14"
    static member actorFontSize (s: string) = "actorFontSize", s //TODO: Multiple types
    /// Default: "\"Open Sans\", sans-serif"
    //static member actorFontFamily (s:string) = "actorFontFamily", s //Did not work
    /// Default: "400"
    static member actorFontWeight (s:string) = "actorFontWeight", s //TODO: Multiple types
    /// Default: "14"
    static member noteFontSize (s:string) = "noteFontSize", s //TODO: Multiple types
    /// Default: "\"trebuchet ms\", verdana, arial, sans-serif"
    //static member noteFontFamily (s:string) = "noteFontFamily", s //Did not work
    /// Default: "400"
    static member noteFontWeight (s:string) = "noteFontWeight", s //TODO: Multiple types
    /// Default: "center"
    static member noteAlign (s:string)  = "noteAlign", s
    static member noteAlignLeft         = "noteAlign", "left"
    static member noteAlignCenter       = "noteAlign", "center"
    static member noteAlignRight        = "noteAlign", "right"
    /// Default: "16"
    static member messageFontSize (s:string) = "messageFontSize", s //TODO: Multiple types
    /// Default: "\"trebuchet ms\", verdana, arial, sans-serif"
    // static member messageFontFamily (s:string) = "messageFontFamily", s //TODO: Multiple types
    /// Default: "400"
    static member messageFontWeight (s:string) = "messageFontWeight", s //TODO: Multiple types
    static member wrap (b: bool) = "wrap", string b
    /// Default: 10
    static member wrapPadding (px: int) = "wrapPadding", string px
    /// Default: 50
    //static member labelBoxWidth (px: int) = "labelBoxWidth", string px //Did not work
    /// Default: 20
    //static member labelBoxHeight (px: int) = "labelBoxHeight", string px //Did not work
    //TO DO: messageFont JavaScript function that returns a FontConfig. By default, these return the appropriate *FontSize, *FontFamily, *FontWeight values. For example, the font calculator called boundaryFont might be defined as:
    //TO DO: noteFont. JavaScript function that returns a FontConfig. By default, these return the appropriate *FontSize, *FontFamily, *FontWeight values. For example, the font calculator called boundaryFont might be defined as:
    //TO DO: actorFont. JavaScript function that returns a FontConfig. By default, these return the appropriate *FontSize, *FontFamily, *FontWeight values. For example, the font calculator called boundaryFont might be defined as:

