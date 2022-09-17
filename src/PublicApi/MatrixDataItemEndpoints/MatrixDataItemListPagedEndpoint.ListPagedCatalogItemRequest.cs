namespace PublicApi.MatrixDataItemEndpoints;

public class ListPagedMatrixDataItemRequest : BaseRequest
{
    public string ConvertFrom { get; init; }
    public string ConvertTo { get; init; }
    public decimal InputValue { get; init; }
  
    public ListPagedMatrixDataItemRequest(string convertFrom, string convertTo, decimal inputValue)
    {
        ConvertFrom = convertFrom;
        ConvertTo = convertTo;
        InputValue = inputValue;      
    }
}
