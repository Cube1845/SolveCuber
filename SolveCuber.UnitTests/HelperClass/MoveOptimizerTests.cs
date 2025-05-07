using SolveCuber.Common;
using SolveCuber.CubeModel;

namespace SolveCuber.UnitTests.HelperClass;

public class MoveOptimizerTests
{
    [Fact]
    public void OptimizeMoves_EmptyList_ReturnsEmpty()
    {
        var result = MoveOptimizer.OptimizeMoves([]);

        result.ShouldBeEmpty();
    }

    [Fact]
    public void OptimizeMoves_OppositeMoves_CancelsThem()
    {
        List<CubeMove> moves = [CubeMove.U, CubeMove.U_];

        var result = MoveOptimizer.OptimizeMoves(moves);

        result.ShouldBeEmpty();
    }

    [Fact]
    public void OptimizeMoves_SameMoves_CombinesToDoubleMove()
    {
        List<CubeMove> moves = [CubeMove.R, CubeMove.R];

        var result = MoveOptimizer.OptimizeMoves(moves);

        result.ShouldHaveSingleItem();
        result[0].ShouldBe(CubeMove.R2);
    }

    [Fact]
    public void OptimizeMoves_DoubleAndNormal_CombinesToInverse()
    {
        List<CubeMove> moves = [CubeMove.F2, CubeMove.F];

        var result = MoveOptimizer.OptimizeMoves(moves);

        result.ShouldHaveSingleItem();
        result[0].ShouldBe(CubeMove.F_);
    }

    [Fact]
    public void OptimizeMoves_ComplexSequence_OptimizesCorrectly()
    {
        List<CubeMove> moves = 
        [
            CubeMove.U, CubeMove.U_,
            CubeMove.R, CubeMove.R,
            CubeMove.F, CubeMove.F_,
            CubeMove.D, CubeMove.D
        ];

        var result = MoveOptimizer.OptimizeMoves(moves);

        result.Count.ShouldBe(2);
        result[0].ShouldBe(CubeMove.R2);
        result[1].ShouldBe(CubeMove.D2);
    }

    [Fact]
    public void OptimizeMoves_RotationPairWithNonInterferingMove_OptimizesCorrectly()
    {
        List<CubeMove> moves =
        [
            CubeMove.x, CubeMove.R, CubeMove.x_
        ];

        var result = MoveOptimizer.OptimizeMoves(moves);

        result.Count.ShouldBe(1);
        result[0].ShouldBe(CubeMove.R);

        moves =
        [
            CubeMove.x, CubeMove.R, CubeMove.x
        ];

        result = MoveOptimizer.OptimizeMoves(moves);

        result.Count.ShouldBe(2);
        result[0].ShouldBe(CubeMove.x2);
        result[1].ShouldBe(CubeMove.R);
    }

    [Fact]
    public void OptimizeMoves_RotationPairWithInterferingMove_DoesNotOptimize()
    {
        List<CubeMove> moves = 
        [
            CubeMove.x, CubeMove.U, CubeMove.x_
        ];

        var result = MoveOptimizer.OptimizeMoves(moves);

        result.Count.ShouldBe(3);
        result[0].ShouldBe(CubeMove.x);
        result[1].ShouldBe(CubeMove.U);
        result[2].ShouldBe(CubeMove.x_);
    }
}
