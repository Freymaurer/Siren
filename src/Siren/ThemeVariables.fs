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