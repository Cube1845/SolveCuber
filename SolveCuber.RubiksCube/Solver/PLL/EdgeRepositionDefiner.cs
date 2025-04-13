using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Solver.PLL.Models;

namespace SolveCuber.Solver.PLL;

internal class EdgeRepositionDefiner
{
    public static EdgesRepositionData DefineEdgesReposition(Cube cube)
    {
        return new
        (
            GetEdgeReposition(cube, EdgeLocation.Front),
            GetEdgeReposition(cube, EdgeLocation.Left),
            GetEdgeReposition(cube, EdgeLocation.Back),
            GetEdgeReposition(cube, EdgeLocation.Right)
        );
    }

    private static Reposition GetEdgeReposition(Cube cube, EdgeLocation edgeLocation)
    {
        var cubeCopy = cube.DeepCopy();

        var edgeLocationsOrder = GetEdgePositionsAfterClockwiseRotations(edgeLocation);

        int amountOfUMoves = 0;

        if (IsEdgeCorrectlyPlaced(cubeCopy, edgeLocation))
        {
            return Reposition.None;
        }

        foreach (var currentEdgeLocation in edgeLocationsOrder)
        {
            cubeCopy.ExecuteMove(CubeMove.U);
            amountOfUMoves++;

            if (IsEdgeCorrectlyPlaced(cubeCopy, currentEdgeLocation))
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

    private static List<EdgeLocation> GetEdgePositionsAfterClockwiseRotations(EdgeLocation currentEdgeLocation)
    {
        return currentEdgeLocation switch
        {
            EdgeLocation.Front => [EdgeLocation.Left, EdgeLocation.Back, EdgeLocation.Right],
            EdgeLocation.Left => [EdgeLocation.Back, EdgeLocation.Right, EdgeLocation.Front],
            EdgeLocation.Back => [EdgeLocation.Right, EdgeLocation.Front, EdgeLocation.Left],
            EdgeLocation.Right => [EdgeLocation.Front, EdgeLocation.Left, EdgeLocation.Back],

            _ => throw new NotImplementedException()
        };
    }

    private static bool IsEdgeCorrectlyPlaced(Cube cube, EdgeLocation cornerLocation)
    {
        return cornerLocation switch
        {
            EdgeLocation.Front => IsFrontEdgeCorrectlyPlaced(cube),
            EdgeLocation.Left => IsLeftEdgeCorrectlyPlaced(cube),
            EdgeLocation.Back => IsBackEdgeCorrectlyPlaced(cube),
            EdgeLocation.Right => IsRightEdgeCorrectlyPlaced(cube),

            _ => throw new NotImplementedException()
        };
    }

    private static bool IsFrontEdgeCorrectlyPlaced(Cube cube)
    {
        return cube.Up.Face[2, 1] == CubeColor.Yellow &&
            cube.Front.Face[0, 1] == cube.Front.Face[1, 1];
    }

    private static bool IsLeftEdgeCorrectlyPlaced(Cube cube)
    {
        return cube.Up.Face[1, 0] == CubeColor.Yellow &&
            cube.Left.Face[0, 1] == cube.Left.Face[1, 1];
    }

    private static bool IsBackEdgeCorrectlyPlaced(Cube cube)
    {
        return cube.Up.Face[0, 1] == CubeColor.Yellow &&
            cube.Back.Face[0, 1] == cube.Back.Face[1, 1];
    }

    private static bool IsRightEdgeCorrectlyPlaced(Cube cube)
    {
        return cube.Up.Face[1, 2] == CubeColor.Yellow &&
            cube.Right.Face[0, 1] == cube.Right.Face[1, 1];
    }
}
