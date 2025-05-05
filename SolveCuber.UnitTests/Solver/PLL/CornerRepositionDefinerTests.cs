using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Solver.PLL;
using SolveCuber.Solver.PLL.Models;

namespace SolveCuber.UnitTests.Solver.PLL;

public class CornerRepositionDefinerTests
{
    [Fact]
    public void DefineCornersReposition_ShouldReturnNone_ForSolvedCube()
    {
        Cube cube = new();
        cube.ExecuteMove(CubeMove.z2);

        var result = CornerRepositionDefiner.DefineCornersReposition(cube);

        result.FrontRight.ShouldBe(Reposition.None);
        result.FrontLeft.ShouldBe(Reposition.None);
        result.BackRight.ShouldBe(Reposition.None);
        result.BackLeft.ShouldBe(Reposition.None);
    }

    [Fact]
    public void DefineCornersReposition_ShouldDetectClockwiseShift()
    {
        Cube cube = new();
        cube.ExecuteAlgorithm([CubeMove.z2, CubeMove.U]);

        var result = CornerRepositionDefiner.DefineCornersReposition(cube);

        result.FrontRight.ShouldBe(Reposition.CounterClockwise);
        result.FrontLeft.ShouldBe(Reposition.CounterClockwise);
        result.BackRight.ShouldBe(Reposition.CounterClockwise);
        result.BackLeft.ShouldBe(Reposition.CounterClockwise);
    }

    [Fact]
    public void DefineCornersReposition_ShouldDetectAcrossShift()
    {
        Cube cube = new();
        cube.ExecuteAlgorithm([CubeMove.z2, CubeMove.U2]);

        var result = CornerRepositionDefiner.DefineCornersReposition(cube);

        result.FrontRight.ShouldBe(Reposition.Across);
        result.FrontLeft.ShouldBe(Reposition.Across);
        result.BackRight.ShouldBe(Reposition.Across);
        result.BackLeft.ShouldBe(Reposition.Across);
    }
}