namespace Vasis.Erp.Facil.Application.Dtos.Shared
{
    public class PagedRequestDto
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Filter { get; set; }

        public int SkipCount => (PageNumber - 1) * PageSize;
    }
}
