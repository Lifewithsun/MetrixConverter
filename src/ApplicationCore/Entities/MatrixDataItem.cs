using System;
using Ardalis.GuardClauses;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities;

public class MatrixDataItem :  IAggregateRoot
{
    public int Id { get; private set; }
    public string ConvertFrom { get; private set; }
    public string ConvertTo { get; private set; }
    public string MutliplyBy { get; private set; }
    public bool IsDecimal { get; private set; }

    public MatrixDataItem(
        int id ,
        string convertFrom,
       string convertTo,
       string mutliplyBy,
       bool isDecimal)
    {
        Id = id;
        ConvertFrom = convertFrom;
        ConvertTo = convertTo;
        MutliplyBy = mutliplyBy;
        IsDecimal = isDecimal;       
    }
    public void UpdateDetails(string convertFrom, string convertTo, string mutliplyBy)
    {
        Guard.Against.NullOrEmpty(convertFrom, nameof(convertFrom));
        Guard.Against.NullOrEmpty(convertTo, nameof(convertTo));
        Guard.Against.NullOrEmpty(mutliplyBy, nameof(mutliplyBy));

        ConvertFrom = convertFrom;
        ConvertTo = convertTo;
        MutliplyBy = mutliplyBy;
    }
    
}
