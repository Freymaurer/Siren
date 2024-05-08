namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class stateConfig
{
    public static (string, string) custom(string key, string value)
         => Siren.stateConfig.custom(key, value).ToValueTuple();
    public static (string, string) titleTopMargin(int value)
         => Siren.stateConfig.titleTopMargin(value).ToValueTuple();
}