from siren.index import siren, sankey

class TestSankey:

  def test_bio_conversion(self):
      actual = (
        siren.sankey([
            sankey.links("Bio-conversion", [
                ("Losses", 26.862),
                ("Solid", 280.322),
                ("Gas", 81.144)
            ])
        ]).write()
      ) 
      expected = """sankey-beta
"Bio-conversion","Losses",26.862000
"Bio-conversion","Solid",280.322000
"Bio-conversion","Gas",81.144000
"""
      assert actual == expected