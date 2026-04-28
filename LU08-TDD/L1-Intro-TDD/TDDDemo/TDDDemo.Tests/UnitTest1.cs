using TDDDemo.App;

namespace TDDDemo.Tests;


public class FeaturesTests
{
    [Fact]
    public void IsEvenBad_ReturnsTrue_ForSimpleEvenInput()
    {
        bool result = Features.IsEvenBad(4);

        Assert.True(result);
    }

    [Theory]
    [InlineData(12, true)]
    [InlineData(13, false)]
    [InlineData(-8, true)]
    public void IsEven_WorksForAnyInteger(int number, bool expected)
    {
        Assert.Equal(expected, Features.IsEven(number));
    }

    [Theory]
    [InlineData("hello world", 3)]
    [InlineData("AEIOU", 5)]
    [InlineData("bcdfg", 0)]
    public void CountVowelsBad_CountsLowercaseVowels(string input, int expected)
    {
        int result = TDDDemo.App.Features.CountVowelsBad(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void CountVowels_HandlesUpperAndLowerCase()
    {
        int result = TDDDemo.App.Features.CountVowels("ApplE");

        Assert.Equal(2, result);
    }

    [Fact]
    public void BuildGreetingBad_ConcatenatesRawInput()
    {
        string result = TDDDemo.App.Features.BuildGreetingBad("  luke  ");

        Assert.Equal("Hello,   luke  !", result);
    }

    [Fact]
    public void BuildGreeting_TrimsInput_AndHandlesBlankNames()
    {
        Assert.Equal("Hello, Luke!", TDDDemo.App.Features.BuildGreeting("  Luke  "));
        Assert.Equal("Hello, friend!", TDDDemo.App.Features.BuildGreeting("   "));
    }

}
