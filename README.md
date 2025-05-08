# SolveCuber

SolveCuber is a simple .NET library that solves the Rubiks Cube using CFOP method.

## Cube Object / CubeProvider

To create a Cube object use:
~~~
Cube cube = new(); // this creates a new, solved Cube
~~~
or use CubeProvider class:
~~~
CubeProvider.GetSolvedCube(); // this creates a new, solved Cube

CubeProvider.GetScrambledCube(); // this creates a randomly scrambled cube
CubeProvider.GetScrambledCube(out var scramble); // this creates a randomly scrambled cube
~~~
You can also insert your cube using
~~~
CubeProvider.InsertCube(up, down, front, back, right, left);
~~~
where each parameter is a CubeColor[,] in order that would be used in a 3d cube mesh.

To execute moves on the cube use:
~~~
cube.ExecuteMove(CubeMove);
cube.ExecuteAlgorithm([CubeMove, CubemMove, ...]);
~~~
where `CubeMove` is an enum.

## Scrambling

To scramble the cube as a separate action, use:
~~~
var scramble = Scrambler.ScrambleCube(cube); // this scrambles the cube and returns a scramble
~~~
or generate the scramble:
~~~
var scramble = Scramble.GenerateScramble();
~~~
and then execute it:
~~~
cube.ExecuteAlgorithm(scramble);
~~~
of course you can also use your own hard coded scramble this way.

## Solver

To solve the Rubiks Cube use:
~~~
CubeSolver.SolveCube(cube);
~~~
this solves the cube and returns a `Solution` object that contains information about the cube solution.

You can also solve every phase of the CFOP method separately using `WhiteCrossSolver`, `F2LSolver`, `OLLExecuter` and `PLLExecuter` classes.
