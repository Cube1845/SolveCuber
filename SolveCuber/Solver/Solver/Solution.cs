using SolveCuber.CubeModel;

namespace SolveCuber.Solver.Solver;

public class Solution
{
    public List<CubeMove> Cross { get; init; } = [];
    public List<CubeMove> F2L { get; init; } = [];
    public List<CubeMove> OLL { get; init; } = [];
    public List<CubeMove> PLL { get; init; } = [];
    public int MovesCount { get; init; }

    public string Order => $"{nameof(Cross)}, {nameof(F2L)}, {nameof(OLL)}, {nameof(PLL)}";
}
