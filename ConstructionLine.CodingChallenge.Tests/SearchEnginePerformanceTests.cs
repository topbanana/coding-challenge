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
        public void PerformanceTest_WithColorSearchOptions_ExecutesWithinTime()
        {
            // arrange
            var searchOptions = new SearchOptions
            {
                Colors = Fixture.CreateMany<Color>().ToList()
            };
            // act
            Action act = () => ClassUnderTest.Search(searchOptions);
            // assert
            act.ExecutionTime().Should().BeLessOrEqualTo(TimeSpan.FromMilliseconds(100));
        }


        [Test]
        public void PerformanceTest_WithColorSearchOptions_ResultsAreCorrect()
        {
            // arrange
            var searchOptions = new SearchOptions
            {
                Colors = Fixture.CreateMany<Color>().ToList()
            };
            // act
            var results = ClassUnderTest.Search(searchOptions);
            // assert
            AssertResults(searchOptions, results.Shirts);
            AssertColorCounts(searchOptions, results.ColorCounts);
            AssertSizeCounts(searchOptions, results.SizeCounts);
        }

        [Test]
        public void PerformanceTest_WithSizeAndColorSearchOptions_ExecutesWithinTime()
        {
            // arrange
            var searchOptions = new SearchOptions
            {
                Colors = Fixture.CreateMany<Color>().ToList(),
                Sizes = Fixture.CreateMany<Size>().ToList()
            };
            // act
            Action act = () => ClassUnderTest.Search(searchOptions);
            // assert
            act.ExecutionTime().Should().BeLessOrEqualTo(TimeSpan.FromMilliseconds(100));
        }

        [Test]
        public void PerformanceTest_WithSizeAndColorSearchOptions_ResultsAreCorrect()
        {
            // arrange
            var searchOptions = new SearchOptions
            {
                Colors = Fixture.CreateMany<Color>().ToList(),
                Sizes = Fixture.CreateMany<Size>().ToList()
            };
            // act
            var results = ClassUnderTest.Search(searchOptions);
            // assert
            AssertResults(searchOptions, results.Shirts);
            AssertColorCounts(searchOptions, results.ColorCounts);
            AssertSizeCounts(searchOptions, results.SizeCounts);
        }

        [Test]
        public void PerformanceTest_WithSizeSearchOptions_ExecutesWithinTime()
        {
            // arrange
            var searchOptions = new SearchOptions
            {
                Sizes = Fixture.CreateMany<Size>().ToList()
            };
            // act
            Action act = () => ClassUnderTest.Search(searchOptions);
            // assert
            act.ExecutionTime().Should().BeLessOrEqualTo(TimeSpan.FromMilliseconds(100));
        }

        [Test]
        public void PerformanceTest_WithSizeSearchOptions_ResultsAreCorrect()
        {
            // arrange
            var searchOptions = new SearchOptions
            {
                Sizes = Fixture.CreateMany<Size>().ToList()
            };
            // act
            var results = ClassUnderTest.Search(searchOptions);
            // assert
            AssertResults(searchOptions, results.Shirts);
            AssertColorCounts(searchOptions, results.ColorCounts);
            AssertSizeCounts(searchOptions, results.SizeCounts);
        }
    }
}