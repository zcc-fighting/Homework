using Microsoft.VisualStudio.TestTools.UnitTesting;
using d1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d1.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void ShowOrderTest()
        {
            Order order1 = new Order();
            List<Order> order = new List<Order>();
            OrderService a = new OrderService();

            order1.Id = 001;
            order1.Customer = "客户一";
            order1.Name = "商品一";
            order1.Money = 10;
            order.Add(order1);

            a.ShowOrder();

            Assert.AreEqual(001, order1.Id);
            Assert.AreEqual("客户一", order1.Customer);
            Assert.AreEqual("商品一", order1.Name);
            Assert.AreEqual(10, order1.Money);
        }

        [TestMethod()]
        public void addOrderTest()
        {
            Order order2 = new Order();
            List<Order> order = new List<Order>();
            OrderService a = new OrderService();

            order2.Id = 001;
            order2.Customer = "客户一";
            order2.Name = "商品一";
            order2.addOrderItem("商品一", 5, 2);
            order.Add(order2);
            order2.getAllPrice();

            Assert.AreEqual(001, order[0].Id);
            Assert.AreEqual("客户一", order[0].Customer);
            Assert.AreEqual("商品一", order[0].Name);
            Assert.AreEqual(10, order[0].Money);
        }

        [TestMethod()]
        public void removeOrderTest()
        {
            Order order2 = new Order();
            Order order3 = new Order(); 
            List<Order> order = new List<Order>();
            OrderService a = new OrderService();

            order2.Id = 001;
            order2.Customer = "客户一";
            order2.Name = "商品一";
            order2.addOrderItem("商品一", 5, 2);
            order.Add(order2);
            order2.getAllPrice();

            order3.Id = 001;
            order3.Customer = "客户一";
            order3.Name = "商品一";
            order3.addOrderItem("商品一", 5, 2);
            order.Add(order3);
            order3.getAllPrice();

            order.Remove(order3);

            Assert.AreEqual(001, order[0].Id);
            Assert.AreEqual("客户一", order[0].Customer);
            Assert.AreEqual("商品一", order[0].Name);
            Assert.AreEqual(10, order[0].Money);
        }
    }
}