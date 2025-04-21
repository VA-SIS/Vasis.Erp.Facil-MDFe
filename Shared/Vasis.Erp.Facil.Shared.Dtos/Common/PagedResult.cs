namespace Vasis.Erp.Facil.Shared.Dtos.Common;

public class PagedResult<T>
{
    public List<T> Items { get; set; } = new();
    public int TotalCount { get; set; }
}
