using SolveCuber.CubeModel;
using SolveCuber.Solver.F2L.Positioning;
using SolveCuber.Solver.F2L.Positioning.Corners;
using SolveCuber.Solver.F2L.Positioning.Edges;

namespace SolveCuber.Solver.F2L;

internal static partial class F2LSolutions
{
    public static List<CubeMove> GetF2lSolution(WhiteCornerPosition cornerPosition, NonYellowEdgePosition edgePosition, CubeColor firstColor)
    {
        return cornerPosition.WhiteStickerFaceAxis switch
        {
            FaceAxis.Z => edgePosition.IsOnTop
                ? edgePosition.Location switch
                {
                    PieceLocation.FrontRight => (firstColor == CubeColor.Green || firstColor == CubeColor.Blue)
                        ? edgePosition.PrimaryColorFaceAxis switch
                        {
                            FaceAxis.Y => WhiteFaceZAxis.EdgeTopLayer.EdgeFrontRight.YFacesSameColor,
                            FaceAxis.X => WhiteFaceZAxis.EdgeTopLayer.EdgeFrontRight.YFacesDifferentColor,

                            _ => throw new NotImplementedException()
                        }
                        : edgePosition.PrimaryColorFaceAxis switch
                        {
                            FaceAxis.Y => WhiteFaceZAxis.EdgeTopLayer.EdgeFrontRight.YFacesDifferentColor,
                            FaceAxis.X => WhiteFaceZAxis.EdgeTopLayer.EdgeFrontRight.YFacesSameColor,

                            _ => throw new NotImplementedException()
                        },
                    PieceLocation.FrontLeft => (firstColor == CubeColor.Green || firstColor == CubeColor.Blue)
                        ? edgePosition.PrimaryColorFaceAxis switch
                        {
                            FaceAxis.Y => WhiteFaceZAxis.EdgeTopLayer.EdgeFrontLeft.YFacesSameColor,
                            FaceAxis.Z =>   WhiteFaceZAxis.EdgeTopLayer.EdgeFrontLeft.YFacesDifferentColor,

                            _ => throw new NotImplementedException()
                        }
                        : edgePosition.PrimaryColorFaceAxis switch
                        {
                            FaceAxis.Y =>   WhiteFaceZAxis.EdgeTopLayer.EdgeFrontLeft.YFacesDifferentColor,
                            FaceAxis.Z => WhiteFaceZAxis.EdgeTopLayer.EdgeFrontLeft.YFacesSameColor,

                            _ => throw new NotImplementedException()
                        },
                    PieceLocation.BackRight => (firstColor == CubeColor.Green || firstColor == CubeColor.Blue)
                        ? edgePosition.PrimaryColorFaceAxis switch
                        {
                            FaceAxis.Y => WhiteFaceZAxis.EdgeTopLayer.EdgeBackRight.YFacesSameColor,
                            FaceAxis.Z => WhiteFaceZAxis.EdgeTopLayer.EdgeBackRight.YFacesDifferentColor,

                            _ => throw new NotImplementedException()
                        }
                        : edgePosition.PrimaryColorFaceAxis switch
                        {
                            FaceAxis.Y => WhiteFaceZAxis.EdgeTopLayer.EdgeBackRight.YFacesDifferentColor,
                            FaceAxis.Z => WhiteFaceZAxis.EdgeTopLayer.EdgeBackRight.YFacesSameColor,

                            _ => throw new NotImplementedException()
                        },
                    PieceLocation.BackLeft => (firstColor == CubeColor.Green || firstColor == CubeColor.Blue)
                        ? edgePosition.PrimaryColorFaceAxis switch
                        {
                            FaceAxis.Y => WhiteFaceZAxis.EdgeTopLayer.EdgeBackLeft.YFacesSameColor,
                            FaceAxis.X => WhiteFaceZAxis.EdgeTopLayer.EdgeBackLeft.YFacesDifferentColor,

                            _ => throw new NotImplementedException()
                        }
                        : edgePosition.PrimaryColorFaceAxis switch
                        {
                            FaceAxis.Y => WhiteFaceZAxis.EdgeTopLayer.EdgeBackLeft.YFacesDifferentColor,
                            FaceAxis.X => WhiteFaceZAxis.EdgeTopLayer.EdgeBackLeft.YFacesSameColor,

                            _ => throw new NotImplementedException()
                        },

                    _ => throw new NotImplementedException()
                }
                : edgePosition.Location switch
                {
                    PieceLocation.FrontRight => (firstColor == CubeColor.Green || firstColor == CubeColor.Blue)
                        ? edgePosition.PrimaryColorFaceAxis switch
                        {
                            FaceAxis.X => WhiteFaceZAxis.EdgeMiddleLayer.EdgeFrontRight.YXFaceSameColor,
                            FaceAxis.Z => WhiteFaceZAxis.EdgeMiddleLayer.EdgeFrontRight.YXFaceDifferentColor,

                            _ => throw new NotImplementedException()
                        }
                        : edgePosition.PrimaryColorFaceAxis switch
                        {
                            FaceAxis.X => WhiteFaceZAxis.EdgeMiddleLayer.EdgeFrontRight.YXFaceDifferentColor,
                            FaceAxis.Z => WhiteFaceZAxis.EdgeMiddleLayer.EdgeFrontRight.YXFaceSameColor,

                            _ => throw new NotImplementedException()
                        },
                    PieceLocation.FrontLeft => (firstColor == CubeColor.Green || firstColor == CubeColor.Blue)
                        ? edgePosition.PrimaryColorFaceAxis switch
                        {
                            FaceAxis.X => WhiteFaceZAxis.EdgeMiddleLayer.EdgeFrontLeft.YXFaceSameColor,
                            FaceAxis.Z => WhiteFaceZAxis.EdgeMiddleLayer.EdgeFrontLeft.YXFaceDifferentColor,

                            _ => throw new NotImplementedException()
                        }
                        : edgePosition.PrimaryColorFaceAxis switch
                        {
                            FaceAxis.X => WhiteFaceZAxis.EdgeMiddleLayer.EdgeFrontLeft.YXFaceDifferentColor,
                            FaceAxis.Z => WhiteFaceZAxis.EdgeMiddleLayer.EdgeFrontLeft.YXFaceSameColor,

                            _ => throw new NotImplementedException()
                        },
                    PieceLocation.BackRight => (firstColor == CubeColor.Green || firstColor == CubeColor.Blue)
                        ? edgePosition.PrimaryColorFaceAxis switch
                        {
                            FaceAxis.X => WhiteFaceZAxis.EdgeMiddleLayer.EdgeBackRight.YXFaceSameColor,
                            FaceAxis.Z => WhiteFaceZAxis.EdgeMiddleLayer.EdgeBackRight.YXFaceDifferentColor,

                            _ => throw new NotImplementedException()
                        }
                        : edgePosition.PrimaryColorFaceAxis switch
                        {
                            FaceAxis.X => WhiteFaceZAxis.EdgeMiddleLayer.EdgeBackRight.YXFaceDifferentColor,
                            FaceAxis.Z => WhiteFaceZAxis.EdgeMiddleLayer.EdgeBackRight.YXFaceSameColor,

                            _ => throw new NotImplementedException()
                        },
                    PieceLocation.BackLeft => (firstColor == CubeColor.Green || firstColor == CubeColor.Blue)
                        ? edgePosition.PrimaryColorFaceAxis switch
                        {
                            FaceAxis.X => WhiteFaceZAxis.EdgeMiddleLayer.EdgeBackLeft.YXFaceSameColor,
                            FaceAxis.Z => WhiteFaceZAxis.EdgeMiddleLayer.EdgeBackLeft.YXFaceDifferentColor,

                            _ => throw new NotImplementedException()
                        }
                        : edgePosition.PrimaryColorFaceAxis switch
                        {
                            FaceAxis.X => WhiteFaceZAxis.EdgeMiddleLayer.EdgeBackLeft.YXFaceDifferentColor,
                            FaceAxis.Z => WhiteFaceZAxis.EdgeMiddleLayer.EdgeBackLeft.YXFaceSameColor,

                            _ => throw new NotImplementedException()
                        },

                    _ => throw new NotImplementedException()
                },

            _ => throw new NotImplementedException()
        };
    }
}
