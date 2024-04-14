namespace Siren

open Fable.Core

[<RequireQualifiedAccess>]
type NodeTypes =
    | Id
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
type NotePosition =
| RightOf
| LeftOf
| Over
    member this.toFormatString() =
        match this with
        | RightOf -> "right of"
        | LeftOf -> "left of"
        | Over -> "over"

[<RequireQualifiedAccess>]
type SubgraphType =
| Subgraph
| Box of color: string option
| Loop 
    member this.toFormatString() =
        let start =
            match this with
            | Subgraph -> "subgraph"
            | Box color -> if color.IsSome then sprintf "box %s" color.Value else "box"
            | Loop -> "loop"
        let end_ = "end"
        start, end_

[<RequireQualifiedAccess>]
type LinkTypes =
    | Arrow         of text: string option * addlength: int option
    | Open          of text: string option * addlength: int option
    | Dotted        of text: string option * addlength: int option
    | DottedArrow   of text: string option * addlength: int option
    | Thick         of text: string option * addlength: int option
    | ThickArrow    of text: string option * addlength: int option
    | Invisible     of text: string option * addlength: int option
    | CircleEdge    of text: string option * addlength: int option
    | CrossEdge     of text: string option * addlength: int option
    | ArrowDouble   of text: string option * addlength: int option
    | CircleDouble  of text: string option * addlength: int option
    | CrossDouble   of text: string option * addlength: int option

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
        | Open _ | Arrow _  | CircleEdge _ | CrossEdge _ | ArrowDouble _ | CircleDouble _ | CrossDouble _ -> "-"
        | Dotted _ | DottedArrow _ -> "."
        | Thick _ | ThickArrow _ -> "="
        | Invisible _ -> "~"

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

[<RequireQualifiedAccess>]
type target =
    | _self
    | _blank
    | _parent
    | _top

    override this.ToString() =
        match this with
        | target._self     -> "_self"
        | target._blank    -> "_blank"
        | target._parent   -> "_parent"
        | target._top      -> "_top"

type ClickTypes =
    | Href of url:string * target: target option
    | Callback of callbackName: string

module rec Types =

    type Config = {
        WhiteSpaces: int
        Level: int
    } with
        static member init(?whitespaces) = {
            WhiteSpaces = defaultArg whitespaces 4
            Level = 0
        }

        member this.GetWhiteSpaceString() =
            String.init (this.WhiteSpaces * this.Level) (fun _ -> " ")

        member this.GetIncreasedLevel() = 
            {this with Level = this.Level + 1}

    type Node = {
        Id: string
        Name: string
        NodeType: NodeTypes
    } with
        static member create (id, ?name, ?t) = {
            Id = id
            Name = defaultArg name id
            NodeType = defaultArg t NodeTypes.Default
        }

    type Connection = {
        Node1: Element
        Node2: Element
        LinkType: LinkTypes
    } with
        static member create (node1, node2, t) = {
            Node1 = node1
            Node2 = node2
            LinkType = t
        }

    type Message = {
        Id1: Element
        Id2: Element
        MessageType: MessageTypes
        Message: string
        // if None then ignore, if true then "activate", if false then "deactivate"
        Active: bool option
    } with
        static member create(id1, id2, mt, msg, ?active) = {
            Id1 = id1
            Id2 = id2
            MessageType = mt
            Message = msg
            Active = active
        }

    type Click = {
        NodeId: string
        Type: ClickTypes
        Tooltip: string option
    } with
        static member create (id, t, ?tooltip) = {
            NodeId = id
            Type = t
            Tooltip = tooltip
        }

    type Subgraph = {
        Type: SubgraphType
        Id: string
        Name: string option
        Children: Children
    } with
        static member create (type_, id, name, children) = 
            {
                Type = type_
                Id = id
                Name = name
                Children = children
            }

    type Children = Element list

    and Element =
        | Empty
        | Raw of string
        | Comment of string
        | KeyValue of key: string * value: string
        | Click of Click
        | Message of Message
        | Node of Node
        | Connection of Connection
        | Subgraph of Subgraph
        | SubgraphChain of Subgraph list
        | Graph of name:string * Children

        member this.GetId() =
            match this with 
            | Empty -> failwith "Cannot get ID from `Empty` Element."
            | Raw _ -> failwith "Cannot get ID from `Raw` Element."
            | Comment _ -> failwith "Cannot get ID from `Comment` Element."
            | KeyValue _ -> failwith "Cannot get ID from `KeyValue` Element."
            | Click c -> c.NodeId
            | Node n -> n.Id
            | Message _ -> failwith "Cannot get ID from `Message` Element."
            | Connection _ -> failwith "Cannot get ID from `Connection` Element."
            | Subgraph sg -> sg.Id
            | SubgraphChain _ -> failwith "Cannot get ID from `SubgraphChain` Element."
            | Graph _ -> failwith "Cannot get ID from `Graph` Element."

