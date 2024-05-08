namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class mindmapConfig
{
    public static (string, string) custom(string key, string value)
         => Siren.mindmapConfig.custom(key, value).ToValueTuple();
    public static (string, string) padding(int value)
         => Siren.mindmapConfig.padding(value).ToValueTuple();
    public static (string, string) maxNodeWidth(int value)
         => Siren.mindmapConfig.maxNodeWidth(value).ToValueTuple();
}