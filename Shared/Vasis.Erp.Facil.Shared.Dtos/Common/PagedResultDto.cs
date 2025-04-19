namespace Vasis.Erp.Facil.Shared.Dtos.Common
{
    public class PagedResultDto<T>
    {
        public IReadOnlyList<T>? Items { get; set; }
        public int TotalCount { get; set; }
    }

}
