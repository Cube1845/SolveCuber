namespace SolveCuber.CubeModel;

public struct CubeFace
{
    public CubeColor[,] Face { get; set; }

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

    internal CubeFace DeepCopy()
    {
        CubeFace newFace = new(Face[0, 0]);

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                newFace.Face[i, j] = Face[i, j];
            }
        }

        return newFace;
    }

    internal CubeFace RotateClockwise()
    {
        CubeColor[,] currentFace = (CubeColor[,])Face.Clone();

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Face[i, j] = currentFace[2 - j, i];
            }
        }

        return this;
    }

    internal CubeFace RotateCounterClockwise()
    {
        CubeColor[,] currentFace = (CubeColor[,])Face.Clone();

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Face[i, j] = currentFace[j, 2 - i];
            }
        }

        return this;
    }

    internal CubeFace RotateTwoTimes()
    {
        CubeColor[,] currentFace = (CubeColor[,])Face.Clone();

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Face[i, j] = currentFace[2 - i, 2 - j];
            }
        }

        return this;
    }
}
