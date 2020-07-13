﻿using System;
using System.Collections.Generic;
using System.Linq;
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
            List<Order> orders = new List<Order>();
            Order order = new Order();
            order.AllCountOfStates = 4;
            order.DeliveryPrice = 200;
            order.Id = 1;
            order.LastStateChangeTime = DateTime.Parse("24.06.2020");
            order.Products = new List<ProductOrder>();
            order.States = new List<string>();
            order.DeliveryType = "Самовывоз";
            order.Address = "Ул. Пушкина, д. Колотушкина";
            ((List<string>)order.States).Add("Сборка заказа");
            ((List<string>)order.States).Add("Отправка заказа в пункт выдачи");

            ProductOrder po = new ProductOrder();
            po.ProductId = 1;
            po.Count = 2;
            po.Price = 10000;
            ((List<ProductOrder>)order.Products).Add(po);
            po = new ProductOrder();
            po.ProductId = 2;
            po.Count = 1;
            po.Price = 25000;
            ((List<ProductOrder>)order.Products).Add(po);
            orders.Add(order);
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
                OrderNumber = random.Next(100000, 999999)
            };
            
            foreach(var prod in orderForm.Products) {
                order.OrderProduct.Add(new OrderProductEntity {
                    OrderId = order.Id,
                    ProductId = prod.ProductId
                });
            }

            dataManager.Orders.SaveOrder(order);

            
            return new List<string>() { "OK", order.OrderNumber.ToString() };
        }
    }
}
