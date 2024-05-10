namespace Siren

open Fable.Core

module YamlHelpers =

    let writeYamlASTBasicWrapper opener closer children =
        [
            Yaml.line opener
            Yaml.level [
                for child in children do 
                    yield! child :> IYamlConvertible |> _.ToYamlAst()
            ]
            if closer <> "" then Yaml.line closer
        ]

    let writeYamlDiagramRoot opener children =
        Yaml.root [
            Yaml.line opener
            Yaml.level [
                for child in children do
                    yield! child :> IYamlConvertible |> _.ToYamlAst()
            ]
        ]

//---
//title: Test
//config:
//    theme: forest
//    gitGraph:
//        parallelCommits: true
//        showCommitLabel: true
//    themeVariables:
//        commitLabelColor: white
//        git0: red
//---

open YamlHelpers

[<RequireQualifiedAccess>]
type NotePosition =
    | Over
    | RightOf
    | LeftOf

[<RequireQualifiedAccess>]
type Direction = 
    | TB
    | TD
    | BT
    | RL
    | LR
    | Custom of string 

    override this.ToString() =
        match this with
        | TB -> "TB"
        | TD -> "TD"
        | BT -> "BT"
        | RL -> "RL"
        | LR -> "LR"
        | Custom str -> str

[<RequireQualifiedAccess>]
type FlowchartNodeTypes =
    | Default
    | Round
    | Stadium
    | Subroutine
    | Cylindrical 
    | Circle 
    | Asymmetric
    | Rhombus
    | Hexagon
    | Parallelogram
    | ParallelogramAlt
    | Trapezoid
    | TrapezoidAlt
    | DoubleCircle

[<RequireQualifiedAccess>]
type FlowchartLinkTypes =
    | Arrow
    | Open
    | Dotted
    | DottedArrow
    | Thick
    | ThickArrow
    | Invisible
    | CircleEdge
    | CrossEdge
    | ArrowDouble
    | CircleDouble
    | CrossDouble

[<RequireQualifiedAccess>]
type SequenceMessageTypes =
    | Solid
    | Dotted
    | Arrow
    | DottedArrow
    | CrossEdge
    | DottedCrossEdge
    | OpenArrow
    | DottedOpenArrow

[<RequireQualifiedAccess>]
type ClassMemberVisibility =
    | Public
    | Private
    | Protected
    | PackageInternal
    | Custom of string

[<RequireQualifiedAccess>]
type ClassMemberClassifier = 
    | Abstract
    | Static
    | Custom of string

[<RequireQualifiedAccess>]
type ClassRelationshipDirection =
    | Left
    | Right
    | TwoWay

[<RequireQualifiedAccess>]
type ClassRelationshipType = 
    | Inheritance
    | Composition
    | Aggregation
    | Association
    | Link
    | Solid
    | Dashed
    | Dependency
    | Realization

type ClassCardinality = 
    | One
    | ZeroOrOne
    | OneOrMore
    | Many
    | N
    | ZeroToN
    | OneToN
    | Custom of string

[<RequireQualifiedAccess>]
type ERCardinalityType = 
    | OneOrZero
    | OneOrMany
    | ZeroOrMany
    | OnlyOne

[<RequireQualifiedAccess>]
type ERKeyType = 
    | PK
    | FK
    | UK

[<RequireQualifiedAccess>]
type ERAttribute = {
    Type : string
    Name : string
    Keys : ERKeyType list
    Comment: string option
} 

[<RequireQualifiedAccess>]
type GanttTags = 
    | Active
    | Done
    | Crit
    | Milestone

[<RequireQualifiedAccess>]
type GanttUnit =
    | Millisecond
    | Second
    | Minute
    | Hour
    | Day
    | Week
    | Month

[<RequireQualifiedAccess>]
type RequirementType =
    | Requirement
    | FunctionalRequirement
    | InterfaceRequirement
    | PerformanceRequirement
    | PhysicalRequirement
    | DesignConstraint

