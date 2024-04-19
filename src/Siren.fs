namespace Siren

open Fable.Core

module Option =

    let formatString (format: string -> string) (str: string option) =
        match str with |None -> "" | Some str -> format str

    let defaultBind (mapping: 'A -> 'T) (default': 'T) (opt: 'A option) =
        match opt with
        | Some a -> mapping a
        | None -> default'

[<RequireQualifiedAccess>]
module Yaml =

    open System.Text

    type Config = {
        Whitespace: int
        Level: int
    } with
        static member init(?whitespace) : Config = {
            Whitespace = defaultArg whitespace 4
            Level = 0
        }
        member this.WhitespaceString =
            String.init (this.Level*this.Whitespace) (fun _ -> " ")
    
    type AST =
        | Root of AST list
        | Level of AST list
        | Line of string

        static member write(rootElement:AST, ?fconfig: Config -> Config) =
            let config = Config.init() |> fun config -> if fconfig.IsSome then fconfig.Value config else config
            let sb = new StringBuilder()
            let rec loop (current: AST) (sb: StringBuilder) (config: Config) =
                match current with
                | Line line ->
                    sb.AppendLine(config.WhitespaceString+line) |> ignore
                | Level children ->
                    let nextConfig = {config with Level = config.Level + 1}
                    for child in children do
                        loop child sb nextConfig
                | Root children ->
                    for child in children do
                        loop child sb config
            loop rootElement sb config
            sb.ToString()
            

    let line (line:string) = Line line

    let level (children: #seq<AST>) = List.ofSeq children |> Level 

    let root (children: #seq<AST>) = List.ofSeq children |> Root

    let write rootElement = AST.write(rootElement)

module Types =

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

    type IYamlConvertible =
        abstract ToYamlAst: unit -> Yaml.AST list

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
        | XYChartWrapper of opener:string * closer:string * XYChartElement list
        | XYChartDirection of string

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
    | PieChart of PieChartElement list
    | Quadrant of QuadrantElement list
    | RequirementDiagram of RequirementDiagramElement list
    | GitGraph of GitGraphElement list
    | Mindmap of MindmapElement list
    | Timeline of TimelineElement list
    | Sankey of SankeyElement list
    | XYChart of XYChartElement list

open Types

module Generic =

    type NotePosition =
    | Over
    | RightOf
    | LeftOf
        member this.ToFormatString() =
            match this with
            | Over      -> "over"
            | RightOf   -> "right of"
            | LeftOf    -> "left of"
    
    let formatComment (txt: string) = sprintf "%%%% %s" txt

    let formatDirection (direction: Direction) =
        sprintf "direction %s" (direction.ToString())

    let formatClickHref id url (tooltip:string option) =
        let tooltip = tooltip |> Option.map (fun s -> sprintf " \"%s\"" s) |> Option.defaultValue ""
        sprintf """click %s href "%s"%s""" id url tooltip

    let formatNote (id) (position: NotePosition option) (msg: string) =
        let position = defaultArg position NotePosition.RightOf |> _.ToFormatString()
        sprintf "note %s %s : %s" position id msg

[<AttachMembers>]
type formatting =
    //static member escaped (txt: string) = // idea for escaping for example quotes
    static member unicode (txt: string) = string '"' + txt + string '"'
    static member markdown (txt: string) = "\"`" + txt + "`\""
    static member comment (txt: string) = Generic.formatComment txt

[<AttachMembers>]
type direction =
    static member tb = Direction.TB
    static member td = Direction.TD
    static member bt = Direction.BT
    static member rl = Direction.RL
    static member lr = Direction.LR
    static member topToBottom = direction.tb
    static member topDown = direction.td
    static member bottomToTop = direction.bt
    static member rightToLeft = direction.rl
    static member leftToRight = direction.lr
    static member custom (str: string) = Direction.Custom str

module Flowchart =

    [<RequireQualifiedAccess>]
    type NodeTypes =
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
    type LinkTypes =
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

        static member appendTextOption (txt: string option) (arrow:string) =
            if txt.IsSome then
                sprintf "%s|%s|" arrow txt.Value
            else
                arrow

        member this.AddedLengthLinker (addedLength: int option) =
            let addedLength = defaultArg addedLength 1
            if addedLength < 1 then failwithf "Minimum length of a link was set below 1: %i" addedLength
            let char = this.GetAddLengthChar()
            String.init addedLength (fun i -> char)

        member private this.GetAddLengthChar() =
            match this with
            | Open | Arrow | CircleEdge | CrossEdge | ArrowDouble | CircleDouble | CrossDouble -> "-"
            | Dotted | DottedArrow -> "."
            | Thick | ThickArrow -> "="
            | Invisible -> "~"

    let private formatMinimalNamedNode (id:string) (name:string) = $"{id}[{name}]"

    let private nodeTypeToFormatter (nodetype: NodeTypes) =
        match nodetype with
        | NodeTypes.Default -> fun id name -> formatMinimalNamedNode id name
        | NodeTypes.Round -> fun id name -> $"{id}({name})"
        | NodeTypes.Stadium -> fun id name -> $"{id}([{name}])"
        | NodeTypes.Subroutine -> fun id name -> $"{id}[[{name}]]"
        | NodeTypes.Cylindrical -> fun id name -> $"{id}[({name})]"
        | NodeTypes.Circle -> fun id name -> $"{id}(({name}))"
        | NodeTypes.Asymmetric -> fun id name -> $"{id}>{name}]"
        | NodeTypes.Rhombus -> fun id name -> sprintf "%s{%s}" id name
        | NodeTypes.Hexagon -> fun id name -> sprintf "%s{{%s}}" id name
        | NodeTypes.Parallelogram -> fun id name -> sprintf "%s[/%s/]" id name
        | NodeTypes.ParallelogramAlt -> fun id name -> sprintf "%s[\%s\]" id name
        | NodeTypes.Trapezoid -> fun id name -> sprintf "%s[/%s\]" id name
        | NodeTypes.TrapezoidAlt -> fun id name -> sprintf "%s[\%s/]" id name
        | NodeTypes.DoubleCircle -> fun id name -> sprintf "%s(((%s)))" id name

    let formatNode (id: string) (name: string option) (shape: NodeTypes) =
        let formatter = nodeTypeToFormatter shape
        let name = defaultArg name id
        formatter id name

    let private formatLinkType (link: LinkTypes) (msg: string option) (addedLength: int option) =
        match link with
        | LinkTypes.Arrow -> $"-{link.AddedLengthLinker(addedLength)}>" 
        | LinkTypes.Open -> $"-{link.AddedLengthLinker(addedLength)}-"
        | LinkTypes.Dotted -> $"-{link.AddedLengthLinker(addedLength)}-"
        | LinkTypes.DottedArrow -> $"-{link.AddedLengthLinker(addedLength)}->"
        | LinkTypes.Thick -> $"={link.AddedLengthLinker(addedLength)}="
        | LinkTypes.ThickArrow -> $"={link.AddedLengthLinker(addedLength)}>"
        | LinkTypes.Invisible -> $"~{link.AddedLengthLinker(addedLength)}~"
        | LinkTypes.CircleEdge -> $"-{link.AddedLengthLinker(addedLength)}o"
        | LinkTypes.CrossEdge -> $"-{link.AddedLengthLinker(addedLength)}x"
        | LinkTypes.ArrowDouble -> $"<-{link.AddedLengthLinker(addedLength)}>"
        | LinkTypes.CircleDouble -> $"o-{link.AddedLengthLinker(addedLength)}o"
        | LinkTypes.CrossDouble -> $"x-{link.AddedLengthLinker(addedLength)}x"
        |> LinkTypes.appendTextOption msg

    let formatLink (n1: string) (n2: string) (link: LinkTypes) (msg: string option) (addedLength: int option) =
        let link = formatLinkType link msg addedLength
        n1 + link + n2

    let formatSubgraph (id) (name: string option) = 
        let nameStr = if name.IsSome then sprintf "[%s]" name.Value else ""
        let opener = sprintf "subgraph %s%s" id nameStr 
        opener



[<AttachMembers>]
type flowchart =
    static member raw (txt: string) = FlowchartElement txt
    static member id (txt: string) = FlowchartElement txt
    static member node (id: string, ?name: string) : FlowchartElement = Flowchart.formatNode id name Flowchart.NodeTypes.Default |> FlowchartElement
    static member nodeRound (id: string, ?name: string) : FlowchartElement = Flowchart.formatNode id name Flowchart.NodeTypes.Round |> FlowchartElement
    static member nodeStadium (id: string, ?name: string) : FlowchartElement = Flowchart.formatNode id name Flowchart.NodeTypes.Stadium |> FlowchartElement
    static member nodeSubroutine (id: string, ?name: string) : FlowchartElement = Flowchart.formatNode id name Flowchart.NodeTypes.Subroutine |> FlowchartElement
    static member nodeCylindrical  (id: string, ?name: string) : FlowchartElement = Flowchart.formatNode id name Flowchart.NodeTypes.Cylindrical |> FlowchartElement
    static member nodeCircle (id: string, ?name: string) : FlowchartElement = Flowchart.formatNode id name Flowchart.NodeTypes.Circle |> FlowchartElement
    static member nodeAsymmetric (id: string, ?name: string) : FlowchartElement = Flowchart.formatNode id name Flowchart.NodeTypes.Asymmetric |> FlowchartElement
    static member nodeRhombus (id: string, ?name: string) : FlowchartElement = Flowchart.formatNode id name Flowchart.NodeTypes.Rhombus |> FlowchartElement
    static member nodeHexagon (id: string, ?name: string) : FlowchartElement = Flowchart.formatNode id name Flowchart.NodeTypes.Hexagon |> FlowchartElement
    static member nodeParallelogram (id: string, ?name: string) : FlowchartElement = Flowchart.formatNode id name Flowchart.NodeTypes.Parallelogram |> FlowchartElement
    static member nodeParallelogramAlt (id: string, ?name: string) : FlowchartElement = Flowchart.formatNode id name Flowchart.NodeTypes.ParallelogramAlt |> FlowchartElement
    static member nodeTrapezoid (id: string, ?name: string) : FlowchartElement = Flowchart.formatNode id name Flowchart.NodeTypes.Trapezoid |> FlowchartElement
    static member nodeTrapezoidAlt (id: string, ?name: string) : FlowchartElement = Flowchart.formatNode id name Flowchart.NodeTypes.TrapezoidAlt |> FlowchartElement
    static member nodeDoubleCircle (id: string, ?name: string) : FlowchartElement = Flowchart.formatNode id name Flowchart.NodeTypes.DoubleCircle |> FlowchartElement
    static member linkArrow (id1: string, id2: string, ?message: string, ?addedLength) = Flowchart.formatLink id1 id2 Flowchart.LinkTypes.Arrow message addedLength |> FlowchartElement
    static member linkArrowDouble (id1: string, id2: string, ?message: string, ?addedLength) = Flowchart.formatLink id1 id2 Flowchart.LinkTypes.ArrowDouble message addedLength |> FlowchartElement
    static member linkOpen (id1: string, id2: string, ?message: string, ?addedLength) = Flowchart.formatLink id1 id2 Flowchart.LinkTypes.Open message addedLength |> FlowchartElement
    static member linkDotted (id1: string, id2: string, ?message: string, ?addedLength) = Flowchart.formatLink id1 id2 Flowchart.LinkTypes.Dotted message addedLength |> FlowchartElement
    static member linkDottedArrow (id1: string, id2: string, ?message: string, ?addedLength) = Flowchart.formatLink id1 id2 Flowchart.LinkTypes.DottedArrow message addedLength |> FlowchartElement
    static member linkThick (id1: string, id2: string, ?message: string, ?addedLength) = Flowchart.formatLink id1 id2 Flowchart.LinkTypes.Thick message addedLength |> FlowchartElement
    static member linkThickArrow (id1: string, id2: string, ?message: string, ?addedLength) = Flowchart.formatLink id1 id2 Flowchart.LinkTypes.ThickArrow message addedLength |> FlowchartElement
    static member linkInvisible (id1: string, id2: string, ?message: string, ?addedLength) = Flowchart.formatLink id1 id2 Flowchart.LinkTypes.Invisible message addedLength |> FlowchartElement
    static member linkCircleEdge (id1: string, id2: string, ?message: string, ?addedLength) = Flowchart.formatLink id1 id2 Flowchart.LinkTypes.CircleEdge message addedLength |> FlowchartElement
    static member linkCircleDouble (id1: string, id2: string, ?message: string, ?addedLength) = Flowchart.formatLink id1 id2 Flowchart.LinkTypes.CircleDouble message addedLength |> FlowchartElement
    static member linkCrossEdge (id1: string, id2: string, ?message: string, ?addedLength) = Flowchart.formatLink id1 id2 Flowchart.LinkTypes.CrossEdge message addedLength |> FlowchartElement
    static member linkCrossDouble (id1: string, id2: string, ?message: string, ?addedLength) = Flowchart.formatLink id1 id2 Flowchart.LinkTypes.CrossDouble message addedLength |> FlowchartElement
    static member direction (direction: Direction) = Generic.formatDirection direction |> FlowchartElement
    static member directionTB = Generic.formatDirection Direction.TB |> FlowchartElement
    static member directionTD = Generic.formatDirection Direction.TD |> FlowchartElement
    static member directionBT = Generic.formatDirection Direction.BT |> FlowchartElement
    static member directionRL = Generic.formatDirection Direction.RL |> FlowchartElement
    static member directionLR = Generic.formatDirection Direction.LR |> FlowchartElement
    static member subgraphNamed (id: string, name: string, children: #seq<FlowchartElement>) = FlowchartSubgraph (Flowchart.formatSubgraph id (Some name),"end",List.ofSeq children)
    static member subgraph (id: string, children: #seq<FlowchartElement>) = FlowchartSubgraph (Flowchart.formatSubgraph id None ,"end",List.ofSeq children)
    static member clickHref(id: string, url: string, ?tooltip: string) = Generic.formatClickHref id url tooltip |> FlowchartElement
    static member comment(txt:string) = Generic.formatComment txt |> FlowchartElement
    //static member clickCallback() = failwith "TODO"

module Sequence =

    [<RequireQualifiedAccess>]
    type MessageTypes =
        | Solid
        | Dotted
        | Arrow
        | DottedArrow
        | CrossEdge
        | DottedCrossEdge
        | OpenArrow
        | DottedOpenArrow

    let private formatMessageType (msgType: MessageTypes) =
        match msgType with
        | MessageTypes.Solid             -> "->"
        | MessageTypes.Dotted            -> "-->"
        | MessageTypes.Arrow             -> "->>"
        | MessageTypes.DottedArrow       -> "-->>"
        | MessageTypes.CrossEdge         -> "-x"
        | MessageTypes.DottedCrossEdge   -> "--x"
        | MessageTypes.OpenArrow         -> "-)"
        | MessageTypes.DottedOpenArrow   -> "--)"

    let formatMessage a1 a2 type' msg (activate: bool option) =
        let active = match activate with |None -> "" | Some true -> "+"| Some false -> "-"
        sprintf "%s%s%s%s: %s" a1 (formatMessageType type') active a2 msg

    let formatParticipant (name) (alias: string option) =
        let alias = alias |> Option.formatString (fun s -> sprintf " as %s" s) 
        sprintf "participant %s%s" name alias

    let formatActor (name) (alias: string option) =
        let alias = alias |> Option.formatString (fun s -> sprintf " as %s" s) 
        sprintf "actor %s%s" name alias

    let formatCreate (formatter: string -> string option -> string) name alias =
        sprintf "create %s" (formatter name alias)

    let formatDestroy (id: string) = sprintf "destroy %s" id

    let formatBox name (color: string option) = 
        let color = color |> Option.formatString (sprintf "%s ")
        sprintf "box %s%s" color name

    let formatNoteSpanning id1 id2 (position: Generic.NotePosition option) (msg: string) =
        let position = defaultArg position Generic.NotePosition.RightOf |> _.ToFormatString()
        sprintf "note %s %s,%s : %s" position id1 id2 msg

    let [<Literal>] BoxCloser = "end"

[<AttachMembers>]
type notePosition =
    static member over = Generic.NotePosition.Over
    static member rightOf = Generic.NotePosition.RightOf
    static member leftOf = Generic.NotePosition.LeftOf

[<AttachMembers>]
type sequence =
    static member raw (txt: string) = SequenceElement txt
    static member participant (name: string, ?alias) = Sequence.formatParticipant name alias |> SequenceElement 
    static member actor (name: string, ?alias) = Sequence.formatActor name alias |> SequenceElement 
    static member createParticipant (name: string, ?alias) = Sequence.formatCreate Sequence.formatParticipant name alias |> SequenceElement
    static member createActor (name: string, ?alias) = Sequence.formatCreate Sequence.formatActor name alias |> SequenceElement
    static member destroy (id: string) = Sequence.formatDestroy id |> SequenceElement
    static member box (name: string, children: #seq<SequenceElement>) = SequenceWrapper (Sequence.formatBox name None, Sequence.BoxCloser, List.ofSeq children)
    static member boxColored (name: string, color: string, children: #seq<SequenceElement>) = SequenceWrapper (Sequence.formatBox name (Some color), Sequence.BoxCloser, List.ofSeq children)
    static member message(a1, a2, message, ?activate: bool) = Sequence.formatMessage a1 a2 Sequence.MessageTypes.Solid message activate |> SequenceElement 
    static member messageSolid(a1, a2, message, ?activate: bool) = Sequence.formatMessage a1 a2 Sequence.MessageTypes.Solid message activate |> SequenceElement 
    static member messageDotted(a1, a2, message, ?activate: bool ) = Sequence.formatMessage a1 a2 Sequence.MessageTypes.Dotted message activate |> SequenceElement 
    static member messageArrow(a1, a2, message, ?activate: bool) = Sequence.formatMessage a1 a2 Sequence.MessageTypes.Arrow message activate |> SequenceElement 
    static member messageDottedArrow(a1, a2, message, ?activate: bool) = Sequence.formatMessage a1 a2 Sequence.MessageTypes.DottedArrow message activate |> SequenceElement 
    static member messageCross(a1, a2, message, ?activate: bool) = Sequence.formatMessage a1 a2 Sequence.MessageTypes.CrossEdge message activate |> SequenceElement 
    static member messageDottedCross(a1, a2, message, ?activate: bool) = Sequence.formatMessage a1 a2 Sequence.MessageTypes.DottedCrossEdge message activate |> SequenceElement 
    static member messageOpenArrow(a1, a2, message, ?activate: bool) = Sequence.formatMessage a1 a2 Sequence.MessageTypes.OpenArrow message activate |> SequenceElement 
    static member messageDottedOpenArrow(a1, a2, message, ?activate: bool) = Sequence.formatMessage a1 a2 Sequence.MessageTypes.DottedOpenArrow message activate |> SequenceElement 
    static member activate(id: string) = sprintf "activate %s" id |> SequenceElement
    static member deactivate(id: string) = sprintf "deactivate %s" id |> SequenceElement
    static member note(id: string, text: string, ?notePosition: Generic.NotePosition) = Generic.formatNote id notePosition text |> SequenceElement
    static member noteSpanning(id1: string, id2, text: string, ?notePosition: Generic.NotePosition) = Sequence.formatNoteSpanning id1 id2 notePosition text |> SequenceElement
    static member loop(name: string, children: #seq<SequenceElement>) = SequenceWrapper(sprintf "loop %s" name,"end", List.ofSeq children)
    static member alt(name: string, children: #seq<SequenceElement>, elseList: #seq<string*#seq<SequenceElement>>) = 
        let elseItems = elseList |> Seq.length
        let altCloser = if elseItems = 0 then "end" else ""
        let last = elseItems-1 
        SequenceWrapperList [
            SequenceWrapper (sprintf "alt %s" name, altCloser, List.ofSeq children)
            if elseItems <> 0 then 
                for i in 0 .. last do
                    let name, children = elseList |> Seq.item i
                    let closer = if i = last then "end" else ""
                    SequenceWrapper(sprintf "else %s" name, closer, List.ofSeq children)                
        ]
    static member opt(name: string, children: #seq<SequenceElement>) = SequenceWrapper (sprintf "opt %s" name, "end", List.ofSeq children)
    static member par(name: string, children: #seq<SequenceElement>, andList: #seq<string*#seq<SequenceElement>>) = 
        let elseItems = andList |> Seq.length
        let altCloser = if elseItems = 0 then "end" else ""
        let last = elseItems-1 
        SequenceWrapperList [
            SequenceWrapper (sprintf "par %s" name, altCloser, List.ofSeq children)
            if elseItems <> 0 then 
                for i in 0 .. last do
                    let name, children = andList |> Seq.item i
                    let closer = if i = last then "end" else ""
                    SequenceWrapper(sprintf "and %s" name, closer, List.ofSeq children)                
        ]
    static member critical(name: string, children: #seq<SequenceElement>, optionList: #seq<string*#seq<SequenceElement>>) = 
        let elseItems = optionList |> Seq.length
        let altCloser = if elseItems = 0 then "end" else ""
        let last = elseItems-1 
        SequenceWrapperList [
            SequenceWrapper (sprintf "critical %s" name, altCloser, List.ofSeq children)
            if elseItems <> 0 then 
                for i in 0 .. last do
                    let name, children = optionList |> Seq.item i
                    let closer = if i = last then "end" else ""
                    SequenceWrapper(sprintf "option %s" name, closer, List.ofSeq children)                
        ]
    static member breakSeq (name: string, children: #seq<SequenceElement>) = SequenceWrapper (sprintf "break %s" name, "end", List.ofSeq children)
    static member rect (color: string, children: #seq<SequenceElement>) = SequenceWrapper (sprintf "rect %s" color, "end", List.ofSeq children)
    static member comment (txt: string) = Generic.formatComment txt |> SequenceElement
    static member autoNumber = SequenceElement "autonumber"
    static member link (id: string, urlLabel: string, url: string) = sprintf "link %s: %s @ %s" id urlLabel url |> SequenceElement
    static member links (id: string, urls: #seq<string*string>) = 
        let json0 = urls |> List.ofSeq |> List.map (fun (k,v) -> sprintf "\"%s\": \"%s\"" k v) |> String.concat ", "
        let json = "{" + json0 + "}"
        sprintf "links %s: %s" id json |> SequenceElement

module ClassDiagram =
    type MemberVisibility =
    | Public
    | Private
    | Protected
    | PackageInternal
    | Custom of string
        member this.ToFormatString() =
            match this with
            | Public            -> "+"
            | Private           -> "-"
            | Protected         -> "#"
            | PackageInternal   -> "~"
            | Custom string     -> string
    type MemberClassifier = 
    | Abstract
    | Static
    | Custom of string
        member this.ToFormatString() =
            match this with
            | Abstract      -> "*"
            | Static        -> "$"
            | Custom string -> string

    type ClassRelationshipDirection =
    | Left
    | Right
    | TwoWay
        member this.ToFormatString(left: string, right: string, center: string) =
            match this with
            | Left  -> left + center
            | Right -> center + right
            | TwoWay -> left + center + right
        member this.ToFormatString(edge: string, center: string) =
            match this with
            | Left  -> edge + center
            | Right -> center + edge
            | TwoWay -> edge + center + edge

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

        member this.ToFormatString(?direction: ClassRelationshipDirection, ?isDotted: bool) =
            let isDotted = defaultArg isDotted false
            let dotted = ".."
            let solid = "--"
            let center = if isDotted then dotted else solid
            let direct = defaultArg direction ClassRelationshipDirection.Right
            match this with
            | Inheritance   -> direct.ToFormatString("<|", "|>", center)
            | Composition   -> direct.ToFormatString("*",center)
            | Aggregation   -> direct.ToFormatString("o", center)
            | Association   -> direct.ToFormatString("<",">", center)
            | Link          -> center
            | Solid         -> solid
            | Dashed        -> dotted
            | Dependency    -> direct.ToFormatString("<",">", dotted)
            | Realization   -> direct.ToFormatString("<|","|>", dotted)

    type Cardinality = 
        | One
        | ZeroOrOne
        | OneOrMore
        | Many
        | N
        | ZeroToN
        | OneToN
        | Custom of string

        member this.ToFormatString() =
            match this with
            | One       -> "1"
            | ZeroOrOne -> "0..1"
            | OneOrMore -> "1..*"
            | Many      -> "*"
            | N         -> "n"
            | ZeroToN   -> "0..n"
            | OneToN    -> "1..n"
            | Custom s  -> s

    let formatClass (id) (name) generic =
        let name = name |> Option.formatString (fun s -> sprintf "[\"%s\"]" s)
        let generic = generic |> Option.formatString (fun s -> sprintf "~%s~" s)
        sprintf "class %s%s%s" id generic name

    let formatMember id label (visibility: MemberVisibility option) (classifier: MemberClassifier option) =
        let visibility = visibility |> Option.map _.ToFormatString() |> Option.formatString (fun x -> x)
        let classifier = classifier |> Option.map _.ToFormatString() |> Option.formatString (fun x -> x)
        sprintf "%s : %s%s%s" id visibility label classifier

    let formatRelationship0 id1 id2 (link: string) (label: string option) (cardinality1: Cardinality option) (cardinality2: Cardinality option) =
        //classI -- classJ : Link(Solid)
        //Student "1" --> "1..*" Course
        let car1 = cardinality1 |> Option.map _.ToFormatString() |> Option.formatString (fun s -> sprintf " \"%s\"" s)
        let car2 = cardinality2 |> Option.map _.ToFormatString() |> Option.formatString (fun s -> sprintf "\"%s\" " s)
        let label = label |> Option.formatString (fun l -> sprintf " : %s" l)
        sprintf "%s%s %s %s%s%s" id1 car1 link car2 id2 label

    let formatRelationship id1 id2 (type': ClassRelationshipType) (label: string option) (cardinality1: Cardinality option) (cardinality2: Cardinality option) =
        let link = type'.ToFormatString()
        formatRelationship0 id1 id2 link label cardinality1 cardinality2

    let formatRelationshipCustom id1 id2 (type': ClassRelationshipType) (direction) (dotted) (label: string option) (cardinality1: Cardinality option) (cardinality2: Cardinality option) =
        let link = type'.ToFormatString(?direction=direction, ?isDotted=dotted)
        formatRelationship0 id1 id2 link label cardinality1 cardinality2

    let formatAnnotation id (annotation: string) = sprintf "<<%s>> %s" annotation id

    let formatNote txt (id: string option) =
        if id.IsSome then
            sprintf "note for %s \"%s\"" id.Value txt
        else
            sprintf "note \"%s\"" txt


[<AttachMembers>]
type memberVisibility =
    static member public' = ClassDiagram.MemberVisibility.Public
    static member private' = ClassDiagram.MemberVisibility.Private
    static member protected' = ClassDiagram.MemberVisibility.Protected
    static member packageInternal = ClassDiagram.MemberVisibility.PackageInternal
    static member custom str = ClassDiagram.MemberVisibility.Custom str

[<AttachMembers>]
type memberClassifier =
    static member abstract' = ClassDiagram.MemberClassifier.Abstract
    static member static' = ClassDiagram.MemberClassifier.Static
    static member custom str = ClassDiagram.MemberClassifier.Custom str

[<AttachMembers>]
type classDiagram =
    static member raw (txt: string) = ClassDiagramElement txt
    static member class' (id: string, ?name: string, ?generic: string, ?members: #seq<string>) = 
        if members.IsSome then ClassDiagramWrapper (ClassDiagram.formatClass id name generic + "{","}", (List.ofSeq >> List.map ClassDiagramElement) members.Value) 
        else ClassDiagram.formatClass id name generic |> ClassDiagramElement
    static member classMember (id: string, label:string, ?visibility: ClassDiagram.MemberVisibility, ?classifier: ClassDiagram.MemberClassifier) = 
        ClassDiagram.formatMember id label visibility classifier |> ClassDiagramElement
    
    static member relationshipInheritance (id1, id2, ?label: string, ?cardinality1: ClassDiagram.Cardinality, ?cardinality2: ClassDiagram.Cardinality) = 
        ClassDiagram.formatRelationship id1 id2 ClassDiagram.ClassRelationshipType.Inheritance label cardinality1 cardinality2 |> ClassDiagramElement
    static member relationshipComposition (id1, id2, ?label: string, ?cardinality1: ClassDiagram.Cardinality, ?cardinality2: ClassDiagram.Cardinality) = 
        ClassDiagram.formatRelationship id1 id2 ClassDiagram.ClassRelationshipType.Composition label cardinality1 cardinality2 |> ClassDiagramElement
    static member relationshipAggregation (id1, id2, ?label: string, ?cardinality1: ClassDiagram.Cardinality, ?cardinality2: ClassDiagram.Cardinality) = 
        ClassDiagram.formatRelationship id1 id2 ClassDiagram.ClassRelationshipType.Aggregation label cardinality1 cardinality2 |> ClassDiagramElement
    static member relationshipAssociation (id1, id2, ?label: string, ?cardinality1: ClassDiagram.Cardinality, ?cardinality2: ClassDiagram.Cardinality) = 
        ClassDiagram.formatRelationship id1 id2 ClassDiagram.ClassRelationshipType.Association label cardinality1 cardinality2 |> ClassDiagramElement
    static member relationshipSolid (id1, id2, ?label: string, ?cardinality1: ClassDiagram.Cardinality, ?cardinality2: ClassDiagram.Cardinality) = 
        ClassDiagram.formatRelationship id1 id2 ClassDiagram.ClassRelationshipType.Solid label cardinality1 cardinality2 |> ClassDiagramElement
    static member relationshipDependency (id1, id2, ?label: string, ?cardinality1: ClassDiagram.Cardinality, ?cardinality2: ClassDiagram.Cardinality) = 
        ClassDiagram.formatRelationship id1 id2 ClassDiagram.ClassRelationshipType.Dependency label cardinality1 cardinality2 |> ClassDiagramElement
    static member relationshipRealization (id1, id2, ?label: string, ?cardinality1: ClassDiagram.Cardinality, ?cardinality2: ClassDiagram.Cardinality) = 
        ClassDiagram.formatRelationship id1 id2 ClassDiagram.ClassRelationshipType.Realization label cardinality1 cardinality2 |> ClassDiagramElement
    static member relationshipDashed (id1, id2, ?label: string, ?cardinality1: ClassDiagram.Cardinality, ?cardinality2: ClassDiagram.Cardinality) = 
        ClassDiagram.formatRelationship id1 id2 ClassDiagram.ClassRelationshipType.Dashed label cardinality1 cardinality2 |> ClassDiagramElement
    static member relationshipCustom (id1, id2, rltsType, ?label: string, ?direction, ?isDotted, ?cardinality1: ClassDiagram.Cardinality, ?cardinality2: ClassDiagram.Cardinality) = 
        ClassDiagram.formatRelationshipCustom id1 id2 rltsType direction isDotted label cardinality1 cardinality2 |> ClassDiagramElement

    static member namespace' (name: string, children: #seq<ClassDiagramElement>) =
        if Seq.isEmpty children then ClassDiagramNone 
        else ClassDiagramWrapper (sprintf "namespace %s {" name,"}", List.ofSeq children)
    static member annotation (id: string, annotation: string) = classDiagram.annotationString (id, annotation)
    static member annotationString (id: string, annotation: string) : string = ClassDiagram.formatAnnotation id annotation
    static member comment (txt:string) = Generic.formatComment txt
    static member direction (direction: Direction) = Generic.formatDirection direction |> ClassDiagramElement
    static member clickHref(id,url,?tooltip) = Generic.formatClickHref id url tooltip |> ClassDiagramElement
    //static member clickCallback() = failwith "TODO"
    static member note(txt:string, ?id: string) = ClassDiagram.formatNote txt id |> ClassDiagramElement
    static member link(id: string, url: string, ?tooltip: string) = Generic.formatClickHref id url tooltip |> ClassDiagramElement
    //static member callback(id: string, func: unit -> unit, ?tooltip: string) = failwith "TODO"

module StateDiagram =

    let formatState id (description: string option) = 
        let description = description |> Option.formatString (fun s -> sprintf " : %s" s)
        sprintf "%s%s" id description

    let formatTransition id1 id2 (description: string option) =
        let description = description |> Option.formatString (fun s -> sprintf " : %s" s)
        sprintf "%s --> %s%s" id1 id2 description

    let formatNoteWrapper (id) (position: Generic.NotePosition option) =
        let position = defaultArg position Generic.RightOf |> _.ToFormatString()
        sprintf "note %s %s" position id


[<AttachMembers>]
type stateDiagram =
    static member state (id: string, ?description: string) = StateDiagram.formatState id description |> StateDiagramElement 
    static member transition (id1: string, id2: string, ?description: string) = StateDiagram.formatTransition id1 id2 description |> StateDiagramElement
    static member transitionStart (id: string, ?description: string) = StateDiagram.formatTransition stateDiagram.startEnd id description |> StateDiagramElement
    static member transitionEnd (id: string, ?description: string) = StateDiagram.formatTransition id stateDiagram.startEnd description |> StateDiagramElement
    static member startEnd : string = "[*]"
    static member stateComposite (id: string, children: #seq<StateDiagramElement>) = StateDiagramWrapper (sprintf "state %s {" id,"}", List.ofSeq children)
    static member stateChoice (id: string) = sprintf "state %s <<choice>>" id |> StateDiagramElement
    static member stateFork (id: string) = sprintf "state %s <<fork>>" id |> StateDiagramElement
    static member stateJoin (id: string) = sprintf "state %s <<join>>" id |> StateDiagramElement
    static member note (id: string, msg: string, ?notePosition: Generic.NotePosition) = 
        if notePosition.IsSome && notePosition.Value = Generic.NotePosition.Over then failwith "Error: Cannot use \"over\" for note in State Diagram!"
        let lines = msg.Split([|"\r\n"; "\n";|], System.StringSplitOptions.RemoveEmptyEntries)
        StateDiagramWrapper(StateDiagram.formatNoteWrapper id notePosition, "end note", [for line in lines do StateDiagramElement line])
    static member noteMultiLine (id: string, lines: #seq<string>, ?notePosition: Generic.NotePosition) = 
        if notePosition.IsSome && notePosition.Value = Generic.NotePosition.Over then failwith "Error: Cannot use \"over\" for note in State Diagram!"
        //let lines = msg.Split([|"\r\n"; "\n";|], System.StringSplitOptions.RemoveEmptyEntries)
        StateDiagramWrapper(StateDiagram.formatNoteWrapper id notePosition, "end note", [for line in lines do StateDiagramElement line])
    static member noteLine (id: string, msg: string, ?notePosition: Generic.NotePosition) = 
        if notePosition.IsSome && notePosition.Value = Generic.NotePosition.Over then failwith "Error: Cannot use \"over\" for note in State Diagram!"
        Generic.formatNote id notePosition msg |> StateDiagramElement
    /// Can only be used in stateComposite
    static member concurrency = StateDiagramElement "--" 
    static member direction (direction: Direction) = Generic.formatDirection direction |> StateDiagramElement
    static member comment (txt: string) = Generic.formatComment txt |> StateDiagramElement

[<RequireQualifiedAccess>]
type IERCardinalityType = 
    | OneOrZero
    | OneOrMany
    | ZeroOrMany
    | OnlyOne
    member this.ToFormatString() =
        match this with
        | OneOrZero -> "one or zero"
        | OneOrMany -> "one or many"
        | ZeroOrMany -> "zero or many"
        | OnlyOne -> "only one"

[<RequireQualifiedAccess>]
type IERKeyType = 
    | PK
    | FK
    | UK
[<RequireQualifiedAccess>]
type IERAttribute = {
    Type : string
    Name : string
    Keys : IERKeyType list
    Comment: string option
} 

module ERDiagram =

    let formatEntityNode (id) (alias: string option) =
        let alias = alias |> Option.formatString (fun s -> sprintf "[\"%s\"]" s)
        sprintf "%s%s" id alias

    let formatEntityWrapper (id) (alias: string option) =
        formatEntityNode id alias + " {"

    let formatAttribute (attr:IERAttribute) =
        let keys = attr.Keys |> List.map _.ToString() |> String.concat ", "
        let comment = attr.Comment |> Option.formatString (fun s -> sprintf "\"%s\"" s)
        [
            attr.Type
            attr.Name
            keys
            comment
        ]
        |> List.filter (fun s -> s <> "")
        |> String.concat " "

    let formatRelationship (id1) (card1: IERCardinalityType) id2 (card2: IERCardinalityType) msg (isOptional: bool option) =
        let isOptional = defaultArg isOptional false
        let toString = if isOptional then "optionally to" else "to"
        sprintf "%s %s %s %s %s : %s" id1 (card1.ToFormatString()) toString (card2.ToFormatString()) id2 msg
        
[<AttachMembers>]
type erKey =
    static member pk = IERKeyType.PK
    static member fk = IERKeyType.FK
    static member uk = IERKeyType.UK

type erCardinality =
    /// <summary>
    /// }| or |{
    /// </summary>
    /// <param name="oneOrZero"></param>
    static member oneOrMany = IERCardinalityType.OneOrMany
    /// <summary>
    /// |o or o|
    /// </summary>
    /// <param name="oneOrZero"></param>
    static member oneOrZero = IERCardinalityType.OneOrZero
    /// <summary>
    /// ||
    /// </summary>
    /// <param name="oneOrMany"></param>
    static member onlyOne = IERCardinalityType.OnlyOne
    /// <summary>
    /// }o or o{
    /// </summary>
    /// <param name="zeroOrMany"></param>
    static member zeroOrMany = IERCardinalityType.ZeroOrMany
    

[<AttachMembers>]
type erDiagram =
    static member raw (line: string) = ERDiagramElement line
    static member entity (id: string, ?alias: string, ?attr: #seq<IERAttribute>) = 
        if attr.IsSome then 
            let children = [for attr in attr.Value do ERDiagram.formatAttribute attr |> ERDiagramElement] // of attributes
            ERDiagramWrapper (ERDiagram.formatEntityWrapper id alias, "}", children) 
        else ERDiagram.formatEntityNode id alias |> ERDiagramElement
    static member relationship(id1, erCardinality1, id2, erCardinality2, message, ?isOptional: bool) = 
        ERDiagram.formatRelationship id1 erCardinality1 id2 erCardinality2 message isOptional |> ERDiagramElement
    static member attribute(type': string, name: string, ?keys: #seq<IERKeyType>, ?comment: string) : IERAttribute = 
        {Type=type'; Name=name;Keys=Option.map List.ofSeq keys |> Option.defaultValue []; Comment = comment}

module UserJourney =

    let formatTask name score actors =
        let actors = actors |> Option.map (String.concat ", ")
        List.choose id [
            Some name
            Some (string score)
            actors
        ]
        |> String.concat ": "

[<AttachMembers>]
type journey =
    static member raw (line: string) = JourneyElement line
    static member title (name: string) = sprintf "title %s" name |> JourneyElement
    static member section (name: string) = sprintf "section %s" name |> JourneyElement
    static member task (name: string, score: int, ?actors: #seq<string>) = UserJourney.formatTask name score actors |> JourneyElement

[<RequireQualifiedAccess>]
type IGanttTags = 
| Active
| Done
| Crit
| Milestone
    member this.ToFormatString() =
        match this with
        | Active    -> "active"
        | Done      -> "done"
        | Crit      -> "crit"
        | Milestone -> "milestone"

[<RequireQualifiedAccess>]
type IGanttUnit =
| Millisecond
| Second
| Minute
| Hour
| Day
| Week
| Month
    member this.ToFormatString() =
        string this |> _.ToLower()

module Gantt =

    let formatTask title (tags: IGanttTags list) (selfid: string option) (startDate: string option) (endDate: string option) =
        let tags = tags |> Seq.map (fun x -> x.ToFormatString() |> Some) |> Seq.distinct 
        let metadata =
            [
                yield! tags
                selfid
                startDate
                endDate
            ]
            |> List.choose id
            |> String.concat ", "
        sprintf "%s : %s" title metadata

[<AttachMembers>]
type ganttTime =
    static member length (timespan: string) : string = timespan
    static member dateTime (datetime: string) : string = datetime
    static member after (id) : string = sprintf "after %s" id
    static member until (id) : string = sprintf "until %s" id

[<AttachMembers>]
type ganttTags =
    static member active = IGanttTags.Active
    static member done' = IGanttTags.Done
    static member crit = IGanttTags.Crit
    static member milestone = IGanttTags.Milestone

[<AttachMembers>]
type ganttUnit =
    static member millisecond = IGanttUnit.Millisecond
    static member second = IGanttUnit.Second
    static member minute = IGanttUnit.Minute
    static member hour = IGanttUnit.Hour
    static member day = IGanttUnit.Day
    static member week = IGanttUnit.Week
    static member month = IGanttUnit.Month

[<AttachMembers>]
type gantt =
    static member raw (line: string) = GanttElement line
    static member title (name: string) = sprintf "title %s" name |> GanttElement
    static member section (name: string) = sprintf "section %s" name |> GanttElement

    static member task (title: string, id: string, startDate:string, endDate: string, ?tags: #seq<IGanttTags>) = 
        Gantt.formatTask title (Option.defaultBind List.ofSeq [] tags) (Some id) (Some startDate) (Some endDate) |> GanttElement
    static member taskStartEnd (title: string, startDate:string, endDate: string, ?tags: #seq<IGanttTags>) = 
        Gantt.formatTask title (Option.defaultBind List.ofSeq [] tags) (None) (Some startDate) (Some endDate) |> GanttElement
    static member taskEnd (title: string, endDate: string, ?tags: #seq<IGanttTags>) = 
        Gantt.formatTask title (Option.defaultBind List.ofSeq [] tags) (None) (None) (Some endDate) |> GanttElement

    static member milestone (title: string, id: string, startDate:string, endDate: string, ?tags: #seq<IGanttTags>) = 
        Gantt.formatTask title (ganttTags.milestone::Option.defaultBind List.ofSeq [] tags) (Some id) (Some startDate) (Some endDate) |> GanttElement
    static member milestoneStartEnd (title: string, startDate:string, endDate: string, ?tags: #seq<IGanttTags>) = 
        Gantt.formatTask title (ganttTags.milestone::Option.defaultBind List.ofSeq [] tags) (None) (Some startDate) (Some endDate) |> GanttElement
    static member milestoneEnd (title: string, endDate: string, ?tags: #seq<IGanttTags>) = 
        Gantt.formatTask title (ganttTags.milestone::Option.defaultBind List.ofSeq [] tags) (None) (None) (Some endDate) |> GanttElement

    static member dateFormat (formatString: string) = sprintf "dateFormat %s" formatString |> GanttElement
    static member axisFormat (formatString: string) = sprintf "axisFormat %s" formatString |> GanttElement
    static member tickInterval (interval: int, unit: IGanttUnit) = sprintf "tickInterval %i%s" interval (unit.ToFormatString()) |> GanttElement ///^([1-9][0-9]*)(millisecond|second|minute|hour|day|week|month)$/;

    static member weekday (day: string) = sprintf "weekday %s" day |> GanttElement 
    static member excludes (day: string) = sprintf "excludes %s" day |> GanttElement 
    static member comment (txt: string) = Generic.formatComment txt |> GanttElement

module PieChart =

    let formatData name value =
        sprintf "\"%s\" : %A" name value

[<AttachMembers>]
type pieChart =
    static member raw (line: string) = PieChartElement line
    static member showData = PieChartElement "showData"
    static member title (title: string) = sprintf "title %s" title |> PieChartElement
    static member data (name: string) (value: float) = PieChart.formatData name value |> PieChartElement

module QuadrantChart =
    let formatAxis (base0) (req: string) (opt: string option) =
        match opt with
        | Some v -> base0 + sprintf "%s --> %s" req v
        | None -> base0 + req

    let formatXAxis (left: string) (right: string option) =
        let base0 = "x-axis "
        formatAxis base0 left right

    let formatYAxis (bottom: string) (top: string option) =
        let base0 = "y-axis "
        formatAxis base0 bottom top

    let formatPoint (name) x y =
        sprintf "%s: [%.2f, %.2f]" name x y


[<AttachMembers>]
type quadrant =
    static member raw (txt: string) = QuadrantElement txt
    static member title (title: string) = "title " + title |> QuadrantElement
    static member xAxis (left:string, ?right: string) = QuadrantChart.formatXAxis left right |> QuadrantElement
    static member yAxis (bottom:string, ?top: string) = QuadrantChart.formatYAxis bottom top |> QuadrantElement
    static member quadrant1 (title: string) = "quadrant-1 " + title |> QuadrantElement
    static member quadrant2 (title: string) = "quadrant-2 " + title |> QuadrantElement
    static member quadrant3 (title: string) = "quadrant-3 " + title |> QuadrantElement
    static member quadrant4 (title: string) = "quadrant-4 " + title |> QuadrantElement
    static member point (name: string, xAxis: float, yAxis: float) = QuadrantChart.formatPoint name xAxis yAxis |> QuadrantElement
    static member comment (txt: string) = Generic.formatComment txt |> QuadrantElement

module RequirementDiagram =

    type IRequirementType =
        | Requirement
        | FunctionalRequirement
        | InterfaceRequirement
        | PerformanceRequirement
        | PhysicalRequirement
        | DesignConstraint

    type IRiskType = 
        | Low
        | Medium
        | High
        member this.ToFormatString() = this.ToString().ToLower()

    type IVerifyMethod =
        | Analysis
        | Inspection
        | Test
        | Demonstration
        member this.ToFormatString() = this.ToString().ToLower()

    /// A relationship type can be one of contains, copies, derives, satisfies, verifies, refines, or traces.
    type IRDRelationship = 
        | Contains
        | Copies
        | Derives
        | Satisfies
        | Verifies
        | Refines
        | Traces
        member this.ToFormatString() = this.ToString().ToLower()

    let createRequirement type0 name id text (risk: IRiskType option) (methods: IVerifyMethod option) =
        let children =
            [
                id |> Option.map (fun i -> sprintf "id: \"%s\"" i)
                text |> Option.map (fun t -> sprintf "text: \"%s\"" t)
                risk |> Option.map (fun r -> sprintf "risk: %s" <| r.ToFormatString())
                methods |> Option.map (fun m -> sprintf "verifymethod: %s" <| m.ToFormatString())
            ]
            |> List.choose (fun x -> x)
            |> List.map RequirementDiagramElement
        RequirementDiagramWrapper(sprintf "%s %s {" type0 name, "}", children)

    let createElement name type0 docref =
        let children =
            [
                type0 |> Option.map (fun t -> sprintf "type: \"%s\"" t)
                docref |> Option.map (fun d -> sprintf "docRef: \"%s\"" d)
            ]
            |> List.choose (fun x -> x)
            |> List.map RequirementDiagramElement
        RequirementDiagramWrapper(sprintf "element %s {" name,"}", children)
        
    let formatRelationship id1 id2 (rltsType: IRDRelationship) =
        sprintf "%s - %s -> %s" id1 (rltsType.ToFormatString()) id2

type rqRisk =
    static member low = RequirementDiagram.IRiskType.Low
    static member medium = RequirementDiagram.IRiskType.Medium
    static member high = RequirementDiagram.IRiskType.High

type rqMethod =
    static member analysis = RequirementDiagram.IVerifyMethod.Analysis
    static member inspection = RequirementDiagram.IVerifyMethod.Inspection
    static member test = RequirementDiagram.IVerifyMethod.Test
    static member demonstration = RequirementDiagram.IVerifyMethod.Demonstration


[<AttachMembers>]
type reqDia =
    static member raw (txt: string) = RequirementDiagramElement txt

    static member requirement (name, ?id: string, ?text: string, ?rqRisk: RequirementDiagram.IRiskType, ?rqMethod: RequirementDiagram.IVerifyMethod) =
        RequirementDiagram.createRequirement "requirement" name id text rqRisk rqMethod
    static member functionalRequirement (name, ?id: string, ?text: string, ?rqRisk: RequirementDiagram.IRiskType, ?rqMethod: RequirementDiagram.IVerifyMethod) =
        RequirementDiagram.createRequirement "functionalRequirement" name id text rqRisk rqMethod
    static member interfaceRequirement (name, ?id: string, ?text: string, ?rqRisk: RequirementDiagram.IRiskType, ?rqMethod: RequirementDiagram.IVerifyMethod) =
        RequirementDiagram.createRequirement "interfaceRequirement" name id text rqRisk rqMethod
    static member performanceRequirement (name, ?id: string, ?text: string, ?rqRisk: RequirementDiagram.IRiskType, ?rqMethod: RequirementDiagram.IVerifyMethod) =
        RequirementDiagram.createRequirement "performanceRequirement" name id text rqRisk rqMethod
    static member physicalRequirement (name, ?id: string, ?text: string, ?rqRisk: RequirementDiagram.IRiskType, ?rqMethod: RequirementDiagram.IVerifyMethod) = 
        RequirementDiagram.createRequirement "physicalRequirement" name id text rqRisk rqMethod
    static member designConstraint (name, ?id: string, ?text: string, ?rqRisk: RequirementDiagram.IRiskType, ?rqMethod: RequirementDiagram.IVerifyMethod) =
        RequirementDiagram.createRequirement "designConstraint" name id text rqRisk rqMethod

    static member element (name, ?type', ?docref) = RequirementDiagram.createElement name type' docref

    static member contains (id1, id2) = RequirementDiagram.formatRelationship id1 id2 RequirementDiagram.Contains |> RequirementDiagramElement
    static member copies (id1, id2) = RequirementDiagram.formatRelationship id1 id2 RequirementDiagram.Copies |> RequirementDiagramElement
    static member derives (id1, id2) = RequirementDiagram.formatRelationship id1 id2 RequirementDiagram.Derives |> RequirementDiagramElement
    static member satisfies (id1, id2) = RequirementDiagram.formatRelationship id1 id2 RequirementDiagram.Satisfies |> RequirementDiagramElement
    static member verifies (id1, id2) = RequirementDiagram.formatRelationship id1 id2 RequirementDiagram.Verifies |> RequirementDiagramElement
    static member refines (id1, id2) = RequirementDiagram.formatRelationship id1 id2 RequirementDiagram.Refines |> RequirementDiagramElement
    static member traces (id1, id2) = RequirementDiagram.formatRelationship id1 id2 RequirementDiagram.Traces |> RequirementDiagramElement

type IGitOrientation = obj

module Git =

    type IGitCommitType =
    | NORMAL
    | REVERSE
    | HIGHLIGHT
        member this.ToFormatString() =
            this.ToString().ToUpper()

    let formatCommitType (commitType: IGitCommitType option) =
        commitType |> Option.map (fun s -> sprintf "type: %s" <| s.ToFormatString())

    let formatTag (tag: string option) =
        tag |> Option.map (fun s -> sprintf "tag: \"%s\"" s)

    let formatSelfID (selfid: string option) =
        selfid |> Option.map (fun s -> sprintf "id: \"%s\"" s)

    let formatParentID (aprentId: string option) =
        aprentId |> Option.map (fun s -> sprintf "parent: \"%s\"" s)

    let formatCommit (selfid: string option) (commitType: IGitCommitType option) (tag: string option) =
        [
            Some "commit"
            selfid |> formatSelfID
            commitType |> formatCommitType
            tag |> formatTag
        ]
        |> List.choose id
        |> String.concat " "

    let formatMerge targetId mergeId (commitType: IGitCommitType option) tag =
        [
            Some "merge"
            Some targetId
            mergeId |> formatSelfID
            commitType |> formatCommitType
            tag |> formatTag
        ]
        |> List.choose id
        |> String.concat " "

    let formatCherryPick commitid parentid =
        [
            Some "cherry-pick"
            Some commitid |> formatSelfID
            parentid |> formatParentID
        ]
        |> List.choose id
        |> String.concat " "


type gitType =
    static member normal = Git.IGitCommitType.NORMAL
    static member reverse = Git.IGitCommitType.REVERSE
    static member highlight = Git.IGitCommitType.HIGHLIGHT

[<AttachMembers>]
type git =
    static member raw (line:string) = GitGraphElement line
    static member commit (?id: string, ?gitType: Git.IGitCommitType, ?tag: string) = Git.formatCommit id gitType tag |> GitGraphElement
    static member merge (targetBranchId: string, ?mergeid: string, ?gitType: Git.IGitCommitType, ?tag: string) = 
        Git.formatMerge targetBranchId mergeid gitType tag |> GitGraphElement
    static member cherryPick (commitid: string, ?parentId: string) = Git.formatCherryPick commitid parentId |> GitGraphElement
    static member branch (id: string) = GitGraphElement ("branch " + id)
    static member checkout (id: string) = GitGraphElement ("checkout " + id)
    //static member title (title:string) = GitGraphTitle title
    //static member showBranches (b: bool) = GitGraphConfig ("", "")
    //static member rotateCommitLabel (b: bool) = GitGraphConfig ("", "")
    //static member showCommitLabel (b: bool) = GitGraphConfig ("", "")
    //static member mainBranchName (name: string) = GitGraphConfig ("", "")
    //static member mainBranchOrder (order: int) = GitGraphConfig ("", "")
    //static member orientation (orientation: IGitOrientation) = GitGraphOrientation "TODO"
    //static member parallelCommits (b: bool) = GitGraphConfig ("", "")
    //static member rawConfig (key, value) = GitGraphConfig (key, value)


module Mindmap =

    type IMindmapShape = 
        | Square //id[I am a square]
        | RoundedSquare //id(I am a rounded square)
        | Circle //id((I am a circle))
        | Bang //id))I am a bang((
        | Cloud //id)I am a cloud(
        | Hexagon //id{{I am a hexagon}}

    let formatNode (id: string) (name: string option) t =
        let name = defaultArg name id
        match t with
        | Square -> sprintf "%s[%s]" id name
        | RoundedSquare -> sprintf "%s(%s)" id name
        | Circle -> sprintf "%s((%s))" id name
        | Bang -> sprintf "%s))%s((" id name
        | Cloud -> sprintf "%s)%s(" id name
        | Hexagon -> sprintf "%s{{%s}}" id name

    let handleNodeChildren (children: #seq<MindmapElement> option) (opener: string)  =
        if children.IsSome && Seq.isEmpty children.Value |> not then
            MindmapWrapper (opener, "", List.ofSeq children.Value)
        else
            MindmapElement opener

[<AttachMembers>]
type mindmap =
    static member raw (line: string) = MindmapElement line
    static member node(name: string, ?children: #seq<MindmapElement>) = Mindmap.handleNodeChildren children name

    static member square(name: string, ?children: #seq<MindmapElement>) = Mindmap.formatNode name None Mindmap.Square |> Mindmap.handleNodeChildren children
    static member squareId(id, name: string, ?children: #seq<MindmapElement>) = Mindmap.formatNode id (Some name) Mindmap.Square |> Mindmap.handleNodeChildren children
    
    static member roundedSquare(name: string, ?children: #seq<MindmapElement>) = Mindmap.formatNode name None Mindmap.RoundedSquare |> Mindmap.handleNodeChildren children
    static member roundedSquareId(id, name: string, ?children: #seq<MindmapElement>) = Mindmap.formatNode id (Some name) Mindmap.RoundedSquare |> Mindmap.handleNodeChildren children
    
    static member circle(name: string, ?children: #seq<MindmapElement>) = Mindmap.formatNode name None Mindmap.Circle |> Mindmap.handleNodeChildren children
    static member circleId(id, name: string, ?children: #seq<MindmapElement>) = Mindmap.formatNode id (Some name) Mindmap.Circle |> Mindmap.handleNodeChildren children
    
    static member bang(name: string, ?children: #seq<MindmapElement>) = Mindmap.formatNode name None Mindmap.Bang |> Mindmap.handleNodeChildren children
    static member bangId(id, name: string, ?children: #seq<MindmapElement>) = Mindmap.formatNode id (Some name) Mindmap.Bang |> Mindmap.handleNodeChildren children
    
    static member cloud(name: string, ?children: #seq<MindmapElement>) = Mindmap.formatNode name None Mindmap.Cloud |> Mindmap.handleNodeChildren children
    static member cloudId(id, name: string, ?children: #seq<MindmapElement>) = Mindmap.formatNode id (Some name) Mindmap.Cloud |> Mindmap.handleNodeChildren children
    
    static member hexagon(name: string, ?children: #seq<MindmapElement>) = Mindmap.formatNode name None Mindmap.Hexagon |> Mindmap.handleNodeChildren children
    static member hexagonId(id, name: string, ?children: #seq<MindmapElement>) = Mindmap.formatNode id (Some name) Mindmap.Hexagon |> Mindmap.handleNodeChildren children

    static member icon(iconClass: string) = sprintf "::icon(%s)" iconClass |> MindmapElement
    static member className(className: string) = sprintf "::: %s" className |> MindmapElement
    static member classNames(classNames: #seq<string>) = classNames |> String.concat " " |> sprintf "::: %s" |> MindmapElement
    static member comment (txt: string) = Generic.formatComment txt

module Timeline =

    let formatSingle header (data: string option) =
        match data with
        | None -> header
        | Some event -> sprintf "%s : %s" header event

    let createMultiple header (data: string list) =
        let children = data |> List.map (fun s -> ": " + s |> TimelineElement)
        TimelineWrapper(header,"", children)

[<AttachMembers>]
type timeline =
    static member raw (line: string) = TimelineElement line
    static member title (name: string) = "title " + name |> TimelineElement
    static member period (name: string) = TimelineElement name
    static member single (timePeriod: string, ?event: string) = Timeline.formatSingle timePeriod event |> TimelineElement
    static member multiple (timePeriod: string, events: #seq<string>) = Timeline.createMultiple timePeriod (List.ofSeq events)
    static member section (name: string, children: #seq<TimelineElement>) = TimelineWrapper ("section " + name,"",List.ofSeq children)
    static member comment (txt: string) = Generic.formatComment txt |> TimelineElement

module Sankey =

    let formatLink (source: string) (target:string) (value:float) =
        let source = source.Replace("\"","\"\"")
        let target = target.Replace("\"","\"\"")
        sprintf "\"%s\",\"%s\",%f" source target value

    let createLinks (source: string) (targets: list<string*float>) =
        [
            for target, value in targets do
                formatLink source target value |> SankeyElement
        ] |> SankeyElementList

[<AttachMembers>]
type sankey =
    static member raw(line: string) = SankeyElement line
    static member comment (txt: string) = Generic.formatComment txt |> SankeyElement
    static member link (source: string, target: string, value: float) = 
        Sankey.formatLink source target value |> SankeyElement //remember to escape " and , for the user
    static member links (source: string, targets: list<string*float>) = 
        Sankey.createLinks source targets

[<AttachMembers>]
type xyChart =
    static member raw(line: string) = XYChartElement line
    static member title(name: string) = XYChartElement "TODO" //If the title is a single word one no need to use ", but if it has space " is needed
    static member horizontal = XYChartDirection "horizontal"
    static member vertical = XYChartDirection "vertical"
    static member xAxis (?name: string, ?data: #seq<string>) = XYChartElement "TODO"
    static member xAxisRange (?name: string, ?startEnd: float*float) = XYChartElement "TODO"
    static member yAxis (?name: string, ?data: #seq<float>) = XYChartElement "TODO"
    static member yAxisRange (?name: string, ?startEnd: float*float) = XYChartElement "TODO"
    static member line (data: #seq<float>) = XYChartElement "TODO"
    static member bar (data: #seq<float>) = XYChartElement "TODO"

[<AttachMembers>]
type siren =
    static member flowchart (direction:Direction, children: #seq<FlowchartElement>) = SirenElement.Flowchart (direction, List.ofSeq children)
    static member sequence (children: #seq<SequenceElement>) = SirenElement.Sequence (List.ofSeq children)
    static member classDiagram (children: #seq<ClassDiagramElement>) = SirenElement.Class(List.ofSeq children)
    static member state (children: #seq<StateDiagramElement>) = SirenElement.State(List.ofSeq children)
    static member stateV2 (children: #seq<StateDiagramElement>) = SirenElement.StateV2(List.ofSeq children)
    static member erDiagram (children: #seq<ERDiagramElement>) = SirenElement.ERDiagram(List.ofSeq children)
    static member journey (children: #seq<JourneyElement>) = SirenElement.Journey (List.ofSeq children)
    static member gantt (children: #seq<GanttElement>) = SirenElement.Gantt(List.ofSeq children)
    static member pieChart (children: #seq<PieChartElement>) = SirenElement.PieChart(List.ofSeq children)
    static member quadrant (children: #seq<QuadrantElement>) = SirenElement.Quadrant (List.ofSeq children)
    static member requirement (children: #seq<RequirementDiagramElement>) = SirenElement.RequirementDiagram (List.ofSeq children)
    static member git (children: #seq<GitGraphElement>) = SirenElement.GitGraph (List.ofSeq children)
    static member mindmap (children: #seq<MindmapElement>) = SirenElement.Mindmap (List.ofSeq children)
    static member timeline (children: #seq<TimelineElement>) = SirenElement.Timeline (List.ofSeq children)
    static member sankey (children: #seq<SankeyElement>) = SirenElement.Sankey (List.ofSeq children)
    static member xyChart (children: #seq<XYChartElement>) = SirenElement.XYChart (List.ofSeq children)
    static member write(diagram: SirenElement) =
        match diagram with
        | SirenElement.Flowchart (direction, children) ->
            let dia = "flowchart " + direction.ToString()
            writeYamlDiagramRoot dia children
        | SirenElement.Sequence (children) ->
            let dia = "sequenceDiagram"
            writeYamlDiagramRoot dia children
        | SirenElement.Class children ->
            let dia = "classDiagram"
            writeYamlDiagramRoot dia children
        | SirenElement.StateV2 children ->
            let dia = "stateDiagram-v2"
            writeYamlDiagramRoot dia children
        | SirenElement.State children ->
            let dia = "stateDiagram"
            writeYamlDiagramRoot dia children
        | SirenElement.ERDiagram children ->
            let dia = "erDiagram"
            writeYamlDiagramRoot dia children
        | SirenElement.Journey children ->
            let dia = "journey"
            writeYamlDiagramRoot dia children
        | SirenElement.Gantt children ->
            let dia = "gantt"
            writeYamlDiagramRoot dia children
        | SirenElement.PieChart (children) ->
            let dia = "pie " // This whitespace is important! without the pie chart is not correctly parsed when using "showData" or "title"
            writeYamlDiagramRoot dia children
        | SirenElement.Quadrant children ->
            let dia = "quadrantChart"
            writeYamlDiagramRoot dia children
        | SirenElement.RequirementDiagram children ->
            let dia = "requirementDiagram"
            writeYamlDiagramRoot dia children
        | SirenElement.GitGraph children ->
            let dia = "gitGraph"
            writeYamlDiagramRoot dia children
        | SirenElement.Mindmap children ->
            let dia = "mindmap"
            writeYamlDiagramRoot dia children
        | SirenElement.Timeline children ->
            let dia = "timeline"
            writeYamlDiagramRoot dia children
        | SirenElement.Sankey children ->
            let dia = "sankey-beta"
            Yaml.root [
                Yaml.line dia
                for child in children do
                    yield! child :> IYamlConvertible |> _.ToYamlAst()
            ]
        | _ -> failwith "TODO"
        |> Yaml.write