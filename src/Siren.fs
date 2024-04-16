namespace Siren

open Fable.Core


module rec Types =

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

    type ISequenceDiagramElement = interface end
    type IPieChartElement = interface end
    type IClassDiagramElement = interface end
    type IDirection = interface end
    type IFlowChartDirection = obj
    type ILinkType = obj

    type FlowChartElement =
        | FlowChartElement of string
        | FlowChartSubgraph of id:string * name: string option * FlowChartElement list

    type FlowChart = {
        Name: string
        Direction: IFlowChartDirection
    }

    type PieChart = {
        showData: bool
        title: string
    }
    type SequenceElement = 
        | SequenceElement of string
        | SequenceWrapper of opener: string * closer: string * SequenceElement list

    type ClassDiagramElement = 
        | ClassDiagramElement of string
        | ClassDiagramWrapper of opener: string * closer: string * ClassDiagramElement list

    type StateDiagramElement =
        | StateDiagramElement of string
        | StateDiagramWrapper of opener: string * closer: string * StateDiagramElement list

    [<RequireQualifiedAccess>]
    type SirenElement =
    | FlowChart of FlowChart * FlowChartElement list 
    | Sequence of SequenceElement list
    | Class of ClassDiagramElement list
    | State of StateDiagramElement list
    | StateV2 of StateDiagramElement list
    | PieChart of PieChart * IPieChartElement list

[<AttachMembers>]
type formatting =
    //static member escaped (txt: string) = // idea for escaping for example quotes
    static member unicode (txt: string) = string '"' + txt + string '"'
    static member markdown (txt: string) = string """ "` """ + txt + string """ `" """

open Types

[<AttachMembers>]
type nodeType =
    static member default_ = NodeTypes.Default

