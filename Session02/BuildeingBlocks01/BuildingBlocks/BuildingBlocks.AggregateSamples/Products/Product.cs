using BuildingBlocks.AggregateSamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.AggregateSamples.Products;
internal class Product : BaseAggregateRoot<int>
{
    public Product(int id) : base(id)
    {
    }
}
