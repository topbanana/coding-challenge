using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using NUnit.Framework;

namespace ConstructionLine.CodingChallenge.Tests
{
    [TestFixture]
    public class SearchEngineTests : SearchEngineTestsBase
    {
        private SearchEngine ClassUnderTest => new SearchEngine(Shirts);


        [Test]
        public void Search_WithColorAndSizeSearchOptions_ColorCountsAreCorrect()
        {
            // arrange
            Shirts = Fixture.CreateMany<Shirt>().ToList();
            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> {Color.Red},
                Sizes = new List<Size> {Size.Small}
            };
            // act
            var results = ClassUnderTest.Search(searchOptions);
            // assert
            AssertColorCounts(searchOptions, results.ColorCounts);
        }


        [Test]
        public void Search_WithColorAndSizeSearchOptions_ResultsAreCorrect()
        {
            // arrange
            Shirts = Fixture.CreateMany<Shirt>().ToList();
            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> {Color.Red},
                Sizes = new List<Size> {Size.Small}
            };
            // act
            var results = ClassUnderTest.Search(searchOptions);
            // assert
            AssertResults(searchOptions, results.Shirts);
        }

        [Test]
        public void Search_WithColorAndSizeSearchOptions_SizeCountsAreCorrect()
        {
            // arrange
            Shirts = Fixture.CreateMany<Shirt>().ToList();
            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> {Color.Red},
                Sizes = new List<Size> {Size.Small}
            };
            // act
            var results = ClassUnderTest.Search(searchOptions);
            // assert
            AssertSizeCounts(searchOptions, results.SizeCounts);
        }

        [Test]
        public void Search_WithColorSearchOption_ColorCountsAreCorrect()
        {
            // arrange
            Shirts = Fixture.CreateMany<Shirt>().ToList();
            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> {Color.Red}
            };
            // act
            var results = ClassUnderTest.Search(searchOptions);
            // assert
            AssertColorCounts(searchOptions, results.ColorCounts);
        }

        [Test]
        public void Search_WithColorSearchOption_ResultsAreCorrect()
        {
            // arrange
            Shirts = Fixture.CreateMany<Shirt>().ToList();
            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> {Color.Red}
            };
            // act
            var results = ClassUnderTest.Search(searchOptions);
            // assert
            AssertResults(searchOptions, results.Shirts);
        }

        [Test]
        public void Search_WithColorSearchOption_SizeCountsAreCorrect()
        {
            // arrange
            Shirts = Fixture.CreateMany<Shirt>().ToList();
            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> {Color.Red}
            };
            // act
            var results = ClassUnderTest.Search(searchOptions);
            // assert
            AssertSizeCounts(searchOptions, results.SizeCounts);
        }


        [Test]
        public void Search_WithNoSearchOption_ColorCountsAreCorrect()
        {
            // arrange
            Shirts = Fixture.CreateMany<Shirt>().ToList();
            var searchOptions = new SearchOptions();
            // act
            var results = ClassUnderTest.Search(searchOptions);
            // assert
            AssertColorCounts(searchOptions, results.ColorCounts);
        }


        [Test]
        public void Search_WithNoSearchOption_ResultsAreCorrect()
        {
            // arrange
            Shirts = Fixture.CreateMany<Shirt>().ToList();
            var searchOptions = new SearchOptions();
            // act
            var results = ClassUnderTest.Search(searchOptions);
            // assert
            AssertResults(searchOptions, results.Shirts);
        }

        [Test]
        public void Search_WithNoSearchOption_SizeCountsAreCorrect()
        {
            // arrange
            Shirts = Fixture.CreateMany<Shirt>().ToList();
            var searchOptions = new SearchOptions();
            // act
            var results = ClassUnderTest.Search(searchOptions);
            // assert
            AssertSizeCounts(searchOptions, results.SizeCounts);
        }

        [Test]
        public void Search_WithSearchOptionForAllSizesAndColors_ColorCountsAreCorrect()
        {
            // arrange
            Shirts = Fixture.CreateMany<Shirt>().ToList();
            var searchOptions = new SearchOptions
            {
                Sizes = Size.All,
                Colors = Color.All
            };
            // act
            var results = ClassUnderTest.Search(searchOptions);
            // assert
            AssertColorCounts(searchOptions, results.ColorCounts);
        }


        [Test]
        public void Search_WithSearchOptionForAllSizesAndColors_ResultsAreCorrect()
        {
            // arrange
            Shirts = Fixture.CreateMany<Shirt>().ToList();
            var searchOptions = new SearchOptions
            {
                Sizes = Size.All,
                Colors = Color.All
            };
            // act
            var results = ClassUnderTest.Search(searchOptions);
            // assert
            AssertResults(searchOptions, results.Shirts);
        }

        [Test]
        public void Search_WithSearchOptionForAllSizesAndColors_SizeCountsAreCorrect()
        {
            // arrange
            Shirts = Fixture.CreateMany<Shirt>().ToList();
            var searchOptions = new SearchOptions
            {
                Sizes = Size.All,
                Colors = Color.All
            };
            // act
            var results = ClassUnderTest.Search(searchOptions);
            // assert
            AssertSizeCounts(searchOptions, results.SizeCounts);
        }

        [Test]
        public void Search_WithSizeSearchOption_ResultsAreCorrect()
        {
            // arrange
            Shirts = Fixture.CreateMany<Shirt>().ToList();
            var searchOptions = new SearchOptions
            {
                Sizes = new List<Size> {Size.Small}
            };
            // act
            var results = ClassUnderTest.Search(searchOptions);
            // assert
            AssertResults(searchOptions, results.Shirts);
        }

        [Test]
        public void Search_WithSizeSearchOption_SizeCountsAreCorrect()
        {
            // arrange
            Shirts = Fixture.CreateMany<Shirt>().ToList();
            var searchOptions = new SearchOptions
            {
                Sizes = new List<Size> {Size.Small}
            };
            // act
            var results = ClassUnderTest.Search(searchOptions);
            // assert
            AssertSizeCounts(searchOptions, results.SizeCounts);
        }
    }
}