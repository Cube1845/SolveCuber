using SolveCuber.Solver.Common;

namespace SolveCuber.Solver.F2L.Positioning.Corners;

// Default cube position while solving F2L is yellow on top, facing green.
internal struct WhiteCornerPosition
{
    public WhiteCornerPosition() {}

    public WhiteCornerPosition(bool isOnTop, PieceLocation location, FaceAxis whiteStickerFaceAxis)
    {
        IsOnTop = isOnTop;
        Location = location;
        WhiteStickerFaceAxis = whiteStickerFaceAxis;
    }

    public bool IsOnTop { get; set; }
    public PieceLocation Location { get; set; }
    public FaceAxis WhiteStickerFaceAxis { get; set; }
}