[<RequireQualifiedAccess>]
type RDRiskType = 
    | Low
    | Medium
    | High

[<RequireQualifiedAccess>]
type RDVerifyMethod =
    | Analysis
    | Inspection
    | Test
    | Demonstration

/// A relationship type can be one of contains, copies, derives, satisfies, verifies, refines, or traces.
[<RequireQualifiedAccess>]
type RDRelationship = 
    | Contains
    | Copies
    | Derives
    | Satisfies
    | Verifies
    | Refines
    | Traces

[<RequireQualifiedAccess>]
type GitCommitType =
    | NORMAL
    | REVERSE
    | HIGHLIGHT

[<RequireQualifiedAccess>]
type MindmapShape = 
    | Square //id[I am a square]
    | RoundedSquare //id(I am a rounded square)
    | Circle //id((I am a circle))
    | Bang //id))I am a bang((
    | Cloud //id)I am a cloud(
    | Hexagon //id{{I am a hexagon}}

[<RequireQualifiedAccess>]
type BlockBlockType =
    | Square
    | RoundedEdge
    | Stadium
    | Subroutine 
    | Cylindrical 
    | Circle  
    | Asymmetric  
    | Rhombus  
    | Hexagon
    | Parallelogram
    | ParallelogramAlt
    | Trapezoid
    | TrapezoidAlt
    | DoubleCircle

[<RequireQualifiedAccess>]
type BlockArrowDirection = 
    | Right
    | Left
    | Up
    | Down
    | X
    | Y
    | Custom of string

type FlowchartElement =
    | FlowchartElement of string
    | FlowchartSubgraph of opener:string * closer: string * FlowchartElement list
    interface IYamlConvertible with
            
        member this.ToYamlAst() = 
            match this with
            | FlowchartElement line -> [Yaml.line line]
            | FlowchartSubgraph (opener, closer, children) ->
                writeYamlASTBasicWrapper opener closer children

type SequenceElement = 
    | SequenceElement of string
    | SequenceWrapper of opener: string * closer: string * SequenceElement list
    | SequenceWrapperList of SequenceElement list

    interface IYamlConvertible with
        member this.ToYamlAst() = 
            match this with
            | SequenceElement line -> [Yaml.line line]
            | SequenceWrapper (opener, closer, children) ->
                writeYamlASTBasicWrapper opener closer children
            | SequenceWrapperList children ->
                [
                    for child in children do
                        yield! child :> IYamlConvertible |> _.ToYamlAst()
                ]

type ClassDiagramElement = 
    | ClassDiagramElement of string
    | ClassDiagramWrapper of opener: string * closer: string * ClassDiagramElement list
    | ClassDiagramNone

    interface IYamlConvertible with
            
        member this.ToYamlAst() = 
            match this with
            | ClassDiagramElement line -> [Yaml.line line]
            | ClassDiagramWrapper (opener, closer, children) ->
                writeYamlASTBasicWrapper opener closer children
            | ClassDiagramNone -> []

type StateDiagramElement =
    | StateDiagramElement of string
    | StateDiagramWrapper of opener: string * closer: string * StateDiagramElement list
    interface IYamlConvertible with
            
        member this.ToYamlAst() = 
            match this with
            | StateDiagramElement line -> [Yaml.line line]
            | StateDiagramWrapper (opener, closer, children) ->
                writeYamlASTBasicWrapper opener closer children

type ERDiagramElement =
    | ERDiagramElement of string
    | ERDiagramWrapper of opener: string * closer: string * ERDiagramElement list
    interface IYamlConvertible with
            
        member this.ToYamlAst() = 
            match this with
            | ERDiagramElement line -> [Yaml.line line]
            | ERDiagramWrapper (opener, closer, children) ->
                writeYamlASTBasicWrapper opener closer children

type JourneyElement =
    | JourneyElement of string
    interface IYamlConvertible with

        member this.ToYamlAst() = 
            match this with
            | JourneyElement line -> [Yaml.line line]

