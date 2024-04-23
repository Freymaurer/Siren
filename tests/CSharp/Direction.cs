using Siren;
using Siren.Sea;
using Xunit;

namespace CSharp
{
    public class Direction
    {
        [Fact]
        public void NameAliasWorking()
        {
            var actual = direction.topDown == direction.td;
            Assert.True(actual);
        }
    }
}