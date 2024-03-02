using HumanCapitalManagement.Models.Pagination;

namespace HumanCapitalManagement.Business.PaginationProvider;

public static class PaginationProvider
{
    public static PaginationViewModel PaginationHelper(int page, int count, int itemsPerPage)
    {
        return new PaginationViewModel
        {
            CurrentPage = page,
            TotalPages = (int)Math.Ceiling(count / (decimal)itemsPerPage),
        };
    }
}