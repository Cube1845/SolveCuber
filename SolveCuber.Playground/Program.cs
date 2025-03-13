using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;

Cube cube = new();

//cube.ExecuteAlgorithm
//([
//    CubeMove.R,
//    CubeMove.U,
//    CubeMove.R_,
//    CubeMove.U_,
//    CubeMove.R_,
//    CubeMove.F,
//    CubeMove.R2,
//    CubeMove.U_,
//    CubeMove.R_,
//    CubeMove.U_,
//    CubeMove.R,
//    CubeMove.U,
//    CubeMove.R_,
//    CubeMove.F_,
//]);

displayScramble(cube.ScrambleCube());

DisplayCube(cube);

void displayScramble(List<CubeMove> scramble)
{
    Console.Write("\nScramble: ");

    foreach (var move in scramble)
    {
        Console.Write(move.ToString() + ", ");
    }

    Console.Write("\n");
}

void DisplayCube(Cube cube)
{
    Console.WriteLine("\nUp:\n");

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            Console.Write(cube.Up.Face[i, j] + " ");
        }

        Console.Write("\n");
    }

    Console.WriteLine("\nDown:\n");

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            Console.Write(cube.Down.Face[i, j] + " ");
        }

        Console.Write("\n");
    }

    Console.WriteLine("\nFront:\n");

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            Console.Write(cube.Front.Face[i, j] + " ");
        }

        Console.Write("\n");
    }

    Console.WriteLine("\nBack:\n");

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            Console.Write(cube.Back.Face[i, j] + " ");
        }

        Console.Write("\n");
    }

    Console.WriteLine("\nRight:\n");

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            Console.Write(cube.Right.Face[i, j] + " ");
        }

        Console.Write("\n");
    }

    Console.WriteLine("\nLeft:\n");

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            Console.Write(cube.Left.Face[i, j] + " ");
        }

        Console.Write("\n");
    }
}