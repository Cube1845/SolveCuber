﻿using SolveCuber.Common;
using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Solver.Common;
using SolveCuber.Solver.F2L.Positioning.Corners;
using SolveCuber.Solver.F2L.Positioning.Edges;
using SolveCuber.Solver.WhiteCross;

namespace SolveCuber.Solver.F2L;

public static class F2LSolver
{
    /// <summary>
    /// Solves first two leayers of the cube if the white cross is solved.
    /// </summary>
    /// <param name="cube">Cube you want to solve the white cross on</param>
    /// <returns>Sequence of moves that solves the first two layers.</returns>
    /// <exception cref="RubiksCubeException"></exception>
    public static List<CubeMove> SolveF2L(Cube cube)
    {
        var cubeRotations = CubeOrienter.OrientCube(cube, CubeColor.Yellow);

        if (!WhiteCrossSolver.IsCrossSolved(cube))
        {
            throw new RubiksCubeException("You can't solve the first two layers if white cross is not solved.");
        }

        if (IsF2lSolved(cube))
        {
            return [];
        }

        var solutionWithLeastMoves = GetSolutionWithLeastMoves(cube);

        cube.ExecuteAlgorithm(solutionWithLeastMoves);

        return MoveOptimizer.OptimizeMoves([.. cubeRotations, .. solutionWithLeastMoves]);
    }

    internal static bool IsF2lSolved(Cube cube)
    {
        var cubeCopy = cube.DeepCopy();

        var cubeRotations = CubeOrienter.OrientCube(cubeCopy, CubeColor.Yellow);

        var cornersData = CornerPositionHelper.LocateCorners(cubeCopy);
        var edgesData = EdgePositionHelper.LocateEdges(cubeCopy);

        var frontFaceCenterColor = cubeCopy.Front.Face[1, 1];

        return IsPairInCorrectPlace(cornersData.GreenOrange, edgesData.GreenOrange, CubeColor.Green, frontFaceCenterColor)
            && IsPairInCorrectPlace(cornersData.OrangeBlue, edgesData.OrangeBlue, CubeColor.Orange, frontFaceCenterColor)
            && IsPairInCorrectPlace(cornersData.BlueRed, edgesData.BlueRed, CubeColor.Blue, frontFaceCenterColor)
            && IsPairInCorrectPlace(cornersData.RedGreen, edgesData.RedGreen, CubeColor.Red, frontFaceCenterColor);
    }

    private static List<CubeMove> GetSolutionWithLeastMoves(Cube cube)
    {
        List<List<CubeMove>> solutions = [];

        foreach (var colorOrder in ColorOrders.EdgeSolvingOrders)
        {
            var solution = GetSolvingF2LMoves(cube, colorOrder);
            solutions.Add(solution);
        }

        var orderedSolutions = solutions.OrderBy(s => s.Count).ToList();

        return orderedSolutions[0];
    }

    private static List<CubeMove> GetSolvingF2LMoves(Cube cube, List<CubeColor> colorOrder)
    {
        Cube cubeCopy = cube.DeepCopy();

        List<CubeMove> solvingF2LMoves = [];

        foreach (var color in colorOrder)
        {
            var cornerData = CornerPositionHelper.LocateCorners(cubeCopy).GetCornerPosition(color);
            var edgeData = EdgePositionHelper.LocateEdges(cubeCopy).GetEdgePosition(color);

            bool isInCorrectPlace =
                IsPairInCorrectPlace(cornerData, edgeData, color, cubeCopy.Front.Face[1, 1]);

            if (isInCorrectPlace)
            {
                continue;
            }

            List<CubeMove> solvingPairMoves = [];

            var positioningMoves = GetMovesToPositionTheCorner(color, cubeCopy);

            cubeCopy.ExecuteAlgorithm(positioningMoves);
            solvingPairMoves.AddRange(positioningMoves);

            var solution = F2LSolutions.GetF2lSolution(cubeCopy, color);

            cubeCopy.ExecuteAlgorithm(solution);
            solvingPairMoves.AddRange(solution);

            solvingF2LMoves.AddRange(MoveOptimizer.OptimizeMoves(solvingPairMoves));
        }

        return MoveOptimizer.OptimizeMoves(solvingF2LMoves);
    }

    private static List<CubeMove> GetMovesToPositionTheCorner(CubeColor firstColor, Cube cube)
    {
        var cubeCopy = cube.DeepCopy();

        var orientingMoves = OrientCubeToSolvePair(firstColor, cubeCopy);

        cubeCopy.ExecuteAlgorithm(orientingMoves);

        var cornerPosition = CornerPositionHelper.LocateCorners(cubeCopy).GetCornerPosition(firstColor);

        List<CubeMove> positioningMoves = cornerPosition.IsOnTop
            ? cornerPosition.Location switch
            {
                PieceLocation.FrontRight => [],
                PieceLocation.FrontLeft => [CubeMove.U_],
                PieceLocation.BackRight => [CubeMove.U],
                PieceLocation.BackLeft => [CubeMove.U2],

                _ => throw new NotImplementedException()
            }
            : cornerPosition.Location switch
            {
                PieceLocation.FrontLeft => [CubeMove.L_, CubeMove.U_, CubeMove.L],
                PieceLocation.FrontRight => [CubeMove.R, CubeMove.U_, CubeMove.R_],
                PieceLocation.BackRight => [CubeMove.B, CubeMove.U, CubeMove.B_],
                PieceLocation.BackLeft => [CubeMove.L, CubeMove.U2, CubeMove.L_],

                _ => throw new NotImplementedException()
            };

        return [.. orientingMoves, .. positioningMoves];
    }

