namespace SolveCuber.Solver.F2L.Positioning.Corners;

// Default cube position while solving F2L is yellow on top, facing green.
internal class WhiteCornerPosition
{
    public bool IsOnTop { get; set; }
    public PieceLocation Location { get; set; }
    public FaceAxis WhiteStickerFaceAxis { get; set; }
}
