namespace Web_API.Model;
public class ResponseModel<TEntity>
{
    public string Message { get; set; }
    public int ResponseCode { get; set; }
    public IEnumerable<TEntity> Data { get; set; }
    public int TotalCount { get; set; }
}