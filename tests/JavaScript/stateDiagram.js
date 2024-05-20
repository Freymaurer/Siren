import {siren, stateDiagram, direction, formatting } from "./siren/index.js"
import * as assert from "assert"

describe('stateDiagram', function(){
    it('Simple', function(){
        let [Still, Moving, Crash] = ["Still", "Moving", "Crash"] 
        const actual = 
            siren.stateV2([
                stateDiagram.transitionStart(Still),
                stateDiagram.transitionEnd(Still),
                stateDiagram.transition(Still, Moving),
                stateDiagram.transition(Moving, Still),
                stateDiagram.transition(Moving, Crash),
                stateDiagram.transitionEnd(Crash)
            ]).withTitle("Simple sample").write();
        const expected = `---
title: Simple sample
---
stateDiagram-v2
    [*] --> Still
    Still --> [*]
    Still --> Moving
    Moving --> Still
    Moving --> Crash
    Crash --> [*]
`
        assert.equal(actual,expected,"This should be equal")
    });
    it('composite-nested', function(){
        let [First, Second, second, Third, third] = ["First", "Second", "second", "Third", "third"] 
        const actual = 
            siren.stateV2([
                stateDiagram.transition (stateDiagram.startEnd,First),
                stateDiagram.stateComposite(First, [
                    stateDiagram.transition(stateDiagram.startEnd, Second),
                
                    stateDiagram.stateComposite(Second, [
                        stateDiagram.transition(stateDiagram.startEnd, second),
                        stateDiagram.transition(second, Third),
                
                        stateDiagram.stateComposite(Third, [
                            stateDiagram.transition(stateDiagram.startEnd, third),
                            stateDiagram.transition(third, stateDiagram.startEnd)
                        ])
                    ])
                ])
            ]).write();
        const expected = `stateDiagram-v2
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
`
        assert.equal(actual,expected,"This should be equal")
    });
    it('choice', function(){
        let [if_state, isPositive] = ["if_state", "IsPositive"] 
        const actual = 
            siren.stateV2([
                stateDiagram.stateChoice(if_state),
                stateDiagram.transition(stateDiagram.startEnd, isPositive),
                stateDiagram.transition(isPositive, if_state),
                stateDiagram.transition(if_state, "False", "if n < 0"),
                stateDiagram.transition(if_state, "True", "if n >= 0")
            ]).write();
        const expected = `stateDiagram-v2
    state if_state <<choice>>
    [*] --> IsPositive
    IsPositive --> if_state
    if_state --> False : if n < 0
    if_state --> True : if n >= 0
`
        assert.equal(actual,expected,"This should be equal")
    });
    it('fork', function(){
        let [fork_state, join_state, State2, State3, State4] = ["fork_state", "join_state", "State2", "State3", "State4"] 
        const actual = 
            siren.stateV2([
                stateDiagram.stateFork(fork_state),
                stateDiagram.transition(stateDiagram.startEnd, fork_state),
                stateDiagram.transition(fork_state, State2),
                stateDiagram.transition(fork_state, State3),
                stateDiagram.stateJoin(join_state),
                stateDiagram.transition(State2, join_state),
                stateDiagram.transition(State3, join_state),
                stateDiagram.transition(join_state, State4),
                stateDiagram.transition(State4, stateDiagram.startEnd)
            ]).write();
        const expected = `stateDiagram-v2
    state fork_state <<fork>>
    [*] --> fork_state
    fork_state --> State2
    fork_state --> State3
    state join_state <<join>>
    State2 --> join_state
    State3 --> join_state
    join_state --> State4
    State4 --> [*]
`
        assert.equal(actual,expected,"This should be equal")
    });
    it('fork', function(){
        let [Active, NumLockOff, NumLockOn, CapsLockOff, CapsLockOn, ScrollLockOff, ScrollLockOn] = 
            ["Active", "NumLockOff", "NumLockOn", "CapsLockOff", "CapsLockOn", "ScrollLockOff", "ScrollLockOn"] 
        let EvNumLockPressed = "EvNumLockPressed"
        let EvCapsLockPressed = "EvCapsLockPressed"
        let EvScrollLockPressed = "EvScrollLockPressed"
        const actual = 
            siren.state([
                stateDiagram.transitionStart(Active),
                stateDiagram.stateComposite(Active, [
                    stateDiagram.transitionStart(NumLockOff),
                    stateDiagram.transition(NumLockOff, NumLockOn, EvNumLockPressed),
                    stateDiagram.transition(NumLockOn, NumLockOff, EvNumLockPressed),
                    stateDiagram.concurrency,
                    stateDiagram.transitionStart(CapsLockOff),
                    stateDiagram.transition(CapsLockOff, CapsLockOn, EvCapsLockPressed),
                    stateDiagram.transition(CapsLockOn, CapsLockOff, EvCapsLockPressed),
                    stateDiagram.concurrency,
                    stateDiagram.transitionStart(ScrollLockOff),
                    stateDiagram.transition(ScrollLockOff, ScrollLockOn, EvScrollLockPressed),
                    stateDiagram.transition(ScrollLockOn, ScrollLockOff, EvScrollLockPressed)
                ])
            ]).write();
        const expected = `stateDiagram
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
`
        assert.equal(actual,expected,"This should be equal")
    });
    it('fork', function(){
        let [A, B, C, D, a, b] = ["A", "B", "C", "D", "a", "b"] 
        const actual = 
            siren.state([
                stateDiagram.direction (direction.tb),
                stateDiagram.transitionStart(A),
                stateDiagram.transition(A,B),
                stateDiagram.transition(B,C),
                stateDiagram.stateComposite(B, [
                    stateDiagram.direction(direction.lr),
                    stateDiagram.transition(a,b)
                ]),
                stateDiagram.transition(B,D)
            ]).write();
        const expected = `stateDiagram
    direction TB
    [*] --> A
    A --> B
    B --> C
    state B {
        direction LR
        a --> b
    }
    B --> D
`
        assert.equal(actual,expected,"This should be equal")
    });
    it('comment', function(){
        let [A, B, C, D, a, b] = ["A", "B", "C", "D", "a", "b"] 
        const actual = 
            siren.state([
                stateDiagram.direction (direction.tb),
                stateDiagram.transitionStart(A),
                stateDiagram.comment("This is a comment"),
                stateDiagram.transition(A,B),
                stateDiagram.transition(B,C),
                stateDiagram.stateComposite(B, [
                    stateDiagram.direction(direction.lr),
                    stateDiagram.transition(a,b + " " + formatting.comment("This is still a comment"))
                ]),
                stateDiagram.transition(B,D)
            ]).write();
        const expected = `stateDiagram
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
`
        assert.equal(actual,expected,"This should be equal")
    });
});