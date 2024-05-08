namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class timelineConfig
{
    public static (string, string) custom(string key, string value)
         => Siren.timelineConfig.custom(key, value).ToValueTuple();
    public static (string, string) disableMulticolor(bool value)
         => Siren.timelineConfig.disableMulticolor(value).ToValueTuple();
    public static (string, string) padding(int value)
         => Siren.timelineConfig.padding(value).ToValueTuple();
}