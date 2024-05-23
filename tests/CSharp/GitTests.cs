namespace Siren.Sea.Tests;
using Xunit;
using Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


public class GitTests
{
    public class DocsTests
    {
        [Fact]
        public void Repository()
        {
            (string hotfix, string develop, string featureA, string featureB, string main, string release) = ("hotfix", "develop", "featureA", "featureB", "main", "release");
            string actual =
                siren.git([
                    git.commit(),
                    git.branch(hotfix),
                    git.checkout(hotfix),
                    git.commit(),
                    git.branch(develop),
                    git.checkout(develop),
                    git.commit("ash",tag: "abc"),
                    git.branch(featureB),
                    git.checkout(featureB),
                    git.commit(gitType: gitType.highlight),
                    git.checkout(main),
                    git.checkout(hotfix),
                    git.commit(gitType: gitType.normal),
                    git.checkout(develop),
                    git.commit(gitType: gitType.reverse),
                    git.checkout(featureB),
                    git.commit(),
                    git.checkout(main),
                    git.merge(hotfix),
                    git.checkout(featureB),
                    git.commit(),
                    git.checkout(develop),
                    git.branch(featureA),
                    git.commit(),
                    git.checkout(develop),
                    git.merge(hotfix),
                    git.checkout(featureA),
                    git.commit(),
                    git.checkout(featureB),
                    git.commit(),
                    git.checkout(develop),
                    git.merge(featureA),
                    git.branch(release),
                    git.checkout(release),
                    git.commit(),
                    git.checkout(main),
                    git.commit(),
                    git.checkout(release),
                    git.merge(main),
                    git.checkout(develop),
                    git.merge(release),
                ])
                    .withTheme(theme.@base)
                    .addGraphConfigVariable(gitGraphConfig.showBranches(false))
                    .write();
            string expected = @"---
config:
    theme: base
    gitGraph:
        showBranches: false
---
gitGraph
    commit
    branch hotfix
    checkout hotfix
    commit
    branch develop
    checkout develop
    commit id: ""ash"" tag: ""abc""
    branch featureB
    checkout featureB
    commit type: HIGHLIGHT
    checkout main
    checkout hotfix
    commit type: NORMAL
    checkout develop
    commit type: REVERSE
    checkout featureB
    commit
    checkout main
    merge hotfix
    checkout featureB
    commit
    checkout develop
    branch featureA
    commit
    checkout develop
    merge hotfix
    checkout featureA
    commit
    checkout featureB
    commit
    checkout develop
    merge featureA
    branch release
    checkout release
    commit
    checkout main
    commit
    checkout release
    merge main
    checkout develop
    merge release
";
            Assert.Equal(expected, actual);
        }
    }
    public class CompletenessTests
    {
        [Fact]
        public void GitTest()
        {
            Type csharpType = typeof(Siren.Sea.git);
            Type fsharpType = typeof(Siren.git);
            Utils.CompareClasses(csharpType, fsharpType);
        }
    }
}
