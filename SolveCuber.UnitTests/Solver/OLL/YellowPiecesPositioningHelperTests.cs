using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Solver.Common;
using SolveCuber.Solver.OLL;

namespace SolveCuber.UnitTests.Solver.OLL;

public class YellowPiecesPositioningHelperTests
{
    [Fact]
    public void GetYellowPiecesFaceAxis_ShouldReturnCorrectDimensions()
    {
        Cube cube = new();

        var axisGrid = YellowPiecesPositioningHelper.GetYellowPiecesFaceAxis(cube);

        axisGrid.GetLength(0).ShouldBe(3);
        axisGrid.GetLength(1).ShouldBe(3);
        axisGrid.GetLength(1).ShouldBe(3);
    }

    [Fact]
    public void GetYellowPiecesFaceAxis_ShouldMapAllTopStickersToYAxis()
    {
        Cube cube = new();
        cube.ExecuteMove(CubeMove.z2);

        var axisGrid = YellowPiecesPositioningHelper.GetYellowPiecesFaceAxis(cube);

        foreach (var axis in axisGrid)
        {
            axis.ShouldBe(FaceAxis.Y);
        }
    }
}