type GanttElement =
    | GanttElement of string
    interface IYamlConvertible with
            
        member this.ToYamlAst() = 
            match this with
            | GanttElement line -> [Yaml.line line]

type PieChartElement =
    | PieChartElement of string
    interface IYamlConvertible with
            
        member this.ToYamlAst() = 
            match this with
            | PieChartElement line -> [Yaml.line line]

type QuadrantElement =
    | QuadrantElement of string
    interface IYamlConvertible with
            
        member this.ToYamlAst() = 
            match this with
            | QuadrantElement line -> [Yaml.line line]

type RequirementDiagramElement =
    | RequirementDiagramElement of string
    | RequirementDiagramWrapper of opener:string * closer:string * RequirementDiagramElement list
    interface IYamlConvertible with
            
        member this.ToYamlAst() = 
            match this with
            | RequirementDiagramElement line -> [Yaml.line line]
            | RequirementDiagramWrapper (opener, closer, children) ->
                writeYamlASTBasicWrapper opener closer children
        
type GitGraphElement =
    | GitGraphElement of string
    | GitGraphWrapper of opener:string * closer:string * GitGraphElement list
    interface IYamlConvertible with
            
        member this.ToYamlAst() = 
            match this with
            | GitGraphElement line -> [Yaml.line line]
            | GitGraphWrapper (opener, closer, children) ->
                writeYamlASTBasicWrapper opener closer children

type MindmapElement =
    | MindmapElement of string
    | MindmapWrapper of opener:string * closer:string * MindmapElement list
    interface IYamlConvertible with
            
        member this.ToYamlAst() = 
            match this with
            | MindmapElement line -> [Yaml.line line]
            | MindmapWrapper (opener, closer, children) ->
                writeYamlASTBasicWrapper opener closer children

type TimelineElement =
    | TimelineElement of string
    | TimelineWrapper of opener:string * closer:string * TimelineElement list
    interface IYamlConvertible with
            
        member this.ToYamlAst() = 
            match this with
            | TimelineElement line -> [Yaml.line line]
            | TimelineWrapper (opener, closer, children) ->
                writeYamlASTBasicWrapper opener closer children


type BlockElement =
    | BlockElement of string
    | BlockWrapper of opener:string * closer:string * BlockElement list
    | BlockLine of BlockElement list
    interface IYamlConvertible with
            
        member this.ToYamlAst() = 
            match this with
            | BlockElement line -> [Yaml.line line]
            | BlockWrapper (opener, closer, children) ->
                writeYamlASTBasicWrapper opener closer children
            | BlockLine children ->
                children
                |> List.fold (fun acc child -> 
                    match child with
                    | BlockElement line -> acc + " " + line
                    | _ -> acc
                ) ""
                |> _.Trim()
                |> Yaml.line
                |> List.singleton

type SankeyElement =
    | SankeyElement of string
    | SankeyElementList of SankeyElement list
    interface IYamlConvertible with
            
        member this.ToYamlAst() = 
            match this with
            | SankeyElement line -> [Yaml.line line]
            | SankeyElementList elements -> [
                for ele in elements do 
                    yield! ele :> IYamlConvertible |> _.ToYamlAst()
            ]

type XYChartElement =
    | XYChartElement of string
    interface IYamlConvertible with
            
        member this.ToYamlAst() = 
            match this with
            | XYChartElement line -> [Yaml.line line]

