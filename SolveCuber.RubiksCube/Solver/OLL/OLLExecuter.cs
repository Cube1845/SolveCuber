using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;

namespace SolveCuber.Solver.OLL;

public static class OLLExecuter
{
    public static List<CubeMove> ExecuteOLL(Cube cube)
    {
        var topLayerOrientations = YellowPiecesPositioningHelper.GetYellowPiecesFaceAxis(cube);

        return [];
    }
}
