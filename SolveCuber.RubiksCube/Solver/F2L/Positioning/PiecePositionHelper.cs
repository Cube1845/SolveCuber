using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;

namespace SolveCuber.Solver.F2L.Positioning;

internal static class PiecePositionHelper
{
    public static WhiteCornersData LocateCorners(Cube cube)
    {
        return new();
    }

    private static List<CubeColor> FlattenCornerColors(Cube cube)
    {
        List<CubeColor> flattenedCornerColors = [];

        flattenedCornerColors.AddRange(GetCornerColors(cube.Up));

        flattenedCornerColors.AddRange(GetCornerColors(cube.Front));
        flattenedCornerColors.AddRange(GetCornerColors(cube.Right));
        flattenedCornerColors.AddRange(GetCornerColors(cube.Back));
        flattenedCornerColors.AddRange(GetCornerColors(cube.Left));

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
