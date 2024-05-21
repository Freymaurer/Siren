namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class classConfig
{
    public static ConfigVariable custom(string key, string value)
         => Siren.classConfig.custom(key, value);
    public static ConfigVariable defaultRenderer(string renderer)
         => Siren.classConfig.defaultRenderer(renderer);
    public static ConfigVariable defaultRendererElk
         => Siren.classConfig.defaultRendererElk;
    public static ConfigVariable defaultRendererDagreD3
         => Siren.classConfig.defaultRendererDagreD3;
    public static ConfigVariable defaultRendererDagreWrapper
         => Siren.classConfig.defaultRendererDagreWrapper;
}