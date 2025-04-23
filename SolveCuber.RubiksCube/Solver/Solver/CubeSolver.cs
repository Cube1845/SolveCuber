using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Solver.F2L;
using SolveCuber.Solver.OLL;
using SolveCuber.Solver.PLL;
using SolveCuber.Solver.WhiteCross;

namespace SolveCuber.Solver.Solver;

public static class CubeSolver
{
    public static Solve SolveCube(Cube cube)
    {
        var crossMoves = WhiteCrossSolver.SolveCross(cube);

        cube.ExecuteMove(CubeMove.z2);

        var f2lMoves = F2LSolver.SolveF2L(cube);

        var oll = OLLExecuter.ExecuteOLL(cube);

        var pll = PLLExecuter.ExecutePLL(cube);

        return new()
        {
            Cross = crossMoves,
            F2L = f2lMoves,
            OLL = oll,
            PLL = pll,
            MovesCount = crossMoves.Count + f2lMoves.Count + oll.Count + pll.Count
        };
    }
}
