namespace SolveCuber.Solver.F2L.Positioning.Edges;

internal struct NonYellowEdgesData(NonYellowEdgePosition greenOrange, NonYellowEdgePosition orangeBlue, NonYellowEdgePosition blueRed, NonYellowEdgePosition redGreen)
{
    public NonYellowEdgePosition GreenOrange { get; set; } = greenOrange;
    public NonYellowEdgePosition OrangeBlue { get; set; } = orangeBlue;
    public NonYellowEdgePosition BlueRed { get; set; } = blueRed;
    public NonYellowEdgePosition RedGreen { get; set; } = redGreen;
}
