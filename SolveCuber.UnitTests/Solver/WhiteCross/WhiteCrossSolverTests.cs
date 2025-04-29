using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Solver.WhiteCross;

namespace SolveCuber.UnitTests.Solver.WhiteCross;

public class WhiteCrossSolverTests
{
    private readonly List<CubeMove> _scramble = [CubeMove.U, CubeMove.R_, CubeMove.B, CubeMove.L, CubeMove.B, CubeMove.L, CubeMove.D2, CubeMove.R_, CubeMove.L2, CubeMove.F2, CubeMove.U, CubeMove.B, CubeMove.L_, CubeMove.B_, CubeMove.R, CubeMove.L2, CubeMove.F, CubeMove.B, CubeMove.D, CubeMove.B, CubeMove.D2, CubeMove.F2, CubeMove.B2, CubeMove.R_, CubeMove.U];

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
        cube.ExecuteAlgorithm(_scramble);

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
        cube.ExecuteAlgorithm(_scramble);

        var result = WhiteCrossSolver.SolveCross(cube);

        result.Count.ShouldBeGreaterThan(0);
        WhiteCrossSolver.IsCrossSolved(cube).ShouldBeTrue();
    }

    [Fact]
    public void SolveCross_ShouldWorkRegardlessOfInitialOrientation()
    {
        Cube cube = new();
        cube.ExecuteAlgorithm([.. _scramble, CubeMove.x2, CubeMove.y_]);

        var result = WhiteCrossSolver.SolveCross(cube);

        result.ShouldNotBeEmpty();
        WhiteCrossSolver.IsCrossSolved(cube).ShouldBeTrue();
    }
}