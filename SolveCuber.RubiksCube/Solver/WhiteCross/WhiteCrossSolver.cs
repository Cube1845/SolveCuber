using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using System.Drawing;

namespace SolveCuber.Solver.WhiteCross;

public static class WhiteCrossSolver
{
    public static List<CubeMove> SolveCross(Cube cube)
    {
        var whiteEdgesData = GetWhiteEdgeLocations(cube);

        return [];
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
        return whiteStickerLocation switch
        {
            WhiteEdgeLocation.UpBack => WhiteEdgeLocation.BackUp,
            WhiteEdgeLocation.UpLeft => WhiteEdgeLocation.LeftUp,
            WhiteEdgeLocation.UpRight => WhiteEdgeLocation.RightUp,
            WhiteEdgeLocation.UpFront => WhiteEdgeLocation.FrontUp,

            WhiteEdgeLocation.DownFront => WhiteEdgeLocation.FrontDown,
            WhiteEdgeLocation.DownLeft => WhiteEdgeLocation.LeftDown,
            WhiteEdgeLocation.DownRight => WhiteEdgeLocation.RightDown,
            WhiteEdgeLocation.DownBack => WhiteEdgeLocation.BackDown,

            WhiteEdgeLocation.FrontUp => WhiteEdgeLocation.UpFront,
            WhiteEdgeLocation.FrontLeft => WhiteEdgeLocation.LeftFront,
            WhiteEdgeLocation.FrontRight => WhiteEdgeLocation.RightFront,
            WhiteEdgeLocation.FrontDown => WhiteEdgeLocation.DownFront,

            WhiteEdgeLocation.BackUp => WhiteEdgeLocation.UpBack,
            WhiteEdgeLocation.BackLeft => WhiteEdgeLocation.LeftBack,
            WhiteEdgeLocation.BackRight => WhiteEdgeLocation.RightBack,
            WhiteEdgeLocation.BackDown => WhiteEdgeLocation.DownBack,

            WhiteEdgeLocation.RightUp => WhiteEdgeLocation.UpRight,
            WhiteEdgeLocation.RightFront => WhiteEdgeLocation.FrontRight,
            WhiteEdgeLocation.RightBack => WhiteEdgeLocation.BackRight,
            WhiteEdgeLocation.RightDown => WhiteEdgeLocation.DownRight,

            WhiteEdgeLocation.LeftUp => WhiteEdgeLocation.UpLeft,
            WhiteEdgeLocation.LeftBack => WhiteEdgeLocation.BackLeft,
            WhiteEdgeLocation.LeftFront => WhiteEdgeLocation.FrontLeft,
            WhiteEdgeLocation.LeftDown => WhiteEdgeLocation.DownLeft,

            _ => throw new NotImplementedException()
        };
    }
}