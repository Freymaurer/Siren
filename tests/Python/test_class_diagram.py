from siren.index import siren, class_diagram, class_member_visibility, class_cardinality

class TestClassDiagram:

  def test_animals(self):
      (duck,animal,zebra,fish) = ("Duck","Animal","Zebra","Fish")
      actual: str = siren.class_diagram([
            class_diagram.note("From Duck till Zebra"),
            class_diagram.relationship_inheritance(duck, animal),
            class_diagram.note("can fly\ncan swim\ncan dive\ncan help in debugging", duck),
            class_diagram.relationship_inheritance(fish, animal),
            class_diagram.relationship_inheritance(zebra, animal),
            class_diagram.id_attr(animal, "age", "int", class_member_visibility.Public()),
            class_diagram.id_attr(animal, "gender", "String", class_member_visibility.Public()),
            class_diagram.id_function(animal, "isMammal", class_member_visibility = class_member_visibility.Public()),
            class_diagram.id_function(animal, "mate", class_member_visibility = class_member_visibility.Public()),
            class_diagram.class_(duck, [
                class_diagram.class_attr("beakColor", "String", class_member_visibility.Public()),
                class_diagram.class_function("swim", class_member_visibility = class_member_visibility.Public()),
                class_diagram.class_function("quack", class_member_visibility = class_member_visibility.Public())
            ]),
            class_diagram.class_(fish, [
                class_diagram.class_attr("sizeInFeet","int", class_member_visibility.Private()),
                class_diagram.class_function("canEat", class_member_visibility = class_member_visibility.Private())
            ]),
            class_diagram.class_(zebra, [
                class_diagram.class_attr("is_wild","bool", class_member_visibility.Public()),
                class_diagram.class_function("run", class_member_visibility = class_member_visibility.Public())
            ]),
            class_diagram.namespace("Mammals", [
                class_diagram.class_id(zebra)
            ])
        ]).write()
      expected = """classDiagram
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
"""
      assert actual == expected
  def test_class(self):
      bankacc = "BankAccount"
      actual: str = siren.class_diagram([
            class_diagram.class_id(bankacc),
            class_diagram.id_attr(bankacc,"owner", "String", class_member_visibility.Public()),
            class_diagram.id_attr(bankacc,"balance", "Bigdecimal", class_member_visibility.Public()),
            class_diagram.id_function(bankacc,"deposit", "amount", class_member_visibility = class_member_visibility.Public()),
            class_diagram.id_function(bankacc,"withdrawal", "amount", class_member_visibility = class_member_visibility.Public())
        ]).with_title("Bank example").write()
      expected = """---
title: Bank example
---
classDiagram
    class BankAccount
    BankAccount : +String owner
    BankAccount : +Bigdecimal balance
    BankAccount : +deposit(amount)
    BankAccount : +withdrawal(amount)
"""
      assert actual == expected
  def test_generic_types(self):
      square = "Square"
      actual: str = siren.class_diagram([
          class_diagram.class_id(square, generic="Shape", members=[
              class_diagram.class_attr("id", "int"),
              class_diagram.class_attr("position", "List<int>"),
              class_diagram.class_function("setPoints", "List<int> points"),
              class_diagram.class_function("getPoints", return_type = "List<int>")
          ]),
          class_diagram.id_attr(square, "messages", "List<string>", class_member_visibility=class_member_visibility.Private()),
          class_diagram.id_function(square, "setMessages", "List<string> messages", class_member_visibility=class_member_visibility.Public()),
          class_diagram.id_function(square, "getMessages", return_type = "List<string>", class_member_visibility=class_member_visibility.Public()),
          class_diagram.id_function(square, "getDistanceMatrix", return_type = "List<List<int>>", class_member_visibility=class_member_visibility.Public())
      ]).write()
      expected = """classDiagram
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
      assert actual == expected
  def test_annotations(self):
      actual: str = siren.class_diagram([
          class_diagram.class_("Shape", members=[
              class_diagram.Interface(),
              class_diagram.class_attr("noOfVertices"),
              class_diagram.class_function("draw")
          ]),
          class_diagram.class_("Color", members=[
              class_diagram.enumeration(),
              class_diagram.class_attr("RED"),
              class_diagram.class_attr("BLUE"),
              class_diagram.class_attr("GREEN"),
              class_diagram.class_attr("WHITE"),
              class_diagram.class_attr("BLACK")
          ])
      ]).write()
      expected = """classDiagram
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
      assert actual == expected
  def test_diagram_direction(self):
      (student, idCard, bike) = ("Student", "IdCard", "Bike")
      actual: str = siren.class_diagram([
          class_diagram.direction_rl(),
          class_diagram.class_(student, members=[
              class_diagram.raw("-idCard : IdCard")
          ]),
          class_diagram.class_(idCard, members=[
              class_diagram.raw("-id : int"),
              class_diagram.raw("-name : string")
          ]),
          class_diagram.class_(bike, members=[
              class_diagram.raw("-id : int"),
              class_diagram.raw("-name : string")
          ]),
          class_diagram.relationship_aggregation (student, idCard, "carries", class_cardinality.one(), class_cardinality.one()),
          class_diagram.relationship_aggregation (student, bike, "rides", class_cardinality.one(), class_cardinality.one())
      ]).write()
      expected = """classDiagram
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
      assert actual == expected