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

        moves = OptimizeRotationPairs(moves);

        List<CubeMove> optimizedMoves = [];
        Stack<CubeMove> moveStack = [];

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

    private static string GetRotationAxis(CubeMove move)
    {
        string moveStr = move.ToString();
        if (moveStr.StartsWith("x")) return "x";
        if (moveStr.StartsWith("y")) return "y";
        if (moveStr.StartsWith("z")) return "z";
        return "";
    }

    private static bool IsMoveAffectedByRotation(CubeMove move, string rotationAxis)
    {
        var moveType = GetMoveType(move);

        return (rotationAxis == "y" && (moveType == "R" || moveType == "L" || moveType == "F" || moveType == "B")) ||
               (rotationAxis == "x" && (moveType == "U" || moveType == "D" || moveType == "F" || moveType == "B")) ||
               (rotationAxis == "z" && (moveType == "U" || moveType == "D" || moveType == "R" || moveType == "L"));
    }

    private static List<CubeMove> OptimizeRotationPairs(List<CubeMove> moves)
    {
        var optimized = new List<CubeMove>();
        int i = 0;

        while (i < moves.Count)
        {
            if (IsRotation(moves[i]) && i + 2 < moves.Count)
            {
                var rotation1 = moves[i];
                var middleMove = moves[i + 1];
                var rotation2 = moves[i + 2];

                if (GetRotationAxis(rotation1) == GetRotationAxis(rotation2))
                {
                    if (!IsMoveAffectedByRotation(middleMove, GetRotationAxis(rotation1)))
                    {
                        var combinedRotation = CombineMoves(rotation1, rotation2);

                        if (combinedRotation.HasValue)
                        {
                            optimized.Add(combinedRotation.Value);
                            optimized.Add(middleMove);
                            i += 3;
                            continue;
                        }
                        else
                        {
                            optimized.Add(middleMove);
                            i += 3;
                            continue;
                        }
                    }
                }
            }
            optimized.Add(moves[i]);
            i++;
        }

        return optimized;
    }

    private static bool DoesMoveInterfereWithRotation(CubeMove move, CubeMove rotation)
    {
        string moveFace = GetMoveType(move);
        string rotationAxis = GetMoveType(rotation);

        return (rotationAxis == "y" && (moveFace == "U" || moveFace == "D")) ||
               (rotationAxis == "x" && (moveFace == "R" || moveFace == "L")) ||
               (rotationAxis == "z" && (moveFace == "F" || moveFace == "B"));
    }

    private static bool IsRotation(CubeMove move)
    {
        string moveStr = move.ToString();
        return moveStr.StartsWith("x") || moveStr.StartsWith("y") || moveStr.StartsWith("z");
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
        {
            return null;
        }

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
        {
            return "2";
        }
        else if (moveName.EndsWith("_"))
        {
            return "_";
        }
        else
        {
            return "";
        }
    }
}