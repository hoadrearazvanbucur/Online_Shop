using Data_Acces;
using Microsoft.Extensions.Configuration;
using Online_Shop.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shop.Repository
{
    public class CustomerRepository
    {
        private readonly string connectionString;
        private DataAcces db;

        public CustomerRepository(string dataBase)
        {
            db = new DataAcces();
            var builder = new ConfigurationBuilder().SetBasePath
            (@"D:\1_PROGRAMARE\C#\Baza_De_Date\Online_Shop\Online_Shop").AddJsonFile("appsettings.json");
            var config = builder.Build();
            this.connectionString = config.GetConnectionString(dataBase);
        }

        public List<Customer> getAll()
        {
            string sql = "select * from customer";
            return db.LoadData<Customer, dynamic>(sql, new { }, connectionString);
        }

        public void add(Customer customer)
        {
            string sql = "insert into customer(email, password, full_name) values (@email, @password, @full_name)";
            db.SaveData(sql, new { customer.Email, customer.Password, customer.Full_name }, connectionString);
        }
        public void deleteById(int id)
        {
            string sql = "delete from customer where id=@id";
            db.SaveData(sql, new { id }, connectionString);
        }
        public void delete(Customer customer)
        {
            string sql = "delete from customer where email=@email and password=@password and full_name=@full_name";
            db.SaveData(sql, new { customer.Email, customer.Password, customer.Full_name }, connectionString);
        }

        public void updateEmail(Customer customer, string newEmail)
        {
            string sql = "update customer set email=@newEmail where email=@email and password=@password and full_name=@full_name";
            db.SaveData(sql, new { newEmail, customer.Email, customer.Password, customer.Full_name }, connectionString);
        }
        public void updatePassword(Customer customer, string newPassword)
        {
            string sql = "update customer set password=@newPassword where email=@email and password=@password and full_name=@full_name";
            db.SaveData(sql, new { newPassword, customer.Email, customer.Password, customer.Full_name }, connectionString);
        }
        public void updateFull_name(Customer customer, string newFull_name)
        {
            string sql = "update customer set full_name=@newFull_name where email=@email and password=@password and full_name=@full_name";
            db.SaveData(sql, new { newFull_name, customer.Email, customer.Password, customer.Full_name }, connectionString);
        }

        public Customer getCustomerWithId(int id)
        {
            string sql = "select * from customer where id=@id";
            return db.LoadData<Customer, dynamic>(sql, new { id }, connectionString)[0];
        }
        public int getIdWithCustomer(Customer customer)
        {
            string sql = "select id from customer where email=@email and password=@password and full_name=@full_name";
            return db.LoadData<int, dynamic>(sql, new { customer.Email, customer.Password, customer.Full_name }, connectionString)[0];
        }
    }
}
