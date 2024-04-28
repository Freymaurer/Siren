module Tests.ClassDiagram

open Fable.Pyxpecto
open Siren

let private tests_click = testList "click" [
    testCase "href" <| fun _ ->
        let actual =
            siren.classDiagram [
                classDiagram.``class`` "ClassA"
                classDiagram.clickHref ("ClassA", @"https://mermaid.js.org/syntax/classDiagram.html#setting-the-direction-of-the-diagram")
            ]
            |> siren.write
        let expected = """classDiagram
    class ClassA
    click ClassA href "https://mermaid.js.org/syntax/classDiagram.html#setting-the-direction-of-the-diagram"
"""
        Expect.trimEqual actual expected ""
]

let private tests_namespace = testList "namespace" [
    testCase "empty" <| fun _ ->
        let actual =
            siren.classDiagram [
                classDiagram.``namespace``("BaseShapes", [])
            ]
            |> siren.write
        let expected = """classDiagram
"""
        Expect.trimEqual actual expected ""
    testCase "simple" <| fun _ ->
        let actual =
            siren.classDiagram [
                classDiagram.``namespace``("BaseShapes", [
                    classDiagram.``class``("classA")
                ])
            ]
            |> siren.write
        let expected = """classDiagram
    namespace BaseShapes {
        class classA
    }
"""
        Expect.trimEqual actual expected ""
]

let private tests_rlts = testList "Relationship" [
    testCase "simple" <| fun _ ->
        let actual = 
            siren.classDiagram [
                classDiagram.relationshipInheritance("classA","classB")
                classDiagram.relationshipComposition("classC","classD")
                classDiagram.relationshipAggregation("classE","classF")
                classDiagram.relationshipAssociation("classG","classH")
                classDiagram.relationshipSolid("classI","classJ")
                classDiagram.relationshipDependency("classK","classL")
                classDiagram.relationshipRealization("classM","classN")
                classDiagram.relationshipDashed("classO","classP")
            ]
            |> siren.write
        let expected = """classDiagram
    classA --|> classB
    classC --* classD
    classE --o classF
    classG --> classH
    classI -- classJ
    classK ..> classL
    classM ..|> classN
    classO .. classP
"""
        Expect.trimEqual actual expected ""
    testCase "custom" <| fun _ ->
        let actual = 
            siren.classDiagram [
                classDiagram.relationshipCustom("classA","classB", 
                    classRltsType.aggregation,
                    "Test Label",
                    classDirection.twoWay,
                    true,
                    classCardinality.one,
                    classCardinality.custom "many")
            ]
            |> siren.write
        let expected = """classDiagram
    classA "1" o..o "many" classB : Test Label
"""
        Expect.trimEqual actual expected ""
]

let private tests_member = testList "member" [
    testCase "visibility" <| fun _ ->
        let actual = 
            let ba = "BankAccount"
            siren.classDiagram [
                classDiagram.``class`` ba
                classDiagram.``member``(ba,"String owner")
                classDiagram.``member``(ba,"+BigDecimal balance")
                classDiagram.``member``(ba,"deposit(amount)", memberVisibility.``public``)
            ]
            |> siren.write
        let expected = """classDiagram
    class BankAccount
    BankAccount : String owner
    BankAccount : +BigDecimal balance
    BankAccount : +deposit(amount)
"""
        Expect.trimEqual actual expected ""
    testCase "classifier" <| fun _ ->
        let actual = 
            let ba = "BankAccount"
            siren.classDiagram [
                classDiagram.``class`` ba
                classDiagram.memberAbstract(ba,"String owner")
                classDiagram.memberStatic(ba,"float owner")
            ]
            |> siren.write
        let expected = """classDiagram
    class BankAccount
    BankAccount : String owner*
    BankAccount : float owner$
"""
        Expect.trimEqual actual expected ""
    testCase "full" <| fun _ ->
        let actual = 
            let ba = "BankAccount"
            siren.classDiagram [
                classDiagram.``class`` ba
                classDiagram.``member``(ba,"String owner",memberVisibility.packageInternal, memberClassifier.``abstract``)
                classDiagram.``member``(ba,"float owner", memberVisibility.``public`` , memberClassifier.``static`` )
            ]
            |> siren.write
        let expected = """classDiagram
    class BankAccount
    BankAccount : ~String owner*
    BankAccount : +float owner$
"""
        Expect.trimEqual actual expected ""
]

