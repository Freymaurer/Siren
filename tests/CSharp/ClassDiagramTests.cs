using Xunit;
using Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Siren.Types;
using System.Reflection;

namespace Tests
{
    public class ClassDiagramTests
    {
        [Fact]
        public void Docs()
        {
            (string duck, string fish, string zebra, string animal) = ("Duck", "Fish", "Zebra", "Animal");
            SirenElement graph = siren.classDiagram
                ([
                    classDiagram.note("From Duck till Zebra"),
                    classDiagram.relationshipInheritance(duck, animal),
                    classDiagram.note(@"can fly\ncan swim\ncan dive\ncan help in debugging", duck),
                    classDiagram.relationshipInheritance(fish, animal),
                    classDiagram.relationshipInheritance(zebra, animal),
                    classDiagram.member(animal, "+int age"),
                    classDiagram.member(animal, "String gender", memberVisibility.@public),
                    classDiagram.member(animal, "isMammal()", memberVisibility.@public),
                    classDiagram.member(animal, "mate()", memberVisibility.@public),
                    classDiagram.@class(duck, members: new string[] {
                        "+String beakColor",
                        "+swim()",
                        "+quack()",
                    }),
                    classDiagram.@class(fish, members: new string[] {
                        "-int sizeInFeet",
                        "-canEat()",
                    }),
                    classDiagram.@class(zebra, members: new string[] {
                        "+bool is_wild",
                        "+run()",
                    }),
                    classDiagram.@namespace("Mammals", [
                        classDiagram.@class(zebra)    
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
    }
}