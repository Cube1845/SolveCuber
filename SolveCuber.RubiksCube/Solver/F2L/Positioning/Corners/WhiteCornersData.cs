namespace SolveCuber.Solver.F2L.Positioning.Corners;

internal struct WhiteCornersData(WhiteCornerPosition greenOrange, WhiteCornerPosition orangeBlue, WhiteCornerPosition blueRed, WhiteCornerPosition redGreen)
{
    public WhiteCornerPosition GreenOrange { get; set; } = greenOrange;
    public WhiteCornerPosition OrangeBlue { get; set; } = orangeBlue;
    public WhiteCornerPosition BlueRed { get; set; } = blueRed;
    public WhiteCornerPosition RedGreen { get; set; } = redGreen;
}
