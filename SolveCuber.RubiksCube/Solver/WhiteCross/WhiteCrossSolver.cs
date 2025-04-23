using SolveCuber.Common;
using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Solver.Common;

namespace SolveCuber.Solver.WhiteCross;

public static class WhiteCrossSolver
{
    private readonly static List<CubeColor> _secondWhiteEdgeColors =
        [CubeColor.Green, CubeColor.Orange, CubeColor.Red, CubeColor.Blue];

    private readonly static List<List<CubeColor>> _edgeSolvingOrders = 
    [
        [CubeColor.Green, CubeColor.Orange, CubeColor.Red, CubeColor.Blue],
        [CubeColor.Green, CubeColor.Orange, CubeColor.Blue, CubeColor.Red],
        [CubeColor.Green, CubeColor.Red, CubeColor.Blue, CubeColor.Orange],
        [CubeColor.Green, CubeColor.Red, CubeColor.Orange, CubeColor.Blue],
        [CubeColor.Green, CubeColor.Blue, CubeColor.Orange, CubeColor.Red],
        [CubeColor.Green, CubeColor.Blue, CubeColor.Red, CubeColor.Orange],

        [CubeColor.Orange, CubeColor.Green, CubeColor.Red, CubeColor.Blue],
        [CubeColor.Orange, CubeColor.Green, CubeColor.Blue, CubeColor.Red],
        [CubeColor.Orange, CubeColor.Red, CubeColor.Blue, CubeColor.Green],
        [CubeColor.Orange, CubeColor.Red, CubeColor.Green, CubeColor.Blue],
        [CubeColor.Orange, CubeColor.Blue, CubeColor.Green, CubeColor.Red],
        [CubeColor.Orange, CubeColor.Blue, CubeColor.Red, CubeColor.Green],

        [CubeColor.Red, CubeColor.Orange, CubeColor.Green, CubeColor.Blue],
        [CubeColor.Red, CubeColor.Orange, CubeColor.Blue, CubeColor.Green],
        [CubeColor.Red, CubeColor.Green, CubeColor.Blue, CubeColor.Orange],
        [CubeColor.Red, CubeColor.Green, CubeColor.Orange, CubeColor.Blue],
        [CubeColor.Red, CubeColor.Blue, CubeColor.Orange, CubeColor.Green],
        [CubeColor.Red, CubeColor.Blue, CubeColor.Green, CubeColor.Orange],

        [CubeColor.Blue, CubeColor.Orange, CubeColor.Red, CubeColor.Green],
        [CubeColor.Blue, CubeColor.Orange, CubeColor.Green, CubeColor.Red],
        [CubeColor.Blue, CubeColor.Red, CubeColor.Green, CubeColor.Orange],
        [CubeColor.Blue, CubeColor.Red, CubeColor.Orange, CubeColor.Green],
        [CubeColor.Blue, CubeColor.Green, CubeColor.Orange, CubeColor.Red],
        [CubeColor.Blue, CubeColor.Green, CubeColor.Red, CubeColor.Orange],
    ];

    /// <summary>
    /// Solves White Cross on the cube.
    /// </summary>
    /// <param name="cube">Cube you want to solve the white cross on</param>
    /// <returns> Sequence of moves that solves the cross.</returns>
    public static List<CubeMove> SolveCross(Cube cube)
    {
        var cubeCopy = cube.DeepCopy();

        var cubeRotations = CubeOrienter.OrientCube(cubeCopy, CubeColor.Green, CubeColor.White);

        if (IsCrossSolved(cubeCopy))
        {
            return [];
        }

        CubeMove? firstUMove = null;

        if (IsAnyWhiteEdgeOnUpFace(cubeCopy))
        {
            var topFaceWhiteEdgePositioningMove = GetMoveThatPositionsTheMostEdgesCorrect(cubeCopy);

            if (topFaceWhiteEdgePositioningMove != null)
            {
                cubeCopy.ExecuteMove(topFaceWhiteEdgePositioningMove!.Value);
                firstUMove = topFaceWhiteEdgePositioningMove!.Value;
            }
        }

        var moves = GetSolutionWithLeastMoves(cubeCopy);

        cubeCopy.ExecuteAlgorithm(moves);

        List<CubeMove> fullMoves = firstUMove is not null
            ? [firstUMove.Value, .. moves]
            : [.. moves];

        List<CubeMove> output = MoveOptimizer.OptimizeMoves([.. cubeRotations, .. fullMoves]);

        cube.ExecuteAlgorithm(output);

        return output;
    }

    private static CubeMove? GetMoveThatPositionsTheMostEdgesCorrect(Cube cube)
    {
        List<int> correctlyPlacedEdgesForSolutions = [];

        Cube cubeCopy = cube.DeepCopy();
        correctlyPlacedEdgesForSolutions.Add(GetCorrectlyPlacedEdgesCount(cubeCopy));

        for (int i = 0; i < (_secondWhiteEdgeColors.Count - 1); i++)
        {
            cubeCopy.ExecuteMove(CubeMove.U);

            correctlyPlacedEdgesForSolutions.Add(GetCorrectlyPlacedEdgesCount(cubeCopy));
        }

        var mostEdgesCorrectIndex = correctlyPlacedEdgesForSolutions.IndexOf(correctlyPlacedEdgesForSolutions.Max());

        return mostEdgesCorrectIndex switch
        {
            0 => null,
            1 => CubeMove.U,
            2 => CubeMove.U2,
            3 => CubeMove.U_,

            _ => throw new Exception()
        };
    }

