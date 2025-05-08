namespace SolveCuber.CubeModel.Models;

public partial struct Cube
{
    public CubeFace Up { get; private set; }
    public CubeFace Down { get; private set; }
    public CubeFace Front { get; private set; }
    public CubeFace Back { get; private set; }
    public CubeFace Right { get; private set; }
    public CubeFace Left { get; private set; }

    public Cube()
    {
        Up = new CubeFace(CubeColor.White);
        Down = new CubeFace(CubeColor.Yellow);
        Front = new CubeFace(CubeColor.Green);
        Back = new CubeFace(CubeColor.Blue);
        Right = new CubeFace(CubeColor.Red);
        Left = new CubeFace(CubeColor.Orange);
    }

    internal Cube(CubeColor[,] up, CubeColor[,] down, CubeColor[,] front, CubeColor[,] back, CubeColor[,] right, CubeColor[,] left)
    {
        Up = new CubeFace(up);
        Down = new CubeFace(down);
        Front = new CubeFace(front);
        Back = new CubeFace(back);
        Right = new CubeFace(right);
        Left = new CubeFace(left);
    }

    internal Cube DeepCopy()
    {
        return new Cube()
        {
            Up = Up.DeepCopy(),
            Down = Down.DeepCopy(),
            Front = Front.DeepCopy(),
            Back = Back.DeepCopy(),
            Right = Right.DeepCopy(),
            Left = Left.DeepCopy()
        };
    }

    public Cube ExecuteAlgorithm(List<CubeMove> algorithm)
    {
        foreach (var move in algorithm)
        {
            ExecuteMove(move);
        }

        return this;
    }

    public Cube ExecuteMove(CubeMove move)
    {
        Action executeMoveFn = move switch
        {
            CubeMove.U => ExecuteUpMove,
            CubeMove.U_ => ExecuteUpPrimeMove,
            CubeMove.U2 => ExecuteDoubleUpMove,
            CubeMove.D => ExecuteDownMove,
            CubeMove.D_ => ExecuteDownPrimeMove,
            CubeMove.D2 => ExecuteDoubleDownMove,
            CubeMove.F => ExecuteFrontMove,
            CubeMove.F_ => ExecuteFrontPrimeMove,
            CubeMove.F2 => ExecuteDoubleFrontMove,
            CubeMove.B => ExecuteBackMove,
            CubeMove.B_ => ExecuteBackPrimeMove,
            CubeMove.B2 => ExecuteDoubleBackMove,
            CubeMove.R => ExecuteRightMove,
            CubeMove.R_ => ExecuteRightPrimeMove,
            CubeMove.R2 => ExecuteDoubleRightMove,
            CubeMove.L => ExecuteLeftMove,
            CubeMove.L_ => ExecuteLeftPrimeMove,
            CubeMove.L2 => ExecuteDoubleLeftMove,

            CubeMove.u => ExecuteUpWideMove,
            CubeMove.u_ => ExecuteUpWidePrimeMove,
            CubeMove.u2 => ExecuteDoubleUpWideMove,
            CubeMove.d => ExecuteDownWideMove,
            CubeMove.d_ => ExecuteDownWidePrimeMove,
            CubeMove.d2 => ExecuteDoubleDownWideMove,
            CubeMove.f => ExecuteFrontWideMove,
            CubeMove.f_ => ExecuteFrontWidePrimeMove,
            CubeMove.f2 => ExecuteDoubleFrontWideMove,
            CubeMove.b => ExecuteBackWideMove,
            CubeMove.b_ => ExecuteBackWidePrimeMove,
            CubeMove.b2 => ExecuteDoubleBackWideMove,
            CubeMove.r => ExecuteRightWideMove,
            CubeMove.r_ => ExecuteRightWidePrimeMove,
            CubeMove.r2 => ExecuteDoubleRightWideMove,
            CubeMove.l => ExecuteLeftWideMove,
            CubeMove.l_ => ExecuteLeftWidePrimeMove,
            CubeMove.l2 => ExecuteDoubleLeftWideMove,

            CubeMove.M => ExecuteMiddleMove,
            CubeMove.M_ => ExecuteMiddlePrimeMove,
            CubeMove.M2 => ExecuteDoubleMiddleMove,
            CubeMove.E => ExecuteEquatorMove,
            CubeMove.E_ => ExecuteEquatorPrimeMove,
            CubeMove.E2 => ExecuteDoubleEquatorMove,
            CubeMove.S => ExecuteStandingMove,
            CubeMove.S_ => ExecuteStandingPrimeMove,
            CubeMove.S2 => ExecuteDoubleStandingMove,

            CubeMove.x => ExecuteXRotation,
            CubeMove.x_ => ExecuteXPrimeRotation,
            CubeMove.x2 => ExecuteDoubleXRotation,
            CubeMove.y => ExecuteYRotation,
            CubeMove.y_ => ExecuteYPrimeRotation,
            CubeMove.y2 => ExecuteDoubleYRotation,
            CubeMove.z => ExecuteZRotation,
            CubeMove.z_ => ExecuteZPrimeRotation,
            CubeMove.z2 => ExecuteDoubleZRotation,

            _ => throw new NotImplementedException()
        };

        executeMoveFn();

        return this;
    }
}
