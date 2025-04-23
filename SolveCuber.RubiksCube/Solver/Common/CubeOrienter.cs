using SolveCuber.Common;
using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;

namespace SolveCuber.Solver.Common;

internal static class CubeOrienter
{
    public static List<CubeMove> OrientCube(Cube cube, CubeColor targetFrontColor, CubeColor targetUpColor)
    {
        List<CubeMove> executedRotations = [];
        
        var cubeCopy = cube.DeepCopy();

        if (cubeCopy.Front.Face[1, 1] == targetUpColor)
        {
            return [CubeMove.y2, CubeMove.x_];
        }

        if (cubeCopy.Front.Face[1, 1] == targetFrontColor)
        {
            while (cubeCopy.Up.Face[1, 1] != targetUpColor)
            {
                cubeCopy.ExecuteMove(CubeMove.z);
                executedRotations.Add(CubeMove.z);

                if (executedRotations.Count > 10)
                {
                    throw new Exception();
                }
            }

            return MoveOptimizer.OptimizeMoves(executedRotations);
        }

        if (cubeCopy.Up.Face[1, 1] == targetUpColor)
        {
            while (cubeCopy.Front.Face[1, 1] != targetFrontColor)
            {
                cubeCopy.ExecuteMove(CubeMove.y);
                executedRotations.Add(CubeMove.y);

                if (executedRotations.Count > 10)
                {
                    throw new Exception();
                }
            }

            return MoveOptimizer.OptimizeMoves(executedRotations);
        }

        if (cubeCopy.Up.Face[1, 1] == targetFrontColor)
        {
            cubeCopy.ExecuteMove(CubeMove.x_);
            executedRotations.Add(CubeMove.x_);

            while (cubeCopy.Front.Face[1, 1] != targetFrontColor)
            {
                cubeCopy.ExecuteMove(CubeMove.z);
                executedRotations.Add(CubeMove.z);

                if (executedRotations.Count > 10)
                {
                    throw new Exception();
                }
            }

            return MoveOptimizer.OptimizeMoves(executedRotations);
        }

        return [];
    }
}
