module Tests.Block

open Fable.Pyxpecto
open Siren

let tests_docs = testList "docs" [
    testCase "Introduction" <| fun _ ->
        let actual = 
            siren.block [
                block.columns(1)
                block.blockCircle("db", "DB")
                block.arrowDown "blockArrowId6"
                block.cIdBlock("ID", [
                    block.block("A")
                    block.block("B", "A wide one in the middle")
                    block.block("C")
                ])
                block.space
                block.block("D")
                block.link ("ID", "D")
                block.link ("C", "D")
                block.style ("B", ["fill", "#939"; "stroke", "#333"; "stroke-width", "4px"])
            ]
            |> siren.write
        let expected = """block-beta
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
        Expect.trimEqual actual expected ""

    testCase "Services" <| fun _ ->
        let Frontend, Backend, Database = "Frontend", "Backend", "Database"
        let actual = 
            siren.block [
                block.columns(3)
                block.line [
                    block.block(Frontend)
                    block.arrowRight("blockArrowId6",1)
                    block.block(Backend)
                ]
                block.line [
                    block.spacew 2
                    block.arrowDown("down",1)
                ]
                block.line [
                    block.block "Disk"
                    block.arrowLeft("left",1)
                    block.blockCylindrical(Database)
                ]
                block.classDef("front", ["fill", "#696"; "stroke", "#333"])
                block.classDef("back", ["fill", "#969"; "stroke", "#333"])
                block.``class``([Frontend], "front")
                block.``class``([Backend; Database], "back")
            ]
            |> siren.write
        let expected = """block-beta
    columns 3
    Frontend["Frontend"] blockArrowId6<["&nbsp;"]>(right) Backend["Backend"]
    space:2 down<["&nbsp;"]>(down)
    Disk["Disk"] left<["&nbsp;"]>(left) Database[("Database")]
    classDef front fill:#696,stroke:#333;
    classDef back fill:#969,stroke:#333;
    class Frontend front
    class Backend,Database back
"""
        Expect.trimEqual actual expected ""
    testCase "Decision making" <| fun _ ->
        let actual = 
            siren.block [
                block.columns(3)
                block.line [
                    block.blockCircle("Start")
                    block.spacew(2)
                ]
                block.line [
                    block.arrowDownLabeled("down", " ")
                    block.spacew(2)
                ]
                block.line [
                    block.blockHexagon("Decision","Make Decision")
                    block.arrowRightLabeled("right", "Yes")
                    block.block("Process1", "Process A")
                ]
                block.line [
                    block.arrowDownLabeled("downAgain", "No")
                    block.space
                    block.arrowDownLabeled("r3", "Done")
                ]
                block.line [
                    block.block("Process2", "Process B")
                    block.arrowRightLabeled ("r2", "Done")
                    block.blockCircle("End")
                ]
                block.style("Start", ["fill", "#969"])
                block.style("End", ["fill", "#696"])
            ]
            |> siren.write
        let expected = """block-beta
    columns 3
    Start(("Start")) space:2
    down<[" "]>(down) space:2
    Decision{{"Make Decision"}} right<["Yes"]>(right) Process1["Process A"]
    downAgain<["No"]>(down) space r3<["Done"]>(down)
    Process2["Process B"] r2<["Done"]>(right) End(("End"))
    style Start fill:#969;
    style End fill:#696;
"""
        Expect.trimEqual actual expected ""
]

let main = testList "Block" [
    tests_docs
    testCase "BlockBlockTypes" <| fun _ ->
        // verify Types.BlockBlockTypes.ToFormatString
        let actual =
            siren.block [
                block.block("id0", "This is the text in the box")
                block.blockRounded("id1", "This is the text in the box")
                block.blockStatidum("id2", "This is the text in the box")
                block.blockSubroutine("id3", "This is the text in the box")
                block.blockCylindrical("id4", "This is the text in the box")
                block.blockCircle("id5", "This is the text in the box")
                block.blockAsymmetric("id6", "This is the text in the box")
                block.blockRhombus("id7", "This is the text in the box")
                block.blockHexagon("id8", "This is the text in the box")
                block.blockParallelogram("id9", "This is the text in the box")
                block.blockParallelogramAlt("id10", "This is the text in the box")
                block.blockTrapezoid("id11", "This is the text in the box")
                block.blockTrapezoidAlt("id12", "This is the text in the box")
                block.blockDoubleCircle("id13", "This is the text in the box")
            ]
            |> siren.write
        let expected = """block-beta
    id0["This is the text in the box"]
    id1("This is the text in the box")
    id2(["This is the text in the box"])
    id3[["This is the text in the box"]]
    id4[("This is the text in the box")]
    id5(("This is the text in the box"))
    id6>"This is the text in the box"]
    id7{"This is the text in the box"}
    id8{{"This is the text in the box"}}
    id9[/"This is the text in the box"/]
    id10[\"This is the text in the box"\]
    id11[/"This is the text in the box"\]
    id12[\"This is the text in the box"/]
    id13((("This is the text in the box")))
"""
        Expect.trimEqual actual expected ""
]


