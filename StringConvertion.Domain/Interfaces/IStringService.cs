using System.Collections.Generic;
using StringConvertion.Domain.Enums;
using StringConvertion.Model;

namespace StringConvertion.Domain.Interfaces
{
    public interface IStringService
    {
        List<string> GetSortedText(string text, SortType sortType);

        TextStatistics GetTextStatistics(string text);
    }
}
