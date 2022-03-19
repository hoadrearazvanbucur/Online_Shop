using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shop.Model
{
    public class OrderDetail : IComparable
    {
        private int id, order_id, product_id, quantity;
        private double price;

        public OrderDetail(int id,int order_id,int product_id,int quantity,double price)
        {
            this.id = id;
            this.order_id = order_id;
            this.product_id = product_id;
            this.quantity = quantity;
            this.price = price;
        }
        public OrderDetail(int order_id, int product_id, int quantity, double price)
        {
            this.order_id = order_id;
            this.product_id = product_id;
            this.quantity = quantity;
            this.price = price;
        }

        public override string ToString() => this.id + "," + this.order_id + "," + this.product_id + "," + this.quantity + "," + this.price;
        public override bool Equals(object obj) => (obj as OrderDetail).ToString() == this.ToString();
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public int Id
        {
            get => this.id;
            set => this.id = value;
        }
        public int Order_id
        {
            get => this.order_id;
            set => this.order_id = value;
        }
        public int Product_id
        {
            get => this.product_id;
            set => this.product_id = value;
        }
        public int Quantity
        {
            get => this.quantity;
            set => this.quantity = value;
        }
        public double Price
        {
            get => this.price;
            set => this.price = value;
        }
    }
}
