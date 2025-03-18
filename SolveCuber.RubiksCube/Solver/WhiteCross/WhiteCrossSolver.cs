using SolveCuber.Common;
using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;

namespace SolveCuber.Solver.WhiteCross;

public static class WhiteCrossSolver
{
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

    public static List<CubeMove> SolveCross(Cube cube)
    {
        WhiteEdgesData edgesData = GetWhiteEdgeLocations(cube);

        if (IsCrossSolved(edgesData))
        {
            return [];
        }

        List<CubeMove> moves = [];

        moves.AddRange(GetSolutionWithLeastMoves(cube, edgesData));

        return MoveOptimizer.OptimizeMoves(moves);
    }

    private static List<CubeMove> GetSolutionWithLeastMoves(Cube cube, WhiteEdgesData edgesData)
    {
        List<List<CubeMove>> solutions = [];

        foreach (var colorOrder in _edgeSolvingOrders)
        {
            solutions.Add(GetSolvingCrossMoves(cube, colorOrder));
        }

        var orderedSolutions = solutions.OrderBy(s => s.Count).ToList();

        return orderedSolutions[0];
    }

    private static List<CubeMove> GetSolvingCrossMoves(Cube cube, List<CubeColor> colorOrder)
    {
        List<CubeMove> crossSolvingMoves = [];

        Cube cubeCopy = cube.DeepCopy();

        foreach (var whiteEdgeSecondColor in colorOrder)
        {
            WhiteEdgesData edgesData = GetWhiteEdgeLocations(cubeCopy);

            var moves =
                GetWhiteEdgePositioningMoves(edgesData.GetLocation(whiteEdgeSecondColor), whiteEdgeSecondColor);

            cubeCopy.ExecuteAlgorithm(moves);

            crossSolvingMoves.AddRange(moves);
        }

        if (!IsCrossSolved(GetWhiteEdgeLocations(cubeCopy)))
        {
            throw new Exception();
        }

        return MoveOptimizer.OptimizeMoves(crossSolvingMoves);
    }

