using SolveCuber.Common;
using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Scramble;

namespace SolveCuber.Provider;

public static class CubeProvider
{
    /// <summary>
    /// Creates a new, solved cube.
    /// </summary>
    /// <returns>Solved cube.</returns>
    public static Cube GetSolvedCube()
    {
        return new();
    }

    /// <summary>
    /// Creates a cube based on faces that you provide.
    /// </summary>
    /// <param name="up">Up face of the cube.</param>
    /// <param name="down">Down face of the cube.</param>
    /// <param name="front">Front face of the cube.</param>
    /// <param name="back">Back face of the cube.</param>
    /// <param name="right">Right face of the cube.</param>
    /// <param name="left">Left face of the cube.</param>
    /// <returns>Cube with face provided by user if they are valid.</returns>
    /// <exception cref="RubiksCubeException"></exception>
    public static Cube InsertCube(CubeColor[,] up, CubeColor[,] down, CubeColor[,] front, CubeColor[,] back, CubeColor[,] right, CubeColor[,] left)
    {
        Cube cube = new(up, down, front, back, right, left);

        var isCubeValid =
            CubeValidator.ValidateCenters(cube) &&
            CubeValidator.ValidateCubeColors(cube) &&
            CubeValidator.ValidateCubeSolve(cube);

        if (!isCubeValid)
        {
            throw new RubiksCubeException("Cube is not valid");
        }

        return cube;
    }

    /// <summary>
    /// Creates a new cube and randomly scrambles it.
    /// </summary>
    /// <returns>Scrambled cube.</returns>
    public static Cube GetScrambledCube()
    {
        Cube cube = new();

        Scrambler.ScrambleCube(cube);

        return cube;
    }

    /// <summary>
    /// Creates a new cube and randomly scrambles it.
    /// </summary>
    /// <param name="scramble">The scramble that was used.</param>
    /// <returns>Scrambled cube.</returns>
    public static Cube GetScrambledCube(out List<CubeMove> scramble)
    {
        Cube cube = new();

        scramble = Scrambler.ScrambleCube(cube);

        return cube;
    }
}
