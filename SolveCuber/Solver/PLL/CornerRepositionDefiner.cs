using SolveCuber.CubeModel.Models;
using SolveCuber.CubeModel;
using SolveCuber.Solver.Common;
using SolveCuber.Solver.PLL.Models;

namespace SolveCuber.Solver.PLL;

internal static class CornerRepositionDefiner
{
    public static CornersRepositionData DefineCornersReposition(Cube cube)
    {
        return new
        (
            GetCornerReposition(cube, PieceLocation.FrontRight),
            GetCornerReposition(cube, PieceLocation.FrontLeft),
            GetCornerReposition(cube, PieceLocation.BackRight),
            GetCornerReposition(cube, PieceLocation.BackLeft)
        );
    }

    private static Reposition GetCornerReposition(Cube cube, PieceLocation cornerLocation)
    {
        var cubeCopy = cube.DeepCopy();

        var cornerLocationsOrder = GetCornerPositionsAfterClockwiseRotations(cornerLocation);

        int amountOfUMoves = 0;

        if (IsCornerCorrectlyPlaced(cubeCopy, cornerLocation))
        {
            return Reposition.None;
        }

        foreach (var currentCornerLocation in cornerLocationsOrder)
        {
            cubeCopy.ExecuteMove(CubeMove.U);
            amountOfUMoves++;

            if (IsCornerCorrectlyPlaced(cubeCopy, currentCornerLocation))
            {
                break;
            }
        }

        return amountOfUMoves switch
        {
            0 => Reposition.None,
            1 => Reposition.Clockwise,
            2 => Reposition.Across,
            3 => Reposition.CounterClockwise,

            _ => throw new NotImplementedException()
        };
    }

    private static List<PieceLocation> GetCornerPositionsAfterClockwiseRotations(PieceLocation currentCornerLocation)
    {
        return currentCornerLocation switch
        {
            PieceLocation.FrontRight => [PieceLocation.FrontLeft, PieceLocation.BackLeft, PieceLocation.BackRight],
            PieceLocation.FrontLeft => [PieceLocation.BackLeft, PieceLocation.BackRight, PieceLocation.FrontRight],
            PieceLocation.BackLeft => [PieceLocation.BackRight, PieceLocation.FrontRight, PieceLocation.FrontLeft],
            PieceLocation.BackRight => [PieceLocation.FrontRight, PieceLocation.FrontLeft, PieceLocation.BackLeft],

            _ => throw new NotImplementedException()
        };
    }

    private static bool IsCornerCorrectlyPlaced(Cube cube, PieceLocation cornerLocation)
    {
        return cornerLocation switch
        {
            PieceLocation.FrontRight => IsFrontRightCornerCorrectlyPlaced(cube),
            PieceLocation.FrontLeft => IsFrontLeftCornerCorrectlyPlaced(cube),
            PieceLocation.BackRight => IsBackRightCornerCorrectlyPlaced(cube),
            PieceLocation.BackLeft => IsBackLeftCornerCorrectlyPlaced(cube),

            _ => throw new NotImplementedException()
        };
    }

    private static bool IsFrontRightCornerCorrectlyPlaced(Cube cube)
    {
        return cube.Up.Face[2, 2] == CubeColor.Yellow &&
            cube.Front.Face[0, 2] == cube.Front.Face[1, 1] &&
            cube.Right.Face[0, 0] == cube.Right.Face[1, 1];
    }

    private static bool IsFrontLeftCornerCorrectlyPlaced(Cube cube)
    {
        return cube.Up.Face[2, 0] == CubeColor.Yellow &&
            cube.Front.Face[0, 0] == cube.Front.Face[1, 1] &&
            cube.Left.Face[0, 2] == cube.Left.Face[1, 1];
    }

    private static bool IsBackRightCornerCorrectlyPlaced(Cube cube)
    {
        return cube.Up.Face[0, 2] == CubeColor.Yellow &&
            cube.Back.Face[0, 0] == cube.Back.Face[1, 1] &&
            cube.Right.Face[0, 2] == cube.Right.Face[1, 1];
    }

    private static bool IsBackLeftCornerCorrectlyPlaced(Cube cube)
    {
        return cube.Up.Face[0, 0] == CubeColor.Yellow &&
            cube.Back.Face[0, 2] == cube.Back.Face[1, 1] &&
            cube.Left.Face[0, 0] == cube.Left.Face[1, 1];
    }
}
