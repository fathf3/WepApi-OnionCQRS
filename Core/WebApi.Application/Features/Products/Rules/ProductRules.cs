using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Bases;
using WebApi.Application.Features.Products.Exceptions;
using WebApi.Domain.Entities;

namespace WebApi.Application.Features.Products.Rules
{
    public class ProductRules : BaseRules
    {
        public Task ProductTitleMustNotBeSame(IList<Product> products, string productTitle)
        {
            if(products.Any(x => x.Title == productTitle)) throw new ProductTitleMustNotBeSameException($"'{productTitle}'");
            return Task.CompletedTask;
        }
    }
}
