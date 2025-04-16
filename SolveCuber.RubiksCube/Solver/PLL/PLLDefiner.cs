using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Solver.PLL.Models;

namespace SolveCuber.Solver.PLL;

internal class PLLDefiner
{
    private readonly static int _pllCount = 11; //21

    public static List<CubeMove>? GetPLL(Cube cube)
    {
        var cubeCopy = cube.DeepCopy();

        for (int i = 0; i < 4; i++)
        {
            cubeCopy.ExecuteMove(CubeMove.d);

            var cornersRepositionData = CornerRepositionDefiner.DefineCornersReposition(cubeCopy);
            var edgesRepositionData = EdgeRepositionDefiner.DefineEdgesReposition(cubeCopy);

            for (int j = 1; j <= _pllCount; j++)
            {
                var isCurrentPLL = IsPLL(cornersRepositionData, edgesRepositionData, (Models.PLL)j);

                if (isCurrentPLL)
                {
                    return PLLAlgorithms.GetPLL((Models.PLL)i);
                }
            }
        }

        return null;
    }

    private static bool IsPLL(CornersRepositionData cornersRepositionData, EdgesRepositionData edgesRepositionData, Models.PLL pll)
    {
        return pll switch
        {
            Models.PLL.Aa => AaCondition(cornersRepositionData, edgesRepositionData),
            Models.PLL.Ab => AbCondition(cornersRepositionData, edgesRepositionData),
            Models.PLL.F => FCondition(cornersRepositionData, edgesRepositionData),
            Models.PLL.Ga => GaCondition(cornersRepositionData, edgesRepositionData),
            Models.PLL.Gb => GbCondition(cornersRepositionData, edgesRepositionData),
            Models.PLL.Gc => GcCondition(cornersRepositionData, edgesRepositionData),
            Models.PLL.Gd => GdCondition(cornersRepositionData, edgesRepositionData),
            Models.PLL.Ja => JaCondition(cornersRepositionData, edgesRepositionData),
            Models.PLL.Jb => JbCondition(cornersRepositionData, edgesRepositionData),
            Models.PLL.Ra => RaCondition(cornersRepositionData, edgesRepositionData),
            Models.PLL.Rb => RbCondition(cornersRepositionData, edgesRepositionData),

            _ => false
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

    private static bool FCondition(CornersRepositionData cornersData, EdgesRepositionData edgesData)
    {
        return cornersData.FrontRight == Reposition.CounterClockwise &&
             cornersData.FrontLeft == Reposition.None &&
             cornersData.BackLeft == Reposition.None &&
             cornersData.BackRight == Reposition.Clockwise &&
             edgesData.Front == Reposition.Across &&
             edgesData.Left == Reposition.None &&
             edgesData.Back == Reposition.Across &&
             edgesData.Right == Reposition.None;
    }
    
    private static bool GaCondition(CornersRepositionData cornersData, EdgesRepositionData edgesData)
    {
        return cornersData.FrontRight == Reposition.CounterClockwise &&
             cornersData.FrontLeft == Reposition.None &&
             cornersData.BackLeft == Reposition.None &&
             cornersData.BackRight == Reposition.Clockwise &&
             edgesData.Front == Reposition.CounterClockwise &&
             edgesData.Left == Reposition.Clockwise &&
             edgesData.Back == Reposition.Across &&
             edgesData.Right == Reposition.Across;
    }
    private static bool GbCondition(CornersRepositionData cornersData, EdgesRepositionData edgesData)
    {
        return cornersData.FrontRight == Reposition.CounterClockwise &&
             cornersData.FrontLeft == Reposition.None &&
             cornersData.BackLeft == Reposition.None &&
             cornersData.BackRight == Reposition.Clockwise &&
             edgesData.Front == Reposition.Across &&
             edgesData.Left == Reposition.Across &&
             edgesData.Back == Reposition.CounterClockwise &&
             edgesData.Right == Reposition.Clockwise;
    }

    private static bool GcCondition(CornersRepositionData cornersData, EdgesRepositionData edgesData)
    {
        return cornersData.FrontRight == Reposition.CounterClockwise &&
             cornersData.FrontLeft == Reposition.None &&
             cornersData.BackLeft == Reposition.None &&
             cornersData.BackRight == Reposition.Clockwise &&
             edgesData.Front == Reposition.Across &&
             edgesData.Left == Reposition.CounterClockwise &&
             edgesData.Back == Reposition.Clockwise &&
             edgesData.Right == Reposition.Across;
    }

    private static bool GdCondition(CornersRepositionData cornersData, EdgesRepositionData edgesData)
    {
        return cornersData.FrontRight == Reposition.CounterClockwise &&
             cornersData.FrontLeft == Reposition.None &&
             cornersData.BackLeft == Reposition.None &&
             cornersData.BackRight == Reposition.Clockwise &&
             edgesData.Front == Reposition.Clockwise &&
             edgesData.Left == Reposition.Across &&
             edgesData.Back == Reposition.Across &&
             edgesData.Right == Reposition.CounterClockwise;
    }

    private static bool JaCondition(CornersRepositionData cornersData, EdgesRepositionData edgesData)
    {
        return cornersData.FrontRight == Reposition.CounterClockwise &&
             cornersData.FrontLeft == Reposition.None &&
             cornersData.BackLeft == Reposition.None &&
             cornersData.BackRight == Reposition.Clockwise &&
             edgesData.Front == Reposition.CounterClockwise &&
             edgesData.Left == Reposition.None &&
             edgesData.Back == Reposition.None &&
             edgesData.Right == Reposition.Clockwise;
    }

    private static bool JbCondition(CornersRepositionData cornersData, EdgesRepositionData edgesData)
    {
        return cornersData.FrontRight == Reposition.None &&
             cornersData.FrontLeft == Reposition.Clockwise &&
             cornersData.BackLeft == Reposition.CounterClockwise &&
             cornersData.BackRight == Reposition.None &&
             edgesData.Front == Reposition.Clockwise&&
             edgesData.Left == Reposition.CounterClockwise &&
             edgesData.Back == Reposition.None &&
             edgesData.Right == Reposition.None;
    }

    private static bool RaCondition(CornersRepositionData cornersData, EdgesRepositionData edgesData)
    {
        return cornersData.FrontRight == Reposition.None &&
             cornersData.FrontLeft == Reposition.None &&
             cornersData.BackLeft == Reposition.Clockwise &&
             cornersData.BackRight == Reposition.CounterClockwise &&
             edgesData.Front == Reposition.Clockwise &&
             edgesData.Left == Reposition.CounterClockwise &&
             edgesData.Back == Reposition.None &&
             edgesData.Right == Reposition.None;
    }

    private static bool RbCondition(CornersRepositionData cornersData, EdgesRepositionData edgesData)
    {
        return cornersData.FrontRight == Reposition.None &&
             cornersData.FrontLeft == Reposition.None &&
             cornersData.BackLeft == Reposition.Clockwise &&
             cornersData.BackRight == Reposition.CounterClockwise &&
             edgesData.Front == Reposition.CounterClockwise &&
             edgesData.Left == Reposition.None &&
             edgesData.Back == Reposition.None &&
             edgesData.Right == Reposition.Clockwise;
    }
}
