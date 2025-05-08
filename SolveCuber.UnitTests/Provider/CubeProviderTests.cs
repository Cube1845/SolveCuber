using SolveCuber.Common;
using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Provider;
using SolveCuber.Solver.Solver;

namespace SolveCuber.UnitTests.Provider;

public class CubeProviderTests
{
    [Fact]
    public void GetSolvedCube_ShouldReturnSolvedCube()
    {
        var cube = CubeProvider.GetSolvedCube();

        IsCubeSolved(cube).ShouldBeTrue();
    }

    [Fact]
    public void InsertCube_ShouldReturnCube_WhenInputIsValid()
    {
        var action = () =>
        {
            var cube = CubeProvider.InsertCube
            (
                new CubeColor[,]
                {
                    { CubeColor.Red, CubeColor.Red, CubeColor.Orange },
                    { CubeColor.Orange, CubeColor.Yellow, CubeColor.Yellow },
                    { CubeColor.Green, CubeColor.White, CubeColor.Green }
                },
                new CubeColor[,]
                {
                    { CubeColor.Green, CubeColor.Yellow, CubeColor.Orange },
                    { CubeColor.Orange, CubeColor.White, CubeColor.Green },
                    { CubeColor.White, CubeColor.White, CubeColor.Yellow }
                },
                new CubeColor[,]
                {
                    { CubeColor.Orange, CubeColor.Red, CubeColor.Red },
                    { CubeColor.Green, CubeColor.Orange, CubeColor.Blue },
                    { CubeColor.Orange, CubeColor.Blue, CubeColor.Yellow }
                },
                new CubeColor[,]
                {
                    { CubeColor.Blue, CubeColor.Yellow, CubeColor.Yellow },
                    { CubeColor.Red, CubeColor.Red, CubeColor.Green },
                    { CubeColor.Red, CubeColor.Orange, CubeColor.Blue }
                },
                new CubeColor[,]
                {
                    { CubeColor.White, CubeColor.Green, CubeColor.White },
                    { CubeColor.White, CubeColor.Blue, CubeColor.Blue },
                    { CubeColor.Blue, CubeColor.Orange, CubeColor.Green }
                },
                new CubeColor[,]
                {
                    { CubeColor.Blue, CubeColor.Blue, CubeColor.White },
                    { CubeColor.Red, CubeColor.Green, CubeColor.White },
                    { CubeColor.Red, CubeColor.Yellow, CubeColor.Yellow }
                }
            );
        };

        action.ShouldNotThrow();
    }

    [Fact]
    public void InsertCube_ShouldThrow_WhenCubeIsInvalid()
    {
        var action = () =>
        {
            CubeProvider.InsertCube
            (
                new CubeColor[,]
                {
                    { CubeColor.Red, CubeColor.Red, CubeColor.Orange },
                    { CubeColor.Orange, CubeColor.Yellow, CubeColor.Yellow },
                    { CubeColor.Green, CubeColor.White, CubeColor.Orange }
                },
                new CubeColor[,]
                {
                    { CubeColor.Green, CubeColor.Yellow, CubeColor.Green },
                    { CubeColor.Orange, CubeColor.White, CubeColor.Green },
                    { CubeColor.Blue, CubeColor.White, CubeColor.Yellow }
                },
                new CubeColor[,]
                {
                    { CubeColor.Orange, CubeColor.Red, CubeColor.Red },
                    { CubeColor.Green, CubeColor.Orange, CubeColor.Blue },
                    { CubeColor.Orange, CubeColor.Blue, CubeColor.Yellow }
                },
                new CubeColor[,]
                {
                    { CubeColor.Blue, CubeColor.Yellow, CubeColor.Yellow },
                    { CubeColor.Red, CubeColor.Red, CubeColor.Green },
                    { CubeColor.Red, CubeColor.Orange, CubeColor.Blue }
                },
                new CubeColor[,]
                {
                    { CubeColor.White, CubeColor.Green, CubeColor.White },
                    { CubeColor.White, CubeColor.Blue, CubeColor.White },
                    { CubeColor.Blue, CubeColor.Orange, CubeColor.Green }
                },
                new CubeColor[,]
                {
                    { CubeColor.Blue, CubeColor.Blue, CubeColor.White },
                    { CubeColor.Red, CubeColor.Green, CubeColor.White },
                    { CubeColor.Red, CubeColor.Yellow, CubeColor.Yellow }
                }
            );
        };

        action.ShouldThrow<RubiksCubeException>();
    }

    [Fact]
    public void GetScrambledCube_ShouldReturnValidScrambledCube()
    {
        var cube = CubeProvider.GetScrambledCube();

        ValidateCubeSolve(cube).ShouldBeTrue();
    }

    [Fact]
    public void GetScrambledCube_WithScrambleOut_ShouldReturnCubeAndScrambleMoves()
    {
        var cube = CubeProvider.GetScrambledCube(out var scramble);

        scramble.ShouldNotBeNull();
        scramble.Count.ShouldBeGreaterThan(0);

        ValidateCubeSolve(cube).ShouldBeTrue();
    }

    private bool IsCubeSolved(Cube cube)
    {
        return IsFaceUniform(cube.Up) &&
               IsFaceUniform(cube.Down) &&
               IsFaceUniform(cube.Front) &&
               IsFaceUniform(cube.Back) &&
               IsFaceUniform(cube.Left) &&
               IsFaceUniform(cube.Right);
    }

    private bool IsFaceUniform(CubeFace face)
    {
        var centerColor = face.Face[1, 1];

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (face.Face[i, j] != centerColor)
                    return false;
            }
        }

        return true;
    }

    private bool ValidateCubeSolve(Cube cube)
    {
        var cubeCopy = cube.DeepCopy();

        try
        {
            CubeSolver.SolveCube(cubeCopy);
        }
        catch
        {
            return false;
        }

        return true;
    }
}
