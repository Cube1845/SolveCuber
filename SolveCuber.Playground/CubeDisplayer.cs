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
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(_empty + _empty + _empty);

            Console.BackgroundColor = MapCubeColorToConsoleColor(cube.Up.Face[i, 0]);
            Console.Write(_empty);
            Console.BackgroundColor = MapCubeColorToConsoleColor(cube.Up.Face[i, 1]);
            Console.Write(_empty);
            Console.BackgroundColor = MapCubeColorToConsoleColor(cube.Up.Face[i, 2]);
            Console.Write(_empty);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(_empty + _empty + _empty);
            Console.Write(_empty + _empty + _empty);

            Console.Write("\n");
        }

        for (int i = 0; i < 3; i++)
        {
            Console.BackgroundColor = MapCubeColorToConsoleColor(cube.Left.Face[i, 0]);
            Console.Write(_empty);
            Console.BackgroundColor = MapCubeColorToConsoleColor(cube.Left.Face[i, 1]);
            Console.Write(_empty);
            Console.BackgroundColor = MapCubeColorToConsoleColor(cube.Left.Face[i, 2]);
            Console.Write(_empty);

            Console.BackgroundColor = MapCubeColorToConsoleColor(cube.Front.Face[i, 0]);
            Console.Write(_empty);
            Console.BackgroundColor = MapCubeColorToConsoleColor(cube.Front.Face[i, 1]);
            Console.Write(_empty);
            Console.BackgroundColor = MapCubeColorToConsoleColor(cube.Front.Face[i, 2]);
            Console.Write(_empty);

            Console.BackgroundColor = MapCubeColorToConsoleColor(cube.Right.Face[i, 0]);
            Console.Write(_empty);
            Console.BackgroundColor = MapCubeColorToConsoleColor(cube.Right.Face[i, 1]);
            Console.Write(_empty);
            Console.BackgroundColor = MapCubeColorToConsoleColor(cube.Right.Face[i, 2]);
            Console.Write(_empty);

            Console.BackgroundColor = MapCubeColorToConsoleColor(cube.Back.Face[i, 0]);
            Console.Write(_empty);
            Console.BackgroundColor = MapCubeColorToConsoleColor(cube.Back.Face[i, 1]);
            Console.Write(_empty);
            Console.BackgroundColor = MapCubeColorToConsoleColor(cube.Back.Face[i, 2]);
            Console.Write(_empty);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");
        }

        for (int i = 0; i < 3; i++)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(_empty + _empty + _empty);

            Console.BackgroundColor = MapCubeColorToConsoleColor(cube.Down.Face[i, 0]);
            Console.Write(_empty);
            Console.BackgroundColor = MapCubeColorToConsoleColor(cube.Down.Face[i, 1]);
            Console.Write(_empty);
            Console.BackgroundColor = MapCubeColorToConsoleColor(cube.Down.Face[i, 2]);
            Console.Write(_empty);

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
}
