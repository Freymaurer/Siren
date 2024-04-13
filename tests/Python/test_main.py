import siren.siren as siren


class TestSyntax:
      
    def test_moon_rocket_example(self):
        def chart():
            return siren.flowchart().bt([
                siren.subgraph.subgraph("space", [
                    siren.direction.bt(),
                    siren.link.dotted_arrow(
                        siren.node.simple("earth"),
                        siren.node.simple("moon"),
                        siren.formatting.unicode("🚀"),
                        6
                    ),
                    siren.node.round("moon","moon"),
                    siren.subgraph.subgraph("atmosphere",[
                        siren.node.circle("earth", "earth")
                    ])
                ])
            ])
        actual = siren.siren.write(chart())
        expected = """flowchart BT
    subgraph space[space]
        direction BT
        earth[earth]-......->|"🚀"|moon[moon]
        moon(moon)
        subgraph atmosphere[atmosphere]
            earth((earth))
        end
    end
"""
        assert actual == expected