namespace Siren.Sea;

using Siren.Sea.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class requirementConfig
{
    public static (string, string) custom(string key, string value)
         => Siren.requirementConfig.custom(key, value).ToValueTuple();
    public static (string, string) rect_min_width(int value)
         => Siren.requirementConfig.rect_min_width(value).ToValueTuple();
    public static (string, string) rect_min_height(int value)
         => Siren.requirementConfig.rect_min_height(value).ToValueTuple();
    public static (string, string) rect_padding(int value)
         => Siren.requirementConfig.rect_padding(value).ToValueTuple();
    public static (string, string) line_height(int value)
         => Siren.requirementConfig.line_height(value).ToValueTuple();
}