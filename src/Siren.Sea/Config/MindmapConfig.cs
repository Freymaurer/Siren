namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class mindmapConfig
{
    public static ConfigVariable custom(string key, string value)
         => Siren.mindmapConfig.custom(key, value);
    public static ConfigVariable padding(int value)
         => Siren.mindmapConfig.padding(value);
    public static ConfigVariable maxNodeWidth(int value)
         => Siren.mindmapConfig.maxNodeWidth(value);
}