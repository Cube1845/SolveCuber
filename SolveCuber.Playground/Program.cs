using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Playground;
using SolveCuber.Scramble;
using SolveCuber.Solver.Solver;

Cube cube = new();

var scramble = Scrambler.ScrambleCube(cube);
//List<CubeMove> scramble = [];
//cube.ExecuteAlgorithm(scramble);

DisplayMoves(scramble);
CubeDisplayer.DisplayCube(cube);

CubeSolver.SolveCube(cube, out var solve);
CubeDisplayer.DisplaySolve(solve);

void DisplayMoves(List<CubeMove> moves)
{
    Console.Write("\nMoves: ");

    foreach (var move in moves)
    {
        Console.Write(move.ToString() + ", ");
    }

    Console.Write("\n");
}