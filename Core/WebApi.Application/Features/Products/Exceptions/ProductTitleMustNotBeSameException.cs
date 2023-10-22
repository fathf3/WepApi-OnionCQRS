using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Bases;

namespace WebApi.Application.Features.Products.Exceptions
{
    public class ProductTitleMustNotBeSameException : BaseExceptions 
    {
        public ProductTitleMustNotBeSameException() : base("Aynı ürün mevcut")
        {
            
        }
        public ProductTitleMustNotBeSameException(string message) : base(message + " isimli başka ürün mevcut")
        {

        }
    }
}
