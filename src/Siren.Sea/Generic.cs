using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Siren.Formatting;
using static Siren.Types;

public static class notePosition
{
    public static Generic.NotePosition over => Siren.notePosition.over;
    public static Generic.NotePosition rightOf => Siren.notePosition.rightOf;
    public static Generic.NotePosition leftOf => Siren.notePosition.leftOf;
}

public static class formatting
{
    public static string unicode(string txt) => Siren.formatting.unicode(txt);
    public static string markdown(string txt) => Siren.formatting.markdown(txt);
    public static string comment(string txt) => Siren.formatting.comment(txt);
}

public static class direction
{
    public static Direction tb => Siren.direction.tb;
    public static Direction td => Siren.direction.td;
    public static Direction bt => Siren.direction.bt;
    public static Direction rl => Siren.direction.rl;
    public static Direction lr => Siren.direction.lr;
    public static Direction topToBottom => Siren.direction.tb;
    public static Direction topDown => Siren.direction.td;
    public static Direction bottomToTop => Siren.direction.bt;
    public static Direction rightToLeft => Siren.direction.rl;
    public static Direction leftToRight => Siren.direction.lr;
    public static Direction custom(string str) => Siren.direction.custom(str);
}
