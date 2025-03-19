using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;

namespace SolveCuber.Scramble;
public static class Scrambler
{
    private static readonly int _scrambleMovesEnumLength = 18;

    private static readonly int _scrambleLength = 25;

    public static List<CubeMove> ScrambleCube(Cube cube)
    {
        var scramble = GenerateScramble(_scrambleLength);

        cube.ExecuteAlgorithm(scramble);

        return scramble;
    }

    public static List<CubeMove> GenerateScramble(int length)
    {
        List<CubeMove> scramble = [];
        CubeMove? previousMove = null;
        CubeMove? secondLastMove = null;

        while (scramble.Count < length)
        {
            CubeMove randomMove = (CubeMove)Random.Shared.Next(1, _scrambleMovesEnumLength + 1);

            if (IsValidMove(randomMove, previousMove, secondLastMove))
            {
                scramble.Add(randomMove);
                secondLastMove = previousMove;
                previousMove = randomMove;
            }
        }

        return scramble;
    }

    private static bool IsValidMove(CubeMove currentMove, CubeMove? previousMove, CubeMove? secondLastMove)
    {
        if (previousMove == null)
        {
            return true;
        }

        string currentFace = currentMove.ToString().TrimEnd('_', '2');
        string previousFace = previousMove.Value.ToString().TrimEnd('_', '2');
        string secondLastFace = secondLastMove?.ToString().TrimEnd('_', '2') ?? string.Empty;

        if (currentFace == previousFace)
        {
            return false;
        }

        if (secondLastMove != null)
        {
            if (currentFace == secondLastFace)
            {
                if (AreOppositeFaces(previousFace, secondLastFace))
                {
                    return false;
                }
            }
        }

        return true;
    }

    private static bool AreOppositeFaces(string face1, string face2)
    {
        var oppositeFaces = new Dictionary<string, string>
        {
            { "U", "D" },
            { "D", "U" },
            { "F", "B" },
            { "B", "F" },
            { "R", "L" },
            { "L", "R" }
        };

        return oppositeFaces.TryGetValue(face1, out string? opposite) && opposite == face2;
    }
}
