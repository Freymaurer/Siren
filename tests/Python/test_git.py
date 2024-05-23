from siren.index import siren, git, git_graph_config, git_type, theme

class TestGit:

  def test_repostiroy(self):
      hotfix, develop, featureA, featureB, main, release = "hotfix", "develop", "featureA", "featureB", "main", "release"
      actual = (
          siren.git([
              git.commit(),
              git.branch(hotfix),
              git.checkout(hotfix),
              git.commit(),
              git.branch(develop),
              git.checkout(develop),
              git.commit("ash", tag = "abc"),
              git.branch(featureB),
              git.checkout(featureB),
              git.commit(git_type = git_type.highlight()),
              git.checkout(main),
              git.checkout(hotfix),
              git.commit(git_type = git_type.normal()),
              git.checkout(develop),
              git.commit(git_type = git_type.reverse()),
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
              .with_theme(theme.base())
              .add_graph_config_variable(git_graph_config.show_branches(False))
              .write()
      )
      expected = """---
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
"""
      assert actual == expected