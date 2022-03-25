using Data_Acces;
using Microsoft.Extensions.Configuration;
using Online_Shop.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shop.Repository
{
    public class ProductRepository
    {
        private readonly string connectionString;
        private DataAcces db;

        public ProductRepository(string dataBase)
        {
            db = new DataAcces();
            var builder = new ConfigurationBuilder().SetBasePath
            (@"D:\1_PROGRAMARE\C#\Baza_De_Date\Online_Shop\Online_Shop").AddJsonFile("appsettings.json");
            var config = builder.Build();
            this.connectionString = config.GetConnectionString(dataBase);
        }

        public List<Product> getAll()
        {
            string sql = "select * from product";
            return db.LoadData<Product, dynamic>(sql, new { }, connectionString);
        }
        public void add(Product product)
        {
            string sql = "insert into product(categorie, name, description, date, image, price, stock) values(@categorie, @name, @description, @date, @image, @price, @stock)";
            db.SaveData(sql, new { product.Categorie, product.Name, product.Description, product.Date, product.Image, product.Price, product.Stock }, connectionString);
        }
        public void deleteById(int id)
        {
            string sql = "delete from product where id=@id";
            db.SaveData(sql, new { id }, connectionString);
        }
        public void delete(Product product)
        {
            string sql = "delete from product where categorie = @categorie and name = @name and description = @description and price = @price and stock = @stock";
            db.SaveData(sql, new { product.Categorie, product.Name, product.Description, product.Price, product.Stock }, connectionString);
        }

        public void updateCategorie(Product product, string newCategorie)
        {
            string sql = "update product set categorie=@newCategorie where categorie=@categorie and name=@name and description=@description and price = @price and stock = @stock";
            db.SaveData(sql, new { newCategorie, product.Categorie, product.Name, product.Description,product.Price, product.Stock }, connectionString);
        }
        public void updateName(Product product, string newName)
        {
            string sql = "update product set name=@newName where categorie=@categorie and name=@name and description=@description and price = @price and stock = @stock";
            db.SaveData(sql, new { newName, product.Categorie, product.Name, product.Description, product.Price, product.Stock }, connectionString);
        }
        public void updateDescription(Product product, string newDescription)
        {
            string sql = "update product set description=@newDescription where categorie=@categorie and name=@name and description=@description and price = @price and stock = @stock";
            db.SaveData(sql, new { newDescription, product.Categorie, product.Name, product.Description, product.Price, product.Stock }, connectionString);
        }
        public void updateDate(Product product, DateTime newDate)
        {
            string sql = "update product set date=@newDate where categorie=@categorie and name=@name and description=@description and price = @price and stock = @stock";
            db.SaveData(sql, new { newDate, product.Categorie, product.Name, product.Description, product.Price, product.Stock }, connectionString);
        }
        public void updateImage(Product product, Byte[] newImage)
        {
            string sql = "update product set image=@newImage where categorie=@categorie and name=@name and description=@description and price = @price and stock = @stock";
            db.SaveData(sql, new { newImage, product.Categorie, product.Name, product.Description, product.Price, product.Stock }, connectionString);
        }
        public void updatePrice(Product product, double newPrice)
        {
            string sql = "update product set price=@newPrice where categorie=@categorie and name=@name and description=@description and price = @price and stock = @stock";
            db.SaveData(sql, new { newPrice, product.Categorie, product.Name, product.Description, product.Price, product.Stock }, connectionString);
        }
        public void updateStock(Product product, int newStock)
        {
            string sql = "update product set stock=@newStock where categorie=@categorie and name=@name and description=@description and price = @price and stock = @stock";
            db.SaveData(sql, new { newStock, product.Categorie, product.Name, product.Description, product.Price, product.Stock }, connectionString);
        }

        public Product getProductWithId(int id)
        {
            string sql = "select * from product where id=@id";
            return db.LoadData<Product, dynamic>(sql, new { id }, connectionString)[0];
        }
        public int getIdWithProduct(Product product)
        {
            string sql = "select id from product where categorie=@categorie and name=@name and description=@description  and price = @price and stock = @stock";
            return db.LoadData<int, dynamic>(sql, new { product.Categorie, product.Name, product.Description, product.Price, product.Stock }, connectionString)[0];
        }
    }
}
