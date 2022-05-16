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
    public class OrderItem
    {
        [Key]
        public string Id { get; set; }

        public int Index { get; set; } 

        public Product Prodc { get; set; }
        //public string ProductID { get; set; }
        public int Num { get; set; }
        public double ItemPrice { get; set; }

        //[ForeignKey("OrderId")]
        //public int OrderId { set; get; }

        public OrderItem() {
            Id = Guid.NewGuid().ToString();
            Prodc = new Product("苹果", 5);
        }

        public OrderItem(string id,Product p,int num)
        {
            Id = id;
            Prodc = p;
            Num = num;
            ItemPrice = Num * Prodc.Price;
        }

        public override bool Equals(object obj)
        {
            var odi = obj as OrderItem;
            return odi != null && Prodc.ProductID== odi.Prodc.ProductID;
        }

        public override string ToString()
        {

            return "[Item]"+Id + '\t' + Prodc + '\t' + Num + '\t' + ItemPrice + '\t';
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
