import {siren, classDiagram, direction, classCardinality, classMemberVisibility } from "./siren/index.js"
import * as assert from "assert"

describe('class diagram', function(){
  it('animals', function(){
      let [duck,animal,zebra,fish] = ["Duck","Animal","Zebra","Fish"]
      const actual = 
          siren.classDiagram([
            classDiagram.note("From Duck till Zebra"),
            classDiagram.relationshipInheritance(duck, animal),
            classDiagram.note("can fly\ncan swim\ncan dive\ncan help in debugging", duck),
            classDiagram.relationshipInheritance(fish, animal),
            classDiagram.relationshipInheritance(zebra, animal),
            classDiagram.idAttr(animal, "age", "int", classMemberVisibility.Public),
            classDiagram.idAttr(animal, "gender", "String", classMemberVisibility.Public),
            classDiagram.idFunction(animal, "isMammal", null, null, classMemberVisibility.Public),
            classDiagram.idFunction(animal, "mate", null, null, classMemberVisibility.Public),
            classDiagram.class(duck, [
                classDiagram.classAttr("beakColor", "String", classMemberVisibility.Public),
                classDiagram.classFunction("swim", null, null, classMemberVisibility.Public),
                classDiagram.classFunction("quack", null, null, classMemberVisibility.Public)
            ]),
            classDiagram.class(fish, [
                classDiagram.classAttr("sizeInFeet","int", classMemberVisibility.Private),
                classDiagram.classFunction("canEat", null, null, classMemberVisibility.Private)
            ]),
            classDiagram.class(zebra, [
                classDiagram.classAttr("is_wild","bool", classMemberVisibility.Public),
                classDiagram.classFunction("run", null, null, classMemberVisibility.Public)
            ]),
            classDiagram.namespace("Mammals", [
                classDiagram.classId(zebra)
            ])
          ]).write();
      const expected = `classDiagram
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
    }
`
      assert.equal(actual,expected,"This should be equal")
  });
  it('Class', function(){
    let bankacc = "BankAccount"
    const actual = 
        siren.classDiagram([
            classDiagram.classId(bankacc),
            classDiagram.idAttr(bankacc,"owner", "String", classMemberVisibility.Public),
            classDiagram.idAttr(bankacc,"balance", "Bigdecimal", classMemberVisibility.Public),
            classDiagram.idFunction(bankacc,"deposit", "amount", null, classMemberVisibility.Public),
            classDiagram.idFunction(bankacc,"withdrawal", "amount", null, classMemberVisibility.Public)
        ])
          .withTitle("Bank example")
          .write();
    const expected = `---
title: Bank example
---
classDiagram
    class BankAccount
    BankAccount : +String owner
    BankAccount : +Bigdecimal balance
    BankAccount : +deposit(amount)
    BankAccount : +withdrawal(amount)
`
    assert.equal(actual,expected,"This should be equal")
  });
  it('Generic Types', function(){
    let square = "Square"
    const actual = 
        siren.classDiagram([
            classDiagram.classId(square, null, "Shape", [
                classDiagram.classAttr("id", "int"),
                classDiagram.classAttr("position", "List<int>"),
                classDiagram.classFunction("setPoints", "List<int> points"),
                classDiagram.classFunction("getPoints", null, "List<int>")
            ]),
            classDiagram.idAttr(square, "messages", "List<string>", classMemberVisibility.Private),
            classDiagram.idFunction(square, "setMessages", "List<string> messages", null,  classMemberVisibility.Public),
            classDiagram.idFunction(square, "getMessages", null, "List<string>", classMemberVisibility.Public),
            classDiagram.idFunction(square, "getDistanceMatrix", null, "List<List<int>>", classMemberVisibility.Public)
        ])
          .write();
    const expected = `classDiagram
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
`
    assert.equal(actual,expected,"This should be equal")
  });
  it('Annotations', function(){
    const actual = 
        siren.classDiagram([
            classDiagram.class("Shape", [
                classDiagram.Interface(),
                classDiagram.classAttr("noOfVertices"),
                classDiagram.classFunction("draw")
            ]),
            classDiagram.class("Color", [
                classDiagram.enumeration(),
                classDiagram.classAttr("RED"),
                classDiagram.classAttr("BLUE"),
                classDiagram.classAttr("GREEN"),
                classDiagram.classAttr("WHITE"),
                classDiagram.classAttr("BLACK")
            ])
        ])
          .write();
    const expected = `classDiagram
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
`
    assert.equal(actual,expected,"This should be equal")
  });
  it('Diagram Direction', function(){
    let [student, idCard, bike] = ["Student", "IdCard", "Bike"]
    const actual = 
        siren.classDiagram([
            classDiagram.directionRL,
            classDiagram.class(student, [
                classDiagram.raw("-idCard : IdCard")
            ]),
            classDiagram.class(idCard, [
                classDiagram.raw("-id : int"),
                classDiagram.raw("-name : string")
            ]),
            classDiagram.class(bike, [
                classDiagram.raw("-id : int"),
                classDiagram.raw("-name : string")
            ]),
            classDiagram.relationshipAggregation (student, idCard, "carries", classCardinality.one, classCardinality.one),
            classDiagram.relationshipAggregation (student, bike, "rides", classCardinality.one, classCardinality.one)
        ])
          .write();
    const expected = `classDiagram
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
`
    assert.equal(actual,expected,"This should be equal")
  });
});