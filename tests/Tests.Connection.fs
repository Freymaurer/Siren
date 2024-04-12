module Tests.Connection

open Fable.Pyxpecto
open Siren

let private tests_simple = testList "formatter" [
    let n1 = node.simple "A"
    let n2 = node.simple "B"
    testCase "simple" <| fun _ ->
        let actual = link.simple (n1,n2) |> Formatter.writeElementFast
        let expected = "A[A]---B[B]"
        Expect.stringEqual actual expected ""
    testCase "arrow" <| fun _ ->
        let actual = link.arrow (n1,n2) |> Formatter.writeElementFast
        let expected = "A[A]-->B[B]"
        Expect.stringEqual actual expected ""
    testCase "arrowDouble" <| fun _ ->
        let actual = link.arrowDouble (n1,n2) |> Formatter.writeElementFast
        let expected = "A[A]<-->B[B]"
        Expect.stringEqual actual expected ""
    testCase "dotted" <| fun _ ->
        let actual = link.dotted (n1,n2) |> Formatter.writeElementFast
        let expected = "A[A]-.-B[B]"
        Expect.stringEqual actual expected ""
    testCase "dottedArrow" <| fun _ ->
        let actual = link.dottedArrow (n1,n2) |> Formatter.writeElementFast
        let expected = "A[A]-.->B[B]"
        Expect.stringEqual actual expected ""
    testCase "thick" <| fun _ ->
        let actual = link.thick(n1,n2) |> Formatter.writeElementFast
        let expected = "A[A]===B[B]"
        Expect.stringEqual actual expected ""
    testCase "thickArrow" <| fun _ ->
        let actual = link.thickArrow(n1,n2) |> Formatter.writeElementFast
        let expected = "A[A]==>B[B]"
        Expect.stringEqual actual expected ""
    testCase "invisible" <| fun _ ->
        let actual = link.invisible(n1,n2) |> Formatter.writeElementFast
        let expected = "A[A]~~~B[B]"
        Expect.stringEqual actual expected ""
    testCase "circle edge" <| fun _ ->
        let actual = link.circleEdge(n1,n2) |> Formatter.writeElementFast
        let expected = "A[A]--oB[B]"
        Expect.stringEqual actual expected ""
    testCase "circle double" <| fun _ ->
        let actual = link.circleDouble(n1,n2) |> Formatter.writeElementFast
        let expected = "A[A]o--oB[B]"
        Expect.stringEqual actual expected ""
    testCase "cross edge" <| fun _ ->
        let actual = link.crossEdge(n1,n2) |> Formatter.writeElementFast
        let expected = "A[A]--xB[B]"
        Expect.stringEqual actual expected ""
    testCase "cross double" <| fun _ ->
        let actual = link.crossDouble(n1,n2) |> Formatter.writeElementFast
        let expected = "A[A]x--xB[B]"
        Expect.stringEqual actual expected ""
]

let main = testList "Connection" [
    tests_simple
]

