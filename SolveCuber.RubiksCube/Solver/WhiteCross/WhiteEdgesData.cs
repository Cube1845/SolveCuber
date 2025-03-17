namespace SolveCuber.Solver.WhiteCross;

internal class WhiteEdgesData
{
    public WhiteEdgeLocation Green { get; set; }
    public WhiteEdgeLocation Orange { get; set; }
    public WhiteEdgeLocation Red { get; set; }
    public WhiteEdgeLocation Blue { get; set; }

    internal WhiteEdgesData DeepCopy()
    {
        return new()
        {
            Green = Green,
            Orange = Orange,
            Red = Red,
            Blue = Blue
        };
    }
}
