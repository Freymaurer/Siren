namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class stateConfig
{
    public static ConfigVariable custom(string key, string value)
         => Siren.stateConfig.custom(key, value);
    public static ConfigVariable titleTopMargin(int value)
         => Siren.stateConfig.titleTopMargin(value);
}