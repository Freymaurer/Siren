from siren.index import siren, block

class TestBlock:

  def test_introduction(self):
      actual = (
        siren.block([
            block.columns(1),
            block.block_circle("db", "DB"),
            block.arrow_down("blockArrowId6"),
            block.c_id_block("ID", [
                block.block("A"),
                block.block("B", "A wide one in the middle"),
                block.block("C")
            ]),
            block.space(),
            block.block("D"),
            block.link("ID", "D"),
            block.link("C", "D"),
            block.style("B", [
                ("fill", "#939"),
                ("stroke", "#333"),
                ("stroke-width", "4px")
            ])
        ]).write()
      ) 
      expected = """block-beta
    columns 1
    db(("DB"))
    blockArrowId6<["&nbsp;&nbsp;&nbsp;"]>(down)
    block:ID
        A["A"]
        B["A wide one in the middle"]
        C["C"]
    end
    space
    D["D"]
    ID-->D
    C-->D
    style B fill:#939,stroke:#333,stroke-width:4px;
"""
      assert actual == expected
  def test_services(self):
      Frontend, Backend, Database = "Frontend", "Backend", "Database"
      actual = (
        siren.block([
          block.columns(3),
          block.line([
              block.block(Frontend),
              block.arrow_right("blockArrowId6", 1),
              block.block(Backend)
          ]),
          block.line([
              block.spacew(2),
              block.arrow_down("down", 1)
          ]),
          block.line([
              block.block("Disk"),
              block.arrow_left("left", 1),
              block.block_cylindrical(Database)
          ]),
          block.class_def("front", [
              ("fill", "#696"), 
              ("stroke", "#333")
          ]),
          block.class_def("back", [("fill", "#969"), ("stroke", "#333")]),
          block.class_([Frontend], "front"),
          block.class_([Backend, Database], "back")
        ]).write()
      ) 
      expected = """block-beta
    columns 3
    Frontend["Frontend"] blockArrowId6<["&nbsp;"]>(right) Backend["Backend"]
    space:2 down<["&nbsp;"]>(down)
    Disk["Disk"] left<["&nbsp;"]>(left) Database[("Database")]
    classDef front fill:#696,stroke:#333;
    classDef back fill:#969,stroke:#333;
    class Frontend front
    class Backend,Database back
"""
      assert actual == expected
  def test_decision_making(self):
      actual = (
        siren.block([
            block.columns(3),
            block.line([
                block.block_circle("Start"),
                block.spacew(2)
            ]),
            block.line([
                block.arrow_down_labeled("down", " "),
                block.spacew(2)
            ]),
            block.line([
                block.block_hexagon("Decision", "Make Decision"),
                block.arrow_right_labeled("right", "Yes"),
                block.block("Process1", "Process A")
            ]),
            block.line([
                block.arrow_down_labeled("downAgain", "No"),
                block.space(),
                block.arrow_down_labeled("r3", "Done")
            ]),
            block.line([
                block.block("Process2", "Process B"),
                block.arrow_right_labeled("r2", "Done"),
                block.block_circle("End")
            ]),
            block.style("Start", [("fill", "#969")]),
            block.style("End", [("fill", "#696")])
        ]).write()
      ) 
      expected = """block-beta
    columns 3
    Start(("Start")) space:2
    down<[" "]>(down) space:2
    Decision{{"Make Decision"}} right<["Yes"]>(right) Process1["Process A"]
    downAgain<["No"]>(down) space r3<["Done"]>(down)
    Process2["Process B"] r2<["Done"]>(right) End(("End"))
    style Start fill:#969;
    style End fill:#696;
"""
      assert actual == expected