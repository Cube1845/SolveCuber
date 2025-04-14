using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Playground;
using SolveCuber.Scramble;
using SolveCuber.Solver.F2L;
using SolveCuber.Solver.OLL;
using SolveCuber.Solver.PLL;
using SolveCuber.Solver.WhiteCross;

Cube cube = new();

var scramble = Scrambler.ScrambleCube(cube);

DisplayMoves(scramble);
CubeDisplayer.DisplayCube(cube);

var solvingCrossMoves = WhiteCrossSolver.SolveCross(cube);

DisplayMoves(solvingCrossMoves);
CubeDisplayer.DisplayCube(cube);

cube.ExecuteMove(CubeMove.z2);

var solvingF2LMoves = F2LSolver.SolveF2L(cube);

DisplayMoves(solvingF2LMoves);
CubeDisplayer.DisplayCube(cube);

var oll = OLLExecuter.ExecuteOLL(cube);

DisplayMoves(oll);
CubeDisplayer.DisplayCube(cube);

var pll = PLLExecuter.ExecutePLL(cube);

DisplayMoves(pll);
CubeDisplayer.DisplayCube(cube);

void DisplayMoves(List<CubeMove> moves)
{
    Console.Write("\nMoves: ");

    foreach (var move in moves)
    {
        Console.Write(move.ToString() + ", ");
    }

    Console.Write("\n");
}