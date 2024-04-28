module Tests.StateDiagram

open Fable.Pyxpecto
open Siren

let private tests_state = testList "state" [
    testCase "simple" <| fun _ ->
        let actual =
            siren.state [
                stateDiagram.state "Still"
            ]
            |> siren.write
        let expected = """stateDiagram
    Still
"""
        Expect.trimEqual actual expected ""

    testCase "composite" <| fun _ ->
        let actual =
            let first, second = "First", "second"
            siren.state [
                stateDiagram.transition (stateDiagram.startEnd,first)
                stateDiagram.stateComposite(first, [
                    stateDiagram.transition(stateDiagram.startEnd, second)
                    stateDiagram.transition(second, stateDiagram.startEnd)
                ])
            ]
            |> siren.write
        let expected = """stateDiagram
    [*] --> First
    state First {
        [*] --> second
        second --> [*]
    }
"""
        Expect.trimEqual actual expected ""
    testCase "composite-nested" <| fun _ ->
        let actual =
            let First, Second, second, Third, third = "First", "Second", "second", "Third", "third"
            siren.stateV2 [
                stateDiagram.transition (stateDiagram.startEnd,First)
                stateDiagram.stateComposite(First, [
                    stateDiagram.transition(stateDiagram.startEnd, Second)

                    stateDiagram.stateComposite(Second, [
                        stateDiagram.transition(stateDiagram.startEnd, second)
                        stateDiagram.transition(second, Third)

                        stateDiagram.stateComposite(Third, [
                            stateDiagram.transition(stateDiagram.startEnd, third)
                            stateDiagram.transition(third, stateDiagram.startEnd)
                        ])
                    ])
                ])
            ]
            |> siren.write
        let expected = """stateDiagram-v2
    [*] --> First
    state First {
        [*] --> Second
        state Second {
            [*] --> second
            second --> Third
            state Third {
                [*] --> third
                third --> [*]
            }
        }
    }
"""
        Expect.trimEqual actual expected ""

    testCase "choice" <| fun _ ->
        let actual =
            let if_state, isPositive = "if_state", "IsPositive"
            siren.stateV2 [
                stateDiagram.stateChoice if_state
                stateDiagram.transition(stateDiagram.startEnd, isPositive)
                stateDiagram.transition(isPositive, if_state)
                stateDiagram.transition(if_state, "False", "if n < 0")
                stateDiagram.transition(if_state, "True", "if n >= 0")
            ]
            |> siren.write
        let expected = """stateDiagram-v2
    state if_state <<choice>>
    [*] --> IsPositive
    IsPositive --> if_state
    if_state --> False : if n < 0
    if_state --> True : if n >= 0
"""
        Expect.trimEqual actual expected ""
    testCase "fork" <| fun _ ->
        let actual =
            let fork_state, join_state, State2, State3, State4 = "fork_state", "join_state", "State2", "State3", "State4"
            siren.stateV2 [
                stateDiagram.stateFork fork_state
                stateDiagram.transition(stateDiagram.startEnd, fork_state)
                stateDiagram.transition(fork_state, State2)
                stateDiagram.transition(fork_state, State3)
                stateDiagram.stateJoin join_state
                stateDiagram.transition(State2, join_state)
                stateDiagram.transition(State3, join_state)
                stateDiagram.transition(join_state, State4)
                stateDiagram.transition(State4, stateDiagram.startEnd)
            ]
            |> siren.write
        let expected = """   stateDiagram-v2
    state fork_state <<fork>>
    [*] --> fork_state
    fork_state --> State2
    fork_state --> State3
    state join_state <<join>>
    State2 --> join_state
    State3 --> join_state
    join_state --> State4
    State4 --> [*]
"""
        Expect.trimEqual actual expected ""
] 

let private tests_transition = testList "transition" [
    testCase "transitionStart/End" <| fun _ ->
        let actual =
            let first, second = "First", "second"
            siren.state [
                stateDiagram.transitionStart (first)
                stateDiagram.stateComposite(first, [
                    stateDiagram.transitionStart(second)
                    stateDiagram.transitionEnd(second)
                ])
            ]
            |> siren.write
        let expected = """stateDiagram
    [*] --> First
    state First {
        [*] --> second
        second --> [*]
    }
"""
        Expect.trimEqual actual expected ""
]

