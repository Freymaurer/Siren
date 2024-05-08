namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class journeyConfig
{
    public static (string, string) custom(string key, string value)
         => Siren.journeyConfig.custom(key, value).ToValueTuple();
    public static (string, string) diagramMarginX(int value)
         => Siren.journeyConfig.diagramMarginX(value).ToValueTuple();
    public static (string, string) diagramMarginY(int value)
         => Siren.journeyConfig.diagramMarginY(value).ToValueTuple();
    public static (string, string) leftMargin(int value)
         => Siren.journeyConfig.leftMargin(value).ToValueTuple();
    public static (string, string) width(int value)
         => Siren.journeyConfig.width(value).ToValueTuple();
    public static (string, string) height(int value)
         => Siren.journeyConfig.height(value).ToValueTuple();
}