using System.Text.RegularExpressions;
using Xunit;

namespace BitVenture.Tests
{
    public class RegexTest
    {

        [Fact]
        public void ShouldMatchRegexStringPattern()
        {
            var stringPattern = "Luke Skywalker";
            var response = "Luke Skywalker";
            var reg = new Regex($@"{stringPattern}");
            Assert.True(reg.Match(response).Success);
        }

        [Fact]
        public void ShouldNotMatchRegexStringPattern()
        {
            var stringPattern = "Luke Skywalker";
            var response = "Lukes Skywalker";
            var reg = new Regex($@"{stringPattern}");
            Assert.False(reg.Match(response).Success);
        }

        [Fact]
        public void ShouldMatchRegexNumberPattern()
        {
            var stringPattern = "\\d";
            var response = "177";
            var reg = new Regex($@"{stringPattern}");
            Assert.True(reg.Match(response).Success);
        }

        [Fact]
        public void ShouldNotMatchRegexNumberPattern()
        {
            var stringPattern = "\\d";
            var response = "Luke Skywalker";
            var reg = new Regex($@"{stringPattern}");
            Assert.False(reg.Match(response).Success);
        }

    }
}
