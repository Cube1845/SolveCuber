using SolveCuber.CubeModel;
using SolveCuber.Solver.F2L.Positioning.Corners;

namespace SolveCuber.Solver.F2L.Positioning.Edges;

internal struct NonYellowEdgesData(NonYellowEdgePosition greenOrange, NonYellowEdgePosition orangeBlue, NonYellowEdgePosition blueRed, NonYellowEdgePosition redGreen)
{
    public NonYellowEdgePosition GreenOrange { get; set; } = greenOrange;
    public NonYellowEdgePosition OrangeBlue { get; set; } = orangeBlue;
    public NonYellowEdgePosition BlueRed { get; set; } = blueRed;
    public NonYellowEdgePosition RedGreen { get; set; } = redGreen;

    public NonYellowEdgePosition GetEdgePosition(CubeColor firstColor)
    {
        return firstColor switch
        {
            CubeColor.Green => GreenOrange,
            CubeColor.Orange => OrangeBlue,
            CubeColor.Blue => BlueRed,
            CubeColor.Red => RedGreen,

            _ => throw new NotImplementedException()
        };
    }
}
