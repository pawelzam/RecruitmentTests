using Moq;
using NewDay.DiamondKata;

namespace DiamondKata.Tests;
public class DiamondTest
{
    [Test]
    public void Print_PrintsDiamond()
    {
        // Arrange
        var diamond = new Diamond([]);
        var printer = new Mock<IDiamondPrinter>();

        // Act
        diamond.Print(printer.Object);

        // Assert
        printer.Verify(p => p.Print(diamond), Times.Once);
    }
}
