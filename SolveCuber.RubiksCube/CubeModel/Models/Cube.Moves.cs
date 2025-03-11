namespace SolveCuber.CubeModel.Models;

public partial struct Cube
{
    // U moves

    private void ExecuteUpMove()
    {
        Up.RotateClockwise();
        MoveColorsAroundYAxis(0, true);
    }

    private void ExecuteUpPrimeMove()
    {
        Up.RotateCounterClockwise();
        MoveColorsAroundYAxis(0, false);
    }

    private void ExecuteDoubleUpMove()
    {
        Up.RotateTwoTimes();
        DoubleMoveColorsAroundYAxis(0);
    }

    // D moves

    private void ExecuteDownMove()
    {
        Down.RotateClockwise();
        MoveColorsAroundYAxis(2, false);
    }

    private void ExecuteDownPrimeMove()
    {
        Down.RotateCounterClockwise();
        MoveColorsAroundYAxis(2, true);
    }

    private void ExecuteDoubleDownMove()
    {
        Down.RotateTwoTimes();
        DoubleMoveColorsAroundYAxis(2);
    }

    // F moves

    private void ExecuteFrontMove()
    {
        Front.RotateClockwise();
        MoveColorsAroundZAxis(2, true);
    }

    private void ExecuteFrontPrimeMove()
    {
        Front.RotateCounterClockwise();
        MoveColorsAroundZAxis(2, false);
    }

    private void ExecuteDoubleFrontMove()
    {
        Front.RotateTwoTimes();
        DoubleMoveColorsAroundZAxis(2);
    }

    // B moves

    private void ExecuteBackMove()
    {
        Back.RotateClockwise();
        MoveColorsAroundZAxis(0, false);
    }

    private void ExecuteBackPrimeMove()
    {
        Back.RotateCounterClockwise();
        MoveColorsAroundZAxis(0, true);
    }

    private void ExecuteDoubleBackMove()
    {
        Back.RotateTwoTimes();
        DoubleMoveColorsAroundZAxis(0);
    }

    // L moves

    private void ExecuteLeftMove()
    {
        Left.RotateClockwise();
        MoveColorsAroundXAxis(0, true);
    }

    private void ExecuteLeftPrimeMove()
    {
        Left.RotateCounterClockwise();
        MoveColorsAroundXAxis(0, false);
    }

    private void ExecuteDoubleLeftMove()
    {
        Left.RotateTwoTimes();
        DoubleMoveColorsAroundXAxis(0);
    }

    // R moves

    private void ExecuteRightMove()
    {
        Right.RotateClockwise();
        MoveColorsAroundXAxis(2, false);
    }

    private void ExecuteRightPrimeMove()
    {
        Right.RotateCounterClockwise();
        MoveColorsAroundXAxis(2, true);
    }

    private void ExecuteDoubleRightMove()
    {
        Right.RotateTwoTimes();
        DoubleMoveColorsAroundXAxis(2);
    }

    // U wide moves
    private void ExecuteUpWideMove()
    {
        Up.RotateClockwise();
        MoveColorsAroundYAxis(0, true);
        MoveColorsAroundYAxis(1, true);
    }

    private void ExecuteUpWidePrimeMove()
    {
        Up.RotateCounterClockwise();
        MoveColorsAroundYAxis(0, false);
        MoveColorsAroundYAxis(1, false);
    }

    private void ExecuteDoubleUpWideMove()
    {
        Up.RotateTwoTimes();
        DoubleMoveColorsAroundYAxis(0);
        DoubleMoveColorsAroundYAxis(1);
    }

    // D wide moves
    private void ExecuteDownWideMove()
    {
        Down.RotateClockwise();
        MoveColorsAroundYAxis(2, false);
        MoveColorsAroundYAxis(1, false);
    }

    private void ExecuteDownWidePrimeMove()
    {
        Down.RotateCounterClockwise();
        MoveColorsAroundYAxis(2, true);
        MoveColorsAroundYAxis(1, true);
    }

    private void ExecuteDoubleDownWideMove()
    {
        Down.RotateTwoTimes();
        DoubleMoveColorsAroundYAxis(2);
        DoubleMoveColorsAroundYAxis(1);
    }

    // F wide moves
    private void ExecuteFrontWideMove()
    {
        Front.RotateClockwise();
        MoveColorsAroundZAxis(2, true);
        MoveColorsAroundZAxis(1, true);
    }