    private static int GetCorrectlyPlacedEdgesCount(Cube cube)
    {
        WhiteEdgesData edgesData = GetWhiteEdgeLocations(cube);
        int correctlyPlacedEdges = 0;

        foreach (var color in _secondWhiteEdgeColors)
        {
            if (WhiteEdgePositioningHelper.IsInCorrectPlace(color, edgesData.GetLocation(color)))
            {
                correctlyPlacedEdges++;
            }
        }

        return correctlyPlacedEdges;
    }

    private static bool IsAnyWhiteEdgeOnUpFace(Cube cube)
    {
        WhiteEdgesData edgesData = GetWhiteEdgeLocations(cube);

        int edgesOnTopFaceCount = 0;

        foreach (var color in _secondWhiteEdgeColors)
        {
            var currentLocation = edgesData.GetLocation(color);

            if (currentLocation.ToString().StartsWith("Up"))
            {
                edgesOnTopFaceCount++;
            }
        }

        return edgesOnTopFaceCount > 0;
    }

    private static List<CubeMove> GetSolutionWithLeastMoves(Cube cube)
    {
        List<List<CubeMove>> solutions = [];

        foreach (var colorOrder in _edgeSolvingOrders)
        {
            var solution = GetSolvingCrossMovesForOrder(cube, colorOrder);
            solutions.Add(solution);
        }

        var orderedSolutions = solutions.OrderBy(s => s.Count).ToList();

        return orderedSolutions[0];
    }

    private static List<CubeMove> GetSolvingCrossMovesForOrder(Cube cube, List<CubeColor> colorOrder)
    {
        Cube cubeCopy = cube.DeepCopy();

        List<CubeMove> moves = [];

        foreach (var secondWhiteEdgeColor in colorOrder)
        {
            WhiteEdgesData edgesData = GetWhiteEdgeLocations(cubeCopy);

            var currentMoves = WhiteEdgePositioningHelper.
                GetWhiteEdgePositioningMoves(edgesData.GetLocation(secondWhiteEdgeColor), secondWhiteEdgeColor);

            cubeCopy.ExecuteAlgorithm(currentMoves);

            moves.AddRange(currentMoves);
        }

        if (!IsCrossSolved(cubeCopy))
        {
            throw new Exception();
        }

        return MoveOptimizer.OptimizeMoves(moves);
    }

    private static bool IsCrossSolved(Cube cube)
    {
        WhiteEdgesData edgesData = GetWhiteEdgeLocations(cube);

        foreach (var color in _secondWhiteEdgeColors)
        {
            if (!WhiteEdgePositioningHelper.IsInCorrectPlace(color, edgesData.GetLocation(color)))
            {
                return false;
            }
        }

        return true;
    }

    private static WhiteEdgesData GetWhiteEdgeLocations(Cube cube)
    {
        WhiteEdgesData edgesData = new();

        List<CubeColor> flattenedEdgeColors = FlattenEdgeColors(cube);

        for (int i = 0; i < 24; i++)
        {
            if (flattenedEdgeColors[i] == CubeColor.White)
            {
                var location = (WhiteEdgeLocation)(i + 1);
                var secondLocation = GetSecondColorLocationOfTheWhiteEdge(location);

                switch (flattenedEdgeColors[((int)secondLocation) - 1])
                {
                    case CubeColor.Green:
                        edgesData.Green = location;
                        break;

                    case CubeColor.Orange:
                        edgesData.Orange = location;
                        break;

                    case CubeColor.Red:
                        edgesData.Red = location;
                        break;

                    case CubeColor.Blue:
                        edgesData.Blue = location;
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
        }

        return edgesData;
    }

    private static List<CubeColor> FlattenEdgeColors(Cube cube)
    {
        List<CubeColor> flattenedColors = [];

        flattenedColors.AddRange(GetEdgeColors(cube.Up));
        flattenedColors.AddRange(GetEdgeColors(cube.Down));

        flattenedColors.AddRange(GetEdgeColors(cube.Front));
        flattenedColors.AddRange(GetEdgeColors(cube.Back));

        flattenedColors.AddRange(GetEdgeColors(cube.Right));
        flattenedColors.AddRange(GetEdgeColors(cube.Left));

        return flattenedColors;
    }

    private static List<CubeColor> GetEdgeColors(CubeFace face)
    {
        return 
        [
            face.Face[0, 1],
            face.Face[1, 0],
            face.Face[1, 2],
            face.Face[2, 1]
        ];
    }

    private static WhiteEdgeLocation GetSecondColorLocationOfTheWhiteEdge(WhiteEdgeLocation whiteStickerLocation)
    {
        var name = whiteStickerLocation.ToString();
        var match = System.Text.RegularExpressions.Regex.Match(name, "^([A-Z][a-z]*)([A-Z][a-z]*)$");

        if (!match.Success || !Enum.TryParse($"{match.Groups[2].Value}{match.Groups[1].Value}", out WhiteEdgeLocation result))
        {
            throw new NotImplementedException();
        }

        return result;
    }
}