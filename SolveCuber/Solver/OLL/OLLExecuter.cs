﻿using SolveCuber.Common;
using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Solver.Common;
using SolveCuber.Solver.F2L;

namespace SolveCuber.Solver.OLL;

public static class OLLExecuter
{
    /// <summary>
    /// Orients top layer of the cube yellow stickers up if first two layers of the cube are solved.
    /// </summary>
    /// <param name="cube">Cube you want to orient top layer on</param>
    /// <returns>Sequence of moves that orients top layer pieces.</returns>
    /// <exception cref="RubiksCubeException"></exception>
    public static List<CubeMove> ExecuteOLL(Cube cube)
    {
        var cubeRotations = CubeOrienter.OrientCube(cube, CubeColor.Yellow);

        if (!F2LSolver.IsF2lSolved(cube))
        {
            throw new RubiksCubeException("You execute the OLL if first two layers of the cube are not solved.");
        }

        var topLayerOrientations = YellowPiecesPositioningHelper.GetYellowPiecesFaceAxis(cube);

        var algorithm = GetOLLAlgorithm(topLayerOrientations, cube);

        cube.ExecuteAlgorithm(algorithm);

        return MoveOptimizer.OptimizeMoves([.. cubeRotations, .. algorithm]);
    }

    private static List<CubeMove> GetOLLAlgorithm(FaceAxis[,] topLayerOrientations, Cube cube)
    {
        FaceAxis[,] clonedOrientations = (FaceAxis[,])topLayerOrientations.Clone();

        Cube cubeCopy = cube.DeepCopy();

        List<CubeMove> setUpMoves = [];
        List<CubeMove>? ollAlgorithm = CheckOLLCases(clonedOrientations);

        while (ollAlgorithm == null)
        {
            cubeCopy.ExecuteMove(CubeMove.U);

            clonedOrientations = YellowPiecesPositioningHelper.GetYellowPiecesFaceAxis(cubeCopy);
            setUpMoves.Add(CubeMove.U);

            ollAlgorithm = CheckOLLCases(clonedOrientations);

            if (setUpMoves.Count > 4)
            {
                throw new RubiksCubeException("OLL case not found");
            }
        }

        return MoveOptimizer.OptimizeMoves([.. setUpMoves, .. ollAlgorithm]);
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
}
