using SolveCuber.CubeModel;

namespace SolveCuber.Solver.Solver;

public class Solve
{
    public List<CubeMove> Cross { get; init; } = [];
    public CubeMove AfterCrossRotation { get; init; } = CubeMove.z2;
    public List<CubeMove> F2L { get; init; } = [];
    public List<CubeMove> OLL { get; init; } = [];
    public List<CubeMove> PLL { get; init; } = [];
    public int MovesCount { get; init; }
}
