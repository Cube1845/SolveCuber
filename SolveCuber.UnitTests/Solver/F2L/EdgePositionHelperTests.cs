using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Solver.Common;
using SolveCuber.Solver.F2L.Positioning.Edges;

namespace SolveCuber.UnitTests.Solver.F2L;

public class EdgePositionHelperTests
{
    [Fact]
    public void LocateEdges_ShouldIdentifyAllFourEdgePairs()
    {
        Cube cube = new();
        cube.ExecuteMove(CubeMove.z2);

        var result = EdgePositionHelper.LocateEdges(cube);

        result.GreenOrange.IsOnTop.ShouldBeFalse();
        result.OrangeBlue.IsOnTop.ShouldBeFalse();
        result.BlueRed.IsOnTop.ShouldBeFalse();
        result.RedGreen.IsOnTop.ShouldBeFalse();

        result.GreenOrange.PrimaryColorFaceAxis.ShouldBe(FaceAxis.Z);
        result.OrangeBlue.PrimaryColorFaceAxis.ShouldBe(FaceAxis.Z);
        result.BlueRed.PrimaryColorFaceAxis.ShouldBe(FaceAxis.Z);
        result.RedGreen.PrimaryColorFaceAxis.ShouldBe(FaceAxis.Z);

        result.GreenOrange.Location.ShouldBe(PieceLocation.FrontRight);
        result.OrangeBlue.Location.ShouldBe(PieceLocation.BackRight);
        result.BlueRed.Location.ShouldBe(PieceLocation.BackLeft);
        result.RedGreen.Location.ShouldBe(PieceLocation.FrontLeft);
    }
}
