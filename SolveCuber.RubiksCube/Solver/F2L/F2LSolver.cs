using SolveCuber.Common;
using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Solver.F2L.Positioning;
using SolveCuber.Solver.F2L.Positioning.Corners;
using SolveCuber.Solver.F2L.Positioning.Edges;

namespace SolveCuber.Solver.F2L;

public static class F2LSolver
{
    // Those are the first colors of the non white and yellow colors,
    // for example Green means GreenOrange or Red means RedGreen (as in the WhiteCornerData or NonYellowEdgesData)
    private readonly static List<List<CubeColor>> _pairSolvingOrders =
    [
        [CubeColor.Green, CubeColor.Orange, CubeColor.Red, CubeColor.Blue],
        [CubeColor.Green, CubeColor.Orange, CubeColor.Blue, CubeColor.Red],
        [CubeColor.Green, CubeColor.Red, CubeColor.Blue, CubeColor.Orange],
        [CubeColor.Green, CubeColor.Red, CubeColor.Orange, CubeColor.Blue],
        [CubeColor.Green, CubeColor.Blue, CubeColor.Orange, CubeColor.Red],
        [CubeColor.Green, CubeColor.Blue, CubeColor.Red, CubeColor.Orange],

        [CubeColor.Orange, CubeColor.Green, CubeColor.Red, CubeColor.Blue],
        [CubeColor.Orange, CubeColor.Green, CubeColor.Blue, CubeColor.Red],
        [CubeColor.Orange, CubeColor.Red, CubeColor.Blue, CubeColor.Green],
        [CubeColor.Orange, CubeColor.Red, CubeColor.Green, CubeColor.Blue],
        [CubeColor.Orange, CubeColor.Blue, CubeColor.Green, CubeColor.Red],
        [CubeColor.Orange, CubeColor.Blue, CubeColor.Red, CubeColor.Green],

        [CubeColor.Red, CubeColor.Orange, CubeColor.Green, CubeColor.Blue],
        [CubeColor.Red, CubeColor.Orange, CubeColor.Blue, CubeColor.Green],
        [CubeColor.Red, CubeColor.Green, CubeColor.Blue, CubeColor.Orange],
        [CubeColor.Red, CubeColor.Green, CubeColor.Orange, CubeColor.Blue],
        [CubeColor.Red, CubeColor.Blue, CubeColor.Orange, CubeColor.Green],
        [CubeColor.Red, CubeColor.Blue, CubeColor.Green, CubeColor.Orange],

        [CubeColor.Blue, CubeColor.Orange, CubeColor.Red, CubeColor.Green],
        [CubeColor.Blue, CubeColor.Orange, CubeColor.Green, CubeColor.Red],
        [CubeColor.Blue, CubeColor.Red, CubeColor.Green, CubeColor.Orange],
        [CubeColor.Blue, CubeColor.Red, CubeColor.Orange, CubeColor.Green],
        [CubeColor.Blue, CubeColor.Green, CubeColor.Orange, CubeColor.Red],
        [CubeColor.Blue, CubeColor.Green, CubeColor.Red, CubeColor.Orange],
    ];

    public static List<CubeMove> SolveF2L(Cube cube)
    {
        if (IsF2lSolved(cube))
        {
            return [];
        }

        var solutionWithLeastMoves = GetSolutionWithLeastMoves(cube);

        cube.ExecuteAlgorithm(solutionWithLeastMoves);

        return solutionWithLeastMoves;
    }

    private static List<CubeMove> GetSolutionWithLeastMoves(Cube cube)
    {
        List<List<CubeMove>> solutions = [];

        foreach (var colorOrder in _pairSolvingOrders)
        {
            var solution = GetSolvingF2LMoves(cube, colorOrder);
            solutions.Add(solution);
        }

        var orderedSolutions = solutions.OrderBy(s => s.Count).ToList();

        return orderedSolutions[0];
    }

    private static List<CubeMove> GetSolvingF2LMoves(Cube cube, List<CubeColor> colorOrder)
    {
        List<CubeMove> solvingF2LMoves = [];

        foreach (var color in colorOrder)
        {
            var cornerData = CornerPositionHelper.LocateCorners(cube).GetCornerPosition(color);
            var edgeData = EdgePositionHelper.LocateEdges(cube).GetEdgePosition(color);

            bool isInCorrectPlace =
                IsPairInCorrectPlace(cornerData, edgeData, color, cube.Front.Face[1, 1]);

            if (isInCorrectPlace)
            {
                continue;
            }

            List<CubeMove> solvingPairMoves = [];

            solvingPairMoves.AddRange(GetMovesToPositionTheCorner(color, cube));
            solvingPairMoves.AddRange(F2LSolutions.GetF2lSolution(cornerData, edgeData, color));

            solvingF2LMoves.AddRange(solvingPairMoves);
        }

        return MoveOptimizer.OptimizeMoves(solvingF2LMoves);
    }

    private static List<CubeMove> GetMovesToPositionTheCorner(CubeColor firstColor, Cube cube)
    {
        var cubeCopy = cube.DeepCopy();

        var orientingMoves = OrientCubeToSolvePair(firstColor, cube);

        cubeCopy.ExecuteAlgorithm(orientingMoves);

        var cornerPosition = CornerPositionHelper.LocateCorners(cube).GetCornerPosition(firstColor);

        List<CubeMove> positioningMoves = cornerPosition.IsOnTop
            ? cornerPosition.Location switch
            {
                PieceLocation.FrontLeft => [CubeMove.U_],
                PieceLocation.BackRight => [CubeMove.U],
                PieceLocation.BackLeft => [CubeMove.U2],

                _ => []
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
        var cubeCopy = cube.DeepCopy();

        CubeColor currentFrontColor = cube.Front.Face[1, 1];

        List<CubeMove> rotations = [];

        while (currentFrontColor != frontTargetColor)
        {
            cubeCopy.ExecuteMove(CubeMove.y);
            rotations.Add(CubeMove.y);

            currentFrontColor = cubeCopy.Front.Face[1, 1];
        }

        return MoveOptimizer.OptimizeMoves(rotations);
    }

    private static bool IsF2lSolved(Cube cube)
    {
        var cornersData = CornerPositionHelper.LocateCorners(cube);
        var edgesData = EdgePositionHelper.LocateEdges(cube);

        var frontFaceCenterColor = cube.Front.Face[1, 1];

        return IsPairInCorrectPlace(cornersData.GreenOrange, edgesData.GreenOrange, CubeColor.Green, frontFaceCenterColor)
            && IsPairInCorrectPlace(cornersData.OrangeBlue, edgesData.OrangeBlue, CubeColor.Orange, frontFaceCenterColor)
            && IsPairInCorrectPlace(cornersData.BlueRed, edgesData.BlueRed, CubeColor.Blue, frontFaceCenterColor)
            && IsPairInCorrectPlace(cornersData.RedGreen, edgesData.RedGreen, CubeColor.Red, frontFaceCenterColor);
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
