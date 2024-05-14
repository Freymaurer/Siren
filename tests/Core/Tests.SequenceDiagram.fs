module Tests.SequenceDiagram

open Fable.Pyxpecto
open Siren

let private tests_formatter = testList "Formatter" [
    testCase "empty" <| fun _ ->
        let actual = 
            siren.sequence [] 
            |> siren.write
        let expected = """sequenceDiagram
"""
        Expect.trimEqual actual expected ""
    testCase "parallel-nested" <| fun _ ->
        let actual = 
            siren.sequence [
                sequence.par ("Alice to Bob", [
                    sequence.messageArrow("Alice", "Bob", "Go help John")
                ], [
                    "Alice to John", [
                        sequence.messageArrow("Alice", "John", "I want this done today")
                        sequence.par ("John to Charlie", [
                            sequence.messageArrow("John", "Charlie", "Can we do this today?")
                        ], [
                            "John to Diana", [
                                sequence.messageArrow("John", "Diana", "Can you help us today?")
                            ]
                        ])
                    ]
                ])
            ] 
            |> siren.write
        let expected = """sequenceDiagram
    par Alice to Bob
        Alice->>Bob: Go help John
    and Alice to John
        Alice->>John: I want this done today
        par John to Charlie
            John->>Charlie: Can we do this today?
        and John to Diana
            John->>Diana: Can you help us today?
        end
    end
"""
        Expect.trimEqual actual expected ""

    testCase "critical-option" <| fun _ ->
        let actual =
            siren.sequence [
                sequence.critical("Establish a connection to the DB", [
                    sequence.messageDotted("Service", "DB", "connect")
                ], [
                    "Network timeout", [
                        sequence.messageDotted("Service", "Service", "Log error")
                    ]
                    "Credentials rejected", [
                        sequence.messageDotted("Service", "Service", "Log different error")
                    ]
                ])
            ]
            |> siren.write
        let expected = """sequenceDiagram
    critical Establish a connection to the DB
        Service-->DB: connect
    option Network timeout
        Service-->Service: Log error
    option Credentials rejected
        Service-->Service: Log different error
    end
"""
        Expect.trimEqual actual expected ""

    testCase "break" <| fun _ ->
        let actual =
            siren.sequence [
                sequence.messageDotted("Consumer", "API", "Book something")
                sequence.messageDotted("API", "BookingService", "Start booking process")
                sequence.breakSeq ("when the booking process fails", [
                    sequence.messageDotted("API", "Consumer", "show failure")
                ])
                sequence.messageDotted("API", "BillingService", "Start billing process")
            ]
            |> siren.write
        let expected = """sequenceDiagram
    Consumer-->API: Book something
    API-->BookingService: Start booking process
    break when the booking process fails
        API-->Consumer: show failure
    end
    API-->BillingService: Start billing process
"""
        Expect.trimEqual actual expected ""

    testCase "rect" <| fun _ ->
        let actual =
            siren.sequence [
                sequence.participant "Alice"
                sequence.participant "John"
                sequence.rect ("rgb(191, 223, 255)", [
                    sequence.note("Alice","Alice calls John.")
                    sequence.messageArrow("Alice", "John", "Hello John, how are you?", true)
                    sequence.rect ("rgb(200, 150, 255)", [
                        sequence.messageArrow("Alice", "John", "John, can you hear me?", true)
                        sequence.messageDottedArrow("John", "Alice", "Hi Alice, I can hear you!", false)
                    ])
                    sequence.messageDottedArrow("John", "Alice", "I feel great!", false)
                ])
                sequence.messageArrow("Alice", "John", "Did you want to go to the game tonight?", true)
                sequence.messageDottedArrow("John", "Alice", "Yeah! See you there.", false)
            ]
            |> siren.write
        let expected = """sequenceDiagram
    participant Alice
    participant John
    rect rgb(191, 223, 255)
        note right of Alice : Alice calls John.
        Alice->>+John: Hello John, how are you?
        rect rgb(200, 150, 255)
            Alice->>+John: John, can you hear me?
            John-->>-Alice: Hi Alice, I can hear you!
        end
        John-->>-Alice: I feel great!
    end
    Alice->>+John: Did you want to go to the game tonight?
    John-->>-Alice: Yeah! See you there.
"""
        Expect.trimEqual actual expected ""
    testCase "comment" <| fun _ ->
        let actual = 
            siren.sequence [
                sequence.messageArrow("Alice", "John", "Hello John, how are you?")
                sequence.comment "This is a comment"
                sequence.messageDottedArrow("John", "Alice", "Great!")
            ]
            |> siren.write
        let expected = """sequenceDiagram
    Alice->>John: Hello John, how are you?
    %% This is a comment
    John-->>Alice: Great!
"""
        Expect.trimEqual actual expected ""
    testCase "actor-links" <| fun _ ->
        let actual = 
            siren.sequence [
                sequence.participant "Alice"
                sequence.participant "John"
                sequence.links("Alice", ["Dashboard", "https://dashboard.contoso.com/alice"; "Wiki", "https://wiki.contoso.com/alice"])
                sequence.links("John", ["Dashboard", "https://dashboard.contoso.com/john"; "Wiki", "https://wiki.contoso.com/john"])
                sequence.messageArrow( "Alice",  "John", "Hello John, how are you?")
            ]
            |> siren.write
        let expected = """sequenceDiagram
    participant Alice
    participant John
    links Alice: {"Dashboard": "https://dashboard.contoso.com/alice", "Wiki": "https://wiki.contoso.com/alice"}
    links John: {"Dashboard": "https://dashboard.contoso.com/john", "Wiki": "https://wiki.contoso.com/john"}
    Alice->>John: Hello John, how are you?
"""
        Expect.trimEqual actual expected ""
]


