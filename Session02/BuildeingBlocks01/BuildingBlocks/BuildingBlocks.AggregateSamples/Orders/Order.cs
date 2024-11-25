using BuildingBlocks.AggregateSamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.AggregateSamples.Orders;
internal class Order : BaseAggregateRoot<int>
{
    public List<OrderLine> OrderLines { get; set; }
    public int TotalPrice { get; set; }
    public Order(int id) : base(id)
    {
    }

    public void AddOrderLine(int id, int productId, int price)
    {
        //Validation
        //Pre Process
        OrderLine orderLine = new OrderLine(id, productId, price);

        OrderLines.Add(orderLine);
        AddDomainEvent(new ORderCreated());
        //Post Process

    }
}

public class OrderLine : BaseEntity<int>
{
    public OrderLine(int id, int productId, int price) : base(id)
    {
    }
}

public record ORderCreated : IDomainEvent
{

}
