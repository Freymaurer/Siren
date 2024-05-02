﻿namespace Siren

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

[<AttachMembers>]
type ganttConfig =
    static member custom (key, value) = key, value
    /// Default: 25
    static member titleTopMargin(px:int) = "titleTopMargin", string px
    /// Default: 20
    static member barHeight(px:int) = "barHeight", string px
    /// Default: 4
    static member barGap(px:int) = "barGap", string px
    /// Default: 50
    static member topPadding(px:int) = "topPadding", string px
    /// Default: 75
    static member leftPadding(px:int) = "leftPadding", string px
    /// Default: 75
    static member rightPadding(px:int) = "rightPadding", string px
    /// Default: 35
    static member gridLineStartPadding(px:int) = "gridLineStartPadding", string px
    /// Default: 11
    static member fontSize(px:int) = "fontSize", string px
    /// Default: 11
    static member sectionFontSize(px:int) = "sectionFontSize", string px
    /// Default: 4
    static member numberSectionStyles(n:int) = "numberSectionStyles", string n
    /// Default: "%Y-%m-%d"
    static member axisFormat(format:string) = "axisFormat", format
    /// Must match: /^([1-9][0-9]*)(millisecond|second|minute|hour|day|week|month)$/
    static member tickInterval(format:string) = "tickInterval", format
    static member tickIntervalMillisecond(ms:int) = "tickInterval", sprintf "%imillisecond" ms
    static member tickIntervalSecond(s:int) = "tickInterval", sprintf "%isecond" s
    static member tickIntervalMinute(min:int) = "tickInterval", sprintf "%iminute" min
    static member tickIntervalHour(hour:int) = "tickInterval", sprintf "%ihour" hour
    static member tickIntervalDay(day:int) = "tickInterval", sprintf "%iday" day
    static member tickIntervalWeek(week:int) = "tickInterval", sprintf "%iweek" week
    static member tickIntervalMonth(month:int) = "tickInterval", sprintf "%imonth" month
    static member topAxis(b:bool) = "topAxis", string b
    static member displayMode(mode: string) = "displayMode", sprintf "\"%s\"" mode
    static member displayModeDefault = "displayMode", sprintf "\"\""
    static member displayModeCompact = "displayMode", sprintf "\"compact\""
    /// Default: "sunday"
    static member weekday(day: string) = "weekday", sprintf "%A" day
    static member weekdayMonday = "weekday", sprintf "%A" "monday"
    static member weekdayTuesday = "weekday", sprintf "%A" "tuesday"
    static member weekdayWednesday = "weekday", sprintf "%A" "wednesday"
    static member weekdayThursday = "weekday", sprintf "%A" "thursday"
    static member weekdayFriday = "weekday", sprintf "%A" "friday"
    static member weekdaySaturday = "weekday", sprintf "%A" "saturday"
    static member weekdaySunday = "weekday", sprintf "%A" "sunday"

type journeyConfig =
    static member custom (key, value) = key, value
    /// Default: 50
    static member diagramMarginX (value: int) = "diagramMarginX", string value
    /// Default: 10
    static member diagramMarginY (value: int) = "diagramMarginY", string value
    /// Default: 150
    static member leftMargin (value: int) = "leftMargin", string value
    /// Default: 150
    static member width (value: int) = "width", string value
    /// Default: 50
    static member height (value: int) = "height", string value
    // ---
    // The following part is shown in official docs but does not really make 
    // sense and does not work in live editor.
    // ---
    ///// Default: 10
    //static member boxMargin (value: int) = "boxMargin", string value
    ///// Default: 5
    //static member boxTextMargin (value: int) = "boxTextMargin", string value
    ///// Default: 10
    //static member noteMargin (value: int) = "noteMargin", string value
    ///// Default: 35
    //static member messageMargin (value: int) = "messageMargin", string value
    ///// Default: "center"
    //static member messageAlign (value: string) = "messageAlign", string value
    //static member messageAlignLeft = "messageAlign", "\"left\""
    //static member messageAlignCenter = "messageAlign", "\"center\""
    //static member messageAlignRight = "messageAlign", "\"right\""
    ///// Default: 1
    //static member bottomMarginAdj (value: int) = "bottomMarginAdj", string value
    //static member rightAngles (value: bool) = "rightAngles", string value

type timelineConfig =
    static member custom (key, value) = key, value
    static member disableMulticolor (value: bool) = "disableMulticolor", string value
    static member padding (value: int) = "disableMulticolor", string value
