namespace Siren.Sea;

using System.Collections.Generic;
using static Siren.Types;
using static Siren.Sea.Util.TupleExtensions;
using Util;
public static class sequence
{
    public static SequenceElement raw(string txt) => Siren.sequence.raw(txt);
    public static SequenceElement participant(string name, Optional<string> alias = default) =>
        Siren.sequence.participant(name, alias.ToOption());
    public static SequenceElement actor(string name, Optional<string> alias = default) =>
        Siren.sequence.actor(name, alias.ToOption());
    public static SequenceElement createParticipant(string name, Optional<string> alias = default) =>
        Siren.sequence.createParticipant(name, alias.ToOption());
    public static SequenceElement createActor(string name, Optional<string> alias = default) =>
        Siren.sequence.createActor(name, alias.ToOption());
    public static SequenceElement destroy(string id) => Siren.sequence.destroy(id);
    public static SequenceElement box(string name, SequenceElement[] children) =>
        Siren.sequence.box(name, children);
    public static SequenceElement boxColored(string name, string color, SequenceElement[] children) =>
        Siren.sequence.boxColored(name, color, children);
    public static SequenceElement message(string id1, string id2, string msg, Optional<bool> activate = default) =>
        Siren.sequence.message(id1, id2, msg, activate.ToOption());
    public static SequenceElement messageSolid(string id1, string id2, string msg, Optional<bool> activate = default) =>
        Siren.sequence.messageSolid(id1, id2, msg, activate.ToOption());
    public static SequenceElement messageDotted(string id1, string id2, string msg, Optional<bool> activate = default) =>
        Siren.sequence.messageDotted(id1, id2, msg, activate.ToOption());
    public static SequenceElement messageArrow(string id1, string id2, string msg, Optional<bool> activate = default) =>
        Siren.sequence.messageArrow(id1, id2, msg, activate.ToOption());
    public static SequenceElement messageDottedArrow(string id1, string id2, string msg, Optional<bool> activate = default) =>
        Siren.sequence.messageDottedArrow(id1, id2, msg, activate.ToOption());
    public static SequenceElement messageCross(string id1, string id2, string msg, Optional<bool> activate = default) =>
        Siren.sequence.messageCross(id1, id2, msg, activate.ToOption());
    public static SequenceElement messageDottedCross(string id1, string id2, string msg, Optional<bool> activate = default) =>
        Siren.sequence.messageDottedCross(id1, id2, msg, activate.ToOption());
    public static SequenceElement messageOpenArrow(string id1, string id2, string msg, Optional<bool> activate = default) =>
        Siren.sequence.messageOpenArrow(id1, id2, msg, activate.ToOption());
    public static SequenceElement messageDottedOpenArrow(string id1, string id2, string msg, Optional<bool> activate = default) =>
        Siren.sequence.messageDottedOpenArrow(id1, id2, msg, activate.ToOption());
    public static SequenceElement activate(string id) => Siren.sequence.activate(id);
    public static SequenceElement deactivate(string id) => Siren.sequence.deactivate(id);
    public static SequenceElement note(string id, string text, Optional<Siren.Formatting.Generic.NotePosition> notePosition = default) =>
        Siren.sequence.note(id, text, notePosition.ToOption());
    public static SequenceElement noteSpanning(string id1, string id2, string text, Optional<Siren.Formatting.Generic.NotePosition> notePosition = default) =>
        Siren.sequence.noteSpanning(id1, id2, text, notePosition.ToOption());
    public static SequenceElement loop(string name, SequenceElement[] children) =>
        Siren.sequence.loop(name, children);
    public static SequenceElement alt(string name, SequenceElement[] children, (string, IEnumerable<SequenceElement>)[] elseList) => 
        Siren.sequence.alt<IEnumerable<SequenceElement>, IEnumerable<Tuple<string, IEnumerable<SequenceElement>>>, IEnumerable<SequenceElement>>(name, children, elseList.Select(t => t.ToTuple()));
    public static SequenceElement opt(string name, SequenceElement[] children) =>
        Siren.sequence.opt(name, children);
    public static SequenceElement par(string name, SequenceElement[] children, (string, IEnumerable<SequenceElement>)[] andList) =>
        Siren.sequence.par<IEnumerable<SequenceElement>, IEnumerable<Tuple<string, IEnumerable<SequenceElement>>>, IEnumerable<SequenceElement>>(name, children, andList.Select(t => t.ToTuple()));
    public static SequenceElement critical(string name, SequenceElement[] children, (string, IEnumerable<SequenceElement>)[] optionList) =>
        Siren.sequence.critical<IEnumerable<SequenceElement>, IEnumerable<Tuple<string, IEnumerable<SequenceElement>>>, IEnumerable<SequenceElement>>
        (
            name, children, optionList.Select(t => t.ToTuple())
        );
    public static SequenceElement breakSeq(string name, SequenceElement[] children) =>
        Siren.sequence.breakSeq(name, children);
    public static SequenceElement rect(string color, SequenceElement[] children) =>
        Siren.sequence.rect(color, children);
    public static SequenceElement comment(string text) => Siren.sequence.comment(text);
    public static SequenceElement autoNumber => Siren.sequence.autoNumber;
    public static SequenceElement link(string id, string urlLabel, string url) => 
        Siren.sequence.link(id, urlLabel, url);
    public static SequenceElement links(string id, (string, string)[] urls) =>
        Siren.sequence.links<IEnumerable<Tuple<string, string>>>(id, urls.Select(t => t.ToTuple()));
}

