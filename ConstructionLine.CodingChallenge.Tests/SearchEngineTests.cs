using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;

namespace ConstructionLine.CodingChallenge.Tests
{
    [TestFixture]
    public class SearchEngineTests : SearchEngineTestsBase
    {
        [SetUp]
        public void SetUp()
        {
            Shirts = Fixture.CreateMany<Shirt>().ToList();
        }

        [Test]
        public void Search_WithColorAndSizeSearchOptions_ColorCountsAreCorrect()
        {
            // arrange
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
        public void Search_WithNonMatchingScenario_ResultsAreCorrect()
        {
            // arrange
            Shirts = new List<Shirt>
            {
                Fixture.Build<Shirt>().With(x => x.Size, Size.Large).With(x => x.Color, Color.Red).Create(),
                Fixture.Build<Shirt>().With(x => x.Size, Size.Medium).With(x => x.Color, Color.Blue).Create()
            };
            var searchOptions = new SearchOptions
            {
                Sizes = new List<Size> {Size.Small},
                Colors = new List<Color> {Color.Black}
            };
            // act
            var results = ClassUnderTest.Search(searchOptions);
            // assert
            results.Shirts.Should().BeEmpty();
        }

        [Test]
        public void Search_WithNoSearchOption_ColorCountsAreCorrect()
        {
            // arrange
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
            var searchOptions = new SearchOptions();
            // act
            var results = ClassUnderTest.Search(searchOptions);
            // assert
            AssertSizeCounts(searchOptions, results.SizeCounts);
        }

        [Test]
        public void Search_WithOneMatching_MapsShirtId()
        {
            // arrange
            var matchingShirt = Fixture.Build<Shirt>().With(x => x.Size, Size.Small).With(x => x.Color, Color.Black)
                .Create();
            Shirts = new List<Shirt>
            {
                Fixture.Build<Shirt>().With(x => x.Size, Size.Large).With(x => x.Color, Color.Red).Create(),
                matchingShirt,
                Fixture.Build<Shirt>().With(x => x.Size, Size.Medium).With(x => x.Color, Color.Blue).Create()
            };
            var searchOptions = new SearchOptions
            {
                Sizes = new List<Size> {Size.Small},
                Colors = new List<Color> {Color.Black}
            };
            // act
            var results = ClassUnderTest.Search(searchOptions);
            // assert
            results.Shirts.Should().HaveCount(1);
            results.Shirts.Single().Id.Should().Be(matchingShirt.Id);
        }

        [Test]
        public void Search_WithOneMatching_MapsShirtName()
        {
            // arrange
            var matchingShirt = Fixture.Build<Shirt>().With(x => x.Size, Size.Small).With(x => x.Color, Color.Black)
                .Create();
            Shirts = new List<Shirt>
            {
                Fixture.Build<Shirt>().With(x => x.Size, Size.Large).With(x => x.Color, Color.Red).Create(),
                matchingShirt,
                Fixture.Build<Shirt>().With(x => x.Size, Size.Medium).With(x => x.Color, Color.Blue).Create()
            };
            var searchOptions = new SearchOptions
            {
                Sizes = new List<Size> {Size.Small},
                Colors = new List<Color> {Color.Black}
            };
            // act
            var results = ClassUnderTest.Search(searchOptions);
            // assert
            results.Shirts.Should().HaveCount(1);
            results.Shirts.Single().Name.Should().BeSameAs(matchingShirt.Name).And.NotBeNullOrWhiteSpace();
        }

        [Test]
        public void Search_WithOneMatching_ResultsAreCorrect()
        {
            // arrange
            var matchingShirt = Fixture.Build<Shirt>().With(x => x.Size, Size.Small).With(x => x.Color, Color.Black)
                .Create();
            Shirts = new List<Shirt>
            {
                Fixture.Build<Shirt>().With(x => x.Size, Size.Large).With(x => x.Color, Color.Red).Create(),
                matchingShirt,
                Fixture.Build<Shirt>().With(x => x.Size, Size.Medium).With(x => x.Color, Color.Blue).Create()
            };
            var searchOptions = new SearchOptions
            {
                Sizes = new List<Size> {Size.Small},
                Colors = new List<Color> {Color.Black}
            };
            // act
            var results = ClassUnderTest.Search(searchOptions);
            // assert
            results.Shirts.Should().HaveCount(1);
            results.Shirts.Should().BeEquivalentTo(new List<Shirt> {matchingShirt});
        }

        [Test]
        public void Search_WithSearchOptionForAllSizesAndColors_ColorCountsAreCorrect()
        {
            // arrange
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