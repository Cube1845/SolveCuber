using SolveCuber.CubeModel;
using SolveCuber.Solver.Common;

namespace SolveCuber.Solver.OLL;

//based on https://jperm.net/algs/oll

internal static class OLLAlgorithms
{
    public static List<OLL> OLLs =
    [
        // 1
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.X, FaceAxis.Z, FaceAxis.X },
                { FaceAxis.X, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.X, FaceAxis.Z, FaceAxis.X }
            },
            [CubeMove.R, CubeMove.U2, CubeMove.R2, CubeMove.F, CubeMove.R, CubeMove.F_, CubeMove.U2, CubeMove.R_, CubeMove.F, CubeMove.R, CubeMove.F_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Z, FaceAxis.Z, FaceAxis.Z },
                { FaceAxis.X, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.X, FaceAxis.Z, FaceAxis.X }
            },
            [CubeMove.r, CubeMove.U, CubeMove.r_, CubeMove.U2, CubeMove.r, CubeMove.U2, CubeMove.R_, CubeMove.U2, CubeMove.R, CubeMove.U_, CubeMove.r_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Z, FaceAxis.Z, FaceAxis.X },
                { FaceAxis.X, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.Y, FaceAxis.Z, FaceAxis.Z }
            },
            [CubeMove.r_, CubeMove.R2, CubeMove.U, CubeMove.R_, CubeMove.U, CubeMove.r, CubeMove.U2, CubeMove.r_, CubeMove.U, CubeMove.M_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.X, FaceAxis.Z, FaceAxis.Z },
                { FaceAxis.X, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.Z, FaceAxis.Z, FaceAxis.Y }
            },
            [CubeMove.M, CubeMove.U_, CubeMove.r, CubeMove.U2, CubeMove.r_, CubeMove.U_, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.M_]
        ),
        // 5
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.X, FaceAxis.Z, FaceAxis.Z }
            },
            [CubeMove.l_, CubeMove.U2, CubeMove.L, CubeMove.U, CubeMove.L_, CubeMove.U, CubeMove.l]
        ),
    ];
}
