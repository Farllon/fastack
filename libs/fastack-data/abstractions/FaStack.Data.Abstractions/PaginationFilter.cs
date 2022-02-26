namespace FaStack.Data.Abstractions
{
    public class PaginationFilter
    {
        public int PageIndex { get; }

        public int PageSize { get; }

        public PaginationFilter(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}