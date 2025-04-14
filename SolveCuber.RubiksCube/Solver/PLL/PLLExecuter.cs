using SolveCuber.Common;
using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;

namespace SolveCuber.Solver.PLL;

public class PLLExecuter
{
    public static List<CubeMove> ExecutePLL(Cube cube)
    {
        var pll = GetPLL(cube);

        cube.ExecuteAlgorithm(pll);

        return pll;
    }

    private static List<CubeMove> GetPLL(Cube cube)
    {
        Cube cubeCopy = cube.DeepCopy();

        List<CubeMove> setUpMoves = [];
        List<CubeMove>? pll = PLLDefiner.GetPLL(cube);

        while (pll == null || pll.Count == 0)
        {
            cubeCopy.ExecuteMove(CubeMove.U);

            setUpMoves.Add(CubeMove.U);

            pll = PLLDefiner.GetPLL(cube);

            if (setUpMoves.Count >= 4)
            {
                throw new Exception("PLL case not found");
            }
        }

        if (setUpMoves.Count > 0)
        {
            return MoveOptimizer.OptimizeMoves([.. pll]);
        }

        setUpMoves = MoveOptimizer.OptimizeMoves(setUpMoves);

        return MoveOptimizer.OptimizeMoves([.. setUpMoves, .. pll, GetOppositeMove(setUpMoves[0])!.Value]);
    }

    private static CubeMove? GetOppositeMove(CubeMove move)
    {
        return move switch
        {
            CubeMove.U => CubeMove.U_,
            CubeMove.U_ => CubeMove.U,
            CubeMove.U2 => CubeMove.U2,

            _ => null
        };
    }
}
