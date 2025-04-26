using SolveCuber.CubeModel;

namespace SolveCuber.Solver.PLL;

//link https://jperm.net/algs/pll

internal static class PLLAlgorithms
{
    public static List<CubeMove> GetPLL(Models.PLL pll)
    {
        return pll switch
        {
            Models.PLL.Aa => Aa,
            Models.PLL.Ab => Ab,
            Models.PLL.F => F,
            Models.PLL.Ga => Ga,
            Models.PLL.Gb => Gb,
            Models.PLL.Gc => Gc,
            Models.PLL.Gd => Gd,
            Models.PLL.Ja => Ja,
            Models.PLL.Jb => Jb,
            Models.PLL.Ra => Ra,
            Models.PLL.Rb => Rb,
            Models.PLL.T => T,
            Models.PLL.E => E,
            Models.PLL.Na => Na,
            Models.PLL.Nb => Nb,
            Models.PLL.V => V,
            Models.PLL.Y => Y,
            Models.PLL.H => H,
            Models.PLL.Ua => Ua,
            Models.PLL.Ub => Ub,
            Models.PLL.Z => Z,

            _ => throw new NotImplementedException()
        };
    }

    public static List<CubeMove> Aa = [CubeMove.x, CubeMove.R_, CubeMove.U, CubeMove.R_, CubeMove.D2, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.D2, CubeMove.R2, CubeMove.x_];
    public static List<CubeMove> Ab = [CubeMove.x, CubeMove.R2, CubeMove.D2, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.D2, CubeMove.R, CubeMove.U_, CubeMove.R, CubeMove.x_];

    public static List<CubeMove> F = [CubeMove.R_, CubeMove.U_, CubeMove.F_, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.R_, CubeMove.F, CubeMove.R2, CubeMove.U_, CubeMove.R_, CubeMove.U_, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U, CubeMove.R];

    public static List<CubeMove> Ga = [CubeMove.R2, CubeMove.U, CubeMove.R_, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.R, CubeMove.U_, CubeMove.R2, CubeMove.U_, CubeMove.D, CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.D_];
    public static List<CubeMove> Gb = [CubeMove.R_, CubeMove.U_, CubeMove.R, CubeMove.U, CubeMove.D_, CubeMove.R2, CubeMove.U, CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R, CubeMove.U_, CubeMove.R2, CubeMove.D];
    public static List<CubeMove> Gc = [CubeMove.R2, CubeMove.U_, CubeMove.R, CubeMove.U_, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U, CubeMove.R2, CubeMove.U, CubeMove.D_, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.D];
    public static List<CubeMove> Gd = [CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.D, CubeMove.R2, CubeMove.U_, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.U, CubeMove.R_, CubeMove.U, CubeMove.R2, CubeMove.D_];

    public static List<CubeMove> Ja = [CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.F_, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.R_, CubeMove.F, CubeMove.R2, CubeMove.U_, CubeMove.R_, CubeMove.U_];
    public static List<CubeMove> Jb = [CubeMove.L_, CubeMove.U_, CubeMove.L, CubeMove.F, CubeMove.L_, CubeMove.U_, CubeMove.L, CubeMove.U, CubeMove.L, CubeMove.F_, CubeMove.L2, CubeMove.U, CubeMove.L, CubeMove.U];

    public static List<CubeMove> Ra = [CubeMove.L, CubeMove.U2, CubeMove.L_, CubeMove.U2, CubeMove.L, CubeMove.F_, CubeMove.L_, CubeMove.U_, CubeMove.L, CubeMove.U, CubeMove.L, CubeMove.F, CubeMove.L2, CubeMove.U];
    public static List<CubeMove> Rb = [CubeMove.R_, CubeMove.U2, CubeMove.R, CubeMove.U2, CubeMove.R_, CubeMove.F, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.R_, CubeMove.F_, CubeMove.R2, CubeMove.U_];

    public static List<CubeMove> T = [CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.R_, CubeMove.F, CubeMove.R2, CubeMove.U_, CubeMove.R_, CubeMove.U_, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.F_];

    public static List<CubeMove> E = [CubeMove.R_, CubeMove.U_, CubeMove.R_, CubeMove.D_, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.D, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.D_, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.D, CubeMove.R2];

    public static List<CubeMove> Na = [CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.F_, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.R_, CubeMove.F, CubeMove.R2, CubeMove.U_, CubeMove.R_, CubeMove.U2, CubeMove.R, CubeMove.U_, CubeMove.R_];
    public static List<CubeMove> Nb = [CubeMove.R_, CubeMove.U, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.F_, CubeMove.U_, CubeMove.F, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.F, CubeMove.R_, CubeMove.F_, CubeMove.R, CubeMove.U_, CubeMove.R];

    public static List<CubeMove> V = [CubeMove.R_, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.y, CubeMove.R_, CubeMove.F_, CubeMove.R2, CubeMove.U_, CubeMove.R_, CubeMove.U, CubeMove.R_, CubeMove.F, CubeMove.R, CubeMove.F];

    public static List<CubeMove> Y = [CubeMove.F, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.U_, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.F_, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.U_, CubeMove.R_, CubeMove.F, CubeMove.R, CubeMove.F_];

    public static List<CubeMove> H = [CubeMove.M2, CubeMove.U, CubeMove.M2, CubeMove.U2, CubeMove.M2, CubeMove.U, CubeMove.M2];

    public static List<CubeMove> Ua = [CubeMove.M2, CubeMove.U, CubeMove.M, CubeMove.U2, CubeMove.M_, CubeMove.U, CubeMove.M2];
    public static List<CubeMove> Ub = [CubeMove.M2, CubeMove.U_, CubeMove.M, CubeMove.U2, CubeMove.M_, CubeMove.U_, CubeMove.M2];

    public static List<CubeMove> Z = [CubeMove.M_, CubeMove.U, CubeMove.M2, CubeMove.U, CubeMove.M2, CubeMove.U, CubeMove.M_, CubeMove.U2, CubeMove.M2];
}