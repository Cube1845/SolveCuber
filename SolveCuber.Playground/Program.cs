using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Scramble;
using SolveCuber.Solver.WhiteCross;

Cube cube = new();

var scramble = Scrambler.ScrambleCube(cube);

DisplayMoves(scramble);

DisplayCube(cube);

var solvingCrossMoves = WhiteCrossSolver.SolveCross(cube);

DisplayMoves(solvingCrossMoves);

DisplayCube(cube);

void DisplayMoves(List<CubeMove> moves)
{
    Console.Write("\nMoves: ");

    foreach (var move in moves)
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