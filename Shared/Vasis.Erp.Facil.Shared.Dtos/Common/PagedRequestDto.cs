namespace Vasis.Erp.Facil.Shared.Dtos.Common
{
    public class PagedRequestDto<T>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SortBy { get; set; }
        public bool SortDescending { get; set; }
        public T? Filter { get; set; } = default!;
    }

}
