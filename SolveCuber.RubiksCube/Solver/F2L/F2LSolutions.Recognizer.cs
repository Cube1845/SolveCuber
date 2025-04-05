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
            FaceAxis.Z => RecognizeWhieFaceZAxisCase(cornerPosition, edgePosition, firstColor),
            FaceAxis.X => RecognizeWhieFaceXAxisCase(cornerPosition, edgePosition, firstColor),
            FaceAxis.Y => RecognizeWhieFaceYAxisCase(cornerPosition, edgePosition, firstColor),

            _ => throw new NotImplementedException()
        };
    }

    private static List<CubeMove> RecognizeWhieFaceZAxisCase(WhiteCornerPosition cornerPosition, NonYellowEdgePosition edgePosition, CubeColor firstColor)
    {
        return edgePosition.IsOnTop
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
                        FaceAxis.Z => WhiteFaceZAxis.EdgeTopLayer.EdgeFrontLeft.YFacesDifferentColor,

                        _ => throw new NotImplementedException()
                    }
                    : edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.Y => WhiteFaceZAxis.EdgeTopLayer.EdgeFrontLeft.YFacesDifferentColor,
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
            };
    }

    private static List<CubeMove> RecognizeWhieFaceXAxisCase(WhiteCornerPosition cornerPosition, NonYellowEdgePosition edgePosition, CubeColor firstColor)
    {
        return edgePosition.IsOnTop
            ? edgePosition.Location switch
            {
                PieceLocation.FrontRight => (firstColor == CubeColor.Green || firstColor == CubeColor.Blue)
                    ? edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.Y => WhiteFaceXAxis.EdgeTopLayer.EdgeFrontRight.YFacesDifferentColor,
                        FaceAxis.X => WhiteFaceXAxis.EdgeTopLayer.EdgeFrontRight.YFacesSameColor,

                        _ => throw new NotImplementedException()
                    }
                    : edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.Y => WhiteFaceXAxis.EdgeTopLayer.EdgeFrontRight.YFacesSameColor,
                        FaceAxis.X => WhiteFaceXAxis.EdgeTopLayer.EdgeFrontRight.YFacesDifferentColor,

                        _ => throw new NotImplementedException()
                    },
                PieceLocation.FrontLeft => (firstColor == CubeColor.Green || firstColor == CubeColor.Blue)
                    ? edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.Y => WhiteFaceXAxis.EdgeTopLayer.EdgeFrontLeft.YFacesDifferentColor,
                        FaceAxis.Z => WhiteFaceXAxis.EdgeTopLayer.EdgeFrontLeft.YFacesSameColor,

                        _ => throw new NotImplementedException()
                    }
                    : edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.Y => WhiteFaceXAxis.EdgeTopLayer.EdgeFrontLeft.YFacesSameColor,
                        FaceAxis.Z => WhiteFaceXAxis.EdgeTopLayer.EdgeFrontLeft.YFacesDifferentColor,

                        _ => throw new NotImplementedException()
                    },
                PieceLocation.BackRight => (firstColor == CubeColor.Green || firstColor == CubeColor.Blue)
                    ? edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.Y => WhiteFaceXAxis.EdgeTopLayer.EdgeBackRight.YFacesDifferentColor,
                        FaceAxis.Z => WhiteFaceXAxis.EdgeTopLayer.EdgeBackRight.YFacesSameColor,

                        _ => throw new NotImplementedException()
                    }
                    : edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.Y => WhiteFaceXAxis.EdgeTopLayer.EdgeBackRight.YFacesSameColor,
                        FaceAxis.Z => WhiteFaceXAxis.EdgeTopLayer.EdgeBackRight.YFacesDifferentColor,

                        _ => throw new NotImplementedException()
                    },
                PieceLocation.BackLeft => (firstColor == CubeColor.Green || firstColor == CubeColor.Blue)
                    ? edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.Y => WhiteFaceXAxis.EdgeTopLayer.EdgeBackLeft.YFacesDifferentColor,
                        FaceAxis.X => WhiteFaceXAxis.EdgeTopLayer.EdgeBackLeft.YFacesSameColor,

                        _ => throw new NotImplementedException()
                    }
                    : edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.Y => WhiteFaceXAxis.EdgeTopLayer.EdgeBackLeft.YFacesSameColor,
                        FaceAxis.X => WhiteFaceXAxis.EdgeTopLayer.EdgeBackLeft.YFacesDifferentColor,

                        _ => throw new NotImplementedException()
                    },

                _ => throw new NotImplementedException()
            }
            : edgePosition.Location switch
            {
                PieceLocation.FrontRight => (firstColor == CubeColor.Green || firstColor == CubeColor.Blue)
                    ? edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.X => WhiteFaceXAxis.EdgeMiddleLayer.EdgeFrontRight.YXFaceDifferentColor,
                        FaceAxis.Z => WhiteFaceXAxis.EdgeMiddleLayer.EdgeFrontRight.YXFaceSameColor,

                        _ => throw new NotImplementedException()
                    }
                    : edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.X => WhiteFaceXAxis.EdgeMiddleLayer.EdgeFrontRight.YXFaceSameColor,
                        FaceAxis.Z => WhiteFaceXAxis.EdgeMiddleLayer.EdgeFrontRight.YXFaceDifferentColor,

                        _ => throw new NotImplementedException()
                    },
                PieceLocation.FrontLeft => (firstColor == CubeColor.Green || firstColor == CubeColor.Blue)
                    ? edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.X => WhiteFaceXAxis.EdgeMiddleLayer.EdgeFrontLeft.YXFaceDifferentColor,
                        FaceAxis.Z => WhiteFaceXAxis.EdgeMiddleLayer.EdgeFrontLeft.YXFaceSameColor,

                        _ => throw new NotImplementedException()
                    }
                    : edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.X => WhiteFaceXAxis.EdgeMiddleLayer.EdgeFrontLeft.YXFaceSameColor,
                        FaceAxis.Z => WhiteFaceXAxis.EdgeMiddleLayer.EdgeFrontLeft.YXFaceDifferentColor,

                        _ => throw new NotImplementedException()
                    },
                PieceLocation.BackRight => (firstColor == CubeColor.Green || firstColor == CubeColor.Blue)
                    ? edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.X => WhiteFaceXAxis.EdgeMiddleLayer.EdgeBackRight.YXFaceDifferentColor,
                        FaceAxis.Z => WhiteFaceXAxis.EdgeMiddleLayer.EdgeBackRight.YXFaceSameColor,

                        _ => throw new NotImplementedException()
                    }
                    : edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.X => WhiteFaceXAxis.EdgeMiddleLayer.EdgeBackRight.YXFaceSameColor,
                        FaceAxis.Z => WhiteFaceXAxis.EdgeMiddleLayer.EdgeBackRight.YXFaceDifferentColor,

                        _ => throw new NotImplementedException()
                    },
                PieceLocation.BackLeft => (firstColor == CubeColor.Green || firstColor == CubeColor.Blue)
                    ? edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.X => WhiteFaceXAxis.EdgeMiddleLayer.EdgeBackLeft.YXFaceDifferentColor,
                        FaceAxis.Z => WhiteFaceXAxis.EdgeMiddleLayer.EdgeBackLeft.YXFaceSameColor,

                        _ => throw new NotImplementedException()
                    }
                    : edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.X => WhiteFaceXAxis.EdgeMiddleLayer.EdgeBackLeft.YXFaceSameColor,
                        FaceAxis.Z => WhiteFaceXAxis.EdgeMiddleLayer.EdgeBackLeft.YXFaceDifferentColor,

                        _ => throw new NotImplementedException()
                    },

                _ => throw new NotImplementedException()
            };
    }

    private static List<CubeMove> RecognizeWhieFaceYAxisCase(WhiteCornerPosition cornerPosition, NonYellowEdgePosition edgePosition, CubeColor firstColor)
    {
        return edgePosition.IsOnTop
            ? edgePosition.Location switch
            {
                PieceLocation.FrontRight => (firstColor == CubeColor.Green || firstColor == CubeColor.Blue)
                    ? edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.Y => WhiteFaceYAxis.EdgeTopLayer.EdgeFrontRight.ZYFaceDifferentColor,
                        FaceAxis.X => WhiteFaceYAxis.EdgeTopLayer.EdgeFrontRight.ZYFaceSameColor,

                        _ => throw new NotImplementedException()
                    }
                    : edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.Y => WhiteFaceYAxis.EdgeTopLayer.EdgeFrontRight.ZYFaceSameColor,
                        FaceAxis.X => WhiteFaceYAxis.EdgeTopLayer.EdgeFrontRight.ZYFaceDifferentColor,

                        _ => throw new NotImplementedException()
                    },
                PieceLocation.FrontLeft => (firstColor == CubeColor.Green || firstColor == CubeColor.Blue)
                    ? edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.Y => WhiteFaceYAxis.EdgeTopLayer.EdgeFrontLeft.ZYFaceDifferentColor,
                        FaceAxis.Z => WhiteFaceYAxis.EdgeTopLayer.EdgeFrontLeft.ZYFaceSameColor,

                        _ => throw new NotImplementedException()
                    }
                    : edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.Y => WhiteFaceYAxis.EdgeTopLayer.EdgeFrontLeft.ZYFaceSameColor,
                        FaceAxis.Z => WhiteFaceYAxis.EdgeTopLayer.EdgeFrontLeft.ZYFaceDifferentColor,

                        _ => throw new NotImplementedException()
                    },
                PieceLocation.BackRight => (firstColor == CubeColor.Green || firstColor == CubeColor.Blue)
                    ? edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.Y => WhiteFaceYAxis.EdgeTopLayer.EdgeBackRight.ZYFaceDifferentColor,
                        FaceAxis.Z => WhiteFaceYAxis.EdgeTopLayer.EdgeBackRight.ZYFaceSameColor,

                        _ => throw new NotImplementedException()
                    }
                    : edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.Y => WhiteFaceYAxis.EdgeTopLayer.EdgeBackRight.ZYFaceSameColor,
                        FaceAxis.Z => WhiteFaceYAxis.EdgeTopLayer.EdgeBackRight.ZYFaceDifferentColor,

                        _ => throw new NotImplementedException()
                    },
                PieceLocation.BackLeft => (firstColor == CubeColor.Green || firstColor == CubeColor.Blue)
                    ? edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.Y => WhiteFaceYAxis.EdgeTopLayer.EdgeBackLeft.ZYFaceDifferentColor,
                        FaceAxis.X => WhiteFaceYAxis.EdgeTopLayer.EdgeBackLeft.ZYFaceSameColor,

                        _ => throw new NotImplementedException()
                    }
                    : edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.Y => WhiteFaceYAxis.EdgeTopLayer.EdgeBackLeft.ZYFaceSameColor,
                        FaceAxis.X => WhiteFaceYAxis.EdgeTopLayer.EdgeBackLeft.ZYFaceDifferentColor,

                        _ => throw new NotImplementedException()
                    },

                _ => throw new NotImplementedException()
            }
            : edgePosition.Location switch
            {
                PieceLocation.FrontRight => (firstColor == CubeColor.Green || firstColor == CubeColor.Blue)
                    ? edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.X => WhiteFaceYAxis.EdgeMiddleLayer.EdgeFrontRight.ZFacesSameColor,
                        FaceAxis.Z => WhiteFaceYAxis.EdgeMiddleLayer.EdgeFrontRight.ZFacesDifferentColor,

                        _ => throw new NotImplementedException()
                    }
                    : edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.X => WhiteFaceYAxis.EdgeMiddleLayer.EdgeFrontRight.ZFacesDifferentColor,
                        FaceAxis.Z => WhiteFaceYAxis.EdgeMiddleLayer.EdgeFrontRight.ZFacesSameColor,

                        _ => throw new NotImplementedException()
                    },
                PieceLocation.FrontLeft => (firstColor == CubeColor.Green || firstColor == CubeColor.Blue)
                    ? edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.X => WhiteFaceYAxis.EdgeMiddleLayer.EdgeFrontLeft.ZFacesSameColor,
                        FaceAxis.Z => WhiteFaceYAxis.EdgeMiddleLayer.EdgeFrontLeft.ZFacesDifferentColor,

                        _ => throw new NotImplementedException()
                    }
                    : edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.X => WhiteFaceYAxis.EdgeMiddleLayer.EdgeFrontLeft.ZFacesDifferentColor,
                        FaceAxis.Z => WhiteFaceYAxis.EdgeMiddleLayer.EdgeFrontLeft.ZFacesSameColor,

                        _ => throw new NotImplementedException()
                    },
                PieceLocation.BackRight => (firstColor == CubeColor.Green || firstColor == CubeColor.Blue)
                    ? edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.X => WhiteFaceYAxis.EdgeMiddleLayer.EdgeBackRight.ZFacesSameColor,
                        FaceAxis.Z => WhiteFaceYAxis.EdgeMiddleLayer.EdgeBackRight.ZFacesDifferentColor,

                        _ => throw new NotImplementedException()
                    }
                    : edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.X => WhiteFaceYAxis.EdgeMiddleLayer.EdgeBackRight.ZFacesDifferentColor,
                        FaceAxis.Z => WhiteFaceYAxis.EdgeMiddleLayer.EdgeBackRight.ZFacesSameColor,

                        _ => throw new NotImplementedException()
                    },
                PieceLocation.BackLeft => (firstColor == CubeColor.Green || firstColor == CubeColor.Blue)
                    ? edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.X => WhiteFaceYAxis.EdgeMiddleLayer.EdgeBackLeft.ZFacesSameColor,
                        FaceAxis.Z => WhiteFaceYAxis.EdgeMiddleLayer.EdgeBackLeft.ZFacesDifferentColor,

                        _ => throw new NotImplementedException()
                    }
                    : edgePosition.PrimaryColorFaceAxis switch
                    {
                        FaceAxis.X => WhiteFaceYAxis.EdgeMiddleLayer.EdgeBackLeft.ZFacesDifferentColor,
                        FaceAxis.Z => WhiteFaceYAxis.EdgeMiddleLayer.EdgeBackLeft.ZFacesSameColor,

                        _ => throw new NotImplementedException()
                    },

                _ => throw new NotImplementedException()
            };
    }
}
