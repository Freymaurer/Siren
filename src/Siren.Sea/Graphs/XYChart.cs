namespace Siren.Sea;

public static class xyChart
{
    public static XYChartElement raw(string line)
         => Siren.xyChart.raw(line);
    public static XYChartElement title(string name)
         => Siren.xyChart.title(name);
    public static XYChartElement xAxis(IEnumerable<string> data)
         => Siren.xyChart.xAxis(data);
    public static XYChartElement xAxisNamed(string name, IEnumerable<string> data)
         => Siren.xyChart.xAxisNamed(name, data);
    public static XYChartElement xAxisRange(double rangeStart, double rangeEnd)
         => Siren.xyChart.xAxisRange(rangeStart, rangeEnd);
    public static XYChartElement xAxisNamedRange(string name, double rangeStart, double rangeEnd)
         => Siren.xyChart.xAxisNamedRange(name, rangeStart, rangeEnd);
    public static XYChartElement yAxis(string name)
         => Siren.xyChart.yAxis(name);
    public static XYChartElement yAxisRange(double rangeStart, double rangeEnd)
         => Siren.xyChart.yAxisRange(rangeStart, rangeEnd);
    public static XYChartElement yAxisNamedRange(string name, double rangeStart, double rangeEnd)
         => Siren.xyChart.yAxisNamedRange(name, rangeStart, rangeEnd);
    public static XYChartElement line(IEnumerable<double> data)
         => Siren.xyChart.line(data);
    public static XYChartElement bar(IEnumerable<double> data)
         => Siren.xyChart.bar(data);
    public static XYChartElement comment(string txt)
         => Siren.xyChart.comment(txt);
}
