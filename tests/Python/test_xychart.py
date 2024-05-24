from siren.index import siren, xy_chart

class TestSankey:

  def test_bio_conversion(self):
      actual = (
          siren.xy_chart([
              xy_chart.title("Sales Revenue"),
              xy_chart.x_axis(["jan", "feb", "mar", "apr", "may", "jun", "jul", "aug", "sep", "oct", "nov", "dec"]),
              xy_chart.y_axis_named_range("Revenue (in $)", 4000, 11000),
              xy_chart.bar([5000, 6000, 7500, 8200, 9500, 10500, 11000, 10200, 9200, 8500, 7000, 6000]),
              xy_chart.line([5000, 6000, 7500, 8200, 9500, 10500, 11000, 10200, 9200, 8500, 7000, 6000])
          ]).write()
      ) 
      expected = """xychart-beta
    title "Sales Revenue"
    x-axis [jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec]
    y-axis "Revenue (in $)" 4000.000000 --> 11000.000000
    bar [5000, 6000, 7500, 8200, 9500, 10500, 11000, 10200, 9200, 8500, 7000, 6000]
    line [5000, 6000, 7500, 8200, 9500, 10500, 11000, 10200, 9200, 8500, 7000, 6000]
"""
      assert actual == expected