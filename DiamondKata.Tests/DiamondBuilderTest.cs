using FluentAssertions;

namespace NewDay.DiamondKata.Tests;

public class DiamondBuilderTest
{

    [TestCase("A")]
    [TestCase("Z")]
    public void Build_ProducesArrayWithCorrectLength(char letter)
    {
        // Arrange
        var sut = new DiamondBuilder();
        var letterPosition = DiamondBuilder.Alphabet.IndexOf(letter) + 1;

        // Act
        var response = sut.Build(letter);

        // Assert
        response.Should().NotBeNull();
        response.Rows.Should().HaveCount((letterPosition * 2) - 1);
    }

    [Test]
    public void GetAllDiamondLetters_ProducesCorrectLettersString()
    {
        // Arrange & Act
        var result = DiamondBuilder.GetAllDiamondLetters('Z');

        // Assert
        result.Should().Be(DiamondBuilder.Alphabet);
    }

    [TestCase('1')]
    [TestCase('(')]
    [TestCase('=')]
    public void GetAllDiamondLetters_ProducesCorrectLettersString1(char unsupportedCharacter)
    {
        // Arrange & Act
        var action = () => DiamondBuilder.GetAllDiamondLetters(unsupportedCharacter);

        // Assert
        action.Should().Throw<NotSupportedException>();
    }

    [TestCase("A")]
    [TestCase("Z")]
    public void Build_ProducesArrayWithCorrectLetters(char letter)
    {
        // Arrange
        var sut = new DiamondBuilder();
        var letterPosition = DiamondBuilder.Alphabet.IndexOf(letter) + 1;
        var letters = DiamondBuilder.GetAllDiamondLetters(letter);

        // Act
        var response = sut.Build(letter);

        // Assert
        response.Should().NotBeNull();
        var allLetters = response.Rows.SelectMany(p => p).Where(p => p != '_').Distinct().ToArray();
        allLetters.Should().BeEquivalentTo(letters);
    }

    [Test]
    public void Build_ProducesCorrectDiamond()
    {
        // Arrange
        var sut = new DiamondBuilder();
        var expected = new string[] {
            "__A__",
            "_B_B_",
            "C___C",
            "_B_B_",
            "__A__",
        };

        // Act
        var actual = sut.Build('C');

        // Assert
        actual.Rows.Should().NotBeNull();
        actual.Rows.Should().BeEquivalentTo(expected);
    }
}
