from siren.index import siren, state_diagram, direction, formatting

class Teststate_diagram:

    def test_simple(self):
        Still, Moving, Crash = "Still", "Moving", "Crash"
        actual: str = (
            siren.state_v2([
                state_diagram.transition_start(Still),
                state_diagram.transition_end(Still),
                state_diagram.transition(Still, Moving),
                state_diagram.transition(Moving, Still),
                state_diagram.transition(Moving, Crash),
                state_diagram.transition_end(Crash)
            ])
              .with_title("Simple sample")
              .write()
        )
        expected = """---
title: Simple sample
---
stateDiagram-v2
    [*] --> Still
    Still --> [*]
    Still --> Moving
    Moving --> Still
    Moving --> Crash
    Crash --> [*]
"""
        assert actual == expected

    def test_composite(self):
        First, Second, second, Third, third =  "First", "Second", "second", "Third", "third"
        actual: str = (
            siren.state_v2([
                state_diagram.transition (state_diagram.start_end(), First),
                state_diagram.state_composite(First, [
                    state_diagram.transition(state_diagram.start_end(), Second),

                    state_diagram.state_composite(Second, [
                        state_diagram.transition(state_diagram.start_end(), second),
                        state_diagram.transition(second, Third),

                        state_diagram.state_composite(Third, [
                            state_diagram.transition(state_diagram.start_end(), third),
                            state_diagram.transition(third, state_diagram.start_end())
                        ])
                    ])
                ])
            ])
              .write()
        )
        expected = """stateDiagram-v2
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
        assert actual == expected
    def test_choice(self):
        if_state, isPositive = "if_state", "IsPositive"
        actual: str = (
            siren.state_v2([
                state_diagram.state_choice(if_state),
                state_diagram.transition(state_diagram.start_end(), isPositive),
                state_diagram.transition(isPositive, if_state),
                state_diagram.transition(if_state, "False", "if n < 0"),
                state_diagram.transition(if_state, "True", "if n >= 0")
            ]).write()
        )
        expected = """stateDiagram-v2
    state if_state <<choice>>
    [*] --> IsPositive
    IsPositive --> if_state
    if_state --> False : if n < 0
    if_state --> True : if n >= 0
"""
        assert actual == expected
    def test_fork(self):
        fork_state, join_state, State2, State3, State4 = "fork_state", "join_state", "State2", "State3", "State4"
        actual: str = (
            siren.state_v2([
                state_diagram.state_fork(fork_state),
                state_diagram.transition(state_diagram.start_end(), fork_state),
                state_diagram.transition(fork_state, State2),
                state_diagram.transition(fork_state, State3),
                state_diagram.state_join(join_state),
                state_diagram.transition(State2, join_state),
                state_diagram.transition(State3, join_state),
                state_diagram.transition(join_state, State4),
                state_diagram.transition(State4, state_diagram.start_end())
            ]).write()
        )
        expected = """stateDiagram-v2
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
        assert actual == expected
    def test_concurrency(self):
        Active, NumLockOff, NumLockOn, CapsLockOff, CapsLockOn, ScrollLockOff, ScrollLockOn = (
          "Active", "NumLockOff", "NumLockOn", "CapsLockOff", "CapsLockOn", "ScrollLockOff", "ScrollLockOn"
        )
        EvNumLockPressed = "EvNumLockPressed"
        EvCapsLockPressed = "EvCapsLockPressed"
        EvScrollLockPressed = "EvScrollLockPressed"
        actual: str = (
            siren.state([
                state_diagram.transition_start(Active),
                state_diagram.state_composite(Active, [
                    state_diagram.transition_start(NumLockOff),
                    state_diagram.transition(NumLockOff, NumLockOn, EvNumLockPressed),
                    state_diagram.transition(NumLockOn, NumLockOff, EvNumLockPressed),
                    state_diagram.concurrency(),
                    state_diagram.transition_start(CapsLockOff),
                    state_diagram.transition(CapsLockOff, CapsLockOn, EvCapsLockPressed),
                    state_diagram.transition(CapsLockOn, CapsLockOff, EvCapsLockPressed),
                    state_diagram.concurrency(),
                    state_diagram.transition_start(ScrollLockOff),
                    state_diagram.transition(ScrollLockOff, ScrollLockOn, EvScrollLockPressed),
                    state_diagram.transition(ScrollLockOn, ScrollLockOff, EvScrollLockPressed)
                ])
            ]).write()
        )
        expected = """stateDiagram
    [*] --> Active
    state Active {
        [*] --> NumLockOff
        NumLockOff --> NumLockOn : EvNumLockPressed
        NumLockOn --> NumLockOff : EvNumLockPressed
        --
        [*] --> CapsLockOff
        CapsLockOff --> CapsLockOn : EvCapsLockPressed
        CapsLockOn --> CapsLockOff : EvCapsLockPressed
        --
        [*] --> ScrollLockOff
        ScrollLockOff --> ScrollLockOn : EvScrollLockPressed
        ScrollLockOn --> ScrollLockOff : EvScrollLockPressed
    }
"""
        assert actual == expected
    def test_direction(self):
        A, B, C, D, a, b = (
          "A", "B", "C", "D", "a", "b"
        )
        actual: str = (
            siren.state([
                state_diagram.direction(direction.tb()),
                state_diagram.transition_start(A),
                state_diagram.transition(A,B),
                state_diagram.transition(B,C),
                state_diagram.state_composite(B, [
                    state_diagram.direction(direction.lr()),
                    state_diagram.transition(a,b)
                ]),
                state_diagram.transition(B,D)
            ]).write()
        )
        expected = """stateDiagram
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
        assert actual == expected
    def test_comment(self):
        A, B, C, D, a, b = (
          "A", "B", "C", "D", "a", "b"
        )
        actual: str = (
            siren.state([
                state_diagram.direction(direction.tb()),
                state_diagram.transition_start(A),
                state_diagram.comment("This is a comment"),
                state_diagram.transition(A,B),
                state_diagram.transition(B,C),
                state_diagram.state_composite(B, [
                    state_diagram.direction(direction.lr()),
                    state_diagram.transition(a,b + " " + formatting.comment("This is still a comment"))
                ]),
                state_diagram.transition(B,D)
            ]).write()
        )
        expected = """stateDiagram
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
        assert actual == expected