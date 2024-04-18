namespace Siren

open Fable.Core

module Option =

    let formatString (format: string -> string) (str: string option) =
        match str with |None -> "" | Some str -> format str

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

    type ERDiagramElement =
        | ERDiagramElement of string
        | ERDiagramWrapper of opener: string * closer: string * StateDiagramElement list

    type JourneyElement =
        | JourneyElement of string
        | JourneyWrapper of opener: string * closer: string * JourneyElement list

    type GanttElement =
        | GanttElement of string
        | GanttWrapper of opener: string * closer: string * GanttElement list

    type PieChartElement =
        | PieChartElement of string
        | PieChartWrapper of opener:string * closer:string * PieChartElement list

    type QuadrantElement =
        | QuadrantElement of string
        | QuadrantWrapper of opener:string * closer:string * QuadrantElement list

    type RequirementDiagramElement =
        | RequirementDiagramElement of string
        | RequirementDiagramWrapper of opener:string * closer:string * RequirementDiagramElement list
        
    type GitGraphElement =
        | GitGraphElement of string
        | GitGraphWrapper of opener:string * closer:string * GitGraphElement list
        | GitGraphTitle of string
        | GitGraphOrientation of string
        | GitGraphConfig of key: string * value: string

    type MindmapElement =
        | MindmapElement of string
        | MindmapWrapper of opener:string * closer:string * MindmapElement list

    type TimelineElement =
        | TimelineElement of string
        | TimelineWrapper of opener:string * closer:string * TimelineElement list
        | TimelineConfig of key:string * value: string

    type SankeyElement =
        | SankeyElement of string

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
    | Gantt of compactMode: bool * GanttElement list
    | PieChart of PieChartElement list
    | Quadrant of QuadrantElement list
    | RequirementDiagram of RequirementDiagramElement list
    | GitGraph of GitGraphElement list
    | Mindmap of MindmapElement list
    | Timeline of TimelineElement list
    | Sankey of SankeyElement list
    | XYChart of XYChartElement list

[<AttachMembers>]
type formatting =
    //static member escaped (txt: string) = // idea for escaping for example quotes
    static member unicode (txt: string) = string '"' + txt + string '"'
    static member markdown (txt: string) = """ "` """ + txt + """ `" """

open Types

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

module Generic =
    
    let formatComment (txt: string) = sprintf "%%%% %s" txt

    let formatDirection (direction: Direction) =
        sprintf "direction %s" (direction.ToString())

    let formatClickHref id url (tooltip:string option) =
        let tooltip = tooltip |> Option.map (fun s -> sprintf " %A" s) |> Option.defaultValue ""
        sprintf """click %s href %A%s""" id url tooltip

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

    type NotePosition =
    | Over
    | RightOf
    | LeftOf
        member this.ToFormatString() =
            match this with
            | Over      -> "over"
            | RightOf   -> "right of"
            | LeftOf    -> "left of"

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

    let formatNote (id) (position: NotePosition option) (msg: string) =
        let position = defaultArg position NotePosition.RightOf |> _.ToFormatString()
        sprintf "note %s %s: %s" position id msg

    let formatNoteSpanning id1 id2 (position: NotePosition option) (msg: string) =
        let position = defaultArg position NotePosition.RightOf |> _.ToFormatString()
        sprintf "note %s %s,%s: %s" position id1 id2 msg

    let [<Literal>] BoxCloser = "end"

[<AttachMembers>]
type notePosition =
    static member over = Sequence.NotePosition.Over
    static member rightOf = Sequence.NotePosition.RightOf
    static member leftOf = Sequence.NotePosition.LeftOf

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
    static member note(id: string, text: string, ?notePosition: Sequence.NotePosition) = Sequence.formatNote id notePosition text |> SequenceElement
    static member noteSpanning(id1: string, id2, text: string, ?notePosition: Sequence.NotePosition) = Sequence.formatNoteSpanning id1 id2 notePosition text |> SequenceElement
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

type ITransitionType = obj