let private tests_note = testList "note" [
    testCase "transitionStart/End" <| fun _ ->
        let actual =
            let State1, State2 = "State1", "State2"
            siren.state [
                stateDiagram.state (State1, "The state with a note")
                stateDiagram.note (State1, "Important information! You can write \nnotes.", notePosition.leftOf)
                stateDiagram.noteMultiLine (State1, ["Important information! You can write";"notes."])
                stateDiagram.noteLine (State1, "This is the note to the left.", notePosition.leftOf)
            ]
            |> siren.write
        let expected = """stateDiagram
    State1 : The state with a note
    note left of State1
        Important information! You can write 
        notes.
    end note
    note right of State1
        Important information! You can write
        notes.
    end note
    note left of State1 : This is the note to the left.
"""
        Expect.trimEqual actual expected ""
]

let private tests_concurrency = testList "Concurrency" [
    testCase "docs" <| fun _ ->
        let actual =
            let Active, NumLockOff, NumLockOn, CapsLockOff, CapsLockOn = "Active", "NumLockOff", "NumLockOn", "CapsLockOff", "CapsLockOn"
            let EvNumLockPressed = "EvNumLockPressed"
            let EvCapsLockPressed = "EvCapsLockPressed"
            siren.state [
                stateDiagram.transitionStart(Active)
                stateDiagram.stateComposite(Active, [
                    stateDiagram.transitionStart(NumLockOff)
                    stateDiagram.transition(NumLockOff, NumLockOn, EvNumLockPressed)
                    stateDiagram.transition(NumLockOn, NumLockOff, EvNumLockPressed)
                    stateDiagram.concurrency
                    stateDiagram.transitionStart(CapsLockOff)
                    stateDiagram.transition(CapsLockOff, CapsLockOn, EvCapsLockPressed)
                    stateDiagram.transition(CapsLockOn, CapsLockOff, EvCapsLockPressed)
                ])
            ]
            |> siren.write
        let expected = """stateDiagram
    [*] --> Active
    state Active {
        [*] --> NumLockOff
        NumLockOff --> NumLockOn : EvNumLockPressed
        NumLockOn --> NumLockOff : EvNumLockPressed
        --
        [*] --> CapsLockOff
        CapsLockOff --> CapsLockOn : EvCapsLockPressed
        CapsLockOn --> CapsLockOff : EvCapsLockPressed
    }
"""
        Expect.trimEqual actual expected ""
]

let private tests_direction = testList "direction" [
    testCase "docs" <| fun _ ->
        let actual =
            let A, B, C, D, a, b = "A", "B", "C", "D", "a", "b"
            siren.state [
                stateDiagram.direction direction.tb
                stateDiagram.transitionStart(A)
                stateDiagram.transition(A,B)
                stateDiagram.transition(B,C)
                stateDiagram.stateComposite(B, [
                    stateDiagram.direction direction.lr
                    stateDiagram.transition(a,b)
                ])
                stateDiagram.transition(B,D)
            ]
            |> siren.write
        let expected = """stateDiagram
    direction TB
    [*] --> A
    A --> B
    B --> C
    state B {
        direction LR
        a --> b
    }
    B --> D
"""
        Expect.trimEqual actual expected ""
]

let private tests_comment = testList "comment" [
    testCase "docs" <| fun _ ->
        let actual =
            let A, B, C, D, a, b = "A", "B", "C", "D", "a", "b"
            siren.state [
                stateDiagram.direction direction.tb
                stateDiagram.transitionStart(A)
                stateDiagram.comment "This is a comment"
                stateDiagram.transition(A,B)
                stateDiagram.transition(B,C)
                stateDiagram.stateComposite(B, [
                    stateDiagram.direction direction.lr
                    stateDiagram.transition(a,b + " " + formatting.comment "This is still a comment")
                ])
                stateDiagram.transition(B,D)
            ]
            |> siren.write
        let expected = """stateDiagram
    direction TB
    [*] --> A
    %% This is a comment
    A --> B
    B --> C
    state B {
        direction LR
        a --> b %% This is still a comment
    }
    B --> D
"""
        Expect.trimEqual actual expected ""
]

let main = testList "StateDiagram" [
    tests_state
    tests_transition
    tests_note
    tests_concurrency
    tests_direction
    tests_comment
]

