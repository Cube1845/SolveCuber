using SolveCuber.CubeModel;

namespace SolveCuber.Solver.F2L;

// based on https://www.cubeskills.com/uploads/pdf/tutorials/f2l.pdf

internal static class F2LSolutions
{
    internal static class Inserts
    {
        public static List<CubeMove> RightHand_BasicInsert = [CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R_];
        public static List<CubeMove> LeftHand_BasicInsert = [CubeMove.U_, CubeMove.L_, CubeMove.U, CubeMove.L];

        public static List<CubeMove> LeftHand_ThreeMover = [CubeMove.L_, CubeMove.U_, CubeMove.L];
        public static List<CubeMove> RightHand_ThreeMover = [CubeMove.R, CubeMove.U, CubeMove.R_];
    }
}
