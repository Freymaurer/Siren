namespace Siren.Sea.Tests;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siren.Sea;

public class StateDiagramTests
{
    public class DocsTests
    {
        [Fact]
        public void Simple()
        {
            (string Still, string Moving, string Crash) = ("Still", "Moving", "Crash");
            string actual = siren.stateV2([
                stateDiagram.transitionStart(Still),
                stateDiagram.transitionEnd(Still),
                stateDiagram.transition(Still, Moving),
                stateDiagram.transition(Moving, Still),
                stateDiagram.transition(Moving, Crash),
                stateDiagram.transitionEnd(Crash)
                ]).withTitle("Simple sample").write();
            string expected = @"---
title: Simple sample
---
stateDiagram-v2
    [*] --> Still
    Still --> [*]
    Still --> Moving
    Moving --> Still
    Moving --> Crash
    Crash --> [*]
";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CompositeNested()
        {
            (string First, string Second, string second, string Third, string third) = ("First", "Second", "second", "Third", "third");
            string actual = siren.stateV2([
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
            string expected = @"stateDiagram-v2
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
";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Choice()
        {
            (string if_state, string isPositive) = ("if_state", "IsPositive");
            string actual = siren.stateV2([
                stateDiagram.stateChoice(if_state),
                stateDiagram.transition(stateDiagram.startEnd, isPositive),
                stateDiagram.transition(isPositive, if_state),
                stateDiagram.transition(if_state, "False", "if n < 0"),
                stateDiagram.transition(if_state, "True", "if n >= 0")
            ]).write();
            string expected = @"stateDiagram-v2
    state if_state <<choice>>
    [*] --> IsPositive
    IsPositive --> if_state
    if_state --> False : if n < 0
    if_state --> True : if n >= 0
";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Forks()
        {
            (string fork_state, string join_state, string State2, string State3, string State4) =
                ("fork_state", "join_state", "State2", "State3", "State4");
            string actual = siren.stateV2
                ([
                    stateDiagram.stateFork(fork_state),
                    stateDiagram.transitionStart(fork_state),
                    stateDiagram.transition(fork_state, State2),
                    stateDiagram.transition(fork_state, State3),
                    stateDiagram.stateJoin(join_state),
                    stateDiagram.transition(State2, join_state),
                    stateDiagram.transition(State3, join_state),
                    stateDiagram.transition(join_state, State4),
                    stateDiagram.transitionEnd(State4)
                ]).write();
            string expected = @"stateDiagram-v2
    state fork_state <<fork>>
    [*] --> fork_state
    fork_state --> State2
    fork_state --> State3
    state join_state <<join>>
    State2 --> join_state
    State3 --> join_state
    join_state --> State4
    State4 --> [*]
";
            Xunit.Assert.Equal(expected, actual);
        }

        [Fact]
        public void Concurrency()
        {
            (string NumLockOff, string NumLockOn, string CapsLockOff, string CapsLockOn, string ScrollLockOff, string ScrollLockOn) = 
                ("NumLockOff", "NumLockOn", "CapsLockOff", "CapsLockOn", "ScrollLockOff", "ScrollLockOn");
            string Active = ("Active");
            string actual = siren.stateV2
                ([
                    stateDiagram.transitionStart(Active),
                    stateDiagram.stateComposite(Active, [
                        stateDiagram.transitionStart(NumLockOff),
                        stateDiagram.transition(NumLockOff, NumLockOn, "EvNumLockPressed"),
                        stateDiagram.transition(NumLockOn, NumLockOff, "EvNumLockPressed"),
                        stateDiagram.concurrency,
                        stateDiagram.transitionStart(CapsLockOff),
                        stateDiagram.transition(CapsLockOff, CapsLockOn, "EvCapsLockPressed"),
                        stateDiagram.transition(CapsLockOn, CapsLockOff, "EvCapsLockPressed"),
                        stateDiagram.concurrency,
                        stateDiagram.transitionStart(ScrollLockOff),
                        stateDiagram.transition(ScrollLockOff, ScrollLockOn, "EvScrollLockPressed"),
                        stateDiagram.transition(ScrollLockOn, ScrollLockOff, "EvScrollLockPressed")
                    ])
                ]).write();
            string expected = @"stateDiagram-v2
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
";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InnerDirection()
        {
            (string A, string B, string C, string D) = ("A", "B", "C", "D");
            string actual = siren.state
                ([
                    stateDiagram.direction(direction.lr),
                    stateDiagram.transitionStart(A),
                    stateDiagram.transition(A, B),
                    stateDiagram.transition(B, C),
                    stateDiagram.stateComposite(B,[
                        stateDiagram.direction(direction.lr),
                        stateDiagram.transition("a", "b")
                    ]),
                    stateDiagram.transition(B, D)
                ]).write();
            string expected = @"stateDiagram
    direction LR
    [*] --> A
    A --> B
    B --> C
    state B {
        direction LR
        a --> b
    }
    B --> D
";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Comment()
        {
            (string A, string B, string C, string D, string a, string b) = ("A", "B", "C", "D", "a", "b");
            string actual = siren.state
                ([
                    stateDiagram.direction(direction.tb),
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
            string expected = @"stateDiagram
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
";
            Assert.Equal(expected, actual);
        }
    }

    [Fact]
    public void CompletenessTest()
    {
        Type csharpType = typeof(Siren.Sea.stateDiagram);
        Type fsharpType = typeof(Siren.stateDiagram);
        Utils.CompareClasses(csharpType, fsharpType);
    }
}
