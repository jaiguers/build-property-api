using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Domain.Tests.BaseContext
{
    public class RealEstateContextTestBase : IDisposable
    {
        protected readonly RealEstateContext context;

        public RealEstateContextTestBase()
        {
            var options = new DbContextOptionsBuilder<RealEstateContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            context = new RealEstateContext(options);
            context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
