using SolveCuber.Common;
using SolveCuber.CubeModel.Models;
using SolveCuber.Solver.PLL;

namespace SolveCuber.UnitTests.Solver.PLL;

public class PLLExecuterTests
{
    [Fact]
    public void ExecutePLL_ThrowsIfTopLayerNotOriented()
    {
        Cube cube = new();
        cube.ExecuteAlgorithm(TestScrambles.F2LSolvedScramble);

        var action = () =>
        {
            PLLExecuter.ExecutePLL(cube);
        };

        action.ShouldThrow<RubiksCubeException>();
    }

    [Fact]
    public void ExecutePLL_ReturnsSolutionForOrientedCube()
    {
        Cube cube = new();

        cube.ExecuteAlgorithm(TestScrambles.OLLExecutedScramble);

        var moves = PLLExecuter.ExecutePLL(cube);

        moves.ShouldNotBeEmpty();
        IsCubeSolved(cube).ShouldBeTrue();
    }

    private bool IsCubeSolved(Cube cube)
    {
        var frontColor = cube.Front.Face[1, 1];
        var isFrontSolved =
            cube.Front.Face[0, 0] == frontColor &&
            cube.Front.Face[0, 1] == frontColor &&
            cube.Front.Face[0, 2] == frontColor;

        var rightColor = cube.Right.Face[1, 1];
        var isRightSolved =
            cube.Right.Face[0, 0] == rightColor &&
            cube.Right.Face[0, 1] == rightColor &&
            cube.Right.Face[0, 2] == rightColor;

        var backColor = cube.Back.Face[1, 1];
        var isBackSolved =
            cube.Back.Face[0, 0] == backColor &&
            cube.Back.Face[0, 1] == backColor &&
            cube.Back.Face[0, 2] == backColor;

        var leftColor = cube.Left.Face[1, 1];
        var isLeftSolved =
            cube.Left.Face[0, 0] == leftColor &&
            cube.Left.Face[0, 1] == leftColor &&
            cube.Left.Face[0, 2] == leftColor;

        return isFrontSolved && isRightSolved && isBackSolved && isLeftSolved;
    }
}