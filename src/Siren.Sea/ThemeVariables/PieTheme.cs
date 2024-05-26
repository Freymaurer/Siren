namespace Siren.Sea;

using Fable.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class pieTheme
{
    public static ThemeVariable custom(string key, string value)
         => Siren.pieTheme.custom(key, value);
    public static ThemeVariable pieOuterStrokeWidth(string lengthUnit)
         => Siren.pieTheme.pieOuterStrokeWidth(lengthUnit);
}