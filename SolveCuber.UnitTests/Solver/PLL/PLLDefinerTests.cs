using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Solver.PLL;

namespace SolveCuber.UnitTests.Solver.PLL;

public class PLLDefinerTests
{
    [Theory]
    [InlineData(SolveCuber.Solver.PLL.Models.PLL.T)]
    [InlineData(SolveCuber.Solver.PLL.Models.PLL.F)]
    [InlineData(SolveCuber.Solver.PLL.Models.PLL.Ra)]
    [InlineData(SolveCuber.Solver.PLL.Models.PLL.H)]
    internal void GetPLL_ShouldReturnCorrectPLLAlgorithm_WhenPLLOccurs(SolveCuber.Solver.PLL.Models.PLL pllCase)
    {
        Cube cube = new();
        cube.ExecuteMove(CubeMove.z2);

        var pllMoves = PLLAlgorithms.GetPLL(pllCase);
        cube.ExecuteAlgorithm(pllMoves);

        var pll = PLLDefiner.GetPLL(cube);

        pll.ShouldNotBeNull();
        pll.ShouldBe(pllMoves);
    }

    [Fact]
    public void GetPLL_ShouldReturnEmptyList_WhenCubeIsSolved()
    {
        Cube cube = new();
        cube.ExecuteMove(CubeMove.z2);

        var pll = PLLDefiner.GetPLL(cube);

        pll.ShouldNotBeNull();
        pll.ShouldBeEmpty();
    }
}
