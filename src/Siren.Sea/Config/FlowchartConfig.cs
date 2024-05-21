namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class flowchartConfig
{
    public static ConfigVariable custom(string key, string value)
         => Siren.flowchartConfig.custom(key, value);
    public static ConfigVariable defaultRenderer(string renderer)
         => Siren.flowchartConfig.defaultRenderer(renderer);
    public static ConfigVariable defaultRendererElk
         => Siren.flowchartConfig.defaultRendererElk;
    public static ConfigVariable defaultRendererDagreD3
         => Siren.flowchartConfig.defaultRendererDagreD3;
    public static ConfigVariable defaultRendererDagreWrapper
         => Siren.flowchartConfig.defaultRendererDagreWrapper;
    public static ConfigVariable titleTopMargin(int px)
         => Siren.flowchartConfig.titleTopMargin(px);
    public static ConfigVariable subGraphTitleMargin(int top, int bottom)
         => Siren.flowchartConfig.subGraphTitleMargin(top, bottom);
    public static ConfigVariable arrowMarkerAbsolute(bool b)
         => Siren.flowchartConfig.arrowMarkerAbsolute(b);
    public static ConfigVariable diagramPadding(int px)
         => Siren.flowchartConfig.diagramPadding(px);
    public static ConfigVariable htmlLabels(bool b)
         => Siren.flowchartConfig.htmlLabels(b);
    public static ConfigVariable nodeSpacing(int px)
         => Siren.flowchartConfig.nodeSpacing(px);
    public static ConfigVariable rankSpacing(int px)
         => Siren.flowchartConfig.rankSpacing(px);
    public static ConfigVariable curve(string name)
         => Siren.flowchartConfig.curve(name);
    public static ConfigVariable curveBasis
         => Siren.flowchartConfig.curveBasis;
    public static ConfigVariable curveLinear
         => Siren.flowchartConfig.curveLinear;
    public static ConfigVariable curveCardianal
         => Siren.flowchartConfig.curveCardianal;
    public static ConfigVariable padding(int px)
         => Siren.flowchartConfig.padding(px);
    public static ConfigVariable wrappingWidth(int px)
         => Siren.flowchartConfig.wrappingWidth(px);
}