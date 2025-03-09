namespace SolveCuber.RubiksCube.Common.Models;

public class CubeFace
{
    public CubeColor[,] Face { get; private set; }

    public CubeFace(int size, CubeColor color)
    {
        Face = new CubeColor[size, size];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Face[i, j] = color;
            }
        }
    }

    public CubeFace RotateClockwise()
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

    public CubeFace RotateCounterClockwise()
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
}
