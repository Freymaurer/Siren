import siren.index as siren


class TestSyntax:
      
    def test_moon_rocket_example(self):
        def chart():
            return siren.siren.flowchart(siren.direction.bt(), [
                siren.flowchart.subgraph("space", [
                    siren.flowchart.direction_bt(),
                    siren.flowchart.link_dotted_arrow(
                        "earth",
                        "moon",
                        siren.formatting.unicode("🚀"),
                        6
                    ),
                    siren.flowchart.node_round("moon"),
                    siren.flowchart.subgraph("atmosphere",[
                        siren.flowchart.node_circle("earth")
                    ])
                ])
            ])
        actual = siren.siren.write(chart())
        expected = """flowchart BT
    subgraph space
        direction BT
        earth-......->|"🚀"|moon
        moon(moon)
        subgraph atmosphere
            earth((earth))
        end
    end
"""
        assert actual == expected