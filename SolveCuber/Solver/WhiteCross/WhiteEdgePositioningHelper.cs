using SolveCuber.CubeModel;

namespace SolveCuber.Solver.WhiteCross;

internal static class WhiteEdgePositioningHelper
{
    internal static bool IsInCorrectPlace(CubeColor secondWhiteEdgeColor, WhiteEdgeLocation location)
    {
        return secondWhiteEdgeColor switch
        {
            CubeColor.Green => location == WhiteEdgeLocation.UpFront,
            CubeColor.Orange => location == WhiteEdgeLocation.UpLeft,
            CubeColor.Red => location == WhiteEdgeLocation.UpRight,
            CubeColor.Blue => location == WhiteEdgeLocation.UpBack,

            _ => throw new NotImplementedException()
        };
    }

    internal static List<CubeMove> GetWhiteEdgePositioningMoves(WhiteEdgeLocation edgeLocation, CubeColor whiteEdgeSecondColor)
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

            WhiteEdgeLocation.BackUp => [CubeMove.B_, CubeMove.U_, CubeMove.R_, CubeMove.U],
            WhiteEdgeLocation.BackRight => [CubeMove.U_, CubeMove.R_, CubeMove.U],
            WhiteEdgeLocation.BackLeft => [CubeMove.U, CubeMove.L, CubeMove.U_],
            WhiteEdgeLocation.BackDown => [CubeMove.D_, CubeMove.R, CubeMove.F_, CubeMove.R_],

            WhiteEdgeLocation.RightUp => [CubeMove.R_, CubeMove.F_],
            WhiteEdgeLocation.RightFront => [CubeMove.F_],
            WhiteEdgeLocation.RightBack => [CubeMove.R2, CubeMove.F_, CubeMove.R2],
            WhiteEdgeLocation.RightDown => [CubeMove.R, CubeMove.F_, CubeMove.R_],

            WhiteEdgeLocation.LeftUp => [CubeMove.L, CubeMove.F],
            WhiteEdgeLocation.LeftBack => [CubeMove.L2, CubeMove.F, CubeMove.L2],
            WhiteEdgeLocation.LeftFront => [CubeMove.F],
            WhiteEdgeLocation.LeftDown => [CubeMove.L_, CubeMove.F, CubeMove.L],

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
            WhiteEdgeLocation.FrontRight => [CubeMove.F2, CubeMove.L_, CubeMove.F2],
            WhiteEdgeLocation.FrontDown => [CubeMove.F, CubeMove.L_, CubeMove.F_],

            WhiteEdgeLocation.BackUp => [CubeMove.B, CubeMove.L],
            WhiteEdgeLocation.BackRight => [CubeMove.U2, CubeMove.R_, CubeMove.U2],
            WhiteEdgeLocation.BackLeft => [CubeMove.L],
            WhiteEdgeLocation.BackDown => [CubeMove.B_, CubeMove.L, CubeMove.B],

            WhiteEdgeLocation.RightUp => [CubeMove.R_, CubeMove.U_, CubeMove.F_, CubeMove.U],
            WhiteEdgeLocation.RightFront => [CubeMove.U_, CubeMove.F_, CubeMove.U],
            WhiteEdgeLocation.RightBack => [CubeMove.U, CubeMove.B, CubeMove.U_],
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
            WhiteEdgeLocation.FrontLeft => [CubeMove.F2, CubeMove.R, CubeMove.F2],
            WhiteEdgeLocation.FrontRight => [CubeMove.R],
            WhiteEdgeLocation.FrontDown => [CubeMove.F_, CubeMove.R, CubeMove.F],

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
            WhiteEdgeLocation.FrontDown => [CubeMove.D, CubeMove.R_, CubeMove.B, CubeMove.R],

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
}
