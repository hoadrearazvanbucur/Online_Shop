using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shop.Model
{
    public class Product : IComparable
    {
        private string categorie, name, description;
        private DateTime date;
        private Byte[] image;
        private int id, stock;
        private double price;

        public Product(int id,string categorie,string name,string description,DateTime date, Byte[] image,double price,int stock)
        {
            this.id = id;
            this.categorie = categorie;
            this.name = name;
            this.description = description;
            this.date = date;
            this.image = image;
            this.price = price;
            this.stock = stock;
        }
        public Product(string categorie, string name, string description, DateTime date, Byte[] image, double price, int stock)
        {
            this.categorie = categorie;
            this.name = name;
            this.description = description;
            this.date = date;
            this.image = image;
            this.price = price;
            this.stock = stock;
        }

        public override string ToString() => this.id + "," + this.categorie + "," + this.name + "," + this.description + "," + this.date + "," + this.image + "," + this.price + "," + this.stock;
        public override bool Equals(object obj) => (obj as Product).ToString() == this.ToString();
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public string Categorie
        {
            get => this.categorie;
            set => this.categorie = value;
        }
        public string Name
        {
            get => this.name;
            set => this.name = value;
        }
        public string Description
        {
            get => this.description;
            set => this.description = value;
        }
        public DateTime Date
        {
            get => this.date;
            set => this.date = value;
        }
        public Byte[] Image
        {
            get => this.image;
            set => this.image = value;
        }
        public int Id
        {
            get => this.id;
            set => this.id = value;
        }
        public int Stock
        {
            get => this.stock;
            set => this.stock = value;
        }
        public double Price
        {
            get => this.price;
            set => this.price = value;
        }
    }
}
