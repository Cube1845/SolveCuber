using SolveCuber.RubiksCube.Models;

namespace SolveCuber.RubiksCube.Moves.Moves;

internal static class UpMoveHandler
{
    public static Cube ExecuteUpMove(Cube cube)
    {
        Cube cubeImage = cube;

        cubeImage.Up.RotateClockwise();

        cubeImage.Front.SetColor(0, 0, cube.Right.Face[0, 0]);
        cubeImage.Front.SetColor(1, 0, cube.Right.Face[1, 0]);
        cubeImage.Front.SetColor(2, 0, cube.Right.Face[2, 0]);

        cubeImage.Right.SetColor(0, 0, cube.Back.Face[0, 0]);
        cubeImage.Right.SetColor(1, 0, cube.Back.Face[1, 0]);
        cubeImage.Right.SetColor(2, 0, cube.Back.Face[2, 0]);

        cubeImage.Back.SetColor(0, 0, cube.Left.Face[0, 0]);
        cubeImage.Back.SetColor(1, 0, cube.Left.Face[1, 0]);
        cubeImage.Back.SetColor(2, 0, cube.Left.Face[2, 0]);

        cubeImage.Left.SetColor(0, 0, cube.Front.Face[0, 0]);
        cubeImage.Left.SetColor(1, 0, cube.Front.Face[1, 0]);
        cubeImage.Left.SetColor(2, 0, cube.Front.Face[2, 0]);

        return cubeImage;
    }

    public static Cube ExecuteUpPrimeMove(Cube cube)
    {
        Cube cubeImage = cube;

        cubeImage.Up.RotateCounterClockwise();

        cubeImage.Right.SetColor(0, 0, cube.Front.Face[0, 0]);
        cubeImage.Right.SetColor(1, 0, cube.Front.Face[1, 0]);
        cubeImage.Right.SetColor(2, 0, cube.Front.Face[2, 0]);

        cubeImage.Back.SetColor(0, 0, cube.Right.Face[0, 0]);
        cubeImage.Back.SetColor(1, 0, cube.Right.Face[1, 0]);
        cubeImage.Back.SetColor(2, 0, cube.Right.Face[2, 0]);

        cubeImage.Left.SetColor(0, 0, cube.Back.Face[0, 0]);
        cubeImage.Left.SetColor(1, 0, cube.Back.Face[1, 0]);
        cubeImage.Left.SetColor(2, 0, cube.Back.Face[2, 0]);

        cubeImage.Front.SetColor(0, 0, cube.Left.Face[0, 0]);
        cubeImage.Front.SetColor(1, 0, cube.Left.Face[1, 0]);
        cubeImage.Front.SetColor(2, 0, cube.Left.Face[2, 0]);

        return cubeImage;
    }

    public static Cube ExecuteDoubleUpMove(Cube cube)
    {
        Cube cubeImage = cube;

        cubeImage.Up.RotateTwoTimes();

        cubeImage.Right.SetColor(0, 0, cube.Left.Face[0, 0]);
        cubeImage.Right.SetColor(1, 0, cube.Left.Face[1, 0]);
        cubeImage.Right.SetColor(2, 0, cube.Left.Face[2, 0]);

        cubeImage.Back.SetColor(0, 0, cube.Front.Face[0, 0]);
        cubeImage.Back.SetColor(1, 0, cube.Front.Face[1, 0]);
        cubeImage.Back.SetColor(2, 0, cube.Front.Face[2, 0]);

        cubeImage.Left.SetColor(0, 0, cube.Right.Face[0, 0]);
        cubeImage.Left.SetColor(1, 0, cube.Right.Face[1, 0]);
        cubeImage.Left.SetColor(2, 0, cube.Right.Face[2, 0]);

        cubeImage.Front.SetColor(0, 0, cube.Back.Face[0, 0]);
        cubeImage.Front.SetColor(1, 0, cube.Back.Face[1, 0]);
        cubeImage.Front.SetColor(2, 0, cube.Back.Face[2, 0]);

        return cubeImage;
    }
}
