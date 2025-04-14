using SolveCuber.CubeModel;
using SolveCuber.Solver.Common;

namespace SolveCuber.Solver.OLL;

//based on https://jperm.net/algs/oll

internal static class OLLAlgorithms
{
    public static List<OLL> OLLs =
    [
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Y }
            },
            []
        ),
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
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.X, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.X, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Z, FaceAxis.Z, FaceAxis.X }
            },
            [CubeMove.r, CubeMove.U2, CubeMove.R_, CubeMove.U_, CubeMove.R, CubeMove.U_, CubeMove.r_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Z, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.Y, FaceAxis.Z, FaceAxis.Z }
            },
            [CubeMove.r, CubeMove.U, CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.U2, CubeMove.r_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.X, FaceAxis.Y, FaceAxis.Z },
                { FaceAxis.X, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Z, FaceAxis.Z, FaceAxis.Y }
            },
            [CubeMove.l_, CubeMove.U_, CubeMove.L, CubeMove.U_, CubeMove.L_, CubeMove.U2, CubeMove.l]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.X, FaceAxis.Y, FaceAxis.Z },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.Z, FaceAxis.Z, FaceAxis.Y }
            },
            [CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.R_, CubeMove.F, CubeMove.R2, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.F_]
        ),
        // 10
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Z, FaceAxis.Z, FaceAxis.Y },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.X, FaceAxis.Y, FaceAxis.Z }
            },
            [CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U, CubeMove.R_, CubeMove.F, CubeMove.R, CubeMove.F_, CubeMove.R, CubeMove.U2, CubeMove.R_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Z, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.X, FaceAxis.Z, FaceAxis.Z }
            },
            [CubeMove.r, CubeMove.U, CubeMove.R_, CubeMove.U, CubeMove.R_, CubeMove.F, CubeMove.R, CubeMove.F_, CubeMove.R, CubeMove.U2, CubeMove.r_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Z },
                { FaceAxis.X, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Z, FaceAxis.Z, FaceAxis.X }
            },
            [CubeMove.M_, CubeMove.R_, CubeMove.U_, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.U2, CubeMove.R, CubeMove.U_, CubeMove.R, CubeMove.r_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Z, FaceAxis.Z, FaceAxis.X },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Y, FaceAxis.Z, FaceAxis.Z }
            },
            [CubeMove.F, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R2, CubeMove.F_, CubeMove.R, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.X, FaceAxis.Z, FaceAxis.Z },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Z, FaceAxis.Z, FaceAxis.Y }
            },
            [CubeMove.R_, CubeMove.F, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.F_, CubeMove.R, CubeMove.F, CubeMove.U_, CubeMove.F_]
        ),
        // 15
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Y, FaceAxis.Z, FaceAxis.X },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.X, FaceAxis.Z, FaceAxis.Z }
            },
            [CubeMove.l_, CubeMove.U_, CubeMove.l, CubeMove.L_, CubeMove.U_, CubeMove.L, CubeMove.U, CubeMove.l_, CubeMove.U, CubeMove.l]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.X, FaceAxis.Z, FaceAxis.Y },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.Z, FaceAxis.Z, FaceAxis.X }
            },
            [CubeMove.r, CubeMove.U, CubeMove.r_, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.r, CubeMove.U_, CubeMove.r_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Y, FaceAxis.Z, FaceAxis.X },
                { FaceAxis.X, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.Z, FaceAxis.Z, FaceAxis.Y }
            },
            [CubeMove.F, CubeMove.R_, CubeMove.F_, CubeMove.R2, CubeMove.r_, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.U_, CubeMove.M_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Y, FaceAxis.Z, FaceAxis.Y },
                { FaceAxis.X, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.Z, FaceAxis.Z, FaceAxis.Z }
            },
            [CubeMove.r, CubeMove.U, CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.U2, CubeMove.r2, CubeMove.U_, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.U2, CubeMove.r]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Y, FaceAxis.Z, FaceAxis.Y },
                { FaceAxis.X, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.X, FaceAxis.Z, FaceAxis.X }
            },
            [CubeMove.r_, CubeMove.R, CubeMove.U, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.M_, CubeMove.R_, CubeMove.F, CubeMove.R, CubeMove.F_]
        ),
        // 20
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Y, FaceAxis.Z, FaceAxis.Y },
                { FaceAxis.X, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.Y, FaceAxis.Z, FaceAxis.Y }
            },
            [CubeMove.r, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.M2, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.U_, CubeMove.M_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Z, FaceAxis.Y, FaceAxis.Z },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Z, FaceAxis.Y, FaceAxis.Z }
            },
            [CubeMove.R, CubeMove.U2, CubeMove.R_, CubeMove.U_, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.R, CubeMove.U_, CubeMove.R_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.X, FaceAxis.Y, FaceAxis.Z },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.X, FaceAxis.Y, FaceAxis.Z }
            },
            [CubeMove.R, CubeMove.U2, CubeMove.R2, CubeMove.U_, CubeMove.R2, CubeMove.U_, CubeMove.R2, CubeMove.U2, CubeMove.R]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Z, FaceAxis.Y, FaceAxis.Z },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Y }
            },
            [CubeMove.R2, CubeMove.D_, CubeMove.R, CubeMove.U2, CubeMove.R_, CubeMove.D, CubeMove.R, CubeMove.U2, CubeMove.R]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Z, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Z, FaceAxis.Y, FaceAxis.Y }
            },
            [CubeMove.r, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.r_, CubeMove.F, CubeMove.R, CubeMove.F_]
        ),
        // 25
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.X, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Z }
            },
            [CubeMove.F_, CubeMove.r, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.r_, CubeMove.F, CubeMove.R]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.X, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Z, FaceAxis.Y, FaceAxis.X }
            },
            [CubeMove.R, CubeMove.U2, CubeMove.R_, CubeMove.U_, CubeMove.R, CubeMove.U_, CubeMove.R_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Z, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Z }
            },
            [CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.U2, CubeMove.R_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.Y, FaceAxis.Z, FaceAxis.Y }
            },
            [CubeMove.r, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.r_, CubeMove.R, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Z, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.Z, FaceAxis.Z, FaceAxis.Y }
            },
            [CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.F_, CubeMove.U_, CubeMove.F, CubeMove.R, CubeMove.U, CubeMove.R_]
        ),
        // 30
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.X, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.Y, FaceAxis.Z, FaceAxis.Y }
            },
            [CubeMove.F, CubeMove.R_, CubeMove.F, CubeMove.R2, CubeMove.U_, CubeMove.R_, CubeMove.U_, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.F2]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Z, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.X, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Z, FaceAxis.Z, FaceAxis.Y }
            },
            [CubeMove.R_, CubeMove.U_, CubeMove.F, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.F_, CubeMove.R]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Z },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.Y, FaceAxis.Z, FaceAxis.Z }
            },
            [CubeMove.L, CubeMove.U, CubeMove.F_, CubeMove.U_, CubeMove.L_, CubeMove.U, CubeMove.L, CubeMove.F, CubeMove.L_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Z, FaceAxis.Z, FaceAxis.Y },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Z, FaceAxis.Z, FaceAxis.Y }
            },
            [CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.R_, CubeMove.F, CubeMove.R, CubeMove.F_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.X, FaceAxis.Z, FaceAxis.X },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Y, FaceAxis.Z, FaceAxis.Y }
            },
            [CubeMove.R, CubeMove.U, CubeMove.R2, CubeMove.U_, CubeMove.R_, CubeMove.F, CubeMove.R, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.F_]
        ),
        // 35
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Y, FaceAxis.Z, FaceAxis.X },
                { FaceAxis.X, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Z, FaceAxis.Y, FaceAxis.Y }
            },
            [CubeMove.R, CubeMove.U2, CubeMove.R2, CubeMove.F, CubeMove.R, CubeMove.F_, CubeMove.R, CubeMove.U2, CubeMove.R_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Z },
                { FaceAxis.X, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.X, FaceAxis.Z, FaceAxis.Y }
            },
            [CubeMove.L_, CubeMove.U_, CubeMove.L, CubeMove.U_, CubeMove.L_, CubeMove.U, CubeMove.L, CubeMove.U, CubeMove.L, CubeMove.F_, CubeMove.L_, CubeMove.F]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.Z, FaceAxis.Z, FaceAxis.Y }
            },
            [CubeMove.F, CubeMove.R_, CubeMove.F_, CubeMove.R, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Z, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.Y, FaceAxis.Z, FaceAxis.X }
            },
            [CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.U_, CubeMove.R_, CubeMove.F, CubeMove.R, CubeMove.F_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Z, FaceAxis.Z, FaceAxis.Y },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Y, FaceAxis.Z, FaceAxis.X }
            },
            [CubeMove.L, CubeMove.F_, CubeMove.L_, CubeMove.U_, CubeMove.L, CubeMove.U, CubeMove.F, CubeMove.U_, CubeMove.L_]
        ),
        // 40
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Y, FaceAxis.Z, FaceAxis.Z },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.X, FaceAxis.Z, FaceAxis.Y }
            },
            [CubeMove.R_, CubeMove.F, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.F_, CubeMove.U, CubeMove.R]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Z, FaceAxis.Y, FaceAxis.Z },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.Y, FaceAxis.Z, FaceAxis.Y }
            },
            [CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.U2, CubeMove.R_, CubeMove.F, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.F_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Y, FaceAxis.Z, FaceAxis.Y },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.Z, FaceAxis.Y, FaceAxis.Z }
            },
            [CubeMove.R_, CubeMove.U_, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.U2, CubeMove.R, CubeMove.F, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.F_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.X, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.X, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.X, FaceAxis.Z, FaceAxis.Y }
            },
            [CubeMove.F_, CubeMove.U_, CubeMove.L_, CubeMove.U, CubeMove.L, CubeMove.F]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.Y, FaceAxis.Z, FaceAxis.X }
            },
            [CubeMove.F, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.F_]
        ),
        // 45
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.X, FaceAxis.Z, FaceAxis.Y },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.X, FaceAxis.Z, FaceAxis.Y }
            },
            [CubeMove.F, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.F_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.X, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.X }
            },
            [CubeMove.R_, CubeMove.U_, CubeMove.R_, CubeMove.F, CubeMove.R, CubeMove.F_, CubeMove.U, CubeMove.R]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Z, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.X, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Z, FaceAxis.Z, FaceAxis.X }
            },
            [CubeMove.R_, CubeMove.U_, CubeMove.R_, CubeMove.F, CubeMove.R, CubeMove.F_, CubeMove.R_, CubeMove.F, CubeMove.R, CubeMove.F_, CubeMove.U, CubeMove.R]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.X, FaceAxis.Y, FaceAxis.Z },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.X, FaceAxis.Z, FaceAxis.Z }
            },
            [CubeMove.F, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.F_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.X, FaceAxis.Y, FaceAxis.Z },
                { FaceAxis.X, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.X, FaceAxis.Z, FaceAxis.Z }
            },
            [CubeMove.r, CubeMove.U_, CubeMove.r2, CubeMove.U, CubeMove.r2, CubeMove.U, CubeMove.r2, CubeMove.U_, CubeMove.r]
        ),
        // 50
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.X, FaceAxis.Z, FaceAxis.Z },
                { FaceAxis.X, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.X, FaceAxis.Y, FaceAxis.Z }
            },
            [CubeMove.r_, CubeMove.U, CubeMove.r2, CubeMove.U_, CubeMove.r2, CubeMove.U_, CubeMove.r2, CubeMove.U, CubeMove.r_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Z, FaceAxis.Z, FaceAxis.X },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Z, FaceAxis.Z, FaceAxis.X }
            },
            [CubeMove.F, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.F_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Z, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.X, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.Z, FaceAxis.Y, FaceAxis.X }
            },
            [CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.B, CubeMove.U_, CubeMove.B_, CubeMove.R_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Z, FaceAxis.Y, FaceAxis.Z },
                { FaceAxis.X, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Z, FaceAxis.Z, FaceAxis.Z }
            },
            [CubeMove.l_, CubeMove.U2, CubeMove.L, CubeMove.U, CubeMove.L_, CubeMove.U_, CubeMove.L, CubeMove.U, CubeMove.L_, CubeMove.U, CubeMove.l]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Z, FaceAxis.Y, FaceAxis.Z },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.X },
                { FaceAxis.Z, FaceAxis.Z, FaceAxis.Z }
            },
            [CubeMove.r, CubeMove.U2, CubeMove.R_, CubeMove.U_, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.R, CubeMove.U_, CubeMove.r_]
        ),
        // 55
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Z, FaceAxis.Z, FaceAxis.Z },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Z, FaceAxis.Z, FaceAxis.Z }
            },
            [CubeMove.R_, CubeMove.F, CubeMove.R, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R2, CubeMove.F_, CubeMove.R2, CubeMove.U_, CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.U, CubeMove.R_]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.X, FaceAxis.Z, FaceAxis.X },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.X, FaceAxis.Z, FaceAxis.X }
            },
            [CubeMove.r_, CubeMove.U_, CubeMove.r, CubeMove.U_, CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.r_, CubeMove.U, CubeMove.r]
        ),
        new
        (
            new FaceAxis[3, 3]
            {
                { FaceAxis.Y, FaceAxis.Z, FaceAxis.Y },
                { FaceAxis.Y, FaceAxis.Y, FaceAxis.Y },
                { FaceAxis.Y, FaceAxis.Z, FaceAxis.Y }
            },
            [CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.M_, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.r_]
        ),
    ];
}
