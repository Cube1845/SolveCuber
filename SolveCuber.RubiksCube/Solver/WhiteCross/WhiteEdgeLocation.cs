namespace SolveCuber.Solver.WhiteCross;

// First identifier determines in which direction the edge is facing with the white color,
// the second one determines the location of the edge at the first identifier's layer

internal enum WhiteEdgeLocation
{
    UpBack = 1,
    UpLeft = 2,
    UpRight = 3,
    UpFront = 4,

    DownFront = 5,
    DownLeft = 6,
    DownRight = 7,
    DownBack = 8,

    FrontUp = 9,
    FrontLeft = 10,
    FrontRight = 11,
    FrontDown = 12,

    BackUp = 13,
    BackRight = 14,
    BackLeft = 15,
    BackDown = 16,

    RightUp = 17,
    RightFront = 18,
    RightBack = 19,
    RightDown = 20,

    LeftUp = 21,
    LeftBack = 22,
    LeftFront = 23,
    LeftDown = 24,
}
