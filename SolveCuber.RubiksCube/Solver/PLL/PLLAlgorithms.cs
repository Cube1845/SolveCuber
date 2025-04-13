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

            _ => throw new NotImplementedException()
        };
    }

    public static List<CubeMove> Aa = [CubeMove.x, CubeMove.R_, CubeMove.U, CubeMove.R_, CubeMove.D2, CubeMove.R, CubeMove.U_, CubeMove.R_, CubeMove.D2, CubeMove.R2, CubeMove.x_];
    public static List<CubeMove> Ab = [CubeMove.x, CubeMove.R2, CubeMove.D2, CubeMove.R, CubeMove.U, CubeMove.R_, CubeMove.D2, CubeMove.R, CubeMove.U_, CubeMove.R, CubeMove.x_];
}