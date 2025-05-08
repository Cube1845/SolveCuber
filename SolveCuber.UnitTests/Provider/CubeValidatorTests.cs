using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Provider;

namespace SolveCuber.UnitTests.Provider;

public class CubeValidatorTests
{
    [Fact]
    public void ValidateCubeSolve_ShouldReturnTrue_WhenCubeIsSolvable()
    {
        Cube cube = new();

        var result = CubeValidator.ValidateCubeSolve(cube);

        result.ShouldBeTrue();
    }

    [Fact]
    public void ValidateCubeSolve_ShouldReturnFalse_WhenCubeIsUnsolvable()
    {
        Cube cube = new
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

        var result = CubeValidator.ValidateCubeSolve(cube);

        result.ShouldBeFalse();
    }

    [Fact]
    public void ValidateCubeColors_ShouldReturnTrue_WhenColorsAreBalanced()
    {
        Cube cube = new();

        var result = CubeValidator.ValidateCubeColors(cube);

        result.ShouldBeTrue();
    }

    [Fact]
    public void ValidateCubeColors_ShouldReturnFalse_WhenColorCountsAreInvalid()
    {
        Cube cube = new
        (
            new CubeColor[,]
            {
                { CubeColor.Red, CubeColor.Red, CubeColor.Orange },
                { CubeColor.Red, CubeColor.Yellow, CubeColor.Yellow },
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
                { CubeColor.Red, CubeColor.Orange, CubeColor.Red }
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

        var result = CubeValidator.ValidateCubeColors(cube);

        result.ShouldBeFalse();
    }

    [Fact]
    public void ValidateCenters_ShouldReturnTrue_WhenCentersAreCorrect()
    {
        Cube cube = new();

        var result = CubeValidator.ValidateCenters(cube);

        result.ShouldBeTrue();
    }

    [Fact]
    public void ValidateCenters_ShouldReturnFalse_WhenCenterColorsAreNotUnique()
    {
        Cube cube = new
        (
            new CubeColor[,]
            {
                { CubeColor.Red, CubeColor.Red, CubeColor.Orange },
                { CubeColor.Orange, CubeColor.Red, CubeColor.Yellow },
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
                { CubeColor.Red, CubeColor.Yellow, CubeColor.Green },
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

        var result = CubeValidator.ValidateCenters(cube);

        result.ShouldBeFalse();
    }
}