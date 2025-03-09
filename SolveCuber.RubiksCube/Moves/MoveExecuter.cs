using SolveCuber.RubiksCube.Models;
using SolveCuber.RubiksCube.Moves.Moves;

namespace SolveCuber.RubiksCube.Moves;

internal static class MoveExecuter
{
    public static Cube GetCubeImageAfterMove(Cube cube, CubeMove move)
    {
        return move switch
        {
            CubeMove.U => UpMoveHandler.ExecuteUpMove(cube),
            CubeMove.U_ => UpMoveHandler.ExecuteUpPrimeMove(cube),
            CubeMove.U2 => UpMoveHandler.ExecuteDoubleUpMove(cube),
            _ => throw new NotImplementedException()
        };
    }
}
