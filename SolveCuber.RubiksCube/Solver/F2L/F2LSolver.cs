using SolveCuber.CubeModel;
using SolveCuber.CubeModel.Models;
using SolveCuber.Solver.F2L.Positioning;
using SolveCuber.Solver.F2L.Positioning.Corners;
using SolveCuber.Solver.F2L.Positioning.Edges;

namespace SolveCuber.Solver.F2L;

public static class F2LSolver
{
    public static List<CubeMove> SolveF2l(Cube cube)
    {
        var cornersData = CornerPositionHelper.LocateCorners(cube);
        var edgesData = EdgePositionHelper.LocateEdges(cube);



        return [];
    }

    private static bool IsPairInCorrectPlace(WhiteCornerPosition cornerPosition, NonYellowEdgePosition edgePosition, CubeColor primaryColor, CubeColor secondaryColor)
    {
        bool isCornerInCorrectPlace;
        bool isEdgeInCorrectPlace;

        if (primaryColor == CubeColor.Red || primaryColor == CubeColor.Orange || secondaryColor == CubeColor.Green || secondaryColor == CubeColor.Blue)
        {
            throw new Exception("Primary colors are blue and green, secondary colors are red and orange.");
        }

        if (primaryColor == CubeColor.Green)
        {
            if (secondaryColor == CubeColor.Orange)
            {
                isCornerInCorrectPlace = !cornerPosition.IsOnTop &&
                    cornerPosition.WhiteStickerFaceAxis == FaceAxis.Y &&
                    cornerPosition.Location == PieceLocation.FrontRight;

                isEdgeInCorrectPlace = !edgePosition.IsOnTop &&
                    edgePosition.PrimaryColorFaceAxis == FaceAxis.Z &&
                    edgePosition.Location == PieceLocation.FrontRight;
            }
            else
            {
                isCornerInCorrectPlace = !cornerPosition.IsOnTop &&
                    cornerPosition.WhiteStickerFaceAxis == FaceAxis.Y &&
                    cornerPosition.Location == PieceLocation.FrontLeft;

                isEdgeInCorrectPlace = !edgePosition.IsOnTop &&
                    edgePosition.PrimaryColorFaceAxis == FaceAxis.Z &&
                    edgePosition.Location == PieceLocation.FrontLeft;
            }
        }
        else
        {
            if (secondaryColor == CubeColor.Orange)
            {
                isCornerInCorrectPlace = !cornerPosition.IsOnTop &&
                    cornerPosition.WhiteStickerFaceAxis == FaceAxis.Y &&
                    cornerPosition.Location == PieceLocation.BackRight;

                isEdgeInCorrectPlace = !edgePosition.IsOnTop &&
                    edgePosition.PrimaryColorFaceAxis == FaceAxis.Z &&
                    edgePosition.Location == PieceLocation.BackRight;
            }
            else
            {
                isCornerInCorrectPlace = !cornerPosition.IsOnTop &&
                    cornerPosition.WhiteStickerFaceAxis == FaceAxis.Y &&
                    cornerPosition.Location == PieceLocation.BackLeft;

                isEdgeInCorrectPlace = !edgePosition.IsOnTop &&
                    edgePosition.PrimaryColorFaceAxis == FaceAxis.Z &&
                    edgePosition.Location == PieceLocation.BackLeft;
            }
        }

        return isCornerInCorrectPlace && isEdgeInCorrectPlace;
    }
}
