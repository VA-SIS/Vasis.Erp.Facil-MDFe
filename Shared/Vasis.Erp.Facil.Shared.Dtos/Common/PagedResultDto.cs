namespace Vasis.Erp.Facil.Application.Dtos.Shared
{
    public class PagedResultDto<T>
    {
        public List<T> Items { get; set; } = new();
        public int TotalCount { get; set; }
    }
}
