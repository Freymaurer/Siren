﻿namespace Siren

open Fable.Core

[<AttachMembers>]
type themeVariable =
    static member custom (key: string, value: string) = ThemeVariable <| (key, value)

[<AttachMembers>]
type quadrantTheme =
    static member custom (key: string, value: string) = ThemeVariable <| (key, value)
    static member quadrant1Fill (color: string) = ThemeVariable <| ("quadrant1Fill", color)
    static member quadrant2Fill (color: string) = ThemeVariable <| ("quadrant2Fill", color)
    static member quadrant3Fill (color: string) = ThemeVariable <| ("quadrant3Fill", color)
    static member quadrant4Fill (color: string) = ThemeVariable <| ("quadrant4Fill", color)
    static member quadrant1TextFill (color: string) = ThemeVariable <| ("quadrant1TextFill", color)
    static member quadrant2TextFill (color: string) = ThemeVariable <| ("quadrant2TextFill", color)
    static member quadrant3TextFill (color: string) = ThemeVariable <| ("quadrant3TextFill", color)
    static member quadrant4TextFill (color: string) = ThemeVariable <| ("quadrant4TextFill", color)
    static member quadrantPointFill (color: string) = ThemeVariable <| ("quadrantPointFill", color)
    static member quadrantPointTextFill (color: string) = ThemeVariable <| ("quadrantPointTextFill", color)
    static member quadrantXAxisTextFill (color: string) = ThemeVariable <| ("quadrantXAxisTextFill", color)
    static member quadrantYAxisTextFill (color: string) = ThemeVariable <| ("quadrantYAxisTextFill", color)
    static member quadrantInternalBorderStrokeFill (color: string) = ThemeVariable <| ("quadrantInternalBorderStrokeFill", color)
    static member quadrantExternalBorderStrokeFill (color: string) = ThemeVariable <| ("quadrantExternalBorderStrokeFill", color)
    static member quadrantTitleFill (color: string) = ThemeVariable <| ("quadrantTitleFill", color)

[<AttachMembers>]
type gitTheme =
    static member custom (key: string, value: string) = ThemeVariable <| (key, value)
    static member git0 (color: string) = ThemeVariable <| ("git0", color)
    static member git1 (color: string) = ThemeVariable <| ("git1", color)
    static member git2 (color: string) = ThemeVariable <| ("git2", color)
    static member git3 (color: string) = ThemeVariable <| ("git3", color)
    static member git4 (color: string) = ThemeVariable <| ("git4", color)
    static member git5 (color: string) = ThemeVariable <| ("git5", color)
    static member git6 (color: string) = ThemeVariable <| ("git6", color)
    static member git7 (color: string) = ThemeVariable <| ("git7", color)
    static member gitBranchLabel0 (color: string) = ThemeVariable <| ("gitBranchLabel0", color)
    static member gitBranchLabel1 (color: string) = ThemeVariable <| ("gitBranchLabel1", color)
    static member gitBranchLabel2 (color: string) = ThemeVariable <| ("gitBranchLabel2", color)
    static member gitBranchLabel3 (color: string) = ThemeVariable <| ("gitBranchLabel3", color)
    static member gitBranchLabel4 (color: string) = ThemeVariable <| ("gitBranchLabel4", color)
    static member gitBranchLabel5 (color: string) = ThemeVariable <| ("gitBranchLabel5", color)
    static member gitBranchLabel6 (color: string) = ThemeVariable <| ("gitBranchLabel6", color)
    static member gitBranchLabel7 (color: string) = ThemeVariable <| ("gitBranchLabel7", color)
    static member gitBranchLabel8 (color: string) = ThemeVariable <| ("gitBranchLabel8", color)
    static member gitBranchLabel9 (color: string) = ThemeVariable <| ("gitBranchLabel9", color)
    static member commitLabelColor (color: string) = ThemeVariable <| ("commitLabelColor", color)
    static member commitLabelBackground (color: string) = ThemeVariable <| ("commitLabelBackground", color)
    static member commitLabelFontSize (lengthUnit: string) = ThemeVariable <| ("commitLabelFontSize", lengthUnit)
    static member commitLabelFontSizePx (lengthUnit: int) = ThemeVariable <| ("commitLabelFontSize", string lengthUnit + "px")
    static member tagLabelFontSize (lengthUnit: string) = ThemeVariable <| ("tagLabelFontSize", lengthUnit)
    static member tagLabelFontSizePx (lengthUnit: int) = ThemeVariable <| ("tagLabelFontSize", string lengthUnit + "px")
    static member tagLabelColor (color: string) = ThemeVariable <| ("tagLabelColor", color)
    static member tagLabelBackground (color: string) = ThemeVariable <| ("tagLabelBackground", color)
    static member tagLabelBorder (color: string) = ThemeVariable <| ("tagLabelBorder", color)
    static member gitInv0 (color: string) = ThemeVariable <| ("gitInv0", color)
    static member gitInv1 (color: string) = ThemeVariable <| ("gitInv1", color)
    static member gitInv2 (color: string) = ThemeVariable <| ("gitInv2", color)
    static member gitInv3 (color: string) = ThemeVariable <| ("gitInv3", color)
    static member gitInv4 (color: string) = ThemeVariable <| ("gitInv4", color)
    static member gitInv5 (color: string) = ThemeVariable <| ("gitInv5", color)
    static member gitInv6 (color: string) = ThemeVariable <| ("gitInv6", color)
    static member gitInv7 (color: string) = ThemeVariable <| ("gitInv7", color)


