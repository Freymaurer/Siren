namespace Siren.Sea;

using static Siren.Formatting;
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
    public static ClassCardinality n
         => Siren.classCardinality.n;
    public static ClassCardinality many
         => Siren.classCardinality.many;
    public static ClassCardinality one
         => Siren.classCardinality.one;
    public static ClassCardinality oneOrMore
         => Siren.classCardinality.oneOrMore;
    public static ClassCardinality oneToN
         => Siren.classCardinality.oneToN;
    public static ClassCardinality zeroOrOne
         => Siren.classCardinality.zeroOrOne;
    public static ClassCardinality zeroToN
         => Siren.classCardinality.zeroToN;
    public static ClassCardinality custom(string cardinality)
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

public static class classMemberClassifier
{
    public static ClassMemberClassifier @abstract
        => Siren.classMemberClassifier.Abstract;
    public static ClassMemberClassifier @static
        => Siren.classMemberClassifier.Static;
    public static ClassMemberClassifier custom(string str)
        => Siren.classMemberClassifier.custom(str);

}

public static class classMemberVisibility
{
    public static ClassMemberVisibility @public
        => Siren.classMemberVisibility.Public;
    public static ClassMemberVisibility @private
        => Siren.classMemberVisibility.Private;
    public static ClassMemberVisibility @protected
        => Siren.classMemberVisibility.Protected;
    public static ClassMemberVisibility packageInternal
        => Siren.classMemberVisibility.packageInternal;
    public static ClassMemberVisibility custom(string str)
        => Siren.classMemberVisibility.custom(str);
}

