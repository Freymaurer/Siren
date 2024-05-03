namespace Siren

open Fable.Core

[<AttachMembers>]
type qudarantTheme =
    static member quadrant1Fill (color: string) = "quadrant1Fill", color
    static member quadrant2Fill (color: string) = "quadrant2Fill", color
    static member quadrant3Fill (color: string) = "quadrant3Fill", color
    static member quadrant4Fill (color: string) = "quadrant4Fill", color
    static member quadrant1TextFill (color: string) = "quadrant1TextFill", color
    static member quadrant2TextFill (color: string) = "quadrant2TextFill", color
    static member quadrant3TextFill (color: string) = "quadrant3TextFill", color
    static member quadrant4TextFill (color: string) = "quadrant4TextFill", color
    static member quadrantPointFill (color: string) = "quadrantPointFill", color
    static member quadrantPointTextFill (color: string) = "quadrantPointTextFill", color
    static member quadrantXAxisTextFill (color: string) = "quadrantXAxisTextFill", color
    static member quadrantYAxisTextFill (color: string) = "quadrantYAxisTextFill", color
    static member quadrantInternalBorderStrokeFill (color: string) = "quadrantInternalBorderStrokeFill", color
    static member quadrantExternalBorderStrokeFill (color: string) = "quadrantExternalBorderStrokeFill", color
    static member quadrantTitleFill (color: string) = "quadrantTitleFill", color

[<AttachMembers>]
type gitTheme =
    static member git0 (color: string) = "git0", color
    static member git1 (color: string) = "git1", color
    static member git2 (color: string) = "git2", color
    static member git3 (color: string) = "git3", color
    static member git4 (color: string) = "git4", color
    static member git5 (color: string) = "git5", color
    static member git6 (color: string) = "git6", color
    static member git7 (color: string) = "git7", color
    static member gitBranchLabel0 (color: string) = "gitBranchLabel0", color
    static member gitBranchLabel1 (color: string) = "gitBranchLabel1", color
    static member gitBranchLabel2 (color: string) = "gitBranchLabel2", color
    static member gitBranchLabel3 (color: string) = "gitBranchLabel3", color
    static member gitBranchLabel4 (color: string) = "gitBranchLabel4", color
    static member gitBranchLabel5 (color: string) = "gitBranchLabel5", color
    static member gitBranchLabel6 (color: string) = "gitBranchLabel6", color
    static member gitBranchLabel7 (color: string) = "gitBranchLabel7", color
    static member gitBranchLabel8 (color: string) = "gitBranchLabel8", color
    static member gitBranchLabel9 (color: string) = "gitBranchLabel9", color
    static member commitLabelColor (color: string) = "commitLabelColor", color
    static member commitLabelBackground (color: string) = "commitLabelBackground", color
    static member commitLabelFontSize (lengthUnit: string) = "commitLabelFontSize", lengthUnit
    static member commitLabelFontSizePx (lengthUnit: int) = "commitLabelFontSize", string lengthUnit + "px"
    static member tagLabelFontSize (lengthUnit: string) = "tagLabelFontSize", lengthUnit
    static member tagLabelFontSizePx (lengthUnit: int) = "tagLabelFontSize", string lengthUnit + "px"
    static member tagLabelColor (color: string) = "tagLabelColor", color
    static member tagLabelBackground (color: string) = "tagLabelBackground", color
    static member tagLabelBorder (color: string) = "tagLabelBorder", color
    static member gitInv0 (color: string) = "gitInv0", color
    static member gitInv1 (color: string) = "gitInv1", color
    static member gitInv2 (color: string) = "gitInv2", color
    static member gitInv3 (color: string) = "gitInv3", color
    static member gitInv4 (color: string) = "gitInv4", color
    static member gitInv5 (color: string) = "gitInv5", color
    static member gitInv6 (color: string) = "gitInv6", color
    static member gitInv7 (color: string) = "gitInv7", color


// cScale0 to cScale11
// cScaleLabel0 to cScaleLabel11
[<AttachMembers>]
type timelineTheme =
    static member cScale0 (color: string) = "cScale0", color
    static member cScale1 (color: string) = "cScale1", color
    static member cScale2 (color: string) = "cScale2", color
    static member cScale3 (color: string) = "cScale3", color
    static member cScale4 (color: string) = "cScale4", color
    static member cScale5 (color: string) = "cScale5", color
    static member cScale6 (color: string) = "cScale6", color
    static member cScale7 (color: string) = "cScale7", color
    static member cScale8 (color: string) = "cScale8", color
    static member cScale9 (color: string) = "cScale9", color
    static member cScale10 (color: string) = "cScale10", color
    static member cScale11 (color: string) = "cScale11", color
    static member cScaleLabel0 (color: string) = "cScaleLabel0", color
    static member cScaleLabel1 (color: string) = "cScaleLabel1", color
    static member cScaleLabel2 (color: string) = "cScaleLabel2", color
    static member cScaleLabel3 (color: string) = "cScaleLabel3", color
    static member cScaleLabel4 (color: string) = "cScaleLabel4", color
    static member cScaleLabel5 (color: string) = "cScaleLabel5", color
    static member cScaleLabel6 (color: string) = "cScaleLabel6", color
    static member cScaleLabel7 (color: string) = "cScaleLabel7", color
    static member cScaleLabel8 (color: string) = "cScaleLabel8", color
    static member cScaleLabel9 (color: string) = "cScaleLabel9", color
    static member cScaleLabel10 (color: string) = "cScaleLabel10", color
    static member cScaleLabel11 (color: string) = "cScaleLabel11", color

type xyChartTheme =
    static member backgroundColor (color: string) = "backgroundColor", color
    static member titleColor (color: string) = "titleColor", color
    static member xAxisLabelColor (color: string) = "xAxisLabelColor", color
    static member xAxisTitleColor (color: string) = "xAxisTitleColor", color
    static member xAxisTickColor (color: string) = "xAxisTickColor", color
    static member xAxisLineColor (color: string) = "xAxisLineColor", color
    static member yAxisLabelColor (color: string) = "yAxisLabelColor", color
    static member yAxisTitleColor (color: string) = "yAxisTitleColor", color
    static member yAxisTickColor (color: string) = "yAxisTickColor", color
    static member yAxisLineColor (color: string) = "yAxisLineColor", color
    static member plotColorPalette (colors: #seq<string>) = "plotColorPalette", colors |> String.concat ","
    