let private tests_class = testList "class" [
    testCase "id-only" <| fun _ ->
        let actual = 
            siren.classDiagram [
                classDiagram.``class``("Animal")
            ]
            |> siren.write
        let expected = """classDiagram
    class Animal
"""
        Expect.trimEqual actual expected ""
    testCase "id+name" <| fun _ ->
        let actual = 
            siren.classDiagram [
                classDiagram.``class``("Animal", "Such a cool thing")
            ]
            |> siren.write
        let expected = """classDiagram
    class Animal["Such a cool thing"]
"""
        Expect.trimEqual actual expected ""
    testCase "id+name+generic" <| fun _ ->
        let actual = 
            siren.classDiagram [
                classDiagram.``class``("Animal", "Such a cool thing","Animal")
                classDiagram.memberStatic("Animal", "sex", memberVisibility.``public``)
            ]
            |> siren.write
        let expected = """classDiagram
    class Animal~Animal~["Such a cool thing"]
    Animal : +sex$
"""
        Expect.trimEqual actual expected ""
    testCase "members" <| fun _ ->
        let actual = 
            siren.classDiagram [
                classDiagram.``class``("BankAccount", "Treasure chest",members=[
                    "+String owner"
                    "+BigDecimal balance"
                    "+deposit(amount) bool"
                    "+withdrawal(amount) int"
                ])
            ]
            |> siren.write
        let expected = """classDiagram
    class BankAccount["Treasure chest"]{
        +String owner
        +BigDecimal balance
        +deposit(amount) bool
        +withdrawal(amount) int
    }
"""
        Expect.trimEqual actual expected ""
]

let private tests_complex = testList "complex" [
    testCase "animals" <| fun _ ->
        let actual =
            let duck,animal,zebra,fish = "Duck","Animal","Zebra", "Fish"
            siren.classDiagram [
                classDiagram.note "From Duck till Zebra"
                classDiagram.relationshipInheritance(duck, animal)
                classDiagram.note(@"can fly\ncan swim\ncan dive\ncan help in debugging", duck)
                classDiagram.relationshipInheritance(fish, animal)
                classDiagram.relationshipInheritance(zebra, animal)
                classDiagram.``member``(animal,"+int age")
                classDiagram.``member``(animal,"+String gender")
                classDiagram.``member``(animal,"+isMammal()")
                classDiagram.``member``(animal,"+mate()")
                classDiagram.``class``(duck,members=[
                    "+String beakColor"
                    "+swim()"
                    "+quack()"
                ])
                classDiagram.``class``(fish,members=[
                    "-int sizeInFeet"
                    "-canEat()"
                ])
                classDiagram.``class``(zebra,members=[
                    "+bool is_wild"
                    "+run()"
                ])
                classDiagram.``namespace``("Mammals", [
                    classDiagram.``class``(zebra)
                ])
            ]
            |> siren.write
        let expected = """classDiagram
    note "From Duck till Zebra"
    Duck --|> Animal
    note for Duck "can fly\ncan swim\ncan dive\ncan help in debugging"
    Fish --|> Animal
    Zebra --|> Animal
    Animal : +int age
    Animal : +String gender
    Animal : +isMammal()
    Animal : +mate()
    class Duck{
        +String beakColor
        +swim()
        +quack()
    }
    class Fish{
        -int sizeInFeet
        -canEat()
    }
    class Zebra{
        +bool is_wild
        +run()
    }
    namespace Mammals {
        class Zebra
    }"""
        Expect.trimEqual actual expected ""
]

let main = testList "ClassDiagram" [
    tests_click
    tests_namespace
    tests_rlts
    tests_member
    tests_class
    tests_complex
]