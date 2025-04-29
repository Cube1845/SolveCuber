using SolveCuber.CubeModel.Models;
using SolveCuber.Scramble;

namespace SolveCuber.UnitTests.HelperClass;

public class ScramblerTests
{
    [Fact]
    public void ScrambleCube_ShouldScrambleCubeWith25Moves()
    {
        Cube cube = new();

        var scramble = Scrambler.ScrambleCube(cube);

        scramble.Count.ShouldBe(25);
    }

    [Fact]
    public void GenerateScramble_ShouldGenerateCorrectLength()
    {
        const int scrambleLength = 10;

        var scramble = Scrambler.GenerateScramble(scrambleLength);

        scramble.Count.ShouldBe(scrambleLength);
    }

    [Fact]
    public void GenerateScramble_ShouldNotHaveSameFaceConsecutive()
    {
        var scramble = Scrambler.GenerateScramble(50);

        for (int i = 1; i < scramble.Count; i++)
        {
            var prevFace = scramble[i - 1].ToString().TrimEnd('_', '2');
            var currFace = scramble[i].ToString().TrimEnd('_', '2');
            currFace.ShouldNotBe(prevFace);
        }
    }
}
