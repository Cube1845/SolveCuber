using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Solver.Common;

namespace SolveCuber.Solver.OLL;

internal static class YellowPiecesPositioningHelper
{
    public static FaceAxis[,] GetYellowPiecesFaceAxis(Cube cube)
    {
        var flattenedTopLayerColors = FlattenTopLayerColors(cube);

        List<int> yellowColorIndexes = [];

        for (int i = 0; i < flattenedTopLayerColors.Count; i++)
        {
            if (flattenedTopLayerColors[i] == CubeColor.Yellow)
            {
                yellowColorIndexes.Add(i);
            }
        }

        FaceAxis[,] topLayerOrientations = new FaceAxis[3, 3];

        for (int i = 0; i < yellowColorIndexes.Count; i++)
        {
            var currentLocation = GetPieceIndexes(yellowColorIndexes[i]);

            topLayerOrientations[currentLocation.Y, currentLocation.X] = GetFaceAxis(yellowColorIndexes[i]);
        }

        return topLayerOrientations;
    }

    private static readonly List<int> _xFaceAxisIndexes = [12, 13, 14, 18, 19, 20];
    private static readonly List<int> _yFaceAxisIndexes = [0, 1, 2, 3, 4, 5, 6, 7, 8];
    private static readonly List<int> _zFaceAxisIndexes = [9, 10, 11, 15, 16, 17];

    private static FaceAxis GetFaceAxis(int stickerIndex)
    {
        return stickerIndex switch
        {
            int i when _xFaceAxisIndexes.Contains(i) => FaceAxis.X,
            int i when _yFaceAxisIndexes.Contains(i) => FaceAxis.Y,
            int i when _zFaceAxisIndexes.Contains(i) => FaceAxis.Z,

            _ => throw new NotImplementedException()
        };
    }

    private static (int Y, int X) GetPieceIndexes(int stickerIndex)
    {
        return stickerIndex switch
        {
            0 or 17 or 18 => (0, 0),
            1 or 16 => (0, 1),
            2 or 15 or 14 => (0, 2),

            3 or 19 => (1, 0),
            4 => (1, 1),
            5 or 13 => (1, 2),

            6 or 9 or 20 => (2, 0),
            7 or 10 => (2, 1),
            8 or 11 or 12 => (2, 2),

            _ => throw new NotImplementedException()
        };
    }

    private static List<CubeColor> FlattenTopLayerColors(Cube cube)
    {
        return
        [
            cube.Up.Face[0, 0],
            cube.Up.Face[0, 1],
            cube.Up.Face[0, 2],

            cube.Up.Face[1, 0],
            cube.Up.Face[1, 1],
            cube.Up.Face[1, 2],

            cube.Up.Face[2, 0],
            cube.Up.Face[2, 1],
            cube.Up.Face[2, 2],

            cube.Front.Face[0, 0],
            cube.Front.Face[0, 1],
            cube.Front.Face[0, 2],

            cube.Right.Face[0, 0],
            cube.Right.Face[0, 1],
            cube.Right.Face[0, 2],

            cube.Back.Face[0, 0],
            cube.Back.Face[0, 1],
            cube.Back.Face[0, 2],

            cube.Left.Face[0, 0],
            cube.Left.Face[0, 1],
            cube.Left.Face[0, 2]
        ];
    }
}
