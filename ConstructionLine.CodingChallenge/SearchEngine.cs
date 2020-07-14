using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private readonly List<Shirt> _shirts;

        public SearchEngine(List<Shirt> shirts)
        {
            _shirts = shirts;

            // TODO: data preparation and initialisation of additional data structures to improve performance goes here.
        }


        public SearchResults Search(SearchOptions options)
        {
            var matchingShirts = _shirts.Where(shirt =>
                (options.Colors.Contains(shirt.Color) || !options.Colors.Any()) &&
                (options.Sizes.Contains(shirt.Size) || !options.Sizes.Any()));

            return new SearchResults
            {
                Shirts = matchingShirts.ToList(),
                SizeCounts = Size.All.Select(size => new SizeCount
                    {Size = size, Count = matchingShirts.Count(shirt => shirt.Size.Id == size.Id)}).ToList(),
                ColorCounts = Color.All.Select(color => new ColorCount
                    {Color = color, Count = matchingShirts.Count(shirt => shirt.Color.Id == color.Id)}).ToList()
            };
        }
    }
}