    private static List<CubeMove> OrientCubeToSolvePair(CubeColor frontTargetColor, Cube cube)
    {
        CubeColor currentFrontColor = cube.Front.Face[1, 1];

        return currentFrontColor switch
        {
            CubeColor.Green => frontTargetColor switch
            {
                CubeColor.Green => [],
                CubeColor.Orange => [CubeMove.y],
                CubeColor.Blue => [CubeMove.y2],
                CubeColor.Red => [CubeMove.y_],

                _ => throw new NotImplementedException()
            },
            CubeColor.Orange => frontTargetColor switch
            {
                CubeColor.Green => [CubeMove.y_],
                CubeColor.Orange => [],
                CubeColor.Blue => [CubeMove.y],
                CubeColor.Red => [CubeMove.y2],

                _ => throw new NotImplementedException()
            },
            CubeColor.Blue => frontTargetColor switch
            {
                CubeColor.Green => [CubeMove.y2],
                CubeColor.Orange => [CubeMove.y_],
                CubeColor.Blue => [],
                CubeColor.Red => [CubeMove.y],

                _ => throw new NotImplementedException()
            },
            CubeColor.Red => frontTargetColor switch
            {
                CubeColor.Green => [CubeMove.y],
                CubeColor.Orange => [CubeMove.y2],
                CubeColor.Blue => [CubeMove.y_],
                CubeColor.Red => [],

                _ => throw new NotImplementedException()
            },

            _ => throw new NotImplementedException()
        };
    }

    private static bool IsPairInCorrectPlace(WhiteCornerPosition cornerPosition, NonYellowEdgePosition edgePosition, CubeColor firstColor, CubeColor frontFaceCenterColor)
    {
        var correctLocation = GetCorrectPieceLocation(firstColor, frontFaceCenterColor);

        bool isCornerInCorrectLocation = 
            !cornerPosition.IsOnTop &&
            cornerPosition.Location == GetCorrectPieceLocation(firstColor, frontFaceCenterColor) &&
            cornerPosition.WhiteStickerFaceAxis == FaceAxis.Y;

        bool isEdgeInCorrectLocation =
            !edgePosition.IsOnTop &&
            edgePosition.Location == GetCorrectPieceLocation(firstColor, frontFaceCenterColor) &&
            edgePosition.PrimaryColorFaceAxis == GetCorrectEdgeFaceAxis(frontFaceCenterColor);

        return isCornerInCorrectLocation && isEdgeInCorrectLocation;
    }

    private static FaceAxis GetCorrectEdgeFaceAxis(CubeColor frontFaceCenterColor)
    {
        return frontFaceCenterColor == CubeColor.Green || frontFaceCenterColor == CubeColor.Blue
            ? FaceAxis.Z
            : FaceAxis.X;
    }

    private static PieceLocation GetCorrectPieceLocation(CubeColor firstColor, CubeColor frontFaceCenterColor)
    {
        return frontFaceCenterColor switch
        {
            CubeColor.Green => firstColor switch
            {
                CubeColor.Green => PieceLocation.FrontRight,
                CubeColor.Orange => PieceLocation.BackRight,
                CubeColor.Blue => PieceLocation.BackLeft,
                CubeColor.Red => PieceLocation.FrontLeft,

                _ => throw new NotImplementedException()
            },
            CubeColor.Orange => firstColor switch
            {
                CubeColor.Orange => PieceLocation.FrontRight,
                CubeColor.Blue => PieceLocation.BackRight,
                CubeColor.Red => PieceLocation.BackLeft,
                CubeColor.Green => PieceLocation.FrontLeft,

                _ => throw new NotImplementedException()
            },
            CubeColor.Blue => firstColor switch
            {
                CubeColor.Blue => PieceLocation.FrontRight,
                CubeColor.Red => PieceLocation.BackRight,
                CubeColor.Green => PieceLocation.BackLeft,
                CubeColor.Orange => PieceLocation.FrontLeft,

                _ => throw new NotImplementedException()
            },
            CubeColor.Red => firstColor switch
            {
                CubeColor.Red => PieceLocation.FrontRight,
                CubeColor.Green => PieceLocation.BackRight,
                CubeColor.Orange => PieceLocation.BackLeft,
                CubeColor.Blue => PieceLocation.FrontLeft,

                _ => throw new NotImplementedException()
            },

            _ => throw new NotImplementedException()
        };
    }
}
