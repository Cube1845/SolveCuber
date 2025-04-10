namespace SolveCuber.Solver.F2L.Positioning.Edges;

// Default cube position while solving F2L is yellow on top, facing green.
internal struct NonYellowEdgePosition
{
    public NonYellowEdgePosition() {}

    public NonYellowEdgePosition(bool isOnTop, PieceLocation location, FaceAxis faceAxis)
    {
        IsOnTop = isOnTop;
        Location = location;
        PrimaryColorFaceAxis = faceAxis;
    }

    public bool IsOnTop { get; set; }

    // If the edge is on top layer,
    // BackRight is Back edge, BackLeft is Left edge, FrontRight is Right edge and FrontLeft is Front edge.
    public PieceLocation Location { get; set; }
    
    // Primary colors are green and blue.
    public FaceAxis PrimaryColorFaceAxis { get; set; }
}
