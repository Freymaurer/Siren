﻿namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class pieConfig
{
    public static ConfigVariable custom(string key, string value)
         => Siren.pieConfig.custom(key, value);
    public static ConfigVariable textPosition(double value)
         => Siren.pieConfig.textPosition(value);
}