module rec Formatter =
    open Types
    open System.Text

    let formatSequenceDiagramAlias (id: string) (alias: string option) = if alias.IsSome then sprintf "%s as %s" id alias.Value else id

    let writeComment (txt: string) = sprintf "%%%% %s" txt
    let writeRaw (txt: string) = txt
    let writeKeyValue (key: string) (v: string) = sprintf "%s %s" key v
    let writeClick (click: Click) =
        [
            "click"
            click.NodeId
            match click.Type with
            | Href (url, None) ->
                "href"
                url
            | Href (url, Some target) ->
                "href"
                url
                target.ToString()
            | Callback callback ->
                "call"
                callback
            if click.Tooltip.IsSome then
                click.Tooltip.Value
        ]
        |> String.concat " "

    let formatMinimalNamedNode (id:string) (name:string) = $"{id}[{name}]"

    let internal formatNodeType (nodetype: NodeTypes) =
        let this = nodetype
        match this with
        | NodeTypes.Id -> fun id _ -> id
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

    let writeNode (node: Node) =
        let formatter = formatNodeType node.NodeType
        formatter node.Id node.Name

    let internal formatMessageType (msgType: MessageTypes) =
        match msgType with
        | MessageTypes.Solid             -> "->"
        | MessageTypes.Dotted            -> "-->"
        | MessageTypes.Arrow             -> "->>"
        | MessageTypes.DottedArrow       -> "-->>"
        | MessageTypes.CrossEdge         -> "-x"
        | MessageTypes.DottedCrossEdge   -> "--x"
        | MessageTypes.OpenArrow         -> "-)"
        | MessageTypes.DottedOpenArrow   -> "--)"

    let internal formatLinkType (link: LinkTypes) =
        let this = link
        match this with
        | LinkTypes.Arrow (txt, l) -> txt, $"-{this.AddedLengthLinker(l)}>" 
        | LinkTypes.Open (txt, l) -> txt, $"-{this.AddedLengthLinker(l)}-"
        | LinkTypes.Dotted (txt, l) -> txt, $"-{this.AddedLengthLinker(l)}-"
        | LinkTypes.DottedArrow (txt, l) -> txt, $"-{this.AddedLengthLinker(l)}->"
        | LinkTypes.Thick (txt, l) -> txt, $"={this.AddedLengthLinker(l)}="
        | LinkTypes.ThickArrow (txt, l) -> txt, $"={this.AddedLengthLinker(l)}>"
        | LinkTypes.Invisible (txt, l) -> txt, $"~{this.AddedLengthLinker(l)}~"
        | LinkTypes.CircleEdge (txt, l) -> txt, $"-{this.AddedLengthLinker(l)}o"
        | LinkTypes.CrossEdge (txt, l) -> txt, $"-{this.AddedLengthLinker(l)}x"
        | LinkTypes.ArrowDouble (txt, l) -> txt, $"<-{this.AddedLengthLinker(l)}>"
        | LinkTypes.CircleDouble (txt, l) -> txt, $"o-{this.AddedLengthLinker(l)}o"
        | LinkTypes.CrossDouble (txt, l) -> txt, $"x-{this.AddedLengthLinker(l)}x"
        ||> LinkTypes.appendTextOption

    let writeMessage (msg: Message) =
        let active = match msg.Active with |None -> "" | Some true -> "+"| Some false -> "-"
        sprintf "%s%s%s:%s%s" (msg.Id1.GetId()) (formatMessageType msg.MessageType) (msg.Id2.GetId()) active msg.Message

    let formatConnectionElement (e:Element) =
        match e with
        | Element.Node node -> writeNode node
        | Element.Subgraph {Id = id} -> id
        | _ -> failwith "todo"

    let writeConnection (connection: Connection) =
        let link = formatLinkType connection.LinkType
        let n1 = formatConnectionElement connection.Node1
        let n2 = formatConnectionElement connection.Node2
        n1 + link + n2 

    let writeSubgraph (subgraph: Subgraph) =
        let prefix, suffix = subgraph.Type.toFormatString()
        let start =
            if subgraph.Name.IsSome then
                sprintf "%s %s[%s]" prefix subgraph.Id subgraph.Name.Value
            else
                sprintf "%s %s" prefix subgraph.Id 
        start, suffix

    let rec writeElement (e:Element) (sb: StringBuilder) (config: Config) = 
        let whitespaceString = config.GetWhiteSpaceString()
        sb.Append(whitespaceString) |> ignore
        match e with
        | Element.Empty -> sb
        | Element.Raw txt -> sb.AppendLine(writeRaw txt)
        | Element.Comment txt -> sb.AppendLine(writeComment txt)
        | Element.KeyValue (k,v) -> sb.AppendLine(writeKeyValue k v)
        | Element.Click c -> sb.AppendLine(writeClick c)
        | Element.Node n -> sb.AppendLine(writeNode n)
        | Element.Connection c -> 
            let str = writeConnection c
            sb.AppendLine(str)
        | Element.Message msg ->
            let str = writeMessage msg
            sb.AppendLine(str)
        | Element.Subgraph sg ->
            let prefix, suffix = writeSubgraph sg
            sb.AppendLine(prefix) |> ignore
            let nextConfig = config.GetIncreasedLevel()
            for child in sg.Children do
                let _: StringBuilder = writeElement child sb nextConfig
                ()
            sb.Append(whitespaceString) |> ignore
            sb.AppendLine(suffix)
        | Element.Graph (name, children) ->
            let nextConfig = config.GetIncreasedLevel()
            sb.AppendLine(name) |> ignore
            for child in children do
                let _: StringBuilder = writeElement child sb nextConfig
                ()
            sb

    let writeElementFast (e: Element) =
        let sb = StringBuilder()
        (writeElement e sb (Config.init())).ToString()

