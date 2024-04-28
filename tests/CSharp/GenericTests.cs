namespace Siren.Sea.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GenericTests
{
    // Test classes in Genric.cs for completeness
    [Fact]
    public void DirectionTest()
    {
        Type csharpType = typeof(Siren.Sea.direction);
        Type fsharpType = typeof(Siren.direction);
        Utils.CompareClasses(csharpType, fsharpType);
    }
    [Fact]
    public void NotePositionTest()
    {
        Type csharpType = typeof(Siren.Sea.notePosition);
        Type fsharpType = typeof(Siren.notePosition);
        Utils.CompareClasses(csharpType, fsharpType);
    }
    [Fact]
    public void FormattingTest()
    {
        Type csharpType = typeof(Siren.Sea.formatting);
        Type fsharpType = typeof(Siren.formatting);
        Utils.CompareClasses(csharpType, fsharpType);
    }
}