[<AttachMembers>]
type timelineTheme =
    static member custom (key: string, value: string) = ThemeVariable <| (key, value)
    static member cScale0 (color: string) = ThemeVariable <| ("cScale0", color)
    static member cScale1 (color: string) = ThemeVariable <| ("cScale1", color)
    static member cScale2 (color: string) = ThemeVariable <| ("cScale2", color)
    static member cScale3 (color: string) = ThemeVariable <| ("cScale3", color)
    static member cScale4 (color: string) = ThemeVariable <| ("cScale4", color)
    static member cScale5 (color: string) = ThemeVariable <| ("cScale5", color)
    static member cScale6 (color: string) = ThemeVariable <| ("cScale6", color)
    static member cScale7 (color: string) = ThemeVariable <| ("cScale7", color)
    static member cScale8 (color: string) = ThemeVariable <| ("cScale8", color)
    static member cScale9 (color: string) = ThemeVariable <| ("cScale9", color)
    static member cScale10 (color: string) = ThemeVariable <| ("cScale10", color)
    static member cScale11 (color: string) = ThemeVariable <| ("cScale11", color)
    static member cScaleLabel0 (color: string) = ThemeVariable <| ("cScaleLabel0", color)
    static member cScaleLabel1 (color: string) = ThemeVariable <| ("cScaleLabel1", color)
    static member cScaleLabel2 (color: string) = ThemeVariable <| ("cScaleLabel2", color)
    static member cScaleLabel3 (color: string) = ThemeVariable <| ("cScaleLabel3", color)
    static member cScaleLabel4 (color: string) = ThemeVariable <| ("cScaleLabel4", color)
    static member cScaleLabel5 (color: string) = ThemeVariable <| ("cScaleLabel5", color)
    static member cScaleLabel6 (color: string) = ThemeVariable <| ("cScaleLabel6", color)
    static member cScaleLabel7 (color: string) = ThemeVariable <| ("cScaleLabel7", color)
    static member cScaleLabel8 (color: string) = ThemeVariable <| ("cScaleLabel8", color)
    static member cScaleLabel9 (color: string) = ThemeVariable <| ("cScaleLabel9", color)
    static member cScaleLabel10 (color: string) = ThemeVariable <| ("cScaleLabel10", color)
    static member cScaleLabel11 (color: string) = ThemeVariable <| ("cScaleLabel11", color)

[<AttachMembers>]
type xyChartTheme =
    static member custom (key: string, value: string) = ThemeVariable <| (key, value)
    static member backgroundColor (color: string) = ThemeVariable <| ("backgroundColor", color)
    static member titleColor (color: string) = ThemeVariable <| ("titleColor", color)
    static member xAxisLabelColor (color: string) = ThemeVariable <| ("xAxisLabelColor", color)
    static member xAxisTitleColor (color: string) = ThemeVariable <| ("xAxisTitleColor", color)
    static member xAxisTickColor (color: string) = ThemeVariable <| ("xAxisTickColor", color)
    static member xAxisLineColor (color: string) = ThemeVariable <| ("xAxisLineColor", color)
    static member yAxisLabelColor (color: string) = ThemeVariable <| ("yAxisLabelColor", color)
    static member yAxisTitleColor (color: string) = ThemeVariable <| ("yAxisTitleColor", color)
    static member yAxisTickColor (color: string) = ThemeVariable <| ("yAxisTickColor", color)
    static member yAxisLineColor (color: string) = ThemeVariable <| ("yAxisLineColor", color)
    static member plotColorPalette (colors: #seq<string>) = ThemeVariable <| ("plotColorPalette", colors |> String.concat ",")

[<AttachMembers>]
type pieTheme =
    static member custom (key: string, value: string) = ThemeVariable <| (key, value)
    static member pieOuterStrokeWidth (lengthUnit: string) = ThemeVariable <| ("pieOuterStrokeWidth", lengthUnit)
    