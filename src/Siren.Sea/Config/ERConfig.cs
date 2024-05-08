namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class erConfig
{
    public static (string, string) custom(string key, string value)
         => Siren.erConfig.custom(key, value).ToValueTuple();
    public static (string, string) titleTopMargin(int value)
         => Siren.erConfig.titleTopMargin(value).ToValueTuple();
    public static (string, string) diagramPadding(int value)
         => Siren.erConfig.diagramPadding(value).ToValueTuple();
    public static (string, string) layoutDirection(string value)
         => Siren.erConfig.layoutDirection(value).ToValueTuple();
    public static (string, string) layoutDirectionTB
         => Siren.erConfig.layoutDirectionTB.ToValueTuple();
    public static (string, string) layoutDirectionBT
         => Siren.erConfig.layoutDirectionBT.ToValueTuple();
    public static (string, string) layoutDirectionLR
         => Siren.erConfig.layoutDirectionLR.ToValueTuple();
    public static (string, string) layoutDirectionRL
         => Siren.erConfig.layoutDirectionRL.ToValueTuple();
    public static (string, string) minEntityWidth(int value)
         => Siren.erConfig.minEntityWidth(value).ToValueTuple();
    public static (string, string) minEntityHeight(int value)
         => Siren.erConfig.minEntityHeight(value).ToValueTuple();
    public static (string, string) entityPadding(int value)
         => Siren.erConfig.entityPadding(value).ToValueTuple();
    public static (string, string) stroke(string value)
         => Siren.erConfig.stroke(value).ToValueTuple();
    public static (string, string) fontSize(int value)
         => Siren.erConfig.fontSize(value).ToValueTuple();
}