namespace Siren

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

[<RequireQualifiedAccess>]
type SirenElement =
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