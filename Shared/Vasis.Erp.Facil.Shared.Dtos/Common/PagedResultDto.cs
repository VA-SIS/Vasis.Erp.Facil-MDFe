namespace Vasis.Erp.Facil.Application.Dtos.Shared
{
    public class PagedResultDto<T>
    {
        private object items;
        private int total;

        public PagedResultDto(object items, int total)
        {
            this.items = items;
            this.total = total;
        }

        public List<T> Items { get; set; } = new();
        public int TotalCount { get; set; }
    }
}
