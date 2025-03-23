using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Solver.F2L.Positioning.Corners;

namespace SolveCuber.Solver.F2L.Positioning;

internal static class PiecePositionHelper
{
    private static readonly List<int> _topLayerIndexes = [0, 1, 2, 3, 4, 5, 8, 9, 12, 13, 16, 17];

    private static readonly List<int> _xAxisWhiteFaceIndexes = [8, 9, 10, 11, 16, 17, 18, 19];
    private static readonly List<int> _yAxisWhiteFaceIndexes = [0, 1, 2, 3, 20, 21, 22, 23];    
    private static readonly List<int> _zAxisWhiteFaceIndexes = [4, 5, 6, 7, 12, 13, 14, 15];

    public static WhiteCornersData LocateCorners(Cube cube)
    {
        var flattenedCornerColors = FlattenCornerColors(cube);

        WhiteCornerPosition GreenOrange;
        WhiteCornerPosition OrangeBlue;
        WhiteCornerPosition BlueRed;
        WhiteCornerPosition RedGreen;

        for (int i = 0; i < flattenedCornerColors.Count; i++)
        {
            if (flattenedCornerColors[i] == CubeColor.White)
            {

            }
        }

        return new();
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
        };
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
