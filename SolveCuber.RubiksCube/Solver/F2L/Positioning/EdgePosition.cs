using SolveCuber.CubeModel;

namespace SolveCuber.Solver.F2L.Positioning;

// Default cube position while solving F2L is yellow on top, facing green.
internal class EdgePosition
{
    public bool IsOnTop { get; set; }
    
    // If the edge is on top layer, FirstColor represents color on the up face of the cube,
    // if the edge is not on top layer, FirstColor represents color on the front face of the cube, when the edge is on
    // the right side of the cube. To check other edges use only E moves.
    public CubeColor FirstColor { get; set; }

    // If the edge is on top layer, SecondColor represents color on the side face of the cube,
    // if the edge is not on top layer, FirstColor represents color on the front face of the cube, when the edge is on
    // the left side of the cube. To check other edges use only E moves.
    public CubeColor SecondColor { get; set; }
}
