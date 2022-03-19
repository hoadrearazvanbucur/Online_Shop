using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shop.Model
{
    public class Order : IComparable
    {
        private int id, amount, customer_id;
        private string order_adress;

        public Order(int id,int amount,string order_adress,int customer_id)
        {
            this.id = id;
            this.amount = amount;
            this.customer_id = customer_id;
            this.order_adress = order_adress;
        }
        public Order(int amount, string order_adress, int customer_id)
        {
            this.amount = amount;
            this.customer_id = customer_id;
            this.order_adress = order_adress;
        }

        public override string ToString() => this.id + "," + this.amount + "," + this.order_adress + "," + this.customer_id;
        public override bool Equals(object obj) => (obj as Order).ToString() == this.ToString();
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public int Id
        {
            get => this.id;
            set => this.id = value;
        }
        public int Amount
        {
            get => this.amount;
            set => this.amount = value;
        }
        public int Customer_id
        {
            get => this.customer_id;
            set => this.customer_id = value;
        }
        public string Order_adress
        {
            get => this.order_adress;
            set => this.order_adress = value;
        }
    }
}