let private tests_docs = testList "docs" [
    testCase "simple" <| fun _ ->
        let actual = 
            siren.sequence [
                sequence.messageArrow( "Alice",  "John", "Hello John, how are you?")
                sequence.messageDottedArrow( "John",  "Alice", "Great!")
                sequence.messageOpenArrow( "Alice",  "John", "See you later!")
            ]
            |> siren.write
        let expected = """sequenceDiagram
    Alice->>John: Hello John, how are you?
    John-->>Alice: Great!
    Alice-)John: See you later!
"""
        Expect.trimEqual actual expected ""
    testCase "create/destroy" <| fun _ -> 
        let actual = 
            let alice, bob, carl, donald = "Alice", "Bob", "Carl", "D"
            siren.sequence [
                sequence.messageArrow(alice, bob, "Hello Bob, how are you?")
                sequence.messageArrow(bob, alice, "Fine, thank you. And you?")
                sequence.createParticipant carl
                sequence.messageArrow(alice, carl, "Hi Carl!")
                sequence.createActor(donald, "Donald")
                sequence.messageArrow(carl, donald, "Hi!")
                sequence.destroy carl
                sequence.messageCross(alice, carl, "We are too many")
                sequence.destroy bob
                sequence.messageArrow(bob, alice, "I agree")
            ]
            |> siren.write
        let expected = """sequenceDiagram
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
"""
        Expect.trimEqual actual expected ""
    testCase "nested activation" <| fun _ -> 
        let actual = 
            let alice, john = "Alice", "John"
            siren.sequence [
                sequence.messageArrow(alice, john, "Hello John, how are you?", true)
                sequence.messageArrow(alice, john, "John, can you hear me?", true)
                sequence.messageDottedArrow(john, alice, "Hi Alice, I can hear you!", false)
                sequence.messageDottedArrow(john, alice, "I feel great!", false)
            ]
            |> siren.write
        let expected = """sequenceDiagram
    Alice->>+John: Hello John, how are you?
    Alice->>+John: John, can you hear me?
    John-->>-Alice: Hi Alice, I can hear you!
    John-->>-Alice: I feel great!
"""
        Expect.trimEqual actual expected ""
    testCase "note" <| fun _ ->
        let actual = 
            let alice, john = "Alice", "John"
            siren.sequence [
                sequence.message(alice, john, "Hello John, how are you?")
                sequence.noteSpanning(alice, john, "A typical interaction<br/>But now in two lines", notePosition.over)
            ]
            |> siren.write
        let expected = """sequenceDiagram
    Alice->John: Hello John, how are you?
    note over Alice,John : A typical interaction<br/>But now in two lines
"""
        Expect.trimEqual actual expected ""
    testCase "alt-else-opt" <| fun _ ->
        let actual = 
            siren.sequence [
                sequence.messageArrow("Alice", "Bob", "Hello Bob, how are you?")
                sequence.alt ("is sick", [
                    sequence.messageArrow("Bob", "Alice", "Not so good :(")
                ], 
                [
                    // One else condition
                    "is well", [
                        sequence.messageArrow("Bob", "Alice", "Feeling fresh like a daisy")
                    ]
                ])
                sequence.opt ("Extra response", [
                    sequence.messageArrow("Bob", "Alice", "Thanks for asking")
                ])
            ] 
            |> siren.write
        let expected = """sequenceDiagram
    Alice->>Bob: Hello Bob, how are you?
    alt is sick
        Bob->>Alice: Not so good :(
    else is well
        Bob->>Alice: Feeling fresh like a daisy
    end
    opt Extra response
        Bob->>Alice: Thanks for asking
    end
"""
        Expect.trimEqual actual expected ""
    testCase "parallel" <| fun _ ->
        let actual = 
            siren.sequence [
                sequence.par ("Alice to Bob", [
                        sequence.messageArrow("Alice", "Bob", "Hello guys!")
                ], [
                    "Alice to John", [
                        sequence.messageArrow("Alice", "John", "Hello guys!")
                    ]
                    "Alice to Fred", [
                        sequence.messageArrow("Alice", "Fred", "Hello guys!")
                    ]
                ])
                sequence.messageDottedArrow("Bob", "Alice", "Hi Alice!")
                sequence.messageDottedArrow("John", "Alice", "Hi Alice!")
                sequence.messageDottedArrow("Fred", "Alice", "Hi Alice!")
            ] 
            |> siren.write
        let expected = """sequenceDiagram
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
"""
        Expect.trimEqual actual expected ""
    testCase "autonumber-loop" <| fun _ ->
        let actual = 
            let alice, john, bob = "Alice", "John", "Bob"
            siren.sequence [
                sequence.autoNumber
                sequence.messageArrow(alice, john, "Hello John, how are you?")
                sequence.loop("HealthCheck", [
                    sequence.messageArrow(john, john, "Fight against hypochondria")
                ])
                sequence.note(john, "Rational thoughts!", notePosition.rightOf)
                sequence.messageDottedArrow(john, alice, "Great!")
                sequence.messageArrow(john, bob, "How about you?")
                sequence.messageDottedArrow(bob, john, "Jolly good!")
            ] 
            |> siren.write
        let expected = """sequenceDiagram
    autonumber
    Alice->>John: Hello John, how are you?
    loop HealthCheck
        John->>John: Fight against hypochondria
    end
    note right of John : Rational thoughts!
    John-->>Alice: Great!
    John->>Bob: How about you?
    Bob-->>John: Jolly good!
"""
        Expect.trimEqual actual expected ""
    testCase "actor-links" <| fun _ ->
        let actual = 
            siren.sequence [
                sequence.participant "Alice"
                sequence.participant "John"
                sequence.link("Alice", "Dashboard", "https://dashboard.contoso.com/alice")
                sequence.link("Alice", "Wiki", "https://wiki.contoso.com/alice")
                sequence.link("John", "Dashboard", "https://dashboard.contoso.com/john")
                sequence.link("John", "Wiki", "https://wiki.contoso.com/john")
                sequence.messageArrow( "Alice",  "John", "Hello John, how are you?")
            ]
            |> siren.write
        let expected = """sequenceDiagram
    participant Alice
    participant John
    link Alice: Dashboard @ https://dashboard.contoso.com/alice
    link Alice: Wiki @ https://wiki.contoso.com/alice
    link John: Dashboard @ https://dashboard.contoso.com/john
    link John: Wiki @ https://wiki.contoso.com/john
    Alice->>John: Hello John, how are you?
"""
        Expect.trimEqual actual expected ""
]
let main = testList "SequenceDiagram" [
    tests_formatter
    tests_docs
]
