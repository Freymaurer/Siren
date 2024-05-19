using Xunit;
using Siren.Sea;

namespace Siren.Sea.Tests;
using Xunit;
using Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


public class ClassDiagramTests
{
    public class DocsTests
    {
        [Fact]
        public void Animals()
        {
            (string duck, string fish, string zebra, string animal) = ("Duck", "Fish", "Zebra", "Animal");
            SirenElement graph = siren.classDiagram
                ([
                    classDiagram.note("From Duck till Zebra"),
                    classDiagram.relationshipInheritance(duck, animal),
                    classDiagram.note(@"can fly\ncan swim\ncan dive\ncan help in debugging", duck),
                    classDiagram.relationshipInheritance(fish, animal),
                    classDiagram.relationshipInheritance(zebra, animal),
                    classDiagram.idAttr(animal,"age", "int", classMemberVisibility.@public),
                    classDiagram.idAttr(animal, "gender", "String", classMemberVisibility.@public),
                    classDiagram.idFunction(animal, "isMammal", classMemberVisibility: classMemberVisibility.@public),
                    classDiagram.idFunction(animal, "mate", classMemberVisibility: classMemberVisibility.@public),
                    classDiagram.@class(duck, [
                        classDiagram.classAttr("beakColor", "String", classMemberVisibility.@public),
                        classDiagram.classFunction("swim", classMemberVisibility: classMemberVisibility.@public),
                        classDiagram.classFunction("quack", classMemberVisibility: classMemberVisibility.@public)
                    ]),
                    classDiagram.@class(fish, [
                        classDiagram.classAttr("sizeInFeet", "int", classMemberVisibility.@private),
                        classDiagram.classFunction("canEat", classMemberVisibility: classMemberVisibility.@private)
                    ]),
                    classDiagram.@class(zebra, members: [
                        classDiagram.classAttr("is_wild", "bool", classMemberVisibility.@public),
                        classDiagram.classFunction("run", classMemberVisibility: classMemberVisibility.@public)
                    ]),
                    classDiagram.@namespace("Mammals", [
                        classDiagram.classId(zebra)
                    ])
                ]);
            string actual = siren.write(graph);
            string expected = @"classDiagram
    note ""From Duck till Zebra""
    Duck --|> Animal
    note for Duck ""can fly\ncan swim\ncan dive\ncan help in debugging""
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
    }
";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ClassTest()
        {
            string bankacc = "BankAccount";
            string actual = siren.classDiagram
                ([
                    classDiagram.classId(bankacc),
                    classDiagram.idAttr(bankacc, "owner", "String", classMemberVisibility.@public),
                    classDiagram.idAttr(bankacc, "balance", "Bigdecimal", classMemberVisibility.@public),
                    classDiagram.idFunction(bankacc, "deposit", "amount", classMemberVisibility: classMemberVisibility.@public),
                    classDiagram.idFunction(bankacc, "withdrawal", "amount", classMemberVisibility: classMemberVisibility.@public)
                ])
                    .withTitle("Bank example")
                    .write();
            string expected = @"---
title: Bank example
---
classDiagram
    class BankAccount
    BankAccount : +String owner
    BankAccount : +Bigdecimal balance
    BankAccount : +deposit(amount)
    BankAccount : +withdrawal(amount)
";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void GenericTypesTest()
        {
            string square = "Square";
            string actual = siren.classDiagram
                ([
                    classDiagram.classId(square, generic: "Shape", members: new ClassDiagramElement[] {
                        classDiagram.classAttr("id", "int"),
                        classDiagram.classAttr("position", "List<int>"),
                        classDiagram.classFunction("setPoints", "List<int> points"),
                        classDiagram.classFunction("getPoints", returnType: "List<int>")
                    }),
                    classDiagram.idAttr(square, "messages", "List<string>", classMemberVisibility.@private),
                    classDiagram.idFunction(square, "setMessages", "List<string> messages", classMemberVisibility: classMemberVisibility.@public),
                    classDiagram.idFunction(square, "getMessages", returnType: "List<string>", classMemberVisibility: classMemberVisibility.@public),
                    classDiagram.idFunction(square, "getDistanceMatrix", returnType: "List<List<int>>", classMemberVisibility: classMemberVisibility.@public)

                ]).write();
            string expected = @"classDiagram
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
";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void AnnotationsTest()
        {
            string actual = siren.classDiagram
                ([
                    classDiagram.@class("Shape", [
                        classDiagram.@interface(),
                        classDiagram.classAttr("noOfVertices"),
                        classDiagram.classFunction("draw")
                    ]),
                    classDiagram.@class("Color", [
                        classDiagram.enumeration(),
                        classDiagram.classAttr("RED"),
                        classDiagram.classAttr("BLUE"),
                        classDiagram.classAttr("GREEN"),
                        classDiagram.classAttr("WHITE"),
                        classDiagram.classAttr("BLACK")
                    ])
                ]).write();
            string expected = @"classDiagram
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
";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void DiagramDirectionTest()
        {
            (string student, string idCard, string bike) = ("Student", "IdCard", "Bike");
            string actual = siren.classDiagram
                ([
                    classDiagram.directionRL,
                    classDiagram.@class(student, [
                        classDiagram.raw("-idCard : IdCard")
                    ]),
                    classDiagram.@class(idCard, [
                        classDiagram.raw("-id : int"),
                        classDiagram.raw("-name : string")
                    ]),
                    classDiagram.@class(bike, [
                        classDiagram.raw("-id : int"),
                        classDiagram.raw("-name : string")
                    ]),
                    classDiagram.relationshipAggregation(student, idCard, "carries", classCardinality.one, classCardinality.one),
                    classDiagram.relationshipAggregation(student, bike, "rides", classCardinality.one, classCardinality.one)
                ]).write();
            string expected = @"classDiagram
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
    Student ""1"" --o ""1"" IdCard : carries
    Student ""1"" --o ""1"" Bike : rides
";
            Assert.Equal(expected, actual);
        }
    }

    public class CompletenessTests
    {
        [Fact]
        public void ClassDiagramTest()
        {
            Type csharpType = typeof(Siren.Sea.classDiagram);
            Type fsharpType = typeof(Siren.classDiagram);
            Utils.CompareClasses(csharpType, fsharpType);
        }
        [Fact]
        public void CardinalityTest()
        {
            Type csharpType = typeof(Siren.Sea.classCardinality);
            Type fsharpType = typeof(Siren.classCardinality);
            Utils.CompareClasses(csharpType, fsharpType);
        }
        [Fact]
        public void DirectionTest()
        {
            Type csharpType = typeof(Siren.Sea.classDirection);
            Type fsharpType = typeof(Siren.classDirection);
            Utils.CompareClasses(csharpType, fsharpType);
        }
        [Fact]
        public void RelationshipTypeTest()
        {
            Type csharpType = typeof(Siren.Sea.classRltsType);
            Type fsharpType = typeof(Siren.classRltsType);
            Utils.CompareClasses(csharpType, fsharpType);
        }
        [Fact]
        public void MemberClassifierTest()
        {
            Type csharpType = typeof(Siren.Sea.classMemberClassifier);
            Type fsharpType = typeof(Siren.classMemberClassifier);
            Utils.CompareClasses(csharpType, fsharpType);
        }
        [Fact]
        public void MemberVisibilityTest()
        {
            Type csharpType = typeof(Siren.Sea.classMemberVisibility);
            Type fsharpType = typeof(Siren.classMemberVisibility);
            Utils.CompareClasses(csharpType, fsharpType);
        }
    }
}
