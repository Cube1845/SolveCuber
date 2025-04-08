using SolveCuber.CubeModel;
using SolveCuber.Solver.Common;

namespace SolveCuber.Solver.OLL;

internal record OLL(FaceAxis[,] Case, List<CubeMove> Algorithm);
