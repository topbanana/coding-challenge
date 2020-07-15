using System;
using System.Linq;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;

namespace ConstructionLine.CodingChallenge.Tests
{
    [TestFixture]
    public class SearchEnginePerformanceTests : SearchEngineTestsBase
    {
        [SetUp]
        public void SetUp()
        {
            Shirts = Fixture.CreateMany<Shirt>(50000).ToList();
        }

        [Test]
        public void PerformanceTest_WithColorSearchOptions_ExecutesCorrectlyWithinTime()
        {
            // arrange
            var searchOptions = new SearchOptions
            {
                Colors = Fixture.CreateMany<Color>().ToList()
            };
            SearchResults results = null;
            // act
            Action act = () => results = ClassUnderTest.Search(searchOptions);
            // assert
            act.ExecutionTimeOf(s => s()).Should().BeLessOrEqualTo(TimeSpan.FromMilliseconds(100));
            AssertResults(searchOptions, results.Shirts);
            AssertColorCounts(searchOptions, results.ColorCounts);
            AssertSizeCounts(searchOptions, results.SizeCounts);
        }
        
        [Test]
        public void PerformanceTest_WithSizeAndColorSearchOptions_ExecutesCorreclyWithinTime()
        {
            // arrange
            var searchOptions = new SearchOptions
            {
                Colors = Fixture.CreateMany<Color>().ToList(),
                Sizes = Fixture.CreateMany<Size>().ToList()
            };
            SearchResults results = null;
            // act
            Action act = () => results = ClassUnderTest.Search(searchOptions);
            // assert
            act.ExecutionTimeOf(s => s()).Should().BeLessOrEqualTo(TimeSpan.FromMilliseconds(100));
            AssertResults(searchOptions, results.Shirts);
            AssertColorCounts(searchOptions, results.ColorCounts);
            AssertSizeCounts(searchOptions, results.SizeCounts);
        }
        
        [Test]
        public void PerformanceTest_WithSizeSearchOptions_ExecutesCorrectlyWithinTime()
        {
            // arrange
            var searchOptions = new SearchOptions
            {
                Sizes = Fixture.CreateMany<Size>().ToList()
            };
            SearchResults results = null;
            // act
            Action act = () => results = ClassUnderTest.Search(searchOptions);
            // assert
            act.ExecutionTimeOf(s => s()).Should().BeLessOrEqualTo(TimeSpan.FromMilliseconds(100));
            AssertResults(searchOptions, results.Shirts);
            AssertColorCounts(searchOptions, results.ColorCounts);
            AssertSizeCounts(searchOptions, results.SizeCounts);
        }
    }
}