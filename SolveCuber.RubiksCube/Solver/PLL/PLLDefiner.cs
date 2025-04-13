using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Solver.PLL.Models;

namespace SolveCuber.Solver.PLL;

internal class PLLDefiner
{
    private readonly static int _pllCount = 21;

    public static List<CubeMove>? GetPLL(Cube cube)
    {
        for (int i = 1; i <= _pllCount; i++)
        {
            if (IsPLL(cube, (Models.PLL)i))
            {
                return PLLAlgorithms.GetPLL((Models.PLL)i);
            }
        }

        return null;
    }

    private static bool IsPLL(Cube cube, Models.PLL pll)
    {
        var cornersRepositionData = CornerRepositionDefiner.DefineCornersReposition(cube);
        var edgesRepositionData = EdgeRepositionDefiner.DefineEdgesReposition(cube);

        return pll switch
        {
            Models.PLL.Aa => AaCondition(cornersRepositionData, edgesRepositionData),
            Models.PLL.Ab => AbCondition(cornersRepositionData, edgesRepositionData),

            _ => throw new NotImplementedException()
        };
    }

    private static bool AaCondition(CornersRepositionData cornersData, EdgesRepositionData edgesData)
    {
        return cornersData.FrontRight == Reposition.Across &&
             cornersData.FrontLeft == Reposition.None &&
             cornersData.BackLeft == Reposition.Clockwise &&
             cornersData.BackRight == Reposition.Clockwise &&
             edgesData.Front == Reposition.None &&
             edgesData.Left == Reposition.None &&
             edgesData.Back == Reposition.None &&
             edgesData.Right == Reposition.None;
    }

    private static bool AbCondition(CornersRepositionData cornersData, EdgesRepositionData edgesData)
    {
        return cornersData.FrontRight == Reposition.CounterClockwise &&
             cornersData.FrontLeft == Reposition.None &&
             cornersData.BackLeft == Reposition.Across &&
             cornersData.BackRight == Reposition.CounterClockwise &&
             edgesData.Front == Reposition.None &&
             edgesData.Left == Reposition.None &&
             edgesData.Back == Reposition.None &&
             edgesData.Right == Reposition.None;
    }
}
