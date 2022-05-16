using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement
{
    [Serializable]
    public class Order:IComparable
    {
        [Key]
        public string OrderId { get; set; }

        public Client Client { get; set; }
        //[ForeignKey("ClientID")]
        public string ClientID { get; set; }

        public string Address { get; set; }

        public List<OrderItem> Items { set; get; }  
        public double TotalPrice { get; }

        public Order() {
            OrderId = Guid.NewGuid().ToString();
            Items = new List<OrderItem>();
            Client = new Client("c01");
        }
        public Order(string id,Client c,string addr,List<OrderItem> items)
        {
            OrderId = id;
            Client = c;
            Address = addr;
            Items = items;
            TotalPrice = 0;
            foreach(OrderItem item in Items)
            {
                TotalPrice += item.ItemPrice;
            }
        }

        public void AddItem(OrderItem orderItem)
        {
            if (Items.Contains(orderItem))
                throw new ApplicationException($"添加错误：订单项已经存在!");
            Items.Add(orderItem);
        }

        public void RemoveItem(OrderItem orderItem)
        {
            Items.Remove(orderItem);
        }

        public override bool Equals(object obj)
        {
            Order od = obj as Order;
            return od != null && OrderId == od.OrderId;
        }

        public override string ToString()
        {
            string s = "订单ID:" + OrderId + '\t' + "Client:" + Client + '\t' +"OrderPrice:"+TotalPrice+ "\t\n";
            foreach (OrderItem item in Items) s += item + "\t\n";
            return s;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            Order od = obj as Order;
            if (od != null)
            {
                int id1 = Convert.ToInt32(this.OrderId.Remove(0, 1));
                int id2 = Convert.ToInt32(od.OrderId.Remove(0, 1));
                return id1 - id2;
            }
            throw new NotImplementedException();
        }
    }
}
