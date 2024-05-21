namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class erConfig
{
    public static ConfigVariable custom(string key, string value)
         => Siren.erConfig.custom(key, value);
    public static ConfigVariable titleTopMargin(int value)
         => Siren.erConfig.titleTopMargin(value);
    public static ConfigVariable diagramPadding(int value)
         => Siren.erConfig.diagramPadding(value);
    public static ConfigVariable layoutDirection(string value)
         => Siren.erConfig.layoutDirection(value);
    public static ConfigVariable layoutDirectionTB
         => Siren.erConfig.layoutDirectionTB;
    public static ConfigVariable layoutDirectionBT
         => Siren.erConfig.layoutDirectionBT;
    public static ConfigVariable layoutDirectionLR
         => Siren.erConfig.layoutDirectionLR;
    public static ConfigVariable layoutDirectionRL
         => Siren.erConfig.layoutDirectionRL;
    public static ConfigVariable minEntityWidth(int value)
         => Siren.erConfig.minEntityWidth(value);
    public static ConfigVariable minEntityHeight(int value)
         => Siren.erConfig.minEntityHeight(value);
    public static ConfigVariable entityPadding(int value)
         => Siren.erConfig.entityPadding(value);
    public static ConfigVariable stroke(string value)
         => Siren.erConfig.stroke(value);
    public static ConfigVariable fontSize(int value)
         => Siren.erConfig.fontSize(value);
}