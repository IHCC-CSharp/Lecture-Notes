namespace TDDDemo.Tests;

public class FeaturesTests
{
    [Fact]
    public void IsEvenBad_ReturnsTrue_ForSimpleEvenInput()
    {
        bool result = TDDDemo.App.Features.IsEvenBad(4);

        Assert.True(result);
    }

    [Fact]
    public void IsEven_WorksForAnyInteger()
    {
        Assert.True(TDDDemo.App.Features.IsEven(12));
        Assert.False(TDDDemo.App.Features.IsEven(13));
        Assert.True(TDDDemo.App.Features.IsEven(-8));
    }

    [Fact]
    public void CountVowelsBad_CountsLowercaseVowels()
    {
        int result = TDDDemo.App.Features.CountVowelsBad("hello world");

        Assert.Equal(3, result);
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
