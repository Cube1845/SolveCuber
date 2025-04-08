using SolveCuber.Common;
using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Solver.Common;

namespace SolveCuber.Solver.OLL;

public static class OLLExecuter
{
    public static List<CubeMove> ExecuteOLL(Cube cube)
    {
        var topLayerOrientations = YellowPiecesPositioningHelper.GetYellowPiecesFaceAxis(cube);

        var algorithm = GetOLLAlgorithm(topLayerOrientations);

        cube.ExecuteAlgorithm(algorithm);

        return algorithm;
    }

    private static List<CubeMove> GetOLLAlgorithm(FaceAxis[,] topLayerOrientations)
    {
        FaceAxis[,] clonedOrientations = (FaceAxis[,])topLayerOrientations.Clone();

        List<CubeMove> setUpMoves = [];
        List<CubeMove>? ollAlgorithm = CheckOLLCases(clonedOrientations);

        while (ollAlgorithm == null || ollAlgorithm.Count == 0)
        {
            clonedOrientations = RotateTopLayerOrientationsClockwise(clonedOrientations);
            setUpMoves.Add(CubeMove.U);

            ollAlgorithm = CheckOLLCases(clonedOrientations);
        }

        return MoveOptimizer.OptimizeMoves([.. setUpMoves, ..ollAlgorithm]);
    }

    private static List<CubeMove>? CheckOLLCases(FaceAxis[,] topLayerOrientations)
    {
        foreach (var oll in OLLAlgorithms.OLLs)
        {
            if (CasesMatch(topLayerOrientations, oll.Case))
            {
                return oll.Algorithm;
            }
        }

        return null;
    }

    private static bool CasesMatch(FaceAxis[,] case1, FaceAxis[,] case2)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (case1[i, j] != case2[i, j])
                {
                    return false;
                }
            }
        }

        return true;
    }

    private static FaceAxis[,] RotateTopLayerOrientationsClockwise(FaceAxis[,] topLayerOrientations)
    {
        FaceAxis[,] currentOrientations = (FaceAxis[,])topLayerOrientations.Clone();
        FaceAxis[,] newOrientations = new FaceAxis[3, 3];

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                newOrientations[i, j] = currentOrientations[2 - j, i];
            }
        }

        return newOrientations;
    }
}
