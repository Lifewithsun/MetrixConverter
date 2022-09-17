using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data;

public class MatrixDataContextSeed
{
    public static async Task SeedAsync(MatrixDataContext matrixContext,
        ILogger logger,
        int retry = 0)
    {
        var retryForAvailability = retry;
        try
        {
                     

            if (!await matrixContext.MatrixDataItems.AnyAsync())
            {
                await matrixContext.MatrixDataItems.AddRangeAsync(
                    GetPreconfiguredItems());

                await matrixContext.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            if (retryForAvailability >= 10) throw;

            retryForAvailability++;
            
            logger.LogError(ex.Message);
            await SeedAsync(matrixContext, logger, retryForAvailability);
            throw;
        }
    }

   

    static IEnumerable<MatrixDataItem> GetPreconfiguredItems()
    {
        return new List<MatrixDataItem>
            {
                    new(1,"Kilometers", "Miles", "0.62", true),
                  new(2,"Kilometers", "Feet", "3280.8", true),
                  new(3,"Meters", "Feet", "3.28", true),
                  new(4,"Centimeters", "Inches", "0.39", true),
                  new(5,"Millimeters", "Inches", "0.039", true),
                  new(6,"Liters", "Quarts", "1.057", true),
                  new(7,"Liters", "Gallons", "0.264", true),
                  new(8,"Milliliters", "Cups", "0.0042", true),
                  new(9,"Milliliters", "Ounces", "0.0338", true),
                  new(10,"Celsius", "Fahrenheit", "i * 9/5 + 32", false),
                  new(11,"Kilogram", "Tons", "0.0011", true),
                  new(12,"Kilogram", "Pounds", "2.2046", true),
                  new(13,"Grams", "Ounces", "0.035", true),
                  new(14,"Grams", "Pounds", "0.002205", true),
                  new(15,"Milligrams", "Ounces", "0.000035", true),
                  new(16,"Fahrenheit", "Celsius", "(i - 32) * 5/9", false),
                  new(17,"Inches", "Meters", "0.0254", true),
                  new(18,"Inches", "Centimeters", "2.54", true),
                  new(19,"Inches", "Millimeters", "25.4", true),
                  new(20,"Feet", "Meters", "0.3", true),
                  new(21,"Yards", "Meters", "0.91", true),
                  new(22,"Yards", "Kilometers", "0.00091", true),
                  new(23,"Miles", "Kilometers", "1.61", true),
                  new(24,"Ounces", "Milliliters", "29.57", true),
                  new(25,"Cups", "Milliliters", "236.6", true),
                  new(26,"Quarts", "Liters", "0.95", true),
                  new(27,"Gallons", "Liters", "3.785", true),
                  new(28,"Ounces", "Milligrams", "28350", true),
                  new(29,"Ounces", "Grams", "28.35", true),
                  new(30,"Pounds", "Kilograms", "0.454", true),
                  new(31,"Tons", "Kilograms", "907.18", true)
        };
    }
}
