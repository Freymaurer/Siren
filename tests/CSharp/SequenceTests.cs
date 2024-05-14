using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Siren.Yaml.AST;
using System.Reflection.Metadata;

namespace Siren.Sea.Tests
{
    public class Sequence
    {
        [Fact]
        public void Alt()
        {
            SirenElement graph =
                siren.sequence([
                    sequence.alt("if",[],[
                        ("else", [])
                    ])
                ]);
            string actual = siren.write(graph);
            string expected = @"sequenceDiagram
    alt if
    else else
    end
";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Links()
        {
            SirenElement graph =
                siren.sequence([
                    sequence.participant("Alice"),
                        sequence.participant("John"),
                        sequence.links("Alice", [("Dashboard", "https://dashboard.contoso.com/alice"), ("Wiki", "https://wiki.contoso.com/alice")]),
                        sequence.links("John", [("Dashboard", "https://dashboard.contoso.com/john"), ("Wiki", "https://wiki.contoso.com/john")]),
                        sequence.messageArrow("Alice", "John", "Hello John, how are you?"),
                ]);
            string actual = siren.write(graph);
            string expected = @"sequenceDiagram
    participant Alice
    participant John
    links Alice: {""Dashboard"": ""https://dashboard.contoso.com/alice"", ""Wiki"": ""https://wiki.contoso.com/alice""}
    links John: {""Dashboard"": ""https://dashboard.contoso.com/john"", ""Wiki"": ""https://wiki.contoso.com/john""}
    Alice->>John: Hello John, how are you?
";
            Assert.Equal(expected, actual);
        }
        public class Docs
        {
            [Fact]
            public void Simple()
            {
                string actual =
                    siren.sequence([
                        sequence.messageArrow( "Alice",  "John", "Hello John, how are you?"),
                        sequence.messageDottedArrow( "John",  "Alice", "Great!"),
                        sequence.messageOpenArrow( "Alice",  "John", "See you later!")
                    ]).write();
                string expected = @"sequenceDiagram
    Alice->>John: Hello John, how are you?
    John-->>Alice: Great!
    Alice-)John: See you later!
";
                Assert.Equal(expected, actual);
            }
            [Fact]
            public void CreateDestroy()
            {
                (string alice, string bob, string carl, string donald) = ("Alice", "Bob", "Carl", "D");
                string actual =
                    siren.sequence([
                        sequence.messageArrow(alice, bob, "Hello Bob, how are you?"),
                        sequence.messageArrow(bob, alice, "Fine, thank you. And you?"),
                        sequence.createParticipant (carl),
                        sequence.messageArrow(alice, carl, "Hi Carl!"),
                        sequence.createActor(donald, "Donald"),
                        sequence.messageArrow(carl, donald, "Hi!"),
                        sequence.destroy (carl),
                        sequence.messageCross(alice, carl, "We are too many"),
                        sequence.destroy (bob),
                        sequence.messageArrow(bob, alice, "I agree")
                    ]).write();
                string expected = @"sequenceDiagram
    Alice->>Bob: Hello Bob, how are you?
    Bob->>Alice: Fine, thank you. And you?
    create participant Carl
    Alice->>Carl: Hi Carl!
    create actor D as Donald
    Carl->>D: Hi!
    destroy Carl
    Alice-xCarl: We are too many
    destroy Bob
    Bob->>Alice: I agree
";
                Assert.Equal(expected, actual);
            }
            [Fact]
            public void NestedActivation()
            {
                (string alice, string john) = ("Alice", "John");
                string actual =
                    siren.sequence([
                        sequence.messageArrow(alice, john, "Hello John, how are you?", true),
                        sequence.messageArrow(alice, john, "John, can you hear me?", true),
                        sequence.messageDottedArrow(john, alice, "Hi Alice, I can hear you!", false),
                        sequence.messageDottedArrow(john, alice, "I feel great!", false)
                    ]).write();
                string expected = @"sequenceDiagram
    Alice->>+John: Hello John, how are you?
    Alice->>+John: John, can you hear me?
    John-->>-Alice: Hi Alice, I can hear you!
    John-->>-Alice: I feel great!
";
                Assert.Equal(expected, actual);
            }
            [Fact]
            public void Note()
            {
                (string alice, string john) = ("Alice", "John");
                string actual =
                    siren.sequence([
                        sequence.message(alice, john, "Hello John, how are you?"),
                        sequence.noteSpanning(alice, john, "A typical interaction<br/>But now in two lines", notePosition.over)
                    ]).write();
                string expected = @"sequenceDiagram
    Alice->John: Hello John, how are you?
    note over Alice,John : A typical interaction<br/>But now in two lines
";
                Assert.Equal(expected, actual);
            }
            [Fact]
            public void AltElseOpt()
            {
                string actual =
                    siren.sequence([
                        sequence.messageArrow("Alice", "Bob", "Hello Bob, how are you?"),
                        sequence.alt ("is sick", [
                            sequence.messageArrow("Bob", "Alice", "Not so good :(")
                        ],
                        [
                            // One else condition
                            ("is well", [
                                sequence.messageArrow("Bob", "Alice", "Feeling fresh like a daisy")
                            ])
                        ]),
                        sequence.opt ("Extra response", [
                            sequence.messageArrow("Bob", "Alice", "Thanks for asking")
                        ])
                    ]).write();
                string expected = @"sequenceDiagram
    Alice->>Bob: Hello Bob, how are you?
    alt is sick
        Bob->>Alice: Not so good :(
    else is well
        Bob->>Alice: Feeling fresh like a daisy
    end
    opt Extra response
        Bob->>Alice: Thanks for asking
    end
";
                Assert.Equal(expected, actual);
            }
            [Fact]
            public void Parallel()
            {
                string actual =
                    siren.sequence([
                        sequence.par (
                            "Alice to Bob", 
                            [sequence.messageArrow("Alice", "Bob", "Hello guys!")], 
                            [
                                ("Alice to John", [
                                    sequence.messageArrow("Alice", "John", "Hello guys!")
                                ]),
                                ("Alice to Fred", [
                                    sequence.messageArrow("Alice", "Fred", "Hello guys!")
                                ])
                            ]
                        ),
                        sequence.messageDottedArrow("Bob", "Alice", "Hi Alice!"),
                        sequence.messageDottedArrow("John", "Alice", "Hi Alice!"),
                        sequence.messageDottedArrow("Fred", "Alice", "Hi Alice!")
                    ]).write();
                string expected = @"sequenceDiagram
    par Alice to Bob
        Alice->>Bob: Hello guys!
    and Alice to John
        Alice->>John: Hello guys!
    and Alice to Fred
        Alice->>Fred: Hello guys!
    end
    Bob-->>Alice: Hi Alice!
    John-->>Alice: Hi Alice!
    Fred-->>Alice: Hi Alice!
";
                Assert.Equal(expected, actual);
            }
            [Fact]
            public void AutonumberLoop()
            {
                (string alice, string john, string bob) = ("Alice", "John", "Bob");
                string actual =
                    siren.sequence([
                        sequence.autoNumber,
                        sequence.messageArrow(alice, john, "Hello John, how are you?"),
                        sequence.loop("HealthCheck", [
                            sequence.messageArrow(john, john, "Fight against hypochondria")
                        ]),
                        sequence.note(john, "Rational thoughts!", notePosition.rightOf),
                        sequence.messageDottedArrow(john, alice, "Great!"),
                        sequence.messageArrow(john, bob, "How about you?"),
                        sequence.messageDottedArrow(bob, john, "Jolly good!")
                    ]).write();
                string expected = @"sequenceDiagram
    autonumber
    Alice->>John: Hello John, how are you?
    loop HealthCheck
        John->>John: Fight against hypochondria
    end
    note right of John : Rational thoughts!
    John-->>Alice: Great!
    John->>Bob: How about you?
    Bob-->>John: Jolly good!
";
                Assert.Equal(expected, actual);
            }
            [Fact]
            public void ActorLinks()
            {
                (string alice, string john) = ("Alice", "John");
                string actual =
                    siren.sequence([
                        sequence.participant(alice),
                        sequence.participant(john),
                        sequence.link(alice, "Dashboard", "https://dashboard.contoso.com/alice"),
                        sequence.link(alice, "Wiki", "https://wiki.contoso.com/alice"),
                        sequence.link(john, "Dashboard", "https://dashboard.contoso.com/john"),
                        sequence.link(john, "Wiki", "https://wiki.contoso.com/john"),
                        sequence.messageArrow( alice, john, "Hello John, how are you?")
                    ]).write();
                string expected = @"sequenceDiagram
    participant Alice
    participant John
    link Alice: Dashboard @ https://dashboard.contoso.com/alice
    link Alice: Wiki @ https://wiki.contoso.com/alice
    link John: Dashboard @ https://dashboard.contoso.com/john
    link John: Wiki @ https://wiki.contoso.com/john
    Alice->>John: Hello John, how are you?
";
                Assert.Equal(expected, actual);
            }
        }
        [Fact]
        public void CompletenessTest()
        {
            Type csharpType = typeof(Siren.Sea.sequence);
            Type fsharpType = typeof(Siren.sequence);
            Utils.CompareClasses(csharpType, fsharpType);
        }
    }
}