using SolveCuber.CubeModel;
using SolveCuber.Solver.Common;

namespace SolveCuber.Solver.F2L.Positioning.Corners;

internal struct WhiteCornersData(WhiteCornerPosition greenOrange, WhiteCornerPosition orangeBlue, WhiteCornerPosition blueRed, WhiteCornerPosition redGreen)
{
    public WhiteCornerPosition GreenOrange { get; set; } = greenOrange;
    public WhiteCornerPosition OrangeBlue { get; set; } = orangeBlue;
    public WhiteCornerPosition BlueRed { get; set; } = blueRed;
    public WhiteCornerPosition RedGreen { get; set; } = redGreen;

    public WhiteCornerPosition GetCornerPosition(CubeColor firstColor)
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
