using SolveCuber.CubeModel;

namespace SolveCuber.Common;

internal static class MoveOptimizer
{
    public static List<CubeMove> OptimizeMoves(List<CubeMove> moves)
    {
        if (moves.Count == 0)
        {
            return moves;
        }

        List<CubeMove> optimizedMoves = [];
        Stack<CubeMove> moveStack = new();

        foreach (var move in moves)
        {
            if (moveStack.Count == 0)
            {
                moveStack.Push(move);
            }
            else
            {
                var previousMove = moveStack.Peek();

                if (AreOppositeMoves(previousMove, move))
                {
                    moveStack.Pop();
                }
                else if (AreSameTypeMoves(previousMove, move))
                {
                    moveStack.Pop();
                    var combinedMove = CombineMoves(previousMove, move);
                    if (combinedMove.HasValue)
                    {
                        moveStack.Push(combinedMove.Value);
                    }
                }
                else
                {
                    moveStack.Push(move);
                }
            }
        }

        optimizedMoves = moveStack.Reverse().ToList();
        return optimizedMoves;
    }

    private static bool AreOppositeMoves(CubeMove move1, CubeMove move2)
    {
        return (move1 == CubeMove.U && move2 == CubeMove.U_) ||
               (move1 == CubeMove.U_ && move2 == CubeMove.U) ||
               (move1 == CubeMove.D && move2 == CubeMove.D_) ||
               (move1 == CubeMove.D_ && move2 == CubeMove.D) ||
               (move1 == CubeMove.F && move2 == CubeMove.F_) ||
               (move1 == CubeMove.F_ && move2 == CubeMove.F) ||
               (move1 == CubeMove.B && move2 == CubeMove.B_) ||
               (move1 == CubeMove.B_ && move2 == CubeMove.B) ||
               (move1 == CubeMove.R && move2 == CubeMove.R_) ||
               (move1 == CubeMove.R_ && move2 == CubeMove.R) ||
               (move1 == CubeMove.L && move2 == CubeMove.L_) ||
               (move1 == CubeMove.L_ && move2 == CubeMove.L);
    }

    private static bool AreSameTypeMoves(CubeMove move1, CubeMove move2)
    {
        return GetMoveType(move1) == GetMoveType(move2);
    }

    private static CubeMove? CombineMoves(CubeMove move1, CubeMove move2)
    {
        var moveType = GetMoveType(move1);

        if (moveType == null)
            return null;

        var move1Suffix = GetMoveSuffix(move1);
        var move2Suffix = GetMoveSuffix(move2);

        if (move1Suffix == "2" && move2Suffix == "2")
        {
            return null;
        }
        else if (move1Suffix == "" && move2Suffix == "")
        {
            return (CubeMove)Enum.Parse(typeof(CubeMove), $"{moveType}2");
        }
        else if (move1Suffix == "_" && move2Suffix == "_")
        {
            return (CubeMove)Enum.Parse(typeof(CubeMove), $"{moveType}2");
        }
        else if ((move1Suffix == "" && move2Suffix == "2") || (move1Suffix == "2" && move2Suffix == ""))
        {
            return (CubeMove)Enum.Parse(typeof(CubeMove), $"{moveType}_");
        }
        else if ((move1Suffix == "_" && move2Suffix == "2") || (move1Suffix == "2" && move2Suffix == "_"))
        {
            return (CubeMove)Enum.Parse(typeof(CubeMove), $"{moveType}");
        }

        return null;
    }

    private static string GetMoveType(CubeMove move)
    {
        var moveName = move.ToString();
        return moveName.Replace("_", "").Replace("2", "");
    }

    private static string GetMoveSuffix(CubeMove move)
    {
        var moveName = move.ToString();
        if (moveName.EndsWith("2"))
            return "2";
        else if (moveName.EndsWith("_"))
            return "_";
        else
            return "";
    }
}
