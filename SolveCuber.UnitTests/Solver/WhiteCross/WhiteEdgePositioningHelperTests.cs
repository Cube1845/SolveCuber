using SolveCuber.CubeModel;
using SolveCuber.Solver.WhiteCross;

namespace SolveCuber.UnitTests.Solver.WhiteCross;

public class WhiteEdgePositioningHelperTests
{
    [Theory]
    [InlineData(CubeColor.Green, WhiteEdgeLocation.UpFront, true)]
    [InlineData(CubeColor.Orange, WhiteEdgeLocation.UpLeft, true)]
    [InlineData(CubeColor.Red, WhiteEdgeLocation.UpRight, true)]
    [InlineData(CubeColor.Blue, WhiteEdgeLocation.UpBack, true)]
    [InlineData(CubeColor.Green, WhiteEdgeLocation.UpLeft, false)]
    [InlineData(CubeColor.Red, WhiteEdgeLocation.DownFront, false)]
    internal void IsInCorrectPlace_ShouldReturnExpectedResult(CubeColor color, WhiteEdgeLocation location, bool expected)
    {
        var result = WhiteEdgePositioningHelper.IsInCorrectPlace(color, location);

        result.ShouldBe(expected);
    }

    [Fact]
    public void IsInCorrectPlace_ShouldThrowForUnknownColor()
    {
        var action = () =>
        {
            WhiteEdgePositioningHelper.IsInCorrectPlace((CubeColor)999, WhiteEdgeLocation.UpFront);
        };

        action.ShouldThrow<NotImplementedException>();
    }

    [Theory]
    [InlineData(CubeColor.Green, WhiteEdgeLocation.UpLeft, new[] { CubeMove.L2, CubeMove.D, CubeMove.F2 })]
    [InlineData(CubeColor.Orange, WhiteEdgeLocation.UpBack, new[] { CubeMove.B2, CubeMove.D, CubeMove.L2 })]
    [InlineData(CubeColor.Red, WhiteEdgeLocation.DownBack, new[] { CubeMove.D_, CubeMove.R2 })]
    [InlineData(CubeColor.Blue, WhiteEdgeLocation.LeftDown, new[] { CubeMove.L, CubeMove.B_, CubeMove.L_ })]
    internal void GetWhiteEdgePositioningMoves_ShouldReturnCorrectMoves(CubeColor color, WhiteEdgeLocation location, CubeMove[] expectedMoves)
    {
        var result = WhiteEdgePositioningHelper.GetWhiteEdgePositioningMoves(location, color);

        result.ShouldBe(expectedMoves);
    }

    [Fact]
    public void GetWhiteEdgePositioningMoves_ShouldThrowForUnknownColor()
    {
        var action = () =>
        {
            WhiteEdgePositioningHelper.GetWhiteEdgePositioningMoves(WhiteEdgeLocation.UpFront, (CubeColor)999);
        };

        action.ShouldThrow<NotImplementedException>();
    }
}
