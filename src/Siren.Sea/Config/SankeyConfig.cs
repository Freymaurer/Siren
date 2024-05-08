namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class sankeyConfig
{
    public static (string, string) custom(string key, string value)
         => Siren.sankeyConfig.custom(key, value).ToValueTuple();
    public static (string, string) width(int value)
         => Siren.sankeyConfig.width(value).ToValueTuple();
    public static (string, string) height(int value)
         => Siren.sankeyConfig.height(value).ToValueTuple();
    public static (string, string) linkColor(string value)
         => Siren.sankeyConfig.linkColor(value).ToValueTuple();
    public static (string, string) linkColorSource
         => Siren.sankeyConfig.linkColorSource.ToValueTuple();
    public static (string, string) linkColorTarget
         => Siren.sankeyConfig.linkColorTarget.ToValueTuple();
    public static (string, string) linkColorGradient
         => Siren.sankeyConfig.linkColorGradient.ToValueTuple();
}