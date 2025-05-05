using SolveCuber.Common;
using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Solver.F2L;

namespace SolveCuber.UnitTests.Solver.F2L;

public class F2LSolverTests
{
    [Fact]
    public void SolveF2L_ShouldThrow_WhenWhiteCrossNotSolved()
    {
        Cube cube = new();

        cube.ExecuteAlgorithm([CubeMove.R_, CubeMove.L, CubeMove.F, CubeMove.B_]);

        var action = () =>
        {
            F2LSolver.SolveF2L(cube);
        };

        action.ShouldThrow<RubiksCubeException>();
    }

    [Fact]
    public void SolveF2L_ShouldReturnEmptyList_WhenF2LIsAlreadySolved()
    {
        Cube cube = new();

        var result = F2LSolver.SolveF2L(cube);

        result.ShouldBeEmpty();
    }

    [Fact]
    public void SolveF2L_ShouldReturnMoves_WhenF2LIsNotSolved()
    {
        Cube cube = new();

        cube.ExecuteAlgorithm(TestScrambles.CrossSolvedScramble);

        var result = F2LSolver.SolveF2L(cube);

        result.ShouldNotBeEmpty();

        F2LSolver.IsF2lSolved(cube).ShouldBeTrue();
    }

    [Fact]
    public void IsF2lSolved_ShouldReturnTrue_WhenAllPairsAreCorrect()
    {
        Cube cube = new();

        cube.ExecuteAlgorithm(TestScrambles.F2LSolvedScramble);

        var result = F2LSolver.IsF2lSolved(cube);

        result.ShouldBeTrue();
    }

    [Fact]
    public void IsF2lSolved_ShouldReturnFalse_WhenAnyPairIsIncorrect()
    {
        Cube cube = new();

        cube.ExecuteAlgorithm(TestScrambles.NoCrossScramble);

        var result = F2LSolver.IsF2lSolved(cube);

        result.ShouldBeFalse();
    }
}