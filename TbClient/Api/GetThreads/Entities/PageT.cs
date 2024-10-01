namespace TbClient.Api.GetThreads.Entities;

public class PageT
{
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPage { get; set; }
    public int TotalCount { get; set; }
    public bool HasMore { get; set; } = false;
    public bool HasPrevious { get; set; } = false;

    public static PageT FromTbData(Page page)
    {
        return new PageT()
        {
            PageSize = page.PageSize,
            CurrentPage = page.CurrentPage,
            TotalPage = page.TotalPage,
            TotalCount = page.TotalCount,
            HasMore = page.HasMore == 1,
            HasPrevious = page.HasPrev == 1
        };
    }

    public override string ToString()
    {
        return
            $"{nameof(PageSize)}: {PageSize}, {nameof(CurrentPage)}: {CurrentPage}, {nameof(TotalPage)}: {TotalPage}, {nameof(TotalCount)}: {TotalCount}, {nameof(HasMore)}: {HasMore}, {nameof(HasPrevious)}: {HasPrevious}";
    }
}