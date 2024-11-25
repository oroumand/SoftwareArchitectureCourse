using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildeingBlocks02.Orders;
public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public int TotalPrice { get; private set; }

    public List<OrderLine> orderLines = [];

    public void AddLine(int productId, int productPrice, int qty)
    {
        var orderLine = new OrderLine();
        orderLine.ProductId = productId;
        orderLine.Price = productPrice;
        orderLine.Qty = qty;

        TotalPrice = orderLines.Sum(c => c.Price * c.Qty);
    }


}


public class OrderLine
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Price { get; set; }
    public int Qty { get; set; }
}