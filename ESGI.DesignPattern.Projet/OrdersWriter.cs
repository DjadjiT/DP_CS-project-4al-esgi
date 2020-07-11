using System;
using System.Collections.Generic;
using System.Text;

namespace ESGI.DesignPattern.Projet
{
    public class OrdersWriter
    {
        private List<Order> orders;

        public OrdersWriter(List<Order> orders)
        {
            this.orders = orders;
        }

        public string GetContents()
        {
            StringBuilder xml = new StringBuilder();
            xml.Append(OpeningOrdersBracket());
            for (int i = 0; i < this.orders.Count; i++)
            {
                Order order = this.orders[i];
                xml.Append(OpeningOrderBracket(order.OrderId()));
                for (int j = 0; j < order.ProductCount(); j++)
                {
                    Product product = order.Product(j);
                    xml.Append(ProductString(product));
                }
                
                xml.Append(ClosingOrderBracket());
            }

            xml.Append(ClosingOrdersBracket());
            return xml.ToString();
        }

        private string CurrencyFor(Product product)
        {
            return "USD";
        }

        private string SizeFor(Product product)
        {
            switch (product.Size)
            {
                case ProductSize.Medium:
                    return "medium";
                default:
                    return "NOT APPLICABLE";
            }
        }

        private string ColorFor(Product product)
        {
            return "red";
        }

        private string OpeningOrdersBracket(){
            return "<orders>";
        }

        private string OpeningOrderBracket(int orderId){
            return "<order id='"+orderId+"'>"; 
        }

        private string ProductString(Product product){
            StringBuilder productStr = new StringBuilder();
            productStr.Append("<product id='" + product.ID + "' color='red'");
            if (product.Size != (int)ProductSize.NotApplicable)
            {
                productStr.Append(" size='" +this.SizeFor(product)+"'");
            }
            productStr.Append(">");
            productStr.Append("<price currency='" +this.CurrencyFor(product)+"'>"+
                product.Price+
                "</price>");

            productStr.Append(product.Name);
            productStr.Append("</product>");
            return productStr.ToString();
        }

        private string ClosingOrderBracket(){
            return "</order>";
        }

        private string ClosingOrdersBracket(){
            return "</orders>";
        }
    }
}