    private void ExecuteFrontWidePrimeMove()
    {
        Front.RotateCounterClockwise();
        MoveColorsAroundZAxis(2, false);
        MoveColorsAroundZAxis(1, false);
    }

    private void ExecuteDoubleFrontWideMove()
    {
        Front.RotateTwoTimes();
        DoubleMoveColorsAroundZAxis(2);
        DoubleMoveColorsAroundZAxis(1);
    }

    // B wide moves
    private void ExecuteBackWideMove()
    {
        Back.RotateClockwise();
        MoveColorsAroundZAxis(0, false);
        MoveColorsAroundZAxis(1, false);
    }

    private void ExecuteBackWidePrimeMove()
    {
        Back.RotateCounterClockwise();
        MoveColorsAroundZAxis(0, true);
        MoveColorsAroundZAxis(1, true);
    }

    private void ExecuteDoubleBackWideMove()
    {
        Back.RotateTwoTimes();
        DoubleMoveColorsAroundZAxis(0);
        DoubleMoveColorsAroundZAxis(1);
    }

    // L wide moves
    private void ExecuteLeftWideMove()
    {
        Left.RotateClockwise();
        MoveColorsAroundXAxis(0, true);
        MoveColorsAroundXAxis(1, true);
    }

    private void ExecuteLeftWidePrimeMove()
    {
        Left.RotateCounterClockwise();
        MoveColorsAroundXAxis(0, false);
        MoveColorsAroundXAxis(1, false);
    }

    private void ExecuteDoubleLeftWideMove()
    {
        Left.RotateTwoTimes();
        DoubleMoveColorsAroundXAxis(0);
        DoubleMoveColorsAroundXAxis(1);
    }

    // R wide moves
    private void ExecuteRightWideMove()
    {
        Right.RotateClockwise();
        MoveColorsAroundXAxis(2, false);
        MoveColorsAroundXAxis(1, false);
    }

    private void ExecuteRightWidePrimeMove()
    {
        Right.RotateCounterClockwise();
        MoveColorsAroundXAxis(2, true);
        MoveColorsAroundXAxis(1, true);
    }

    private void ExecuteDoubleRightWideMove()
    {
        Right.RotateTwoTimes();
        DoubleMoveColorsAroundXAxis(2);
        DoubleMoveColorsAroundXAxis(1);
    }

    // M moves

    private void ExecuteMiddleMove()
    {
        MoveColorsAroundXAxis(1, true);
    }

    private void ExecuteMiddlePrimeMove()
    {
        MoveColorsAroundXAxis(1, false);
    }

    private void ExecuteDoubleMiddleMove()
    {
        DoubleMoveColorsAroundXAxis(1);
    }

    // E moves

    private void ExecuteEquatorMove()
    {
        MoveColorsAroundYAxis(1, false);
    }

    private void ExecuteEquatorPrimeMove()
    {
        MoveColorsAroundYAxis(1, true);
    }

    private void ExecuteDoubleEquatorMove()
    {
        DoubleMoveColorsAroundXAxis(1);
    }

    // S moves

    private void ExecuteStandingMove()
    {
        MoveColorsAroundZAxis(1, true);
    }

    private void ExecuteStandingPrimeMove()
    {
        MoveColorsAroundZAxis(1, false);
    }

    private void ExecuteDoubleStandingMove()
    {
        DoubleMoveColorsAroundZAxis(1);
    }

