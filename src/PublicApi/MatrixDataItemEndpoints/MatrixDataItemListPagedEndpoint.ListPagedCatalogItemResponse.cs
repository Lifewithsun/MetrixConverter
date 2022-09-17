using PublicApi.MatrixDataItemEndpoints;
using System;
using System.Collections.Generic;

namespace PublicApi.MatrixDataItemEndpoints;

public class ListPagedMatrixDataItemResponse : BaseResponse
{
    public ListPagedMatrixDataItemResponse(Guid correlationId) : base(correlationId)
    {
    }

    public ListPagedMatrixDataItemResponse()
    {
    }

    public string outValue { get; set; }
  
}
