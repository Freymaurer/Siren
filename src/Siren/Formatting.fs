module Siren.Formatting

open Siren.Util

module Generic =

    type NotePosition with
        member this.ToFormatString() =
            match this with
            | NotePosition.Over      -> "over"
            | NotePosition.RightOf   -> "right of"
            | NotePosition.LeftOf    -> "left of"
    
    let formatComment (txt: string) = sprintf "%%%% %s" txt

    let formatDirection (direction: Direction) =
        sprintf "direction %s" (direction.ToString())

    let formatClickHref id url (tooltip:string option) =
        let tooltip = tooltip |> Option.map (fun s -> sprintf " \"%s\"" s) |> Option.defaultValue ""
        sprintf """click %s href "%s"%s""" id url tooltip

    let formatNote (id) (position: NotePosition option) (msg: string) =
        let position = defaultArg position NotePosition.RightOf |> _.ToFormatString()
        sprintf "note %s %s : %s" position id msg

    [<Literal>]
    let ProtectedWhitespace = "&nbsp;"

    let formatClassDef (className: string) (styles0: (string*string) list) =
        let styles = styles0 |> List.map (fun (key, v) -> sprintf "%s:%s" key v) |> String.concat ","
        sprintf "classDef %s %s;" className styles

    let formatClass (nodeIds0: string list) (className: string) =
        let ids = nodeIds0 |> String.concat ","
        sprintf "class %s %s;" ids className

module Flowchart =

    type FlowchartLinkTypes with

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
            | FlowchartLinkTypes.Open | FlowchartLinkTypes.Arrow | FlowchartLinkTypes.CircleEdge | FlowchartLinkTypes.CrossEdge | FlowchartLinkTypes.ArrowDouble | FlowchartLinkTypes.CircleDouble | FlowchartLinkTypes.CrossDouble -> "-"
            | FlowchartLinkTypes.Dotted | FlowchartLinkTypes.DottedArrow -> "."
            | FlowchartLinkTypes.Thick | FlowchartLinkTypes.ThickArrow -> "="
            | FlowchartLinkTypes.Invisible -> "~"

    let private formatMinimalNamedNode (id:string) (name:string) = $"{id}[{name}]"

    let private nodeTypeToFormatter (nodetype: FlowchartNodeTypes) =
        match nodetype with
        | FlowchartNodeTypes.Default -> fun id name -> formatMinimalNamedNode id name
        | FlowchartNodeTypes.Round -> fun id name -> $"{id}({name})"
        | FlowchartNodeTypes.Stadium -> fun id name -> $"{id}([{name}])"
        | FlowchartNodeTypes.Subroutine -> fun id name -> $"{id}[[{name}]]"
        | FlowchartNodeTypes.Cylindrical -> fun id name -> $"{id}[({name})]"
        | FlowchartNodeTypes.Circle -> fun id name -> $"{id}(({name}))"
        | FlowchartNodeTypes.Asymmetric -> fun id name -> $"{id}>{name}]"
        | FlowchartNodeTypes.Rhombus -> fun id name -> sprintf "%s{%s}" id name
        | FlowchartNodeTypes.Hexagon -> fun id name -> sprintf "%s{{%s}}" id name
        | FlowchartNodeTypes.Parallelogram -> fun id name -> sprintf "%s[/%s/]" id name
        | FlowchartNodeTypes.ParallelogramAlt -> fun id name -> sprintf "%s[\%s\]" id name
        | FlowchartNodeTypes.Trapezoid -> fun id name -> sprintf "%s[/%s\]" id name
        | FlowchartNodeTypes.TrapezoidAlt -> fun id name -> sprintf "%s[\%s/]" id name
        | FlowchartNodeTypes.DoubleCircle -> fun id name -> sprintf "%s(((%s)))" id name

    let formatNode (id: string) (name: string option) (shape: FlowchartNodeTypes) =
        let formatter = nodeTypeToFormatter shape
        let name = defaultArg name id
        formatter id name

    let private formatLinkType (link: FlowchartLinkTypes) (msg: string option) (addedLength: int option) =
        match link with
        | FlowchartLinkTypes.Arrow -> $"-{link.AddedLengthLinker(addedLength)}>" 
        | FlowchartLinkTypes.Open -> $"-{link.AddedLengthLinker(addedLength)}-"
        | FlowchartLinkTypes.Dotted -> $"-{link.AddedLengthLinker(addedLength)}-"
        | FlowchartLinkTypes.DottedArrow -> $"-{link.AddedLengthLinker(addedLength)}->"
        | FlowchartLinkTypes.Thick -> $"={link.AddedLengthLinker(addedLength)}="
        | FlowchartLinkTypes.ThickArrow -> $"={link.AddedLengthLinker(addedLength)}>"
        | FlowchartLinkTypes.Invisible -> $"~{link.AddedLengthLinker(addedLength)}~"
        | FlowchartLinkTypes.CircleEdge -> $"-{link.AddedLengthLinker(addedLength)}o"
        | FlowchartLinkTypes.CrossEdge -> $"-{link.AddedLengthLinker(addedLength)}x"
        | FlowchartLinkTypes.ArrowDouble -> $"<-{link.AddedLengthLinker(addedLength)}>"
        | FlowchartLinkTypes.CircleDouble -> $"o-{link.AddedLengthLinker(addedLength)}o"
        | FlowchartLinkTypes.CrossDouble -> $"x-{link.AddedLengthLinker(addedLength)}x"
        |> FlowchartLinkTypes.appendTextOption msg

    let formatLink (n1: string) (n2: string) (link: FlowchartLinkTypes) (msg: string option) (addedLength: int option) =
        let link = formatLinkType link msg addedLength
        n1 + link + n2

    let formatSubgraph (id) (name: string option) = 
        let nameStr = if name.IsSome then sprintf "[%s]" name.Value else ""
        let opener = sprintf "subgraph %s%s" id nameStr 
        opener

    let formatLinkStyles (ids0: int list) (styles0: (string*string) list) =
        let styles = styles0 |> List.map (fun (key, v) -> sprintf "%s:%s" key v) |> String.concat ","
        let ids = ids0 |> List.map string |> String.concat ","
        sprintf "linkStyle %s %s;" ids styles

    let formatNodeStyles (ids0: string list) (styles0: (string*string) list) =
        let styles = styles0 |> List.map (fun (key, v) -> sprintf "%s:%s" key v) |> String.concat ","
        let ids = ids0 |> String.concat ","
        sprintf "style %s %s;" ids styles



