namespace Siren.Sea;

using static Siren.Types;

public class pieChart
{
    public static PieChartElement raw(string line)
         => Siren.pieChart.raw(line);
    public static PieChartElement data(string name, double value)
         => Siren.pieChart.data(name, value);
    public static PieChartElement data(string name, int value)
         => Siren.pieChart.data(name, value);
}
