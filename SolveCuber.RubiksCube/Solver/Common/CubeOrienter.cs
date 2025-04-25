using SolveCuber.Common;
using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;

namespace SolveCuber.Solver.Common;

internal static class CubeOrienter
{
    public static List<CubeMove> OrientCube(Cube cube, CubeColor targetUpColor)
    {
        List<CubeMove> executedRotations = [];

        var cubeCopy = cube.DeepCopy();

        var zRotationMoves = RotateUntil(cubeCopy, CubeMove.z, () => cubeCopy.Up.Face[1, 1] == targetUpColor);
        var xRotationMoves = RotateUntil(cubeCopy, CubeMove.x, () => cubeCopy.Up.Face[1, 1] == targetUpColor);

        var optimizedRotations = MoveOptimizer.OptimizeMoves
        ([
            .. zRotationMoves ?? [],
            .. xRotationMoves ?? [],
        ]);

        cube.ExecuteAlgorithm(optimizedRotations);

        return optimizedRotations;
    }

    public static List<CubeMove> OrientCube(Cube cube, CubeColor targetFrontColor, CubeColor targetUpColor)
    {
        if (AreColorsIncorrect(targetFrontColor, targetUpColor))
        {
            throw new RubiksCubeException("Colors are incorrect");
        }

        List<CubeMove> executedRotations = [];
        
        var cubeCopy = cube.DeepCopy();

        var xRotationMoves = RotateUntil(cubeCopy, CubeMove.x, () => cubeCopy.Front.Face[1, 1] == targetFrontColor);
        var yRotationMoves = RotateUntil(cubeCopy, CubeMove.y, () => cubeCopy.Front.Face[1, 1] == targetFrontColor);
        var zRotationMoves = RotateUntil(cubeCopy, CubeMove.z, () => cubeCopy.Up.Face[1, 1] == targetUpColor);

        var optimizedRotations = MoveOptimizer.OptimizeMoves
        ([
            .. xRotationMoves ?? [],
            .. yRotationMoves ?? [],
            .. zRotationMoves ?? [],
        ]);

        cube.ExecuteAlgorithm(optimizedRotations);

        return optimizedRotations;
    }

    private static bool AreColorsIncorrect(CubeColor targetFrontColor, CubeColor targetUpColor)
    {
        List<CubeColor> HotOppositeColors = [CubeColor.Red, CubeColor.Orange];
        List<CubeColor> ColdOppositeColors = [CubeColor.Blue, CubeColor.Green];
        List<CubeColor> NeutralOppositeColors = [CubeColor.White, CubeColor.Yellow];

        return (HotOppositeColors.Contains(targetFrontColor) && HotOppositeColors.Contains(targetUpColor)) ||
            (ColdOppositeColors.Contains(targetFrontColor) && ColdOppositeColors.Contains(targetUpColor)) ||
            (NeutralOppositeColors.Contains(targetFrontColor) && NeutralOppositeColors.Contains(targetUpColor));
    }

    private static List<CubeMove>? RotateUntil(Cube cube, CubeMove rotation, Func<bool> compare)
    {
        int i = 0;
        List<CubeMove> executedRotations = [];

        while (!compare())
        {
            cube.ExecuteMove(rotation);
            executedRotations.Add(rotation);

            i++;

            if (i > 3)
            {
                return null;
            }
        }

        return MoveOptimizer.OptimizeMoves(executedRotations);
    }
}
