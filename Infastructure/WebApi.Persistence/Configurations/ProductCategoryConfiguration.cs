using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Entities;

namespace WebApi.Persistence.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(x => new {x.ProductId, x.CategoryId});
            
            builder.HasOne(p => p.Product)
                .WithMany(pc =>pc.ProductCategories)
                .HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(p => p.Category)
               .WithMany(pc => pc.ProductCategories)
               .HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
