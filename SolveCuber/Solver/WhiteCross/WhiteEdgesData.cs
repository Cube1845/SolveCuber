using SolveCuber.CubeModel;

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

    internal WhiteEdgeLocation GetLocation(CubeColor color)
    {
        return color switch
        {
            CubeColor.Green => Green,
            CubeColor.Orange => Orange,
            CubeColor.Red => Red,
            CubeColor.Blue => Blue,

            _ => throw new NotImplementedException()
        };
    }
}
