using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Solver.Solver;

namespace SolveCuber.UnitTests.Solver.Solver;

public class CubeSolverTests
{
    [Fact]
    public void SolveCube_ShouldReturnValidSolveObject()
    {
        Cube cube = new();
        cube.ExecuteAlgorithm(TestScrambles.NoCrossScramble);

        var solveResult = CubeSolver.SolveCube(cube);

        solveResult.Cross.ShouldNotBeNull();
        solveResult.F2L.ShouldNotBeNull();
        solveResult.OLL.ShouldNotBeNull();
        solveResult.PLL.ShouldNotBeNull();

        solveResult.MovesCount.ShouldBe(solveResult.Cross.Count + solveResult.F2L.Count + solveResult.OLL.Count + solveResult.PLL.Count);
    }

    [Fact]
    public void SolveCube_SolvesScrambledCube()
    {
        Cube cube = new();
        cube.ExecuteAlgorithm(TestScrambles.NoCrossScramble);

        var solveResult = CubeSolver.SolveCube(cube);

        IsCubeSolved(cube).ShouldBeTrue();
    }

    public static bool IsCubeSolved(Cube cube)
    {
        return IsFaceSolved(cube.Up) &&
               IsFaceSolved(cube.Down) &&
               IsFaceSolved(cube.Left) &&
               IsFaceSolved(cube.Right) &&
               IsFaceSolved(cube.Front) &&
               IsFaceSolved(cube.Back);
    }

    private static bool IsFaceSolved(CubeFace face)
    {
        var centerColor = face.Face[1, 1];

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (face.Face[row, col] != centerColor)
                {
                    return false;
                }
            }
        }

        return true;
    }
}
