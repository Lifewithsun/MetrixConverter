using System;

namespace PublicApi;

/// <summary>
/// Base class used by API responses
/// </summary>
public abstract class BaseResponse : BaseMessage
{
    public BaseResponse(Guid correlationId) : base()
    {
        base._correlationId = correlationId;
    }

    public BaseResponse()
    {
    }
    //  Result Code : 0 -> Success , 1-> Failure  
    public byte ResultCode { get; set; } = 0;
    public TypeOfResult ResultType { get; set; } = TypeOfResult.Success;

    public string ResultDesc { get; set; } = "Success";
}
public enum TypeOfResult
{
    Success = 0,
    Failed,
    Warning,
    Info,
    Error
}