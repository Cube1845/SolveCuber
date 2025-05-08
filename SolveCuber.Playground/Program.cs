using SolveCuber.CubeModel;
using SolveCuber.Playground;
using SolveCuber.Provider;
using SolveCuber.Solver.Solver;

var cube = CubeProvider.GetScrambledCube(out var scramble);

//List<CubeMove> scramble = [];
//cube.ExecuteAlgorithm(scramble);

DisplayMoves(scramble);
CubeDisplayer.DisplayCube(cube);

var solve = CubeSolver.SolveCube(cube);
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