namespace Siren.Sea.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Utils
{
    public static int GetMemberCount(Type type)
    {
        var members = type.GetMembers();
        return members.Length;
    }

    public static List<string> GetMemberNameDifferences(Type type1, Type type2)
    {
        List<string> differences = new List<string>();

        var type1Members = type1.GetMembers().Select(m => m.Name);
        var type2Members = type2.GetMembers().Select(m => m.Name);
        differences.AddRange(type1Members.Except(type2Members));
        differences.AddRange(type2Members.Except(type1Members));

        return differences;
    }

    public static void CompareClasses(Type csharpType, Type fsharpType)
    {
        int csharpMemberCount = GetMemberCount(csharpType);
        int fsharpMemberCount = GetMemberCount(fsharpType);
        List<string> differences = GetMemberNameDifferences(fsharpType, csharpType);

        Assert.Empty(differences);
        Assert.Equal(fsharpMemberCount, csharpMemberCount);
    }
}