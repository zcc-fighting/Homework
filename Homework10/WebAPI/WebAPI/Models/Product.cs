using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement
{
    [Serializable]
    public class Product
    {
        [Key]
        public string ProductID { get; set; }

        public string Name { get; }
        public double Price { get; set; }

        public Product() {

        }
        public Product(string name,double price)
        {
            ProductID = Guid.NewGuid().ToString();
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return Name + '-' + Price + "元";
        }

        public override int GetHashCode()
        {
            var hashCode = 1479869798;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ProductID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
