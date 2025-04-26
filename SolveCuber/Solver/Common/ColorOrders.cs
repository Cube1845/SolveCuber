using SolveCuber.CubeModel;

namespace SolveCuber.Solver.Common;

internal static class ColorOrders
{
    // In F2L:
    // Those are the first colors of the non white and yellow colors,
    // for example Green means GreenOrange or Red means RedGreen (as in the WhiteCornerData or NonYellowEdgesData)

    internal readonly static List<List<CubeColor>> EdgeSolvingOrders =
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
}
