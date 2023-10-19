using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Common;

namespace WebApi.Domain.Entities
{
    public class Category : EntityBase
    {
        public Category()
        {
            
        }
        public Category(int parentId, string name, int priortyId)
        {
            this.ParentId = parentId;
            this.Name = name;
            this.Priorty = priortyId;
        }
        public int ParentId {get;set;}
        public string Name { get;set;}
        public int Priorty { get;set;}

        public ICollection<Detail> Details { get;set;}
        public ICollection<Product> Products { get;set;}

    }
}
