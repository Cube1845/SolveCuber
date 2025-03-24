using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;

namespace SolveCuber.Solver.F2L.Positioning.Edges;

internal static class EdgePositionHelper
{
    private static readonly List<int> _topLayerIndexes = [0, 1, 2, 3, 4, 7, 10, 13];
    private static readonly List<CubeColor> _primaryColors = [CubeColor.Green, CubeColor.Blue];

    public static NonYellowEdgesData LocateEdges(Cube cube)
    {
        var flattenedEdgeColors = FlattenEdgeColors(cube);

        var yellowEdgeIndexes = GetYellowEdgeIndexes(flattenedEdgeColors);

        List<int> usedEdgeIndexes = [];

        NonYellowEdgePosition greenOrange = new();
        NonYellowEdgePosition orangeBlue = new();
        NonYellowEdgePosition blueRed = new();
        NonYellowEdgePosition redGreen = new();

        for (int i = 0; i < flattenedEdgeColors.Count; i++)
        {
            if (yellowEdgeIndexes.Contains(i) || usedEdgeIndexes.Contains(i))
            {
                continue;
            }

            var secondEdgeColorIndex = GetOtherEdgeColor(i);

            usedEdgeIndexes.Add(i);
            usedEdgeIndexes.Add(secondEdgeColorIndex);

            NonYellowEdgePosition currentPosition = new
            (
                _topLayerIndexes.Contains(i),
                GetEdgeLocation(i),
                _primaryColors.Contains(flattenedEdgeColors[i]) ? GetFaceAxis(i) : GetFaceAxis(secondEdgeColorIndex)
            );

            if (flattenedEdgeColors[i] == CubeColor.Green || flattenedEdgeColors[secondEdgeColorIndex] == CubeColor.Green)
            {
                if (flattenedEdgeColors[i] == CubeColor.Orange || flattenedEdgeColors[secondEdgeColorIndex] == CubeColor.Orange)
                {
                    greenOrange = currentPosition;
                }
                else
                {
                    redGreen = currentPosition;
                }
            }
            else
            {
                if (flattenedEdgeColors[i] == CubeColor.Orange || flattenedEdgeColors[secondEdgeColorIndex] == CubeColor.Orange)
                {
                    orangeBlue = currentPosition;
                }
                else
                {
                    blueRed = currentPosition;
                }
            }
        }

        return new(greenOrange, orangeBlue, blueRed, redGreen);
    }

    private static PieceLocation GetEdgeLocation(int index)
    {
        return index switch
        {
            0 => PieceLocation.BackRight,
            1 => PieceLocation.BackLeft,
            2 => PieceLocation.FrontRight,
            3 => PieceLocation.FrontLeft,
            4 => PieceLocation.FrontLeft,
            5 => PieceLocation.FrontLeft,
            6 => PieceLocation.FrontRight,
            7 => PieceLocation.FrontRight,
            8 => PieceLocation.FrontRight,
            9 => PieceLocation.BackRight,
            10 => PieceLocation.BackRight,
            11 => PieceLocation.BackRight,
            12 => PieceLocation.BackLeft,
            13 => PieceLocation.BackLeft,
            14 => PieceLocation.BackLeft,
            15 => PieceLocation.FrontLeft,

            _ => throw new NotImplementedException()
        };
    }

    private static List<int> GetYellowEdgeIndexes(List<CubeColor> flattenedEdgeColors)
    {
        List<int> yellowEdgeIndexes = [];

        for (int i = 0; i < flattenedEdgeColors.Count; i++)
        {
            if (flattenedEdgeColors[i] == CubeColor.Yellow)
            {
                yellowEdgeIndexes.Add(i);
                yellowEdgeIndexes.Add(GetOtherEdgeColor(i));
            }
        }

        return yellowEdgeIndexes;
    }

    private static int GetOtherEdgeColor(int firstColorEdgeIndex)
    {
        return firstColorEdgeIndex switch
        {
            0 => 10,
            1 => 13,
            2 => 7,
            3 => 4,
            4 => 3,
            5 => 15,
            6 => 8,
            7 => 2,
            8 => 6,
            9 => 11,
            10 => 0,
            11 => 9,
            12 => 14,
            13 => 1,
            14 => 12,
            15 => 5,

            _ => throw new NotImplementedException()
        };
    }

    private static readonly List<int> _xAxisWhiteFaceIndexes = [7, 8, 9, 13, 14, 15];
    private static readonly List<int> _yAxisWhiteFaceIndexes = [0, 1, 2, 3];

    private static FaceAxis GetFaceAxis(int primaryColorIndex)
    {
        if (_xAxisWhiteFaceIndexes.Contains(primaryColorIndex))
        {
            return FaceAxis.X;
        }
        else if (_yAxisWhiteFaceIndexes.Contains(primaryColorIndex))
        {
            return FaceAxis.Y;
        }

        return FaceAxis.Z;
    }

    private static List<CubeColor> FlattenEdgeColors(Cube cube)
    {
        List<CubeColor> flattenedEdgeColors = [];

        flattenedEdgeColors.AddRange(GetEdgeColors(cube.Up, true));

        flattenedEdgeColors.AddRange(GetEdgeColors(cube.Front));
        flattenedEdgeColors.AddRange(GetEdgeColors(cube.Right));
        flattenedEdgeColors.AddRange(GetEdgeColors(cube.Back));
        flattenedEdgeColors.AddRange(GetEdgeColors(cube.Left));

        return flattenedEdgeColors;
    }

    private static List<CubeColor> GetEdgeColors(CubeFace face, bool downEdge = false)
    {
        return !downEdge
        ? 
        [
            face.Face[0, 1],
            face.Face[1, 0],
            face.Face[1, 2],
        ]
        :
        [
            face.Face[0, 1],
            face.Face[1, 0],
            face.Face[1, 2],
            face.Face[2, 1],
        ];
    }
}
