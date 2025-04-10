using SolveCuber.CubeModel;

namespace SolveCuber.Solver.Solver;

public class SolveData
{
    public List<CubeMove> CrossMoves { get; set; } = [];
    public CubeMove AfterCrossRotation { get; private init; } = CubeMove.z2;
    public List<CubeMove> F2L { get; set; } = [];
}
