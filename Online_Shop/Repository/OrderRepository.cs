using Data_Acces;
using Microsoft.Extensions.Configuration;
using Online_Shop.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shop.Repository
{
    public class OrderRepository
    {
        private readonly string connectionString;
        private DataAcces db;

        public OrderRepository(string dataBase)
        {
            db = new DataAcces();
            var builder = new ConfigurationBuilder().SetBasePath
            (@"D:\1_PROGRAMARE\C#\Baza_De_Date\Online_Shop\Online_Shop").AddJsonFile("appsettings.json");
            var config = builder.Build();
            this.connectionString = config.GetConnectionString(dataBase);
        }

        public List<Order> getAll()
        {
            string sql = "select * from order_table";
            return db.LoadData<Order, dynamic>(sql, new { }, connectionString);
        }
        public void add(Order order)
        {
            string sql = "insert into order_table(amount, order_adress, customer_id) values(@amount, @order_adress, @customer_id)";
            db.SaveData(sql, new {order.Amount,order.Order_adress,order.Customer_id }, connectionString);
        }
        public void deleteById(int id)
        {
            string sql = "delete from order_table where id=@id";
            db.SaveData(sql, new { id }, connectionString);
        }
        public void delete(Order order)
        {
            string sql = "delete from order_table where amount=@amount and order_adress=@order_adress and customer_id=@customer_id";
            db.SaveData(sql, new { order.Amount,order.Order_adress,order.Customer_id}, connectionString);
        }

        public void updateAmount(Order order, int newAmount)
        {
            string sql = "update order_table set amount=@newAmount where amount=@amount and order_adress=@order_adress and customer_id=@order_adress";
            db.SaveData(sql, new {newAmount,order.Amount,order.Order_adress,order.Customer_id}, connectionString);
        }
        public void updateOrder_adress(Order order, string newOrder_adress)
        {
            string sql = "update order_table set order_adress=@newOrder_adress where amount=@amount and order_adress=@order_adress and customer_id=@order_adress";
            db.SaveData(sql, new { newOrder_adress, order.Amount, order.Order_adress, order.Customer_id }, connectionString);
        }


        public Order getProductWithId(int id)
        {
            string sql = "select * from order_table where id=@id";
            return db.LoadData<Order, dynamic>(sql, new { id }, connectionString)[0];
        }
        public int getIdWithProduct(Order order)
        {
            string sql = "select id from order_table where amount=@amount and order_adress=@order_adress and customer_id=@order_adress";
            return db.LoadData<int, dynamic>(sql, new {order.Amount, order.Order_adress, order.Customer_id }, connectionString)[0];
        }
    }
}
