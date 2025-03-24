using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Playground;
using SolveCuber.Scramble;
using SolveCuber.Solver.F2L;
using SolveCuber.Solver.WhiteCross;

Cube cube = new();

var scramble = Scrambler.ScrambleCube(cube);

DisplayMoves(scramble);

CubeDisplayer.DisplayCube(cube);

var solvingCrossMoves = WhiteCrossSolver.SolveCross(cube);

DisplayMoves(solvingCrossMoves);

cube.RotateCube(CubeRotation.z2);

CubeDisplayer.DisplayCube(cube);

F2LSolver.SolveF2l(cube);

void DisplayMoves(List<CubeMove> moves)
{
    Console.Write("\nMoves: ");

    foreach (var move in moves)
    {
        Console.Write(move.ToString() + ", ");
    }

    Console.Write("\n");
}