using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildeingBlocks02.Products;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public static Product Create(int id, string name)
    {
        return new Product
        {
            Id = id,
            Name = name,
        };
    }
}
