namespace Siren

open Util
open Fable.Core

// official docs: https://mermaid.js.org/config/schema-docs/config.html

[<AttachMembers>]
type flowchartConfig =
    static member custom (key, value) = ConfigVariable <| (key, value)
    /// Default: "dagre-wrapper"
    static member defaultRenderer (renderer: string) = ConfigVariable <| ("defaultRenderer", renderer)
    static member defaultRendererElk = ConfigVariable <| ("defaultRenderer", "elk")
    static member defaultRendererDagreD3 = ConfigVariable <| ("defaultRenderer", "dagre-d3")
    static member defaultRendererDagreWrapper = ConfigVariable <| ("defaultRenderer", "dagre-wrapper")
    /// Default: 25
    static member titleTopMargin(px:int) = ConfigVariable <| ("titleTopMargin", string px)
    /// Default: {"top": 0, "bottom": 0 }
    static member subGraphTitleMargin(top: int, bottom: int) = ConfigVariable <| ("subGraphTitleMargin", sprintf "{\"top\": %i, \"bottom\": %i}" top bottom)
    static member arrowMarkerAbsolute(b: bool) = ConfigVariable <| ("arrowMarkerAbsolute", Bool.toString b)
    /// Default: 20
    static member diagramPadding(px: int) = ConfigVariable <| ("diagramPadding", string px)
    /// Default: true
    static member htmlLabels(b: bool) = ConfigVariable <| ("htmlLabels", Bool.toString b)
    /// Default: 50
    static member nodeSpacing(px: int) = ConfigVariable <| ("nodeSpacing", string px)
    /// Default: 50
    static member rankSpacing(px: int) = ConfigVariable <| ("rankSpacing", string px)
    /// Default: "basis"
    static member curve(name: string) = ConfigVariable <| ("curve", name)
    static member curveBasis = ConfigVariable <| ("curve", "basis")
    static member curveLinear = ConfigVariable <| ("curve", "linear")
    static member curveCardianal = ConfigVariable <| ("curve", "cardinal")
    /// Default: 15
    static member padding(px: int) = ConfigVariable <| ("padding", string px)
    /// Default: 200
    static member wrappingWidth(px: int) = ConfigVariable <| ("wrappingWidth", string px)

