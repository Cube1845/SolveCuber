using SolveCuber.Common;
using SolveCuber.CubeModel.Models;
using SolveCuber.Solver.Common;
using SolveCuber.Solver.OLL;

namespace SolveCuber.UnitTests.Solver.OLL;

public class OLLExecuterTests
{
    [Fact]
    public void ExecuteOLL_ShouldThrowIfF2LIsNotSolved()
    {
        Cube cube = new();
        cube.ExecuteAlgorithm(TestScrambles.NoCrossScramble);

        var action = () =>
        {
            OLLExecuter.ExecuteOLL(cube);
        };

        action.ShouldThrow<RubiksCubeException>();
    }

    [Fact]
    public void ExecuteOLL_ShouldApplyOLLAlgorithm_WhenF2LIsSolved()
    {
        Cube cube = new();
        cube.ExecuteAlgorithm(TestScrambles.F2LSolvedScramble);

        var oll = OLLExecuter.ExecuteOLL(cube);

        oll.ShouldNotBeEmpty();
    }

    [Fact]
    public void ExecuteOLL_OrientsPiecesCorrectly()
    {
        Cube cube = new();
        cube.ExecuteAlgorithm(TestScrambles.F2LSolvedScramble);

        OLLExecuter.ExecuteOLL(cube);

        foreach (var color in cube.Up.Face)
        {
            color.ShouldBe(CubeModel.CubeColor.Yellow);
        }
    }
}
