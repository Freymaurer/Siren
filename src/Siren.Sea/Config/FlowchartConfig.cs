namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class flowchartConfig
{
    public static (string, string) custom(string key, string value)
         => Siren.flowchartConfig.custom(key, value).ToValueTuple();
    public static (string, string) defaultRenderer(string renderer)
         => Siren.flowchartConfig.defaultRenderer(renderer).ToValueTuple();
    public static (string, string) defaultRendererElk
         => Siren.flowchartConfig.defaultRendererElk.ToValueTuple();
    public static (string, string) defaultRendererDagreD3
         => Siren.flowchartConfig.defaultRendererDagreD3.ToValueTuple();
    public static (string, string) defaultRendererDagreWrapper
         => Siren.flowchartConfig.defaultRendererDagreWrapper.ToValueTuple();
    public static (string, string) titleTopMargin(int px)
         => Siren.flowchartConfig.titleTopMargin(px).ToValueTuple();
    public static (string, string) subGraphTitleMargin(int top, int bottom)
         => Siren.flowchartConfig.subGraphTitleMargin(top, bottom).ToValueTuple();
    public static (string, string) arrowMarkerAbsolute(bool b)
         => Siren.flowchartConfig.arrowMarkerAbsolute(b).ToValueTuple();
    public static (string, string) diagramPadding(int px)
         => Siren.flowchartConfig.diagramPadding(px).ToValueTuple();
    public static (string, string) htmlLabels(bool b)
         => Siren.flowchartConfig.htmlLabels(b).ToValueTuple();
    public static (string, string) nodeSpacing(int px)
         => Siren.flowchartConfig.nodeSpacing(px).ToValueTuple();
    public static (string, string) rankSpacing(int px)
         => Siren.flowchartConfig.rankSpacing(px).ToValueTuple();
    public static (string, string) curve(string name)
         => Siren.flowchartConfig.curve(name).ToValueTuple();
    public static (string, string) curveBasis
         => Siren.flowchartConfig.curveBasis.ToValueTuple();
    public static (string, string) curveLinear
         => Siren.flowchartConfig.curveLinear.ToValueTuple();
    public static (string, string) curveCardianal
         => Siren.flowchartConfig.curveCardianal.ToValueTuple();
    public static (string, string) padding(int px)
         => Siren.flowchartConfig.padding(px).ToValueTuple();
    public static (string, string) wrappingWidth(int px)
         => Siren.flowchartConfig.wrappingWidth(px).ToValueTuple();
}