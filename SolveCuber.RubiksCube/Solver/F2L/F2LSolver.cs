using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Solver.F2L.Positioning.Corners;
using SolveCuber.Solver.F2L.Positioning.Edges;

namespace SolveCuber.Solver.F2L;

public static class F2LSolver
{
    public static List<CubeMove> SolveF2l(Cube cube)
    {
        var x = CornerPositionHelper.LocateCorners(cube);
        var y = EdgePositionHelper.LocateEdges(cube);

        return [];
    }
}
