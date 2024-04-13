module Tests.Node

open Fable.Pyxpecto
open Siren

let private tests_constructor = testList "formatter" [
    let id = "A"
    let name = "Hello World"
    testCase "simple" <| fun _ ->
        let actual = node.simple id |> Formatter.writeElementFast
        let expected = "A[A]"
        Expect.stringEqual actual expected ""
    testCase "node" <| fun _ ->
        let actual = node.node id name |> Formatter.writeElementFast
        let expected = "A[Hello World]"
        Expect.stringEqual actual expected ""
    testCase "stadium" <| fun _ ->
        let actual = node.stadium id name |> Formatter.writeElementFast
        let expected = "A([Hello World])"
        Expect.stringEqual actual expected ""
    testCase "subroutine" <| fun _ ->
        let actual = node.subroutine id name |> Formatter.writeElementFast
        let expected = "A[[Hello World]]"
        Expect.stringEqual actual expected ""
    testCase "cylindrical" <| fun _ ->
        let actual = node.cylindrical id name |> Formatter.writeElementFast
        let expected = "A[(Hello World)]"
        Expect.stringEqual actual expected ""
    testCase "circle" <| fun _ ->
        let actual = node.circle id name |> Formatter.writeElementFast
        let expected = "A((Hello World))"
        Expect.stringEqual actual expected ""
    testCase "asymmetric" <| fun _ ->
        let actual = node.asymmetric id name |> Formatter.writeElementFast
        let expected = "A>Hello World]"
        Expect.stringEqual actual expected ""
    testCase "rhombus" <| fun _ ->
        let actual = node.rhombus id name |> Formatter.writeElementFast
        let expected = "A{Hello World}"
        Expect.stringEqual actual expected ""
    testCase "hexagon " <| fun _ ->
        let actual = node.hexagon id name |> Formatter.writeElementFast
        let expected = "A{{Hello World}}"
        Expect.stringEqual actual expected ""
    testCase "parallelogram " <| fun _ ->
        let actual = node.parallelogram id name |> Formatter.writeElementFast
        let expected = "A[/Hello World/]"
        Expect.stringEqual actual expected ""
    testCase "parallelogram alt" <| fun _ ->
        let actual = node.parallelogramAlt id name |> Formatter.writeElementFast
        let expected = "A[\Hello World\]"
        Expect.stringEqual actual expected ""
    testCase "trapezoid" <| fun _ ->
        let actual = node.trapezoid id name |> Formatter.writeElementFast
        let expected = "A[/Hello World\]"
        Expect.stringEqual actual expected ""
    testCase "trapezoid alt" <| fun _ ->
        let actual = node.trapezoidAlt id name |> Formatter.writeElementFast
        let expected = "A[\Hello World/]"
        Expect.stringEqual actual expected ""
    testCase "double circle" <| fun _ ->
        let actual = node.doubleCircle id name |> Formatter.writeElementFast
        let expected = "A(((Hello World)))"
        Expect.stringEqual actual expected ""
]

let main = testList "Node" [
    tests_constructor
]
