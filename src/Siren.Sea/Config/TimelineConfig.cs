namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class timelineConfig
{
    public static ConfigVariable custom(string key, string value)
         => Siren.timelineConfig.custom(key, value);
    public static ConfigVariable disableMulticolor(bool value)
         => Siren.timelineConfig.disableMulticolor(value);
    public static ConfigVariable padding(int value)
         => Siren.timelineConfig.padding(value);
}