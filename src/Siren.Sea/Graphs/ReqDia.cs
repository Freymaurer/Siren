namespace Siren.Sea;

using static Siren.Formatting.RequirementDiagram;
using Util;
public static class rqRisk
{
    public static RDRiskType low
         => Siren.rqRisk.low;
    public static RDRiskType medium
         => Siren.rqRisk.medium;
    public static RDRiskType high
         => Siren.rqRisk.high;
}

public static class rqMethod
{
    public static RDVerifyMethod analysis
         => Siren.rqMethod.analysis;
    public static RDVerifyMethod inspection
         => Siren.rqMethod.inspection;
    public static RDVerifyMethod test
         => Siren.rqMethod.test;
    public static RDVerifyMethod demonstration
         => Siren.rqMethod.demonstration;
}
public static class reqDia
{
    public static RequirementDiagramElement raw(string txt)
         => Siren.reqDia.raw(txt);
    public static RequirementDiagramElement requirement(string name, Optional<string> id = default, Optional<string> text = default, Optional<RDRiskType> rqRisk = default, Optional<RDVerifyMethod> rqMethod = default)
         => Siren.reqDia.requirement(name, id.ToOption(), text.ToOption(), rqRisk.ToOption(), rqMethod.ToOption());
    public static RequirementDiagramElement functionalRequirement(string name, Optional<string> id = default, Optional<string> text = default, Optional<RDRiskType> rqRisk = default, Optional<RDVerifyMethod> rqMethod = default)
         => Siren.reqDia.functionalRequirement(name, id.ToOption(), text.ToOption(), rqRisk.ToOption(), rqMethod.ToOption());
    public static RequirementDiagramElement interfaceRequirement(string name, Optional<string> id = default, Optional<string> text = default, Optional<RDRiskType> rqRisk = default, Optional<RDVerifyMethod> rqMethod = default)
         => Siren.reqDia.interfaceRequirement(name, id.ToOption(), text.ToOption(), rqRisk.ToOption(), rqMethod.ToOption());
    public static RequirementDiagramElement performanceRequirement(string name, Optional<string> id = default, Optional<string> text = default, Optional<RDRiskType> rqRisk = default, Optional<RDVerifyMethod> rqMethod = default)
         => Siren.reqDia.performanceRequirement(name, id.ToOption(), text.ToOption(), rqRisk.ToOption(), rqMethod.ToOption());
    public static RequirementDiagramElement physicalRequirement(string name, Optional<string> id = default, Optional<string> text = default, Optional<RDRiskType> rqRisk = default, Optional<RDVerifyMethod> rqMethod = default)
         => Siren.reqDia.physicalRequirement(name, id.ToOption(), text.ToOption(), rqRisk.ToOption(), rqMethod.ToOption());
    public static RequirementDiagramElement designConstraint(string name, Optional<string> id = default, Optional<string> text = default, Optional<RDRiskType> rqRisk = default, Optional<RDVerifyMethod> rqMethod = default)
         => Siren.reqDia.designConstraint(name, id.ToOption(), text.ToOption(), rqRisk.ToOption(), rqMethod.ToOption());
    public static RequirementDiagramElement element(string name, Optional<string> elementType = default, Optional<string> docref = default)
         => Siren.reqDia.element(name, elementType.ToOption(), docref.ToOption());
    public static RequirementDiagramElement contains(string id1, string id2)
         => Siren.reqDia.contains(id1, id2);
    public static RequirementDiagramElement copies(string id1, string id2)
         => Siren.reqDia.copies(id1, id2);
    public static RequirementDiagramElement derives(string id1, string id2)
         => Siren.reqDia.derives(id1, id2);
    public static RequirementDiagramElement satisfies(string id1, string id2)
         => Siren.reqDia.satisfies(id1, id2);
    public static RequirementDiagramElement verifies(string id1, string id2)
         => Siren.reqDia.verifies(id1, id2);
    public static RequirementDiagramElement refines(string id1, string id2)
         => Siren.reqDia.refines(id1, id2);
    public static RequirementDiagramElement traces(string id1, string id2)
         => Siren.reqDia.traces(id1, id2);
}
