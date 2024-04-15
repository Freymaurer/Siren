module Tests.SequenceDiagram

open Fable.Pyxpecto
open Siren

let private tests_formatter = testList "Formatter" [
    testCase "empty" <| fun _ ->
        let actual = 
            diagram.sequence [] 
            |> Formatter.writeElementFast
        let expected = """sequenceDiagram
"""
        Expect.stringEqualF actual expected ""
    testCase "alt-else-opt" <| fun _ ->
        let actual = 
            diagram.sequence [
                message.arrow(node.id "Alice", node.id "Bob", "Hello Bob, how are you?")
                subgraph.chain [
                    sequenceDiagram.alt "is sick" [
                        message.arrow(node.id "Bob", node.id "Alice", "Not so good :(")
                    ]
                    sequenceDiagram.else_ "is well" [
                        message.arrow(node.id "Bob", node.id "Alice", "Feeling fresh like a daisy")
                    ]
                ]
                sequenceDiagram.opt "Extra response" [
                    message.arrow(node.id "Bob", node.id "Alice", "Thanks for asking")
                ]
            ] 
            |> Formatter.writeElementFast
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
        Expect.stringEqualF actual expected ""
    testCase "parallel" <| fun _ ->
        let actual = 
            diagram.sequence [
                subgraph.chain [
                    sequenceDiagram.par "Alice to Bob" [
                        message.arrow(node.id "Alice", node.id "Bob", "Hello guys!")
                    ]
                    sequenceDiagram.and_ "Alice to John" [
                        message.arrow(node.id "Alice", node.id "John", "Hello guys!")
                    ]
                    sequenceDiagram.and_ "Alice to Fred" [
                        message.arrow(node.id "Alice", node.id "Fred", "Hello guys!")
                    ]
                ]
                message.dottedArrow(node.id "Bob", node.id "Alice", "Hi Alice!")
                message.dottedArrow(node.id "John", node.id "Alice", "Hi Alice!")
                message.dottedArrow(node.id "Fred", node.id "Alice", "Hi Alice!")
            ] 
            |> Formatter.writeElementFast
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
        Expect.stringEqualF actual expected ""
    testCase "parallel-nested" <| fun _ ->
        let actual = 
            diagram.sequence [
                subgraph.chain [
                    sequenceDiagram.par "Alice to Bob" [
                        message.arrow(node.id "Alice", node.id "Bob", "Go help John")
                    ]
                    sequenceDiagram.and_ "Alice to John" [
                        message.arrow(node.id "Alice", node.id "John", "I want this done today")
                        subgraph.chain [
                            sequenceDiagram.par "John to Charlie" [
                                message.arrow(node.id "John", node.id "Charlie", "Can we do this today?")
                            ]
                            sequenceDiagram.and_ "John to Diana" [
                                message.arrow(node.id "John", node.id "Diana", "Can you help us today?")
                            ]
                        ]
                    ]
                ]
            ] 
            |> Formatter.writeElementFast
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
        Expect.stringEqualF actual expected ""

    testCase "critical-option" <| fun _ ->
        let actual =
            diagram.sequence [
                subgraph.chain [
                    sequenceDiagram.critical "Establish a connection to the DB" [
                        message.dotted(node.id "Service", node.id "DB", "connect")
                    ]
                    sequenceDiagram.option "Network timeout" [
                        message.dotted(node.id "Service", node.id "Service", "Log error")
                    ]
                    sequenceDiagram.option "Credentials rejected" [
                        message.dotted(node.id "Service", node.id "Service", "Log different error")
                    ]
                ]
            ]
            |> Formatter.writeElementFast
        let expected = """sequenceDiagram
    critical Establish a connection to the DB
        Service-->DB: connect
    option Network timeout
        Service-->Service: Log error
    option Credentials rejected
        Service-->Service: Log different error
    end
"""
        Expect.stringEqualF actual expected ""

    testCase "break" <| fun _ ->
        let actual =
            diagram.sequence [
                message.dotted(node.id "Consumer", node.id "API", "Book something")
                message.dotted(node.id "API", node.id "BookingService", "Start booking process")
                sequenceDiagram.break_ "when the booking process fails" [
                    message.dotted(node.id "API", node.id "Consumer", "show failure")
                ]
                message.dotted(node.id "API", node.id "BillingService", "Start billing process")
            ]
            |> Formatter.writeElementFast
        let expected = """sequenceDiagram
    Consumer-->API: Book something
    API-->BookingService: Start booking process
    break when the booking process fails
        API-->Consumer: show failure
    end
    API-->BillingService: Start billing process
"""
        Expect.stringEqualF actual expected ""

    testCase "rect" <| fun _ ->
        let actual =
            diagram.sequence [
                sequenceDiagram.participant "Alice"
                sequenceDiagram.participant "John"
                sequenceDiagram.rect "rgb(191, 223, 255)" [
                    sequenceDiagram.note("Alice",notePosition.rightOf,"Alice calls John.")
                    message.arrow(node.id "Alice", node.id "John", "Hello John, how are you?", true)
                    sequenceDiagram.rect "rgb(200, 150, 255)" [
                        message.arrow(node.id "Alice", node.id "John", "John, can you hear me?", true)
                        message.dottedArrow(node.id "John", node.id "Alice", "Hi Alice, I can hear you!", false)
                    ]
                    message.dottedArrow(node.id "John", node.id "Alice", "I feel great!", false)
                ]
                message.arrow(node.id "Alice", node.id "John", "Did you want to go to the game tonight?", true)
                message.dottedArrow(node.id "John", node.id "Alice", "Yeah! See you there.", false)
            ]
            |> Formatter.writeElementFast
        let expected = """sequenceDiagram
    participant Alice
    participant John
    rect rgb(191, 223, 255)
        note right of Alice: Alice calls John.
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
        Expect.stringEqualF actual expected ""
    testCase "comment" <| fun _ ->
        let actual = 
            diagram.sequence [
                message.arrow(node.id "Alice", node.id "John", "Hello John, how are you?")
                comment.comment "This is a comment"
                message.dottedArrow(node.id "John", node.id "Alice", "Great!")
            ]
            |> Formatter.writeElementFast
        let expected = """sequenceDiagram
    Alice->>John: Hello John, how are you?
    %% This is a comment
    John-->>Alice: Great!
"""
        Expect.stringEqualF actual expected ""
    testCase "actor-links" <| fun _ ->
        let actual = 
            diagram.sequence [
                sequenceDiagram.participant "Alice"
                sequenceDiagram.participant "John"
                sequenceDiagram.link("Alice", "Dashboard", "https://dashboard.contoso.com/alice")
                sequenceDiagram.link("Alice", "Wiki", "https://wiki.contoso.com/alice")
                sequenceDiagram.link("John", "Dashboard", "https://dashboard.contoso.com/john")
                sequenceDiagram.link("John", "Wiki", "https://wiki.contoso.com/john")
                message.arrow(node.id "Alice", node.id "John", "Hello John, how are you?")
            ]
            |> Formatter.writeElementFast
        let expected = """sequenceDiagram
    participant Alice
    participant John
    link Alice: Dashboard @ https://dashboard.contoso.com/alice
    link Alice: Wiki @ https://wiki.contoso.com/alice
    link John: Dashboard @ https://dashboard.contoso.com/john
    link John: Wiki @ https://wiki.contoso.com/john
    Alice->>John: Hello John, how are you?
"""
        Expect.stringEqualF actual expected ""
    testCase "actor-links" <| fun _ ->
        let actual = 
            diagram.sequence [
                sequenceDiagram.participant "Alice"
                sequenceDiagram.participant "John"
                sequenceDiagram.links("Alice", ["Dashboard", "https://dashboard.contoso.com/alice"; "Wiki", "https://wiki.contoso.com/alice"])
                sequenceDiagram.links("John", ["Dashboard", "https://dashboard.contoso.com/john"; "Wiki", "https://wiki.contoso.com/john"])
                message.arrow(node.id "Alice", node.id "John", "Hello John, how are you?")
            ]
            |> Formatter.writeElementFast
        let expected = """sequenceDiagram
    participant Alice
    participant John
    links Alice: {"Dashboard": "https://dashboard.contoso.com/alice", "Wiki": "https://wiki.contoso.com/alice"}
    links John: {"Dashboard": "https://dashboard.contoso.com/john", "Wiki": "https://wiki.contoso.com/john"}
    Alice->>John: Hello John, how are you?
"""
        Expect.stringEqualF actual expected ""
]

let main = testList "SequenceDiagram" [
    tests_formatter
]
