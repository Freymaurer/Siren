namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class journeyConfig
{
    public static ConfigVariable custom(string key, string value)
         => Siren.journeyConfig.custom(key, value);
    public static ConfigVariable diagramMarginX(int value)
         => Siren.journeyConfig.diagramMarginX(value);
    public static ConfigVariable diagramMarginY(int value)
         => Siren.journeyConfig.diagramMarginY(value);
    public static ConfigVariable leftMargin(int value)
         => Siren.journeyConfig.leftMargin(value);
    public static ConfigVariable width(int value)
         => Siren.journeyConfig.width(value);
    public static ConfigVariable height(int value)
         => Siren.journeyConfig.height(value);
}