[<AttachMembers>]
type flowchart =
    static member raw (txt: string) = FlowChartElement txt
    static member id (str: string) = FlowChartElement str
    static member node (id: string, ?name: string, ?shape:NodeTypes) : FlowChartElement = FlowChartElement "TODO"
    static member direction (direction: IDirection) = FlowChartElement "TODO"
    static member link (ele1: FlowChartElement, ele2: FlowChartElement, ?linkType: ILinkType, ?message: string) = FlowChartElement ""
    static member subgraph (id: string, name: string, children: #seq<FlowChartElement>) = FlowChartSubgraph (id, Some name, List.ofSeq children)
    static member subgraph (id: string, children: #seq<FlowChartElement>) = FlowChartSubgraph (id,None, List.ofSeq children)
    static member clickHref() = failwith "TODO"
    static member clickCallback() = failwith "TODO"

type INotePosition = obj

[<AttachMembers>]
type sequenceDiagram =
    static member raw (txt: string) = SequenceElement txt
    static member id (str: string) = SequenceElement str
    static member participant (str: string, ?alias) = SequenceElement "TODO"
    static member actor (str: string, ?alias) = SequenceElement "TODO"
    static member create (actor: SequenceElement) = SequenceElement "TODO"
    static member destroy (actor: SequenceElement) = SequenceElement "TODO"
    static member box (name: string, color: string, children: #seq<SequenceElement>) = SequenceWrapper ("TODO", "", List.ofSeq children)
    static member message(a1, a2, message, messageType, activate: bool option) = SequenceElement "TODO"
    static member activate(id: string) = SequenceElement "TODO"
    static member deactivate(id: string) = SequenceElement "TODO"
    static member note(id: string, text: string, ?notePosition: INotePosition) = SequenceElement "TODO"
    static member noteSpanning(id1: string, id2, text: string, ?notePosition: INotePosition) = SequenceElement "TODO"
    static member alt(name: string, elseList: #seq<string*#seq<SequenceElement>>) = SequenceWrapper (name, "", [])
    static member opt(name: string, children: #seq<SequenceElement>) = SequenceWrapper (name, "", List.ofSeq children)
    static member par(name: string, andList: #seq<string*#seq<SequenceElement>>) = SequenceWrapper (name, "", [])
    static member critical(name: string, optionList: #seq<string*#seq<SequenceElement>>) = SequenceWrapper (name, "", [])
    static member break (name: string, children: #seq<SequenceElement>) = SequenceWrapper (name, "", List.ofSeq children)
    static member rect (color: string, children: #seq<SequenceElement>) = SequenceWrapper (color, "", List.ofSeq children)
    static member comment (txt: string) = SequenceElement txt
    static member autoNumber = SequenceElement "autonumber"
    static member link (id: string, urlLabel: string, url: string) = SequenceElement "TODO"
    static member links (id: string, linkJson: obj) = SequenceElement "TODO" // look at implementation

type IAccessibility = obj
type IClassifier = obj
type IReleationshipType = obj
type ICardinality = obj

type classDiagram =
    static member raw (txt: string) = ClassDiagramElement txt
    static member class' (id: string, ?label: string, ?members: #seq<string>) = if members.IsSome then ClassDiagramWrapper ("TODO","",[]) else ClassDiagramElement "TODO"
    static member classMember (id: string, label:string, ?accessibility: IAccessibility, ?classifier: IClassifier) = ClassDiagramElement "TODO"
    static member attribute (name: string, ?type': string, ?accessibility: IAccessibility, ?classifier: IClassifier) : string = "TODO"
    static member function' (name: string, args: string, ?type': string, ?accessibility: IAccessibility, ?classifier: IClassifier) : string = "TODO"
    static member generic (name: string) : string = "TODO"
    static member relationship (c1, c2, ?rltsType: IReleationshipType,?msg: string, ?cardinality1: ICardinality, ?cardinality2: ICardinality) = ClassDiagramElement "TODO"
    static member rlts (c1, c2, ?rltsType: IReleationshipType) = classDiagram.relationship (c1,c2,rltsType=rltsType)
    static member namespace' (name: string, children: #seq<ClassDiagramElement>) = ClassDiagramWrapper (name,"",List.ofSeq children)
    static member annotation (id: string, annotation: string) = ClassDiagramElement "TODO"
    static member annotationString (id: string, annotation: string) : string = "TODO"
    static member comment (txt:string) = ClassDiagramElement "TODO"
    static member direction (direction: IDirection) = ClassDiagramElement "TODO"
    static member clickHref() = failwith "TODO"
    static member clickCallback() = failwith "TODO"
    static member note(txt:string, ?id: string) = ClassDiagramElement "TODO"
    static member link(id: string, url: string, ?tooltip: string) = ClassDiagramElement "TODO"
    static member callback(id: string, func: unit -> unit, ?tooltip: string) = failwith "TODO"

type ITransitionType = obj

type stateDiagram =
    static member state (id: string, ?description: string) = StateDiagramElement "TODO"
    static member stateIf (id: string) = StateDiagramElement "TODO" //state if_state <<choice>>
    static member stateFork (id: string) = StateDiagramElement "TODO" // state fork_state <<fork>>
    static member transition (id1: string, id2: string, ?transitionType: ITransitionType, ?description: string) = StateDiagramElement "TODO"
    static member startStop = StateDiagramElement "TODO"
    static member startStopString : string = "[*]"
    static member stateComposite (id: string, children: #seq<StateDiagramElement>) = StateDiagramWrapper ("TODO","TODO", List.ofSeq children)
    static member note (id: string, notePosition: INotePosition) = StateDiagramElement "TODO"
    /// Can only be used in stateComposite
    static member concurrency = StateDiagramElement "--" 
    static member direction (direction: IDirection) = StateDiagramElement "TODO"
    static member comment (txt: string) = StateDiagramElement "TODO"

[<AttachMembers>]
type diagram =
    static member flowchart (name, children: #seq<FlowChartElement>, ?direction) = SirenElement.FlowChart ({Name = name; Direction = direction}, List.ofSeq children)
    static member sequence (children: #seq<SequenceElement>) = SirenElement.Sequence (List.ofSeq children)
    static member classDiagram (children: #seq<ClassDiagramElement>) = SirenElement.Class(List.ofSeq children)
    static member state (children: #seq<StateDiagramElement>) = SirenElement.State(List.ofSeq children)
    static member stateV2 (children: #seq<StateDiagramElement>) = SirenElement.StateV2(List.ofSeq children)
    static member pieChart (name, children: #seq<IPieChartElement>, ?showData) = SirenElement.PieChart({showData = defaultArg showData false; title = name}, List.ofSeq children)
    

