module Tests.Comment

open Fable.Pyxpecto
open Siren


let main = testList "Comment" [
    testCase "constructor" <| fun _ ->
        let str = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr."
        let actual = comment.comment str
        let expected = Types.Element.Comment str
        Expect.equal actual expected ""
    testList "String formatting" [
        testCase "simple" <| fun _ ->
            let actual = comment.comment "Lorem ipsum dolor sit amet, consetetur sadipscing elitr." |> Formatter.writeElementFast
            let expected = "%% Lorem ipsum dolor sit amet, consetetur sadipscing elitr."
            Expect.stringEqual actual expected ""
    ]
]