[<AttachMembers>]
[<RequireQualifiedAccess>]
type SirenGraph =
| Flowchart of Direction * FlowchartElement list 
| Sequence of SequenceElement list
| Class of ClassDiagramElement list
| State of StateDiagramElement list
| StateV2 of StateDiagramElement list
| ERDiagram of ERDiagramElement list
| Journey of JourneyElement list
| Gantt of GanttElement list
| PieChart of showData:bool * title: string option * PieChartElement list
| Quadrant of QuadrantElement list
| RequirementDiagram of RequirementDiagramElement list
| GitGraph of GitGraphElement list
| Mindmap of MindmapElement list
| Timeline of TimelineElement list
| Sankey of SankeyElement list
| XYChart of isHorizontal:bool * XYChartElement list
| Block of BlockElement list
with 
    member this.ToConfigName() =
        match this with 
        | SirenGraph.Flowchart _ -> "flowchart"
        | SirenGraph.Class _ -> "class"
        | SirenGraph.Sequence _ -> "sequence"
        | SirenGraph.State _
        | SirenGraph.StateV2 _ -> "state"
        | SirenGraph.ERDiagram _ -> "erDiagram"
        | SirenGraph.Journey _ -> "journey"
        | SirenGraph.Gantt _ -> "gantt"
        | SirenGraph.PieChart _ -> "pie"
        | SirenGraph.Quadrant _ -> "quadrant"
        | SirenGraph.RequirementDiagram _ -> "requirement"
        | SirenGraph.GitGraph _ -> "gitGraph"
        | SirenGraph.Mindmap _ -> "mindmap"
        | SirenGraph.Timeline _ -> "timeline"
        | SirenGraph.Sankey _ -> "sankey"
        | SirenGraph.XYChart _ -> "xyChart"
        | SirenGraph.Block _ -> "block"

    member this.ToYamlAst() = 
        match this with
        | SirenGraph.Flowchart (direction, children) ->
            let dia = "flowchart " + direction.ToString()
            writeYamlDiagramRoot dia children
        | SirenGraph.Sequence (children) ->
            let dia = "sequenceDiagram"
            writeYamlDiagramRoot dia children
        | SirenGraph.Class children ->
            let dia = "classDiagram"
            writeYamlDiagramRoot dia children
        | SirenGraph.StateV2 children ->
            let dia = "stateDiagram-v2"
            writeYamlDiagramRoot dia children
        | SirenGraph.State children ->
            let dia = "stateDiagram"
            writeYamlDiagramRoot dia children
        | SirenGraph.ERDiagram children ->
            let dia = "erDiagram"
            writeYamlDiagramRoot dia children
        | SirenGraph.Journey children ->
            let dia = "journey"
            writeYamlDiagramRoot dia children
        | SirenGraph.Gantt children ->
            let dia = "gantt"
            writeYamlDiagramRoot dia children
        | SirenGraph.PieChart (showData, title, children) ->
            let dia = ["pie"; if showData then "showData"; if title.IsSome then sprintf "title %s" title.Value] |> String.concat " "
            writeYamlDiagramRoot dia children
        | SirenGraph.Quadrant children ->
            let dia = "quadrantChart"
            writeYamlDiagramRoot dia children
        | SirenGraph.RequirementDiagram children ->
            let dia = "requirementDiagram"
            writeYamlDiagramRoot dia children
        | SirenGraph.GitGraph children ->
            let dia = "gitGraph"
            writeYamlDiagramRoot dia children
        | SirenGraph.Mindmap children ->
            let dia = "mindmap"
            writeYamlDiagramRoot dia children
        | SirenGraph.Timeline children ->
            let dia = "timeline"
            writeYamlDiagramRoot dia children
        | SirenGraph.Sankey children ->
            let dia = "sankey-beta"
            Yaml.root [
                Yaml.line dia
                for child in children do
                    yield! child :> IYamlConvertible |> _.ToYamlAst()
            ]
        | SirenGraph.XYChart (isHorizontal, children) ->
            let dia = "xychart-beta"  + if isHorizontal then " horizontal" else ""
            writeYamlDiagramRoot dia children
        | SirenGraph.Block children ->
            let dia = "block-beta"
            writeYamlDiagramRoot dia children

open System.Collections.Generic

