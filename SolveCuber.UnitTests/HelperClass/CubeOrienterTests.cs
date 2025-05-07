using SolveCuber.Common;
using SolveCuber.CubeModel.Models;
using SolveCuber.CubeModel;

namespace SolveCuber.UnitTests.HelperClass;

public class CubeOrienterTests
{
    [Fact]
    public void OrientCube_WithUpColor_ShouldOrientCubeCorrectly()
    {
        Cube cube = new();

        var moves = CubeOrienter.OrientCube(cube, CubeColor.Yellow);

        moves.ShouldNotBeNull();
        cube.Up.Face[1, 1].ShouldBe(CubeColor.Yellow);
    }

    [Fact]
    public void OrientCube_WithFrontAndUpColor_ShouldOrientCubeCorrectly()
    {
        Cube cube = new();

        var moves = CubeOrienter.OrientCube(cube, CubeColor.Blue, CubeColor.Yellow);

        moves.ShouldNotBeNull();
        cube.Up.Face[1, 1].ShouldBe(CubeColor.Yellow);
        cube.Front.Face[1, 1].ShouldBe(CubeColor.Blue);
    }

    [Theory]
    [InlineData(CubeColor.Red, CubeColor.Orange)]
    [InlineData(CubeColor.Blue, CubeColor.Green)]
    [InlineData(CubeColor.White, CubeColor.Yellow)]
    public void OrientCube_WithIncorrectColors_ShouldThrowException(CubeColor frontColor, CubeColor upColor)
    {

        Cube cube = new();

        var action = () =>
        {
            CubeOrienter.OrientCube(cube, frontColor, upColor);
        };

        action.ShouldThrow<RubiksCubeException>();
    }
}
