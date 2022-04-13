using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TestMvc.Data;

public class SeedData
{
    public static void Initialize(IServiceProvider provider)
    {
        var options = provider.GetService<DbContextOptions<DataContext>>();
        using (var context = new DataContext(options))
        {
            context.Database.EnsureCreated();
        }
    }


}