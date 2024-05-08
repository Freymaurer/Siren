namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public static class quadrantTheme
{
    public static (string, string) quadrant1Fill(string color)
         => Siren.quadrantTheme.quadrant1Fill(color).ToValueTuple();
    public static (string, string) quadrant2Fill(string color)
         => Siren.quadrantTheme.quadrant2Fill(color).ToValueTuple();
    public static (string, string) quadrant3Fill(string color)
         => Siren.quadrantTheme.quadrant3Fill(color).ToValueTuple();
    public static (string, string) quadrant4Fill(string color)
         => Siren.quadrantTheme.quadrant4Fill(color).ToValueTuple();
    public static (string, string) quadrant1TextFill(string color)
         => Siren.quadrantTheme.quadrant1TextFill(color).ToValueTuple();
    public static (string, string) quadrant2TextFill(string color)
         => Siren.quadrantTheme.quadrant2TextFill(color).ToValueTuple();
    public static (string, string) quadrant3TextFill(string color)
         => Siren.quadrantTheme.quadrant3TextFill(color).ToValueTuple();
    public static (string, string) quadrant4TextFill(string color)
         => Siren.quadrantTheme.quadrant4TextFill(color).ToValueTuple();
    public static (string, string) quadrantPointFill(string color)
         => Siren.quadrantTheme.quadrantPointFill(color).ToValueTuple();
    public static (string, string) quadrantPointTextFill(string color)
         => Siren.quadrantTheme.quadrantPointTextFill(color).ToValueTuple();
    public static (string, string) quadrantXAxisTextFill(string color)
         => Siren.quadrantTheme.quadrantXAxisTextFill(color).ToValueTuple();
    public static (string, string) quadrantYAxisTextFill(string color)
         => Siren.quadrantTheme.quadrantYAxisTextFill(color).ToValueTuple();
    public static (string, string) quadrantInternalBorderStrokeFill(string color)
         => Siren.quadrantTheme.quadrantInternalBorderStrokeFill(color).ToValueTuple();
    public static (string, string) quadrantExternalBorderStrokeFill(string color)
         => Siren.quadrantTheme.quadrantExternalBorderStrokeFill(color).ToValueTuple();
    public static (string, string) quadrantTitleFill(string color)
         => Siren.quadrantTheme.quadrantTitleFill(color).ToValueTuple();
}