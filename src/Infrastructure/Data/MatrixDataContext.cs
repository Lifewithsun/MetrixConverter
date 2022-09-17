using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;


namespace Infrastructure.Data;

public class MatrixDataContext : DbContext
{
    public MatrixDataContext(DbContextOptions<MatrixDataContext> options) : base(options)
    {
    }

   
    public DbSet<MatrixDataItem> MatrixDataItems { get; set; }
  

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
