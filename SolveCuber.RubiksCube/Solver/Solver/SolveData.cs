using SolveCuber.CubeModel;

namespace SolveCuber.Solver.Solver;

public class SolveData
{
    public List<CubeMove> CrossMoves { get; set; } = [];
    public CubeRotation AfterCrossRotation { get; private init; } = CubeRotation.z2;
    public List<CubeMove> F2L { get; set; } = [];
}