    private void MoveColorsAroundYAxis(int y, bool clockwise)
    {
        // Clockwise means clockwise in U move
        var originalCubeState = DeepCopy();

        if (clockwise)
        {
            Front.Face[y, 0] = originalCubeState.Right.Face[y, 0];
            Front.Face[y, 1] = originalCubeState.Right.Face[y, 1];
            Front.Face[y, 2] = originalCubeState.Right.Face[y, 2];

            Right.Face[y, 0] = originalCubeState.Back.Face[y, 0];
            Right.Face[y, 1] = originalCubeState.Back.Face[y, 1];
            Right.Face[y, 2] = originalCubeState.Back.Face[y, 2];

            Back.Face[y, 0] = originalCubeState.Left.Face[y, 0];
            Back.Face[y, 1] = originalCubeState.Left.Face[y, 1];
            Back.Face[y, 2] = originalCubeState.Left.Face[y, 2];

            Left.Face[y, 0] = originalCubeState.Front.Face[y, 0];
            Left.Face[y, 1] = originalCubeState.Front.Face[y, 1];
            Left.Face[y, 2] = originalCubeState.Front.Face[y, 2];
        }
        else
        {
            Right.Face[y, 0] = originalCubeState.Front.Face[y, 0];
            Right.Face[y, 1] = originalCubeState.Front.Face[y, 1];
            Right.Face[y, 2] = originalCubeState.Front.Face[y, 2];

            Back.Face[y, 0] = originalCubeState.Right.Face[y, 0];
            Back.Face[y, 1] = originalCubeState.Right.Face[y, 1];
            Back.Face[y, 2] = originalCubeState.Right.Face[y, 2];

            Left.Face[y, 0] = originalCubeState.Back.Face[y, 0];
            Left.Face[y, 1] = originalCubeState.Back.Face[y, 1];
            Left.Face[y, 2] = originalCubeState.Back.Face[y, 2];

            Front.Face[y, 0] = originalCubeState.Left.Face[y, 0];
            Front.Face[y, 1] = originalCubeState.Left.Face[y, 1];
            Front.Face[y, 2] = originalCubeState.Left.Face[y, 2];
        }
    }

    private void MoveColorsAroundXAxis(int x, bool clockwise)
    {
        // Clockwise means clockwise in L move
        var originalCubeState = DeepCopy();

        if (clockwise)
        {
            Down.Face[0, x] = originalCubeState.Front.Face[0, x];
            Down.Face[1, x] = originalCubeState.Front.Face[1, x];
            Down.Face[2, x] = originalCubeState.Front.Face[2, x];

            Front.Face[0, x] = originalCubeState.Up.Face[0, x];
            Front.Face[1, x] = originalCubeState.Up.Face[1, x];
            Front.Face[2, x] = originalCubeState.Up.Face[2, x];

            Up.Face[0, x] = originalCubeState.Back.Face[0, 2 - x];
            Up.Face[1, x] = originalCubeState.Back.Face[1, 2 - x];
            Up.Face[2, x] = originalCubeState.Back.Face[2, 2 - x];

            Back.Face[0, 2 - x] = originalCubeState.Down.Face[0, x];
            Back.Face[1, 2 - x] = originalCubeState.Down.Face[1, x];
            Back.Face[2, 2 - x] = originalCubeState.Down.Face[2, x];
        }
        else
        {
            Front.Face[0, x] = originalCubeState.Down.Face[0, x];
            Front.Face[1, x] = originalCubeState.Down.Face[1, x];
            Front.Face[2, x] = originalCubeState.Down.Face[2, x];

            Up.Face[0, x] = originalCubeState.Front.Face[0, x];
            Up.Face[1, x] = originalCubeState.Front.Face[1, x];
            Up.Face[2, x] = originalCubeState.Front.Face[2, x];

            Back.Face[0, 2 - x] = originalCubeState.Up.Face[0, x];
            Back.Face[1, 2 - x] = originalCubeState.Up.Face[1, x];
            Back.Face[2, 2 - x] = originalCubeState.Up.Face[2, x];

            Down.Face[0, x] = originalCubeState.Back.Face[0, 2 - x];
            Down.Face[1, x] = originalCubeState.Back.Face[1, 2 - x];
            Down.Face[2, x] = originalCubeState.Back.Face[2, 2 - x];
        }
    }

    private void MoveColorsAroundZAxis(int z, bool clockwise)
    {
        // Clockwise means clockwise in F move
        var originalCubeState = DeepCopy();

        if (clockwise)
        {
            Up.Face[z, 0] = originalCubeState.Left.Face[0, z];
            Up.Face[z, 1] = originalCubeState.Left.Face[1, z];
            Up.Face[z, 2] = originalCubeState.Left.Face[2, z];

            Left.Face[0, z] = originalCubeState.Down.Face[2 - z, 0];
            Left.Face[1, z] = originalCubeState.Down.Face[2 - z, 1];
            Left.Face[2, z] = originalCubeState.Down.Face[2 - z, 2];

            Down.Face[2 - z, 0] = originalCubeState.Right.Face[0, 2 - z];
            Down.Face[2 - z, 1] = originalCubeState.Right.Face[1, 2 - z];
            Down.Face[2 - z, 2] = originalCubeState.Right.Face[2, 2 - z];

            Right.Face[0, 2 - z] = originalCubeState.Up.Face[z, 0];
            Right.Face[1, 2 - z] = originalCubeState.Up.Face[z, 1];
            Right.Face[2, 2 - z] = originalCubeState.Up.Face[z, 2];
        }
        else
        {
            Left.Face[0, z] = originalCubeState.Up.Face[z, 0];
            Left.Face[1, z] = originalCubeState.Up.Face[z, 1];
            Left.Face[2, z] = originalCubeState.Up.Face[z, 2];

            Down.Face[2 - z, 0] = originalCubeState.Left.Face[0, z];
            Down.Face[2 - z, 1] = originalCubeState.Left.Face[1, z];
            Down.Face[2 - z, 2] = originalCubeState.Left.Face[2, z];

            Right.Face[0, 2 - z] = originalCubeState.Down.Face[2 - z, 0];
            Right.Face[1, 2 - z] = originalCubeState.Down.Face[2 - z, 1];
            Right.Face[2, 2 - z] = originalCubeState.Down.Face[2 - z, 2];

            Up.Face[z, 0] = originalCubeState.Right.Face[0, 2 - z];
            Up.Face[z, 1] = originalCubeState.Right.Face[1, 2 - z];
            Up.Face[z, 2] = originalCubeState.Right.Face[2, 2 - z];
        }
    }