    private static bool IsCrossSolved(WhiteEdgesData edgesData)
    {
        return edgesData.Green == WhiteEdgeLocation.UpFront &&
            edgesData.Orange == WhiteEdgeLocation.UpLeft &&
            edgesData.Red == WhiteEdgeLocation.UpRight &&
            edgesData.Blue == WhiteEdgeLocation.UpBack;
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

    private static List<CubeMove> GetWhiteEdgePositioningMoves(WhiteEdgeLocation edgeLocation, CubeColor whiteEdgeSecondColor)
    {
        Func<WhiteEdgeLocation, List<CubeMove>> getMoves = whiteEdgeSecondColor switch
        {
            CubeColor.Green => GetGreenWhiteEdgePositioningMoves,
            CubeColor.Orange => GetOrangeWhiteEdgePositioningMoves,
            CubeColor.Red => GetRedWhiteEdgePositioningMoves,
            CubeColor.Blue => GetBlueWhiteEdgePositioningMoves,

            _ => throw new NotImplementedException()
        };

        return getMoves(edgeLocation);
    }

    private static List<CubeMove> GetGreenWhiteEdgePositioningMoves(WhiteEdgeLocation edgeLocation)
    {
        return edgeLocation switch
        {
            WhiteEdgeLocation.UpFront => [],
            WhiteEdgeLocation.UpLeft => [CubeMove.L2, CubeMove.D, CubeMove.F2],
            WhiteEdgeLocation.UpRight => [CubeMove.R2, CubeMove.D_, CubeMove.F2],
            WhiteEdgeLocation.UpBack => [CubeMove.B2, CubeMove.D2, CubeMove.F2],

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

    private static List<CubeMove> GetOrangeWhiteEdgePositioningMoves(WhiteEdgeLocation edgeLocation)
    {
        return edgeLocation switch
        {
            WhiteEdgeLocation.UpFront => [CubeMove.F2, CubeMove.D_, CubeMove.L2],
            WhiteEdgeLocation.UpLeft => [],
            WhiteEdgeLocation.UpRight => [CubeMove.R2, CubeMove.D2, CubeMove.L2],
            WhiteEdgeLocation.UpBack => [CubeMove.B2, CubeMove.D, CubeMove.L2],

            WhiteEdgeLocation.DownFront => [CubeMove.D_, CubeMove.L2],
            WhiteEdgeLocation.DownLeft => [CubeMove.L2],
            WhiteEdgeLocation.DownRight => [CubeMove.D2, CubeMove.L2],
            WhiteEdgeLocation.DownBack => [CubeMove.D, CubeMove.L2],

            WhiteEdgeLocation.FrontUp => [CubeMove.F_, CubeMove.L_],
            WhiteEdgeLocation.FrontLeft => [CubeMove.L_],
            WhiteEdgeLocation.FrontRight => [CubeMove.F2, CubeMove.L_],
            WhiteEdgeLocation.FrontDown => [CubeMove.F, CubeMove.L_],

            WhiteEdgeLocation.BackUp => [CubeMove.B, CubeMove.L],
            WhiteEdgeLocation.BackRight => [CubeMove.U2, CubeMove.R_, CubeMove.U2],
            WhiteEdgeLocation.BackLeft => [CubeMove.L],
            WhiteEdgeLocation.BackDown => [CubeMove.B_, CubeMove.L],

            WhiteEdgeLocation.RightUp => [CubeMove.R_, CubeMove.U_, CubeMove.F_, CubeMove.U],
            WhiteEdgeLocation.RightFront => [CubeMove.U_, CubeMove.F_, CubeMove.U],
            WhiteEdgeLocation.RightBack => [CubeMove.U2, CubeMove.B, CubeMove.U2],
            WhiteEdgeLocation.RightDown => [CubeMove.D_, CubeMove.F, CubeMove.L_, CubeMove.F_],

            WhiteEdgeLocation.LeftUp => [CubeMove.L, CubeMove.U_, CubeMove.F, CubeMove.U],
            WhiteEdgeLocation.LeftBack => [CubeMove.U, CubeMove.B_, CubeMove.U_],
            WhiteEdgeLocation.LeftFront => [CubeMove.U_, CubeMove.F, CubeMove.U],
            WhiteEdgeLocation.LeftDown => [CubeMove.L_, CubeMove.U_, CubeMove.F, CubeMove.U],

            _ => []
        };
    }

    private static List<CubeMove> GetRedWhiteEdgePositioningMoves(WhiteEdgeLocation edgeLocation)
    {
        return edgeLocation switch
        {
            WhiteEdgeLocation.UpFront => [CubeMove.F2, CubeMove.D, CubeMove.R2],
            WhiteEdgeLocation.UpLeft => [CubeMove.L2, CubeMove.D2, CubeMove.R2],
            WhiteEdgeLocation.UpRight => [],
            WhiteEdgeLocation.UpBack => [CubeMove.B2, CubeMove.D_, CubeMove.R2],

            WhiteEdgeLocation.DownFront => [CubeMove.D, CubeMove.R2],
            WhiteEdgeLocation.DownLeft => [CubeMove.D2, CubeMove.R2],
            WhiteEdgeLocation.DownRight => [CubeMove.R2],
            WhiteEdgeLocation.DownBack => [CubeMove.D_, CubeMove.R2],

            WhiteEdgeLocation.FrontUp => [CubeMove.F, CubeMove.R],
            WhiteEdgeLocation.FrontLeft => [CubeMove.F2, CubeMove.R],
            WhiteEdgeLocation.FrontRight => [CubeMove.R],
            WhiteEdgeLocation.FrontDown => [CubeMove.F_, CubeMove.R],

            WhiteEdgeLocation.BackUp => [CubeMove.B_, CubeMove.R_],
            WhiteEdgeLocation.BackRight => [CubeMove.R_],
            WhiteEdgeLocation.BackLeft => [CubeMove.U2, CubeMove.L, CubeMove.U2],
            WhiteEdgeLocation.BackDown => [CubeMove.B, CubeMove.R_, CubeMove.B_],

            WhiteEdgeLocation.RightUp => [CubeMove.R_, CubeMove.U, CubeMove.F_, CubeMove.U_],
            WhiteEdgeLocation.RightFront => [CubeMove.U, CubeMove.F_, CubeMove.U_],
            WhiteEdgeLocation.RightBack => [CubeMove.U_, CubeMove.B, CubeMove.U],
            WhiteEdgeLocation.RightDown => [CubeMove.R, CubeMove.U, CubeMove.F_, CubeMove.U_],

            WhiteEdgeLocation.LeftUp => [CubeMove.L, CubeMove.U, CubeMove.F, CubeMove.U_],
            WhiteEdgeLocation.LeftBack => [CubeMove.U_, CubeMove.B_, CubeMove.U],
            WhiteEdgeLocation.LeftFront => [CubeMove.U, CubeMove.F, CubeMove.U_],
            WhiteEdgeLocation.LeftDown => [CubeMove.D, CubeMove.F_, CubeMove.R, CubeMove.F],

            _ => []
        };
    }

    private static List<CubeMove> GetBlueWhiteEdgePositioningMoves(WhiteEdgeLocation edgeLocation)
    {
        return edgeLocation switch
        {
            WhiteEdgeLocation.UpFront => [CubeMove.F2, CubeMove.D2, CubeMove.B2],
            WhiteEdgeLocation.UpLeft => [CubeMove.L2, CubeMove.D_, CubeMove.B2],
            WhiteEdgeLocation.UpRight => [CubeMove.R2, CubeMove.D, CubeMove.B2],
            WhiteEdgeLocation.UpBack => [],

            WhiteEdgeLocation.DownFront => [CubeMove.D2, CubeMove.B2],
            WhiteEdgeLocation.DownLeft => [CubeMove.D_, CubeMove.B2],
            WhiteEdgeLocation.DownRight => [CubeMove.D, CubeMove.B2],
            WhiteEdgeLocation.DownBack => [CubeMove.B2],

            WhiteEdgeLocation.FrontUp => [CubeMove.F, CubeMove.U, CubeMove.R, CubeMove.U_],
            WhiteEdgeLocation.FrontLeft => [CubeMove.U_, CubeMove.L_, CubeMove.U],
            WhiteEdgeLocation.FrontRight => [CubeMove.U, CubeMove.R, CubeMove.U_],
            WhiteEdgeLocation.FrontDown => [CubeMove.F_, CubeMove.U, CubeMove.R, CubeMove.U_],

            WhiteEdgeLocation.BackUp => [CubeMove.B_, CubeMove.U, CubeMove.R_, CubeMove.U_],
            WhiteEdgeLocation.BackRight => [CubeMove.U, CubeMove.R_, CubeMove.U_],
            WhiteEdgeLocation.BackLeft => [CubeMove.U_, CubeMove.L, CubeMove.U],
            WhiteEdgeLocation.BackDown => [CubeMove.B, CubeMove.U, CubeMove.R_, CubeMove.U_],

            WhiteEdgeLocation.RightUp => [CubeMove.R, CubeMove.B],
            WhiteEdgeLocation.RightFront => [CubeMove.U2, CubeMove.F_, CubeMove.U2],
            WhiteEdgeLocation.RightBack => [CubeMove.B],
            WhiteEdgeLocation.RightDown => [CubeMove.R_, CubeMove.B, CubeMove.R],

            WhiteEdgeLocation.LeftUp => [CubeMove.L_, CubeMove.B_],
            WhiteEdgeLocation.LeftBack => [CubeMove.B_],
            WhiteEdgeLocation.LeftFront => [CubeMove.U2, CubeMove.F, CubeMove.U2],
            WhiteEdgeLocation.LeftDown => [CubeMove.L, CubeMove.B_, CubeMove.L_],

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