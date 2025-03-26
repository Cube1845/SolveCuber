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

    internal static class Case1
    {
        public static List<CubeMove> LeftHand_1 = [CubeMove.U_, CubeMove.F, CubeMove.U_, CubeMove.F_, CubeMove.U, CubeMove.L_, CubeMove.U_, CubeMove.L];
        public static List<CubeMove> RightHand_1 = [CubeMove.U_, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.U, CubeMove.R_];

        public static List<CubeMove> LeftHand_2 = [CubeMove.L, CubeMove.U2, CubeMove.L2, CubeMove.U_, CubeMove.L2, CubeMove.U_, CubeMove.L];
        public static List<CubeMove> RightHand_2 = [CubeMove.R_, CubeMove.U2, CubeMove.R2, CubeMove.U, CubeMove.R2, CubeMove.U, CubeMove.R];

        public static List<CubeMove> LeftHand_3 = [CubeMove.U, CubeMove.L_, CubeMove.U, CubeMove.L, CubeMove.U_, CubeMove.L_, CubeMove.U_, CubeMove.L];
        public static List<CubeMove> RightHand_3 = [CubeMove.U_, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.U, CubeMove.R_];
    }

    internal static class Case2
    {
        public static List<CubeMove> LeftHand_1 = [CubeMove.U, CubeMove.L_, CubeMove.U_, CubeMove.L, CubeMove.U2, CubeMove.L_, CubeMove.U, CubeMove.L];
        public static List<CubeMove> RightHand_1 = [CubeMove.U_, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U2, CubeMove.R, CubeMove.U_, CubeMove.R_];

        public static List<CubeMove> LeftHand_2 = [CubeMove.U, CubeMove.L_, CubeMove.U2, CubeMove.L, CubeMove.U2, CubeMove.L_, CubeMove.U, CubeMove.L];
        public static List<CubeMove> RightHand_2 = [CubeMove.U_, CubeMove.R, CubeMove.U2, CubeMove.R_, CubeMove.U2, CubeMove.R, CubeMove.U_, CubeMove.R_];
    }

    internal static class Case3
    {
        public static List<CubeMove> LeftHand_1 = [CubeMove.U_, CubeMove.L_, CubeMove.U2, CubeMove.L, CubeMove.U_, CubeMove.L_, CubeMove.U, CubeMove.L];
        public static List<CubeMove> RightHand_1 = [CubeMove.U, CubeMove.R, CubeMove.U2, CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R_];

        public static List<CubeMove> LeftHand_2 = [CubeMove.U2, CubeMove.L_, CubeMove.U_, CubeMove.L, CubeMove.U_, CubeMove.L_, CubeMove.U, CubeMove.L];
        public static List<CubeMove> RightHand_2 = [CubeMove.U2, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R_];
    }
}