    private void DoubleMoveColorsAroundYAxis(int y)
    {
        var originalCubeState = DeepCopy();

        Front.Face[y, 0] = originalCubeState.Back.Face[y, 0];
        Front.Face[y, 1] = originalCubeState.Back.Face[y, 1];
        Front.Face[y, 2] = originalCubeState.Back.Face[y, 2];

        Back.Face[y, 0] = originalCubeState.Front.Face[y, 0];
        Back.Face[y, 1] = originalCubeState.Front.Face[y, 1];
        Back.Face[y, 2] = originalCubeState.Front.Face[y, 2];

        Left.Face[y, 0] = originalCubeState.Right.Face[y, 0];
        Left.Face[y, 1] = originalCubeState.Right.Face[y, 1];
        Left.Face[y, 2] = originalCubeState.Right.Face[y, 2];

        Right.Face[y, 0] = originalCubeState.Left.Face[y, 0];
        Right.Face[y, 1] = originalCubeState.Left.Face[y, 1];
        Right.Face[y, 2] = originalCubeState.Left.Face[y, 2];
    }

    private void DoubleMoveColorsAroundXAxis(int x)
    {
        var originalCubeState = DeepCopy();

        Up.Face[0, x] = originalCubeState.Down.Face[0, x];
        Up.Face[1, x] = originalCubeState.Down.Face[1, x];
        Up.Face[2, x] = originalCubeState.Down.Face[2, x];

        Down.Face[0, x] = originalCubeState.Up.Face[0, x];
        Down.Face[1, x] = originalCubeState.Up.Face[1, x];
        Down.Face[2, x] = originalCubeState.Up.Face[2, x];

        Front.Face[0, x] = originalCubeState.Back.Face[0, x];
        Front.Face[1, x] = originalCubeState.Back.Face[1, x];
        Front.Face[2, x] = originalCubeState.Back.Face[2, x];

        Back.Face[0, x] = originalCubeState.Front.Face[0, x];
        Back.Face[1, x] = originalCubeState.Front.Face[1, x];
        Back.Face[2, x] = originalCubeState.Front.Face[2, x];
    }

    private void DoubleMoveColorsAroundZAxis(int z)
    {
        var originalCubeState = DeepCopy();

        Up.Face[z, 0] = originalCubeState.Down.Face[2 - z, 0];
        Up.Face[z, 1] = originalCubeState.Down.Face[2 - z, 1];
        Up.Face[z, 2] = originalCubeState.Down.Face[2 - z, 2];

        Down.Face[2 - z, 0] = originalCubeState.Up.Face[z, 0];
        Down.Face[2 - z, 1] = originalCubeState.Up.Face[z, 1];
        Down.Face[2 - z, 2] = originalCubeState.Up.Face[z, 2];

        Left.Face[0, z] = originalCubeState.Right.Face[0, 2 - z];
        Left.Face[1, z] = originalCubeState.Right.Face[1, 2 - z];
        Left.Face[2, z] = originalCubeState.Right.Face[2, 2 - z];

        Right.Face[0, 2 - z] = originalCubeState.Left.Face[0, z];
        Right.Face[1, 2 - z] = originalCubeState.Left.Face[1, z];
        Right.Face[2, 2 - z] = originalCubeState.Left.Face[2, z];
    }
}
