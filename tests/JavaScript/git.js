import {siren, git, gitType, gitGraphConfig, theme } from "./siren/index.js"
import * as assert from "assert"

describe('git', function(){
  it('Repository', function(){
      const [hotfix, develop, featureA, featureB, main, release] = ["hotfix", "develop", "featureA", "featureB", "main", "release"];
      const actual =
          siren.git([
            git.commit(),
            git.branch(hotfix),
            git.checkout(hotfix),
            git.commit(),
            git.branch(develop),
            git.checkout(develop),
            git.commit("ash",null,"abc"),
            git.branch(featureB),
            git.checkout(featureB),
            git.commit(null, gitType.highlight),
            git.checkout(main),
            git.checkout(hotfix),
            git.commit(null, gitType.normal),
            git.checkout(develop),
            git.commit(null, gitType.reverse),
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
            .withTheme(theme.base)
            .addGraphConfigVariable(gitGraphConfig.showBranches(false))
            .write();
      const expected = `---
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
    commit id: "ash" tag: "abc"
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
`
      assert.equal(actual,expected,"This should be equal")
  });
});