from siren.index import siren, journey

class TestJourney:

  def test_workday(self):
      Me, Cat = "Me", "Cat"
      actual = (
          siren.journey([
              journey.title("My working day"),
              journey.section("Go to work"),
              journey.task("Make tea", 5, [Me]),
              journey.task("Go upstairs", 3, [Me]),
              journey.task("Do work", 1, [Me, Cat]),
              journey.section("Go home"),
              journey.task("Go downstairs", 5, [Me]),
              journey.task("Sit down", 5, [Me])
          ]).write()
      )
      expected = """journey
    title My working day
    section Go to work
    Make tea: 5: Me
    Go upstairs: 3: Me
    Do work: 1: Me, Cat
    section Go home
    Go downstairs: 5: Me
    Sit down: 5: Me
"""
      assert actual == expected