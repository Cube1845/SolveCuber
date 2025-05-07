using SolveCuber.CubeModel;

namespace SolveCuber.UnitTests;

internal static class TestScrambles
{
    public static readonly List<CubeMove> NoCrossScramble = [CubeMove.U, CubeMove.R_, CubeMove.B, CubeMove.L, CubeMove.B, CubeMove.L, CubeMove.D2, CubeMove.R_, CubeMove.L2, CubeMove.F2, CubeMove.U, CubeMove.B, CubeMove.L_, CubeMove.B_, CubeMove.R, CubeMove.L2, CubeMove.F, CubeMove.B, CubeMove.D, CubeMove.B, CubeMove.D2, CubeMove.F2, CubeMove.B2, CubeMove.R_, CubeMove.U];
    public static readonly List<CubeMove> CrossSolvedScramble = [CubeMove.U, CubeMove.R_, CubeMove.B, CubeMove.L, CubeMove.B, CubeMove.L, CubeMove.D2, CubeMove.R_, CubeMove.L2, CubeMove.F2, CubeMove.U, CubeMove.B, CubeMove.L_, CubeMove.B_, CubeMove.R, CubeMove.L2, CubeMove.F, CubeMove.B, CubeMove.D, CubeMove.B, CubeMove.D2, CubeMove.F2, CubeMove.B2, CubeMove.R_, CubeMove.U, CubeMove.L, CubeMove.B_, CubeMove.L_, CubeMove.D_, CubeMove.L2, CubeMove.F_, CubeMove.R, CubeMove.F2];
    public static readonly List<CubeMove> F2LSolvedScramble = [CubeMove.z2, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.U2, CubeMove.R_];
    public static readonly List<CubeMove> OLLExecutedScramble = [CubeMove.z2, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.R_, CubeMove.F, CubeMove.R2, CubeMove.U_, CubeMove.R_, CubeMove.U_, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.F_];
}
