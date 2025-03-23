using SolveCuber.Solver.F2L.Positioning.Corners;

namespace SolveCuber.Solver.F2L.Positioning;

internal class NonYellowEdgesData
{
    public WhiteCornerPosition GreenOrange { get; set; } = new();
    public WhiteCornerPosition OrangeBlue { get; set; } = new();
    public WhiteCornerPosition BlueRed { get; set; } = new();
    public WhiteCornerPosition RedGreen { get; set; } = new();
}
