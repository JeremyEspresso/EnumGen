using Xunit;

namespace EnumGen.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Level.High.MemberString();
        }
    }

    [EnumGen]
    public enum Level
    {
        Low,
        Medium,
        High
    }
}