namespace Siren

open Fable.Core
open Util
open Types
open Formatting

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

[<AttachMembers>]
type flowchart =
    static member raw (txt: string) = FlowchartElement txt
    static member id (txt: string) = FlowchartElement txt
    static member node (id: string, ?name: string) : FlowchartElement = 
        Flowchart.formatNode id name Flowchart.NodeTypes.Default |> FlowchartElement
    static member nodeRound (id: string, ?name: string) : FlowchartElement = 
        Flowchart.formatNode id name Flowchart.NodeTypes.Round |> FlowchartElement
    static member nodeStadium (id: string, ?name: string) : FlowchartElement = 
        Flowchart.formatNode id name Flowchart.NodeTypes.Stadium |> FlowchartElement
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
    static member linkArrow (id1: string, id2: string, ?message: string, ?addedLength) = 
        Flowchart.formatLink id1 id2 Flowchart.LinkTypes.Arrow message addedLength |> FlowchartElement
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


#if FABLE_COMPILER_PYTHON
[<CompiledName("note_position")>]
#endif
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
    static member box (name: string, children: #seq<SequenceElement>) = SequenceWrapper (Sequence.formatBox name None, "end", List.ofSeq children)
    static member boxColored (name: string, color: string, children: #seq<SequenceElement>) = SequenceWrapper (Sequence.formatBox name (Some color), "end", List.ofSeq children)
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


#if FABLE_COMPILER_PYTHON
[<CompiledName("member_visibility")>]
#endif
[<AttachMembers>]
type memberVisibility =
    static member ``public`` = ClassDiagram.MemberVisibility.Public
    static member ``private`` = ClassDiagram.MemberVisibility.Private
    static member ``protected`` = ClassDiagram.MemberVisibility.Protected
    static member packageInternal = ClassDiagram.MemberVisibility.PackageInternal
    static member custom str = ClassDiagram.MemberVisibility.Custom str

#if FABLE_COMPILER_PYTHON
[<CompiledName("member_classifier")>]
#endif
[<AttachMembers>]
type memberClassifier =
    static member ``abstract`` = ClassDiagram.MemberClassifier.Abstract
    static member ``static`` = ClassDiagram.MemberClassifier.Static
    static member custom str = ClassDiagram.MemberClassifier.Custom str

#if FABLE_COMPILER_PYTHON
[<CompiledName("class_direction")>]
#endif
[<AttachMembers>]
type classDirection =
    static member twoWay = ClassDiagram.ClassRelationshipDirection.TwoWay
    static member left = ClassDiagram.ClassRelationshipDirection.Left
    static member right = ClassDiagram.ClassRelationshipDirection.Right

#if FABLE_COMPILER_PYTHON
[<CompiledName("class_cardinality")>]
#endif
[<AttachMembers>]
type classCardinality =
    static member n = ClassDiagram.Cardinality.N
    static member many = ClassDiagram.Cardinality.Many
    static member one = ClassDiagram.Cardinality.One
    static member oneOrMore = ClassDiagram.Cardinality.OneOrMore
    static member oneToN = ClassDiagram.Cardinality.OneToN
    static member zeroOrOne = ClassDiagram.Cardinality.ZeroOrOne
    static member zeroToN = ClassDiagram.Cardinality.ZeroToN
    static member custom (cardinality: string) = ClassDiagram.Cardinality.Custom cardinality
    
type classRltsType =
    static member inheritance = ClassDiagram.ClassRelationshipType.Inheritance
    static member aggregation = ClassDiagram.ClassRelationshipType.Aggregation
    static member association = ClassDiagram.ClassRelationshipType.Association
    static member composition = ClassDiagram.ClassRelationshipType.Composition
    static member dashed = ClassDiagram.ClassRelationshipType.Dashed
    static member dependency = ClassDiagram.ClassRelationshipType.Dependency
    static member link = ClassDiagram.ClassRelationshipType.Link
    static member realization = ClassDiagram.ClassRelationshipType.Realization
    static member solid = ClassDiagram.ClassRelationshipType.Solid
    

#if FABLE_COMPILER_PYTHON
[<CompiledName("class_diagram")>]
#endif
[<AttachMembers>]
type classDiagram =
    static member raw (txt: string) = ClassDiagramElement txt
    static member ``class`` (id: string, ?name: string, ?generic: string, ?members: #seq<string>) = 
        if members.IsSome then ClassDiagramWrapper (ClassDiagram.formatClass id name generic + "{","}", (List.ofSeq >> List.map ClassDiagramElement) members.Value) 
        else ClassDiagram.formatClass id name generic |> ClassDiagramElement
    static member ``member`` (id: string, label:string, ?memberVisibility: ClassDiagram.MemberVisibility, ?memberClassifier: ClassDiagram.MemberClassifier) = 
        ClassDiagram.formatMember id label memberVisibility memberClassifier |> ClassDiagramElement
    static member memberAbstract(id: string, label:string, ?memberVisibility: ClassDiagram.MemberVisibility) =
        ClassDiagram.formatMember id label memberVisibility (Some ClassDiagram.MemberClassifier.Abstract) |> ClassDiagramElement
    static member memberStatic(id: string, label:string, ?memberVisibility: ClassDiagram.MemberVisibility) =
        ClassDiagram.formatMember id label memberVisibility (Some ClassDiagram.MemberClassifier.Static) |> ClassDiagramElement
    
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

    static member ``namespace`` (name: string, children: #seq<ClassDiagramElement>) =
        if Seq.isEmpty children then ClassDiagramNone 
        else ClassDiagramWrapper (sprintf "namespace %s {" name,"}", List.ofSeq children)
    static member annotation (id: string, annotation: string) : ClassDiagramElement = classDiagram.annotationString (id, annotation) |> ClassDiagramElement
    static member annotationString (id: string, annotation: string) : string = ClassDiagram.formatAnnotation id annotation
    static member comment (txt:string) = Generic.formatComment txt |> ClassDiagramElement
    static member direction (direction: Direction) = Generic.formatDirection direction |> ClassDiagramElement
    static member clickHref(id,url,?tooltip) = Generic.formatClickHref id url tooltip |> ClassDiagramElement
    //static member clickCallback() = failwith "TODO"
    static member note(txt:string, ?id: string) = ClassDiagram.formatNote txt id |> ClassDiagramElement
    static member link(id: string, url: string, ?tooltip: string) = Generic.formatClickHref id url tooltip |> ClassDiagramElement
    //static member callback(id: string, func: unit -> unit, ?tooltip: string) = failwith "TODO"

#if FABLE_COMPILER_PYTHON
[<CompiledName("state_diagram")>]
#endif
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



#if FABLE_COMPILER_PYTHON
[<CompiledName("er_key")>]
#endif
[<AttachMembers>]
type erKey =
    static member pk = ERDiagram.ERKeyType.PK
    static member fk = ERDiagram.ERKeyType.FK
    static member uk = ERDiagram.ERKeyType.UK

#if FABLE_COMPILER_PYTHON
[<CompiledName("er_cardinality")>]
#endif
[<AttachMembers>]
type erCardinality =
    /// <summary>
    /// }| or |{
    /// </summary>
    /// <param name="oneOrZero"></param>
    static member oneOrMany = ERDiagram.ERCardinalityType.OneOrMany
    /// <summary>
    /// |o or o|
    /// </summary>
    /// <param name="oneOrZero"></param>
    static member oneOrZero = ERDiagram.ERCardinalityType.OneOrZero
    /// <summary>
    /// ||
    /// </summary>
    /// <param name="oneOrMany"></param>
    static member onlyOne = ERDiagram.ERCardinalityType.OnlyOne
    /// <summary>
    /// }o or o{
    /// </summary>
    /// <param name="zeroOrMany"></param>
    static member zeroOrMany = ERDiagram.ERCardinalityType.ZeroOrMany
    
#if FABLE_COMPILER_PYTHON
[<CompiledName("er_diagram")>]
#endif
[<AttachMembers>]
type erDiagram =
    static member raw (line: string) = ERDiagramElement line
    static member entity (id: string, ?alias: string, ?attr: #seq<ERDiagram.ERAttribute>) = 
        if attr.IsSome then 
            let children = [for attr in attr.Value do ERDiagram.formatAttribute attr |> ERDiagramElement] // of attributes
            ERDiagramWrapper (ERDiagram.formatEntityWrapper id alias, "}", children) 
        else ERDiagram.formatEntityNode id alias |> ERDiagramElement
    static member relationship(id1, erCardinality1, id2, erCardinality2, message, ?isOptional: bool) = 
        ERDiagram.formatRelationship id1 erCardinality1 id2 erCardinality2 message isOptional |> ERDiagramElement
    static member attribute(attrType: string, name: string, ?keys: #seq<ERDiagram.ERKeyType>, ?comment: string) : ERDiagram.ERAttribute = 
        {Type=attrType; Name=name;Keys=Option.map List.ofSeq keys |> Option.defaultValue []; Comment = comment}


[<AttachMembers>]
type journey =
    static member raw (line: string) = JourneyElement line
    static member title (name: string) = sprintf "title %s" name |> JourneyElement
    static member section (name: string) = sprintf "section %s" name |> JourneyElement
    static member task (name: string, score: int, ?actors: #seq<string>) = UserJourney.formatTask name score actors |> JourneyElement


#if FABLE_COMPILER_PYTHON
[<CompiledName("gantt_time")>]
#endif
[<AttachMembers>]
type ganttTime =
    static member length (timespan: string) : string = timespan
    static member dateTime (datetime: string) : string = datetime
    static member after (id) : string = sprintf "after %s" id
    static member until (id) : string = sprintf "until %s" id

#if FABLE_COMPILER_PYTHON
[<CompiledName("gantt_tags")>]
#endif
[<AttachMembers>]
type ganttTags =
    static member active = Gantt.GanttTags.Active
    static member ``done`` = Gantt.GanttTags.Done
    static member crit = Gantt.GanttTags.Crit
    static member milestone = Gantt.GanttTags.Milestone

#if FABLE_COMPILER_PYTHON
[<CompiledName("gantt_unit")>]
#endif
[<AttachMembers>]
type ganttUnit =
    static member millisecond = Gantt.GanttUnit.Millisecond
    static member second = Gantt.GanttUnit.Second
    static member minute = Gantt.GanttUnit.Minute
    static member hour = Gantt.GanttUnit.Hour
    static member day = Gantt.GanttUnit.Day
    static member week = Gantt.GanttUnit.Week
    static member month = Gantt.GanttUnit.Month

[<AttachMembers>]
type gantt =
    static member raw (line: string) = GanttElement line
    static member title (name: string) = sprintf "title %s" name |> GanttElement
    static member section (name: string) = sprintf "section %s" name |> GanttElement

    static member task (title: string, id: string, startDate:string, endDate: string, ?tags: #seq<Gantt.GanttTags>) = 
        Gantt.formatTask title (Option.defaultBind List.ofSeq [] tags) (Some id) (Some startDate) (Some endDate) |> GanttElement
    static member taskStartEnd (title: string, startDate:string, endDate: string, ?tags: #seq<Gantt.GanttTags>) = 
        Gantt.formatTask title (Option.defaultBind List.ofSeq [] tags) (None) (Some startDate) (Some endDate) |> GanttElement
    static member taskEnd (title: string, endDate: string, ?tags: #seq<Gantt.GanttTags>) = 
        Gantt.formatTask title (Option.defaultBind List.ofSeq [] tags) (None) (None) (Some endDate) |> GanttElement

    static member milestone (title: string, id: string, startDate:string, endDate: string, ?tags: #seq<Gantt.GanttTags>) = 
        Gantt.formatTask title (ganttTags.milestone::Option.defaultBind List.ofSeq [] tags) (Some id) (Some startDate) (Some endDate) |> GanttElement
    static member milestoneStartEnd (title: string, startDate:string, endDate: string, ?tags: #seq<Gantt.GanttTags>) = 
        Gantt.formatTask title (ganttTags.milestone::Option.defaultBind List.ofSeq [] tags) (None) (Some startDate) (Some endDate) |> GanttElement
    static member milestoneEnd (title: string, endDate: string, ?tags: #seq<Gantt.GanttTags>) = 
        Gantt.formatTask title (ganttTags.milestone::Option.defaultBind List.ofSeq [] tags) (None) (None) (Some endDate) |> GanttElement

    static member dateFormat (formatString: string) = sprintf "dateFormat %s" formatString |> GanttElement
    static member axisFormat (formatString: string) = sprintf "axisFormat %s" formatString |> GanttElement
    static member tickInterval (interval: int, unit: Gantt.GanttUnit) = sprintf "tickInterval %i%s" interval (unit.ToFormatString()) |> GanttElement ///^([1-9][0-9]*)(millisecond|second|minute|hour|day|week|month)$/;

    static member weekday (day: string) = sprintf "weekday %s" day |> GanttElement 
    static member excludes (day: string) = sprintf "excludes %s" day |> GanttElement 
    static member comment (txt: string) = Generic.formatComment txt |> GanttElement


#if FABLE_COMPILER_PYTHON
[<CompiledName("pie_chart")>]
#endif
[<AttachMembers>]
type pieChart =
    static member raw (line: string) = PieChartElement line
    static member data (name: string, value: float) = PieChart.formatData name value |> PieChartElement
    static member data (name: string, value: int) = PieChart.formatData name value |> PieChartElement



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


#if FABLE_COMPILER_PYTHON
[<CompiledName("rq_risk")>]
#endif
[<AttachMembers>]
type rqRisk =
    static member low = RequirementDiagram.RiskType.Low
    static member medium = RequirementDiagram.RiskType.Medium
    static member high = RequirementDiagram.RiskType.High

#if FABLE_COMPILER_PYTHON
[<CompiledName("rq_method")>]
#endif
[<AttachMembers>]
type rqMethod =
    static member analysis = RequirementDiagram.VerifyMethod.Analysis
    static member inspection = RequirementDiagram.VerifyMethod.Inspection
    static member test = RequirementDiagram.VerifyMethod.Test
    static member demonstration = RequirementDiagram.VerifyMethod.Demonstration

#if FABLE_COMPILER_PYTHON
[<CompiledName("req_dia")>]
#endif
[<AttachMembers>]
type reqDia =
    static member raw (txt: string) = RequirementDiagramElement txt

    static member requirement (name, ?id: string, ?text: string, ?rqRisk: RequirementDiagram.RiskType, ?rqMethod: RequirementDiagram.VerifyMethod) =
        RequirementDiagram.createRequirement "requirement" name id text rqRisk rqMethod
    static member functionalRequirement (name, ?id: string, ?text: string, ?rqRisk: RequirementDiagram.RiskType, ?rqMethod: RequirementDiagram.VerifyMethod) =
        RequirementDiagram.createRequirement "functionalRequirement" name id text rqRisk rqMethod
    static member interfaceRequirement (name, ?id: string, ?text: string, ?rqRisk: RequirementDiagram.RiskType, ?rqMethod: RequirementDiagram.VerifyMethod) =
        RequirementDiagram.createRequirement "interfaceRequirement" name id text rqRisk rqMethod
    static member performanceRequirement (name, ?id: string, ?text: string, ?rqRisk: RequirementDiagram.RiskType, ?rqMethod: RequirementDiagram.VerifyMethod) =
        RequirementDiagram.createRequirement "performanceRequirement" name id text rqRisk rqMethod
    static member physicalRequirement (name, ?id: string, ?text: string, ?rqRisk: RequirementDiagram.RiskType, ?rqMethod: RequirementDiagram.VerifyMethod) = 
        RequirementDiagram.createRequirement "physicalRequirement" name id text rqRisk rqMethod
    static member designConstraint (name, ?id: string, ?text: string, ?rqRisk: RequirementDiagram.RiskType, ?rqMethod: RequirementDiagram.VerifyMethod) =
        RequirementDiagram.createRequirement "designConstraint" name id text rqRisk rqMethod

    static member element (name, ?elementType, ?docref) = RequirementDiagram.createElement name elementType docref

    static member contains (id1, id2) = RequirementDiagram.formatRelationship id1 id2 RequirementDiagram.Contains |> RequirementDiagramElement
    static member copies (id1, id2) = RequirementDiagram.formatRelationship id1 id2 RequirementDiagram.Copies |> RequirementDiagramElement
    static member derives (id1, id2) = RequirementDiagram.formatRelationship id1 id2 RequirementDiagram.Derives |> RequirementDiagramElement
    static member satisfies (id1, id2) = RequirementDiagram.formatRelationship id1 id2 RequirementDiagram.Satisfies |> RequirementDiagramElement
    static member verifies (id1, id2) = RequirementDiagram.formatRelationship id1 id2 RequirementDiagram.Verifies |> RequirementDiagramElement
    static member refines (id1, id2) = RequirementDiagram.formatRelationship id1 id2 RequirementDiagram.Refines |> RequirementDiagramElement
    static member traces (id1, id2) = RequirementDiagram.formatRelationship id1 id2 RequirementDiagram.Traces |> RequirementDiagramElement


#if FABLE_COMPILER_PYTHON
[<CompiledName("git_type")>]
#endif
[<AttachMembers>]
type gitType =
    static member normal = Git.GitCommitType.NORMAL
    static member reverse = Git.GitCommitType.REVERSE
    static member highlight = Git.GitCommitType.HIGHLIGHT

[<AttachMembers>]
type git =
    static member raw (line:string) = GitGraphElement line
    static member commit (?id: string, ?gitType: Git.GitCommitType, ?tag: string) = Git.formatCommit id gitType tag |> GitGraphElement
    static member merge (targetBranchId: string, ?mergeid: string, ?gitType: Git.GitCommitType, ?tag: string) = 
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


[<AttachMembers>]
type timeline =
    static member raw (line: string) = TimelineElement line
    static member title (name: string) = "title " + name |> TimelineElement
    static member period (name: string) = TimelineElement name
    static member single (timePeriod: string, ?event: string) = Timeline.formatSingle timePeriod event |> TimelineElement
    static member multiple (timePeriod: string, events: #seq<string>) = Timeline.createMultiple timePeriod (List.ofSeq events)
    static member section (name: string, children: #seq<TimelineElement>) = TimelineWrapper ("section " + name,"",List.ofSeq children)
    static member comment (txt: string) = Generic.formatComment txt |> TimelineElement


[<AttachMembers>]
type sankey =
    static member raw(line: string) = SankeyElement line
    static member comment (txt: string) = Generic.formatComment txt |> SankeyElement
    static member link (source: string, target: string, value: float) = 
        Sankey.formatLink source target value |> SankeyElement //remember to escape " and , for the user
    static member links (source: string, targets: #seq<string*float>) = 
        Sankey.createLinks source (List.ofSeq targets)


#if FABLE_COMPILER_PYTHON
[<CompiledName("xy_chart")>]
#endif
[<AttachMembers>]
type xyChart =
    static member raw(line: string) = XYChartElement line
    static member title(name: string) = sprintf "title \"%s\"" name |> XYChartElement

    static member xAxis (data: #seq<string>) = XYChart.formatXAxis None (List.ofSeq data) |> XYChartElement
    static member xAxisNamed (name: string, data: #seq<string>) = XYChart.formatXAxis (Some name) (List.ofSeq data) |> XYChartElement
    static member xAxisRange (rangeStart: float, rangeEnd: float) = XYChart.formatXAxisRange (None) (rangeStart,rangeEnd) |> XYChartElement
    static member xAxisNamedRange (name: string, rangeStart: float, rangeEnd: float) = XYChart.formatXAxisRange (Some name) (rangeStart,rangeEnd) |> XYChartElement

    static member yAxis (name: string) = XYChart.formatYAxis (Some name) None |> XYChartElement
    static member yAxisRange (rangeStart: float, rangeEnd: float) = XYChart.formatYAxis (None) (Some (rangeStart,rangeEnd)) |> XYChartElement
    static member yAxisNamedRange (name: string, rangeStart: float, rangeEnd: float) = XYChart.formatYAxis (Some name) (Some (rangeStart,rangeEnd)) |> XYChartElement

    static member line (data: #seq<float>) = XYChart.formatLine (List.ofSeq data) |> XYChartElement
    static member bar (data: #seq<float>) = XYChart.formatBar (List.ofSeq data) |> XYChartElement
    static member comment (txt) = Generic.formatComment txt |> XYChartElement

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
    static member pieChart (children: #seq<PieChartElement>, ?showData: bool, ?title: string) = SirenElement.PieChart(defaultArg showData false, title, List.ofSeq children)
    static member quadrant (children: #seq<QuadrantElement>) = SirenElement.Quadrant (List.ofSeq children)
    static member requirement (children: #seq<RequirementDiagramElement>) = SirenElement.RequirementDiagram (List.ofSeq children)
    static member git (children: #seq<GitGraphElement>) = SirenElement.GitGraph (List.ofSeq children)
    static member mindmap (children: #seq<MindmapElement>) = SirenElement.Mindmap (List.ofSeq children)
    static member timeline (children: #seq<TimelineElement>) = SirenElement.Timeline (List.ofSeq children)
    static member sankey (children: #seq<SankeyElement>) = SirenElement.Sankey (List.ofSeq children)
    static member xyChart (children: #seq<XYChartElement>, ?isHorizontal: bool) = SirenElement.XYChart (defaultArg isHorizontal false, List.ofSeq children)
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
        | SirenElement.PieChart (showData, title, children) ->
            let dia = ["pie"; if showData then "showData"; if title.IsSome then sprintf "title %s" title.Value] |> String.concat " "
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
        | SirenElement.XYChart (isHorizontal, children) ->
            let dia = "xychart-beta"  + if isHorizontal then " horizontal" else ""
            writeYamlDiagramRoot dia children
        |> Yaml.write