public static class classDiagram
{
    public static ClassDiagramElement raw(string txt)
         => Siren.classDiagram.raw(txt);
    public static ClassDiagramElement @class(string id, ClassDiagramElement[] members)
         => Siren.classDiagram.@class(id, members);
    public static ClassDiagramElement classId(string id, Optional<string> name = default, Optional<string> generic = default, Optional<ClassDiagramElement[]> members = default)
         => Siren.classDiagram.classId(id, name.ToOption(), generic.ToOption(), members.ToOption());
    public static ClassDiagramElement classMember(string name, Optional<ClassMemberVisibility> classMemberVisibility = default, Optional<ClassMemberClassifier> classMemberClassifier = default)
         => Siren.classDiagram.classMember(name, classMemberVisibility.ToOption(), classMemberClassifier.ToOption());
    public static ClassDiagramElement classAttr(string name, Optional<string> generic = default, Optional<ClassMemberVisibility> classMemberVisibility = default, Optional<ClassMemberClassifier> classMemberClassifier = default)
         => Siren.classDiagram.classAttr(name, generic.ToOption(), classMemberVisibility.ToOption(), classMemberClassifier.ToOption());
    public static ClassDiagramElement classFunction(string name, Optional<string> param = default, Optional<string> returnType = default, Optional<ClassMemberVisibility> classMemberVisibility = default, Optional<ClassMemberClassifier> classMemberClassifier = default)
         => Siren.classDiagram.classFunction(name, param.ToOption(), returnType.ToOption(), classMemberVisibility.ToOption(), classMemberClassifier.ToOption());
    public static ClassDiagramElement idMember(string id, string name, Optional<ClassMemberVisibility> classMemberVisibility = default, Optional<ClassMemberClassifier> classMemberClassifier = default)
         => Siren.classDiagram.idMember(id, name, classMemberVisibility.ToOption(), classMemberClassifier.ToOption());
    public static ClassDiagramElement idAttr(string id, string name, Optional<string> generic = default, Optional<ClassMemberVisibility> classMemberVisibility = default, Optional<ClassMemberClassifier> classMemberClassifier = default)
         => Siren.classDiagram.idAttr(id, name, generic.ToOption(), classMemberVisibility.ToOption(), classMemberClassifier.ToOption());
    public static ClassDiagramElement idFunction(string id, string name, Optional<string> param = default, Optional<string> returnType = default, Optional<ClassMemberVisibility> classMemberVisibility = default, Optional<ClassMemberClassifier> classMemberClassifier = default)
         => Siren.classDiagram.idFunction(id, name, param.ToOption(), returnType.ToOption(), classMemberVisibility.ToOption(), classMemberClassifier.ToOption());
    public static ClassDiagramElement relationshipInheritance(string id1, string id2, Optional<string> label = default, Optional<ClassCardinality> cardinality1 = default, Optional<ClassCardinality> cardinality2 = default)
         => Siren.classDiagram.relationshipInheritance(id1, id2, label.ToOption(), cardinality1.ToOption(), cardinality2.ToOption());
    public static ClassDiagramElement relationshipComposition(string id1, string id2, Optional<string> label = default, Optional<ClassCardinality> cardinality1 = default, Optional<ClassCardinality> cardinality2 = default)
         => Siren.classDiagram.relationshipComposition(id1, id2, label.ToOption(), cardinality1.ToOption(), cardinality2.ToOption());
    public static ClassDiagramElement relationshipAggregation(string id1, string id2, Optional<string> label = default, Optional<ClassCardinality> cardinality1 = default, Optional<ClassCardinality> cardinality2 = default)
         => Siren.classDiagram.relationshipAggregation(id1, id2, label.ToOption(), cardinality1.ToOption(), cardinality2.ToOption());
    public static ClassDiagramElement relationshipAssociation(string id1, string id2, Optional<string> label = default, Optional<ClassCardinality> cardinality1 = default, Optional<ClassCardinality> cardinality2 = default)
         => Siren.classDiagram.relationshipAssociation(id1, id2, label.ToOption(), cardinality1.ToOption(), cardinality2.ToOption());
    public static ClassDiagramElement relationshipSolid(string id1, string id2, Optional<string> label = default, Optional<ClassCardinality> cardinality1 = default, Optional<ClassCardinality> cardinality2 = default)
         => Siren.classDiagram.relationshipSolid(id1, id2, label.ToOption(), cardinality1.ToOption(), cardinality2.ToOption());
    public static ClassDiagramElement relationshipDependency(string id1, string id2, Optional<string> label = default, Optional<ClassCardinality> cardinality1 = default, Optional<ClassCardinality> cardinality2 = default)
         => Siren.classDiagram.relationshipDependency(id1, id2, label.ToOption(), cardinality1.ToOption(), cardinality2.ToOption());
    public static ClassDiagramElement relationshipRealization(string id1, string id2, Optional<string> label = default, Optional<ClassCardinality> cardinality1 = default, Optional<ClassCardinality> cardinality2 = default)
         => Siren.classDiagram.relationshipRealization(id1, id2, label.ToOption(), cardinality1.ToOption(), cardinality2.ToOption());
    public static ClassDiagramElement relationshipDashed(string id1, string id2, Optional<string> label = default, Optional<ClassCardinality> cardinality1 = default, Optional<ClassCardinality> cardinality2 = default)
         => Siren.classDiagram.relationshipDashed(id1, id2, label.ToOption(), cardinality1.ToOption(), cardinality2.ToOption());
    public static ClassDiagramElement relationshipCustom(string id1, string id2, ClassRelationshipType rltsType, Optional<string> label = default, Optional<ClassRelationshipDirection> direction = default, Optional<bool> isDotted = default, Optional<ClassCardinality> cardinality1 = default, Optional<ClassCardinality> cardinality2 = default)
         => Siren.classDiagram.relationshipCustom(id1, id2, rltsType, label.ToOption(), direction.ToOption(), isDotted.ToOption(), cardinality1.ToOption(), cardinality2.ToOption());
    public static ClassDiagramElement @namespace(string name, ClassDiagramElement[] children)
             => Siren.classDiagram.@namespace(name, children);
    public static ClassDiagramElement @interface(Optional<string> id = default)
            => Siren.classDiagram.Interface(id.ToOption());
    public static ClassDiagramElement @abstract(Optional<string> id = default)
            => Siren.classDiagram.Abstract(id.ToOption());
    public static ClassDiagramElement service(Optional<string> id = default)
            => Siren.classDiagram.service(id.ToOption());
    public static ClassDiagramElement enumeration(Optional<string> id = default)
         => Siren.classDiagram.enumeration(id.ToOption());
    public static ClassDiagramElement annotation(string name, Optional<string> id = default)
         => Siren.classDiagram.annotation(name, id.ToOption());
    public static ClassDiagramElement comment(string txt)
         => Siren.classDiagram.comment(txt);
    public static ClassDiagramElement direction(Direction direction)
         => Siren.classDiagram.direction(direction);
    public static ClassDiagramElement directionTB
         => Siren.classDiagram.directionTB;
    public static ClassDiagramElement directionTD
         => Siren.classDiagram.directionTD;
    public static ClassDiagramElement directionBT
         => Siren.classDiagram.directionBT;
    public static ClassDiagramElement directionRL
         => Siren.classDiagram.directionRL;
    public static ClassDiagramElement directionLR
         => Siren.classDiagram.directionLR;
    public static ClassDiagramElement clickHref(string id, string url, Optional<string> tooltip = default)
         => Siren.classDiagram.clickHref(id, url, tooltip.ToOption());
    public static ClassDiagramElement note(string txt, Optional<string> id = default)
         => Siren.classDiagram.note(txt, id.ToOption());
    public static ClassDiagramElement link(string id, string url, Optional<string> tooltip = default)
         => Siren.classDiagram.link(id, url, tooltip.ToOption());
    public static ClassDiagramElement style(string id, (string,string)[] styles)
         => Siren.classDiagram.style(id, styles.Select(t => t.ToTuple()));
    public static ClassDiagramElement cssClass(string[] ids, string className)
         => Siren.classDiagram.cssClass(ids, className);
}