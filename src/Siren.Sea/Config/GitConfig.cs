namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class gitGraphConfig
{
    public static (string, string) custom(string key, string value)
         => Siren.gitGraphConfig.custom(key, value).ToValueTuple();
    public static (string, string) titleTopMargin(int value)
         => Siren.gitGraphConfig.titleTopMargin(value).ToValueTuple();
    public static (string, string) diagramPadding(int value)
         => Siren.gitGraphConfig.diagramPadding(value).ToValueTuple();
    public static (string, string) mainBranchName(string value)
         => Siren.gitGraphConfig.mainBranchName(value).ToValueTuple();
    public static (string, string) mainBranchOrder(string value)
         => Siren.gitGraphConfig.mainBranchOrder(value).ToValueTuple();
    public static (string, string) showCommitLabel(bool value)
         => Siren.gitGraphConfig.showCommitLabel(value).ToValueTuple();
    public static (string, string) showBranches(bool value)
         => Siren.gitGraphConfig.showBranches(value).ToValueTuple();
    public static (string, string) rotateCommitLabel(bool value)
         => Siren.gitGraphConfig.rotateCommitLabel(value).ToValueTuple();
    public static (string, string) parallelCommits(bool value)
         => Siren.gitGraphConfig.parallelCommits(value).ToValueTuple();
}