[<AttachMembers>]
type sequenceConfig =
    static member custom (key: string, value: string) = ConfigVariable <| (key, value)
    static member arrowMarkerAbsolute (b: bool) = ConfigVariable <| ("arrowMarkerAbsolute", Bool.toString b)
    static member hideUnusedParticipants (b: bool) = ConfigVariable <| ("hideUnusedParticipants", Bool.toString b)
    /// Default: 10
    static member activationWidth (px: int) = ConfigVariable <| ("activationWidth", string px)
    /// Default: 50
    static member diagramMarginX (px: int) = ConfigVariable <| ("diagramMarginX", string px)
    /// Default: 10
    static member diagramMarginY (px: int) = ConfigVariable <| ("diagramMarginX", string px)
    /// Default: 50
    static member actorMargin (px: int) = ConfigVariable <| ("actorMargin", string px)
    /// Default: 150
    static member width (px: int) = ConfigVariable <| ("width", string px)
    /// Default: 50
    static member height (px: int) = ConfigVariable <| ("height", string px)
    /// Default: 10
    static member boxMargin (px: int) = ConfigVariable <| ("boxMargin", string px)
    /// Default: 5
    static member boxTextMargin (px: int) = ConfigVariable <| ("boxTextMargin", string px)
    /// Default: 10
    static member noteMargin (px: int) = ConfigVariable <| ("noteMargin", string px)
    // Default: 35
    // static member messageMargin (px: int) = "messageMargin", string px //Did not work
    /// Default: center
    static member messageAlign (name: string)   = ConfigVariable <| ("messageAlign", name)
    static member messageAlignLeft              = ConfigVariable <| ("messageAlign", "left")
    static member messageAligncCenter           = ConfigVariable <| ("messageAlign", "center")
    static member messageAlignRight             = ConfigVariable <| ("messageAlign", "right")
    /// Default: true
    static member mirrorActors (b:bool) = ConfigVariable <| ("mirrorActors", Bool.toString b)
    // static member forceMenus (b:bool) = "forceMenus", string b //Did not work
    /// Default: 1 
    static member bottomMarginAdj (px: int) = ConfigVariable <| ("bottomMarginAdj", string px)
    //static member rightAngles (b: bool) = "rightAngles", string b //Did not work
    static member showSequenceNumbers (b: bool) = ConfigVariable <| ("showSequenceNumbers", Bool.toString b)
    /// Default: "14"
    static member actorFontSize (s: string) = ConfigVariable <| ("actorFontSize", s) //TODO: Multiple types
    // Default: "\"Open Sans\", sans-serif"
    //static member actorFontFamily (s:string) = "actorFontFamily", s //Did not work
    /// Default: "400"
    static member actorFontWeight (s:string) = ConfigVariable <| ("actorFontWeight", s) //TODO: Multiple types
    /// Default: "14"
    static member noteFontSize (s:string) = ConfigVariable <| ("noteFontSize", s) //TODO: Multiple types
    // Default: "\"trebuchet ms\", verdana, arial, sans-serif"
    //static member noteFontFamily (s:string) = "noteFontFamily", s //Did not work
    /// Default: "400"
    static member noteFontWeight (s:string) = ConfigVariable <| ("noteFontWeight", s) //TODO: Multiple types
    /// Default: "center"
    static member noteAlign (s:string)  = ConfigVariable <| ("noteAlign", s)
    static member noteAlignLeft         = ConfigVariable <| ("noteAlign", "left")
    static member noteAlignCenter       = ConfigVariable <| ("noteAlign", "center")
    static member noteAlignRight        = ConfigVariable <| ("noteAlign", "right")
    /// Default: "16"
    static member messageFontSize (s:string) = ConfigVariable <| ("messageFontSize", s) //TODO: Multiple types
    // Default: "\"trebuchet ms\", verdana, arial, sans-serif"
    // static member messageFontFamily (s:string) = "messageFontFamily", s //TODO: Multiple types
    /// Default: "400"
    static member messageFontWeight (s:string) = ConfigVariable <| ("messageFontWeight", s) //TODO: Multiple types
    static member wrap (b: bool) = ConfigVariable <| ("wrap", Bool.toString b)
    /// Default: 10
    static member wrapPadding (px: int) = ConfigVariable <| ("wrapPadding", string px)
    // Default: 50
    //static member labelBoxWidth (px: int) = "labelBoxWidth", string px //Did not work
    /// Default: 20
    //static member labelBoxHeight (px: int) = "labelBoxHeight", string px //Did not work
    //TO DO: messageFont JavaScript function that returns a FontConfig. By default, these return the appropriate *FontSize, *FontFamily, *FontWeight values. For example, the font calculator called boundaryFont might be defined as:
    //TO DO: noteFont. JavaScript function that returns a FontConfig. By default, these return the appropriate *FontSize, *FontFamily, *FontWeight values. For example, the font calculator called boundaryFont might be defined as:
    //TO DO: actorFont. JavaScript function that returns a FontConfig. By default, these return the appropriate *FontSize, *FontFamily, *FontWeight values. For example, the font calculator called boundaryFont might be defined as:

