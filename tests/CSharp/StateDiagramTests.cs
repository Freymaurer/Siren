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
    [Fact]
    public void Forks()
    {
        (string fork_state, string join_state, string State2, string State3, string State4) =
            ("fork_state", "join_state", "State2", "State3", "State4");
        SirenElement graph = siren.stateV2
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
            ]);
        string actual = siren.write(graph);
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
        SirenElement graph = siren.stateV2
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
            ]) ;
        string actual = siren.write(graph);
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
        Xunit.Assert.Equal(expected, actual);
    }

    [Fact]
    public void InnerDirection()
    {
        (string A, string B, string C, string D) = ("A", "B", "C", "D");
        SirenElement graph = siren.state
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
            ]);
        string actual = siren.write(graph);
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
        Xunit.Assert.Equal(expected, actual);
    }

    [Fact]
    public void CompletenessTest()
    {
        Type csharpType = typeof(Siren.Sea.stateDiagram);
        Type fsharpType = typeof(Siren.stateDiagram);
        Utils.CompareClasses(csharpType, fsharpType);
    }
}
