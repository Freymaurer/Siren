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
public static class Requirement
{
    public static RequirementDiagramElement raw(string txt)
         => Siren.requirement.raw(txt);
    public static RequirementDiagramElement requirement(string name, Optional<string> id = default, Optional<string> text = default, Optional<RDRiskType> rqRisk = default, Optional<RDVerifyMethod> rqMethod = default)
         => Siren.requirement.requirement(name, id.ToOption(), text.ToOption(), rqRisk.ToOption(), rqMethod.ToOption());
    public static RequirementDiagramElement functionalRequirement(string name, Optional<string> id = default, Optional<string> text = default, Optional<RDRiskType> rqRisk = default, Optional<RDVerifyMethod> rqMethod = default)
         => Siren.requirement.functionalRequirement(name, id.ToOption(), text.ToOption(), rqRisk.ToOption(), rqMethod.ToOption());
    public static RequirementDiagramElement interfaceRequirement(string name, Optional<string> id = default, Optional<string> text = default, Optional<RDRiskType> rqRisk = default, Optional<RDVerifyMethod> rqMethod = default)
         => Siren.requirement.interfaceRequirement(name, id.ToOption(), text.ToOption(), rqRisk.ToOption(), rqMethod.ToOption());
    public static RequirementDiagramElement performanceRequirement(string name, Optional<string> id = default, Optional<string> text = default, Optional<RDRiskType> rqRisk = default, Optional<RDVerifyMethod> rqMethod = default)
         => Siren.requirement.performanceRequirement(name, id.ToOption(), text.ToOption(), rqRisk.ToOption(), rqMethod.ToOption());
    public static RequirementDiagramElement physicalRequirement(string name, Optional<string> id = default, Optional<string> text = default, Optional<RDRiskType> rqRisk = default, Optional<RDVerifyMethod> rqMethod = default)
         => Siren.requirement.physicalRequirement(name, id.ToOption(), text.ToOption(), rqRisk.ToOption(), rqMethod.ToOption());
    public static RequirementDiagramElement designConstraint(string name, Optional<string> id = default, Optional<string> text = default, Optional<RDRiskType> rqRisk = default, Optional<RDVerifyMethod> rqMethod = default)
         => Siren.requirement.designConstraint(name, id.ToOption(), text.ToOption(), rqRisk.ToOption(), rqMethod.ToOption());
    public static RequirementDiagramElement element(string name, Optional<string> elementType = default, Optional<string> docref = default)
         => Siren.requirement.element(name, elementType.ToOption(), docref.ToOption());
    public static RequirementDiagramElement contains(string id1, string id2)
         => Siren.requirement.contains(id1, id2);
    public static RequirementDiagramElement copies(string id1, string id2)
         => Siren.requirement.copies(id1, id2);
    public static RequirementDiagramElement derives(string id1, string id2)
         => Siren.requirement.derives(id1, id2);
    public static RequirementDiagramElement satisfies(string id1, string id2)
         => Siren.requirement.satisfies(id1, id2);
    public static RequirementDiagramElement verifies(string id1, string id2)
         => Siren.requirement.verifies(id1, id2);
    public static RequirementDiagramElement refines(string id1, string id2)
         => Siren.requirement.refines(id1, id2);
    public static RequirementDiagramElement traces(string id1, string id2)
         => Siren.requirement.traces(id1, id2);
}
