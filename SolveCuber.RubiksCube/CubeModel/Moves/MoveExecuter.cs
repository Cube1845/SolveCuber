using SolveCuber.CubeModel.Models;
using SolveCuber.CubeModel.Moves.Moves;

namespace SolveCuber.CubeModel.Moves;

internal static class MoveExecuter
{
    public static Cube GetCubeImageAfterMove(Cube cube, CubeMove move)
    {
        return move switch
        {
            CubeMove.U => UpMovesExecuter.ExecuteUpMove(cube),
            //CubeMove.U_ => UpMovesExecuter.ExecuteUpPrimeMove(cube),
            //CubeMove.U2 => UpMovesExecuter.ExecuteDoubleUpMove(cube),
            _ => throw new NotImplementedException()
        };
    }
}
