using SolveCuber.RubiksCube.Moves;

namespace SolveCuber.RubiksCube.Models;

public class Cube
{
    public CubeFace Up { get; private set; } = new CubeFace(CubeColor.White);
    public CubeFace Down { get; private set; } = new CubeFace(CubeColor.Yellow);
    public CubeFace Front { get; private set; } = new CubeFace(CubeColor.Green);
    public CubeFace Back { get; private set; } = new CubeFace(CubeColor.Blue);
    public CubeFace Right { get; private set; } = new CubeFace(CubeColor.Red);
    public CubeFace Left { get; private set; } = new CubeFace(CubeColor.Orange);

    public Cube ExecuteMove(CubeMove move)
    {
        SetCube(MoveExecuter.GetCubeImageAfterMove(this, move));

        return this;
    }

    private void SetCube(Cube cube)
    {
        Up = cube.Up;
        Down = cube.Down;
        Front = cube.Front;
        Back = cube.Back;
        Right = cube.Right;
        Left = cube.Left;
    }
}