module Sequence =

    open Generic

    let private formatMessageType (msgType: SequenceMessageTypes) =
        match msgType with
        | SequenceMessageTypes.Solid             -> "->"
        | SequenceMessageTypes.Dotted            -> "-->"
        | SequenceMessageTypes.Arrow             -> "->>"
        | SequenceMessageTypes.DottedArrow       -> "-->>"
        | SequenceMessageTypes.CrossEdge         -> "-x"
        | SequenceMessageTypes.DottedCrossEdge   -> "--x"
        | SequenceMessageTypes.OpenArrow         -> "-)"
        | SequenceMessageTypes.DottedOpenArrow   -> "--)"

    let formatMessage a1 a2 msgType msg (activate: bool option) =
        let active = match activate with |None -> "" | Some true -> "+"| Some false -> "-"
        sprintf "%s%s%s%s: %s" a1 (formatMessageType msgType) active a2 msg

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

    let formatNoteSpanning id1 id2 (position: NotePosition option) (msg: string) =
        let position = defaultArg position NotePosition.RightOf |> _.ToFormatString()
        sprintf "note %s %s,%s : %s" position id1 id2 msg


module ClassDiagram =
    type ClassMemberVisibility with
        member this.ToFormatString() =
            match this with
            | ClassMemberVisibility.Public            -> "+"
            | ClassMemberVisibility.Private           -> "-"
            | ClassMemberVisibility.Protected         -> "#"
            | ClassMemberVisibility.PackageInternal   -> "~"
            | ClassMemberVisibility.Custom string     -> string

    type ClassMemberClassifier with
        member this.ToFormatString() =
            match this with
            | ClassMemberClassifier.Abstract      -> "*"
            | ClassMemberClassifier.Static        -> "$"
            | ClassMemberClassifier.Custom string -> string

    type ClassRelationshipDirection with
        member this.ToFormatString(left: string, right: string, center: string) =
            match this with
            | ClassRelationshipDirection.Left  -> left + center
            | ClassRelationshipDirection.Right -> center + right
            | ClassRelationshipDirection.TwoWay -> left + center + right
        member this.ToFormatString(edge: string, center: string) =
            match this with
            | ClassRelationshipDirection.Left  -> edge + center
            | ClassRelationshipDirection.Right -> center + edge
            | ClassRelationshipDirection.TwoWay -> edge + center + edge

    type ClassRelationshipType with

        member this.ToFormatString(?direction: ClassRelationshipDirection, ?isDotted: bool) =
            let isDotted = defaultArg isDotted false
            let dotted = ".."
            let solid = "--"
            let center = if isDotted then dotted else solid
            let direct = defaultArg direction ClassRelationshipDirection.Right
            match this with
            | ClassRelationshipType.Inheritance   -> direct.ToFormatString("<|", "|>", center)
            | ClassRelationshipType.Composition   -> direct.ToFormatString("*",center)
            | ClassRelationshipType.Aggregation   -> direct.ToFormatString("o", center)
            | ClassRelationshipType.Association   -> direct.ToFormatString("<",">", center)
            | ClassRelationshipType.Link          -> center
            | ClassRelationshipType.Solid         -> solid
            | ClassRelationshipType.Dashed        -> dotted
            | ClassRelationshipType.Dependency    -> direct.ToFormatString("<",">", dotted)
            | ClassRelationshipType.Realization   -> direct.ToFormatString("<|","|>", dotted)

    type ClassCardinality with

        member this.ToFormatString() =
            match this with
            | ClassCardinality.One       -> "1"
            | ClassCardinality.ZeroOrOne -> "0..1"
            | ClassCardinality.OneOrMore -> "1..*"
            | ClassCardinality.Many      -> "*"
            | ClassCardinality.N         -> "n"
            | ClassCardinality.ZeroToN   -> "0..n"
            | ClassCardinality.OneToN    -> "1..n"
            | ClassCardinality.Custom s  -> s

    let formatClass (id) (name) generic =
        let name = name |> Option.formatString (fun s -> sprintf "[\"%s\"]" s)
        let generic = generic |> Option.formatString (fun s -> sprintf "~%s~" s)
        sprintf "class %s%s%s" id generic name

    let formatMember id label (visibility: ClassMemberVisibility option) (classifier: ClassMemberClassifier option) =
        let visibility = visibility |> Option.map _.ToFormatString() |> Option.formatString (fun x -> x)
        let classifier = classifier |> Option.map _.ToFormatString() |> Option.formatString (fun x -> x)
        sprintf "%s : %s%s%s" id visibility label classifier

    let formatRelationship0 id1 id2 (link: string) (label: string option) (cardinality1: ClassCardinality option) (cardinality2: ClassCardinality option) =
        //classI -- classJ : Link(Solid)
        //Student "1" --> "1..*" Course
        let car1 = cardinality1 |> Option.map _.ToFormatString() |> Option.formatString (fun s -> sprintf " \"%s\"" s)
        let car2 = cardinality2 |> Option.map _.ToFormatString() |> Option.formatString (fun s -> sprintf "\"%s\" " s)
        let label = label |> Option.formatString (fun l -> sprintf " : %s" l)
        sprintf "%s%s %s %s%s%s" id1 car1 link car2 id2 label

    let formatRelationship id1 id2 (rltsType: ClassRelationshipType) (label: string option) (cardinality1: ClassCardinality option) (cardinality2: ClassCardinality option) =
        let link = rltsType.ToFormatString()
        formatRelationship0 id1 id2 link label cardinality1 cardinality2

    let formatRelationshipCustom id1 id2 (rltsType: ClassRelationshipType) (direction) (dotted) (label: string option) (cardinality1: ClassCardinality option) (cardinality2: ClassCardinality option) =
        let link = rltsType.ToFormatString(?direction=direction, ?isDotted=dotted)
        formatRelationship0 id1 id2 link label cardinality1 cardinality2

    let formatAnnotation id (annotation: string) = sprintf "<<%s>> %s" annotation id

    let formatNote txt (id: string option) =
        if id.IsSome then
            sprintf "note for %s \"%s\"" id.Value txt
        else
            sprintf "note \"%s\"" txt

    let formatClassStyles (id: string) (styles0: (string*string) list) =
        let styles = styles0 |> List.map (fun (key, v) -> sprintf "%s: %s" key v) |> String.concat ","
        sprintf "style %s %s" id styles

    let formatCssClass (ids0: string list) (className: string) =
        let ids = ids0 |> String.concat ","
        sprintf "style \"%s\" %s;" ids className


