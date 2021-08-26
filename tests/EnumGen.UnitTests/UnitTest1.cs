using Xunit;

namespace EnumGen.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Level.High.MemberString();
            Testing.Enum.MemberString();
        }
    }

    [EnumGen]
    public enum Level
    {
        Low,
        Medium,
        High
    }

    [EnumGen]
    public enum Testing
	{
        Low,
        Medium,
        High,
        Swag,
        Test,
        Lol,
        Ok,
        Cry,
        To,
        Sleep,
        F,
        Kek,
        Super,
        Long,
        Enum
    }
}