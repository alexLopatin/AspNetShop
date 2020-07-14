using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNetShop.Server.Domain;
using AspNetShop.Server.Domain.Entities;
using AspNetShop.Shared.ModelView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetShop.Server.Controllers
{
    [ApiController]
    [Route("{controller}/{action=Get}")]
    public class OrderController : Controller
    {
        private DataManager dataManager;

        public OrderController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        //список заказов пользователя
        [HttpGet]
        [Authorize]
        public Order[] Get()
        {
            var orderEntities = dataManager.Orders.GetUserOrders(new Guid(User.FindFirstValue("Id")));

            List<Order> orders = new List<Order>();
            foreach (var orderEntity in orderEntities)
            {
                Order order = new Order();
                order.AllCountOfStates = 4;
                order.Id = orderEntity.OrderNumber;
                order.LastStateChangeTime = DateTime.Now;
                order.States = new List<string>();
                ((List<string>)order.States).Add("Сборка заказа");
                ((List<string>)order.States).Add("Отправка заказа в пункт выдачи");

                switch (orderEntity.DeliveryType)
                {
                    case 0:
                        order.DeliveryType = "Самовывоз";
                        order.DeliveryPrice = 0;
                        switch (orderEntity.DeliveryTypeOption)
                        {
                            case 0:
                                order.Address = "Москва, ул. Красноармейская д.12";
                                break;
                            case 1:
                                order.Address = "Санкт-Петербург, ул. Пушкина";
                                break;
                        }
                        break;
                    case 1:
                        order.DeliveryType = "Доставка курьером";
                        order.DeliveryPrice = 500;
                        switch (orderEntity.DeliveryTypeOption)
                        {
                            case 0:
                                order.Address = orderEntity.Address;
                                break;
                            case 1:
                                order.Address = orderEntity.Address;
                                break;
                        }
                        break;
                    case 2:
                        order.DeliveryType = "Доставка по почте";
                        order.DeliveryPrice = 200;
                        order.Address = orderEntity.Address;
                        break;
                }

                order.Products = new List<ProductOrder>();
                ProductOrder po = new ProductOrder();

                //po.ProductId = 1;
                //po.Count = 2;
                //po.Price = 10000;
                //((List<ProductOrder>)order.Products).Add(po);
                //po = new ProductOrder();
                //po.ProductId = 2;
                //po.Count = 1;
                //po.Price = 25000;
                //((List<ProductOrder>)order.Products).Add(po);

                var products = orderEntity.OrderProduct.Select(entity => entity.Product).ToList();
                foreach (var product in products)
                {
                    ((List<ProductOrder>) order.Products).Add(new ProductOrder()
                    {
                        Count = orderEntity.OrderProduct.Select(entity => entity.CountProduct).FirstOrDefault(),
                        Price = product.NewPrice,
                        ProductId = product.Id
                    });
                }

                orders.Add(order);
            }

            //List<Order> orders = new List<Order>();

            //Order order = new Order();
            //order.AllCountOfStates = 4;
            //order.DeliveryPrice = 200;
            //order.Id = 23;
            //order.LastStateChangeTime = DateTime.Parse("24.06.2020");

            //order.Products = new List<ProductOrder>();
            
            //order.DeliveryType = "Самовывоз";
            //order.Address = "Ул. Пушкина, д. Колотушкина";
            //order.States = new List<string>();
            //((List<string>)order.States).Add("Сборка заказа");
            //((List<string>)order.States).Add("Отправка заказа в пункт выдачи");

            //ProductOrder po = new ProductOrder();
            //po.ProductId = 1;
            //po.Count = 2;
            //po.Price = 10000;
            //((List<ProductOrder>)order.Products).Add(po);
            //po = new ProductOrder();
            //po.ProductId = 2;
            //po.Count = 1;
            //po.Price = 25000;
            //((List<ProductOrder>)order.Products).Add(po);

            //orders.Add(order);
            return orders.ToArray();
        }

        [HttpPost]
        [Authorize]
        public List<string> CreateOrder(Shared.Form.Order orderForm)
        {
            //OK - номер заказа, в ином случае ERROR - текст ошибки.  
            if (orderForm == null) {
                return new List<string>() { "ERROR", "orderForm = null" };
            }
            Random random = new Random();

            var order = new OrderEntity
            {
                Address = orderForm.Address,
                DeliveryType = orderForm.DeliveryType,
                DeliveryTypeOption = orderForm.DeliveryTypeOption,
                PaymentType = orderForm.PaymentType,
                OrderNumber = random.Next(100000, 999999),
                UserId = new Guid(User.FindFirstValue("Id"))
            };

            dataManager.Orders.SaveOrder(order, orderForm);
            return new List<string>() { "OK", order.OrderNumber.ToString() };
        }
    }
}
