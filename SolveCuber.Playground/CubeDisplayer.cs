using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using System.ComponentModel;

namespace SolveCuber.Playground;

internal static class CubeDisplayer
{
    private static readonly string _empty = "  ";

    internal static void DisplayCube(Cube cube)
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