module StateDiagram =

    open Generic

    let formatState id (description: string option) = 
        let description = description |> Option.formatString (fun s -> sprintf " : %s" s)
        sprintf "%s%s" id description

    let formatTransition id1 id2 (description: string option) =
        let description = description |> Option.formatString (fun s -> sprintf " : %s" s)
        sprintf "%s --> %s%s" id1 id2 description

    let formatNoteWrapper (id) (position: NotePosition option) =
        let position = defaultArg position NotePosition.RightOf |> _.ToFormatString()
        sprintf "note %s %s" position id


module ERDiagram =

    type ERCardinalityType with
        member this.ToFormatString() =
            match this with
            | ERCardinalityType.OneOrZero -> "one or zero"
            | ERCardinalityType.OneOrMany -> "one or many"
            | ERCardinalityType.ZeroOrMany -> "zero or many"
            | ERCardinalityType.OnlyOne -> "only one"

    let formatEntityNode (id) (alias: string option) =
        let alias = alias |> Option.formatString (fun s -> sprintf "[\"%s\"]" s)
        sprintf "%s%s" id alias

    let formatEntityWrapper (id) (alias: string option) =
        formatEntityNode id alias + " {"

    let formatAttribute (attr:ERAttribute) =
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

    let formatRelationship (id1) (card1: ERCardinalityType) id2 (card2: ERCardinalityType) msg (isOptional: bool option) =
        let isOptional = defaultArg isOptional false
        let toString = if isOptional then "optionally to" else "to"
        sprintf "%s %s %s %s %s : %s" id1 (card1.ToFormatString()) toString (card2.ToFormatString()) id2 msg
     
    
