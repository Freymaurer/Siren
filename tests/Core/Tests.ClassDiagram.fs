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
                classDiagram.idAttr(ba,"owner", "String")
                classDiagram.idAttr(ba,"balance", "BigDecimal", classMemberVisibility.Public)
                classDiagram.idFunction(ba,"deposit", "amount", classMemberVisibility = classMemberVisibility.Public)
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
                classDiagram.idAttr(ba,"owner", "String", classMemberClassifier = classMemberClassifier.Abstract)
                classDiagram.idAttr(ba,"owner", "float", classMemberClassifier = classMemberClassifier.Static)
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
                classDiagram.idAttr(ba,"owner","String", classMemberVisibility.packageInternal, classMemberClassifier.Abstract)
                classDiagram.idAttr(ba,"owner", "float", classMemberVisibility.Public , classMemberClassifier.Static)
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
                classDiagram.idAttr("Animal", "sex", "String", cmv.Public, cmc.Static)
            ]
            |> siren.write
        let expected = """classDiagram
    class Animal~Animal~["Such a cool thing"]
    Animal : +String sex$
"""
        Expect.trimEqual actual expected ""
    testCase "members" <| fun _ ->
        let actual = 
            siren.classDiagram [
                classDiagram.``class``("BankAccount", "Treasure chest",members=[
                    classDiagram.classAttr("owner","String", classMemberVisibility.Public)
                    classDiagram.classAttr("balance","BigDecimal", classMemberVisibility.Public)
                    classDiagram.classFunction("deposit", "amount", "bool", classMemberVisibility.Public)
                    classDiagram.classFunction("withdrawal", "amount", "int", classMemberVisibility.Public)
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

let private tests_docs = testList "docs" [
    testCase "animals" <| fun _ ->
        let actual =
            let duck,animal,zebra,fish = "Duck","Animal","Zebra", "Fish"
            siren.classDiagram [
                classDiagram.note "From Duck till Zebra"
                classDiagram.relationshipInheritance(duck, animal)
                classDiagram.note(@"can fly\ncan swim\ncan dive\ncan help in debugging", duck)
                classDiagram.relationshipInheritance(fish, animal)
                classDiagram.relationshipInheritance(zebra, animal)
                classDiagram.idAttr(animal,"age", "int", classMemberVisibility.Public)
                classDiagram.idAttr(animal, "gender", "String", classMemberVisibility.Public)
                classDiagram.idFunction(animal, "isMammal", classMemberVisibility = classMemberVisibility.Public)
                classDiagram.idFunction(animal, "mate", classMemberVisibility = classMemberVisibility.Public)
                classDiagram.``class``(duck,members=[
                    classDiagram.classAttr("beakColor","String", classMemberVisibility.Public)
                    classDiagram.classFunction("swim", classMemberVisibility = classMemberVisibility.Public)
                    classDiagram.classFunction("quack", classMemberVisibility = classMemberVisibility.Public)
                ])
                classDiagram.``class``(fish,members=[
                    classDiagram.classAttr("sizeInFeet","int", classMemberVisibility.Private)
                    classDiagram.classFunction("canEat", classMemberVisibility = classMemberVisibility.Private)
                ])
                classDiagram.``class``(zebra,members=[
                    classDiagram.classAttr("is_wild","bool", classMemberVisibility.Public)
                    classDiagram.classFunction("run", classMemberVisibility = classMemberVisibility.Public)
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
    testCase "Class" <| fun _ ->
        let actual =
            let bankacc = "BankAccount"
            siren.classDiagram [
                classDiagram.``class``(bankacc)
                classDiagram.idAttr(bankacc,"owner", "String", classMemberVisibility.Public)
                classDiagram.idAttr(bankacc,"balance", "Bigdecimal", classMemberVisibility.Public)
                classDiagram.idFunction(bankacc,"deposit", "amount", classMemberVisibility = classMemberVisibility.Public)
                classDiagram.idFunction(bankacc,"withdrawal", "amount", classMemberVisibility = classMemberVisibility.Public)
            ]
            |> siren.withTitle ("Bank example")
            |> siren.write
        let expected = """---
title: Bank example
---
classDiagram
    class BankAccount
    BankAccount : +String owner
    BankAccount : +Bigdecimal balance
    BankAccount : +deposit(amount)
    BankAccount : +withdrawal(amount)
"""
        Expect.trimEqual actual expected ""
    testCase "Generic Types" <| fun _ ->
        let actual =
            let square = "Square"
            siren.classDiagram [
                classDiagram.``class``(square, generic="Shape", members=[
                    classDiagram.classAttr("id", "int")
                    classDiagram.classAttr("position", "List<int>")
                    classDiagram.classFunction("setPoints", "List<int> points")
                    classDiagram.classFunction("getPoints", returnType = "List<int>")
                ])
                classDiagram.idAttr(square, "messages", "List<string>", classMemberVisibility.Private)
                classDiagram.idFunction(square, "setMessages", "List<string> messages", classMemberVisibility = classMemberVisibility.Public)
                classDiagram.idFunction(square, "getMessages", returnType = "List<string>", classMemberVisibility = classMemberVisibility.Public)
                classDiagram.idFunction(square, "getDistanceMatrix", returnType = "List<List<int>>", classMemberVisibility = classMemberVisibility.Public)
            ]
            |> siren.write
        let expected = """classDiagram
    class Square~Shape~{
        int id
        List~int~ position
        setPoints(List~int~ points)
        getPoints() List~int~
    }
    Square : -List~string~ messages
    Square : +setMessages(List~string~ messages)
    Square : +getMessages() List~string~
    Square : +getDistanceMatrix() List~List~int~~
"""
        Expect.trimEqual actual expected ""
    testCase "Annotations" <| fun _ ->
        let actual =
            siren.classDiagram [
                classDiagram.``class``("Shape", members=[
                    classDiagram.Interface()
                    classDiagram.classAttr("noOfVertices")
                    classDiagram.classFunction("draw")
                ])
                classDiagram.``class``("Color", members=[
                    classDiagram.enumeration()
                    classDiagram.classAttr("RED")
                    classDiagram.classAttr("BLUE")
                    classDiagram.classAttr("GREEN")
                    classDiagram.classAttr("WHITE")
                    classDiagram.classAttr("BLACK")
                ])
            ]
            |> siren.write
        let expected = """classDiagram
    class Shape{
        <<Interface>>
        noOfVertices
        draw()
    }
    class Color{
        <<Enumeration>>
        RED
        BLUE
        GREEN
        WHITE
        BLACK
    }
"""
        Expect.trimEqual actual expected ""
    testCase "Diagram Direction" <| fun _ ->
        let actual =
            let student, idCard, bike = "Student", "IdCard", "Bike"
            siren.classDiagram [
                classDiagram.directionRL
                classDiagram.``class``(student, members=[
                    classDiagram.raw("-idCard : IdCard")
                ])
                classDiagram.``class``(idCard, members=[
                    classDiagram.raw("-id : int")
                    classDiagram.raw("-name : string")
                ])
                classDiagram.``class``(bike, members=[
                    classDiagram.raw("-id : int")
                    classDiagram.raw("-name : string")
                ])
                classDiagram.relationshipAggregation (student, idCard, "carries", classCardinality.one, classCardinality.one)
                classDiagram.relationshipAggregation (student, bike, "rides", classCardinality.one, classCardinality.one)
            ]
            |> siren.write
        let expected = """classDiagram
    direction RL
    class Student{
        -idCard : IdCard
    }
    class IdCard{
        -id : int
        -name : string
    }
    class Bike{
        -id : int
        -name : string
    }
    Student "1" --o "1" IdCard : carries
    Student "1" --o "1" Bike : rides
"""
        Expect.trimEqual actual expected ""
]

let main = testList "ClassDiagram" [
    tests_click
    tests_namespace
    tests_rlts
    tests_member
    tests_class
    tests_docs
]