[<AttachMembers>]
type ganttConfig =
    static member custom (key: string, value: string) = ConfigVariable <| (key, value)
    /// Default: 25
    static member titleTopMargin(px:int) = ConfigVariable <| ("titleTopMargin", string px)
    /// Default: 20
    static member barHeight(px:int) = ConfigVariable <| ("barHeight", string px)
    /// Default: 4
    static member barGap(px:int) = ConfigVariable <| ("barGap", string px)
    /// Default: 50
    static member topPadding(px:int) = ConfigVariable <| ("topPadding", string px)
    /// Default: 75
    static member leftPadding(px:int) = ConfigVariable <| ("leftPadding", string px)
    /// Default: 75
    static member rightPadding(px:int) = ConfigVariable <| ("rightPadding", string px)
    /// Default: 35
    static member gridLineStartPadding(px:int) = ConfigVariable <| ("gridLineStartPadding", string px)
    /// Default: 11
    static member fontSize(px:int) = ConfigVariable <| ("fontSize", string px)
    /// Default: 11
    static member sectionFontSize(px:int) = ConfigVariable <| ("sectionFontSize", string px)
    /// Default: 4
    static member numberSectionStyles(n:int) = ConfigVariable <| ("numberSectionStyles", string n)
    /// Default: "%Y-%m-%d"
    static member axisFormat(format:string) = ConfigVariable <| ("axisFormat", format)
    /// Must match: /^([1-9][0-9]*)(millisecond|second|minute|hour|day|week|month)$/
    static member tickInterval(format:string) = ConfigVariable <| ("tickInterval", format)
    static member tickIntervalMillisecond(ms:int) = ConfigVariable <| ("tickInterval", sprintf "%imillisecond" ms)
    static member tickIntervalSecond(s:int) = ConfigVariable <| ("tickInterval", sprintf "%isecond" s)
    static member tickIntervalMinute(min:int) = ConfigVariable <| ("tickInterval", sprintf "%iminute" min)
    static member tickIntervalHour(hour:int) = ConfigVariable <| ("tickInterval", sprintf "%ihour" hour)
    static member tickIntervalDay(day:int) = ConfigVariable <| ("tickInterval", sprintf "%iday" day)
    static member tickIntervalWeek(week:int) = ConfigVariable <| ("tickInterval", sprintf "%iweek" week)
    static member tickIntervalMonth(month:int) = ConfigVariable <| ("tickInterval", sprintf "%imonth" month)
    static member topAxis(b:bool) = ConfigVariable <| ("topAxis", Bool.toString b)
    static member displayMode(mode: string) = ConfigVariable <| ("displayMode", sprintf "\"%s\"" mode)
    static member displayModeDefault = ConfigVariable <| ("displayMode", sprintf "\"\"")
    static member displayModeCompact = ConfigVariable <| ("displayMode", sprintf "\"compact\"")
    /// Default: "sunday"
    static member weekday(day: string) = ConfigVariable <| ("weekday", sprintf "%A" day)
    static member weekdayMonday = ConfigVariable <| ("weekday", sprintf "%A" "monday")
    static member weekdayTuesday = ConfigVariable <| ("weekday", sprintf "%A" "tuesday")
    static member weekdayWednesday = ConfigVariable <| ("weekday", sprintf "%A" "wednesday")
    static member weekdayThursday = ConfigVariable <| ("weekday", sprintf "%A" "thursday")
    static member weekdayFriday = ConfigVariable <| ("weekday", sprintf "%A" "friday")
    static member weekdaySaturday = ConfigVariable <| ("weekday", sprintf "%A" "saturday")
    static member weekdaySunday = ConfigVariable <| ("weekday", sprintf "%A" "sunday")

[<AttachMembers>]
type journeyConfig =
    static member custom (key: string, value: string) = ConfigVariable <| (key, value)
    /// Default: 50
    static member diagramMarginX (value: int) = ConfigVariable <| ("diagramMarginX", string value)
    /// Default: 10
    static member diagramMarginY (value: int) = ConfigVariable <| ("diagramMarginY", string value)
    /// Default: 150
    static member leftMargin (value: int) = ConfigVariable <| ("leftMargin", string value)
    /// Default: 150
    static member width (value: int) = ConfigVariable <| ("width", string value)
    /// Default: 50
    static member height (value: int) = ConfigVariable <| ("height", string value)
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

[<AttachMembers>]
type timelineConfig =
    static member custom (key: string, value: string) = ConfigVariable <| (key, value)
    static member disableMulticolor (value: bool) = ConfigVariable <| ("disableMulticolor", Bool.toString value)
    static member padding (value: int) = ConfigVariable <| ("disableMulticolor", string value)