module UserJourney =

    let formatTask name score actors =
        let actors = actors |> Option.map (String.concat ", ")
        List.choose id [
            Some name
            Some (string score)
            actors
        ]
        |> String.concat ": "


module Gantt =

    type GanttTags with
        member this.ToFormatString() =
            match this with
            | GanttTags.Active    -> "active"
            | GanttTags.Done      -> "done"
            | GanttTags.Crit      -> "crit"
            | GanttTags.Milestone -> "milestone"

    type GanttUnit with
        member this.ToFormatString() =
            string this |> _.ToLower()

    let formatTask title (tags: GanttTags list) (selfid: string option) (startDate: string option) (endDate: string option) =
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


module PieChart =

    let formatData name value =
        sprintf "\"%s\" : %A" name value


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


module RequirementDiagram =


    type RDRiskType with
        member this.ToFormatString() = this.ToString().ToLower()

    type RDVerifyMethod with
        member this.ToFormatString() = this.ToString().ToLower()

    /// A relationship type can be one of contains, copies, derives, satisfies, verifies, refines, or traces.
    type RDRelationship with
        member this.ToFormatString() = this.ToString().ToLower()

    let createRequirement type0 name id text (risk: RDRiskType option) (methods: RDVerifyMethod option) =
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
        
    let formatRelationship id1 id2 (rltsType: RDRelationship) =
        sprintf "%s - %s -> %s" id1 (rltsType.ToFormatString()) id2


module Git =

    type GitCommitType with
        member this.ToFormatString() =
            this.ToString().ToUpper()

    let formatCommitType (commitType: GitCommitType option) =
        commitType |> Option.map (fun s -> sprintf "type: %s" <| s.ToFormatString())

    let formatTag (tag: string option) =
        tag |> Option.map (fun s -> sprintf "tag: \"%s\"" s)

    let formatSelfID (selfid: string option) =
        selfid |> Option.map (fun s -> sprintf "id: \"%s\"" s)

    let formatParentID (aprentId: string option) =
        aprentId |> Option.map (fun s -> sprintf "parent: \"%s\"" s)

    let formatCommit (selfid: string option) (commitType: GitCommitType option) (tag: string option) =
        [
            Some "commit"
            selfid |> formatSelfID
            commitType |> formatCommitType
            tag |> formatTag
        ]
        |> List.choose id
        |> String.concat " "

    let formatMerge targetId mergeId (commitType: GitCommitType option) tag =
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


