namespace SolveCuber.RubiksCube.Models;

public class CubeFace
{
    public CubeColor[,] Face { get; private set; }

    public CubeFace(CubeColor color)
    {
        Face = new CubeColor[3, 3];

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Face[i, j] = color;
            }
        }
    }

    internal CubeFace SetColor(int x, int y, CubeColor color)
    {
        Face[y, x] = color;

        return this;
    }

    internal CubeFace RotateClockwise()
    {
        int size = Face.GetLength(0);
        CubeColor[,] currentFace = Face;

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Face[i, j] = currentFace[2 - j, i];
            }
        }

        return this;
    }

    internal CubeFace RotateCounterClockwise()
    {
        int size = Face.GetLength(0);
        CubeColor[,] currentFace = Face;

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Face[i, j] = currentFace[j, 2 - i];
            }
        }

        return this;
    }

    internal CubeFace RotateTwoTimes()
    {
        int size = Face.GetLength(0);
        CubeColor[,] currentFace = Face;

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Face[i, j] = currentFace[2 - i, 2 - j];
            }
        }

        return this;
    }
}
