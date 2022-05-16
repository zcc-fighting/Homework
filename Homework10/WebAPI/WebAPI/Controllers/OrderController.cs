using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using OrderManagement;
using WebAPI.Models;
using OrderManagement;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly OrderContext orderDB;

        public OrderController(OrderContext context)
        {
            orderDB = context;
        }


        //// GET: api/<controller> 查询订单
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<controller>/5 根据id查询
        [HttpGet]
        public ActionResult<List<Order>> Get(string id)
        {
            IQueryable<Order> query = BuildQuery(id);
            List<Order> orderList = query.ToList();
            orderList.Sort();
            return orderList;
            //return "value";
        }

        //构造Query
        public IQueryable<Order> BuildQuery(string Item)
        {

            IQueryable<Order> query = orderDB.Orders.Include(o => o.Client).Include(o => o.Items).ThenInclude(i => i.Id).
                                        Where(o => o.OrderId != null);
            if (Item != null)
            {
                query = query.Include(o => o.Client).Include(o => o.Items).ThenInclude(i => i.Id).
                            Where(o => o.Items.Any(i => i.Id == Item));
            }
            return query;
        }

        // POST api/<controller> 增加订单
        [HttpPost]
        public ActionResult<Order> Post(Order order)
        {
            try
            {
                order.Client = null;
                order.Items.ForEach(i => i.Prodc = null);
                orderDB.Orders.Add(order);
                orderDB.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return order;
        }

        // PUT api/<controller>/5 修改订单
        [HttpPut("{id}")]
        public ActionResult<Order> Put(string id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest("Id错误");
            }
            try
            {
                orderDB.Entry(order).State = EntityState.Modified;
                orderDB.SaveChanges();
            }
            catch (Exception e)
            {
                string error = e.Message;
                return BadRequest(error);
            }

            return NoContent();
        }

        // DELETE api/<controller>/5 删除订单
        [HttpDelete("{id}")]
        public ActionResult<Order> Delete(string id)
        {
            try
            {
                Order od = orderDB.Orders.FirstOrDefault(o => o.OrderId == id);
                if (od != null)
                {
                    orderDB.Orders.Remove(od);
                    orderDB.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();

        }



    }
}
