using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;

namespace ConstructionLine.CodingChallenge.Tests
{
    public class SearchEngineTestsBase
    {
        protected Fixture Fixture;
        protected List<Shirt> Shirts = new List<Shirt>();
        protected SearchEngine ClassUnderTest => new SearchEngine(Shirts);


        [SetUp]
        public void BaseSetup()
        {
            Fixture = new Fixture();
            Fixture.Customizations.Add(new ElementsBuilder<Size>(Size.All));
            Fixture.Customizations.Add(new ElementsBuilder<Color>(Color.All));
        }

        protected void AssertColorCounts(SearchOptions searchOptions,
            List<ColorCount> resultsColorCounts)
        {
            var matchingShirts = GetMatchingShirts(searchOptions);
            var evaluatedColorCount = Color.All.Select(color => new ColorCount
                {Color = color, Count = matchingShirts.Count(shirt => shirt.Color.Id == color.Id)});
            resultsColorCounts.Should().BeEquivalentTo(evaluatedColorCount);
            resultsColorCounts.Sum(x => x.Count).Should().Be(matchingShirts.Count);
        }

        protected void AssertSizeCounts(SearchOptions searchOptions,
            List<SizeCount> resultsSizeCounts)
        {
            var matchingShirts = GetMatchingShirts(searchOptions);
            var evaluatedSizeCount = Size.All.Select(size => new SizeCount
                {Size = size, Count = matchingShirts.Count(shirt => shirt.Size.Id == size.Id)});
            resultsSizeCounts.Should().BeEquivalentTo(evaluatedSizeCount);
            resultsSizeCounts.Sum(x => x.Count).Should().Be(matchingShirts.Count);
        }

        private List<Shirt> GetMatchingShirts(SearchOptions searchOptions)
        {
            return Shirts
                .Where(shirt =>
                    !searchOptions.Sizes.Any() || searchOptions.Sizes.Select(size => size.Id).Contains(shirt.Size.Id))
                .Where(shirt =>
                    !searchOptions.Colors.Any() ||
                    searchOptions.Colors.Select(color => color.Id).Contains(shirt.Color.Id)).ToList();
        }

        protected void AssertResults(SearchOptions searchOptions, List<Shirt> resultsShirts)
        {
            var matchingShirts = GetMatchingShirts(searchOptions);
            matchingShirts.Should().BeEquivalentTo(resultsShirts);
        }
    }
}