[<AttachMembers>]
type stateDiagram =
    static member state (id: string, ?description: string) = StateDiagramElement "TODO"
    static member stateIf (id: string) = StateDiagramElement "TODO" //state if_state <<choice>>
    static member stateFork (id: string) = StateDiagramElement "TODO" // state fork_state <<fork>>
    static member transition (id1: string, id2: string, ?transitionType: ITransitionType, ?description: string) = StateDiagramElement "TODO"
    static member startStop = StateDiagramElement "TODO"
    static member startStopString : string = "[*]"
    static member stateComposite (id: string, children: #seq<StateDiagramElement>) = StateDiagramWrapper ("TODO","TODO", List.ofSeq children)
    static member note (id: string, notePosition: Sequence.NotePosition) = StateDiagramElement "TODO"
    /// Can only be used in stateComposite
    static member concurrency = StateDiagramElement "--" 
    static member direction (direction: obj) = StateDiagramElement "TODO"
    static member comment (txt: string) = StateDiagramElement "TODO"

type IERRelationshipType = obj
type IERKeyType = obj
type IERAttribute = obj

[<AttachMembers>]
type erDiagram =
    static member raw (line: string) = ERDiagramElement line
    static member entity (id: string, ?alias: string, ?attributes: #seq<IERAttribute>) = if attributes.IsSome then ERDiagramWrapper ("TODO", "TODO", []) else ERDiagramElement "TODO"
    static member relationship(id1, id2, ?relationshipType: IERRelationshipType, ?message) = ERDiagramElement "TODO"
    static member attribute(type': string, name: string, ?keys: #seq<IERKeyType>, ?comment: string) : IERAttribute = "TODO"

[<AttachMembers>]
type journey =
    static member raw (line: string) = JourneyElement line
    static member title (name: string) = JourneyElement "TODO"
    static member section (name: string, tasks: #seq<JourneyElement>) = JourneyWrapper ("TODO","",List.ofSeq tasks)
    static member task (name: string, score: int, actors: #seq<string>) = JourneyElement "TODO"

type IGanttTags = obj
type IGanttMetadata = obj
type IGanttFormatString = obj
type IGanttAxisFormatString = obj
type ITimeUnit = obj

[<AttachMembers>]
type gantt =
    static member raw (line: string) = GanttElement line
    static member title (name: string) = GanttElement "TODO"
    static member section (name: string, children: #seq<GanttElement>) = GanttWrapper ("TODO", "", List.ofSeq children)
    static member task (title: string, ?tags: #seq<IGanttMetadata>, ?metadata: IGanttMetadata) = GanttElement "TODO"
    static member milestone (title: string, ?id: string, ?startPoint: string, ?timespan: string) = GanttElement "TODO"
    static member dateFormat (formatString: IGanttFormatString) = GanttElement "TODO"
    static member axisFormat (formatString: IGanttAxisFormatString) = GanttElement "TODO"
    static member tickInterval (interval: int, unit: ITimeUnit) = GanttElement "TODO" ///^([1-9][0-9]*)(millisecond|second|minute|hour|day|week|month)$/;
    static member weekday (day: string) = GanttElement "TODO"
    static member comment (txt: string) = GanttElement "TODO"

[<AttachMembers>]
type pieChart =
    static member raw (line: string) = PieChartElement line
    static member showDate = PieChartElement "TODO"
    static member title (title: string) = PieChartElement "TODO"
    static member data(name: string, value: float) = PieChartElement "TODO"

[<AttachMembers>]
type quadrant =
    static member title (title: string) = QuadrantElement "TODO"
    static member xAxis (left:string, ?right: string) = QuadrantElement "TODO"
    static member yAxis (bottom:string, ?top: string) = QuadrantElement "TODO"
    static member quadrant (number: int, title: string) = QuadrantElement "TODO"
    static member point (name: string, xAxis: float, yAxis: float) = QuadrantElement "TODO"
    static member comment (txt: string) = QuadrantElement "TODO"
    
type IRequirementType = obj
type IRiskType = obj
type IVerifyMethod = obj
/// A relationship type can be one of contains, copies, derives, satisfies, verifies, refines, or traces.
type IRDRelationship = obj

[<AttachMembers>]
type requirementDiagram =
    static member requirement (name, ?type': IRequirementType, ?id: string, ?text: string, ?risk: IRiskType, ?methods: IVerifyMethod) = RequirementDiagramWrapper("TODO","}", [])
    static member element (name: string, ?type': string, ?docref: string) = RequirementDiagramWrapper("TODO","}", [])
    static member relationship (id1, id2, rltsType: IRDRelationship) = RequirementDiagramWrapper("TODO","}", [])

type IGitCommitType = obj
type IGitOrientation = obj

[<AttachMembers>]
type git =
    static member raw (line:string) = GitGraphTitle line
    static member commit (?id: string, ?commitType: IGitCommitType, ?tag: string) = GitGraphElement "TODO"
    static member branch (id: string) = GitGraphElement "TODO"
    static member checkout (id: string) = GitGraphElement "TODO"
    static member merge (branchid: string, ?mergeid: string, ?commitType: IGitCommitType, ?tag: string) = GitGraphElement "TODO"
    static member cherryPick (commitid: string, ?parentId: string) = GitGraphElement "TODO"
    static member title (title:string) = GitGraphTitle title
    static member showBranches (b: bool) = GitGraphConfig ("", "")
    static member rotateCommitLabel (b: bool) = GitGraphConfig ("", "")
    static member showCommitLabel (b: bool) = GitGraphConfig ("", "")
    static member mainBranchName (name: string) = GitGraphConfig ("", "")
    static member mainBranchOrder (order: int) = GitGraphConfig ("", "")
    static member orientation (orientation: IGitOrientation) = GitGraphOrientation "TODO"
    static member parallelCommits (b: bool) = GitGraphConfig ("", "")
    static member rawConfig (key, value) = GitGraphConfig (key, value)

type IMindmapShape = obj

[<AttachMembers>]
type mindmap =
    static member raw (line: string) = MindmapElement line
    static member root (shape: IMindmapShape, children: #seq<MindmapElement>) = MindmapWrapper ("TODO", "", List.ofSeq children)
    static member node(id: string, ?name: string, ?shape: IMindmapShape, ?children: #seq<MindmapElement>) = if children.IsSome then MindmapWrapper ("TODO", "", List.ofSeq children.Value) else MindmapElement "TODO"
    static member icon(iconClass: string) = MindmapElement "TODO"
    static member classNames(classNames: string) = MindmapElement "TODO"

[<AttachMembers>]
type timeline =
    static member raw (line: string) = TimelineElement line
    static member title (name: string) = TimelineElement "TODO"
    static member timePeriod (timePoint: string, data: #seq<string>) = TimelineElement "TODO"
    static member section (name: string, children: #seq<TimelineElement>) = TimelineWrapper ("TODO","",List.ofSeq children)
    static member disableMulticolor (b:bool) = TimelineConfig ("TODO","TODO")

[<AttachMembers>]
type sankey =
    static member raw(line: string) = SankeyElement line
    static member comment (txt: string) = SankeyElement "TODO" //%% source,target,value
    static member link (source: string, target: string, value: float) = SankeyElement "TODO" //remember to escape " and , for the user

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
    static member gantt (children: #seq<GanttElement>,?compactMode: bool) = SirenElement.Gantt(defaultArg compactMode false, List.ofSeq children)
    static member pieChart (children: #seq<PieChartElement>) = SirenElement.PieChart(List.ofSeq children)
    static member quadrant (children: #seq<QuadrantElement>) = SirenElement.Quadrant (List.ofSeq children)
    static member requirementDiagram (children: #seq<RequirementDiagramElement>) = SirenElement.RequirementDiagram (List.ofSeq children)
    static member gitGraph (children: #seq<GitGraphElement>) = SirenElement.GitGraph (List.ofSeq children)
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
        | _ -> failwith "TODO"
        |> Yaml.write