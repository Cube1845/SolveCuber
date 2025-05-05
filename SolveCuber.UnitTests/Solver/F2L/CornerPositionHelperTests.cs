using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Solver.Common;
using SolveCuber.Solver.F2L.Positioning.Corners;

namespace SolveCuber.UnitTests.Solver.F2L;

public class CornerPositionHelperTests
{
    [Fact]
    public void LocateCorners_ShouldIdentifyAllFourWhiteCornerPairs()
    {
        Cube cube = new();
        cube.ExecuteMove(CubeMove.z2);

        var result = CornerPositionHelper.LocateCorners(cube);

        result.GreenOrange.Location.ShouldBe(PieceLocation.FrontRight);
        result.OrangeBlue.Location.ShouldBe(PieceLocation.BackRight);
        result.BlueRed.Location.ShouldBe(PieceLocation.BackLeft);
        result.RedGreen.Location.ShouldBe(PieceLocation.FrontLeft);

        result.GreenOrange.IsOnTop.ShouldBeFalse();
        result.OrangeBlue.IsOnTop.ShouldBeFalse();
        result.BlueRed.IsOnTop.ShouldBeFalse();
        result.RedGreen.IsOnTop.ShouldBeFalse();

        result.GreenOrange.WhiteStickerFaceAxis.ShouldBe(FaceAxis.Y);
        result.OrangeBlue.WhiteStickerFaceAxis.ShouldBe(FaceAxis.Y);
        result.BlueRed.WhiteStickerFaceAxis.ShouldBe(FaceAxis.Y);
        result.RedGreen.WhiteStickerFaceAxis.ShouldBe(FaceAxis.Y);
    }
}
