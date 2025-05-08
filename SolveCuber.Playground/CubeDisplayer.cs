using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Solver.Solver;

namespace SolveCuber.Playground;

public static class CubeDisplayer
{
    private static readonly string _empty = "  ";

    public static void DisplaySolve(Solution solve)
    {
        Console.WriteLine("Solve: \n");

        Console.WriteLine("- Cross:");
        DisplayMoves(solve.Cross);

        Console.WriteLine("- F2L:");
        DisplayMoves(solve.F2L);

        Console.WriteLine("- OLL:");
        DisplayMoves(solve.OLL);

        Console.WriteLine("- PLL:");
        DisplayMoves(solve.PLL);

        Console.WriteLine("- Moves: " + solve.MovesCount);
    }

    private static void DisplayMoves(List<CubeMove> moves)
    {
        foreach (var move in moves)
        {
            Console.Write(move.ToString() + ", ");
        }

        Console.Write("\n\n");
    }

    public static void DisplayCube(Cube cube)
    {
        Console.WriteLine("Cube: \n");

        for (int i = 0; i < 3; i++)
        {
            WriteEmptySpaces(3);

            for (int j = 0; j < 3; j++)
            {
                WriteColor(cube.Up.Face[i, j]);
            }

            WriteEmptySpaces(6);

            Console.Write("\n");
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                WriteColor(cube.Left.Face[i, j]);
            }

            for (int j = 0; j < 3; j++)
            {
                WriteColor(cube.Front.Face[i, j]);
            }

            for (int j = 0; j < 3; j++)
            {
                WriteColor(cube.Right.Face[i, j]);
            }

            for (int j = 0; j < 3; j++)
            {
                WriteColor(cube.Back.Face[i, j]);
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");
        }

        for (int i = 0; i < 3; i++)
        {
            WriteEmptySpaces(3);

            for (int j = 0; j < 3; j++)
            {
                WriteColor(cube.Down.Face[i, j]);
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");
        }
    }

    private static ConsoleColor MapCubeColorToConsoleColor(CubeColor color)
    {
        return color switch
        {
            CubeColor.White => ConsoleColor.White,
            CubeColor.Yellow => ConsoleColor.Yellow,
            CubeColor.Green => ConsoleColor.Green,
            CubeColor.Blue => ConsoleColor.Blue,
            CubeColor.Red => ConsoleColor.Red,
            CubeColor.Orange => ConsoleColor.Magenta,

            _ => throw new NotImplementedException()
        };
    }

    private static void WriteEmptySpaces(int count)
    {
        Console.BackgroundColor = ConsoleColor.Black;

        for (int i = 0; i < count; i++)
        {
            Console.Write(_empty);
        }
    }

    private static void WriteColor(CubeColor color)
    {
        Console.BackgroundColor = MapCubeColorToConsoleColor(color);
        Console.Write(_empty);
    }
}