[<AttachMembers>]
type classConfig =
    static member custom (key: string, value: string) = ConfigVariable <| (key, value)
    /// Default: "dagre-wrapper"
    static member defaultRenderer (renderer: string) = ConfigVariable <| ("defaultRenderer", renderer)
    static member defaultRendererElk = ConfigVariable <| ("defaultRenderer", "elk")
    static member defaultRendererDagreD3 = ConfigVariable <| ("defaultRenderer", "dagre-d3")
    static member defaultRendererDagreWrapper = ConfigVariable <| ("defaultRenderer", "dagre-wrapper")

[<AttachMembers>]
type stateConfig =
    static member custom (key: string, value: string) = ConfigVariable <| (key, value)
    /// Default: 25
    static member titleTopMargin (value: int) = ConfigVariable <| ("titleTopMargin", string value)

[<AttachMembers>]
type erConfig =
    static member custom (key: string, value: string) = ConfigVariable <| (key, value)
    /// Default: 25
    static member titleTopMargin (value: int) = ConfigVariable <| ("titleTopMargin", string value)
    /// Default: 20
    static member diagramPadding (value: int) = ConfigVariable <| ("diagramPadding", string value)
    /// Default: "TB"
    static member layoutDirection (value: string) = ConfigVariable <| ("layoutDirection", value)
    static member layoutDirectionTB = ConfigVariable <| ("layoutDirection", "TB")
    static member layoutDirectionBT = ConfigVariable <| ("layoutDirection", "BT")
    static member layoutDirectionLR = ConfigVariable <| ("layoutDirection", "LR")
    static member layoutDirectionRL = ConfigVariable <| ("layoutDirection", "RL")
    /// Default: 100
    static member minEntityWidth (value: int) = ConfigVariable <| ("minEntityWidth", string value)
    /// Default: 75
    static member minEntityHeight (value: int) = ConfigVariable <| ("minEntityHeight", string value)
    /// Default: 15
    static member entityPadding (value: int) = ConfigVariable <| ("entityPadding", string value)
    /// Default: "gray"
    static member stroke (value: string) = ConfigVariable <| ("stroke", value)
    /// Default: 12
    static member fontSize (value: int) = ConfigVariable <| ("fontSize", string value)

[<AttachMembers>]
type quadrantChartConfig  =
    static member custom (key: string, value: string) = ConfigVariable <| (key, value)
    /// Default: 500
    static member chartWidth (value: int) = ConfigVariable <| ("chartWidth", string value)
    /// Default: 500
    static member chartHeight (value: int) = ConfigVariable <| ("chartHeight", string value)
    /// Default: 20
    static member titleFontSize (value: int) = ConfigVariable <| ("titleFontSize", string value)
    /// Default: 10
    static member titlePadding (value: int) = ConfigVariable <| ("titlePadding", string value)
    /// Default: 5
    static member quadrantPadding (value: int) = ConfigVariable <| ("quadrantPadding", string value)
    /// Default: 5
    static member xAxisLabelPadding (value: int) = ConfigVariable <| ("xAxisLabelPadding", string value)
    /// Default: 5
    static member yAxisLabelPadding (value: int) = ConfigVariable <| ("yAxisLabelPadding", string value)
    /// Default: 16
    static member xAxisLabelFontSize (value: int) = ConfigVariable <| ("xAxisLabelFontSize", string value)
    /// Default: 16
    static member yAxisLabelFontSize (value: int) = ConfigVariable <| ("yAxisLabelFontSize", string value)
    /// Default: 16
    static member quadrantLabelFontSize (value: int) = ConfigVariable <| ("quadrantLabelFontSize", string value)
    /// Default: 5
    static member quadrantTextTopPadding (value: int) = ConfigVariable <| ("quadrantTextTopPadding", string value)
    /// Default: 5
    static member pointTextPadding (value: int) = ConfigVariable <| ("pointTextPadding", string value)
    /// Default: 12
    static member pointLabelFontSize (value: int) = ConfigVariable <| ("pointLabelFontSize", string value)
    /// Default: 5
    static member pointRadius (value: int) = ConfigVariable <| ("pointRadius", string value)
    // Default: "top" 
    // Did not work
    //static member xAxisPosition (value: string)     = "xAxisPosition", value
    //static member xAxisPositionTop                  = "xAxisPosition", "top"
    //static member xAxisPositionBottom               = "xAxisPosition", "bottom"
    /// Default: "left" 
    static member yAxisPosition (value: string)     = ConfigVariable <| ("xAxisPosition", value)
    static member yAxisPositionLeft                 = ConfigVariable <| ("xAxisPosition", "left")
    static member yAxisPositionRight                = ConfigVariable <| ("xAxisPosition", "right")
    /// Default: 1
    static member quadrantInternalBorderStrokeWidth (value: int) = ConfigVariable <| ("quadrantInternalBorderStrokeWidth", string value)
    /// Default: 2
    static member quadrantExternalBorderStrokeWidth (value: int) = ConfigVariable <| ("quadrantExternalBorderStrokeWidth", string value)

