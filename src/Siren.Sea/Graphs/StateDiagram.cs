namespace Siren.Sea;

using static Siren.Types;
using static Formatting.Generic;
using Util;
public static class stateDiagram
{
    public static StateDiagramElement state(string id, Optional<string> description = default)
         => Siren.stateDiagram.state(id, description.ToOption());
    public static StateDiagramElement transition(string id1, string id2, Optional<string> description = default)
         => Siren.stateDiagram.transition(id1, id2, description.ToOption());
    public static StateDiagramElement transitionStart(string id, Optional<string> description = default)
         => Siren.stateDiagram.transitionStart(id, description.ToOption());
    public static StateDiagramElement transitionEnd(string id, Optional<string> description = default)
         => Siren.stateDiagram.transitionEnd(id, description.ToOption());
    public static String startEnd
         => Siren.stateDiagram.startEnd;
    public static StateDiagramElement stateComposite(string id, IEnumerable<StateDiagramElement> children)
         => Siren.stateDiagram.stateComposite(id, children);
    public static StateDiagramElement stateChoice(string id)
         => Siren.stateDiagram.stateChoice(id);
    public static StateDiagramElement stateFork(string id)
         => Siren.stateDiagram.stateFork(id);
    public static StateDiagramElement stateJoin(string id)
         => Siren.stateDiagram.stateJoin(id);
    public static StateDiagramElement note(string id, string msg, Optional<NotePosition> notePosition = default)
         => Siren.stateDiagram.note(id, msg, notePosition.ToOption());
    public static StateDiagramElement noteMultiLine(string id, IEnumerable<string> lines, Optional<NotePosition> notePosition = default)
         => Siren.stateDiagram.noteMultiLine(id, lines, notePosition.ToOption());
    public static StateDiagramElement noteLine(string id, string msg, Optional<NotePosition> notePosition = default)
         => Siren.stateDiagram.noteLine(id, msg, notePosition.ToOption());
    public static StateDiagramElement concurrency
         => Siren.stateDiagram.concurrency;
    public static StateDiagramElement direction(Direction direction)
         => Siren.stateDiagram.direction(direction);
    public static StateDiagramElement comment(string txt)
         => Siren.stateDiagram.comment(txt);
}
