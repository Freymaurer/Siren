namespace Siren.Sea;

using static Siren.Formatting;
using static Siren.Types;
using Util;

using static Formatting.ClassDiagram;

public static class classRltsType
{
    public static ClassRelationshipType inheritance
         => Siren.classRltsType.inheritance;
    public static ClassRelationshipType aggregation
         => Siren.classRltsType.aggregation;
    public static ClassRelationshipType association
         => Siren.classRltsType.association;
    public static ClassRelationshipType composition
         => Siren.classRltsType.composition;
    public static ClassRelationshipType dashed
         => Siren.classRltsType.dashed;
    public static ClassRelationshipType dependency
         => Siren.classRltsType.dependency;
    public static ClassRelationshipType link
         => Siren.classRltsType.link;
    public static ClassRelationshipType realization
         => Siren.classRltsType.realization;
    public static ClassRelationshipType solid
         => Siren.classRltsType.solid;
}

public static class classCardinality
{
    public static Cardinality n
         => Siren.classCardinality.n;
    public static Cardinality many
         => Siren.classCardinality.many;
    public static Cardinality one
         => Siren.classCardinality.one;
    public static Cardinality oneOrMore
         => Siren.classCardinality.oneOrMore;
    public static Cardinality oneToN
         => Siren.classCardinality.oneToN;
    public static Cardinality zeroOrOne
         => Siren.classCardinality.zeroOrOne;
    public static Cardinality zeroToN
         => Siren.classCardinality.zeroToN;
    public static Cardinality custom(string cardinality)
         => Siren.classCardinality.custom(cardinality);
}

public static class classDirection
{
    public static ClassRelationshipDirection twoWay
         => Siren.classDirection.twoWay;
    public static ClassRelationshipDirection left
         => Siren.classDirection.left;
    public static ClassRelationshipDirection right
         => Siren.classDirection.right;
}

public static class memberClassifier
{
    public static MemberClassifier @abstract
        => Siren.memberClassifier.@abstract;
    public static MemberClassifier @static
        => Siren.memberClassifier.@static;
    public static MemberClassifier custom(string str)
        => Siren.memberClassifier.custom(str);
}

public static class memberVisibility
{
    public static MemberVisibility @public
        => Siren.memberVisibility.@public;
    public static MemberVisibility @private
        => Siren.memberVisibility.@private;
    public static MemberVisibility @protected
        => Siren.memberVisibility.@protected;
    public static MemberVisibility packageInternal
        => Siren.memberVisibility.packageInternal;
    public static MemberVisibility custom(string str)
        => Siren.memberVisibility.custom(str);
}

public static class classDiagram
{
    public static ClassDiagramElement raw(string txt) => Siren.classDiagram.raw(txt);
    public static ClassDiagramElement @class(string id, Optional<string> name = default, Optional<string> generic = default, Optional<string[]> members = default) =>
        Siren.classDiagram.@class(id, name.ToOption(), generic.ToOption(), members.ToOption());
    public static ClassDiagramElement member(string id, string label, Optional<ClassDiagram.MemberVisibility> memberVisibility = default, Optional<ClassDiagram.MemberClassifier> memberClassifier = default) =>
        Siren.classDiagram.member(id, label, memberVisibility.ToOption(), memberClassifier.ToOption());
    public static ClassDiagramElement memberAbstract(string id, string label, Optional<ClassDiagram.MemberVisibility> memberVisibility = default) =>
        Siren.classDiagram.memberAbstract(id, label, memberVisibility.ToOption());
    public static ClassDiagramElement memberStatic(string id, string label, Optional<ClassDiagram.MemberVisibility> memberVisibility = default) =>
        Siren.classDiagram.memberStatic(id, label, memberVisibility.ToOption());