module Mindmap =

    let formatNode (id: string) (name: string option) t =
        let name = defaultArg name id
        match t with
        | MindmapShape.Square -> sprintf "%s[%s]" id name
        | MindmapShape.RoundedSquare -> sprintf "%s(%s)" id name
        | MindmapShape.Circle -> sprintf "%s((%s))" id name
        | MindmapShape.Bang -> sprintf "%s))%s((" id name
        | MindmapShape.Cloud -> sprintf "%s)%s(" id name
        | MindmapShape.Hexagon -> sprintf "%s{{%s}}" id name

    let handleNodeChildren (children: #seq<MindmapElement> option) (opener: string)  =
        if children.IsSome && Seq.isEmpty children.Value |> not then
            MindmapWrapper (opener, "", List.ofSeq children.Value)
        else
            MindmapElement opener


module Timeline =

    let formatSingle header (data: string option) =
        match data with
        | None -> header
        | Some event -> sprintf "%s : %s" header event

    let createMultiple header (data: string list) =
        let children = data |> List.map (fun s -> ": " + s |> TimelineElement)
        TimelineWrapper(header,"", children)



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



module XYChart =
    let formatData (data: string list) =
        ("[" + (data |> String.concat ", ") + "]")

    let formatXAxis name data =
        [
            Some "x-axis"
            name |> Option.map (fun name -> sprintf "\"%s\"" name)
            Some (formatData data)
        ]
        |> List.choose id
        |> String.concat " "

    let formatXAxisRange (name: string option) (data: float*float) =
        [
            Some "x-axis"
            name |> Option.map (fun name -> sprintf "\"%s\"" name)
            Some (sprintf "%f --> %f" (fst data) (snd data))
        ]
        |> List.choose id
        |> String.concat " "

    let formatYAxis (name: string option) (data: (float*float) option) =
        [
            Some "y-axis"
            name |> Option.map (fun name -> sprintf "\"%s\"" name)
            data |> Option.map (fun data -> sprintf "%f --> %f" (fst data) (snd data))
        ]
        |> List.choose id
        |> String.concat " "
        
    let formatLine (data: float list) = sprintf "line %s" (data |> List.map string |> formatData)
    let formatBar (data: float list) = sprintf "bar %s" (data |> List.map string |> formatData)

module Block =

    type BlockBlockType with
        member this.ToFormatString(id: string, label: string) =
            match this with
            | BlockBlockType.Square -> sprintf "%s[\"%s\"]" id label
            | BlockBlockType.RoundedEdge -> sprintf "%s(\"%s\")" id label
            | BlockBlockType.Stadium -> sprintf "%s([\"%s\"])" id label
            | BlockBlockType.Subroutine -> sprintf "%s[[\"%s\"]]" id label
            | BlockBlockType.Cylindrical -> sprintf "%s[(\"%s\")]" id label
            | BlockBlockType.Circle -> sprintf "%s((\"%s\"))" id label
            | BlockBlockType.Asymmetric -> sprintf "%s>\"%s\"]" id label
            | BlockBlockType.Rhombus -> sprintf "%s{\"%s\"}" id label
            | BlockBlockType.Hexagon -> sprintf "%s{{\"%s\"}}" id label
            | BlockBlockType.Parallelogram -> sprintf "%s[/\"%s\"/]" id label
            | BlockBlockType.ParallelogramAlt -> sprintf "%s[\\\"%s\"\\]" id label
            | BlockBlockType.Trapezoid -> sprintf "%s[/\"%s\"\]" id label
            | BlockBlockType.TrapezoidAlt -> sprintf "%s[\\\"%s\"/]" id label
            | BlockBlockType.DoubleCircle -> sprintf "%s(((\"%s\")))" id label

    type BlockArrowDirection with
        member this.ToFormatString() =
            match this with
            | BlockArrowDirection.Custom s -> s
            | anyElse -> anyElse.ToString().ToLower()

    let formatBlockType (id: string) (label:string option) (width: int option) (blockType: BlockBlockType) =
        let label = defaultArg label id
        let baseStr = blockType.ToFormatString(id, label)
        let width = width |> Option.map (fun w -> sprintf ":%i" w)
        baseStr + (width |> Option.defaultValue "")

    let formatBlockArrow (id: string) (label: string option) (direction: BlockArrowDirection) =
        let label = defaultArg label id
        let directionStr = direction.ToFormatString()
        sprintf "%s<[\"%s\"]>(%s)" id label directionStr

    let formatEmptyBlockArrow (id: string) (width: int option) (direction: BlockArrowDirection) =
        let width = defaultArg width 3
        let labelStr = String.init width (fun _ -> Generic.ProtectedWhitespace)
        let directionStr = direction.ToFormatString()
        sprintf "%s<[\"%s\"]>(%s)" id labelStr directionStr

    let formatSpace (width: int option) =
        if width.IsSome then sprintf "space:%i" width.Value else "space"

    let formatLink id1 id2 (label: string option) =
        if label.IsSome then
            sprintf "%s-- \"%s\" -->%s" id1 label.Value id2
        else
            sprintf "%s-->%s" id1 id2

    let formatStyle (id: string) (styles: (string*string) list) =
        let styles = styles |> List.map (fun (key, v) -> sprintf "%s:%s" key v) |> String.concat ","
        sprintf "style %s %s;" id styles

    let formatClass (nodeIds0: string list) (className: string) =
        Generic.formatClass nodeIds0 className
        |> fun x -> x.TrimEnd(';')