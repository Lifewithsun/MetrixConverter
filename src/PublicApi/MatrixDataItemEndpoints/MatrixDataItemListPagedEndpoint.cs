using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

using MinimalApi.Endpoint;
using Ardalis.Specification;
using System.Linq.Expressions;
using Flee.PublicTypes;
using IDynamicExpression = Flee.PublicTypes.IDynamicExpression;

namespace PublicApi.MatrixDataItemEndpoints;

/// <summary>
/// List MatrixData Items (paged)
/// </summary>
public class MatrixDataItemListPagedEndpoint : IEndpoint<IResult, ListPagedMatrixDataItemRequest>
{
    private IRepository<MatrixDataItem> _itemRepository;

    private readonly IMapper _mapper;

    public MatrixDataItemListPagedEndpoint( IMapper mapper)
    {      
        _mapper = mapper;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/matrix-items",
            async (string convertFrom, string convertTo, decimal inputValue, IRepository<MatrixDataItem> itemRepository) =>
            {
                _itemRepository = itemRepository;
                return await HandleAsync(new ListPagedMatrixDataItemRequest(convertFrom, convertTo, inputValue));
            })            
            .Produces<ListPagedMatrixDataItemResponse>()
            .WithTags("MatrixDataItemEndpoints");
    }

    public async Task<IResult> HandleAsync(ListPagedMatrixDataItemRequest request)
    {
        var response = new ListPagedMatrixDataItemResponse(request.CorrelationId());
        try
        {



            var matrixDataSpecification = new MatrixDataSpecification(request.ConvertFrom, request.ConvertTo);
            var items = await _itemRepository.ListAsync(matrixDataSpecification);

            if (items != null && items.Count > 0)
            {
                var firstItem = items[0];
                if (firstItem.IsDecimal)
                {
                    response.outValue =Convert.ToString(Convert.ToDecimal(firstItem.MutliplyBy) * request.InputValue);
                }
                else
                {
                    // Define the context of our expression
                    ExpressionContext context = new ExpressionContext();
                    // Allow the expression to use all static public methods of System.Math
                    context.Imports.AddType(typeof(Math));
                    // Define an int variable
                    context.Variables["i"] = request.InputValue;
                    // Create a dynamic expression that evaluates to an Object
                    IDynamicExpression eDynamic = context.CompileDynamic(firstItem.MutliplyBy);
                    // Evaluate the expressions
                    decimal result = (decimal)eDynamic.Evaluate();

                    response.outValue = Convert.ToString(result);

                }
          
                response.ResultCode = 0;
                response.ResultType = TypeOfResult.Info;
            }
            else
            {
                response.outValue = "0";
                response.ResultCode = 1;
                response.ResultType = TypeOfResult.Info;
                response.ResultDesc = "Data is not found.";
            }

            return Results.Ok(response);
        }
        catch (Exception ex) 
        {
            response.ResultCode = 1;
            response.ResultType = TypeOfResult.Error;
            response.ResultDesc = "Something went Wrong";
            return Results.Ok(response);
            throw;
        }
    }
    public class MatrixDataSpecification : Specification<MatrixDataItem>
    {
        public MatrixDataSpecification(string convertFrom, string convertTo)
        {
            Query.Where(c => c.ConvertFrom== convertFrom && c.ConvertTo == convertTo);
        }
    }
}
