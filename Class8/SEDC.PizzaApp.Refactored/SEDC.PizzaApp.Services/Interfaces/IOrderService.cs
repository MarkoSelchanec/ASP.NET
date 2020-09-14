using System;
using System.Collections.Generic;
using System.Text;
using SEDC.PizzaApp.ViewModels.Order;

namespace SEDC.PizzaApp.Services.Interfaces
{
    public interface IOrderService
    {
        List<OrderDetailsViewModel> GetAllOrders();
        OrderDetailsViewModel GetOrderById(int id);
        void CreateOrder(OrderViewModel orderViewModel);
        void AddPizzaToOrder(PizzaOrderViewModel pizzaOrderViewModel);
    }
}
