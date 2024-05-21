namespace Siren.Sea;

using Siren.Sea.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class requirementConfig
{
    public static ConfigVariable custom(string key, string value)
         => Siren.requirementConfig.custom(key, value);
    public static ConfigVariable rect_min_width(int value)
         => Siren.requirementConfig.rect_min_width(value);
    public static ConfigVariable rect_min_height(int value)
         => Siren.requirementConfig.rect_min_height(value);
    public static ConfigVariable rect_padding(int value)
         => Siren.requirementConfig.rect_padding(value);
    public static ConfigVariable line_height(int value)
         => Siren.requirementConfig.line_height(value);
}