    public static ClassDiagramElement relationshipInheritance
        (
            string id1, string id2, 
            Optional<string> label = default, 
            Optional<ClassDiagram.Cardinality> cardinality1 = default, 
            Optional<ClassDiagram.Cardinality> cardinality2 = default
        ) =>
        Siren.classDiagram.relationshipInheritance(id1, id2, label.ToOption(), cardinality1.ToOption(), cardinality2.ToOption());
    public static ClassDiagramElement relationshipComposition(string id1, string id2,Optional<string> label = default,Optional<ClassDiagram.Cardinality> cardinality1 = default,Optional<ClassDiagram.Cardinality> cardinality2 = default) =>
        Siren.classDiagram.relationshipComposition(id1, id2, label.ToOption(), cardinality1.ToOption(), cardinality2.ToOption());
    public static ClassDiagramElement relationshipAggregation(string id1, string id2, Optional<string> label = default, Optional<ClassDiagram.Cardinality> cardinality1 = default, Optional<ClassDiagram.Cardinality> cardinality2 = default) =>
        Siren.classDiagram.relationshipAggregation(id1, id2, label.ToOption(), cardinality1.ToOption(), cardinality2.ToOption());
    public static ClassDiagramElement relationshipAssociation(string id1, string id2, Optional<string> label = default, Optional<ClassDiagram.Cardinality> cardinality1 = default, Optional<ClassDiagram.Cardinality> cardinality2 = default) =>
        Siren.classDiagram.relationshipAssociation(id1, id2, label.ToOption(), cardinality1.ToOption(), cardinality2.ToOption());
    public static ClassDiagramElement relationshipSolid(string id1, string id2, Optional<string> label = default, Optional<ClassDiagram.Cardinality> cardinality1 = default, Optional<ClassDiagram.Cardinality> cardinality2 = default) =>
        Siren.classDiagram.relationshipSolid(id1, id2, label.ToOption(), cardinality1.ToOption(), cardinality2.ToOption());
    public static ClassDiagramElement relationshipDependency(string id1, string id2, Optional<string> label = default, Optional<ClassDiagram.Cardinality> cardinality1 = default, Optional<ClassDiagram.Cardinality> cardinality2 = default) =>
        Siren.classDiagram.relationshipDependency(id1, id2, label.ToOption(), cardinality1.ToOption(), cardinality2.ToOption());
    public static ClassDiagramElement relationshipRealization(string id1, string id2, Optional<string> label = default, Optional<ClassDiagram.Cardinality> cardinality1 = default, Optional<ClassDiagram.Cardinality> cardinality2 = default) =>
        Siren.classDiagram.relationshipRealization(id1, id2, label.ToOption(), cardinality1.ToOption(), cardinality2.ToOption());
    public static ClassDiagramElement relationshipDashed(string id1, string id2, Optional<string> label = default, Optional<ClassDiagram.Cardinality> cardinality1 = default, Optional<ClassDiagram.Cardinality> cardinality2 = default) =>
        Siren.classDiagram.relationshipDashed(id1, id2, label.ToOption(), cardinality1.ToOption(), cardinality2.ToOption());
    public static ClassDiagramElement relationshipCustom
        (
            string id1, string id2, 
            ClassDiagram.ClassRelationshipType classRltsType, 
            Optional<string> label = default, 
            Optional<ClassDiagram.ClassRelationshipDirection> direction = default,
            Optional<bool> isDotted = default,
            Optional<ClassDiagram.Cardinality> cardinality1 = default, 
            Optional<ClassDiagram.Cardinality> cardinality2 = default ) =>
        Siren.classDiagram.relationshipCustom(id1, id2, classRltsType, label.ToOption(), direction.ToOption(), isDotted.ToOption(), cardinality1.ToOption(), cardinality2.ToOption());
    public static ClassDiagramElement @namespace(string name, IEnumerable<ClassDiagramElement> children) =>
        Siren.classDiagram.@namespace(name, children);
    public static ClassDiagramElement annotation(string name, string annotation) =>
        Siren.classDiagram.annotation(name, annotation);
    public static string annotationString(string name, string annotation) =>
        Siren.classDiagram.annotationString(name, annotation);
    public static ClassDiagramElement comment(string txt) => Siren.classDiagram.comment(txt);
    public static ClassDiagramElement direction(Direction direction) => Siren.classDiagram.direction(direction);
    public static ClassDiagramElement clickHref(string id, string url, Optional<string> tooltip = default) => Siren.classDiagram.clickHref(id, url, tooltip.ToOption());
    public static ClassDiagramElement note(string txt, Optional<string> id = default) => Siren.classDiagram.note(txt, id.ToOption());
    public static ClassDiagramElement link(string id, string url, Optional<string> tooltip = default) => Siren.classDiagram.link(id, url, tooltip.ToOption());
}
