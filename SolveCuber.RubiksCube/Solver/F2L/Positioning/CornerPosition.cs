using SolveCuber.CubeModel;

namespace SolveCuber.Solver.F2L.Positioning;

// Default cube position while solving F2L is yellow on top, facing green.
internal class CornerPosition
{
    public bool IsOnTop { get; set; }

    // Color of the up/down face.
    public CubeColor YAxisColor { get; set; }

    // RightColor represents front color of the corner when it's positioned at
    // the top/bottom layer and on the right side of the cube.
    public CubeColor RightColor { get; set; }

    // LeftColor represents front color of the corner when it's positioned at
    // the top/bottom layer and on the left side of the cube.
    public CubeColor LeftColor { get; set; }
}
