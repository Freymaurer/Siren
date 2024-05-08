namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class classConfig
{
    public static (string, string) custom(string key, string value)
         => Siren.classConfig.custom(key, value).ToValueTuple();
    public static (string, string) defaultRenderer(string renderer)
         => Siren.classConfig.defaultRenderer(renderer).ToValueTuple();
    public static (string, string) defaultRendererElk
         => Siren.classConfig.defaultRendererElk.ToValueTuple();
    public static (string, string) defaultRendererDagreD3
         => Siren.classConfig.defaultRendererDagreD3.ToValueTuple();
    public static (string, string) defaultRendererDagreWrapper
         => Siren.classConfig.defaultRendererDagreWrapper.ToValueTuple();
}