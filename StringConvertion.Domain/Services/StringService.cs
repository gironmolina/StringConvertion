using System.Collections.Generic;
using System.Linq;
using StringConvertion.Domain.Enums;
using StringConvertion.Domain.Interfaces;
using StringConvertion.Model;

namespace StringConvertion.Domain.Services
{
    public class StringService : IStringService
    {
        private const char Hyphens = '-';
        private const char Spaces = ' ';

        public List<string> GetSortedText(string text, SortType sortType)
        {
            var texts = text.Split().ToList();
            var sortedText = new List<string>();

            switch (sortType)
            {
                case SortType.AlphabeticAsc:
                    sortedText = GetAlphabeticAscSort(texts);
                    break;

                case SortType.AlphabeticDesc:
                    sortedText = GetAlphabeticDescSort(texts);
                    break;

                case SortType.LengthAsc:
                    sortedText = GetLengthAscSort(texts);
                    break;
            }

            return sortedText;
        }

        public TextStatistics GetTextStatistics(string text)
        {
            var hyphensQuantity = text.Count(character => character == Hyphens);
            var wordQuantity = text.Split().Length;
            var spacesQuantity = text.Count(character => character == Spaces);

            return new TextStatistics
            {
                HyphensQuantity = hyphensQuantity,
                WordsQuantity = wordQuantity,
                SpacesQuantity = spacesQuantity
            };
        }

        private List<string> GetAlphabeticAscSort(IEnumerable<string> texts)
        {
            var alphabeticAscSort = texts.OrderBy(txt => txt).ToList();
            return alphabeticAscSort;
        }

        private List<string> GetAlphabeticDescSort(IEnumerable<string> texts)
        {
            var alphabeticDescSort = texts.OrderByDescending(txt => txt).ToList();
            return alphabeticDescSort;
        }

        private List<string> GetLengthAscSort(IEnumerable<string> texts)
        {
            var lengthAscSort = texts.OrderBy(txt => txt.Length).ToList();
            return lengthAscSort;
        }
    }
}
