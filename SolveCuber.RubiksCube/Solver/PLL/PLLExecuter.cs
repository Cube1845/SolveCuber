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
        List<CubeMove>? pll = PLLDefiner.GetPLL(cubeCopy);

        while (pll == null)
        {
            cubeCopy.ExecuteMove(CubeMove.U);

            setUpMoves.Add(CubeMove.U);

            pll = PLLDefiner.GetPLL(cubeCopy);

            if (setUpMoves.Count >= 4)
            {
                throw new Exception("PLL case not found");
            }
        }

        cubeCopy.ExecuteAlgorithm(pll);

        List<CubeMove> goingBackMoves = [];

        for (int i = 0; i < 4; i++)
        {
            cubeCopy.ExecuteMove(CubeMove.U);
            goingBackMoves.Add(CubeMove.U);

            if (IsCubeSolved(cubeCopy))
            {
                break;
            }
        }

        return MoveOptimizer.OptimizeMoves([.. setUpMoves, .. pll, .. goingBackMoves]);
    }

    private static bool IsCubeSolved(Cube cube)
    {
        var frontColor = cube.Front.Face[1, 1];
        var isFrontSolved =
            cube.Front.Face[0, 0] == frontColor &&
            cube.Front.Face[0, 1] == frontColor &&
            cube.Front.Face[0, 2] == frontColor;

        var rightColor = cube.Right.Face[1, 1];
        var isRightSolved =
            cube.Right.Face[0, 0] == rightColor &&
            cube.Right.Face[0, 1] == rightColor &&
            cube.Right.Face[0, 2] == rightColor;

        var backColor = cube.Back.Face[1, 1];
        var isBackSolved =
            cube.Back.Face[0, 0] == backColor &&
            cube.Back.Face[0, 1] == backColor &&
            cube.Back.Face[0, 2] == backColor;

        var leftColor = cube.Left.Face[1, 1];
        var isLeftSolved =
            cube.Left.Face[0, 0] == leftColor &&
            cube.Left.Face[0, 1] == leftColor &&
            cube.Left.Face[0, 2] == leftColor;

        return isFrontSolved && isRightSolved && isBackSolved && isLeftSolved;
    }
}
