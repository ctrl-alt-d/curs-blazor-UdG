using LibTaller;
using Moq;
using System;
using Xunit;

namespace MyTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestCotxe()
        {
            // arrange
            var intermitentE = new Mock<IIntermitent>();
            var intermitentD = new Mock<IIntermitent>();

            // act
            var cotxe = new Cotxe(intermitentD.Object, intermitentE.Object);
            cotxe.Activa4Intermitents();

            // assert
            intermitentE.Verify(x => x.Activar(), Times.Once);
            intermitentD.Verify(x => x.Activar(), Times.Once);

        }
    }
}
