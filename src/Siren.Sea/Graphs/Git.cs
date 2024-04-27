namespace Siren.Sea;

using static Siren.Formatting.Git;
using static Siren.Types;

public class gitType
{
    public static GitCommitType normal
         => Siren.gitType.normal;
    public static GitCommitType reverse
         => Siren.gitType.reverse;
    public static GitCommitType highlight
         => Siren.gitType.highlight;
}
public class git
{
    public static GitGraphElement raw(string line)
         => Siren.git.raw(line);
    public static GitGraphElement commit(Optional<string> id = default, Optional<GitCommitType> gitType = default, Optional<string> tag = default)
         => Siren.git.commit(id.ToOption(), gitType.ToOption(), tag.ToOption());
    public static GitGraphElement merge(string targetBranchId, Optional<string> mergeid = default, Optional<GitCommitType> gitType = default, Optional<string> tag = default)
         => Siren.git.merge(targetBranchId, mergeid.ToOption(), gitType.ToOption(), tag.ToOption());
    public static GitGraphElement cherryPick(string commitid, Optional<string> parentId = default)
         => Siren.git.cherryPick(commitid, parentId.ToOption());
    public static GitGraphElement branch(string id)
         => Siren.git.branch(id);
    public static GitGraphElement checkout(string id)
         => Siren.git.checkout(id);
}