module Interop =

    open Types

    let mkKeyValue (key: string) (v: string) : Element = KeyValue (key, v)

    let mkLineRaw (txt: string) = Raw txt

    let mkComment (comment: string) = Comment comment

    let mkNote (id: string) (position: NotePosition) (msg: string) = 
        let v = sprintf "%s %s: %s" (position.toFormatString()) (id: string) msg
        KeyValue ("Note", v)
    
    // link
    let mkConnection node1 node2 linkType = Connection.create(node1, node2, linkType) |> Element.Connection
    let mkMessage node1 node2 messageType message active = Message.create(node1, node2, messageType, message, ?active=active) |> Element.Message

    // nodes
    let mkNodeId (id: string) : Element = Node <| Node.create(id, id, NodeTypes.Id)
    let mkNodeSimple (id: string) : Element = Node <| Node.create(id)
    let mkNode (id: string) (name: string) = Node <| Node.create (id, name)
    let mkNodeRound (id: string) (name: string) = Node <| Node.create (id, name, NodeTypes.Round)
    let mkNodeStadium (id: string) (name: string) = Node <| Node.create (id, name, NodeTypes.Stadium)
    let mkNodeSubroutine (id: string) (name: string) = Node <| Node.create (id, name, NodeTypes.Subroutine)
    let mkNodeCylindrical (id: string) (name: string) = Node <| Node.create (id, name, NodeTypes.Cylindrical)
    let mkNodeCircle (id: string) (name: string) = Node <| Node.create (id, name, NodeTypes.Circle)
    let mkNodeAsymmetric (id: string) (name: string) = Node <| Node.create (id, name, NodeTypes.Asymmetric)
    let mkNodeRhombus (id: string) (name: string) = Node <| Node.create (id, name, NodeTypes.Rhombus)
    let mkNodeHexagon (id: string) (name: string) = Node <| Node.create (id, name, NodeTypes.Hexagon)
    let mkNodeParallelogram (id: string) (name: string) = Node <| Node.create (id, name, NodeTypes.Parallelogram)
    let mkNodeParallelogramAlt (id: string) (name: string) = Node <| Node.create (id, name, NodeTypes.ParallelogramAlt)
    let mkNodeTrapezoid (id: string) (name: string) = Node <| Node.create (id, name, NodeTypes.Trapezoid)
    let mkNodeTrapezoidAlt (id: string) (name: string) = Node <| Node.create (id, name, NodeTypes.TrapezoidAlt)
    let mkNodeDoubleCircle (id: string) (name: string) = Node <| Node.create (id, name, NodeTypes.DoubleCircle)    
    
    // subgraph
    let mkSubgraph (id: string) (children: #seq<Element>) : Element = Subgraph <| Subgraph.create(SubgraphType.Subgraph, id, None, List.ofSeq children)
    let mkSubgraphNamed (id: string) (name:string) (children: #seq<Element>) : Element = Subgraph <| Subgraph.create(SubgraphType.Subgraph, id, Some name, List.ofSeq children)
    let mkBox (name: string) (color: string option) (children: #seq<Element>) = Subgraph <| Subgraph.create(SubgraphType.Box color, name, None, List.ofSeq children)
    let mkLoop (name: string) (children: #seq<Element>) = Subgraph <| Subgraph.create(SubgraphType.Loop, name, None, List.ofSeq children)

    // click
    let mkClickHref (nodeid: string) (url:string) (target: target option) (tooltip: string option) = 
        let t = Href (url, target)
        Click.create(nodeid,t,?tooltip=tooltip)
    let mkClickCallback (nodeid: string) (callbackName: string) (tooltip: string option) = 
        let t = Callback callbackName
        Click.create(nodeid,t,?tooltip=tooltip)

    let mkGraph (name: string) (children: #seq<Element>) : Element =
        Graph (name, List.ofSeq children)

open Types    

[<AttachMembers>]
type formatting =
    //static member escaped (txt: string) = // idea for escaping for example quotes
    static member unicode (txt: string) = string '"' + txt + string '"'
    static member markdown (txt: string) = string """ "` """ + txt + string """ `" """

[<AttachMembers>]
type notePosition =
    static member rightOf = NotePosition.RightOf
    static member leftOf = NotePosition.LeftOf
    static member over = NotePosition.Over

[<AttachMembers>]
type comment =
    static member comment (txt: string) = Interop.mkComment txt

[<AttachMembers>]
type node =
    static member id (id: string) = Interop.mkNodeSimple id
    static member simple (id: string) = Interop.mkNodeSimple id
    static member node (id: string) (name: string) = Interop.mkNode id name
    static member unicode (id: string) (name: string) = Interop.mkNode id (formatting.unicode name)
    static member markdown (id: string) (name: string) = Interop.mkNode id (formatting.markdown name)
    //
    static member round (id: string) (name: string) = Interop.mkNodeRound id name
    static member stadium (id: string) (name: string) = Interop.mkNodeStadium id name
    static member subroutine (id: string) (name: string) = Interop.mkNodeSubroutine id name
    static member cylindrical (id: string) (name: string) = Interop.mkNodeCylindrical id name
    static member circle (id: string) (name: string) = Interop.mkNodeCircle id name
    static member asymmetric (id: string) (name: string) = Interop.mkNodeAsymmetric id name
    static member rhombus (id: string) (name: string) = Interop.mkNodeRhombus id name
    static member hexagon (id: string) (name: string) = Interop.mkNodeHexagon id name
    static member parallelogram (id: string) (name: string) = Interop.mkNodeParallelogram id name
    static member parallelogramAlt (id: string) (name: string) = Interop.mkNodeParallelogramAlt id name
    static member trapezoid (id: string) (name: string) = Interop.mkNodeTrapezoid id name
    static member trapezoidAlt (id: string) (name: string) = Interop.mkNodeTrapezoidAlt id name
    static member doubleCircle (id: string) (name: string) = Interop.mkNodeDoubleCircle id name

[<AttachMembers>]
type click =
    static member href (nodeid: string, url: string, ?target, ?tooltip) = Interop.mkClickHref nodeid url target tooltip
    static member callback (nodeid: string, callbackName: string, ?tooltip) = Interop.mkClickCallback nodeid callbackName tooltip

[<AttachMembers>]
type style =
    static member styleString (nodeid: string) (styleString: string) = Interop.mkKeyValue "style" (nodeid + " " + styleString)
    static member style (nodeid: string) (keyValueStyles: #seq<string*string>) = 
        let styleString = keyValueStyles |> List.ofSeq |> List.fold (fun acc (k,v) -> acc + sprintf ",%s:%s" k v) ""
        style.styleString nodeid styleString

[<AttachMembers>]
type direction =
    static member custom (v: string) = Interop.mkKeyValue "direction" v
    static member tb = direction.custom "TB"
    static member td = direction.custom "TD"
    static member bt = direction.custom "BT"
    static member rl = direction.custom "RL"
    static member lr = direction.custom "LR"

[<AttachMembers>]
type subgraph =
    static member subgraph (id: string) (children: #seq<Element>) = Interop.mkSubgraph id children
    static member subgraphNamed (id: string) (name:string) (children: #seq<Element>) = Interop.mkSubgraphNamed id name children

[<AttachMembers>]
type flowchart() = 
    member this.td (children: #seq<Element>) = Interop.mkGraph "flowchart TD" children
    member this.tb (children: #seq<Element>) = this.td children
    member this.lr (children: #seq<Element>) = Interop.mkGraph "flowchart LR" children
    member this.bt (children: #seq<Element>) = Interop.mkGraph "flowchart BT" children
    member this.rl (children: #seq<Element>) = Interop.mkGraph "flowchart RL" children

[<AttachMembers>]
type line =
    static member raw txt = Interop.mkLineRaw txt

[<AttachMembers>]
type link =
    static member arrow (node1,node2,?text:string,?addedLength: int) = 
        Interop.mkConnection node1 node2 <| LinkTypes.Arrow (text, addedLength)
    static member open_ (node1,node2,?text:string,?addedLength: int) =
        Interop.mkConnection node1 node2 <| LinkTypes.Open (text, addedLength)
    static member simple (node1,node2,?text:string,?addedLength: int) =
        link.open_(node1,node2,?text=text,?addedLength=addedLength)
    static member dotted (node1,node2,?text:string,?addedLength: int) =
        Interop.mkConnection node1 node2 <| LinkTypes.Dotted (text, addedLength)
    static member dottedArrow (node1,node2,?text:string,?addedLength: int) =
        Interop.mkConnection node1 node2 <| LinkTypes.DottedArrow (text, addedLength)
    static member thick (node1,node2,?text:string,?addedLength: int) =
        Interop.mkConnection node1 node2 <| LinkTypes.Thick (text, addedLength)
    static member thickArrow (node1,node2,?text:string,?addedLength: int) =
        Interop.mkConnection node1 node2 <| LinkTypes.ThickArrow (text, addedLength)
    static member invisible (node1,node2,?text:string,?addedLength: int) =
        Interop.mkConnection node1 node2 <| LinkTypes.Invisible (text, addedLength)
    static member circleEdge (node1,node2,?text:string,?addedLength: int) =
        Interop.mkConnection node1 node2 <| LinkTypes.CircleEdge (text, addedLength)
    static member crossEdge (node1,node2,?text:string,?addedLength: int) =
        Interop.mkConnection node1 node2 <| LinkTypes.CrossEdge (text, addedLength)
    static member arrowDouble (node1,node2,?text:string,?addedLength: int) =
        Interop.mkConnection node1 node2 <| LinkTypes.ArrowDouble (text, addedLength)
    static member circleDouble (node1,node2,?text:string,?addedLength: int) =
        Interop.mkConnection node1 node2 <| LinkTypes.CircleDouble (text, addedLength)
    static member crossDouble (node1,node2,?text:string,?addedLength: int) =
        Interop.mkConnection node1 node2 <| LinkTypes.CrossDouble (text, addedLength)

[<AttachMembers>]
type message =
    static member solid (node1, node2, msg, active: bool option) = Interop.mkMessage node1 node2 MessageTypes.Solid msg active
    static member arrow (node1, node2, msg, active: bool option) = Interop.mkMessage node1 node2 MessageTypes.Arrow msg active
    static member dotted (node1, node2, msg, active: bool option) = Interop.mkMessage node1 node2 MessageTypes.Dotted msg active
    static member dottedArrow (node1, node2, msg, active: bool option) = Interop.mkMessage node1 node2 MessageTypes.DottedArrow msg active
    static member cross (node1, node2, msg, active: bool option) = Interop.mkMessage node1 node2 MessageTypes.CrossEdge msg active
    static member dottedCross (node1, node2, msg, active: bool option) = Interop.mkMessage node1 node2 MessageTypes.DottedCrossEdge msg active
    static member openArrow (node1, node2, msg, active: bool option) = Interop.mkMessage node1 node2 MessageTypes.OpenArrow msg active
    static member dottedOpenArrow (node1, node2, msg, active: bool option) = Interop.mkMessage node1 node2 MessageTypes.DottedOpenArrow msg active

[<AttachMembers>]
type sequenceDiagram =
    static member participant (id: string, ?alias: string) = Interop.mkKeyValue "participant" (Formatter.formatSequenceDiagramAlias id alias)
    static member actor (id: string, ?alias: string) = Interop.mkKeyValue "actor" (Formatter.formatSequenceDiagramAlias id alias)
    static member destroy (id: string) = Interop.mkKeyValue "destroy" id
    static member createParticipant (id: string, ?alias: string) = Interop.mkKeyValue "create participant" (Formatter.formatSequenceDiagramAlias id alias)
    static member createActor (id: string, ?alias: string) = Interop.mkKeyValue "create actor" (Formatter.formatSequenceDiagramAlias id alias)
    static member box (name: string) (children: #seq<Element>) = Interop.mkBox name None children
    static member boxColored (name: string) (color: string) (children: #seq<Element>) = Interop.mkBox name (Some color) children
    static member activate (id: string) = Interop.mkKeyValue "activate" id
    static member deactivate (id: string) = Interop.mkKeyValue "deactivate" id
    static member note(id: string, position, msg) = Interop.mkNote id position msg

[<AttachMembers>]
type diagram =
    static member flowchart = flowchart()
    static member sequence (children: #seq<Element>) = Interop.mkGraph "sequenceDiagram" children
    static member gantt (children: #seq<Element>) = Interop.mkGraph "gantt" children
    static member classDiagram (children: #seq<Element>) = Interop.mkGraph "classDiagram" children
    static member git (children: #seq<Element>) = Interop.mkGraph "gitGraph" children
    static member entityRelationship (children: #seq<Element>) = Interop.mkGraph "erDiagram" children
    static member journey (children: #seq<Element>) = Interop.mkGraph "journey" children
    static member quadrant (children: #seq<Element>) = Interop.mkGraph "quadrantChart" children
    static member xy (children: #seq<Element>) = Interop.mkGraph "xychart-beta" children

open Interop

[<AttachMembers>]
type siren =
    static member write (element: Element, ?whitespaces: int) : string =
        let whitespaces = defaultArg whitespaces 4
        let sb = System.Text.StringBuilder()
        Formatter.writeElement element sb (Config.init(whitespaces))
        |> _.ToString()

[<AutoOpen>]
module Operators =
    
    let (---) (node1:Element) (node2:Element) : Element =
        link.open_ (node1, node2)

    let (-->) (node1:Element) (node2:Element) : Element =
        link.arrow (node1, node2)