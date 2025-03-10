using SolveCuber.CubeModel.Moves;

namespace SolveCuber.CubeModel.Models;

public partial class Cube()
{
    public CubeFace Up { get; private set; } = new CubeFace(CubeColor.White);
    public CubeFace Down { get; private set; } = new CubeFace(CubeColor.Yellow);
    public CubeFace Front { get; private set; } = new CubeFace(CubeColor.Green);
    public CubeFace Back { get; private set; } = new CubeFace(CubeColor.Blue);
    public CubeFace Right { get; private set; } = new CubeFace(CubeColor.Red);
    public CubeFace Left { get; private set; } = new CubeFace(CubeColor.Orange);

    internal Cube GetNewInstance()
    {
        return new Cube()
        {
            Up = Up.GetNewInstance(),
            Down = Down.GetNewInstance(),
            Front = Front.GetNewInstance(),
            Back = Back.GetNewInstance(),
            Right = Right.GetNewInstance(),
            Left = Left.GetNewInstance()
        };
    }

    public Cube ExecuteMove(CubeMove move)
    {
        SetCube(MoveExecuter.GetCubeImageAfterMove(GetNewInstance(), move));

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
