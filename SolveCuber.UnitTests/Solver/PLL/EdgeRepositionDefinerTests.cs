using SolveCuber.CubeModel;
using SolveCuber.Solver.PLL.Models;
using SolveCuber.Solver.PLL;
using SolveCuber.CubeModel.Models;

namespace SolveCuber.UnitTests.Solver.PLL;

public class EdgeRepositionDefinerTests
{
    [Fact]
    public void DefineEdgesReposition_ShouldReturnNone_ForSolvedCube()
    {
        Cube cube = new();
        cube.ExecuteMove(CubeMove.z2);

        var result = EdgeRepositionDefiner.DefineEdgesReposition(cube);

        result.Front.ShouldBe(Reposition.None);
        result.Left.ShouldBe(Reposition.None);
        result.Back.ShouldBe(Reposition.None);
        result.Right.ShouldBe(Reposition.None);
    }

    [Fact]
    public void DefineEdgesReposition_ShouldDetectClockwiseShift()
    {
        Cube cube = new();
        cube.ExecuteAlgorithm([CubeMove.z2, CubeMove.U_]);

        var result = EdgeRepositionDefiner.DefineEdgesReposition(cube);

        result.Front.ShouldBe(Reposition.Clockwise);
        result.Left.ShouldBe(Reposition.Clockwise);
        result.Back.ShouldBe(Reposition.Clockwise);
        result.Right.ShouldBe(Reposition.Clockwise);
    }

    [Fact]
    public void DefineEdgesReposition_ShouldDetectAcrossShift()
    {
        Cube cube = new();
        cube.ExecuteAlgorithm([CubeMove.z2, CubeMove.U2]);

        var result = EdgeRepositionDefiner.DefineEdgesReposition(cube);

        result.Front.ShouldBe(Reposition.Across);
        result.Left.ShouldBe(Reposition.Across);
        result.Back.ShouldBe(Reposition.Across);
        result.Right.ShouldBe(Reposition.Across);
    }
}
