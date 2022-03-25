using Online_Shop.Exceptions;
using Online_Shop.Model;
using Online_Shop.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shop.Services
{
    public class OrderServices
    {
        public OrderRepository orderRepository;

        public OrderServices(string dataBase)
        {
            this.orderRepository = new OrderRepository(dataBase);
        }

        public List<Order> lista()
        {
            return orderRepository.getAll();
        }

        public void create(Order order)
        {
            if (!this.exist(order.Amount,order.Order_adress,order.Customer_id))
            {
                this.orderRepository.add(order);
            }
            else
            {
                throw new OrderException("Aceasta comanda exista");
            }
        }
        public void deleteById(int id)
        {
            if (this.existId(id))
            {
                this.orderRepository.deleteById(id);
            }
            else
            {
                throw new OrderException("Aceasta comanda nu exista");
            }
        }
        public void delete(Order order)
        {
            if (this.exist(order.Amount,order.Order_adress,order.Customer_id))
            {
                this.orderRepository.delete(order);
            }
            else
            {
                throw new OrderException("Aceasta comanda nu exista");
            }
        }

        public void updateAmount(Order order, int newAmount)
        {
            if (this.exist(order.Amount, order.Order_adress, order.Customer_id))
            {
                this.orderRepository.updateAmount(order, newAmount);
            }
            else
            {
                throw new OrderException("Aceasta comanda nu exista");
            }
        }
        public void update(Order order, string newOrder_adress)
        {
            if (this.exist(order.Amount, order.Order_adress, order.Customer_id))
            {
                this.orderRepository.updateOrder_adress(order, newOrder_adress);
            }
            else
            {
                throw new OrderException("Aceasta comanda nu exista");
            }
        }



        public bool exist(int amount, string order_adress, int customer_id)
        {
            foreach (Order order in this.lista())
                if (order.Amount == amount && order.Order_adress == order_adress && order.Customer_id == customer_id)
                    return true;
            return false;
        }
        public bool existId(int id)
        {
            foreach (Order order in this.lista())
                if (order.Id == id)
                    return true;
            return false;
        }
    }
}
