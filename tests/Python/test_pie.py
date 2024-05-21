from siren.index import siren, pie_chart, pie_config, pie_theme

class TestPieChart:

  def test_product(self):
      actual = (
        siren.pie_chart([
              pie_chart.data("Calcium", 42.96),
              pie_chart.data("Potassium", 50.05),
              pie_chart.data("Magnesium", 10.01),
              pie_chart.data("Iron", 5)
          ], True, "Key elements in Product X")
            .add_graph_config_variable(pie_config.text_position(0.5))
            .add_theme_variable(pie_theme.pie_outer_stroke_width("5px"))
            .write()
      ) 
      expected = """---
config:
    pie:
        textPosition: 0.5
    themeVariables:
        pieOuterStrokeWidth: 5px
---
pie showData title Key elements in Product X
    "Calcium" : 42.96
    "Potassium" : 50.05
    "Magnesium" : 10.01
    "Iron" : 5
"""
      assert actual == expected