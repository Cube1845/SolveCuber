using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Solver.WhiteCross;

namespace SolveCuber.UnitTests.Solver.WhiteCross;

public class WhiteCrossSolverTests
{
    [Fact]
    public void IsCrossSolved_ShouldReturnTrue_WhenAllEdgesInCorrectPlace()
    {
        Cube cube = new();

        var result = WhiteCrossSolver.IsCrossSolved(cube);

        result.ShouldBeTrue();
    }

    [Fact]
    public void IsCrossSolved_ShouldReturnFalse_WhenAnyEdgeIncorrect()
    {
        Cube cube = new();
        cube.ExecuteAlgorithm(TestScrambles.NoCrossScramble);

        var result = WhiteCrossSolver.IsCrossSolved(cube);

        result.ShouldBeFalse();
    }

    [Fact]
    public void SolveCross_ShouldReturnEmptyList_WhenCrossIsAlreadySolved()
    {
        Cube cube = new();

        var result = WhiteCrossSolver.SolveCross(cube);

        result.ShouldBeEmpty();
    }

    [Fact]
    public void SolveCross_ShouldReturnMoves_WhenCrossIsNotSolved()
    {
        Cube cube = new();
        cube.ExecuteAlgorithm(TestScrambles.NoCrossScramble);

        var result = WhiteCrossSolver.SolveCross(cube);

        result.Count.ShouldBeGreaterThan(0);
        WhiteCrossSolver.IsCrossSolved(cube).ShouldBeTrue();
    }

    [Fact]
    public void SolveCross_ShouldWorkRegardlessOfInitialOrientation()
    {
        Cube cube = new();
        cube.ExecuteAlgorithm([.. TestScrambles.NoCrossScramble, CubeMove.x2, CubeMove.y_]);

        var result = WhiteCrossSolver.SolveCross(cube);

        result.ShouldNotBeEmpty();
        WhiteCrossSolver.IsCrossSolved(cube).ShouldBeTrue();
    }
}