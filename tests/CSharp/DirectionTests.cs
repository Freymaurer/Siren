using Siren.Sea;
using Xunit;

namespace CSharp
{
    public class Direction
    {
        [Fact]
        public void DirectionAccessSuccessful()
        {
            var actual = direction.topDown == direction.td;
            Assert.True(actual);
        }
    }
}