[<AttachMembers>]
type pieConfig =
    static member custom (key: string, value: string) = ConfigVariable <| (key, value)
    /// Default: 0.75
    static member textPosition (value: float) = ConfigVariable <| ("textPosition", string value)

[<AttachMembers>]
type sankeyConfig =
    static member custom (key: string, value: string) = ConfigVariable <| (key, value)
    static member width (value: int) = ConfigVariable <| ("width", string value)
    static member height (value: int) = ConfigVariable <| ("width", string value)
    static member linkColor (value: string) = ConfigVariable <| ("linkColor", string value)
    static member linkColorSource = ConfigVariable <| ("linkColor", "source")
    static member linkColorTarget = ConfigVariable <| ("linkColor", "target")
    static member linkColorGradient = ConfigVariable <| ("linkColor", "gradient")
    
module private XYChartHelpers =
    let inline optionIntBind (key:string) (value:int option) =
        match value with
        | Some value -> Some (key, string value)
        | None -> None

    let inline optionBoolBind (key:string) (value:bool option) =
        match value with
        | Some value -> Some (key, Bool.toString value)
        | None -> None

    let mkAxisConfig (parameters: (string*string) list) =
        parameters
        |> List.map (fun (key, value) -> sprintf "\"%s\": %A" key value)
        |> String.concat ", "
        |> fun s -> "{" + s + "}"

