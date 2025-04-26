using SolveCuber.CubeModel;

namespace SolveCuber.Solver.F2L;

// link https://www.cubeskills.com/uploads/pdf/tutorials/f2l.pdf

internal static partial class F2LSolutions
{
    internal static class WhiteFaceZAxis
    {
        internal static class EdgeTopLayer
        {
            internal static class EdgeFrontRight
            {
                public static List<CubeMove> YFacesSameColor = [CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R_];
                public static List<CubeMove> YFacesDifferentColor = [CubeMove.U_, CubeMove.R, CubeMove.U2, CubeMove.R_, CubeMove.d, CubeMove.R_, CubeMove.U_, CubeMove.R];
            }

            internal static class EdgeFrontLeft
            {
                public static List<CubeMove> YFacesSameColor = [CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U2, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R_];
                public static List<CubeMove> YFacesDifferentColor = [CubeMove.d, CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.U_, CubeMove.R];
            }

            internal static class EdgeBackRight
            {
                public static List<CubeMove> YFacesSameColor = [CubeMove.U_, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U2, CubeMove.R, CubeMove.U_, CubeMove.R_];
                public static List<CubeMove> YFacesDifferentColor = [CubeMove.d, CubeMove.R_, CubeMove.U_, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.U_, CubeMove.R];
            }

            internal static class EdgeBackLeft
            {
                public static List<CubeMove> YFacesSameColor = [CubeMove.U_, CubeMove.R, CubeMove.U2, CubeMove.R_, CubeMove.U2, CubeMove.R, CubeMove.U_, CubeMove.R_];
                public static List<CubeMove> YFacesDifferentColor = [CubeMove.y_, CubeMove.R_, CubeMove.U_, CubeMove.R];
            }
        }

        internal static class EdgeMiddleLayer
        {
            internal static class EdgeFrontRight
            {
                public static List<CubeMove> YXFaceSameColor = [CubeMove.U_, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.d, CubeMove.R_, CubeMove.U_, CubeMove.R];
                public static List<CubeMove> YXFaceDifferentColor = [CubeMove.U_, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.U2, CubeMove.R, CubeMove.U_, CubeMove.R_];
            }

            internal static class EdgeFrontLeft
            {
                public static List<CubeMove> YXFaceSameColor = [CubeMove.L_, CubeMove.U_, CubeMove.L, CubeMove.U, CubeMove.y_, CubeMove.R_, CubeMove.U_, CubeMove.R];
                public static List<CubeMove> YXFaceDifferentColor = [CubeMove.y_, CubeMove.U_, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U2, CubeMove.R_, CubeMove.U, CubeMove.R];
            }

            internal static class EdgeBackRight
            {
                public static List<CubeMove> YXFaceSameColor = [CubeMove.R_, CubeMove.U2, CubeMove.R, CubeMove.y_, CubeMove.R_, CubeMove.U_, CubeMove.R];
                public static List<CubeMove> YXFaceDifferentColor = [CubeMove.y, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.L_, CubeMove.U_, CubeMove.L];
            }

            internal static class EdgeBackLeft
            {
                public static List<CubeMove> YXFaceSameColor = [CubeMove.L, CubeMove.U_, CubeMove.L_, CubeMove.d, CubeMove.R_, CubeMove.U_, CubeMove.R];
                public static List<CubeMove> YXFaceDifferentColor = [CubeMove.y, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.R, CubeMove.L_, CubeMove.U_, CubeMove.L];
            }
        }
    }

    internal static class WhiteFaceXAxis
    {
        internal static class EdgeTopLayer
        {
            internal static class EdgeFrontRight
            {
                public static List<CubeMove> YFacesSameColor = [CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.U2, CubeMove.y_, CubeMove.R_, CubeMove.U_, CubeMove.R];
                public static List<CubeMove> YFacesDifferentColor = [CubeMove.U_, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.U, CubeMove.R_];
            }

            internal static class EdgeFrontLeft
            {
                public static List<CubeMove> YFacesSameColor = [CubeMove.U_, CubeMove.F_, CubeMove.U, CubeMove.F];
                public static List<CubeMove> YFacesDifferentColor = [CubeMove.R_, CubeMove.U2, CubeMove.R2, CubeMove.U, CubeMove.R2, CubeMove.U, CubeMove.R];
            }

            internal static class EdgeBackRight
            {
                public static List<CubeMove> YFacesSameColor = [CubeMove.d, CubeMove.R_, CubeMove.U2, CubeMove.R, CubeMove.U2, CubeMove.R_, CubeMove.U, CubeMove.R];
                public static List<CubeMove> YFacesDifferentColor = [CubeMove.R, CubeMove.U, CubeMove.R_];
            }

            internal static class EdgeBackLeft
            {
                public static List<CubeMove> YFacesSameColor = [CubeMove.d, CubeMove.R_, CubeMove.U_, CubeMove.R, CubeMove.U2, CubeMove.R_, CubeMove.U, CubeMove.R];
                public static List<CubeMove> YFacesDifferentColor = [CubeMove.U_, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.U, CubeMove.R_];
            }
        }

