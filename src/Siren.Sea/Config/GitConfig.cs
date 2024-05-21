namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class gitGraphConfig
{
    public static ConfigVariable custom(string key, string value)
         => Siren.gitGraphConfig.custom(key, value);
    public static ConfigVariable titleTopMargin(int value)
         => Siren.gitGraphConfig.titleTopMargin(value);
    public static ConfigVariable diagramPadding(int value)
         => Siren.gitGraphConfig.diagramPadding(value);
    public static ConfigVariable mainBranchName(string value)
         => Siren.gitGraphConfig.mainBranchName(value);
    public static ConfigVariable mainBranchOrder(string value)
         => Siren.gitGraphConfig.mainBranchOrder(value);
    public static ConfigVariable showCommitLabel(bool value)
         => Siren.gitGraphConfig.showCommitLabel(value);
    public static ConfigVariable showBranches(bool value)
         => Siren.gitGraphConfig.showBranches(value);
    public static ConfigVariable rotateCommitLabel(bool value)
         => Siren.gitGraphConfig.rotateCommitLabel(value);
    public static ConfigVariable parallelCommits(bool value)
         => Siren.gitGraphConfig.parallelCommits(value);
}