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

    public static List<CubeMove> SolveF2l(Cube cube)
    {
        foreach (var color in _pairSolvingOrders)
        {

        }

        return [];
    }

    private static List<CubeMove> GetSolvingF2LMoves(Cube cube, List<CubeColor> colorOrder)
    {
        var cornersData = CornerPositionHelper.LocateCorners(cube);
        var edgesData = EdgePositionHelper.LocateEdges(cube);

        var cubeCopy = cube.DeepCopy();

        foreach (var color in colorOrder)
        {
            
        }

        return [];
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

    private static bool IsPairInCorrectPlace(WhiteCornerPosition cornerPosition, NonYellowEdgePosition edgePosition, CubeColor primaryColor, CubeColor secondaryColor)
    {
        bool isCornerInCorrectPlace;
        bool isEdgeInCorrectPlace;

        if (primaryColor == CubeColor.Red || primaryColor == CubeColor.Orange || secondaryColor == CubeColor.Green || secondaryColor == CubeColor.Blue)
        {
            throw new Exception("Primary colors are blue and green, secondary colors are red and orange.");
        }

        if (primaryColor == CubeColor.Green)
        {
            if (secondaryColor == CubeColor.Orange)
            {
                isCornerInCorrectPlace = !cornerPosition.IsOnTop &&
                    cornerPosition.WhiteStickerFaceAxis == FaceAxis.Y &&
                    cornerPosition.Location == PieceLocation.FrontRight;

                isEdgeInCorrectPlace = !edgePosition.IsOnTop &&
                    edgePosition.PrimaryColorFaceAxis == FaceAxis.Z &&
                    edgePosition.Location == PieceLocation.FrontRight;
            }
            else
            {
                isCornerInCorrectPlace = !cornerPosition.IsOnTop &&
                    cornerPosition.WhiteStickerFaceAxis == FaceAxis.Y &&
                    cornerPosition.Location == PieceLocation.FrontLeft;

                isEdgeInCorrectPlace = !edgePosition.IsOnTop &&
                    edgePosition.PrimaryColorFaceAxis == FaceAxis.Z &&
                    edgePosition.Location == PieceLocation.FrontLeft;
            }
        }
        else
        {
            if (secondaryColor == CubeColor.Orange)
            {
                isCornerInCorrectPlace = !cornerPosition.IsOnTop &&
                    cornerPosition.WhiteStickerFaceAxis == FaceAxis.Y &&
                    cornerPosition.Location == PieceLocation.BackRight;

                isEdgeInCorrectPlace = !edgePosition.IsOnTop &&
                    edgePosition.PrimaryColorFaceAxis == FaceAxis.Z &&
                    edgePosition.Location == PieceLocation.BackRight;
            }
            else
            {
                isCornerInCorrectPlace = !cornerPosition.IsOnTop &&
                    cornerPosition.WhiteStickerFaceAxis == FaceAxis.Y &&
                    cornerPosition.Location == PieceLocation.BackLeft;

                isEdgeInCorrectPlace = !edgePosition.IsOnTop &&
                    edgePosition.PrimaryColorFaceAxis == FaceAxis.Z &&
                    edgePosition.Location == PieceLocation.BackLeft;
            }
        }

        return isCornerInCorrectPlace && isEdgeInCorrectPlace;
    }
}
