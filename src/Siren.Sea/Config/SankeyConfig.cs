namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class sankeyConfig
{
    public static ConfigVariable custom(string key, string value)
         => Siren.sankeyConfig.custom(key, value);
    public static ConfigVariable width(int value)
         => Siren.sankeyConfig.width(value);
    public static ConfigVariable height(int value)
         => Siren.sankeyConfig.height(value);
    public static ConfigVariable linkColor(string value)
         => Siren.sankeyConfig.linkColor(value);
    public static ConfigVariable linkColorSource
         => Siren.sankeyConfig.linkColorSource;
    public static ConfigVariable linkColorTarget
         => Siren.sankeyConfig.linkColorTarget;
    public static ConfigVariable linkColorGradient
         => Siren.sankeyConfig.linkColorGradient;
}