[<AttachMembers>]
type xyChartConfig =
    static member custom (key: string, value: string) = ConfigVariable <| (key, value)
    /// Default: 700
    static member width (value: int) = ConfigVariable <| ("width", string value)
    /// Default: 500
    static member height (value: int) = ConfigVariable <| ("height", string value)
    /// Default: 22
    static member titlePadding (value: int) = ConfigVariable <| ("titlePadding", string value)
    /// Default: 20
    static member titleFontSize (value: int) = ConfigVariable <| ("titleFontSize", string value)
    /// Default: true
    static member showTitle (value: int) = ConfigVariable <| ("showTitle", string value)
    static member internal _axis(name: string,
        ?showLabel: bool, ?labelFontSize: int, ?labelPadding: int, ?showTitle: bool, ?titleFontSize: int,
        ?titlePadding: int, ?showTick: bool, ?tickLength: int, ?tickWidth: int, ?showAxisLine: bool, ?axisLineWidth: int) =
            name, [
                XYChartHelpers.optionBoolBind "showLabel" showLabel
                XYChartHelpers.optionIntBind "labelFontSize" labelFontSize
                XYChartHelpers.optionIntBind "labelPadding" labelPadding
                XYChartHelpers.optionBoolBind "showTitle" showTitle
                XYChartHelpers.optionIntBind "titleFontSize" titleFontSize
                XYChartHelpers.optionIntBind "titlePadding" titlePadding
                XYChartHelpers.optionBoolBind "showTick" showTick
                XYChartHelpers.optionIntBind "tickLength" tickLength
                XYChartHelpers.optionIntBind "tickWidth" tickWidth
                XYChartHelpers.optionBoolBind "showAxisLine" showAxisLine
                XYChartHelpers.optionIntBind "axisLineWidth" axisLineWidth
            ]
            |> List.choose id
            |> XYChartHelpers.mkAxisConfig
    static member xAxis(?showLabel: bool, ?labelFontSize: int, ?labelPadding: int, ?showTitle: bool, ?titleFontSize: int,
        ?titlePadding: int, ?showTick: bool, ?tickLength: int, ?tickWidth: int, ?showAxisLine: bool, ?axisLineWidth: int) = 
        xyChartConfig._axis(
            "xAxis", ?showLabel=showLabel, ?labelFontSize=labelFontSize, ?labelPadding=labelPadding, ?showTitle=showTitle, 
            ?titleFontSize=titleFontSize, ?titlePadding=titlePadding, ?showTick=showTick, ?tickLength=tickLength, 
            ?tickWidth=tickWidth, ?showAxisLine=showAxisLine, ?axisLineWidth=axisLineWidth)
        |> ConfigVariable.ConfigVariable
    static member yAxis(?showLabel: bool, ?labelFontSize: int, ?labelPadding: int, ?showTitle: bool, ?titleFontSize: int,
        ?titlePadding: int, ?showTick: bool, ?tickLength: int, ?tickWidth: int, ?showAxisLine: bool, ?axisLineWidth: int) = 
        xyChartConfig._axis(
            "yAxis", ?showLabel=showLabel, ?labelFontSize=labelFontSize, ?labelPadding=labelPadding, ?showTitle=showTitle, 
            ?titleFontSize=titleFontSize, ?titlePadding=titlePadding, ?showTick=showTick, ?tickLength=tickLength, 
            ?tickWidth=tickWidth, ?showAxisLine=showAxisLine, ?axisLineWidth=axisLineWidth)
        |> ConfigVariable.ConfigVariable
    /// Default: "vertical"
    static member chartOrientation (value: int) = ConfigVariable <| ("chartOrientation", string value)
    static member chartOrientationVertical = ConfigVariable <| ("chartOrientation", "vertical")
    static member chartOrientationHorizontal= ConfigVariable <| ("chartOrientation", "horizontal")

[<AttachMembers>]
type mindmapConfig =
    static member custom (key: string, value: string) = ConfigVariable <| (key, value)
    /// Default: 10
    static member padding (value: int) = ConfigVariable <| ("padding", string value)
    /// Default: 200
    static member maxNodeWidth (value: int) = ConfigVariable <| ("maxNodeWidth", string value)

[<AttachMembers>]
type gitGraphConfig =
    static member custom (key: string, value: string) = ConfigVariable <| (key, value)
    /// Default: 25
    static member titleTopMargin (value: int) = ConfigVariable <| ("titleTopMargin", string value)
    /// Default: 8
    static member diagramPadding (value: int) = ConfigVariable <| ("diagramPadding", string value)
    /// Default: main
    static member mainBranchName (value: string) = ConfigVariable <| ("mainBranchName", value)
    static member mainBranchOrder (value: string) = ConfigVariable <| ("mainBranchOrder", value)
    /// Default: true
    static member showCommitLabel (value: bool) = ConfigVariable <| ("showCommitLabel", Bool.toString value)
    /// Default: true
    static member showBranches (value: bool) = ConfigVariable <| ("showBranches", Bool.toString value)
    /// Default: true
    static member rotateCommitLabel (value: bool) = ConfigVariable <| ("rotateCommitLabel", Bool.toString value)
    /// Default: false
    static member parallelCommits (value: bool) = ConfigVariable <| ("parallelCommits", Bool.toString value)


[<AttachMembers>]
type requirementConfig  =
    static member custom (key: string, value: string) = ConfigVariable <| (key, value)
    /// Default: 200
    static member rect_min_width (value: int) = ConfigVariable <| ("rect_min_width", string value)
    /// Default: 200
    static member rect_min_height (value: int) = ConfigVariable <| ("rect_min_height", string value)
    /// Defaukt: 10
    static member rect_padding (value: int) = ConfigVariable <| ("rect_padding", string value)
    /// Default: 20
    static member line_height (value: int) = ConfigVariable <| ("line_height", string value)
    