        internal static class EdgeMiddleLayer
        {
            internal static class EdgeFrontRight
            {
                public static List<CubeMove> YXFaceSameColor = [CubeMove.U, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U2, CubeMove.R, CubeMove.U, CubeMove.R_];
                public static List<CubeMove> YXFaceDifferentColor = [CubeMove.U, CubeMove.F_, CubeMove.U_, CubeMove.F, CubeMove.U_, CubeMove.R, CubeMove.U, CubeMove.R_];
            }

            internal static class EdgeFrontLeft
            {
                public static List<CubeMove> YXFaceSameColor = [CubeMove.U_, CubeMove.L_, CubeMove.U, CubeMove.L, CubeMove.R, CubeMove.U, CubeMove.R_];
                public static List<CubeMove> YXFaceDifferentColor = [CubeMove.U2, CubeMove.L_, CubeMove.U, CubeMove.L, CubeMove.F_, CubeMove.U2, CubeMove.F];
            }

            internal static class EdgeBackRight
            {
                public static List<CubeMove> YXFaceSameColor = [CubeMove.R_, CubeMove.U_, CubeMove.R2, CubeMove.U, CubeMove.R_];
                public static List<CubeMove> YXFaceDifferentColor = [CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.d_, CubeMove.L_, CubeMove.U, CubeMove.L];
            }

            internal static class EdgeBackLeft
            {
                public static List<CubeMove> YXFaceSameColor = [CubeMove.U_, CubeMove.L, CubeMove.U, CubeMove.L_, CubeMove.R, CubeMove.U, CubeMove.R_];
                public static List<CubeMove> YXFaceDifferentColor = [CubeMove.y, CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.y_, CubeMove.R, CubeMove.U, CubeMove.R_];
            }
        }
    }

    internal static class WhiteFaceYAxis
    {
        internal static class EdgeTopLayer

        {
            internal static class EdgeFrontRight
            {
                public static List<CubeMove> ZYFaceSameColor = [CubeMove.F, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.F_, CubeMove.R, CubeMove.U_, CubeMove.R_];
                public static List<CubeMove> ZYFaceDifferentColor = [CubeMove.R, CubeMove.U2, CubeMove.R_, CubeMove.U_, CubeMove.R, CubeMove.U, CubeMove.R_];
            }

            internal static class EdgeFrontLeft
            {
                public static List<CubeMove> ZYFaceSameColor = [CubeMove.y_, CubeMove.R_, CubeMove.U2, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.R];
                public static List<CubeMove> ZYFaceDifferentColor = [CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U2, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.R, CubeMove.U, CubeMove.R_];
            }

            internal static class EdgeBackRight
            {
                public static List<CubeMove> ZYFaceSameColor = [CubeMove.F_, CubeMove.L_, CubeMove.U2, CubeMove.L, CubeMove.F];
                public static List<CubeMove> ZYFaceDifferentColor = [CubeMove.U, CubeMove.R, CubeMove.U2, CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R_];
            }

            internal static class EdgeBackLeft
            {
                public static List<CubeMove> ZYFaceSameColor = [CubeMove.y_, CubeMove.U_, CubeMove.R_, CubeMove.U2, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.U, CubeMove.R];
                public static List<CubeMove> ZYFaceDifferentColor = [CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.U2, CubeMove.R, CubeMove.U, CubeMove.R_];
            }
        }

        internal static class EdgeMiddleLayer
        {
            internal static class EdgeFrontRight
            {
                public static List<CubeMove> ZFacesSameColor = [CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.d, CubeMove.R_, CubeMove.U, CubeMove.R];
                public static List<CubeMove> ZFacesDifferentColor = [CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R_];
            }

            internal static class EdgeFrontLeft
            {
                public static List<CubeMove> ZFacesSameColor = [CubeMove.U_, CubeMove.L_, CubeMove.U, CubeMove.L, CubeMove.F_, CubeMove.L_, CubeMove.U2, CubeMove.L, CubeMove.F];
                public static List<CubeMove> ZFacesDifferentColor = [CubeMove.L_, CubeMove.U2, CubeMove.L, CubeMove.U_, CubeMove.R, CubeMove.U, CubeMove.R_];
            }

            internal static class EdgeBackRight
            {
                public static List<CubeMove> ZFacesSameColor = [CubeMove.R_, CubeMove.U_, CubeMove.R, CubeMove.F_, CubeMove.L_, CubeMove.U2, CubeMove.L, CubeMove.F];
                public static List<CubeMove> ZFacesDifferentColor = [CubeMove.U_, CubeMove.R_, CubeMove.U, CubeMove.R2, CubeMove.U_, CubeMove.R_];
            }

            internal static class EdgeBackLeft
            {
                public static List<CubeMove> ZFacesSameColor = [CubeMove.y_, CubeMove.U2, CubeMove.F, CubeMove.U2, CubeMove.F_, CubeMove.R_, CubeMove.U, CubeMove.R];
                public static List<CubeMove> ZFacesDifferentColor = [CubeMove.y_, CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.U_, CubeMove.R, CubeMove.L_, CubeMove.U2, CubeMove.L];
            }
        }
    }
}
