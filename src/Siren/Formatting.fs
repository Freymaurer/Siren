module Siren.Formatting

open Siren.Util
open Siren.Types

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

    let formatNoteSpanning id1 id2 (position: Generic.NotePosition option) (msg: string) =
        let position = defaultArg position Generic.NotePosition.RightOf |> _.ToFormatString()
        sprintf "note %s %s,%s : %s" position id1 id2 msg


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

    let formatRelationship id1 id2 (rltsType: ClassRelationshipType) (label: string option) (cardinality1: Cardinality option) (cardinality2: Cardinality option) =
        let link = rltsType.ToFormatString()
        formatRelationship0 id1 id2 link label cardinality1 cardinality2

    let formatRelationshipCustom id1 id2 (rltsType: ClassRelationshipType) (direction) (dotted) (label: string option) (cardinality1: Cardinality option) (cardinality2: Cardinality option) =
        let link = rltsType.ToFormatString(?direction=direction, ?isDotted=dotted)
        formatRelationship0 id1 id2 link label cardinality1 cardinality2

    let formatAnnotation id (annotation: string) = sprintf "<<%s>> %s" annotation id

    let formatNote txt (id: string option) =
        if id.IsSome then
            sprintf "note for %s \"%s\"" id.Value txt
        else
            sprintf "note \"%s\"" txt


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


module ERDiagram =

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