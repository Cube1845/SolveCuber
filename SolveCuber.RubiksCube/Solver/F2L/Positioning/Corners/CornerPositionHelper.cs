using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Solver.Common;

namespace SolveCuber.Solver.F2L.Positioning.Corners;

internal static class CornerPositionHelper
{
    private static readonly List<int> _topLayerIndexes = [0, 1, 2, 3, 4, 5, 8, 9, 12, 13, 16, 17];

    public static WhiteCornersData LocateCorners(Cube cube)
    {
        var flattenedCornerColors = FlattenCornerColors(cube);

        WhiteCornerPosition greenOrange = new();
        WhiteCornerPosition orangeBlue = new();
        WhiteCornerPosition blueRed = new();
        WhiteCornerPosition redGreen = new();

        for (int i = 0; i < flattenedCornerColors.Count; i++)
        {
            if (flattenedCornerColors[i] == CubeColor.White)
            {
                var otherColors = GetOtherCornerColors(flattenedCornerColors, i);

                WhiteCornerPosition currentPosition = new
                (
                    _topLayerIndexes.Contains(i),
                    GetCornerLocation(i),
                    GetFaceAxis(i)
                );

                if (otherColors.Contains(CubeColor.Green))
                {
                    if (otherColors.Contains(CubeColor.Orange))
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
                    if (otherColors.Contains(CubeColor.Orange))
                    {
                        orangeBlue = currentPosition;
                    }
                    else
                    {
                        blueRed = currentPosition;
                    }
                }
            }
        }

        return new(greenOrange, orangeBlue, blueRed, redGreen);
    }

    private static List<CubeColor> GetOtherCornerColors(List<CubeColor> flattenedCornerColors, int whiteColorIndex)
    {
        return whiteColorIndex switch
        {
            0 => [flattenedCornerColors[13], flattenedCornerColors[16]],
            1 => [flattenedCornerColors[9], flattenedCornerColors[12]],
            2 => [flattenedCornerColors[4], flattenedCornerColors[17]],
            3 => [flattenedCornerColors[5], flattenedCornerColors[8]],
            4 => [flattenedCornerColors[2], flattenedCornerColors[17]],
            5 => [flattenedCornerColors[3], flattenedCornerColors[8]],
            6 => [flattenedCornerColors[19], flattenedCornerColors[20]],
            7 => [flattenedCornerColors[10], flattenedCornerColors[21]],
            8 => [flattenedCornerColors[5], flattenedCornerColors[3]],
            9 => [flattenedCornerColors[12], flattenedCornerColors[1]],
            10 => [flattenedCornerColors[7], flattenedCornerColors[21]],
            11 => [flattenedCornerColors[14], flattenedCornerColors[23]],
            12 => [flattenedCornerColors[9], flattenedCornerColors[1]],
            13 => [flattenedCornerColors[0], flattenedCornerColors[16]],
            14 => [flattenedCornerColors[11], flattenedCornerColors[23]],
            15 => [flattenedCornerColors[18], flattenedCornerColors[22]],
            16 => [flattenedCornerColors[0], flattenedCornerColors[13]],
            17 => [flattenedCornerColors[2], flattenedCornerColors[4]],
            18 => [flattenedCornerColors[15], flattenedCornerColors[22]],
            19 => [flattenedCornerColors[6], flattenedCornerColors[20]],
            20 => [flattenedCornerColors[19], flattenedCornerColors[6]],
            21 => [flattenedCornerColors[10], flattenedCornerColors[7]],
            22 => [flattenedCornerColors[18], flattenedCornerColors[15]],
            23 => [flattenedCornerColors[11], flattenedCornerColors[14]],

            _ => throw new NotImplementedException()
        };
    }

    private static PieceLocation GetCornerLocation(int whiteColorIndex)
    {
        return whiteColorIndex switch
        {
            0 => PieceLocation.BackLeft,
            1 => PieceLocation.BackRight,
            2 => PieceLocation.FrontLeft,
            3 => PieceLocation.FrontRight,
            4 => PieceLocation.FrontLeft,
            5 => PieceLocation.FrontRight,
            6 => PieceLocation.FrontLeft,
            7 => PieceLocation.FrontRight,
            8 => PieceLocation.FrontRight,
            9 => PieceLocation.BackRight,
            10 => PieceLocation.FrontRight,
            11 => PieceLocation.BackRight,
            12 => PieceLocation.BackRight,
            13 => PieceLocation.BackLeft,
            14 => PieceLocation.BackRight,
            15 => PieceLocation.BackLeft,
            16 => PieceLocation.BackLeft,
            17 => PieceLocation.FrontLeft,
            18 => PieceLocation.BackLeft,
            19 => PieceLocation.FrontLeft,
            20 => PieceLocation.FrontLeft,
            21 => PieceLocation.FrontRight,
            22 => PieceLocation.BackLeft,
            23 => PieceLocation.BackRight,

            _ => throw new NotImplementedException()
        };
    }

    private static readonly List<int> _xAxisWhiteFaceIndexes = [8, 9, 10, 11, 16, 17, 18, 19];
    private static readonly List<int> _yAxisWhiteFaceIndexes = [0, 1, 2, 3, 20, 21, 22, 23];

    private static FaceAxis GetFaceAxis(int whiteColorIndex)
    {
        if (_xAxisWhiteFaceIndexes.Contains(whiteColorIndex))
        {
            return FaceAxis.X;
        }
        else if (_yAxisWhiteFaceIndexes.Contains(whiteColorIndex))
        {
            return FaceAxis.Y;
        }
            
        return FaceAxis.Z;
    }

    private static List<CubeColor> FlattenCornerColors(Cube cube)
    {
        List<CubeColor> flattenedCornerColors = [];

        flattenedCornerColors.AddRange(GetCornerColors(cube.Up));
        flattenedCornerColors.AddRange(GetCornerColors(cube.Front));
        flattenedCornerColors.AddRange(GetCornerColors(cube.Right));
        flattenedCornerColors.AddRange(GetCornerColors(cube.Back));
        flattenedCornerColors.AddRange(GetCornerColors(cube.Left));
        flattenedCornerColors.AddRange(GetCornerColors(cube.Down));

        return flattenedCornerColors;
    }

    private static List<CubeColor> GetCornerColors(CubeFace face)
    {
        return
        [
            face.Face[0, 0],
            face.Face[0, 2],
            face.Face[2, 0],
            face.Face[2, 2],
        ];
    }
}
