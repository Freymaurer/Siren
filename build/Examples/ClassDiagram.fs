module Build.Examples.ClassDiagram

open Siren
open Util

let writeAnimalExample() =
    let key = "Example2"
    let codeDisplay = """let duck,animal,zebra,fish = "Duck","Animal","Zebra", "Fish"
siren.classDiagram [
    classDiagram.note "From Duck till Zebra"
    classDiagram.relationshipInheritance(duck, animal)
    classDiagram.note(@"can fly\ncan swim\ncan dive\ncan help in debugging", duck)
    classDiagram.relationshipInheritance(fish, animal)
    classDiagram.relationshipInheritance(zebra, animal)
    classDiagram.classMember(animal,"+int age")
    classDiagram.classMember(animal,"+String gender")
    classDiagram.classMember(animal,"+isMammal()")
    classDiagram.classMember(animal,"+mate()")
    classDiagram.class'(duck,members=[
        "+String beakColor"
        "+swim()"
        "+quack()"
    ])
    classDiagram.class'(fish,members=[
        "-int sizeInFeet"
        "-canEat()"
    ])
    classDiagram.class'(zebra,members=[
        "+bool is_wild"
        "+run()"
    ])
    classDiagram.namespace'("Mammals", [
        classDiagram.class'(zebra)
    ])
]
|> siren.write
"""
    let mermaidMd = 
        let duck,animal,zebra,fish = "Duck","Animal","Zebra", "Fish"
        siren.classDiagram [
            classDiagram.note "From Duck till Zebra"
            classDiagram.relationshipInheritance(duck, animal)
            classDiagram.note(@"can fly\ncan swim\ncan dive\ncan help in debugging", duck)
            classDiagram.relationshipInheritance(fish, animal)
            classDiagram.relationshipInheritance(zebra, animal)
            classDiagram.classMember(animal,"+int age")
            classDiagram.classMember(animal,"+String gender")
            classDiagram.classMember(animal,"+isMammal()")
            classDiagram.classMember(animal,"+mate()")
            classDiagram.class'(duck,members=[
                "+String beakColor"
                "+swim()"
                "+quack()"
            ])
            classDiagram.class'(fish,members=[
                "-int sizeInFeet"
                "-canEat()"
            ])
            classDiagram.class'(zebra,members=[
                "+bool is_wild"
                "+run()"
            ])
            classDiagram.namespace'("Mammals", [
                classDiagram.class'(zebra)
            ])
        ]
        |> siren.write
    let replacement = $"""
```fsharp
{codeDisplay}
```

```mermaid
{mermaidMd}
```
"""
    writeExample(key, replacement)

