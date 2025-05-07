using SolveCuber.Common;
using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;

namespace SolveCuber.Provider;

internal static class CubeValidator
{
    public static bool ValidateCubeColors(Cube cube)
    {
        List<CubeColor> flattenedCubeColors = FlattenCubeColors(cube);

        for (int i = 1; i <= 6; i++)
        {
            var currentCubeColorCount = flattenedCubeColors
                .Where(c => c == (CubeColor)i)
                .Count();

            if (currentCubeColorCount != 9)
            {
                return false;
            }
        }

        return true;
    }

    private static List<CubeColor> FlattenCubeColors(Cube cube)
    {
        return
        [
            .. FlattenFaceColors(cube.Up),
            .. FlattenFaceColors(cube.Down),
            .. FlattenFaceColors(cube.Right),
            .. FlattenFaceColors(cube.Left),
            .. FlattenFaceColors(cube.Front),
            .. FlattenFaceColors(cube.Back),
        ];
    }

    private static List<CubeColor> FlattenFaceColors(CubeFace cubeFace)
    {
        List<CubeColor> flattenedFaceColors = [];

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                flattenedFaceColors.Add(cubeFace.Face[i, j]);
            }
        }

        return flattenedFaceColors;
    }

    public static bool ValidateCenters(Cube cube)
    {
        var centerColorsValid = ValidateCenterColors(cube);

        if (!centerColorsValid)
        {
            return false;
        }

        var cubeCopy = cube.DeepCopy();

        try
        {
            CubeOrienter.OrientCube(cubeCopy, CubeColor.White, CubeColor.Green);
        }
        catch
        {
            return false;
        }

        return cubeCopy.Left.Face[1, 1] == CubeColor.Orange &&
            cubeCopy.Right.Face[1, 1] == CubeColor.Red &&
            cubeCopy.Back.Face[1, 1] == CubeColor.Blue &&
            cubeCopy.Down.Face[1, 1] == CubeColor.Yellow;
    }

    private static bool ValidateCenterColors(Cube cube)
    {
        List<CubeColor> centerColors =
        [
            cube.Up.Face[1, 1],
            cube.Down.Face[1, 1],
            cube.Front.Face[1, 1],
            cube.Back.Face[1, 1],
            cube.Right.Face[1, 1],
            cube.Left.Face[1, 1],
        ];

        for (int i = 1; i <= 6; i++)
        {
            if (!centerColors.Contains((CubeColor)i))
            {
                return false;
            }
        }

        return true;
    }
}