/// https://mermaid.js.org/config/configuration.html
[<AttachMembers>]
type SirenConfig(graph: SirenGraph, ?title, ?theme, ?graphConfig, ?themeVariable) =
    member val Graph: SirenGraph = graph with get
    member val Title: string option = title with get, set
    member val Theme: string option = theme with get, set
    member val GraphConfig: Dictionary<string, string> option = graphConfig with get, set
    member val ThemeVariables: Dictionary<string, string> option = themeVariable with get, set

    member this.AddGraphConfig(key: string, value: string) =
        match this.GraphConfig with
        | Some config -> config.Add(key, value)
        | None -> 
            let config = new Dictionary<string, string>()
            config.Add(key, value)
            this.GraphConfig <- Some config

    member this.RemoveGraphConfig(key: string) =
        match this.GraphConfig with
        | Some config -> config.Remove(key) |> ignore
        | None -> ()

    member this.AddThemeVariable(key: string, value: string) = 
        match this.ThemeVariables with
        | Some theme -> theme.Add(key, value)
        | None -> 
            let theme = new Dictionary<string, string>()
            theme.Add(key, value)
            this.ThemeVariables <- Some theme

    member this.RemoveThemeVariable(key: string) =
        match this.ThemeVariables with
        | Some theme -> theme.Remove(key) |> ignore
        | None -> ()

    member this.ToYamlAst() = 
        let hasInnerConfig = this.GraphConfig.IsSome || this.ThemeVariables.IsSome || this.Theme.IsSome
        let createInnerConfig () =
            Yaml.root [
                Yaml.line "config:"
                Yaml.level [
                    if this.Theme.IsSome then Yaml.line $"theme: {this.Theme.Value}"
                    match this.GraphConfig with
                    | Some config -> 
                        this.Graph.ToConfigName()
                        |> fun b -> b + ":" 
                        |> Yaml.line
                        Yaml.level [
                            for KeyValue(key, value) in config do
                                yield Yaml.line $"{key}: {value}"
                        ]
                    | None -> ()
                    match this.ThemeVariables with
                    | Some theme -> 
                        Yaml.line "themeVariables:"
                        Yaml.level [
                            for KeyValue(key, value) in theme do
                                yield Yaml.line $"{key}: {value}"
                        ]
                    | None -> ()
                ]
            ]
        Yaml.root [
            if this.Title.IsSome || hasInnerConfig then
                Yaml.line "---"
                if this.Title.IsSome then 
                    Yaml.line $"title: {this.Title.Value}"
                if hasInnerConfig then 
                    createInnerConfig()
                Yaml.line "---"
        ]

    override this.ToString() =
        [
            "Title", this.Title.ToString()
            "Theme", this.Theme.ToString()
            "GraphConfig", this.GraphConfig |> Option.map (fun x -> x.ToString()) |> _.ToString()
            "ThemeVariables", this.ThemeVariables |> Option.map (fun x -> x.ToString()) |> _.ToString()
        ]
        |> List.map (fun (key, value) -> sprintf "%s: %s" key value)
        |> String.concat ",\n"
        |> sprintf "{%s}"
        

type SirenElement = {
    Graph: SirenGraph
    Config: SirenConfig
} with
    static member init(graph: SirenGraph) = {
        Graph = graph
        Config = SirenConfig(graph) 
    }
    member this.withTitle (title: string) =
        this.Config.Title <- Some title
        this

    member this.withTheme (theme: string) =
        this.Config.Theme <- Some theme
        this

    member this.withGraphConfig (config: Dictionary<string, string>) =
        this.Config.GraphConfig <- Some config
        this

    member this.withThemeVariables (themeVariables: Dictionary<string, string>) =
        this.Config.ThemeVariables <- Some themeVariables
        this

    member this.addThemeVariable (key: string, value: string) =
        this.Config.AddThemeVariable(key, value)
        this

    member this.addGraphConfigVariable (key: string, value: string) =
        this.Config.AddGraphConfig(key, value)
        this

    member this.write() =
        Yaml.root [
            this.Config.ToYamlAst()
            this.Graph.ToYamlAst()
        ]
        |> Yaml.write