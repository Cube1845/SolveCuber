using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;

namespace SolveCuber.Solver.WhiteCross;

public static class WhiteCrossSolver
{
    public static List<CubeMove> SolveCross(Cube cube)
    {
        WhiteEdgesData whiteEdgesData = GetWhiteEdgeLocations(cube);

        if (IsCrossSolved(whiteEdgesData))
        {
            return [];
        }



        return GetGreenWhiteEdgePositioningMoves(whiteEdgesData.Green!.Value);
    }

    private static bool IsCrossSolved(WhiteEdgesData edgesData)
    {
        return edgesData.Green == null &&
            edgesData.Orange == null &&
            edgesData.Red == null &&
            edgesData.Blue == null;
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
                        if (location != WhiteEdgeLocation.UpFront)
                        {
                            edgesData.Green = location;
                        }
                        break;

                    case CubeColor.Orange:
                        if (location != WhiteEdgeLocation.UpLeft)
                        {
                            edgesData.Orange = location;
                        }
                        break;

                    case CubeColor.Red:
                        if (location != WhiteEdgeLocation.UpRight)
                        {
                            edgesData.Red = location;
                        }
                        break;

                    case CubeColor.Blue:
                        if (location != WhiteEdgeLocation.UpBack)
                        {
                            edgesData.Blue = location;
                        }
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

    private static List<CubeMove> GetGreenWhiteEdgePositioningMoves(WhiteEdgeLocation edgeLocation)
    {
        return edgeLocation switch
        {
            WhiteEdgeLocation.DownFront => [CubeMove.F2],
            WhiteEdgeLocation.DownLeft => [CubeMove.D, CubeMove.F2],
            WhiteEdgeLocation.DownRight => [CubeMove.D_, CubeMove.F2],
            WhiteEdgeLocation.DownBack => [CubeMove.D2, CubeMove.F2],

            WhiteEdgeLocation.FrontUp => [CubeMove.F, CubeMove.U_, CubeMove.R, CubeMove.U],
            WhiteEdgeLocation.FrontLeft => [CubeMove.U, CubeMove.L_, CubeMove.U_],
            WhiteEdgeLocation.FrontRight => [CubeMove.U_, CubeMove.R, CubeMove.U],
            WhiteEdgeLocation.FrontDown => [CubeMove.F_, CubeMove.U_, CubeMove.R, CubeMove.U],

            WhiteEdgeLocation.BackUp => [CubeMove.B_, CubeMove.U2, CubeMove.B, CubeMove.U2],
            WhiteEdgeLocation.BackRight => [CubeMove.U_, CubeMove.R_, CubeMove.U],
            WhiteEdgeLocation.BackLeft => [CubeMove.U, CubeMove.L, CubeMove.U_],
            WhiteEdgeLocation.BackDown => [CubeMove.D_, CubeMove.R, CubeMove.F_, CubeMove.R_],

            WhiteEdgeLocation.RightUp => [CubeMove.R_, CubeMove.F_],
            WhiteEdgeLocation.RightFront => [CubeMove.F_],
            WhiteEdgeLocation.RightBack => [CubeMove.R2, CubeMove.F_],
            WhiteEdgeLocation.RightDown => [CubeMove.R, CubeMove.F_],

            WhiteEdgeLocation.LeftUp => [CubeMove.L, CubeMove.F],
            WhiteEdgeLocation.LeftBack => [CubeMove.L2, CubeMove.F],
            WhiteEdgeLocation.LeftFront => [CubeMove.F],
            WhiteEdgeLocation.LeftDown => [CubeMove.L_, CubeMove.F],

            _ => []
        };
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