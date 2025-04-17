using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Solver.PLL.Models;

namespace SolveCuber.Solver.PLL;

internal class PLLDefiner
{
    private readonly static int _pllCount = 21;

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
                if (NoPLLCondition(cornersRepositionData, edgesRepositionData))
                {
                    return [];
                }

                if (IsPLL(cornersRepositionData, edgesRepositionData, (Models.PLL)j))
                {
                    return PLLAlgorithms.GetPLL((Models.PLL)j);
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
            Models.PLL.T => TCondition(cornersRepositionData, edgesRepositionData),
            Models.PLL.E => ECondition(cornersRepositionData, edgesRepositionData),
            Models.PLL.Na => NaCondition(cornersRepositionData, edgesRepositionData),
            Models.PLL.Nb => NbCondition(cornersRepositionData, edgesRepositionData),
            Models.PLL.V => VCondition(cornersRepositionData, edgesRepositionData),
            Models.PLL.Y => YCondition(cornersRepositionData, edgesRepositionData),
            Models.PLL.H => HCondition(cornersRepositionData, edgesRepositionData),
            Models.PLL.Ua => UaCondition(cornersRepositionData, edgesRepositionData),
            Models.PLL.Ub => UbCondition(cornersRepositionData, edgesRepositionData),
            Models.PLL.Z => ZCondition(cornersRepositionData, edgesRepositionData),

            _ => false
        };
    }

    private static bool NoPLLCondition(CornersRepositionData cornersData, EdgesRepositionData edgesData)
    {
        return cornersData.FrontRight == Reposition.None &&
             cornersData.FrontLeft == Reposition.None &&
             cornersData.BackLeft == Reposition.None &&
             cornersData.BackRight == Reposition.None &&
             edgesData.Front == Reposition.None &&
             edgesData.Left == Reposition.None &&
             edgesData.Back == Reposition.None &&
             edgesData.Right == Reposition.None;
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

    private static bool TCondition(CornersRepositionData cornersData, EdgesRepositionData edgesData)
    {
        return cornersData.FrontRight == Reposition.CounterClockwise &&
             cornersData.FrontLeft == Reposition.None &&
             cornersData.BackLeft == Reposition.None &&
             cornersData.BackRight == Reposition.Clockwise &&
             edgesData.Front == Reposition.None &&
             edgesData.Left == Reposition.Across &&
             edgesData.Back == Reposition.None &&
             edgesData.Right == Reposition.Across;
    }

    private static bool ECondition(CornersRepositionData cornersData, EdgesRepositionData edgesData)
    {
        return cornersData.FrontRight == Reposition.CounterClockwise &&
             cornersData.FrontLeft == Reposition.Clockwise &&
             cornersData.BackLeft == Reposition.CounterClockwise &&
             cornersData.BackRight == Reposition.Clockwise &&
             edgesData.Front == Reposition.None &&
             edgesData.Left == Reposition.None &&
             edgesData.Back == Reposition.None &&
             edgesData.Right == Reposition.None;
    }

    private static bool NaCondition(CornersRepositionData cornersData, EdgesRepositionData edgesData)
    {
        return cornersData.FrontRight == Reposition.None &&
             cornersData.FrontLeft == Reposition.Across &&
             cornersData.BackLeft == Reposition.None &&
             cornersData.BackRight == Reposition.Across &&
             edgesData.Front == Reposition.None &&
             edgesData.Left == Reposition.None &&
             edgesData.Back == Reposition.Across &&
             edgesData.Right == Reposition.Across;
    }

    private static bool NbCondition(CornersRepositionData cornersData, EdgesRepositionData edgesData)
    {
        return cornersData.FrontRight == Reposition.Across &&
             cornersData.FrontLeft == Reposition.None &&
             cornersData.BackLeft == Reposition.Across &&
             cornersData.BackRight == Reposition.None &&
             edgesData.Front == Reposition.None &&
             edgesData.Left == Reposition.Across &&
             edgesData.Back == Reposition.None &&
             edgesData.Right == Reposition.Across;
    }

    private static bool VCondition(CornersRepositionData cornersData, EdgesRepositionData edgesData)
    {
        return cornersData.FrontRight == Reposition.Across &&
             cornersData.FrontLeft == Reposition.None &&
             cornersData.BackLeft == Reposition.Across &&
             cornersData.BackRight == Reposition.None &&
             edgesData.Front == Reposition.None &&
             edgesData.Left == Reposition.None &&
             edgesData.Back == Reposition.Clockwise &&
             edgesData.Right == Reposition.CounterClockwise;
    }

    private static bool YCondition(CornersRepositionData cornersData, EdgesRepositionData edgesData)
    {
        return cornersData.FrontRight == Reposition.Across &&
             cornersData.FrontLeft == Reposition.None &&
             cornersData.BackLeft == Reposition.Across &&
             cornersData.BackRight == Reposition.None &&
             edgesData.Front == Reposition.None &&
             edgesData.Left == Reposition.Clockwise &&
             edgesData.Back == Reposition.CounterClockwise &&
             edgesData.Right == Reposition.None;
    }

    private static bool HCondition(CornersRepositionData cornersData, EdgesRepositionData edgesData)
    {
        return cornersData.FrontRight == Reposition.None &&
             cornersData.FrontLeft == Reposition.None &&
             cornersData.BackLeft == Reposition.None &&
             cornersData.BackRight == Reposition.None &&
             edgesData.Front == Reposition.Across &&
             edgesData.Left == Reposition.Across &&
             edgesData.Back == Reposition.Across &&
             edgesData.Right == Reposition.Across;
    }

    private static bool UaCondition(CornersRepositionData cornersData, EdgesRepositionData edgesData)
    {
        return cornersData.FrontRight == Reposition.None &&
             cornersData.FrontLeft == Reposition.None &&
             cornersData.BackLeft == Reposition.None &&
             cornersData.BackRight == Reposition.None &&
             edgesData.Front == Reposition.CounterClockwise &&
             edgesData.Left == Reposition.CounterClockwise &&
             edgesData.Back == Reposition.None &&
             edgesData.Right == Reposition.Across;
    }

    private static bool UbCondition(CornersRepositionData cornersData, EdgesRepositionData edgesData)
    {
        return cornersData.FrontRight == Reposition.None &&
             cornersData.FrontLeft == Reposition.None &&
             cornersData.BackLeft == Reposition.None &&
             cornersData.BackRight == Reposition.None &&
             edgesData.Front == Reposition.Clockwise &&
             edgesData.Left == Reposition.Across &&
             edgesData.Back == Reposition.None &&
             edgesData.Right == Reposition.Clockwise;
    }

    private static bool ZCondition(CornersRepositionData cornersData, EdgesRepositionData edgesData)
    {
        return cornersData.FrontRight == Reposition.None &&
             cornersData.FrontLeft == Reposition.None &&
             cornersData.BackLeft == Reposition.None &&
             cornersData.BackRight == Reposition.None &&
             edgesData.Front == Reposition.Clockwise &&
             edgesData.Left == Reposition.CounterClockwise &&
             edgesData.Back == Reposition.Clockwise &&
             edgesData.Right == Reposition.CounterClockwise;
    }
}
